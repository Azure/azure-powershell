using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Exceptions
{
    [Serializable]
    public class StorSimpleTaskNotFoundException : Exception
    {
        static String genericErrorMessage = "The TaskId provided does not exist. Please try with a valid task instance Id.";
        /// <summary>
        /// Create a new instance with error message
        /// </summary>
        /// <param name="message">error message</param>
        public StorSimpleTaskNotFoundException(String message)
            : base(message)
        { }

        public StorSimpleTaskNotFoundException()
            : base(genericErrorMessage)
        {

        }
    }
}
