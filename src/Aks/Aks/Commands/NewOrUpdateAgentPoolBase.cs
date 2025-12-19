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

using Microsoft.Azure.Commands.Aks.Commands;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.ContainerService.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Aks
{
    public class NewOrUpdateAgentPoolBase : KubeCmdletBase
    {

        [Parameter(Mandatory = false, HelpMessage = "The version of Kubernetes to use for creating the cluster.")]
        public string KubernetesVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Minimum number of nodes for auto-scaling.")]
        public int MinCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Maximum number of nodes for auto-scaling")]
        public int MaxCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether to enable auto-scaler")]
        public SwitchParameter EnableAutoScaling { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The pool mode")]
        [PSArgumentCompleter("System", "User", "Gateway")]
        public string Mode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Node pool labels used for building Kubernetes network.")]
        public Hashtable NodeLabel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The tags to be persisted on the agent pool virtual machine scale set.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The node taints added to new nodes during node pool create and scale")]
        public string[] NodeTaint { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Aks custom headers")]
        public Hashtable AksCustomHeader { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The request should only proceed if an entity matches this string.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The request should only proceed if no entity matches this string.")]
        public string IfNoneMatch { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The network-related settings of an agent pool.")]
        public AgentPoolNetworkProfile NetworkProfile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The scale down mode to use when scaling the Agent Pool. This also effects the cluster autoscaler behavior. If not specified, it defaults to Delete.")]
        [PSArgumentCompleter("Delete", "Deallocate")]
        public string ScaleDownMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The secure Boot is a feature of Trusted Launch which ensures that only signed operating systems and drivers can boot. For more details, see aka.ms/aks/trustedlaunch.  If not specified, the default is false.")]
        public SwitchParameter EnableSecureBoot { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The vTPM is a Trusted Launch feature for configuring a dedicated secure vault for keys and measurements held locally on the node. For more details, see aka.ms/aks/trustedlaunch. If not specified, the default is false.")]
        public SwitchParameter EnableVtpm { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The sSH access method of an agent pool.")]
        [PSArgumentCompleter("LocalUser", "Disabled")]
        public string SshAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The maximum number or percentage of nodes that are surged during upgrade. This can either be set to an integer (e.g. &#39;5&#39;) or a percentage (e.g. &#39;50%&#39;). If a percentage is specified, it is the percentage of the total agent pool size at the time of the upgrade. For percentages, fractional nodes are rounded up. If not specified, the default is 10%. For more information, including best practices, see: https://learn.microsoft.com/en-us/azure/aks/upgrade-cluster")]
        public string MaxSurge { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The maximum number or percentage of nodes that can be simultaneously unavailable during upgrade. This can either be set to an integer (e.g. &#39;1&#39;) or a percentage (e.g. &#39;5%&#39;). If a percentage is specified, it is the percentage of the total agent pool size at the time of the upgrade. For percentages, fractional nodes are rounded up. If not specified, the default is 0. For more information, including best practices, see: https://learn.microsoft.com/en-us/azure/aks/upgrade-cluster")]
        public string MaxUnavailable { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The drain timeout for a node. The amount of time (in minutes) to wait on eviction of pods and graceful termination per node. This eviction wait time honors waiting on pod disruption budgets. If this time is exceeded, the upgrade fails. If not specified, the default is 30 minutes.")]
        public int DrainTimeoutInMinute { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The the soak duration for a node. The amount of time (in minutes) to wait after draining a node and before reimaging it and moving on to next node. If not specified, the default is 0 minutes.")]
        public int NodeSoakDurationInMinute { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The behavior for undrainable nodes during upgrade. The most common cause of undrainable nodes is Pod Disruption Budgets (PDBs), but other issues, such as pod termination grace period is exceeding the remaining per-node drain timeout or pod is still being in a running state, can also cause undrainable nodes.")]
        [PSArgumentCompleter("Cordon", "Schedule")]
        public string UndrainableNodeBehavior { get; set; }

        protected AgentPoolSecurityProfile CreateOrUpdateSecurityProfile(AgentPoolSecurityProfile SecurityProfile = null)
        {
            if (this.IsParameterBound(c => c.EnableSecureBoot) ||
                this.IsParameterBound(c => c.EnableVtpm) ||
                this.IsParameterBound(c => c.SshAccess) )
            {
                if (SecurityProfile == null)
                {
                    SecurityProfile = new AgentPoolSecurityProfile();
                }
                if (this.IsParameterBound(c => c.EnableSecureBoot))
                {
                    SecurityProfile.EnableSecureBoot = EnableSecureBoot.ToBool();
                }
                if (this.IsParameterBound(c => c.EnableVtpm))
                {
                    SecurityProfile.EnableVtpm = EnableVtpm.ToBool();
                }
                if (this.IsParameterBound(c => c.SshAccess))
                {
                    SecurityProfile.SshAccess = SshAccess;
                }
            }
            return SecurityProfile;
        }

        protected AgentPoolUpgradeSettings CreateOrUpdateUpgradeSettings(AgentPoolUpgradeSettings UpgradeSettings = null)
        {
            if (this.IsParameterBound(c => c.MaxSurge) ||
                this.IsParameterBound(c => c.MaxUnavailable) ||
                this.IsParameterBound(c => c.DrainTimeoutInMinute) ||
                this.IsParameterBound(c => c.NodeSoakDurationInMinute) ||
                this.IsParameterBound(c => c.UndrainableNodeBehavior))
            {
                if (UpgradeSettings == null)
                {
                    UpgradeSettings = new AgentPoolUpgradeSettings();
                }
                if (this.IsParameterBound(c => c.MaxSurge))
                {
                    UpgradeSettings.MaxSurge = MaxSurge;
                }
                if (this.IsParameterBound(c => c.MaxUnavailable))
                {
                    UpgradeSettings.MaxUnavailable = MaxUnavailable;
                }
                if (this.IsParameterBound(c => c.DrainTimeoutInMinute))
                {
                    UpgradeSettings.DrainTimeoutInMinutes = DrainTimeoutInMinute;
                }
                if (this.IsParameterBound(c => c.NodeSoakDurationInMinute))
                {
                    UpgradeSettings.NodeSoakDurationInMinutes = NodeSoakDurationInMinute;
                }
                if (this.IsParameterBound(c => c.UndrainableNodeBehavior))
                {
                    UpgradeSettings.UndrainableNodeBehavior = UndrainableNodeBehavior;
                }
            }
            return UpgradeSettings;
        }

        private protected AgentPool CreateOrUpdate(string resourceGroupName, string resourceName, string agentPoolName, AgentPool parameters)
        {
            if (this.IsParameterBound(c => c.AksCustomHeader))
            {
                Dictionary<string, List<string>> customHeaders = Utilities.HashtableToDictionary(AksCustomHeader);
                return Client.AgentPools.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, resourceName, agentPoolName, parameters, IfMatch, IfNoneMatch, customHeaders).GetAwaiter().GetResult().Body;
            }
            else
            {
                return Client.AgentPools.CreateOrUpdate(resourceGroupName, resourceName, agentPoolName, parameters, IfMatch, IfNoneMatch);
            }
        }
    }
}
