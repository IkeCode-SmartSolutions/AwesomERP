using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awe.Models
{
    public abstract class AweBaseModel
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int? UserId { get; set; }
        public virtual DateTime DateIns { get; set; }
        public virtual DateTime LastModification { get; set; }
    }
}
