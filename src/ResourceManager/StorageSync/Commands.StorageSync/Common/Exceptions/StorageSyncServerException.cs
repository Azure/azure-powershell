using System;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.StorageSync.Common.Exceptions
{

    [Serializable]
    public class StorageSyncServerException : ApplicationException
    {
        protected const string RequestIdHeaderInResponse = "x-ms-request-id";

        public StorageSyncServerException()
            : base()
        {
        }

        public StorageSyncServerException(string message)
            : base(message)
        {
        }

        public StorageSyncServerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public StorageSyncServerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }
}
