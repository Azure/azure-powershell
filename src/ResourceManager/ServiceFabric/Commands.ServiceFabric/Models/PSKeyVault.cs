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

using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSKeyVault
    {
        public string KeyVaultId { get; set; }

        public string KeyVaultName { get; set; }

        public string KeyVaultCertificateId { get; set; }

        public string KeyVaultCertificateName { get; set; }

        public string SecretIdentifier { get; set; }

        public X509Certificate2 Certificate { get; set; }

        public string CertificateThumbprint { get; set; }

        public string CertificateSavedLocalPath { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            const string spaces = "    ";
            sb.AppendLine(string.Format("{0} {1} : {2}", "", "KeyVaultId", this.KeyVaultId));
            sb.AppendLine(string.Format("{0} {1} : {2}", "", "KeyVaultName", this.KeyVaultName));
            sb.AppendLine(string.Format("{0} {1} : {2}", "", "KeyVaultCertificateId", this.KeyVaultCertificateId));
            sb.AppendLine(string.Format("{0} {1} : {2}", "", "KeyVaultCertificateName", this.KeyVaultCertificateName));
            sb.AppendLine(string.Format("{0} {1} : {2}", "", "SecretIdentifier", this.SecretIdentifier));

            sb.AppendLine(string.Format("{0} {1} :", "", "Certificate:"));
            if (Certificate != null)
            {
                sb.AppendLine(string.Format("{0} {1} : {2}", spaces, "SubjectName", Certificate.SubjectName));
                sb.AppendLine(string.Format("{0} {1} : {2}", spaces, "IssuerName", Certificate.IssuerName));
                sb.AppendLine(string.Format("{0} {1} : {2}", spaces, "NotBefore", Certificate.NotBefore));
                sb.AppendLine(string.Format("{0} {1} : {2}", spaces, "NotAfter", Certificate.NotAfter));
            }

            sb.AppendLine(string.Format("{0} {1} : {2}", "", "CertificateThumbprint", this.CertificateThumbprint));
            sb.AppendLine(string.Format("{0} {1} : {2}", "", "CertificateSavedLocalPath", this.CertificateSavedLocalPath));

            return sb.ToString();
        }
    }
}
