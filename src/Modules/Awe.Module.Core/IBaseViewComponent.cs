using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core
{
    public interface IBaseComponent
    {
        string Name { get; }
        string Description { get; }
    }
}
