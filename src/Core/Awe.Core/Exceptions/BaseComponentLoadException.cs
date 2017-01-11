using System;

namespace Awe.Core
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
