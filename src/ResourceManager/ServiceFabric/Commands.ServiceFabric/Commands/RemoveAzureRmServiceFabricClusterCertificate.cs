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
    [Cmdlet(VerbsCommon.Remove, CmdletNoun.AzureRmServiceFabricClusterCertificate, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class RemoveAzureRmServiceFabricClusterCertificate : ServiceFabricClusterCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true,
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
                        this.Name));
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

            if (this.Thumbprint.Equals(
                clusterResource.Certificate.ThumbprintSecondary,
                StringComparison.OrdinalIgnoreCase))
            {
                patchRequest.Certificate.ThumbprintSecondary = null;
            }
            else if (this.Thumbprint.Equals( 
                clusterResource.Certificate.Thumbprint,
                StringComparison.OrdinalIgnoreCase))
            {
                patchRequest.Certificate.Thumbprint =
                   clusterResource.Certificate.ThumbprintSecondary;
                clusterResource.Certificate.ThumbprintSecondary = null;                
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotFindThumbprintInTheCluster,
                        this.Thumbprint));
            }

            if (ShouldProcess(target: this.Name, action: string.Format("Remove a cluster certificate from {0} ", this.Name)))
            {
                var cluster = SendPatchRequest(patchRequest);
                WriteObject(cluster, true);
            }
        }
    }
}