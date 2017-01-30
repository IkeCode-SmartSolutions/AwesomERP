using Awe.Core.Reflection;
using Awe.Module.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Awe.Mvc.Core.Middlewares
{
    public class AweThemeRegister : AweBaseMiddleware<IServiceCollection>
    {
        private IServiceCollection _serviceCollection;

        private AweThemeRegister(IServiceCollection serviceCollection, string folderPath)
            : base(folderPath)
        {
            _serviceCollection = serviceCollection;
        }

        public static AweThemeRegister CreateInstance(IServiceCollection serviceCollection, string folderPath)
        {
            return new AweThemeRegister(serviceCollection, folderPath);
        }

        public override IServiceCollection Invoke<T>()
        {
            var types = AssemblyTools.LoadTypesThatImplements<T>(FolderPath);

            var ctorTypes = new Type[] { typeof(IServiceCollection) };
            foreach (var type in types)
            {
                object[] args = new object[0];

                var isServiceCollectionConstructor = type.GetConstructor(ctorTypes) != null;

                if (isServiceCollectionConstructor)
                {
                    args = new object[] { _serviceCollection };
                }

                var instance = type.CreateInstance<IAweTheme>(args);
                instance?.RegisterServices();
            }

            return ReturnObj;
        }
    }
}
