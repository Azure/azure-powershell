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
    /// Represents the EKM proxy client certificate information returned by a Managed HSM.
    /// </summary>
    public class PSKeyVaultEkmConnectionCertificate
    {
        /// <summary>
        /// Name of the Managed HSM the certificate belongs to.
        /// </summary>
        public string HsmName { get; set; }

        /// <summary>
        /// Subject Common Name (CN) of the EKM proxy client certificate.
        /// </summary>
        public string SubjectCommonName { get; set; }

        /// <summary>
        /// CA certificates (base64-encoded DER) for the EKM proxy client certificate.
        /// </summary>
        public string[] CaCertificates { get; set; }

        public PSKeyVaultEkmConnectionCertificate() { }

        public PSKeyVaultEkmConnectionCertificate(EkmProxyClientCertificateInfo info, string hsmName = null)
        {
            if (info != null)
            {
                SubjectCommonName = info.SubjectCommonName;
                CaCertificates = info.CaCertificates?
                    .Select(cert => Convert.ToBase64String(cert.ToArray()))
                    .ToArray();
            }
            HsmName = hsmName;
        }
    }
}
