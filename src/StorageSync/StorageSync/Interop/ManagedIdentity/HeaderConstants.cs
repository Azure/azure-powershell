using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity
{
    public partial class HeaderConstants
    {
        /// <summary>
        /// Authentication scheme for Basic challenge authentication framework
        /// </summary>
        public const string BasicAuthScheme = "Basic";

        /// <summary>
        /// Http Metadata request header
        /// </summary>
        public const string Metadata = "Metadata";

        /// <summary>
        /// The http header authorization. Value is a key/certificate/token.
        /// </summary>
        public const string HttpHeaderAuthorization = "Authorization";

        /// <summary>
        /// Authentication scheme for NTLM challenge authentication framework
        /// </summary>
        public const string WWWAuthenticate = "WWW-Authenticate";

        /// <summary>
        /// Bearer token authentication scheme
        /// </summary>
        public const string BearerTokenAuthScheme = "Bearer"; 
    }
}
