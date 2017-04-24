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

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSDeploymentResult
    {
        public string VmUserName { get; set; }

        public X509Certificate2 Certificate { get; set; }

        public string Thumbprint { get; set; }

        public string KeyVaultName { get; set; }

        public string KeyVaultCertificateName { get; set; }

        public string KeyVaultSecretName { get; set; }

        public string KeyVaultSecretVersion { get; set; }

        public PSDeploymentExtended DeploymentDetail { get; set; }

        public PSCluster ClusterDetail { get; set; } 

        public PSDeploymentResult()
        {
        }

        public PSDeploymentResult(
            PSDeploymentExtended deployment, 
            PSCluster cluster,
            string vmUserName,
            X509Certificate2 certificate,
            string thumbprint,
            string keyVaultName,
            string keyVaultCertificateName,
            string keyVaultSecretName,
            string keyVaultSecretVersion)
        {
            this.DeploymentDetail = deployment;
            this.ClusterDetail = cluster;
            this.VmUserName = vmUserName;
            this.KeyVaultName = keyVaultName;
            this.Certificate = certificate;
            this.KeyVaultCertificateName = keyVaultCertificateName;
            this.KeyVaultSecretName = keyVaultSecretName;
            this.KeyVaultSecretVersion = keyVaultSecretVersion;
            this.Thumbprint = thumbprint;
        }
    }
}
