using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Encryption
{
    public class StorSimpleSecretManagementException : Exception
    {
        public KeyStoreOperationStatus OperationStatus{ get; set; }

        public StorSimpleSecretManagementException(string message, KeyStoreOperationStatus status) : base(message)
        {
            this.OperationStatus = status;
        }

    }
}
