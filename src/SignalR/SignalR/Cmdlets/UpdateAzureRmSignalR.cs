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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.SignalR.Models;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalR", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSSignalRResource))]
    public class UpdateAzureRmSignalR : SignalRCmdletBase, IWithSignalRInputObject, IWithResourceId
    {
        private const int DefaultUnitCount = 1;

        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSet,
            HelpMessage = "The resource group name. The default one will be used if not specified.")]
        [ValidateNotNullOrEmpty()]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 0,
            ParameterSetName = ResourceGroupParameterSet,
            HelpMessage = "The SignalR service name.")]
        [ValidateNotNullOrEmpty()]
        [ResourceNameCompleter(Constants.SignalRResourceType, nameof(ResourceGroupName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The SignalR service resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SignalR service SKU. Default to \"Standard_S1\".")]
        [PSArgumentCompleter("Free_F1", "Standard_S1", "Premium_P1", "Premium_P2")]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SignalR service unit count. Free_F1: 1; Standard_S1: 1,2,3,4,5,6,7,8,9,10,20,30,40,50,60,70,80,90,100; Premium_P1: 1,2,3,4,5,6,7,8,9,10,20,30,40,50,60,70,80,90,100; Premium_P2: 100,200,300,400,500,600,700,800,900,1000. Default to 1.")]
        [PSArgumentCompleter("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "200", "300", "400", "500", "600", "700", "800", "900", "1000")]
        public int? UnitCount { get; set; }

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
            HelpMessage = "Enable or disable system-assigned identity. $true enables system-assigned identity, $false disables it. If not provided, no change happens on system-assigned identity.")]
        public bool? EnableSystemAssignedIdentity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Set user-assigned identities. To remove all user-assigned identities, provide an empty array @(). If not provided, user-assigned identities remain unchanged.")]
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
                switch (ParameterSetName)
                {
                    case ResourceGroupParameterSet:
                        ResolveResourceGroupName();
                        break;
                    case ResourceIdParameterSet:
                        this.LoadFromResourceId();
                        break;
                    case InputObjectParameterSet:
                        this.LoadFromSignalRInputObject();
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }

                var signalR = Client.SignalR.Get(ResourceGroupName, Name);
                if (Sku != null)
                {
                    signalR.Sku = new ResourceSku(Sku, capacity: UnitCount ?? DefaultUnitCount);
                }
                if (UnitCount.HasValue)
                {
                    signalR.Sku.Capacity = UnitCount.Value;
                }
                if (Tag != null)
                {
                    signalR.Tags = Tag;
                }
                if (ServiceMode != null)
                {
                    AddOrUpdateServiceMode(signalR, ServiceMode);
                }
                if (AllowedOrigin != null)
                {
                    signalR.Cors = new SignalRCorsSettings(ParseAndCheckAllowedOrigins(AllowedOrigin));
                }

                // Update identity if parameters are provided
                if (EnableSystemAssignedIdentity.HasValue || UserAssignedIdentity != null)
                {
                    signalR.Identity = UpdateManagedIdentity(signalR.Identity);
                }

                if (ShouldProcess($"SignalR service {ResourceGroupName}/{Name}", "update"))
                {
                    var result = Client.SignalR.Update(ResourceGroupName, Name, signalR);
                    WriteObject(new PSSignalRResource(result));
                }
                else
                {
                    WriteWarning("Update-AzSignalR cmdlet was not run actually.");
                    WriteObject(new PSSignalRResource(signalR));
                }
            });
        }

        private ManagedIdentity UpdateManagedIdentity(ManagedIdentity currentIdentity)
        {
            var hasSystemAssignedIdentity = currentIdentity != null && currentIdentity.Type != null && currentIdentity.Type.Equals(ManagedIdentityType.SystemAssigned, StringComparison.OrdinalIgnoreCase);
            var hasUserAssignedIdentity = currentIdentity != null && currentIdentity.Type != null && currentIdentity.Type.Equals(ManagedIdentityType.UserAssigned, StringComparison.OrdinalIgnoreCase);

            // Update system assigned identity
            if (EnableSystemAssignedIdentity.HasValue)
            {
                hasSystemAssignedIdentity = EnableSystemAssignedIdentity.Value;
            }

            if (UserAssignedIdentity != null)
            {
                hasUserAssignedIdentity = UserAssignedIdentity.Length > 0;
            }

            if (hasSystemAssignedIdentity)
            {
                if (hasUserAssignedIdentity)
                {
                    throw new AzPSArgumentException("SignalR service doesn't support both system assigned and user assigned identities at the same time. Please specify either EnableSystemAssignedIdentity or UserAssignedIdentity, but not both.", $"{nameof(EnableSystemAssignedIdentity)}, {nameof(UserAssignedIdentity)}");
                }
                else
                {
                    if (currentIdentity?.Type == ManagedIdentityType.SystemAssigned)
                    {
                        // No change
                        return currentIdentity;
                    }
                    return new ManagedIdentity(type: ManagedIdentityType.SystemAssigned);
                }
            }
            else
            {
                if (hasUserAssignedIdentity)
                {
                    return new ManagedIdentity(type: ManagedIdentityType.UserAssigned, userAssignedIdentities: UserAssignedIdentity == null ? currentIdentity.UserAssignedIdentities : UserAssignedIdentity.ToDictionary(id => id, id => new UserAssignedIdentityProperty()));
                }
                else
                {
                    // Disable identity
                    return null;
                }
            }
        }

        private void AddOrUpdateServiceMode(SignalRResource signalR, string ServiceMode)
        {
            signalR.Features = signalR.Features?.SkipWhile(f => f.Flag.Equals(ServiceMode)).ToList() ??
                new List<SignalRFeature>();
            signalR.Features.Add(new SignalRFeature(FeatureFlags.ServiceMode, ServiceMode));
        }
    }
}