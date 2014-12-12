using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Exceptions
{
    [Serializable]
    public class StorSimpleJobNotFoundException : Exception
    {
        static String genericErrorMessage = "The JobId provided does not exist. Please try with a valid job instance Id.";
        /// <summary>
        /// Create a new instance with error message
        /// </summary>
        /// <param name="message">error message</param>
        public StorSimpleJobNotFoundException(String message)
            : base(message)
        { }

        public StorSimpleJobNotFoundException()
            : base(genericErrorMessage)
        {

        }
    }
}
