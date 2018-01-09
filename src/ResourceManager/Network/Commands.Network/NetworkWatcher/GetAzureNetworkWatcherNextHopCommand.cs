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
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmNetworkWatcherNextHop", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSNextHopResult))]

    public class GetAzureNetworkWatcherNextHopCommand : NetworkWatcherBaseCmdlet
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
            HelpMessage = "The target virtual machine ID.")]
        [ValidateNotNullOrEmpty]
        public string TargetVirtualMachineId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Destination IP address.")]
        [ValidateNotNullOrEmpty]
        public string DestinationIPAddress { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Source IP address.")]
        [ValidateNotNullOrEmpty]
        public string SourceIPAddress { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Target network interface Id.")]
        [ValidateNotNullOrEmpty]
        public string TargetNetworkInterfaceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            MNM.NextHopParameters parameters = new MNM.NextHopParameters();

            parameters.DestinationIPAddress= this.DestinationIPAddress;
            parameters.SourceIPAddress = this.SourceIPAddress;
            parameters.TargetNicResourceId = this.TargetNetworkInterfaceId;
            parameters.TargetResourceId = this.TargetVirtualMachineId;

            MNM.NextHopResult nextHop = new MNM.NextHopResult();

            if (ParameterSetName.Contains("SetByResource"))
            {
                nextHop = this.NetworkWatcherClient.GetNextHop(this.NetworkWatcher.ResourceGroupName, this.NetworkWatcher.Name, parameters);
            }
            else
            {
                nextHop = this.NetworkWatcherClient.GetNextHop(this.ResourceGroupName, this.NetworkWatcherName, parameters);
            }

            PSNextHopResult psNextHop = NetworkResourceManagerProfile.Mapper.Map<PSNextHopResult>(nextHop);

            WriteObject(psNextHop);
        }
    }
}
