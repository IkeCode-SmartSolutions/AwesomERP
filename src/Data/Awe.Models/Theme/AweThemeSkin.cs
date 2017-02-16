using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Models
{
    public class AweThemeSkin : AweBaseModel
    {
        public string CssFile { get; set; }
        public int ThemeId { get; set; }
        public AweTheme Theme { get; set; }
        public string ThumbUrl { get; set; }
    }
}
