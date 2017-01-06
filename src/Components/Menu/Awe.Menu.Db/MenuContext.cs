using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Menu.Db
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options)
            : base(options)
        {

        }

        public DbSet<AweMenu> Menus { get; set; }
    }
}
