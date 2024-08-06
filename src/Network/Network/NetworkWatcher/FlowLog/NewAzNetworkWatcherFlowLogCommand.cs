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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherFlowLog", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"), OutputType(typeof(PSFlowLogResource))]
    public class NewAzNetworkWatcherFlowLogCommand : FlowLogBaseCmdlet
    {
        private const string SetByResource = "SetByResource";
        private const string SetByResourceWithTA = "SetByResourceWithTA";
        private const string SetByName = "SetByName";
        private const string SetByNameWithTA = "SetByNameWithTA";
        private const string SetByLocation = "SetByLocation";
        private const string SetByLocationWithTA = "SetByLocationWithTA";

        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = SetByResource)]
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = SetByResourceWithTA)]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = SetByName)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = SetByNameWithTA)]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = SetByName)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = SetByNameWithTA)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = SetByLocation)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = SetByLocationWithTA)]
        [LocationCompleter("Microsoft.Network/networkWatchers")]
        [ValidateNotNull]
        public string Location { get; set; }

        [Alias("FlowLogName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The flow log name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "ID of network security group to which flow log will be applied.")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "ID of the storage account which is used to store the flow log.")]
        [ValidateNotNullOrEmpty]
        public string StorageId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Optional field to filter network traffic logs.")]
        [ValidateNotNullOrEmpty]
        public string EnabledFilteringCriteria { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Flag to enable/disable flow logging.")]
        [ValidateNotNullOrEmpty]
        public bool Enabled { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable/disable retention.")]
        [ValidateNotNull]
        public bool EnableRetention { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Number of days to retain flow log records.")]
        [ValidateNotNull]
        public int? RetentionPolicyDays { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The file type of flow log. The only supported value now is 'JSON'.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("JSON")]
        public string FormatType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The version (revision) of the flow log.")]
        [ValidateNotNull]
        public int? FormatVersion { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Flag to enable/disable TrafficAnalytics",
             ParameterSetName = SetByResourceWithTA)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Flag to enable/disable TrafficAnalytics",
             ParameterSetName = SetByNameWithTA)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Flag to enable/disable TrafficAnalytics",
             ParameterSetName = SetByLocationWithTA)]
        [ValidateNotNull]
        public SwitchParameter EnableTrafficAnalytics { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Resource Id of the attached workspace.",
             ParameterSetName = SetByResourceWithTA)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Resource Id of the attached workspace.",
             ParameterSetName = SetByNameWithTA)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Resource Id of the attached workspace.",
             ParameterSetName = SetByLocationWithTA)]
        [ValidateNotNullOrEmpty]
        public string TrafficAnalyticsWorkspaceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The interval in minutes which would decide how frequently TA service should do flow analytics.",
             ParameterSetName = SetByResourceWithTA)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The interval in minutes which would decide how frequently TA service should do flow analytics.",
             ParameterSetName = SetByNameWithTA)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The interval in minutes which would decide how frequently TA service should do flow analytics.",
             ParameterSetName = SetByLocationWithTA)]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int? TrafficAnalyticsInterval { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
          Mandatory = false,
          HelpMessage = "ResourceId of the user assigned identity to be assigned to Flowlog.")]
        [ValidateNotNullOrEmpty]
        [Alias("UserAssignedIdentity")]
        public string UserAssignedIdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Contains(SetByResource))
            {
                this.ResourceGroupName = this.NetworkWatcher.ResourceGroupName;
                this.NetworkWatcherName = this.NetworkWatcher.Name;
                this.Location = this.NetworkWatcher.Location;
            }
            else if (ParameterSetName.Contains(SetByLocation))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new PSArgumentException(Properties.Resources.NoNetworkWatcherFound);
                }

                this.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                this.NetworkWatcherName = networkWatcher.Name;
            }
            else if (ParameterSetName.Contains(SetByName))
            {
                MNM.NetworkWatcher networkWatcher = this.NetworkClient.NetworkManagementClient.NetworkWatchers.Get(this.ResourceGroupName, this.NetworkWatcherName);
                this.Location = networkWatcher.Location;
            }

            var present = this.IsFlowLogPresent(this.ResourceGroupName, this.NetworkWatcherName, this.Name);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, this.Name),
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    PSFlowLogResource flowLog = CreateFlowLog();
                    WriteObject(flowLog);
                },
                () => present);
        }

        private PSFlowLogResource CreateFlowLog()
        {
            this.ValidateFlowLogParameters(this.TargetResourceId, this.StorageId, this.EnabledFilteringCriteria, this.FormatVersion, this.FormatType, this.EnableTrafficAnalytics == true,
                this.TrafficAnalyticsWorkspaceId, this.TrafficAnalyticsInterval, this.RetentionPolicyDays, this.UserAssignedIdentityId);

            MNM.FlowLog flowLogParameters = GetFlowLogParametersFromRequest();

            this.FlowLogs.CreateOrUpdate(this.ResourceGroupName, this.NetworkWatcherName, this.Name, flowLogParameters);
            MNM.FlowLog flowLogResult = this.FlowLogs.Get(this.ResourceGroupName, this.NetworkWatcherName, this.Name);

            return NetworkResourceManagerProfile.Mapper.Map<PSFlowLogResource>(flowLogResult);
        }

        private MNM.FlowLog GetFlowLogParametersFromRequest()
        {
            MNM.FlowLog flowLogParameters = new FlowLog
            {
                Location = this.Location,
                TargetResourceId = this.TargetResourceId,
                StorageId = this.StorageId,
                Enabled = this.Enabled,
                EnabledFilteringCriteria = this.EnabledFilteringCriteria ?? "",
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true)
            };

            if (this.EnableRetention == true || this.EnableRetention == false)
            {
                flowLogParameters.RetentionPolicy = new MNM.RetentionPolicyParameters
                {
                    Enabled = this.EnableRetention,
                    Days = this.RetentionPolicyDays
                };
            }

            if (this.UserAssignedIdentityId != null)
            {
                if (string.Equals(this.UserAssignedIdentityId, "none", StringComparison.OrdinalIgnoreCase))
                {
                    flowLogParameters.Identity = new ManagedServiceIdentity
                    {
                        Type = MNM.ResourceIdentityType.None,
                    };
                }
                else
                {
                    flowLogParameters.Identity = new ManagedServiceIdentity
                    {
                        Type = MNM.ResourceIdentityType.UserAssigned,
                        UserAssignedIdentities = new Dictionary<string, ManagedServiceIdentityUserAssignedIdentitiesValue>
                    {
                        { this.UserAssignedIdentityId, new ManagedServiceIdentityUserAssignedIdentitiesValue() }
                    }
                    };
                }
            }

            if (!string.IsNullOrWhiteSpace(this.FormatType) || this.FormatVersion != null)
            {
                flowLogParameters.Format = new MNM.FlowLogFormatParameters
                {
                    Type = "JSON",
                    Version = this.FormatVersion ?? 0
                };
            }

            if (ParameterSetName.Contains("WithTA"))
            {
                flowLogParameters.FlowAnalyticsConfiguration = new TrafficAnalyticsProperties()
                {
                    NetworkWatcherFlowAnalyticsConfiguration = new TrafficAnalyticsConfigurationProperties()
                    {
                        Enabled = this.EnableTrafficAnalytics.IsPresent,
                        WorkspaceResourceId = this.TrafficAnalyticsWorkspaceId,
                        TrafficAnalyticsInterval = this.TrafficAnalyticsInterval ?? 60
                    }
                };
            }

            return flowLogParameters;
        }
    }
}
