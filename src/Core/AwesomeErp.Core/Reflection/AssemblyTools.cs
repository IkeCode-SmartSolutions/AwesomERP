using Microsoft.DotNet.InternalAbstractions;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Loader;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using AwesomeErp.Core.Crypto;
using Microsoft.DotNet.PlatformAbstractions;

namespace AwesomeErp.Core.Reflection
{
    public class AssemblyLoader : AssemblyLoadContext
    {
        private string folderPath;

        public AssemblyLoader(string folderPath)
        {
            this.folderPath = folderPath;
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            var deps = DependencyContext.Default;
            var res = deps.CompileLibraries.Where(d => d.Name.Contains(assemblyName.Name)).ToList();

            if (res.Count > 0)
            {
                return Assembly.Load(new AssemblyName(res.First().Name));
            }
            else
            {
                var apiApplicationFileInfo = new FileInfo($"{folderPath}{Path.DirectorySeparatorChar}{assemblyName.Name}.dll");
                if (File.Exists(apiApplicationFileInfo.FullName))
                {
                    var asl = new AssemblyLoader(apiApplicationFileInfo.DirectoryName);
                    return asl.LoadFromAssemblyPath(apiApplicationFileInfo.FullName);
                }
            }

            return Assembly.Load(assemblyName);
        }
    }

    public static class AssemblyTools
    {
        internal static readonly string[] _ignoredSystemAssemblies = { "System", "Microsoft", "Nuget", "mscorlib", "dotnet-", "Newtonsoft" };

        private static Dictionary<string, List<Assembly>> _assembliesCache { get; set; } = new Dictionary<string, List<Assembly>>();

        public static string GetDefaultNamespace(Assembly asm)
        {
            var attr = asm.GetCustomAttribute<DefaultNamespaceAttribute>();

            return attr != null ? attr.DefaultNamespace : string.Empty;
        }

        private static string GetCacheKey(string folderPath, bool ignoreSystemAssemblies = true, params string[] ignoredAssemblies)
        {
            var cacheKey = string.Empty;

            var ignoredString = string.Join(",", ignoredAssemblies);

            var result = $"{folderPath}_{ignoredAssemblies}_{ignoredString}";

            cacheKey = CryptoTools.CalculateMD5Hash(result);

            return cacheKey;
        }

        public static IEnumerable<Assembly> LoadAssemblies(string folderPath, bool ignoreSystemAssemblies = true, params string[] ignoredAssemblies)
        {
            var cacheKey = GetCacheKey(folderPath, ignoreSystemAssemblies, ignoredAssemblies);

            if (_assembliesCache.ContainsKey(cacheKey))
            {
                foreach (var cached in _assembliesCache[cacheKey])
                {
                    yield return cached;
                }
            }
            else
            {
                _assembliesCache[cacheKey] = new List<Assembly>();

                var runtimeId = RuntimeEnvironment.GetRuntimeIdentifier();
                var assemblieNames = DependencyContext.Default.GetRuntimeAssemblyNames(runtimeId);

                if (ignoreSystemAssemblies)
                {
                    assemblieNames = assemblieNames
                                    .Where(asm => _ignoredSystemAssemblies
                                                        .All(sysName => !asm.Name.StartsWith(sysName, StringComparison.CurrentCultureIgnoreCase))
                                          );
                }

                if (ignoredAssemblies.Length > 0)
                {
                    assemblieNames = assemblieNames
                                    .Where(asm => _ignoredSystemAssemblies
                                                        .All(sysName => !asm.Name.Equals(sysName, StringComparison.CurrentCultureIgnoreCase))
                                          );
                }

                if (assemblieNames.Count() == 0)
                    yield break;

                var asl = new AssemblyLoader(folderPath);

                foreach (var asmName in assemblieNames)
                {
                    var assembly = asl.LoadFromAssemblyName(asmName);

                    _assembliesCache[cacheKey].Add(assembly);

                    yield return assembly;
                }
            }
        }

        public static IEnumerable<Assembly> LoadAssembliesThatImplements<T>(string folderPath, bool ignoreSystemAssemblies = true, params string[] ignoredAssemblies)
        {
            var type = typeof(T);

            var result = new List<Assembly>();

            foreach (var asm in LoadAssemblies(folderPath, ignoreSystemAssemblies, ignoredAssemblies))
            {
                var moduleTypes = asm.GetTypes().Where(a => !a.GetTypeInfo().IsInterface
                                                             && type.IsAssignableFrom(a));

                var isAssignable = moduleTypes != null && moduleTypes.Count() > 0;

                if (!isAssignable)
                    continue;

                result.Add(asm);
            }

            return result;
        }
    }
}
