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
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmNetworkWatcherConfigFlowLog", SupportsShouldProcess = true, DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSFlowLog))]
    public class SetAzureNetworkWatcherConfigFlowLogCommand : NetworkWatcherBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByName")]
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
