using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Exceptions
{
    [Serializable]
    public class ResourceContextNotFoundException : Exception
    {
        static String genericErrorMessage = "Resource Context is not set for your subscription. Please use Select-AzureStorSimpleResource -ResourceName <<name>> to set";
        /// <summary>
        /// Create a new instance with error message
        /// </summary>
        /// <param name="message">error message</param>
        public ResourceContextNotFoundException(String message)
            : base(message)
        { }

        public ResourceContextNotFoundException():base(genericErrorMessage)
        {

        }
    }
}
