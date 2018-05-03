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
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmNetworkWatcher"), OutputType(typeof(PSNetworkWatcher))]

    public class GetAzureNetworkWatcherCommand : NetworkWatcherBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The network watcher name.",
             ParameterSetName = "Get")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource group name.",
             ParameterSetName = "List")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name.",
             ParameterSetName = "Get")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!string.IsNullOrEmpty(this.Name))
            {
                PSNetworkWatcher psNetworkWatcher;
                psNetworkWatcher = this.GetNetworkWatcher(this.ResourceGroupName, this.Name);

                WriteObject(psNetworkWatcher);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                var networkWatchersList = this.NetworkWatcherClient.List(this.ResourceGroupName);

                var psNetworkWatchers = new List<PSNetworkWatcher>();
                foreach (var networkWatcher in networkWatchersList)
                {
                    var psNetworkWatcher = this.ToPsNetworkWatcher(networkWatcher);
                    psNetworkWatcher.ResourceGroupName = this.ResourceGroupName;
                    psNetworkWatchers.Add(psNetworkWatcher);
                }

                WriteObject(psNetworkWatchers, true);
            }
            else
            {
                var networkWatchersList = this.NetworkWatcherClient.ListAll();

                var psNetworkWatchers = new List<PSNetworkWatcher>();
                foreach (var networkWatcher in networkWatchersList)
                {
                    var psNetworkWatcher = this.ToPsNetworkWatcher(networkWatcher);
                    psNetworkWatcher.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(networkWatcher.Id);
                    psNetworkWatchers.Add(psNetworkWatcher);
                }

                WriteObject(psNetworkWatchers, true);
            }
        }
    }
}
