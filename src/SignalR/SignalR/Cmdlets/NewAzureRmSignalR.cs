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

<<<<<<< HEAD
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
=======
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.SignalR.Models;
using Newtonsoft.Json;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalR", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSignalRResource))]
    public sealed class NewAzureRmSignalR : SignalRCmdletBase
    {
        private const string DefaultSku = "Standard_S1";
<<<<<<< HEAD
=======
        private const int DefaultUnitCount = 1;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
            HelpMessage = "The SignalR service SKU.")]
        [PSArgumentCompleter("Free_F1", "Standard_S1")]
        public string Sku { get; set; } = DefaultSku;

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SignalR service unit count, from 1 to 10. Default to 1.")]
        [PSArgumentCompleter("1", "2", "3", "4", "5", "6", "7", "8", "9", "10")]
        [ValidateRange(1, 10)]
        public int UnitCount { get; set; } = 1;
=======
            HelpMessage = "The SignalR service SKU. Default to \"Standard_S1\".")]
        [PSArgumentCompleter("Free_F1", "Standard_S1")]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SignalR service unit count, value only from {1, 2, 5, 10, 20, 50, 100}. Default to 1.")]
        [PSArgumentCompleter("1", "2", "5", "10", "20", "50", "100")]
        public int UnitCount { get; set; } = DefaultUnitCount;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        [Parameter(
            Mandatory = false,
            HelpMessage = "The tags for the SignalR service.")]
        public IDictionary<string, string> Tag { get; set; }

        [Parameter(
            Mandatory = false,
<<<<<<< HEAD
=======
            HelpMessage = "The service mode for the SignalR service.")]
        [PSArgumentCompleter("Default", "Serverless", "Classic")]
        public string ServiceMode { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The allowed origins for the SignalR service. To allow all, use \"*\" and remove all other origins from the list. Slashes are not allowed as part of domain or after top-level domain")]
        public string[] AllowedOrigin { get; set; }

        [Parameter(
            Mandatory = false,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            HelpMessage = "Run the cmdlet in background job.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
<<<<<<< HEAD
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
=======
        {
            base.ExecuteCmdlet();

            RunCmdlet(() =>
            {
                ResolveResourceGroupName(required: false);
                ResourceGroupName = ResourceGroupName ?? Name;

                if (ShouldProcess($"SignalR service {ResourceGroupName}/{Name}", "new"))
                {
                    PromptParameter(nameof(ResourceGroupName), ResourceGroupName);
                    PromptParameter(nameof(Name), Name);

                    if (Location == null)
                    {
                        Location = GetLocationFromResourceGroup();
                        PromptParameter(nameof(Location), null, true, Location, "(from resource group location)");
                    }
                    else
                    {
                        PromptParameter(nameof(Location), Location);
                    }

                    PromptParameter(nameof(Sku), Sku, true, DefaultSku);
                    PromptParameter(nameof(UnitCount), UnitCount);
                    PromptParameter(nameof(Tag), Tag == null ? null : JsonConvert.SerializeObject(Tag));
                    PromptParameter(nameof(ServiceMode), ServiceMode);

                    IList<string> origins = ParseAndCheckAllowedOrigins(AllowedOrigin);
                    PromptParameter(nameof(AllowedOrigin), origins == null ? null : JsonConvert.SerializeObject(origins));

                    Sku = Sku ?? DefaultSku;

                    IList<SignalRFeature> features = ServiceMode == null ? null : new List<SignalRFeature> { new SignalRFeature(flag: FeatureFlags.ServiceMode, value: ServiceMode) };
                    SignalRCorsSettings cors = AllowedOrigin == null ? null : new SignalRCorsSettings(allowedOrigins: origins);

                    var parameters = new SignalRResource(
                        location: Location,
                        tags: Tag,
                        sku: new ResourceSku(name: Sku, capacity: UnitCount),
                        features: features,
                        cors: cors);

                    Client.SignalR.CreateOrUpdate(ResourceGroupName, Name, parameters);

                    var signalr = Client.SignalR.Get(ResourceGroupName, Name);
                    WriteObject(new PSSignalRResource(signalr));
                }
            });
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
