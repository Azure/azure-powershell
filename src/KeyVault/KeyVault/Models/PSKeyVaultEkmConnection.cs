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

using Azure.Security.KeyVault.Administration;

using System;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    /// <summary>
    /// Represents the External Key Manager (EKM) connection configured on a Managed HSM.
    /// </summary>
    public class PSKeyVaultEkmConnection
    {
        /// <summary>
        /// Name of the Managed HSM the connection belongs to.
        /// </summary>
        public string HsmName { get; set; }

        /// <summary>
        /// EKM proxy host (FQDN or FQDN:port).
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Optional path prefix appended to EKM proxy requests.
        /// </summary>
        public string PathPrefix { get; set; }

        /// <summary>
        /// Optional expected Common Name (CN) for the EKM proxy server certificate.
        /// </summary>
        public string ServerSubjectCommonName { get; set; }

        /// <summary>
        /// Server CA certificates (base64-encoded DER) configured for the connection.
        /// </summary>
        public string[] ServerCaCertificates { get; set; }

        public PSKeyVaultEkmConnection() { }

        public PSKeyVaultEkmConnection(KeyVaultEkmConnection connection, string hsmName = null)
        {
            if (connection != null)
            {
                Host = connection.HostName;
                PathPrefix = connection.PathPrefix;
                ServerSubjectCommonName = connection.ServerSubjectCommonName;
                ServerCaCertificates = connection.ServerCaCertificates?
                    .Select(cert => Convert.ToBase64String(cert.ToArray()))
                    .ToArray();
            }
            HsmName = hsmName;
        }

        public override string ToString() => $"{Host}{PathPrefix}";
    }
}
