using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Models
{
    public class AweAppUser : IdentityUser<int>
    {
        public virtual DateTime DateIns { get; set; }
        public virtual DateTime LastModification { get; set; }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
