using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Models
{
    public class AweThemeVariant : AweBaseModel
    {
        public int ThemeId { get; set; }
        public AweTheme Theme { get; set; }
    }
}
