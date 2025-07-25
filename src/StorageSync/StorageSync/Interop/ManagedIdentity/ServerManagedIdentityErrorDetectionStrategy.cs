


using Microsoft.Azure.Commands.StorageSync.Interop.Exceptions;
using Microsoft.Rest.TransientFaultHandling;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity
{

    public class ServerManagedIdentityErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        /// <summary>
        /// Determines whether the specified exception represents a transient failure that
        /// can be compensated by a retry.
        /// </summary>
        /// <param name="ex">The exception object to be verified.</param>
        /// <returns>true if the specified exception is considered as transient; otherwise, false.</returns>
        public bool IsTransient(Exception ex)
        {
            bool isTransient = false;

            // Exceptions should come in as ServerManagedIdentityTokenException
            // The inner exception should have the true exception
            var innerException = ex.InnerException;

            if (innerException != null)
            {
                if (innerException is TaskCanceledException)
                {
                    isTransient = true;
                }
                else
                {

                    ServerManagedIdentityTokenException serverManagedIdentityTokenException = innerException as ServerManagedIdentityTokenException;
                    if (serverManagedIdentityTokenException != null && serverManagedIdentityTokenException.HttpStatusCode.HasValue)
                    {
                        var statusCode = serverManagedIdentityTokenException.HttpStatusCode.Value;

                        // 429 (Too Many Requests) not part of HttpStatusCode
                        if (statusCode == HttpStatusCode.NotFound ||
                            statusCode == HttpStatusCode.RequestTimeout ||
                            statusCode == HttpStatusCode.Gone ||
                            statusCode == HttpStatusCode.BadGateway ||
                            statusCode == HttpStatusCode.ServiceUnavailable ||
                            statusCode == HttpStatusCode.GatewayTimeout ||
                            (int)statusCode == 429)
                        {
                            isTransient = true;
                        }
                    }
                }
            }

            return isTransient;
        }
    }
}
