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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Management.SignalR.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalR", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSSignalRResource))]
    [CmdletOutputBreakingChange(typeof(PSSignalRResource), DeprecatedOutputProperties = new String[] { nameof(PSSignalRResource.HostNamePrefix) })]
    public class UpdateAzureRmSignalR : SignalRCmdletBase, IWithInputObject, IWithResourceId
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
        [PSArgumentCompleter("Free_F1", "Standard_S1")]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SignalR service unit count, value only from {1, 2, 5, 10, 20, 50, 100}. Default to 1.")]
        [PSArgumentCompleter("1", "2", "5", "10", "20", "50", "100")]
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
                        this.LoadFromInputObject();
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
                if (ShouldProcess($"SignalR service {ResourceGroupName}/{Name}", "update"))
                {
                    var result = Client.SignalR.Update(signalR, ResourceGroupName, Name);
                    WriteObject(new PSSignalRResource(result));
                }
                else
                {
                    WriteWarning("Update-AzSignalR cmdlet was not run actually.");
                    WriteObject(new PSSignalRResource(signalR));
                }
            });
        }

        private void AddOrUpdateServiceMode(SignalRResource signalR, string ServiceMode)
        {
            signalR.Features = signalR.Features?.SkipWhile(f => f.Flag.Equals(ServiceMode)).ToList() ??
                new List<SignalRFeature>();
            signalR.Features.Add(new SignalRFeature(FeatureFlags.ServiceMode, ServiceMode));
        }
    }
}