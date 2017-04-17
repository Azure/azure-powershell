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
using System.Threading.Tasks;
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
        public virtual string ClusterName { get; set; }

        #region SFRP

        protected PSCluster SendPatchRequest(
             ClusterUpdateParameters request,
             bool longRunningOperation = true)
        {
            Cluster cluster;
            try
            {
                cluster = SFRPClient.Clusters.Update(ResourceGroupName, ClusterName, request);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    while (e.InnerException != null)
                    {
                        e = e.InnerException;
                    }

                    throw e;
                }

                throw;
            }

            return new Models.PSCluster(cluster);

            //if (longRunningOperation)
            //{
            //    while (true)
            //    {
            //        cluster = GetCurrentCluster();
            //        var clusterStateStr = cluster.ClusterState;
            //        ClusterProvisioningState clusterState;
            //        if (!Enum.TryParse(clusterStateStr, out clusterState))
            //        {
            //            throw new PSInvalidOperationException(clusterStateStr);
            //        }

            //        if (clusterState == ClusterProvisioningState.Ready ||
            //            clusterState == ClusterProvisioningState.Failed)
            //        {
            //            if (clusterState == ClusterProvisioningState.Failed)
            //            {
            //                throw new PSInvalidCastException("Failed to upgrade the cluster");
            //            }

            //            return new PsCluster(cluster);
            //        }
            //        else
            //        {
            //            //TODO
            //            System.Threading.Thread.Sleep(20 * 1000);
            //        }
            //    }
            //}

            //return new PsCluster(cluster);
        }

        protected Task<PSCluster> PatchAsync(
            ClusterUpdateParameters request,
            bool longRunningOperation)
        {
            return Task.Run<PSCluster>(() => SendPatchRequest(request, longRunningOperation));
        }

        protected Cluster GetCurrentCluster()
        {
            try
            {
                return SFRPClient.Clusters.Get(ResourceGroupName, ClusterName);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    while (e.InnerException != null)
                    {
                        e = e.InnerException;
                    }

                    throw e;
                }

                throw;
            }
        }

        protected void GetDurabilityLevel(
            out DurabilityLevel durabilityLevel,
            out bool missMatch,
            string nodeTypeName)
        {
            durabilityLevel = DurabilityLevel.Bronze;

            var cluster = GetCurrentCluster();
            var nodeType = cluster.NodeTypes.SingleOrDefault(n => string.Compare(n.Name, nodeTypeName, StringComparison.OrdinalIgnoreCase) == 0);

            var durabilityLevelFromNodeType = (DurabilityLevel)Enum.Parse(typeof(DurabilityLevel), nodeType.DurabilityLevel);

            var vmss = GetVmss(nodeTypeName);
            var ext = FindFabricVmExt(vmss.VirtualMachineProfile.ExtensionProfile.Extensions);

            var durabilityLevelStr = (string)((JObject)ext.Settings)["durabilityLevel"];
            var durabilityLevelFromVmss = (DurabilityLevel)Enum.Parse(typeof(DurabilityLevel), durabilityLevelStr);

            if(durabilityLevelFromVmss != durabilityLevelFromNodeType)
            {
                WriteWarning(ServiceFabricProperties.Resources.DurabilityLevelMismatches);
                missMatch = true;
            }

            durabilityLevel = durabilityLevelFromNodeType;
            missMatch = false;
        }

        internal ClusterType GetClusterType(
            Cluster clusterResource)
        {
            if (clusterResource.ManagementEndpoint != null)
            {
                var endPoint = clusterResource.ManagementEndpoint;
                if (endPoint.StartsWith("https://",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return ClusterType.Secure;
                }

                if (endPoint.StartsWith("http://",
                   StringComparison.OrdinalIgnoreCase))
                {
                    return ClusterType.Unsecure;
                }
            }

            return ClusterType.Unknown;
        }

        #endregion
    }
}