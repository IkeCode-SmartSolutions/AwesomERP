using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core
{
    public class BaseComponentLoadException : Exception
    {
        public BaseComponentLoadException(string message)
            :base(message)
        {

        }

        public BaseComponentLoadException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
