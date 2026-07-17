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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;
using Azure.Core;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalRReplica", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSReplicaResource))]
    public class UpdateAzureRmSignalRReplica : SignalRCmdletBase, ISignalRChildResource
    {
        [Parameter(Mandatory = false, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The SignalR service name.")]
        [ResourceNameCompleter(Constants.SignalRResourceType, nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty()]
        public string SignalRName { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The replica name.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SignalRObjectParameterSet, HelpMessage = "The replica name.")]
        [ValidateNotNullOrEmpty()]
        [ResourceNameCompleter(Constants.SignalRReplicaResourceType, nameof(ResourceGroupName), nameof(SignalRName))]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The SignalR replica resource object.")]
        [ValidateNotNull]
        public PSReplicaResource InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SignalRObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource SignalRObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The resource ID of the replica.", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty()]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The SignalR replica service SKU.")]
        [PSArgumentCompleter("Premium_P1", "Premium_P2")]
        public string Sku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The SignalR replica unit count. For Premium_P1: 1,2,3,4,5,6,7,8,9,10,20,30,40,50,60,70,80,90,100. Default to 1. For Premium_P2: 100,200,300,400,500,600,700,800,900,1000")]
        [PSArgumentCompleter("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "200", "300", "400", "500", "600", "700", "800", "900", "1000")]
        public int? UnitCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable or disable the regional endpoint. Valid values are 'Enabled' and 'Disabled'.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string RegionEndpointEnabled { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The tags for the SignalR replica.")]
        public IDictionary<string, string> Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run the cmdlet in background job.")]
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
                        this.LoadFromChildResourceId(ResourceId, Constants.SignalRReplicaResourceType);
                        break;
                    case SignalRObjectParameterSet:
                        var signalRResourceId = new ResourceIdentifier(SignalRObject.Id);
                        ResourceGroupName = signalRResourceId.ResourceGroupName;
                        SignalRName = signalRResourceId.Name;
                        break;
                    case InputObjectParameterSet:
                        this.LoadFromChildResourceId(InputObject.Id, Constants.SignalRReplicaResourceType);
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }

                if (ShouldProcess($"SignalR replica {ResourceGroupName}/{SignalRName}/{Name}", "update"))
                {
                    // Get the current replica to preserve existing properties
                    var replica = Microsoft.Azure.Management.SignalR.SignalRReplicasOperationsExtensions.Get(Client.SignalRReplicas, ResourceGroupName, SignalRName, Name);

                    if (Sku != null)
                    {
                        replica.Sku.Name = Sku;
                    }
                    if (UnitCount != null)
                    {
                        replica.Sku.Capacity = UnitCount;
                    }

                    replica.RegionEndpointEnabled = RegionEndpointEnabled ?? replica.RegionEndpointEnabled;
                    replica.Tags = Tag ?? replica.Tags;

                    var result = Microsoft.Azure.Management.SignalR.SignalRReplicasOperationsExtensions.Update(Client.SignalRReplicas, ResourceGroupName, SignalRName, Name, replica);
                    WriteObject(new PSReplicaResource(result));
                }
            });
        }
    }
}