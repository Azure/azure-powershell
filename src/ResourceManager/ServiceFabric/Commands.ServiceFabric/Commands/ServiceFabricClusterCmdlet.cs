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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Newtonsoft.Json.Linq;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public abstract class ServiceFabricClusterCmdlet : ServiceFabricCmdletBase
    {
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        public virtual string Name { get; set; }

        #region SFRP

        protected PSCluster SendPatchRequest(ClusterUpdateParameters request)
        {
            Cluster cluster;
            try
            {
                cluster = SFRPClient.Clusters.Update(ResourceGroupName, Name, request);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    while (e.InnerException != null)
                    {
                        e = e.InnerException;
                    }

                    throw;
                }

                throw;
            }

            return new PSCluster(cluster);
        }

        protected Task<PSCluster> PatchAsync(ClusterUpdateParameters request)
        {
            return Task.Run(() => SendPatchRequest(request));
        }

        protected Cluster GetCurrentCluster()
        {
            try
            {
                return SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    while (e.InnerException != null)
                    {
                        e = e.InnerException;
                    }

                    throw;
                }

                throw;
            }
        }

        protected void GetDurabilityLevel(string nodeTypeName, out DurabilityLevel durabilityLevel, out bool isMismatched)
        {
            var cluster = GetCurrentCluster();
            var nodeType = cluster.NodeTypes.SingleOrDefault(n => n.Name.Equals(nodeTypeName, StringComparison.OrdinalIgnoreCase));
            if (nodeType == null)
            {
                throw new PSInvalidOperationException(string.Format(ServiceFabricProperties.Resources.CannotFindTheNodeType, nodeTypeName));
            }

            var durabilityLevelFromNodeType = (DurabilityLevel)Enum.Parse(typeof(DurabilityLevel), nodeType.DurabilityLevel);

            var vmss = GetVmss(nodeTypeName);
            var ext = FindFabricVmExt(vmss.VirtualMachineProfile.ExtensionProfile.Extensions);

            var durabilityLevelStr = (string)((JObject)ext.Settings)["durabilityLevel"];
            if (string.IsNullOrWhiteSpace(durabilityLevelStr))
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.CannotFindDurabilityLevelSetting);
            }

            var durabilityLevelFromVmss = (DurabilityLevel)Enum.Parse(typeof(DurabilityLevel), durabilityLevelStr);

            if(durabilityLevelFromVmss != durabilityLevelFromNodeType)
            {
                WriteWarning(ServiceFabricProperties.Resources.DurabilityLevelMismatches);
                durabilityLevel = durabilityLevelFromNodeType;
                isMismatched = true;
                return;
            }

            durabilityLevel = durabilityLevelFromNodeType;
            isMismatched = false;
        }

        internal ClusterType GetClusterType(Cluster clusterResource)
        {
            if (string.IsNullOrWhiteSpace(clusterResource.Certificate.Thumbprint) &&
                string.IsNullOrWhiteSpace(clusterResource.Certificate.ThumbprintSecondary))
            {
                return ClusterType.Unsecure;
            }
            else
            {
                return ClusterType.Secure;
            } 
        }

        #endregion

        protected IDictionary<string, string> GetServiceFabricTags()
        {
            return new Dictionary<string, string>()
            {
                { "clusterName",this.Name },
                { "resourceType" ,Constants.ServieFabricTag }
            };
        }
    }
}