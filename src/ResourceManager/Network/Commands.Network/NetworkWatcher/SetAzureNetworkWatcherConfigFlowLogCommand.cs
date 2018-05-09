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
using Microsoft.Azure.Management.OperationalInsights;
using ResourceGroups.Tests;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmNetworkWatcherConfigFlowLog", SupportsShouldProcess = true, DefaultParameterSetName = SetByResourceWithTAByResource), OutputType(typeof(PSFlowLog))]
    public class SetAzureNetworkWatcherConfigFlowLogCommand : NetworkWatcherBaseCmdlet
    {
        private const string SetByResourceWithTAByResource = "SetByResourceWithTAByResource";
        private const string SetByResourceWithTAByDetails = "SetByResourceWithTAByDetails";
        private const string SetByResourceWithoutTA = "SetByResourceWithoutTA";
        private const string SetByNameWithTAByResource = "SetByNameWithTAByResource";
        private const string SetByNameWithTAByDetails = "SetByNameWithTAByDetails";
        private const string SetByNameWithoutTA = "SetByNameWithoutTA";

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
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetByResourceWithTAByResource)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetByResourceWithTAByDetails)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Flag to enable/disable retention.",
            ParameterSetName = SetByNameWithTAByResource)]
        [Parameter(
            Mandatory = true,
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The WS object which is used to store the traffic analytics data.",
            ParameterSetName = SetByNameWithTAByResource)]
        [ValidateNotNull]
        public Microsoft.Azure.Management.OperationalInsights.Models.Workspace Workspace { get; set; }

        public override void Execute()
        {
            base.Execute();
            string resourceGroupName;
            string name;

            if (ParameterSetName.Contains("SetByResource"))
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

                    if (this.EnableTrafficAnalytics == true || this.EnableTrafficAnalytics == false)
                    {
                        parameters.FlowAnalyticsConfiguration = new MNM.TrafficAnalyticsProperties();
                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration = new MNM.TrafficAnalyticsConfigurationProperties();

                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled = this.EnableTrafficAnalytics;

                        string[] workspaceDetailsComponents = this.WorkspaceResourceId.Split('/');
                        string worksapceResourceGroup = "", workspaceName = "";

                        //Expected format : /subscriptions/-WorkspaceSubscriptionId-/resourcegroups/-WorkspaceResourceGroup-/providers/microsoft.operationalinsights/workspaces/-this.WorkspaceName-
                        if (workspaceDetailsComponents.Length == 9)
                        {
                            worksapceResourceGroup = workspaceDetailsComponents[4];
                            workspaceName = workspaceDetailsComponents[8];

                        }
                        else
                        {
                            throw new System.ArgumentException("The given workspace resource id is not in format of: /subscriptions/-WorkspaceSubscriptionId-/resourcegroups/-WorkspaceResourceGroup-/providers/microsoft.operationalinsights/workspaces/-this.WorkspaceName-.");
                        }

                        if (Workspace == null)
                        {
                            if (this.WorkspaceResourceId == null || this.WorkspaceGUId == null || this.WorkspaceLocation == null)
                            {
                                throw new System.ArgumentException("Either the Workspace parameter or all of WorkspaceResourceId,WorkspaceGUId,WorkspaceLocation must be provided");
                            }
                        }
                        else
                        {
                            if (this.WorkspaceResourceId == null)
                            {
                                this.WorkspaceResourceId = this.Workspace.Id;
                            }
                            else if (this.WorkspaceResourceId != this.Workspace.Id)
                            {
                                throw new System.ArgumentException("The Workspace parameter and the WorkspaceResourceId poarameters are conflicting");
                            }

                            if (this.WorkspaceGUId == null)
                            {
                                this.WorkspaceGUId = this.Workspace.CustomerId;
                            }
                            else if (this.WorkspaceGUId != this.Workspace.CustomerId)
                            {
                                throw new System.ArgumentException("The Workspace parameter and the WorkspaceGUId poarameters are conflicting");
                            }

                            if (this.WorkspaceLocation == null)
                            {
                                this.WorkspaceLocation = this.Workspace.Location;
                            }
                            else if (this.WorkspaceLocation != this.Workspace.Location)
                            {
                                throw new System.ArgumentException("The Workspace parameter and the WorkspaceLocation poarameters are conflicting");
                            }
                        }

                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId = this.WorkspaceGUId;
                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion = this.WorkspaceLocation;
                        parameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId = this.WorkspaceResourceId;
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

        //public static OperationalInsightsManagementClient GetOperationalInsightsManagementClientWithHandler(MockContext context, RecordedDelegatingHandler handler)
        //{
        //    var client = context.GetServiceClient<OperationalInsightsManagementClient>(handlers: handler);
        //    return client;
        //}
    }
}
