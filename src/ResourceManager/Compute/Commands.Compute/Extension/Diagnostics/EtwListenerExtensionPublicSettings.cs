// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    /// <summary>
    /// Public setting contract of EtwListenerExtension
    /// </summary>
    [DataContract]
    public class EtwListenerExtensionPublicSettings
    {
        /// <summary>
        /// Server certificate thumbprint
        /// </summary>
        [DataMember]
        public string ServerCertificateThumbprint { get; set; }

        /// <summary>
        /// Client certificate thumbprint
        /// </summary>
        [DataMember]
        public string ClientCertificateThumbprint { get; set; }

        /// <summary>
        /// The url of server certificate in key vault
        /// Don't need to export server certificate url.
        /// </summary>
        [IgnoreDataMember]
        public string ServerCertificateUrl { get; set; }

        /// <summary>
        /// The url of client certificate in key vault
        /// </summary>
        [DataMember]
        public string ClientCertificateUrl { get; set; }
    }
}
