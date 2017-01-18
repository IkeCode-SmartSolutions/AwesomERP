using Awe.Core.Reflection;
using Awe.Menu;
using Awe.Menu.Service;
using Awe.Module.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Awe.Mvc.Core.Middlewares
{
    public class AweModulesMenusRegister : AweBaseMiddleware<IApplicationBuilder>
    {
        private AweModulesMenusRegister(IApplicationBuilder builder, string folderPath)
            : base(folderPath)
        {
            ReturnObj = builder;
        }

        public static AweModulesMenusRegister CreateInstance(IApplicationBuilder mvcBuilder, string folderPath)
        {
            return new AweModulesMenusRegister(mvcBuilder, folderPath);
        }

        public override IApplicationBuilder Invoke<T>()
        {
            var menuService = ReturnObj.ApplicationServices.GetService<IAweMenuService>();

            //TODO
            if (false && menuService != null)
            {
                var asms = AssemblyTools.LoadAssembliesThatImplements<T>(FolderPath);
                var t = typeof(Controller);
                var tMethod = typeof(IActionResult);

                var menus = new List<AweMenu>();

                foreach (var asm in asms)
                {
                    var controllers = asm.GetTypes().Where(i => !i.GetTypeInfo().IsInterface
                                                                 && t.IsAssignableFrom(i)).ToList();

                    var moduleType = asm.GetTypes()
                                            .Where(i => i.GetTypeInfo().ImplementedInterfaces.OfType<IAweModule>() != null)
                                            .ToList();

                    if (moduleType.FirstOrDefault() != null)
                    {
                        IAweModule module = (IAweModule)Activator.CreateInstance(moduleType.FirstOrDefault());

                        foreach (var controller in controllers)
                        {
                            var methods = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                                    .Where(m => !m.IsVirtual
                                                                && tMethod.IsAssignableFrom(m.ReturnType)
                                                                && m.GetCustomAttribute<MenuAttribute>() != null)
                                                    .ToList();

                            foreach (var method in methods)
                            {

                            }
                        }
                    }
                }
            }

            return ReturnObj;
        }
    }
}
