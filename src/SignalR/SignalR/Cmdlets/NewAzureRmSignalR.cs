﻿// ----------------------------------------------------------------------------------
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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.SignalR.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalR", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSignalRResource))]
    public sealed class NewAzureRmSignalR : SignalRCmdletBase
    {
        private const string DefaultSku = "Standard_S1";
        private const int DefaultUnitCount = 1;

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource group name. The default one will be used if not specified.")]
        [ValidateNotNullOrEmpty()]
        [ResourceGroupCompleter]
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
            HelpMessage = "The SignalR service SKU. Default to \"Standard_S1\".")]
        [PSArgumentCompleter("Free_F1", "Standard_S1")]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SignalR service unit count. Free_F1: 1; Standard_S1: 1,2,3,4,5,6,7,8,9,10,20,30,40,50,60,70,80,90,100; Premium_P1: 1,2,3,4,5,6,7,8,9,10,20,30,40,50,60,70,80,90,100; Premium_P2: 100,200,300,400,500,600,700,800,900,1000. Default to 1.")]
        [PSArgumentCompleter("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "200", "300", "400", "500", "600", "700", "800", "900", "1000")]
        public int UnitCount { get; set; } = DefaultUnitCount;

        [Parameter(
            Mandatory = false,
            HelpMessage = "The tags for the SignalR service.")]
        public IDictionary<string, string> Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The service mode for the SignalR service.")]
        [PSArgumentCompleter("Default", "Serverless", "Classic")]
        public string ServiceMode { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The allowed origins for the SignalR service. To allow all, use \"*\" and remove all other origins from the list. Slashes are not allowed as part of domain or after top-level domain")]
        public string[] AllowedOrigin { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable system-assigned identity for the SignalR service.")]
        public SwitchParameter EnableSystemAssignedIdentity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource IDs of user-assigned identities to assign to the SignalR service.")]
        public string[] UserAssignedIdentity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run the cmdlet in background job.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
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
                    ManagedIdentity identity = CreateManagedIdentity();

                    var parameters = new SignalRResource(
                        location: Location,
                        tags: Tag,
                        sku: new ResourceSku(name: Sku, capacity: UnitCount),
                        features: features,
                        cors: cors,
                        identity: identity);

                    Client.SignalR.CreateOrUpdate(ResourceGroupName, Name, parameters);

                    var signalr = Client.SignalR.Get(ResourceGroupName, Name);
                    WriteObject(new PSSignalRResource(signalr));
                }
            });
        }

        private ManagedIdentity CreateManagedIdentity()
        {
            if (!EnableSystemAssignedIdentity.IsPresent && (UserAssignedIdentity == null || UserAssignedIdentity.Length == 0))
            {
                return null;
            }

            // SignalR doesn't support both system assigned and user assigned identities at the same time
            if (EnableSystemAssignedIdentity.IsPresent && UserAssignedIdentity != null && UserAssignedIdentity.Length > 0)
            {
                throw new AzPSArgumentException("SignalR service doesn't support both system assigned and user assigned identities at the same time. Please specify either EnableSystemAssignedIdentity or UserAssignedIdentity, but not both.", $"{nameof(EnableSystemAssignedIdentity)}, {nameof(UserAssignedIdentity)}");
            }

            string identityType;
            IDictionary<string, UserAssignedIdentityProperty> userAssignedIdentities = null;

            if (EnableSystemAssignedIdentity.IsPresent)
            {
                identityType = ManagedIdentityType.SystemAssigned;
            }
            else if (UserAssignedIdentity != null && UserAssignedIdentity.Length > 0)
            {
                identityType = ManagedIdentityType.UserAssigned;
                userAssignedIdentities = new Dictionary<string, UserAssignedIdentityProperty>();
                foreach (var identityId in UserAssignedIdentity)
                {
                    userAssignedIdentities[identityId] = new UserAssignedIdentityProperty();
                }
            }
            else
            {
                identityType = ManagedIdentityType.None;
            }

            return new ManagedIdentity(type: identityType, userAssignedIdentities: userAssignedIdentities);
        }
    }
}