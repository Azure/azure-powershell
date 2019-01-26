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
using System.Text;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSDeploymentResult
    {
        public string VmUserName { get; set; }

        public List<PSKeyVault> Certificates { get; set; }

        public PSDeploymentExtended Deployment { get; set; }

        public PSCluster Cluster { get; set; }

        public string DeploymentString { get { return Deployment == null ? null : Deployment.ToString(); } }
        public string ClusterString { get { return Cluster == null ? null : Cluster.ToString(); } }
        public string CertificatesString { get { return Certificates == null ? null : FormatCertificatesString(Certificates); } }

        public PSDeploymentResult()
        {
        }

        public PSDeploymentResult(
            PSDeploymentExtended deployment,
            PSCluster cluster,
            string vmUserName,
            List<PSKeyVault> certificates
        )
        {
            this.Deployment = deployment;
            this.Cluster = cluster;
            this.VmUserName = vmUserName;
            this.Certificates = certificates;
        }

        private string FormatCertificatesString(List<PSKeyVault> certificates)
        {
            if (certificates == null || certificates.Count == 0)
            {
                return null;
            }

            int i = 0;
            var sb = new StringBuilder();
            foreach (var certificate in certificates)
            {
                if (i == 0)
                {
                    sb.AppendLine("Primary key vault and certificate detail:");
                }
                else if(i == 1)
                {
                    sb.AppendLine("Secondary key vault and certificate detail:");
                }
                else
                {
                    sb.AppendLine(string.Format("The {0} key vault and certificate detail:", i));
                }

                sb.Append(string.Format("{0}", certificate));

                i++;
            }

            return sb.ToString();
        }
    }
}
