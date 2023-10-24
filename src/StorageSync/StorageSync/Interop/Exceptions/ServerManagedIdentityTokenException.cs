using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using System;
using System.Net;

namespace Microsoft.Azure.Commands.StorageSync.Interop.Exceptions
{
    /// <summary>
    /// Exception class for Managed Identity library
    /// </summary>
    public class ServerManagedIdentityTokenException : Exception
    {
        public ManagedIdentityErrorCodes ErrorCode { get; private set; }

        public HttpStatusCode? HttpStatusCode { get; private set; }
        public ServerManagedIdentityTokenException(ManagedIdentityErrorCodes errorCode, string message, Exception innerException, HttpStatusCode? httpStatusCode = System.Net.HttpStatusCode.Unused) :
            base(message, innerException)
        {
            this.ErrorCode = errorCode;
            this.HttpStatusCode = httpStatusCode;
        }
    }
}
