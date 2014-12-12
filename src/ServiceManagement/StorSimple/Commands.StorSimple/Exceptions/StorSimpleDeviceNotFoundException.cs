using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Exceptions
{
    [Serializable]
    public class StorSimpleDeviceNotFoundException : Exception
    {
        static String genericErrorMessage = "The device name provided does not exist under your currently selected resource. To get a list of all available devices use Get-AzureStorSimpleDevice";
        /// <summary>
        /// Create a new instance with error message
        /// </summary>
        /// <param name="message">error message</param>
        public StorSimpleDeviceNotFoundException(String message)
            : base(message)
        { }

        public StorSimpleDeviceNotFoundException()
            : base(genericErrorMessage)
        {

        }
    }
}
