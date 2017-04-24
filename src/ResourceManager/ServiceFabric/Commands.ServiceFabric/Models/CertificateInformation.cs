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
using Microsoft.Azure.Management.KeyVault.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    internal class CertificateInformation
    {
        internal Vault KeyVault { get; set; }

        internal X509Certificate2 Certificate { get; set; }

        internal string CertificateUrl { get; set; }

        internal string CertificateName { get; set; }

        internal string SecretUrl { get; set; }

        internal string SecretName { get; set; }

        internal string Version { get; set; }

        internal string Thumbprint { get; set; }
    }
}