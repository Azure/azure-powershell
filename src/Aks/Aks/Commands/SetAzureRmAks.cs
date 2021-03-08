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
using System.Linq;
using System.Management.Automation;

using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks
{
    [CmdletDeprecation(ReplacementCmdletName = "Set-AzAksCluster")]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksCluster", DefaultParameterSetName = DefaultParamSet, SupportsShouldProcess = true)]
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Aks")]
    [OutputType(typeof(PSKubernetesCluster))]
    public class SetAzureRmAks : CreateOrUpdateKubeBase
    {
        private const string IdParameterSet = "IdParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "A PSKubernetesCluster object, normally passed through the pipeline.")]
        [ValidateNotNullOrEmpty]
        public PSKubernetesCluster InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "NodePoolMode represents mode of an node pool.")]
        [PSArgumentCompleter("System", "User")]
        public string NodePoolMode { get; set; }

        /// <summary>
        /// Cluster name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = IdParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of a managed Kubernetes cluster")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ManagedCluster cluster = null;
            switch (ParameterSetName)
            {
                case IdParameterSet:
                {
                    var resource = new ResourceIdentifier(Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    Name = resource.ResourceName;
                    break;
                }
                case InputObjectParameterSet:
                {
                    WriteVerbose(Resources.UsingClusterFromPipeline);
                    cluster = PSMapper.Instance.Map<ManagedCluster>(InputObject);
                    var resource = new ResourceIdentifier(cluster.Id);
                    ResourceGroupName = resource.ResourceGroupName;
                    Name = resource.ResourceName;
                    break;
                }
            }

            var msg = $"{Name} in {ResourceGroupName}";

            if (ShouldProcess(msg, Resources.UpdateOrCreateAManagedKubernetesCluster))
            {
                RunCmdLet(() =>
                {
                    if (Exists())
                    {
                        if (cluster == null)
                        {
                            cluster = Client.ManagedClusters.Get(ResourceGroupName, Name);
                        }

                        if (this.IsParameterBound(c => c.Location))
                        {
                            throw new AzPSArgumentException(
                                Resources.LocationCannotBeUpdateForExistingCluster,
                                nameof(Location),
                                desensitizedMessage: Resources.LocationCannotBeUpdateForExistingCluster);
                        }

                        if (this.IsParameterBound(c => c.DnsNamePrefix))
                        {
                            WriteVerbose(Resources.UpdatingDnsNamePrefix);
                            cluster.DnsPrefix = DnsNamePrefix;
                        }

                        if (this.IsParameterBound(c => c.SshKeyValue))
                        {
                            WriteVerbose(Resources.UpdatingSshKeyValue);
                            cluster.LinuxProfile.Ssh.PublicKeys = new List<ContainerServiceSshPublicKey>
                            {
                                new ContainerServiceSshPublicKey(GetSshKey(SshKeyValue))
                            };
                        }
                        if (this.IsParameterBound(c => c.ServicePrincipalIdAndSecret))
                        {
                            WriteVerbose(Resources.UpdatingServicePrincipal);
                            var acsServicePrincipal = EnsureServicePrincipal(ServicePrincipalIdAndSecret.UserName, ServicePrincipalIdAndSecret.Password?.ConvertToString());

                            var spProfile = new ManagedClusterServicePrincipalProfile(
                                acsServicePrincipal.SpId,
                                acsServicePrincipal.ClientSecret);
                            cluster.ServicePrincipalProfile = spProfile;
                        }

                        if (this.IsParameterBound(c => c.LinuxProfileAdminUserName))
                        {
                            WriteVerbose(Resources.UpdatingAdminUsername);
                            cluster.LinuxProfile.AdminUsername = LinuxProfileAdminUserName;
                        }

                        if (NeedUpdateNodeAgentPool())
                        {
                            ManagedClusterAgentPoolProfile defaultAgentPoolProfile;

                            string nodePoolName = "default";
                            if (this.IsParameterBound(c => c.NodeName))
                            {
                                nodePoolName = NodeName;
                            }

                            if (cluster.AgentPoolProfiles.Any(x => x.Name == nodePoolName))
                            {
                                defaultAgentPoolProfile = cluster.AgentPoolProfiles.First(x => x.Name == nodePoolName);
                            }
                            else
                            {
                                throw new AzPSArgumentException(
                                    Resources.SpecifiedAgentPoolDoesNotExist,
                                    nameof(Name),
                                    desensitizedMessage: Resources.SpecifiedAgentPoolDoesNotExist);
                            }

                            if (this.IsParameterBound(c => c.NodeMinCount))
                            {
                                defaultAgentPoolProfile.MinCount = NodeMinCount;
                            }
                            if (this.IsParameterBound(c => c.NodeMaxCount))
                            {
                                defaultAgentPoolProfile.MaxCount = NodeMaxCount;
                            }
                            if (this.IsParameterBound(c => c.EnableNodeAutoScaling))
                            {
                                defaultAgentPoolProfile.EnableAutoScaling = EnableNodeAutoScaling.ToBool();
                            }
                            if (this.IsParameterBound(c => c.NodeVmSize))
                            {
                                WriteVerbose(Resources.UpdatingNodeVmSize);
                                defaultAgentPoolProfile.VmSize = NodeVmSize;
                            }

                            if (this.IsParameterBound(c => c.NodeCount))
                            {
                                WriteVerbose(Resources.UpdatingNodeCount);
                                defaultAgentPoolProfile.Count = NodeCount;
                            }

                            if (this.IsParameterBound(c => c.NodeOsDiskSize))
                            {
                                WriteVerbose(Resources.UpdatingNodeOsDiskSize);
                                defaultAgentPoolProfile.OsDiskSizeGB = NodeOsDiskSize;
                            }

                            if (this.IsParameterBound(c => c.NodePoolMode))
                            {
                                WriteVerbose(Resources.UpdatingNodePoolMode);
                                defaultAgentPoolProfile.Mode = NodePoolMode;
                            }
                        }

                        if (this.IsParameterBound(c => c.KubernetesVersion))
                        {
                            WriteVerbose(Resources.UpdatingKubernetesVersion);
                            cluster.KubernetesVersion = KubernetesVersion;
                        }

                        if (this.IsParameterBound(c => c.Tag))
                        {
                            WriteVerbose(Resources.UpdatingTags);
                            cluster.Tags = TagsConversionHelper.CreateTagDictionary(Tag, true);
                        }

                        //To avoid server error: for agentPoolProfiles.availabilityZones, server will expect
                        //$null instead of empty collection, otherwise it will throw error.
                        foreach(var profile in cluster.AgentPoolProfiles)
                        {
                            if(profile.AvailabilityZones?.Count == 0)
                            {
                                profile.AvailabilityZones = null;
                            }
                        }

                        WriteVerbose(Resources.UpdatingYourManagedKubernetesCluster);
                    }
                    else
                    {
                        WriteVerbose(Resources.PreparingForDeploymentOfYourNewManagedKubernetesCluster);
                        cluster = BuildNewCluster();
                    }

                    var kubeCluster = Client.ManagedClusters.CreateOrUpdate(ResourceGroupName, Name, cluster);
                    WriteObject(PSMapper.Instance.Map<PSKubernetesCluster>(kubeCluster));
                });
            }
        }

        private bool NeedUpdateNodeAgentPool()
        {
            return this.IsParameterBound(c => c.NodeCount) || this.IsParameterBound(c => c.NodeOsDiskSize) ||
                this.IsParameterBound(c => c.NodeVmSize) || this.IsParameterBound(c => c.EnableNodeAutoScaling) ||
                this.IsParameterBound(c => c.NodeMinCount) || this.IsParameterBound(c => c.NodeMaxCount) || 
                this.IsParameterBound(c => c.NodePoolMode);
        }
    }
}
