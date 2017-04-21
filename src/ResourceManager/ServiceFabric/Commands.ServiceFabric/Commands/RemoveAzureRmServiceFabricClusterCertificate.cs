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

using System;
using System.Management.Automation;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureRmServiceFabricClusterCertificate), OutputType(typeof(PSCluster))]
    public class RemoveAzureRmServiceFabricClusterCertificate : ServiceFabricClusterCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the cluster thumbprint which to be removed")]
        [ValidateNotNullOrEmpty()]
        public string Thumbprint { get; set; }

        public override void ExecuteCmdlet()
        {
            var clusterResource = GetCurrentCluster();
            var clusterType = GetClusterType(clusterResource);

            if (clusterType == ClusterType.Unsecure)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.RemoveCertFromUnsecureCluster,
                        this.ClusterName));
            }

            if (clusterResource.Certificate.ThumbprintSecondary == null)
            {
                throw new InvalidOperationException(
                    ServiceFabricProperties.Resources.OnlyOneClusterCertificate);
            }

            var patchRequest = new ClusterUpdateParameters
            {
                Certificate = clusterResource.Certificate
            };

            if (string.Compare(
                this.Thumbprint,
                clusterResource.Certificate.ThumbprintSecondary,
                StringComparison.OrdinalIgnoreCase) == 0)
            {
                patchRequest.Certificate.ThumbprintSecondary = null;
            }
            else if (string.Compare(
                this.Thumbprint,
                clusterResource.Certificate.Thumbprint,
                StringComparison.OrdinalIgnoreCase) == 0)
            {
                patchRequest.Certificate.Thumbprint =
                   clusterResource.Certificate.ThumbprintSecondary;
                clusterResource.Certificate.ThumbprintSecondary = null;                
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CanNotFindThumbprintInTheCluster,
                        this.Thumbprint));
            }

            var cluster = SendPatchRequest(patchRequest, true);
            WriteObject(cluster,true);
        }
    }
}