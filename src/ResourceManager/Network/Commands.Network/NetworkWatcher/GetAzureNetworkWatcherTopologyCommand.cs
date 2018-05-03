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
    [Cmdlet(VerbsCommon.Get, "AzureRmNetworkWatcherTopology", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSTopology))]

    public class GetAzureNetworkWatcherTopologyCommand : NetworkWatcherBaseCmdlet
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
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();
            MNM.TopologyParameters parameters = new MNM.TopologyParameters();
            parameters.TargetResourceGroupName = this.TargetResourceGroupName;

            PSTopology topology = new PSTopology();

            if (ParameterSetName.Contains("SetByResource"))
            {
                topology = GetTopology(this.NetworkWatcher.ResourceGroupName, this.NetworkWatcher.Name, parameters);
            }
            else
            {
                topology = GetTopology(this.ResourceGroupName, this.NetworkWatcherName, parameters);
            }
            WriteObject(topology);
        }

        public PSTopology GetTopology(string resourceGroupName, string name, MNM.TopologyParameters parameters)
        {
            MNM.Topology topology = this.NetworkWatcherClient.GetTopology(resourceGroupName, name, parameters);
            PSTopology psTopology = NetworkResourceManagerProfile.Mapper.Map<PSTopology>(topology);

            return psTopology;
        }
    }
}
