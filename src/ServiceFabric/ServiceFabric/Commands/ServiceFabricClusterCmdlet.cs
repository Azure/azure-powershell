﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ServiceFabric.Common;
    using Microsoft.Azure.Commands.ServiceFabric.Models;
    using Microsoft.Azure.Management.ServiceFabric;
    using Microsoft.Azure.Management.ServiceFabric.Models;
    using Newtonsoft.Json.Linq;
    using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
    using Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models;
    using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;

    public abstract class ServiceFabricClusterCmdlet : ServiceFabricCmdletBase
    {
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public virtual string Name { get; set; }

        #region SFRP

        protected PSCluster SendPatchRequest(ClusterUpdateParameters request)
        {
            WriteVerboseWithTimestamp("Begin to update the cluster");
            Cluster cluster = StartRequestAndWait<Cluster>(
                        () => this.SFRPClient.Clusters.BeginUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, request),
                        () => string.Format(ServiceFabricProperties.Resources.ClusterStateVerbose, GetCurrentClusterState()));

            return new PSCluster(cluster);
        }

        protected PSCluster SendDynamicPatchRequest(dynamic request)
        {
            WriteVerboseWithTimestamp("Begin to update the cluster with dynamic object");
            Cluster cluster = StartRequestAndWait<Cluster>(
                        () => ClusterOperations.BeginUpdateWithHttpMessagesAsync(this.SFRPClient, this.ResourceGroupName, this.Name, request),
                        () => string.Format(ServiceFabricProperties.Resources.ClusterStateVerbose, GetCurrentClusterState()));

            return new PSCluster(cluster);
        }

        protected Task<Cluster> PatchAsync(ClusterUpdateParameters request)
        {
            return this.SFRPClient.Clusters.UpdateAsync(this.ResourceGroupName, this.Name, request);
        }

        protected string GetCurrentClusterState()
        {
            var resource = SafeGetResource(() => this.GetCurrentCluster(), true);

            if (resource != null)
            {
                return resource.ClusterState;
            }

            return null;
        }

        protected Cluster GetCurrentCluster()
        {
            try
            {
                return this.SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name);
            }
            catch (Exception e)
            {
                throw GetInnerException(e);
            }
        }

        protected NodeTypeDescription GetNodeType(Cluster cluster, string nodeTypeName, bool ignoreErrors = false)
        {
            NodeTypeDescription nodeType =
                cluster.NodeTypes.SingleOrDefault(
                    n =>
                        string.Equals(
                            nodeTypeName,
                            n.Name,
                            StringComparison.OrdinalIgnoreCase));

            if (nodeType == null && !ignoreErrors)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotFindTheNodeType,
                        nodeTypeName));
            }

            return nodeType;
        }

        protected DurabilityLevel GetDurabilityLevel(VirtualMachineScaleSet vmss)
        {
            VirtualMachineScaleSetExtension sfExt;
            if (!TryGetFabricVmExt(vmss.VirtualMachineProfile.ExtensionProfile.Extensions, out sfExt))
            {
                throw new InvalidOperationException(string.Format(ServiceFabricProperties.Resources.SFExtensionNotFoundInVMSS, vmss.Name, vmss.Id));
            }

            var durabilityLevelStr = (string)((JObject)sfExt.Settings)["durabilityLevel"];
            if (string.IsNullOrWhiteSpace(durabilityLevelStr))
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.CannotFindDurabilityLevelSetting);
            }

            return GetDurabilityLevel(durabilityLevelStr);
        }

        protected DurabilityLevel GetDurabilityLevel(string durabilityLevel)
        {
            return (DurabilityLevel)Enum.Parse(typeof(DurabilityLevel), durabilityLevel);
        }

        protected ReliabilityLevel GetReliabilityLevel(Cluster cluster)
        {
            var level = cluster.ReliabilityLevel;
            ReliabilityLevel reliabilitylevel;
            if (Enum.TryParse(level, out reliabilitylevel))
            {
                return reliabilitylevel;
            }
            else
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotParseReliabilityLevel,
                        level));
            }
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

        protected VmImageKind GetVmImage(Cluster cluster)
        {
            var vmImage = cluster.VmImage;
            VmImageKind vmImageKind;
            if (Enum.TryParse(vmImage, out vmImageKind))
            {
                return vmImageKind;
            }
            else
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.CannotParseVmImage,
                        vmImage));
            }
        }

        #endregion

        protected IDictionary<string, string> GetServiceFabricTags()
        {
            return new Dictionary<string, string>()
            {
                { "clusterName", this.Name },
                { "resourceType", Constants.ServieFabricTag }
            };
        }

        protected void WriteClusterAndVmssVerboseWhenUpdate(List<Task> allTasks, bool printClusterStatus, string vmssName = null)
        {
            var token = new CancellationTokenSource();
            var exceptions = new List<Exception>();
            var task = Task.Factory.ContinueWhenAll(
                    allTasks.ToArray(),
                    tasks =>
                    {
                        token.Cancel();
                        exceptions.AddRange((from t in tasks where t.IsFaulted select t.Exception).Cast<Exception>());

                        if (exceptions.Count > 0)
                        {
                            throw new AggregateException(exceptions);
                        }
                    },
                    CancellationToken.None);

            while (!token.IsCancellationRequested)
            {
                if (!RunningTest)
                {
                    if (printClusterStatus)
                    {
                        var c = SafeGetResource(GetCurrentCluster, true);
                        if (c != null)
                        {
                            WriteVerboseWithTimestamp(
                                string.Format(ServiceFabricProperties.Resources.ClusterStateVerbose, c.ClusterState));
                        }
                    }

                    var vmsss = this.ComputeClient.VirtualMachineScaleSets.List(this.ResourceGroupName);

                    do
                    {
                        if (vmsss.Any())
                        {
                            foreach (var vmss in vmsss)
                            {
                                if (!string.IsNullOrEmpty(vmssName) &&
                                    !vmss.Name.Equals(vmssName, StringComparison.OrdinalIgnoreCase))
                                {
                                    continue;
                                }

                                WriteVerboseWithTimestamp(
                                    string.Format(ServiceFabricProperties.Resources.VmssVerbose, vmss.Name,
                                        vmss.ProvisioningState));
                            }
                        }
                    } while (!string.IsNullOrEmpty(vmsss.NextPageLink) &&
                             (vmsss = this.ComputeClient.VirtualMachineScaleSets.ListNext(vmsss.NextPageLink)) !=
                             null);
                }

                Thread.Sleep(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));
            }

            exceptions.ForEach(PrintSdkExceptionDetail);
            task.Wait();
        }

        protected Exception GetInnerException(Exception exception)
        {
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            return exception;
        }
    }
}