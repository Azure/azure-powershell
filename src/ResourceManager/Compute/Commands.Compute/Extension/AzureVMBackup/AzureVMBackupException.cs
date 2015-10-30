using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureVMBackup
{
    public class AzureVMBackupErrorCodes
    {
        public const int TimeOut = 1;
        public const int OSNotSupported = 2;
        public const int WrongBlobUriFormat = 3;
    }

    public class AzureVMBackupException : Exception
    {
        public AzureVMBackupException(int errorCode,string message):base(message)
        {
            this.AzureVMBackupErrorCode = errorCode;
        }
        public int AzureVMBackupErrorCode { get; set; }
    }
}
