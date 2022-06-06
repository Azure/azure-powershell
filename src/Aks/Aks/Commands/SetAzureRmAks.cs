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

using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Authorization.Version2015_07_01.Models;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using ResourceIdentityType = Microsoft.Azure.Management.ContainerService.Models.ResourceIdentityType;

namespace Microsoft.Azure.Commands.Aks
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksCluster", DefaultParameterSetName = DefaultParamSet, SupportsShouldProcess = true)]
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

        [Parameter(Mandatory = false, HelpMessage = "Disable the 'acrpull' role assignment to the ACR specified by name or resource ID, e.g. myacr")]
        public string AcrNameToDetach { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "Will only upgrade the node image of agent pools.")]
        public SwitchParameter NodeImageOnly { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Will only upgrade control plane to target version.")]
        public SwitchParameter ControlPlaneOnly { get; set; }

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

        private ManagedCluster BuildNewCluster()
        {
            BeforeBuildNewCluster();

            var defaultAgentPoolProfile = new ManagedClusterAgentPoolProfile(
                name: NodeName ?? "default",
                count: NodeCount,
                vmSize: NodeVmSize,
                osDiskSizeGB: NodeOsDiskSize);

            if (this.IsParameterBound(c => c.NodeMinCount))
            {
                defaultAgentPoolProfile.MinCount = NodeMinCount;
            }
            if (this.IsParameterBound(c => c.NodeMaxCount))
            {
                defaultAgentPoolProfile.MaxCount = NodeMaxCount;
            }
            if (EnableNodeAutoScaling.IsPresent)
            {
                defaultAgentPoolProfile.EnableAutoScaling = EnableNodeAutoScaling.ToBool();
            }

            var pubKey =
                new List<ContainerServiceSshPublicKey> { new ContainerServiceSshPublicKey(SshKeyValue) };

            var linuxProfile =
                new ContainerServiceLinuxProfile(LinuxProfileAdminUserName,
                    new ContainerServiceSshConfiguration(pubKey));

            var acsServicePrincipal = EnsureServicePrincipal(ServicePrincipalIdAndSecret?.UserName, ServicePrincipalIdAndSecret?.Password?.ConvertToString());

            var spProfile = new ManagedClusterServicePrincipalProfile(
                acsServicePrincipal.SpId,
                acsServicePrincipal.ClientSecret);

            WriteVerbose(string.Format(Resources.DeployingYourManagedKubeCluster, AcsSpFilePath));
            var managedCluster = new ManagedCluster(
                Location,
                name: Name,
                tags: TagsConversionHelper.CreateTagDictionary(Tag, true),
                dnsPrefix: DnsNamePrefix,
                kubernetesVersion: KubernetesVersion,
                agentPoolProfiles: new List<ManagedClusterAgentPoolProfile> { defaultAgentPoolProfile },
                linuxProfile: linuxProfile,
                servicePrincipalProfile: spProfile);
            return managedCluster;
        }

        private ContainerServiceNetworkProfile SetNetworkProfile(ContainerServiceNetworkProfile networkProfile)
        {
            networkProfile.LoadBalancerProfile = CreateOrUpdateLoadBalancerProfile(networkProfile.LoadBalancerProfile);

            return networkProfile;
        }

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
                    AcsServicePrincipal acsServicePrincipal;
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
                            acsServicePrincipal = EnsureServicePrincipal(ServicePrincipalIdAndSecret.UserName, ServicePrincipalIdAndSecret.Password?.ConvertToString());

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

                        if (this.IsParameterBound(c => c.KubernetesVersion) && this.IsParameterBound(c => c.NodeImageOnly))
                        {
                            throw new AzPSArgumentException(Resources.UpdateKubernetesVersionAndNodeImageOnlyConflict, "KubernetesVersion");
                        }

                        bool allAgentPoolVirtualMachineScaleSets = cluster.AgentPoolProfiles.All(c => c.Type.ToLower().Equals("virtualmachinescalesets"));
                        if (this.IsParameterBound(c => c.NodeImageOnly))
                        {
                            if (!ShouldProcess(Resources.ConfirmOnlyUpgradeNodeVersion, ""))
                            {
                                return;
                            }

                            foreach (var agentPoolProfile in cluster.AgentPoolProfiles)
                            {
                                if (!allAgentPoolVirtualMachineScaleSets)
                                {
                                    throw new AzPSApplicationException(Resources.NotUsingVirtualMachineScaleSets);
                                }
                                var agentPoolClient = Client.AgentPools.Get(ResourceGroupName, Name, agentPoolProfile.Name);
                                Client.AgentPools.UpgradeNodeImageVersion(ResourceGroupName, Name, agentPoolProfile.Name);
                            }
                            cluster = Client.ManagedClusters.Get(ResourceGroupName, Name);
                            WriteObject(PSMapper.Instance.Map<PSKubernetesCluster>(cluster));
                            return;
                        }
                        if (this.IsParameterBound(c => c.KubernetesVersion))
                        {
                            WriteVerbose(Resources.UpdatingKubernetesVersion);
                            cluster.KubernetesVersion = KubernetesVersion;
                        }
                        bool upgradeAllNode = false;
                        if (cluster.MaxAgentPools < 8 || !allAgentPoolVirtualMachineScaleSets)
                        {
                            if (this.IsParameterBound(c => c.ControlPlaneOnly))
                            {
                                if (!ShouldProcess(string.Format(Resources.ConfirmControlPlaneOnlyInVMASCluster, KubernetesVersion), ""))
                                {
                                    return;
                                }
                            }
                            upgradeAllNode = true;
                        }
                        else
                        {
                            if (!this.IsParameterBound(c => c.ControlPlaneOnly))
                            {
                                if (!ShouldProcess(string.Format(Resources.ConfirmNotControlPlaneOnly, KubernetesVersion), ""))
                                {
                                    return;
                                }
                                upgradeAllNode = true;
                            }
                            else
                            {
                                if (!ShouldProcess(string.Format(Resources.ConfirmControlPlaneOnly, KubernetesVersion), ""))
                                {
                                    return;
                                }
                            }
                        }
                        if (upgradeAllNode)
                        {
                            cluster.AgentPoolProfiles.ForEach(c => c.OrchestratorVersion = KubernetesVersion);
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

                    if (this.IsParameterBound(c => c.AcrNameToAttach) ||
                        this.IsParameterBound(c => c.AcrNameToDetach))
                    {
                        acsServicePrincipal = EnsureServicePrincipal(ServicePrincipalIdAndSecret?.UserName, ServicePrincipalIdAndSecret?.Password?.ConvertToString());
                        if (this.IsParameterBound(c => c.AcrNameToAttach))
                        {
                            AddAcrRoleAssignment(AcrNameToAttach, nameof(AcrNameToAttach), acsServicePrincipal);
                        }
                        if (this.IsParameterBound(c => c.AcrNameToDetach))
                        {
                            RemoveAcrRoleAssignment(AcrNameToDetach, nameof(AcrNameToDetach), acsServicePrincipal);
                        }
                    }
                    cluster.NetworkProfile = SetNetworkProfile(cluster.NetworkProfile);
                    cluster.ApiServerAccessProfile = CreateOrUpdateApiServerAccessProfile(cluster.ApiServerAccessProfile);
                    if (this.IsParameterBound(c => c.FqdnSubdomain))
                    {
                        cluster.FqdnSubdomain = FqdnSubdomain;
                    }
                    SetIdentity(cluster);

                    var kubeCluster = Client.ManagedClusters.CreateOrUpdate(ResourceGroupName, Name, cluster);

                    WriteObject(PSMapper.Instance.Map<PSKubernetesCluster>(kubeCluster));
                });
            }
        }

        private void RemoveAcrRoleAssignment(string acrName, string acrParameterName, AcsServicePrincipal acsServicePrincipal)
        {
            string acrResourceId = null;
            try
            {
                //Find Acr resourceId first
                var acrQuery = new ODataQuery<GenericResourceFilter>($"$filter=resourceType eq 'Microsoft.ContainerRegistry/registries' and name eq '{acrName}'");
                var acrObjects = RmClient.Resources.List(acrQuery);
                acrResourceId = acrObjects.First().Id;
            }
            catch (Exception)
            {
                throw new AzPSArgumentException(
                    string.Format(Resources.CouldNotFindSpecifiedAcr, acrName),
                    acrParameterName,
                    string.Format(Resources.CouldNotFindSpecifiedAcr, "*"));
            }

            var roleDefinitionId = GetRoleId("acrpull", acrResourceId);
            RoleAssignment roleAssignment = GetRoleAssignmentWithRoleDefinitionId(roleDefinitionId);
            if (roleAssignment == null)
            {
                throw new AzPSInvalidOperationException(
                    Resources.CouldNotDeleteAcrRoleAssignment,
                    desensitizedMessage: Resources.CouldNotDeleteAcrRoleAssignment);
            }

            var deleteResult = RetryAction(() => AuthClient.RoleAssignments.DeleteById(roleAssignment.Id));
            if (!deleteResult)
            {
                throw new AzPSInvalidOperationException(
                    Resources.CouldNotDeleteAcrRoleAssignment,
                    desensitizedMessage: Resources.CouldNotDeleteAcrRoleAssignment);
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
