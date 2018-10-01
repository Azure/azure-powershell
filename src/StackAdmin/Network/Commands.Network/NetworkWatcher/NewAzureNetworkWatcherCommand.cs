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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmNetworkWatcher", SupportsShouldProcess = true),
        OutputType(typeof(PSNetworkWatcher))]
    public class NewAzureNetworkWatcherCommand : NetworkWatcherBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network watcher name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Location.")]
        [LocationCompleter("Microsoft.Network/networkWatchers")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsNetworkWatcherPresent(this.ResourceGroupName, this.Name);

            if (!present)
            {
                ConfirmAction(
                    Properties.Resources.CreatingResourceMessage,
                    this.Name,
                    () =>
                    {
                        var networkWatcher = CreateNetworkWatcher();
                        WriteObject(networkWatcher);
                    });
            }
        }

        private PSNetworkWatcher CreateNetworkWatcher()
        {
            var networkWatcher = new PSNetworkWatcher();
            networkWatcher.Name = this.Name;
            networkWatcher.ResourceGroupName = this.ResourceGroupName;
            networkWatcher.Location = this.Location;
            networkWatcher.Tag = this.Tag;

            // Map to the sdk object
            var networkWatcherModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkWatcher>(networkWatcher);
            MNM.NetworkWatcher networkWatcherPropertiesModel = new MNM.NetworkWatcher();
            networkWatcherPropertiesModel.Location = networkWatcher.Location;
            networkWatcherPropertiesModel.Tags = TagsConversionHelper.CreateTagDictionary(networkWatcher.Tag, validate: true);

            // Execute the Create NetworkWatcher call
            this.NetworkWatcherClient.CreateOrUpdate(this.ResourceGroupName, this.Name, networkWatcherPropertiesModel);

            var getNetworkWatcher = this.GetNetworkWatcher(this.ResourceGroupName, this.Name);

            return getNetworkWatcher;
        }
    }
}
