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
using System.IO;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Aks.Utils;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks
{
    public abstract class NewKubeBase : CreateOrUpdateKubeBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Represents types of an node pool. Possible values include: 'VirtualMachineScaleSets', 'AvailabilitySet'")]
        [PSArgumentCompleter("AvailabilitySet", "VirtualMachineScaleSets")]
        public string NodeVmSetType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "VNet SubnetID specifies the VNet's subnet identifier.")]
        public string NodeVnetSubnetID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Maximum number of pods that can run on node.")]
        public int NodeMaxPodCount { get; set; }

        ////Hide it as it expects GA by around May
        //[Parameter(Mandatory = false, HelpMessage = "Whether to enable public IP for nodes")]
        //public SwitchParameter EnableNodePublicIp { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.")]
        [PSArgumentCompleter("Low", "Regular")]
        public string NodeSetPriority { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "NodePoolMode represents mode of an node pool.")]
        [PSArgumentCompleter("System", "User")]
        public string NodePoolMode { get; set; } = "System";

        [Parameter(Mandatory = false, HelpMessage = "ScaleSetEvictionPolicy to be used to specify eviction policy for low priority virtual machine scale set. Default to Delete.")]
        [PSArgumentCompleter("Delete", "Deallocate")]
        public string NodeScaleSetEvictionPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Add-on names to be enabled when cluster is created.")]
        [ValidateNotNullOrEmpty()]
        [PSArgumentCompleter("HttpApplicationRouting", "Monitoring", "VirtualNode", "AzurePolicy", "KubeDashboard")]
        public string[] AddOnNameToBeEnabled { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Id of the workspace of Monitoring addon.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceResourceId { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subnet name of VirtualNode addon.")]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        ///// <summary>The client AAD application ID.</summary>
        //[Parameter(Mandatory = false, HelpMessage = "The client AAD application ID.")]
        //public string AadProfileClientAppId { get; set; }

        ///// <summary>The server AAD application ID.</summary>
        //[Parameter(Mandatory = false, HelpMessage = "The server AAD application ID.")]
        //public string AadProfileServerAppId { get; set; }

        ///// <summary>The server AAD application secret.</summary>
        //[Parameter(Mandatory = false, HelpMessage = "The server AAD application secret.")]
        //public string AadProfileServerAppSecret { get; set; }

        //// <summary> The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription. </summary>
        //[Parameter(Mandatory = false,
        //    HelpMessage =
        //        "The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.")]
        //public string AadProfileTenantId { get; set; }

        ///// <summary>Profile of managed cluster add-on.</summary>
        //[Parameter(Mandatory = false, HelpMessage = "Profile of managed cluster add-on.")]
        //public ManagedClusterAddonProfile AddOnProfile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Grant the 'acrpull' role of the specified ACR to AKS Service Principal, e.g. myacr")]
        public string AcrNameToAttach { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable Kubernetes Role-Based Access")]
        public SwitchParameter EnableRbac { get; set; }

        ////Hide it as there's no GA plan for it.
        //[Parameter(Mandatory = false, HelpMessage = "Whether to enable Kubernetes Pod security")]
        //public SwitchParameter EnablePodSecurityPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The administrator username to use for Windows VMs.")]
        public string WindowsProfileAdminUserName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The administrator password to use for Windows VMs. Password requirement:"
          + "At least one lower case, one upper case, one special character !@#$%^&*(), the minimum lenth is 12.")]
        [ValidateSecureString(RegularExpression = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%\\^&\\*\\(\\)])[a-zA-Z\\d!@#$%\\^&\\*\\(\\)]{12,123}$", ParameterName = nameof(WindowsProfileAdminUserPassword))]
        public SecureString WindowsProfileAdminUserPassword { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Network plugin used for building Kubernetes network.")]
        [PSArgumentCompleter("azure", "kubenet")]
        public string NetworkPlugin { get; set; } = "azure";

        [Parameter(Mandatory = false, HelpMessage = "The load balancer sku for the managed cluster.")]
        [PSArgumentCompleter("basic", "standard")]
        public string LoadBalancerSku { get; set; }

        protected override ManagedCluster BuildNewCluster()
        {
            BeforeBuildNewCluster();

            var pubKey =
                new List<ContainerServiceSshPublicKey> { new ContainerServiceSshPublicKey(SshKeyValue) };

            var linuxProfile =
                new ContainerServiceLinuxProfile(LinuxProfileAdminUserName,
                    new ContainerServiceSshConfiguration(pubKey));

            var acsServicePrincipal = EnsureServicePrincipal(ServicePrincipalIdAndSecret?.UserName, ServicePrincipalIdAndSecret?.Password?.ConvertToString());

            var spProfile = new ManagedClusterServicePrincipalProfile(
                acsServicePrincipal.SpId,
                acsServicePrincipal.ClientSecret);

            var aadProfile = GetAadProfile();

            var defaultAgentPoolProfile = GetAgentPoolProfile();

            var windowsProfile = GetWindowsProfile();

            var networkProfile = GetNetworkProfile();

            var addonProfiles = CreateAddonsProfiles();

            WriteVerbose(string.Format(Resources.DeployingYourManagedKubeCluster, AcsSpFilePath));

            var managedCluster = new ManagedCluster(
                Location,
                name: Name,
                tags: TagsConversionHelper.CreateTagDictionary(Tag, true),
                dnsPrefix: DnsNamePrefix,
                kubernetesVersion: KubernetesVersion,
                agentPoolProfiles: new List<ManagedClusterAgentPoolProfile> { defaultAgentPoolProfile },
                linuxProfile: linuxProfile,
                windowsProfile: windowsProfile,
                servicePrincipalProfile: spProfile,
                aadProfile: aadProfile,
                addonProfiles: addonProfiles,
                networkProfile: networkProfile);

            if(EnableRbac.IsPresent)
            {
                managedCluster.EnableRBAC = EnableRbac;
            }
            //if(EnablePodSecurityPolicy.IsPresent)
            //{
            //    managedCluster.EnablePodSecurityPolicy = EnablePodSecurityPolicy;
            //}

            if(this.IsParameterBound(c => c.AcrNameToAttach))
            {
                AddAcrRoleAssignment(AcrNameToAttach, nameof(AcrNameToAttach), acsServicePrincipal);
            }

            return managedCluster;
        }

        private ContainerServiceNetworkProfile GetNetworkProfile()
        {
            var networkProfile = new ContainerServiceNetworkProfile();
            networkProfile.NetworkPlugin = NetworkPlugin;
            networkProfile.LoadBalancerSku = LoadBalancerSku;
            return networkProfile;
        }

        private ManagedClusterWindowsProfile GetWindowsProfile()
        {
            ManagedClusterWindowsProfile windowsProfile = null;

            if(!string.IsNullOrEmpty(WindowsProfileAdminUserName) ||
                WindowsProfileAdminUserPassword != null)
            {
                windowsProfile = new ManagedClusterWindowsProfile(WindowsProfileAdminUserName,
                    WindowsProfileAdminUserPassword?.ConvertToString());
            }
            return windowsProfile;
        }

        private ManagedClusterAgentPoolProfile GetAgentPoolProfile()
        {
            var defaultAgentPoolProfile = new ManagedClusterAgentPoolProfile(
                name: NodeName ?? "default",
                count: NodeCount,
                vmSize: NodeVmSize,
                osDiskSizeGB: NodeOsDiskSize,
                type: NodeVmSetType ?? "VirtualMachineScaleSets",
                vnetSubnetID: NodeVnetSubnetID);
            defaultAgentPoolProfile.OsType = "Linux";
            if (this.IsParameterBound(c => c.NodeMaxPodCount))
            {
                defaultAgentPoolProfile.MaxPods = NodeMaxPodCount;
            }
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
            //if (EnableNodePublicIp.IsPresent)
            //{
            //    defaultAgentPoolProfile.EnableNodePublicIP = EnableNodePublicIp.ToBool();
            //}
            if (this.IsParameterBound(c => c.NodeScaleSetEvictionPolicy))
            {
                defaultAgentPoolProfile.ScaleSetEvictionPolicy = NodeScaleSetEvictionPolicy;
            }
            if (this.IsParameterBound(c => c.NodeSetPriority))
            {
                defaultAgentPoolProfile.ScaleSetPriority = NodeSetPriority;
            }
            defaultAgentPoolProfile.Mode = NodePoolMode;

            return defaultAgentPoolProfile;
        }

        private ManagedClusterAADProfile GetAadProfile()
        {
            ManagedClusterAADProfile aadProfile = null;
            //if (!string.IsNullOrEmpty(AadProfileClientAppId) || !string.IsNullOrEmpty(AadProfileServerAppId) ||
            //    !string.IsNullOrEmpty(AadProfileServerAppSecret) || !string.IsNullOrEmpty(AadProfileTenantId))
            //{
            //    aadProfile = new ManagedClusterAADProfile(clientAppID: AadProfileClientAppId, serverAppID: AadProfileServerAppId,
            //        serverAppSecret: AadProfileServerAppSecret, tenantID: AadProfileTenantId); 
            //}
            return aadProfile;
        }

        private IDictionary<string, ManagedClusterAddonProfile> CreateAddonsProfiles()
        {
            if (this.IsParameterBound(c => c.AddOnNameToBeEnabled))
            {
                Dictionary<string, ManagedClusterAddonProfile> addonProfiles = new Dictionary<string, ManagedClusterAddonProfile>();
                return AddonUtils.EnableAddonsProfile(addonProfiles, AddOnNameToBeEnabled, nameof(AddOnNameToBeEnabled), WorkspaceResourceId, nameof(WorkspaceResourceId), SubnetName, nameof(SubnetName));
            } else
            {
                return null;
            }
        }
    }
}