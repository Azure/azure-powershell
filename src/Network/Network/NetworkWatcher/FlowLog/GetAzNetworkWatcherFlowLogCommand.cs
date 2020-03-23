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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherFlowLog", DefaultParameterSetName = "SetByName"), OutputType(typeof(PSFlowLogResource))]

    public class GetAzNetworkWatcherFlowLogCommand : FlowLogBaseCmdlet
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

        [Alias("FlowLogName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The flow log name.",
            ParameterSetName = "SetByName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The flow log name.",
            ParameterSetName = "SetByResource")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The flow log name.",
            ParameterSetName = "SetByLocation")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

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

            if (ShouldGetByName(this.ResourceGroupName, this.Name))
            {
                MNM.FlowLog flowLogResult = this.FlowLogs.Get(this.ResourceGroupName, this.NetworkWatcherName, this.Name);
                WriteObject(NetworkResourceManagerProfile.Mapper.Map<PSFlowLogResource>(flowLogResult));
            }
            else
            {
                var flowLogResults = this.FlowLogs.List(this.ResourceGroupName, this.NetworkWatcherName);

                List<PSFlowLogResource> flowLogs = new List<PSFlowLogResource>();
                foreach (var flowLogResult in flowLogResults)
                {
                    flowLogs.Add(NetworkResourceManagerProfile.Mapper.Map<PSFlowLogResource>(flowLogResult));
                }

                WriteObject(SubResourceWildcardFilter(this.Name, flowLogs), true);
            }
        }
    }
}
