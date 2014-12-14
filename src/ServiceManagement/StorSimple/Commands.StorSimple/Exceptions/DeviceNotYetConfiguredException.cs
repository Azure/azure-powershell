using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Exceptions
{
    [Serializable]
    public class DeviceNotYetConfiguredException : Exception
    {
        static String genericErrorMessage = "The device name you have specified is not yet configured fully. Please complete the configuration and retry";
        /// <summary>
        /// Create a new instance with error message
        /// </summary>
        /// <param name="message">error message</param>
        public DeviceNotYetConfiguredException(String message)
            : base(message)
        { }

        public DeviceNotYetConfiguredException()
            : base(genericErrorMessage)
        {

        }
    }
}
