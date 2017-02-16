using System.Collections.Generic;

namespace Awe.Models
{
    public class AweAppTenant : AweBaseModel
    {
        /// <summary>
        /// Used in case of TenantHost.ConnectionString was empty
        /// </summary>
        public string ConnectionString { get; set; }

        public List<AweTenantHost> TenantHosts { get; set; }
        public List<AweTheme> Themes { get; set; }
    }
}
