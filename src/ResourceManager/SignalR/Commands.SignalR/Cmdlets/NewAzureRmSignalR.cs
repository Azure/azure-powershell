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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Strategies;
using Microsoft.Azure.Management.SignalR.Models;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.SignalR.Strategies.ResourceManager;
using Microsoft.Azure.Commands.SignalR.Strategies.SignalRRp;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalR", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSignalRResource))]
    public sealed class NewAzureRmSignalR : SignalRCmdletBase
    {
        private const string DefaultSku = "Basic_DS2";

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource group name. The default one will be used if not specified.")]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 0,
            HelpMessage = "The SignalR service name.")]
        [ValidateNotNullOrEmpty()]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SignalR service location. The resource group location will be used if not specified.")]
        [LocationCompleter("Microsoft.SignalR/SignalR")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SignalR service SKU.")]
        [PSArgumentCompleter("Free_DS2", "Basic_DS2")]
        public string Sku { get; set; } = DefaultSku;

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SignalR service unit count, from 1 to 10. Default to 1.")]
        [PSArgumentCompleter("1", "2", "3", "4", "5", "6", "7", "8", "9", "10")]
        [ValidateRange(1, 10)]
        public int UnitCount { get; set; } = 1;

        [Parameter(
            Mandatory = false,
            HelpMessage = "The tags for the SignalR service.")]
        public IDictionary<string, string> Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run the cmdlet in background job.")]
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

            public string DefaultLocation => "eastus";

            readonly NewAzureRmSignalR _cmdlet;

            public Parameters(NewAzureRmSignalR cmdlet)
            {
                _cmdlet = cmdlet;
            }

            public Task<ResourceConfig<SignalRResource>> CreateConfigAsync()
            {
                _cmdlet.ResolveResourceGroupName(required: false);
                _cmdlet.ResourceGroupName = _cmdlet.ResourceGroupName ?? _cmdlet.Name;

                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(
                    _cmdlet.ResourceGroupName);

                var result = SignalRStrategy.Strategy.CreateResourceConfig(
                    resourceGroup: resourceGroup,
                    name: _cmdlet.Name,
                    createModel: engine => new SignalRResource(
                        tags: _cmdlet.Tag,
                        sku: new ResourceSku(_cmdlet.Sku, capacity: _cmdlet.UnitCount),
                        hostNamePrefix: null /* _cmdlet.Name*/)); // hostNamePrefix is just a placeholder and ignored in the resource provider.

                return Task.FromResult(result);
            }
        }

        async Task SimpleExecuteCmdlet(IAsyncCmdlet asyncCmdlet)
        {
            var client = new Client(DefaultProfile.DefaultContext);

            var parameters = new Parameters(this);

            var result = await client.RunAsync(
                client.SubscriptionId, parameters, asyncCmdlet);

            if (result != null)
            {
                var psResult = new PSSignalRResource(result);
                asyncCmdlet.WriteObject(psResult);
            }
        }
    }
}
