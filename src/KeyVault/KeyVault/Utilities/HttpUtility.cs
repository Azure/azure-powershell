using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Utilities
{
    using System.Net;

    /// <summary>
    /// The http utility.
    /// </summary>
    public static class HttpUtility
    {
        /// <summary>
        /// Returns true if the status code corresponds to a successful request.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        public static bool IsSuccessfulRequest(this HttpStatusCode statusCode)
        {
            return HttpUtility.IsSuccessfulRequest((int)statusCode);
        }

        /// <summary>
        /// Returns true if the status code corresponds to a server failure request.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        public static bool IsServerFailureRequest(this HttpStatusCode statusCode)
        {
            return HttpUtility.IsServerFailureRequest((int)statusCode);
        }

        /// <summary>
        /// Returns true if the status code corresponds to client failure.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        public static bool IsClientFailureRequest(this HttpStatusCode statusCode)
        {
            return HttpUtility.IsClientFailureRequest((int)statusCode);
        }

        /// <summary>
        /// Returns true if the status code corresponds to a successful request.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        private static bool IsSuccessfulRequest(int statusCode)
        {
            return (statusCode >= 200 && statusCode <= 299) || statusCode == 304;
        }

        /// <summary>
        /// Returns true if the status code corresponds to client failure.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        private static bool IsClientFailureRequest(int statusCode)
        {
            return statusCode == 505 || statusCode == 501 || (statusCode >= 400 && statusCode < 500 && statusCode != 408);
        }

        /// <summary>
        /// Returns true if the status code corresponds to a server failure request.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        private static bool IsServerFailureRequest(int statusCode)
        {
            return (statusCode >= 500 && statusCode <= 599 && statusCode != 505 && statusCode != 501) || statusCode == 408;
        }
    }
}
