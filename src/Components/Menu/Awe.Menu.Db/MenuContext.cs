﻿using Microsoft.EntityFrameworkCore;

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