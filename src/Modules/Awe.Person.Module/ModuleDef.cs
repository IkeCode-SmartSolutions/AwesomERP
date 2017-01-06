using Awe.Menu;
using Awe.Menu.Service;
using Module.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: DefaultNamespace(nameof(PersonModule))]
namespace PersonModule
{
    public class ModuleDef : IBaseModule
    {
        private IAweMenuService _menuService;
        public ModuleDef(IAweMenuService menuService)
        {
            _menuService = menuService;
            menuService.RegisterMenu(new AweMenu
            {
                Id = 1,
                Title = "Teste 01",
                Order = 1,
                RouteUrl = "/testeurl"
            });
        }

        public string Name { get { return "Pessoas"; } }

        public string Description { get { return "Módulo de Pessoas [descrição...]"; } }
    }
}
