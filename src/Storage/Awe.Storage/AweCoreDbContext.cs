using Microsoft.EntityFrameworkCore;
using Awe.Models;
using Microsoft.Extensions.Configuration;

namespace Awe.Storage
{
    public class AweCoreDbContext : DbContext
    {
        public DbSet<AweTheme> Themes { get; set; }
        public DbSet<AweThemeSkin> ThemeSkins { get; set; }
        public DbSet<AweThemeVariant> ThemeVariants { get; set; }
        public DbSet<AweMenuItem> MenuItems { get; set; }
        public DbSet<AweAppTenant> Tenants { get; set; }
        public DbSet<AweTenantHost> TenantHosts { get; set; }

        public AweCoreDbContext()
        {

        }
        
        public AweCoreDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
