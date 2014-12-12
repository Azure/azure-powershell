using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Exceptions
{
    [Serializable]
    public class NoDeviceRegisteredException : Exception
    {
        static String genericErrorMessage = "No StorSimple device is currently registered with this resource. Please register at least one device to the resource and rerun this command.";
        /// <summary>
        /// Create a new instance with error message
        /// </summary>
        /// <param name="message">error message</param>
        public NoDeviceRegisteredException(String message)
            : base(message)
        { }

        public NoDeviceRegisteredException()
            : base(genericErrorMessage)
        {

        }
    }
}
