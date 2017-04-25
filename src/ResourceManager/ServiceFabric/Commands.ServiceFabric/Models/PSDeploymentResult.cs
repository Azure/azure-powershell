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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSDeploymentResult
    {
        public string VmUserName { get; set; }

        public List<PSKeyVault> CertificateInformation { get; set; }

        public PSDeploymentExtended DeploymentDetail { get; set; }

        public PSCluster ClusterDetail { get; set; } 

        public PSDeploymentResult()
        {
        }

        public PSDeploymentResult(
            PSDeploymentExtended deployment, 
            PSCluster cluster,
            string vmUserName,
            List<PSKeyVault> certificateInformations
        )
        {
            this.DeploymentDetail = deployment;
            this.ClusterDetail = cluster;
            this.VmUserName = vmUserName;
            this.CertificateInformation = certificateInformations;
        }
    }
}
