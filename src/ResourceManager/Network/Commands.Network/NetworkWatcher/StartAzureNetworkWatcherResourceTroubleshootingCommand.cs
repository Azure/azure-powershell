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
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsLifecycle.Start, "AzureRmNetworkWatcherResourceTroubleshooting", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSTroubleshootingResult))]

    public class StartAzureNetworkWatcherResourceTroubleshootingCommand : NetworkWatcherBaseCmdlet
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
            HelpMessage = "Location of the network watcher.",
            ParameterSetName = "SetByLocation")]
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
            HelpMessage = "The storage ID.")]
        [ValidateNotNullOrEmpty]
        public string StorageId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage path.")]
        [ValidateNotNullOrEmpty]
        public string StoragePath { get; set; }

        public override void Execute()
        {
            base.Execute();
            MNM.TroubleshootingParameters parameters = new MNM.TroubleshootingParameters();
            parameters.TargetResourceId = this.TargetResourceId;
            parameters.StorageId = this.StorageId;
            parameters.StoragePath = this.StoragePath;

            PSTroubleshootingResult troubleshoot = new PSTroubleshootingResult();
            if (string.Equals(this.ParameterSetName, "SetByLocation", StringComparison.OrdinalIgnoreCase))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new ArgumentException("There is no network watcher in location {0}", this.Location);
                }

                this.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                this.NetworkWatcherName = networkWatcher.Name;
                troubleshoot = GetTroubleshooting(this.ResourceGroupName, this.NetworkWatcherName, parameters);
            }
            else if (string.Equals(this.ParameterSetName, "SetByResource", StringComparison.OrdinalIgnoreCase))
            {
                troubleshoot = GetTroubleshooting(this.NetworkWatcher.ResourceGroupName, this.NetworkWatcher.Name, parameters);
            }
            else
            {
                troubleshoot = GetTroubleshooting(this.ResourceGroupName, this.NetworkWatcherName, parameters);
            }
            WriteObject(troubleshoot);
        }

        public PSTroubleshootingResult GetTroubleshooting(string resourceGroupName, string name, MNM.TroubleshootingParameters parameters, string expandResource = null)
        {
            MNM.TroubleshootingResult troubleshoot = this.NetworkWatcherClient.GetTroubleshooting(resourceGroupName, name, parameters);

            PSTroubleshootingResult psTroubleshoot = NetworkResourceManagerProfile.Mapper.Map<PSTroubleshootingResult>(troubleshoot);
            return psTroubleshoot;
        }
    }
}
