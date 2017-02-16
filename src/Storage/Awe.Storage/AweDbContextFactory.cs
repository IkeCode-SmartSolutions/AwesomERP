using Awe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Storage
{
    public class AweDbContextFactory<TContext> : IDbContextFactory<TContext>
         where TContext : DbContext
    {
        private readonly AweAppTenant _tenant;
        public AweDbContextFactory(AweAppTenant tenant)
        {
            _tenant = tenant;
        }

        public TContext Create(DbContextFactoryOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
