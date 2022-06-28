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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;

using Microsoft.Azure.Commands.Aks.Models;
using Microsoft.Azure.Commands.Aks.Properties;
using Microsoft.Azure.Commands.Aks.Utils;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Aks
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AksCluster", DefaultParameterSetName = DefaultParamSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSKubernetesCluster))]
    public class NewAzureRmAks : CreateOrUpdateKubeBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Represents types of an node pool. Possible values include: 'VirtualMachineScaleSets', 'AvailabilitySet'")]
        [PSArgumentCompleter("AvailabilitySet", "VirtualMachineScaleSets")]
        public string NodeVmSetType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "VNet SubnetID specifies the VNet's subnet identifier.")]
        public string NodeVnetSubnetID { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Maximum number of pods that can run on node.")]
        public int NodeMaxPodCount { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable Kubernetes Role-Based Access")]
        public SwitchParameter EnableRbac { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The administrator username to use for Windows VMs.")]
        public string WindowsProfileAdminUserName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The administrator password to use for Windows VMs. Password requirement:"
          + "At least one lower case, one upper case, one special character !@#$%^&*(), the minimum lenth is 12.")]
        [ValidateSecureString(RegularExpression = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%\\^&\\*\\(\\)])[a-zA-Z\\d!@#$%\\^&\\*\\(\\)]{12,123}$", ParameterName = nameof(WindowsProfileAdminUserPassword))]
        public SecureString WindowsProfileAdminUserPassword { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Network plugin used for building Kubernetes network.")]
        [PSArgumentCompleter("azure", "kubenet")]
        public string NetworkPlugin { get; set; } = "azure";

        [Parameter(Mandatory = false, HelpMessage = "Network policy used for building Kubernetes network.")]
        public string NetworkPolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Pod cidr used for building Kubernetes network.")]
        public string PodCidr { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Service cidr used for building Kubernetes network.")]
        public string ServiceCidr { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "DNS service IP used for building Kubernetes network.")]
        public string DnsServiceIP { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Docker bridge cidr used for building Kubernetes network.")]
        public string DockerBridgeCidr { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Node pool labels used for building Kubernetes network.")]

        public Hashtable NodePoolLabel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Aks custom headers used for building Kubernetes network.")]

        public Hashtable AksCustomHeader { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The load balancer sku for the managed cluster.")]
        [PSArgumentCompleter("basic", "standard")]
        public string LoadBalancerSku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Create cluster even if it already exists")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Generate ssh key file to folder {HOME}/.ssh/ using pre-installed ssh-keygen.")]
        public SwitchParameter GenerateSshKey { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable public IP for nodes.")]
        public SwitchParameter EnableNodePublicIp { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The resource Id of public IP prefix for node pool.")]
        public string NodePublicIPPrefixID { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Availability zones for cluster. Must use VirtualMachineScaleSets AgentPoolType.")]
        public string[] AvailabilityZone { get; set; }

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
                    ManagedCluster cluster;
                    if (this.IsParameterBound(c => c.AksCustomHeader))
                    {
                        Dictionary<string, List<string>> customHeaders = new Dictionary<string, List<string>>();
                        foreach (var key in AksCustomHeader.Keys)
                        {
                            List<string> values = new List<string>();
                            foreach (var value in (object[])AksCustomHeader[key])
                            {
                                values.Add(value.ToString());
                            }
                            customHeaders.Add(key.ToString(), values);
                        }

                        cluster = Client.ManagedClusters.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, Name, managedCluster, customHeaders).GetAwaiter().GetResult().Body;
                    }
                    else
                    {
                        cluster = Client.ManagedClusters.CreateOrUpdate(ResourceGroupName, Name, managedCluster);
                    }
                    var psObj = PSMapper.Instance.Map<PSKubernetesCluster>(cluster);

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
            String generateSshKeyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh", "id_rsa"); ;
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

            var aadProfile = GetAadProfile();

            var defaultAgentPoolProfile = GetAgentPoolProfile();

            var windowsProfile = GetWindowsProfile();

            var networkProfile = GetNetworkProfile();

            var apiServerAccessProfile = CreateOrUpdateApiServerAccessProfile(null);

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
                networkProfile: networkProfile,
                apiServerAccessProfile: apiServerAccessProfile);

            SetIdentity(managedCluster);

            if (EnableRbac.IsPresent)
            {
                managedCluster.EnableRBAC = EnableRbac;
            }
            if (this.IsParameterBound(c => c.FqdnSubdomain))
            {
                managedCluster.FqdnSubdomain = FqdnSubdomain;
            }
            //if(EnablePodSecurityPolicy.IsPresent)
            //{
            //    managedCluster.EnablePodSecurityPolicy = EnablePodSecurityPolicy;
            //}

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
            if (this.IsParameterBound(c => c.DockerBridgeCidr))
            {
                networkProfile.DockerBridgeCidr = DockerBridgeCidr;
            }
            networkProfile.LoadBalancerProfile = CreateOrUpdateLoadBalancerProfile(null);

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
            if (EnableNodePublicIp.IsPresent)
            {
                defaultAgentPoolProfile.EnableNodePublicIP = EnableNodePublicIp.ToBool();
            }
            if (this.IsParameterBound(c => c.NodePublicIPPrefixID))
            {
                defaultAgentPoolProfile.NodePublicIPPrefixID = NodePublicIPPrefixID;
            }
            if (this.IsParameterBound(c => c.NodeScaleSetEvictionPolicy))
            {
                defaultAgentPoolProfile.ScaleSetEvictionPolicy = NodeScaleSetEvictionPolicy;
            }
            if (this.IsParameterBound(c => c.NodeSetPriority))
            {
                defaultAgentPoolProfile.ScaleSetPriority = NodeSetPriority;
            }
            if (this.IsParameterBound(c => c.NodePoolLabel))
            {
                defaultAgentPoolProfile.NodeLabels = new Dictionary<string, string>();
                foreach (var key in NodePoolLabel.Keys)
                {
                    defaultAgentPoolProfile.NodeLabels.Add(key.ToString(), NodePoolLabel[key].ToString());
                }
            }
            if (this.IsParameterBound(c => c.AvailabilityZone))
            {
                defaultAgentPoolProfile.AvailabilityZones = AvailabilityZone;
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
            }
            else
            {
                return null;
            }
        }
    }
}
