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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.ServiceFabric;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Remove,  CmdletNoun.AzureRmServiceFabricNodeType), OutputType(typeof(PSCluster))]
    public class RemoveAzureRmServiceFabricNodeType : ServiceFabricVmssCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            if (!CheckNodeTypeExistence())
            {
                throw new PSInvalidOperationException();
            }

            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName);

            if (cluster.NodeTypes == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.NoneNodeTypeFound);
            }

            var existingNodeType = cluster.NodeTypes.SingleOrDefault(n =>
            string.Equals(
                this.NodeTypeName,
                n.Name,
                StringComparison.InvariantCultureIgnoreCase));

            if (existingNodeType == null)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CanNotFindTheNodeType,
                        this.NodeTypeName));
            }

            if (existingNodeType.IsPrimary)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CanNotDeletePrimayNodeType,
                        this.NodeTypeName));
            }

            DurabilityLevel durabilityLevel;
            bool missMatch;
            GetDurabilityLevel(out durabilityLevel, out missMatch, this.NodeTypeName);
            
            if (durabilityLevel == DurabilityLevel.Bronze)
            {
                throw new PSInvalidOperationException(
                    ServiceFabricProperties.Resources.CanNotUpdateBronzeNodeType);
            }
            
            ComputeClient.VirtualMachineScaleSets.Delete(this.ResourceGroupName, this.NodeTypeName);

            cluster = RemoveNodeTypeFromSfrp();
            WriteObject((PSCluster)cluster,true);
        }
    }
}
