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
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
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
        [Alias("ClusterName")]
        public virtual string Name { get; set; }

        #region SFRP

        #region Temporary code until next SDK version is released
        protected PSCluster SendPutRequest(Cluster clusterResource, bool runOnSameThread = true)
        {
            if (runOnSameThread)
            {
                WriteVerboseWithTimestamp("Begin to update the cluster");
            }

            Cluster cluster = null;
            var tokenSource = new CancellationTokenSource();
            try
            {
                var putRequest = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        cluster = this.SFRPClient.Clusters.Create(this.ResourceGroupName, this.Name, clusterResource);
                    }
                    finally
                    {
                        tokenSource.Cancel();
                    }
                });

                while (!tokenSource.IsCancellationRequested)
                {
                    if (runOnSameThread)
                    {
                        if (!RunningTest)
                        {
                            var c = SafeGetResource(this.GetCurrentCluster, true);
                            if (c != null)
                            {
                                WriteVerboseWithTimestamp(
                                    string.Format(
                                        ServiceFabricProperties.Resources.ClusterStateVerbose,
                                        c.ClusterState));
                            }
                        }
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));
                }

                if (putRequest.IsFaulted)
                {
                    throw putRequest.Exception;
                }

            }
            catch (Exception e)
            {
                PrintSdkExceptionDetail(e);

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
        #endregion

        protected PSCluster SendPatchRequest(ClusterUpdateParameters request, bool runOnSameThread = true)
        {
            if (runOnSameThread)
            {
                WriteVerboseWithTimestamp("Begin to update the cluster");
            }

            Cluster cluster = null;
            var tokenSource = new CancellationTokenSource();
            try
            {
                var patchRequest = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        cluster = this.SFRPClient.Clusters.Update(this.ResourceGroupName, this.Name, request);
                    }
                    finally
                    {
                        tokenSource.Cancel();
                    }
                });

                while (!tokenSource.IsCancellationRequested)
                {
                    if (runOnSameThread)
                    {
                        if (!RunningTest)
                        {
                            var c = SafeGetResource(() => this.GetCurrentCluster(), true);
                            if (c != null)
                            {
                                WriteVerboseWithTimestamp(
                                    string.Format(
                                        ServiceFabricProperties.Resources.ClusterStateVerbose,
                                        c.ClusterState));
                            }
                        }
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));
                }

                if (patchRequest.IsFaulted)
                {
                    throw patchRequest.Exception;
                }

            }
            catch (Exception e)
            {
                PrintSdkExceptionDetail(e);

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

        protected Task<Cluster> PatchAsync(ClusterUpdateParameters request)
        {
            return this.SFRPClient.Clusters.UpdateAsync(this.ResourceGroupName, this.Name, request);
        }

        protected Cluster GetCurrentCluster()
        {
            try
            {
                return this.SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name);
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
            var ext = FindFabricVmExt(vmss.VirtualMachineProfile.ExtensionProfile.Extensions);

            var durabilityLevelStr = (string)((JObject)ext.Settings)["durabilityLevel"];
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

        #endregion

        protected IDictionary<string, string> GetServiceFabricTags()
        {
            return new Dictionary<string, string>()
            {
                { "clusterName",this.Name },
                { "resourceType" ,Constants.ServieFabricTag }
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
    }
}