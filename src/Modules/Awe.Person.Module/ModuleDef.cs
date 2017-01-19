using Awe.Module.Core;
using System;

[assembly: DefaultNamespace("Awe.Person.Module")]
namespace Awe.Person.Module
{
    public class ModuleDef : IAweModule
    {
        public ModuleDef()
        {
        }

        public string Name { get { return "Pessoas"; } }

        public string Description { get { return "Módulo de Pessoas [descrição...]"; } }

        public int? Order { get { return 0; } }

        public string RootMenuDefaultTitle { get { return "Pessoas"; } }
    }
}
