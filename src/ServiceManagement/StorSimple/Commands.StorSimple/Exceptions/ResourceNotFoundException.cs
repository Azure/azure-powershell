using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Exceptions
{
    [Serializable]
    public class StorSimpleResourceNotFoundException : Exception
    {
        static String genericErrorMessage = "The resourcename provided does not exist under your subscription. To get a list of all available resources use Get-AzureStorSimpleResource";
        /// <summary>
        /// Create a new instance with error message
        /// </summary>
        /// <param name="message">error message</param>
        public StorSimpleResourceNotFoundException(String message)
            : base(message)
        { }

        public StorSimpleResourceNotFoundException()
            : base(genericErrorMessage)
        {

        }
    }
}
