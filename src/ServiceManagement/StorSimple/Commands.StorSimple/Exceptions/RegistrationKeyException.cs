using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Exceptions
{
    [Serializable]
    public class RegistrationKeyException : Exception
    {
        /// <summary>
        /// Create a new instance with error message
        /// </summary>
        /// <param name="message">error message</param>
        public RegistrationKeyException(String message)
            : base(message)
        { }

        public RegistrationKeyException(string message, Exception e) : base(message, e) { }

    }
}
