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
using System;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherNetworkConfigurationDiagnostic", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSNetworkConfigurationDiagnosticResponse))]
    public class InvokeNetworkWatcherNetworkConfigurationDiagnosticCommand : NetworkWatcherBaseCmdlet
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of the target resource to perform network configuration diagnostic. Valid options are VM, NetworkInterface, VMSS/NetworkInterface and Application Gateway.")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Verbosity level. Accepted values are 'Normal', 'Minimum', 'Full'.")]
        [PSArgumentCompleter("Minimum", "Full", "Normal")]
        [ValidateNotNullOrEmpty]
        public string VerbosityLevel { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of network configuration diagnostic profiles.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkConfigurationDiagnosticProfile> Profile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            MNM.NetworkConfigurationDiagnosticParameters parameters = new MNM.NetworkConfigurationDiagnosticParameters();

            parameters.TargetResourceId = this.TargetResourceId;
            parameters.VerbosityLevel = this.VerbosityLevel;

            parameters.Profiles = new List<MNM.NetworkConfigurationDiagnosticProfile>();
            foreach (PSNetworkConfigurationDiagnosticProfile profile in this.Profile)
            {
                MNM.NetworkConfigurationDiagnosticProfile profileMNM = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkConfigurationDiagnosticProfile>(profile);
                parameters.Profiles.Add(profileMNM);
            }


            MNM.NetworkConfigurationDiagnosticResponse response = new MNM.NetworkConfigurationDiagnosticResponse();

            if (string.Equals(this.ParameterSetName, "SetByLocation", StringComparison.OrdinalIgnoreCase))
            {
                var networkWatcher = this.GetNetworkWatcherByLocation(this.Location);

                if (networkWatcher == null)
                {
                    throw new ArgumentException("There is no network watcher in location {0}", this.Location);
                }

                this.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                this.NetworkWatcherName = networkWatcher.Name;
            }
            else if (string.Equals(this.ParameterSetName, "SetByResource", StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.NetworkWatcher.ResourceGroupName;
                this.NetworkWatcherName = this.NetworkWatcher.Name;
            }
            else if (string.Equals(this.ParameterSetName, "SetByResourceId", StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.NetworkWatcherName = resourceInfo.ResourceName;
            }

            response = this.NetworkWatcherClient.GetNetworkConfigurationDiagnostic(this.ResourceGroupName, this.NetworkWatcherName, parameters);
            PSNetworkConfigurationDiagnosticResponse psResponse = NetworkResourceManagerProfile.Mapper.Map<PSNetworkConfigurationDiagnosticResponse>(response);

            WriteObject(psResponse);
        }
    }
}
