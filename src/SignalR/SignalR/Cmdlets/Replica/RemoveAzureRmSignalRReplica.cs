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
using System.Management.Automation;
using Azure.Core;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalRReplica", SupportsShouldProcess = true, DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmSignalRReplica : SignalRCmdletBase, ISignalRChildResource
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
        [Parameter(Mandatory = true, ParameterSetName = SignalRObjectParameterSet, HelpMessage = "The replica name.")]
        [ValidateNotNullOrEmpty()]
        [ResourceNameCompleter(Constants.SignalRReplicaResourceType, nameof(ResourceGroupName), nameof(SignalRName))]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The resource ID of a replica", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty()]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SignalRObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource SignalRObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The replica resource object.")]
        [ValidateNotNull]
        public PSReplicaResource InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Returns true when the command succeeds.")]
        public SwitchParameter PassThru { get; set; }

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
                    case SignalRObjectParameterSet:
                        var signalRResourceId = new ResourceIdentifier(SignalRObject.Id);
                        ResourceGroupName = signalRResourceId.ResourceGroupName;
                        SignalRName = signalRResourceId.Name;
                        break;
                    case ResourceIdParameterSet:
                        this.LoadFromChildResourceId(ResourceId, Constants.SignalRReplicaResourceType);
                        break;
                    case InputObjectParameterSet:
                        this.LoadFromChildResourceId(InputObject.Id, Constants.SignalRReplicaResourceType);
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
                Microsoft.Azure.Management.SignalR.SignalRReplicasOperationsExtensions.Delete(Client.SignalRReplicas, ResourceGroupName, SignalRName, Name);

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            });
        }
    }
}