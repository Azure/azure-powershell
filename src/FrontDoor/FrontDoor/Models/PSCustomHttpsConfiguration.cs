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

namespace Microsoft.Azure.Commands.FrontDoor.Models
{
    public class PSFrontDoorCertificateSourceParameters
    {
        public PSCertificateType CertificateType { get; set; }
    }

    public class PSKeyVaultCertificateSourceParameters
    {
        public string Vault { get; set; }

        public string SecretName { get; set; }

        public string SecretVersion { get; set; }

        public PSCertificateType CertificateType { get; set; }
    }

    public class PSCustomHttpsConfiguration
    {
        public const string ProtocolType = "ServerNameIndication";

        public string Name { get; set; }

        public string MinimumTlsVersion { get; set; }

        public string CertificateSource { get; set; }

        public PSKeyVaultCertificateSourceParameters KeyVaultCertificateSourceParameters { get; set; }

        public PSFrontDoorCertificateSourceParameters FrontDoorCertificateSourceParameters { get; set; }
    }
}
