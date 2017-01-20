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

            if (menuService != null)
            {
                var asms = AssemblyTools.LoadAssembliesThatImplements<T>(FolderPath);
                var t = typeof(Controller);
                var tMethod = typeof(IActionResult);
                var tModule = typeof(IAweModule);

                foreach (var asm in asms)
                {
                    var moduleType = asm.GetTypes().FirstOrDefault(i => !i.GetTypeInfo().IsInterface && tModule.IsAssignableFrom(i));

                    var module = CreateModuleInstance(moduleType);

                    var rootMenuDefaultTitle = module?.RootMenuDefaultTitle;

                    var controllers = asm.GetTypes().Where(i => !i.GetTypeInfo().IsInterface
                                                                && t.IsAssignableFrom(i))
                                                    .ToList();

                    foreach (var controller in controllers)
                    {
                        var methods = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                                .Where(m => !m.IsVirtual
                                                            && tMethod.IsAssignableFrom(m.ReturnType)
                                                            && m.GetCustomAttribute<MenuAttribute>() != null)
                                                .ToList();

                        foreach (var method in methods)
                        {
                            var menuAttr = method.GetCustomAttribute<MenuAttribute>();
                            var routeAttr = method.GetCustomAttribute<RouteAttribute>();

                            AweMenuItem menu;

                            var category = string.IsNullOrWhiteSpace(rootMenuDefaultTitle) ? menuAttr.Category : rootMenuDefaultTitle;

                            if (routeAttr == null)
                            {
                                menu = new AweMenuItem(controller.Name, method.Name, menuAttr.Parent, menuAttr.Title, menuAttr.Hint, menuAttr.Order, menuAttr.Icon);
                            }
                            else
                            {
                                menu = new AweMenuItem(routeAttr.Name, menuAttr.Parent, menuAttr.Title, menuAttr.Hint, menuAttr.Order, menuAttr.Icon);
                            }

                            var categoryOrder = module?.Order ?? menuAttr.CategoryOrder ?? 9999;

                            menuService.RegisterMenu(categoryOrder, category, menu);
                        }
                    }
                }
            }

            return ReturnObj;
        }

        private static IAweModule CreateModuleInstance(Type moduleType)
        {
            return moduleType != null ? ((IAweModule)Activator.CreateInstance(moduleType)) : null;
        }
    }
}
