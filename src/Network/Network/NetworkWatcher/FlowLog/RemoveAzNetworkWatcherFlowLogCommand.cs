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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherFlowLog", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"), OutputType(typeof(bool))]
    public class RemoveAzNetworkWatcherFlowLogCommand : FlowLogBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ResourceNameCompleter("Microsoft.Network/networkWatchers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByName")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = "SetByLocation")]
        [LocationCompleter("Microsoft.Network/networkWatchers")]
        [ValidateNotNull]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource ID.",
            ParameterSetName = "SetByResourceId")]
        [ValidateNotNull]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Flow log object.",
            ParameterSetName = "SetByInputObject")]
        [ValidateNotNull]
        public PSFlowLogResource InputObject { get; set; }

        [Alias("FlowLogName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The flow log name.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The flow log name.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The flow log name.",
            ParameterSetName = "SetByLocation")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Contains("SetByResourceId"))
            {
                ResourceIdentifier flowLogInfo = new ResourceIdentifier(this.ResourceId);

                this.Name = flowLogInfo.ResourceName;
                this.ResourceGroupName = flowLogInfo.ResourceGroupName;

                string parent = flowLogInfo.ParentResource;
                string[] tokens = parent.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                this.NetworkWatcherName = tokens[1];
            }
            else if (ParameterSetName.Contains("SetByResource"))
            {
                this.ResourceGroupName = this.NetworkWatcher.ResourceGroupName;
                this.NetworkWatcherName = this.NetworkWatcher.Name;
            }
            else if (ParameterSetName.Contains("SetByLocation"))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new PSArgumentException(Properties.Resources.NoNetworkWatcherFound);
                }

                this.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                this.NetworkWatcherName = networkWatcher.Name;
            }
            else if (ParameterSetName.Contains("SetByInputObject"))
            {
                ResourceIdentifier flowLogInfo = new ResourceIdentifier(this.InputObject.Id);

                this.Name = flowLogInfo.ResourceName;
                this.ResourceGroupName = flowLogInfo.ResourceGroupName;

                string parent = flowLogInfo.ParentResource;
                string[] tokens = parent.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                this.NetworkWatcherName = tokens[1];
            }

            ConfirmAction(
            Properties.Resources.RemoveResourceMessage,
            this.Name,
            () =>
            {
                try
                {
                    this.FlowLogs.Delete(this.ResourceGroupName, this.NetworkWatcherName, this.Name);
                    WriteObject(true);
                }
                catch (Exception ex)
                {
                    WriteObject(false);
                    throw ex;
                }
                if (PassThru)
                {
                    WriteObject("PassThru: " + true);
                }
            });
        }
    }
}
