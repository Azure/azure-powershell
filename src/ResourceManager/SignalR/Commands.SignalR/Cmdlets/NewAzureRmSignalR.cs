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

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Strategies;
using Microsoft.Azure.Management.SignalR.Models;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Commands.SignalR.Strategies.ResourceManager;
using System.Threading;
using Microsoft.Azure.Commands.SignalR.Strategies.SignalRRp;

namespace Microsoft.Azure.Commands.SignalR
{
    [Cmdlet(VerbsCommon.New, "AzureRmSignalR", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSignalRResource))]
    public sealed class NewAzureRmSignalR : AzureRMCmdlet
    {
        /// <summary>
        /// TODO: smart command with default resource group name
        /// </summary>
        [Parameter(
            Mandatory = false,
            Position = 0)]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1)]
        [ValidateNotNullOrEmpty()]
        public string Name { get; set; }

        /// <summary>
        /// TODO: smart command with default location based on ResourceGroupName
        /// </summary>
        [Parameter(
            Mandatory = false,
            Position = 2)]
        [LocationCompleter("Microsoft.SignalR/signalRs")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        /// <summary>
        /// TODO:
        /// - Assign default value.
        /// - validation set or tab completion
        /// </summary>
        [Parameter(Mandatory = false)]
        public string Sku { get; set; }

        /// <summary>
        /// TODO:
        /// - Default host name prefix. 
        /// - alias `DomainNameLabel`
        /// </summary>
        [Parameter(Mandatory = false)]
        public string HostNamePrefix { get; set; }

        [Parameter(Mandatory = false)]
        public IDictionary<string, string> Tag { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
            => this.StartAndWait(SimpleExecuteCmdlet);

        sealed class Parameters : IParameters<SignalRResource>
        {
            public string Location
            {
                get
                {
                    return _cmdlet.Location;
                }

                set
                {
                    _cmdlet.Location = value;
                }
            }

            readonly NewAzureRmSignalR _cmdlet;

            public Parameters(NewAzureRmSignalR cmdlet)
            {
                _cmdlet = cmdlet;
            }

            public async Task<ResourceConfig<SignalRResource>> CreateConfigAsync()
            {
                _cmdlet.ResourceGroupName = _cmdlet.ResourceGroupName ?? _cmdlet.Name;
                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);
                return SignalRStrategy.Strategy.CreateResourceConfig(
                    resourceGroup: resourceGroup,
                    name: _cmdlet.Name,
                    createModel: engine =>
                    new SignalRResource(
                        tags: _cmdlet.Tag,
                        signalrsku: new ResourceSku(_cmdlet.Sku),
                        hostNamePrefix: _cmdlet.HostNamePrefix));
            }
        }

        async Task SimpleExecuteCmdlet(IAsyncCmdlet asyncCmdlet)
        {
            var client = new Client(DefaultProfile.DefaultContext);

            var parameters = new Parameters(this);

            var result = await client.RunAsync(
                client.SubscriptionId, parameters, asyncCmdlet, new CancellationToken());

            if (result != null)
            {
                var psResult = new PSSignalRResource(result);
                asyncCmdlet.WriteObject(psResult);
            }
        }
    }
}
