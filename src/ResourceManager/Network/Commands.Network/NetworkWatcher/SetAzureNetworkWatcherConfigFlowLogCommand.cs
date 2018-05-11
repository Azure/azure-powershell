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
using COM = Microsoft.Azure.Commands.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmNetworkWatcherConfigFlowLog", SupportsShouldProcess = true, DefaultParameterSetName = SetByResourceWithoutTA), OutputType(typeof(PSFlowLog))]
    public class SetAzureNetworkWatcherConfigFlowLogCommand : NetworkWatcherBaseCmdlet
    {
        private const string SetByResourceWithTAByResource = "SetByResourceWithTAByResource";
        private const string SetByResourceWithTAByDetails = "SetByResourceWithTAByDetails";
        private const string SetByResourceWithoutTA = "SetByResourceWithoutTA";
        private const string SetByNameWithTAByResource = "SetByNameWithTAByResource";
        private const string SetByNameWithTAByDetails = "SetByNameWithTAByDetails";
        private const string SetByNameWithoutTA = "SetByNameWithoutTA";
        private const string SetByResource = "SetByResource";
        private const string WithTA = "WithTA";
        private const string TAByDetails = "TAByDetails";

        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = SetByResourceWithTAByResource)]
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = SetByResourceWithTAByDetails)]
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = SetByResourceWithoutTA)]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = SetByNameWithTAByResource)]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = SetByNameWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = SetByNameWithoutTA)]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = SetByNameWithTAByResource)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = SetByNameWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = SetByNameWithoutTA)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Alias("EnableTA")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetByResourceWithTAByResource)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetByResourceWithTAByDetails)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetByNameWithTAByResource)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetByNameWithTAByDetails)]
        [ValidateNotNull]
        public SwitchParameter EnableTrafficAnalytics { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subscription of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetByResourceWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Subscription of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetByNameWithTAByDetails)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceResourceId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "GUID of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetByResourceWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "GUID of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetByNameWithTAByDetails)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceGUId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure Region of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetByResourceWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure Region of the WS which is used to store the traffic analytics data.",
            ParameterSetName = SetByNameWithTAByDetails)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceLocation { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The WS object which is used to store the traffic analytics data.",
            ParameterSetName = SetByResourceWithTAByResource)]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The WS object which is used to store the traffic analytics data.",
            ParameterSetName = SetByNameWithTAByResource)]
        [ValidateNotNull]
        public COM.PSWorkspace Workspace { get; set; }

        public override void Execute()
        {
            base.Execute();
            string resourceGroupName;
            string name;
            string WorkspaceResourceId;
            string WorkspaceGUId;
            string WorkspaceLocation;

            if (ParameterSetName.Contains(SetByResource))
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

                    if (ParameterSetName.Contains(WithTA))
                    {
                        parameters.FlowAnalyticsConfiguration = new MNM.TrafficAnalyticsProperties();
                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration = new MNM.TrafficAnalyticsConfigurationProperties();

                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled = this.EnableTrafficAnalytics.IsPresent;

                        

                        if (ParameterSetName.Contains(TAByDetails))
                        {
                            if (this.WorkspaceResourceId == null || this.WorkspaceGUId == null || this.WorkspaceLocation == null)
                            {
                                throw new System.ArgumentException("Either the Workspace parameter or all of WorkspaceResourceId,WorkspaceGUId,WorkspaceLocation must be provided");
                            }

                            string[] workspaceDetailsComponents = this.WorkspaceResourceId.Split('/');

                            //Expected format : /subscriptions/-WorkspaceSubscriptionId-/resourcegroups/-WorkspaceResourceGroup-/providers/microsoft.operationalinsights/workspaces/-this.WorkspaceName-
                            if (workspaceDetailsComponents.Length != 9)
                            {
                                throw new System.ArgumentException("The given workspace resource id is not in format of: /subscriptions/-WorkspaceSubscriptionId-/resourcegroups/-WorkspaceResourceGroup-/providers/microsoft.operationalinsights/workspaces/-this.WorkspaceName-.");
                            }

                            WorkspaceResourceId = this.WorkspaceResourceId;
                            WorkspaceGUId = this.WorkspaceGUId;
                            WorkspaceLocation = this.WorkspaceLocation;
                        }
                        else
                        {
                            if (this.Workspace == null)
                            {
                                throw new System.ArgumentException("Either the Workspace parameter or all of WorkspaceResourceId,WorkspaceGUId,WorkspaceLocation must be provided");
                            }

                            WorkspaceResourceId = this.Workspace.ResourceId;
                            WorkspaceGUId = this.Workspace.CustomerId.ToString();
                            WorkspaceLocation = this.Workspace.Location;

                        }

                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId = WorkspaceResourceId;
                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId = WorkspaceGUId;
                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion = WorkspaceLocation;                        
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
