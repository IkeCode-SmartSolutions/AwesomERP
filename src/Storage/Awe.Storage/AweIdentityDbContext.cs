using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Awe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Awe.Storage
{
    public class AweIdentityDbContext : IdentityDbContext
    {
        public AweIdentityDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
