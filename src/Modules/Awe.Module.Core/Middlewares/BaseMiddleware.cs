using AwesomeErp.Core.Reflection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Middlewares
{
    public abstract class BaseMiddleware
    {
        protected readonly string _folderPath;

        public BaseMiddleware(string folderPath)
        {
            _folderPath = folderPath;
        }
        
        public virtual void CheckIntegrity<T>(out List<IFileProvider> providers)
        {
            var moduleAsms = AssemblyTools.LoadAssembliesThatImplements<T>(_folderPath);

            providers = new List<IFileProvider>();

            var type = typeof(T);

            foreach (var moduleAsm in moduleAsms)
            {
                var ns = AssemblyTools.GetDefaultNamespace(moduleAsm);

                if (string.IsNullOrWhiteSpace(ns))
                {
                    var asmName = moduleAsm.GetName().Name;
                    throw new BaseComponentLoadException($"'DefaultNamespaceAttribute' was not found on type {asmName}. Consider add attribute on {type.Name} class implementation (e.g. [assembly: DefaultNamespace(nameof({asmName}))])");
                }

                var embeddedFileProvider = new EmbeddedFileProvider(moduleAsm, ns);
                providers.Add(embeddedFileProvider);
            }
        }
    }
}
