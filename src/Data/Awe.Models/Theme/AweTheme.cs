using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Models
{
    public class AweTheme : AweBaseModel
    {
        public List<AweThemeVariant> Variants { get; set; }
        public string SkinsPath { get; set; }
        public List<AweThemeSkin> Skins { get; set; }
        public List<AweAppTenant> Tenants { get; set; }
    }
}
