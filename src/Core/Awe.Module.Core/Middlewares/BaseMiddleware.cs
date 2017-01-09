using Awe.Core.Reflection;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;

namespace Module.Core.Middlewares
{
    public abstract class BaseMiddleware<TReturnObject>
    {
        protected readonly string FolderPath;
        protected TReturnObject ReturnObj;

        public BaseMiddleware(string folderPath)
        {
            FolderPath = folderPath;
        }
        
        public virtual void CheckIntegrity<T>(out List<IFileProvider> providers)
        {
            var moduleAsms = AssemblyTools.LoadAssembliesThatImplements<T>(FolderPath);

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

        public abstract TReturnObject Invoke<T>();
    }
}
