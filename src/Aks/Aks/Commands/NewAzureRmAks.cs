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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Aks.Utils;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksCluster", DefaultParameterSetName = DefaultParamSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSKubernetesCluster))]
    public class NewAzureRmAks : CreateOrUpdateKubeBase
    {
        // Request Body Parameters

        [Parameter(Mandatory = false, HelpMessage = "The name of the Edge Zone.")]
        public string EdgeZone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Add-on names to be enabled when cluster is created.")]
        [ValidateNotNullOrEmpty()]
        [PSArgumentCompleter("HttpApplicationRouting", "Monitoring", "VirtualNode", "AzurePolicy", "KubeDashboard")]
        public string[] AddOnNameToBeEnabled { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Subnet name of VirtualNode addon.")]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the workspace of Monitoring addon.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Availability zones for cluster. Must use VirtualMachineScaleSets AgentPoolType.")]
        public string[] AvailabilityZone { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable host based OS and data drive")]
        public SwitchParameter EnableEncryptionAtHost { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to use a FIPS-enabled OS.")]
        public SwitchParameter EnableFIPS { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable public IP for nodes.")]
        public SwitchParameter EnableNodePublicIp { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable UltraSSD")]
        public SwitchParameter EnableUltraSSD { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The GpuInstanceProfile to be used to specify GPU MIG instance profile for supported GPU VM SKU.")]
        [PSArgumentCompleter("MIG1g", "MIG2g", "MIG3g", "MIG4g", "MIG7g")]
        public string GpuInstanceProfile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The fully qualified resource ID of the Dedicated Host Group to provision virtual machines from, used only in creation scenario and not allowed to changed once set.")]
        public string NodeHostGroupID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Kubelet configuration on the agent pool nodes.")]
        public KubeletConfig NodeKubeletConfig { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The OS configuration of Linux agent nodes.")]
        public LinuxOSConfig NodeLinuxOSConfig { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Maximum number of pods that can run on node.")]
        public int NodeMaxPodCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The message of the day for Linux nodes, base64-encoded. A base64-encoded string which will be written to /etc/motd after decoding. This allows customization of the message of the day for Linux nodes. It must not be specified for Windows nodes. It must be a static string (i.e., will be printed raw and not be executed as a script).")]
        public string NodeMessageOfTheDay { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "NodePoolMode represents mode of an node pool.")]
        [PSArgumentCompleter("System", "User")]
        public string NodePoolMode { get; set; } = "System";

        [Parameter(Mandatory = false, HelpMessage = "The network-related settings of an agent pool.")]
        public AgentPoolNetworkProfile NodeNetworkProfile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource Id of public IP prefix for node pool.")]
        public string NodePublicIPPrefixID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The default is 'Ephemeral' if the VM supports it and has a cache disk larger than the requested OSDiskSizeGB. Otherwise, defaults to 'Managed'. May not be changed after creation. For more information see [Ephemeral OS](https://docs.microsoft.com/azure/aks/cluster-configuration#ephemeral-os).")]
        [PSArgumentCompleter("Managed", "Ephemeral")]
        public string NodeOSDiskType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The default OS sku for the node pools.")]
        [PSArgumentCompleter("Ubuntu", "Mariner", "AzureLinux", "Windows2019", "Windows2022")]
        public string NodeOsSKU { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The pod IP Allocation Mode. The IP allocation mode for pods in the agent pool. Must be used with podSubnetId. ")]
        [PSArgumentCompleter("DynamicIndividual", "StaticBlock")]
        public string NodePodIPAllocationMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The ID of the subnet which pods will join when launched.")]
        public string NodePodSubnetID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The ID for Proximity Placement Group.")]
        public string PPG { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ScaleSetEvictionPolicy to be used to specify eviction policy for low priority virtual machine scale set. Default to Delete.")]
        [PSArgumentCompleter("Delete", "Deallocate")]
        public string NodeScaleSetEvictionPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.")]
        [PSArgumentCompleter("Low", "Regular")]
        public string NodeSetPriority { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The secure Boot is a feature of Trusted Launch which ensures that only signed operating systems and drivers can boot. For more details, see aka.ms/aks/trustedlaunch.  If not specified, the default is false.")]
        public SwitchParameter NodeEnableSecureBoot { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The vTPM is a Trusted Launch feature for configuring a dedicated secure vault for keys and measurements held locally on the node. For more details, see aka.ms/aks/trustedlaunch. If not specified, the default is false.")]
        public SwitchParameter NodeEnableVtpm { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The sSH access method of an agent pool.")]
        [PSArgumentCompleter("LocalUser", "Disabled")]
        public string NodeSshAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Represents types of an node pool. Possible values include: 'VirtualMachineScaleSets', 'AvailabilitySet'")]
        [PSArgumentCompleter("AvailabilitySet", "VirtualMachineScaleSets", "VirtualMachines")]
        public string NodeVmSetType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The maximum number or percentage of nodes that ar surged during upgrade.")]
        public string NodeMaxSurge { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The parameters to be applied to the cluster-autoscaler.")]
        public ManagedClusterPropertiesAutoScalerProfile AutoScalerProfile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "VNet SubnetID specifies the VNet's subnet identifier.")]
        public string NodeVnetSubnetID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable Kubernetes Role-Based Access")]
        public SwitchParameter EnableRbac { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "DNS service IP used for building Kubernetes network.")]
        public string DnsServiceIP { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The load balancer sku for the managed cluster.")]
        [PSArgumentCompleter("basic", "standard")]
        public string LoadBalancerSku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Network plugin used for building Kubernetes network.")]
        [PSArgumentCompleter("azure", "kubenet")]
        public string NetworkPlugin { get; set; } = "azure";

        [Parameter(Mandatory = false, HelpMessage = "Network policy used for building Kubernetes network.")]
        public string NetworkPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The outbound (egress) routing method.")]
        [PSArgumentCompleter("loadBalancer", "userDefinedRouting", "managedNATGateway", "userAssignedNATGateway")]
        public string OutboundType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Pod cidr used for building Kubernetes network.")]
        public string PodCidr { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Service cidr used for building Kubernetes network.")]
        public string ServiceCidr { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource group containing agent pool.")]
        public string NodeResourceGroup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable OIDC issuer feature.")]
        public SwitchParameter EnableOidcIssuer { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The administrator username to use for Windows VMs.")]
        public string WindowsProfileAdminUserName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to use use Uptime SLA.")]
        public SwitchParameter EnableUptimeSLA { get; set; }

        // Other Parameters

        [Parameter(Mandatory = false, HelpMessage = "Generate ssh key file to folder {HOME}/.ssh/ using pre-installed ssh-keygen.")]
        public SwitchParameter GenerateSshKey { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Create cluster even if it already exists")]
        public SwitchParameter Force { get; set; }

        private AcsServicePrincipal acsServicePrincipal;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            PreValidate();
            PrepareParameter();

            Action action = () =>
            {
                WriteVerbose(Resources.PreparingForDeploymentOfYourManagedKubernetesCluster);
                var managedCluster = BuildNewCluster();
                try
                {

                    var cluster = this.CreateOrUpdate(ResourceGroupName, Name, managedCluster);
                    var psObj = AdapterHelper<ManagedCluster, PSKubernetesCluster>.Adapt(cluster);

                    if (this.IsParameterBound(c => c.AcrNameToAttach))
                    {
                        AddAcrRoleAssignment(AcrNameToAttach, nameof(AcrNameToAttach), acsServicePrincipal);
                    }
                    WriteObject(psObj);
                }
                catch (ValidationException e)
                {
                    var sdkApiParameterMap = new Dictionary<string, CmdletParameterNameValuePair>()
                    {
                        { Constants.DotNetApiParameterResourceGroupName, new CmdletParameterNameValuePair(nameof(ResourceGroupName), ResourceGroupName) },
                        { Constants.DotNetApiParameterResourceName, new CmdletParameterNameValuePair(nameof(Name), Name) },
                        { "Name", new CmdletParameterNameValuePair(nameof(NodeName), managedCluster.AgentPoolProfiles.FirstOrDefault()?.Name) },
                    };

                    if (!HandleValidationException(e, sdkApiParameterMap))
                    {
                        throw;
                    }
                }
            };

            var msg = $"{Name} in {ResourceGroupName}";

            if (Exists())
            {
                WriteVerbose(Resources.ClusterAlreadyExistsConfirmAction);
                ConfirmAction(
                    Force,
                    Resources.DoYouWantToCreateANewManagedKubernetesCluster,
                    Resources.CreatingAManagedKubernetesCluster,
                    msg,
                    action);
            }
            else
            {
                WriteVerbose(Resources.ClusterIsNew);
                if (ShouldProcess(msg, Resources.CreatingAManagedKubernetesCluster))
                {
                    RunCmdLet(action);
                }
            }
        }

        private void PreValidate()
        {
            if ((this.IsParameterBound(c => c.NodeMinCount) || this.IsParameterBound(c => c.NodeMaxCount) || this.EnableNodeAutoScaling.IsPresent) &&
                !(this.IsParameterBound(c => c.NodeMinCount) && this.IsParameterBound(c => c.NodeMaxCount) && this.EnableNodeAutoScaling.IsPresent))
            {
                throw new AzPSArgumentException(
                  Resources.AksNodePoolAutoScalingParametersMustAppearTogether,
                  nameof(EnableNodeAutoScaling),
                  desensitizedMessage: Resources.AksNodePoolAutoScalingParametersMustAppearTogether);
            }

            if (this.IsParameterBound(c => c.GenerateSshKey) && this.IsParameterBound(c => c.SshKeyValue))
            {
                throw new AzPSArgumentException(Resources.DonotUseGenerateSshKeyWithSshKeyValue,
                    nameof(GenerateSshKey),
                    desensitizedMessage: Resources.DonotUseGenerateSshKeyWithSshKeyValue);
            }

            if ((this.IsParameterBound(c => c.WindowsProfileAdminUserName) && !this.IsParameterBound(c => c.WindowsProfileAdminUserPassword)) ||
                (!this.IsParameterBound(c => c.WindowsProfileAdminUserName) && this.IsParameterBound(c => c.WindowsProfileAdminUserPassword)))
            {
                throw new AzPSArgumentException(
                    Resources.WindowsUserNameAndPasswordShouldAppearTogether,
                    nameof(WindowsProfileAdminUserName),
                    desensitizedMessage: Resources.WindowsUserNameAndPasswordShouldAppearTogether);
            }

            if (this.IsParameterBound(c => c.WindowsProfileAdminUserName))
            {
                if (!string.Equals(this.NetworkPlugin, "azure"))
                {
                    throw new AzPSArgumentException(
                        Resources.NetworkPluginShouldBeAzure,
                        nameof(NetworkPlugin),
                        desensitizedMessage: Resources.NetworkPluginShouldBeAzure);
                }
            }
        }

        private string GenerateSshKeyValue()
        {
            String generateSshKeyFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh");
            if (!Directory.Exists(generateSshKeyFolder)) {
                Directory.CreateDirectory(generateSshKeyFolder);
            }
            String generateSshKeyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh", "id_rsa");
            if (File.Exists(generateSshKeyPath))
            {
                throw new AzPSArgumentException(
                    string.Format(Resources.DefaultSshKeyAlreadyExist, generateSshKeyPath),
                    nameof(GenerateSshKey),
                    desensitizedMessage: string.Format(Resources.DefaultSshKeyAlreadyExist, "*"));
            }
            using (Process process = new Process())
            {
                try
                {
                    process.StartInfo.FileName = "ssh-keygen";
                    process.StartInfo.Arguments = String.Format("-f \"{0}\"", generateSshKeyPath);
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    string errorOutput = null;
                    process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => errorOutput += e.Data);
                    process.Start();

                    string standOutput = process.StandardOutput.ReadToEnd();
                    if (!string.IsNullOrEmpty(standOutput))
                    {
                        WriteDebug(standOutput);
                    }
                    process.WaitForExit();
                    if (!string.IsNullOrEmpty(errorOutput))
                    {
                        var errorMessage = string.Format(Resources.FailedToGenerateSshKey, errorOutput);
                        throw new AzPSInvalidOperationException(errorMessage, ErrorKind.InternalError);
                    }
                }
                catch (Win32Exception exception)
                {
                    var message = string.Format(Resources.FailedToRunSshKeyGen, exception.Message);
                    throw new AzPSInvalidOperationException(message, ErrorKind.InternalError);
                }
            }
            return GetSshKey(generateSshKeyPath);
        }

        protected void PrepareParameter()
        {
            if (this.IsParameterBound(c => c.GenerateSshKey))
            {
                SshKeyValue = GenerateSshKeyValue();
            }
        }
        private ManagedCluster BuildNewCluster()
        {
            BeforeBuildNewCluster();

            var pubKey =
                new List<ContainerServiceSshPublicKey> { new ContainerServiceSshPublicKey(SshKeyValue) };

            var linuxProfile =
                new ContainerServiceLinuxProfile(LinuxProfileAdminUserName,
                    new ContainerServiceSshConfiguration(pubKey));

            acsServicePrincipal = EnsureServicePrincipal(ServicePrincipalIdAndSecret?.UserName, ServicePrincipalIdAndSecret?.Password?.ConvertToString());

            var spProfile = new ManagedClusterServicePrincipalProfile(
                acsServicePrincipal.SpId,
                acsServicePrincipal.ClientSecret);

            var publicNetworkAccess = GetPublicNetworkAccess();

            var defaultAgentPoolProfile = GetAgentPoolProfile();

            var windowsProfile = GetWindowsProfile();

            var networkProfile = GetNetworkProfile();

            var apiServerAccessProfile = CreateOrUpdateApiServerAccessProfile(null);

            var httpProxyConfig = CreateOrUpdateHttpProxyConfig(null);

            var autoUpgradeProfile = CreateOrUpdateAutoUpgradeProfile(null);

            var addonProfiles = CreateAddonsProfiles();

            WriteVerbose(string.Format(Resources.DeployingYourManagedKubeCluster, AcsSpFilePath));

            var managedCluster = new ManagedCluster(
                Location,
                name: Name,
                tags: TagsConversionHelper.CreateTagDictionary(Tag, true),
                publicNetworkAccess: publicNetworkAccess,
                dnsPrefix: DnsNamePrefix,
                kubernetesVersion: KubernetesVersion,
                nodeResourceGroup: NodeResourceGroup,
                supportPlan: SupportPlan,
                agentPoolProfiles: new List<ManagedClusterAgentPoolProfile> { defaultAgentPoolProfile },
                linuxProfile: linuxProfile,
                windowsProfile: windowsProfile,
                servicePrincipalProfile: spProfile,
                aadProfile: AadProfile,
                addonProfiles: addonProfiles,
                networkProfile: networkProfile,
                apiServerAccessProfile: apiServerAccessProfile,
                httpProxyConfig: httpProxyConfig,
                autoUpgradeProfile: autoUpgradeProfile);

            SetIdentity(managedCluster);

            if (EnableRbac.IsPresent)
            {
                managedCluster.EnableRbac = EnableRbac;
            }
            if (this.IsParameterBound(c => c.FqdnSubdomain))
            {
                managedCluster.FqdnSubdomain = FqdnSubdomain;
            }
            if (this.IsParameterBound(c => c.AssignKubeletIdentity))
            {
                managedCluster.IdentityProfile = new Dictionary<string, UserAssignedIdentity>
                {
                    { "kubeletidentity", new UserAssignedIdentity(AssignKubeletIdentity) }
                };
            }
            if (this.IsParameterBound(c => c.DiskEncryptionSetID))
            {
                managedCluster.DiskEncryptionSetId = DiskEncryptionSetID;
            }
            if (DisableLocalAccount.IsPresent)
            {
                managedCluster.DisableLocalAccounts = DisableLocalAccount;
            }
            if (EnabledMonitorMetric.IsPresent)
            {
                managedCluster.AzureMonitorProfile = new ManagedClusterAzureMonitorProfile(new ManagedClusterAzureMonitorProfileMetrics(enabled: EnabledMonitorMetric.ToBool()));
            }
            //if(EnablePodSecurityPolicy.IsPresent)
            //{
            //    managedCluster.EnablePodSecurityPolicy = EnablePodSecurityPolicy;
            //}
            if (this.IsParameterBound(c => c.AutoScalerProfile))
            {
                managedCluster.AutoScalerProfile = AutoScalerProfile;
            }
            if (this.IsParameterBound(c => c.EnableUptimeSLA))
            {
                if (EnableUptimeSLA.ToBool())
                {
                    managedCluster.Sku = new ManagedClusterSKU(name: "Base", tier: "Standard");
                }
                else
                {
                    managedCluster.Sku = new ManagedClusterSKU(name: "Base", tier: "Free");
                }
            }
            if (this.IsParameterBound(c => c.EdgeZone))
            {
                managedCluster.ExtendedLocation = new ExtendedLocation(name: EdgeZone, type: "EdgeZone");
            }

            if (this.IsParameterBound(c => c.EnableAIToolchainOperator))
            {
                managedCluster.AiToolchainOperatorProfile = new ManagedClusterAIToolchainOperatorProfile(enabled: EnableAIToolchainOperator.ToBool());
            }
            if (this.IsParameterBound(c => c.EnableOidcIssuer))
            {
                managedCluster.OidcIssuerProfile = new ManagedClusterOidcIssuerProfile(enabled: EnableOidcIssuer.ToBool());
            }
            if (this.IsParameterBound(c => c.NodeProvisioningMode) || this.IsParameterBound(c => c.NodeProvisioningDefaultPool))
            {
                managedCluster.NodeProvisioningProfile = new ManagedClusterNodeProvisioningProfile();
                if (this.IsParameterBound(c => c.NodeProvisioningMode)) {
                    managedCluster.NodeProvisioningProfile.Mode = NodeProvisioningMode;
                }
                if (this.IsParameterBound(c => c.NodeProvisioningDefaultPool))
                {
                    managedCluster.NodeProvisioningProfile.DefaultNodePools = NodeProvisioningDefaultPool;
                }
            }
            if (this.IsParameterBound(c => c.NodeResourceGroupRestrictionLevel))
            {
                managedCluster.NodeResourceGroupProfile = new ManagedClusterNodeResourceGroupProfile();
                managedCluster.NodeResourceGroupProfile.RestrictionLevel = NodeResourceGroupRestrictionLevel;
            }

            managedCluster.MetricsProfile = CreateOrUpdateMetricsProfile();
            managedCluster.BootstrapProfile = CreateOrUpdateBootstrapProfile();
            managedCluster.PodIdentityProfile = CreateOrUpdatePodIdentityProfile();
            managedCluster.SecurityProfile = CreateOrUpdateSecurityProfile();
            managedCluster.WorkloadAutoScalerProfile = CreateOrUpdateWorkloadAutoScalerProfile();

            return managedCluster;
        }

        private ContainerServiceNetworkProfile GetNetworkProfile()
        {
            var networkProfile = new ContainerServiceNetworkProfile
            {
                NetworkPlugin = NetworkPlugin,
                LoadBalancerSku = LoadBalancerSku
            };
            if (this.IsParameterBound(c => c.NetworkPolicy))
            {
                networkProfile.NetworkPolicy = NetworkPolicy;
            }
            if (this.IsParameterBound(c => c.PodCidr))
            {
                networkProfile.PodCidr = PodCidr;
            }
            if (this.IsParameterBound(c => c.ServiceCidr))
            {
                networkProfile.ServiceCidr = ServiceCidr;
            }
            if (this.IsParameterBound(c => c.DnsServiceIP))
            {
                networkProfile.DnsServiceIP = DnsServiceIP;
            }
            if (this.IsParameterBound(c => c.OutboundType))
            {
                networkProfile.OutboundType = OutboundType;
            }
            if (this.IsParameterBound(c => c.IPFamily))
            {
                networkProfile.IPFamilies = IPFamily;
            }
            if (this.IsParameterBound(c => c.NetworkDataplane))
            {
                networkProfile.NetworkDataplane = NetworkDataplane;
            }
            if (this.IsParameterBound(c => c.NetworkPluginMode))
            {
                networkProfile.NetworkPluginMode = NetworkPluginMode;
            }
            if (this.IsParameterBound(c => c.EnabledStaticEgressGateway))
            {
                networkProfile.StaticEgressGatewayProfile = new ManagedClusterStaticEgressGatewayProfile(EnabledStaticEgressGateway.ToBool());
            }

            networkProfile.LoadBalancerProfile = CreateOrUpdateLoadBalancerProfile();
            networkProfile.NatGatewayProfile = CreateOrUpdateNATGatewayProfile();
            networkProfile.AdvancedNetworking = CreateOrUpdateAdvancedNetworking();

            return networkProfile;
        }

        private ManagedClusterWindowsProfile GetWindowsProfile()
        {
            ManagedClusterWindowsProfile windowsProfile = null;

            if (!string.IsNullOrEmpty(WindowsProfileAdminUserName) ||
                WindowsProfileAdminUserPassword != null)
            {
                windowsProfile = new ManagedClusterWindowsProfile(WindowsProfileAdminUserName,
                    WindowsProfileAdminUserPassword?.ConvertToString());
                if (this.IsParameterBound(c => c.EnableAHUB) && EnableAHUB.ToBool())
                {
                    windowsProfile.LicenseType = "Windows_Server";
                }
            }
            return windowsProfile;
        }

        private ManagedClusterAgentPoolProfile GetAgentPoolProfile()
        {
            var defaultAgentPoolProfile = new ManagedClusterAgentPoolProfile(
                name: NodeName ?? "default",
                count: NodeCount,
                vmSize: NodeVmSize,
                osDiskSizeGb: NodeOsDiskSize,
                osDiskType: NodeOSDiskType,
                messageOfTheDay: NodeMessageOfTheDay,
                type: NodeVmSetType ?? "VirtualMachineScaleSets",
                vnetSubnetId: NodeVnetSubnetID);
            defaultAgentPoolProfile.OSType = "Linux";
            if (this.IsParameterBound(c => c.NodeOsSKU))
            {
                defaultAgentPoolProfile.OSSku = NodeOsSKU;
                if (NodeOsSKU.ToLower().Equals("cblmariner") || NodeOsSKU.ToLower().Equals("mariner")) {
                    WriteWarning("The NodeOsSKU 'AzureLinux' should be used going forward instead of 'CBLMariner' or 'Mariner'. The NodeOsSKU 'CBLMariner' and 'Mariner' will eventually be deprecated.");
                }
            }
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
            if (this.IsParameterBound(c => c.NodePodIPAllocationMode))
            {
                defaultAgentPoolProfile.PodIPAllocationMode = NodePodIPAllocationMode;
            }
            if (EnableNodeAutoScaling.IsPresent)
            {
                defaultAgentPoolProfile.EnableAutoScaling = EnableNodeAutoScaling.ToBool();
            }
            if (EnableNodePublicIp.IsPresent)
            {
                defaultAgentPoolProfile.EnableNodePublicIP = EnableNodePublicIp.ToBool();
            }
            if (this.IsParameterBound(c => c.NodePublicIPPrefixID))
            {
                defaultAgentPoolProfile.NodePublicIPPrefixId = NodePublicIPPrefixID;
            }
            if (this.IsParameterBound(c => c.NodeScaleSetEvictionPolicy))
            {
                defaultAgentPoolProfile.ScaleSetEvictionPolicy = NodeScaleSetEvictionPolicy;
            }
            if (this.IsParameterBound(c => c.NodeSetPriority))
            {
                defaultAgentPoolProfile.ScaleSetPriority = NodeSetPriority;
            }
            if (this.IsParameterBound(c => c.NodeWorkloadRuntime))
            {
                defaultAgentPoolProfile.WorkloadRuntime = NodeWorkloadRuntime;
            }
            if (this.IsParameterBound(c => c.NodePoolLabel))
            {
                defaultAgentPoolProfile.NodeLabels = new Dictionary<string, string>();
                foreach (var key in NodePoolLabel.Keys)
                {
                    defaultAgentPoolProfile.NodeLabels.Add(key.ToString(), NodePoolLabel[key].ToString());
                }
            }
            if(this.IsParameterBound(c => c.NodeTaint))
            {
                defaultAgentPoolProfile.NodeTaints = NodeTaint;
            }
            if (this.IsParameterBound(c => c.NodePoolTag))
            {
                defaultAgentPoolProfile.Tags = new Dictionary<string, string>();
                foreach (var key in NodePoolTag.Keys)
                {
                    defaultAgentPoolProfile.Tags.Add(key.ToString(), NodePoolTag[key].ToString());
                }
            }
            if (this.IsParameterBound(c => c.NodePodSubnetID)) {
                defaultAgentPoolProfile.PodSubnetId = NodePodSubnetID;
            }
            if (this.IsParameterBound(c => c.AvailabilityZone))
            {
                defaultAgentPoolProfile.AvailabilityZones = AvailabilityZone;
            }
            if (EnableEncryptionAtHost.IsPresent)
            {
                defaultAgentPoolProfile.EnableEncryptionAtHost = EnableEncryptionAtHost.ToBool();
            }
            if (EnableUltraSSD.IsPresent)
            {
                defaultAgentPoolProfile.EnableUltraSsd = EnableUltraSSD.ToBool();
            }
            if (this.IsParameterBound(c => c.NodeLinuxOSConfig))
            {
                defaultAgentPoolProfile.LinuxOSConfig = NodeLinuxOSConfig;
            }
            if (this.IsParameterBound(c => c.NodeKubeletConfig))
            {
                defaultAgentPoolProfile.KubeletConfig = NodeKubeletConfig;
            }
            if (this.IsParameterBound(c => c.NodeNetworkProfile))
            {
                defaultAgentPoolProfile.NetworkProfile = NodeNetworkProfile;
            }
            if (this.IsParameterBound(c => c.NodeMaxSurge))
            {
                defaultAgentPoolProfile.UpgradeSettings = new AgentPoolUpgradeSettings(NodeMaxSurge);
            }
            if (this.IsParameterBound(c => c.PPG))
            {
                defaultAgentPoolProfile.ProximityPlacementGroupId = PPG;
            }
            if (EnableFIPS.IsPresent)
            {
                defaultAgentPoolProfile.EnableFips = EnableFIPS.ToBool();
            }
            if (this.IsParameterBound(c => c.GpuInstanceProfile))
            {
                defaultAgentPoolProfile.GpuInstanceProfile = GpuInstanceProfile;
            }
            if (this.IsParameterBound(c => c.NodeHostGroupID)) {
                defaultAgentPoolProfile.HostGroupId = NodeHostGroupID;
            }

            defaultAgentPoolProfile.SecurityProfile = GetAgentPoolSecurityProfile();

            defaultAgentPoolProfile.Mode = NodePoolMode;

            return defaultAgentPoolProfile;
        }

        private AgentPoolSecurityProfile GetAgentPoolSecurityProfile()
        {
            if (this.IsParameterBound(c => c.NodeEnableSecureBoot) || 
                this.IsParameterBound(c => c.NodeEnableVtpm) ||
                this.IsParameterBound(c => c.NodeSshAccess))
            {
                var securityProfile = new AgentPoolSecurityProfile();
                if (this.IsParameterBound(c => c.NodeEnableVtpm))
                {
                    securityProfile.EnableVtpm = NodeEnableVtpm.ToBool();
                }
                if (this.IsParameterBound(c => c.NodeEnableSecureBoot))
                {
                    securityProfile.EnableSecureBoot = NodeEnableSecureBoot.ToBool();
                }
                if (this.IsParameterBound(c => c.NodeSshAccess))
                {
                    securityProfile.SshAccess = NodeSshAccess;
                }
                return securityProfile;
            }
            return null;
        }

        private IDictionary<string, ManagedClusterAddonProfile> CreateAddonsProfiles()
        {
            if (this.IsParameterBound(c => c.AddOnNameToBeEnabled))
            {
                Dictionary<string, ManagedClusterAddonProfile> addonProfiles = new Dictionary<string, ManagedClusterAddonProfile>();
                return AddonUtils.EnableAddonsProfile(addonProfiles, AddOnNameToBeEnabled, nameof(AddOnNameToBeEnabled), WorkspaceResourceId, nameof(WorkspaceResourceId), SubnetName, nameof(SubnetName));
            }
            else
            {
                return null;
            }
        }
    }
}
