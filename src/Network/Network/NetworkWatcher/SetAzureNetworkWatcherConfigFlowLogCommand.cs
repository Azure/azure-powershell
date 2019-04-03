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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Net;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Internal.Network.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConfigFlowLog", SupportsShouldProcess = true, DefaultParameterSetName = SetFlowlogByResourceWithoutTA), OutputType(typeof(PSFlowLog))]
    public class SetAzureNetworkWatcherConfigFlowLogCommand : NetworkWatcherBaseCmdlet
    {
        private const string SetFlowlogByResourceWithTAByResource = "SetFlowlogByResourceWithTAByResource";
        private const string SetFlowlogByResourceWithTAByDetails = "SetFlowlogByResourceWithTAByDetails";
        private const string SetFlowlogByResourceWithoutTA = "SetFlowlogByResourceWithoutTA";
        private const string SetFlowlogByNameWithTAByResource = "SetFlowlogByNameWithTAByResource";
        private const string SetFlowlogByNameWithTAByDetails = "SetFlowlogByNameWithTAByDetails";
        private const string SetFlowlogByNameWithoutTA = "SetFlowlogByNameWithoutTA";
        private const string SetFlowlogByLocationWithTAByResource = "SetFlowlogByLocationWithTAByResource";
        private const string SetFlowlogByLocationWithTAByDetails = "SetFlowlogByLocationWithTAByDetails";
        private const string SetFlowlogByLocationWithoutTA = "SetFlowlogByLocationWithoutTA";
        private const string SetFlowlogByResource = "SetFlowlogByResource";
        private const string SetFlowlogByLocation = "SetFlowlogByLocation";
        private const string WithTA = "WithTA";
        private const string TAByDetails = "TAByDetails";

        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = SetFlowlogByResourceWithTAByResource)]
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = SetFlowlogByResourceWithTAByDetails)]
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = SetFlowlogByResourceWithoutTA)]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = SetFlowlogByNameWithTAByResource)]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = SetFlowlogByNameWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = SetFlowlogByNameWithoutTA)]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = SetFlowlogByNameWithTAByResource)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = SetFlowlogByNameWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = SetFlowlogByNameWithoutTA)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = SetFlowlogByLocationWithTAByResource)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = SetFlowlogByLocationWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = SetFlowlogByLocationWithoutTA)]
        [LocationCompleter("Microsoft.Network/networkWatchers")]
        [ValidateNotNull]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target resource ID.")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Flag to enable/disable flow logging.")]
        [ValidateNotNullOrEmpty]
        public bool EnableFlowLog { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ID of the storage account which is used to store the flow log.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Flag to enable/disable retention.")]
        [ValidateNotNull]
        public bool EnableRetention { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Number of days to retain flow log records.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int RetentionInDays { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Type of flow log format.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Json")]
        public string FormatType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Version of flow log format.")]
        [ValidateRange(1, int.MaxValue)]
        public int? FormatVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Alias("EnableTA")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetFlowlogByResourceWithTAByResource)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetFlowlogByResourceWithTAByDetails)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetFlowlogByNameWithTAByResource)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetFlowlogByNameWithTAByDetails)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetFlowlogByLocationWithTAByResource)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetFlowlogByLocationWithTAByDetails)]
        [ValidateNotNull]
        public SwitchParameter EnableTrafficAnalytics { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subscription of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByResourceWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subscription of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByNameWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subscription of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByLocationWithTAByDetails)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceResourceId { get; set; }
        
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "GUID of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByResourceWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "GUID of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByNameWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subscription of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByLocationWithTAByDetails)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceGUID { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure Region of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByResourceWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure Region of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByNameWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subscription of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByLocationWithTAByDetails)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceLocation { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The WS object which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByResourceWithTAByResource)]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The WS object which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByNameWithTAByResource)]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The WS object which is used to store the traffic analytics data.",
            ParameterSetName = SetFlowlogByLocationWithTAByResource)]
        [ValidateNotNull]
        public IOperationalInsightWorkspace Workspace { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the interval (in minutes) which would decide how frequently TA service should do flow analytics.",
            ParameterSetName = SetFlowlogByResourceWithTAByResource)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the interval (in minutes) which would decide how frequently TA service should do flow analytics.",
            ParameterSetName = SetFlowlogByResourceWithTAByDetails)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the interval (in minutes) which would decide how frequently TA service should do flow analytics.",
            ParameterSetName = SetFlowlogByNameWithTAByResource)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the interval (in minutes) which would decide how frequently TA service should do flow analytics.",
            ParameterSetName = SetFlowlogByNameWithTAByDetails)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the interval (in minutes) which would decide how frequently TA service should do flow analytics.",
            ParameterSetName = SetFlowlogByLocationWithTAByResource)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the interval (in minutes) which would decide how frequently TA service should do flow analytics.",
            ParameterSetName = SetFlowlogByLocationWithTAByDetails)]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int TrafficAnalyticsInterval { get; set; }

        public override void Execute()
        {
            base.Execute();
            string resourceGroupName;
            string name;
            string WorkspaceResourceId;
            string WorkspaceGUID;
            string WorkspaceLocation;


            if (ParameterSetName.Contains(SetFlowlogByLocation))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new System.ArgumentException("There is no network watcher in location {0}", this.Location);
                }

                resourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                name = networkWatcher.Name;
            }
            else if (ParameterSetName.Contains(SetFlowlogByResource))
            {
                resourceGroupName = this.NetworkWatcher.ResourceGroupName;
                name = this.NetworkWatcher.Name;
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                name = this.NetworkWatcherName;
            }

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                "FlowLogConfig",
                () =>
                {
                    MNM.FlowLogInformation parameters = new MNM.FlowLogInformation();
                    parameters.TargetResourceId = this.TargetResourceId;
                    parameters.Enabled = this.EnableFlowLog;
                    parameters.StorageId = this.StorageAccountId;

                    if (this.EnableRetention == true || this.EnableRetention == false)
                    {
                        parameters.RetentionPolicy = new MNM.RetentionPolicyParameters();
                        parameters.RetentionPolicy.Enabled = this.EnableRetention;
                        parameters.RetentionPolicy.Days = this.RetentionInDays;
                    }

                    if (!string.IsNullOrWhiteSpace(this.FormatType) || this.FormatVersion != null)
                    {
                        parameters.Format = new MNM.FlowLogFormatParameters();

                        parameters.Format.Type = this.FormatType;
                        if (string.IsNullOrWhiteSpace(parameters.Format.Type))
                        {
                            parameters.Format.Type = "Json";
                        }

                        parameters.Format.Version = this.FormatVersion;
                        if (parameters.Format.Version == null)
                        {
                            parameters.Format.Version = 0;
                        }
                    }

                    if (ParameterSetName.Contains(WithTA))
                    {
                        parameters.FlowAnalyticsConfiguration = new MNM.TrafficAnalyticsProperties();
                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration = new MNM.TrafficAnalyticsConfigurationProperties();

                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled = this.EnableTrafficAnalytics.IsPresent;

                        if (ParameterSetName.Contains(TAByDetails))
                        {
                            string[] workspaceDetailsComponents = this.WorkspaceResourceId.Split('/');

                            //Expected format : /subscriptions/-WorkspaceSubscriptionId-/resourcegroups/-WorkspaceResourceGroup-/providers/microsoft.operationalinsights/workspaces/-this.WorkspaceName-
                            if (workspaceDetailsComponents.Length != 9)
                            {
                                throw new System.ArgumentException("The given workspace resource id is not in format of: /subscriptions/-WorkspaceSubscriptionId-/resourcegroups/-WorkspaceResourceGroup-/providers/microsoft.operationalinsights/workspaces/-this.WorkspaceName-.");
                            }

                            WorkspaceResourceId = this.WorkspaceResourceId;
                            WorkspaceGUID = this.WorkspaceGUID;
                            WorkspaceLocation = this.WorkspaceLocation;
                        }
                        else
                        {

                            WorkspaceResourceId = this.Workspace.ResourceId;
                            WorkspaceGUID = this.Workspace.CustomerId.ToString();
                            WorkspaceLocation = this.Workspace.Location;

                        }

                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId = WorkspaceResourceId;
                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId = WorkspaceGUID;
                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion = WorkspaceLocation;
                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.TrafficAnalyticsInterval = TrafficAnalyticsInterval;
                    }

                    PSFlowLog flowLog = new PSFlowLog();
                    flowLog = SetFlowLogConfig(resourceGroupName, name, parameters);

                    WriteObject(flowLog);
                });
        }
        public PSFlowLog SetFlowLogConfig(string resourceGroupName, string name, MNM.FlowLogInformation parameters)
        {
            MNM.FlowLogInformation flowLog = this.NetworkWatcherClient.SetFlowLogConfiguration(resourceGroupName, name, parameters);
            PSFlowLog psFlowLog = NetworkResourceManagerProfile.Mapper.Map<PSFlowLog>(flowLog);

            return psFlowLog;
        }

    }
}
