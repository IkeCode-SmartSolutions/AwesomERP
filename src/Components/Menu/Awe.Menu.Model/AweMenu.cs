using Awe.Core.Crypto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Awe.Menu
{
    public class AweMenu
    {
        public AweMenu()
        {
        }
        
        public int Id { get; set; }
        public int? ParentId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Hint { get; set; }
        public int Order { get; set; }
        [Required]
        public string RouteUrl { get; set; }
        public string Icon { get; set; }

        public List<AweMenu> Children { get; set; }
        public AweMenu Parent { get; set; }

        public string GetSignature()
        {
            var key = $"{Id}_{Title}_{RouteUrl}";
            return CryptoTools.CalculateMD5Hash(key);
        }
    }
}
