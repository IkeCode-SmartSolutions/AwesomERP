//using Awe.Menu;
//using Awe.Menu.Service;
using Awe.Module.Core;
using System;

[assembly: DefaultNamespace("Awe.Person.Module")]
namespace Awe.Person.Module
{
    public class ModuleDef : IAweModule
    {
        //private IAweMenuService _menuService;
        public ModuleDef(/*IAweMenuService menuService*/)
        {
            //_menuService = menuService;
            //menuService.RegisterMenu(new AweMenu
            //{
            //    Id = 1,
            //    Title = "Teste 01",
            //    Order = 1,
            //    RouteUrl = "/testeurl"
            //});
        }

        public string Name { get { return "Pessoas"; } }

        public string Description { get { return "Módulo de Pessoas [descrição...]"; } }
    }
}
