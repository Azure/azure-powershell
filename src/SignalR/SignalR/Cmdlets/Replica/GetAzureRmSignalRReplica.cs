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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.SignalR.Models;
using Microsoft.Azure.Commands.SignalR.Properties;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SignalRReplica", DefaultParameterSetName = ResourceGroupParameterSet)]
    [OutputType(typeof(PSReplicaResource))]
    public class GetAzureRmSignalRReplica : SignalRCmdletBase, ISignalRChildResource
    {
        [Parameter(Mandatory = false, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The resource group name. The default one will be used if not specified.")]
        [ValidateNotNullOrEmpty()]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The SignalR service name.")]
        [ValidateNotNullOrEmpty()]
        [ResourceNameCompleter(Constants.SignalRResourceType, nameof(ResourceGroupName))]
        public string SignalRName { get; set; }

        [ValidateNotNullOrEmpty()]
        [Parameter(Mandatory = false, ParameterSetName = ResourceGroupParameterSet, HelpMessage = "The name of the replica")]
        [Parameter(Mandatory = false, ParameterSetName = SignalRObjectParameterSet, HelpMessage = "The name of the replica")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The resource ID of a replica", ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty()]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SignalRObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The SignalR resource object.")]
        [ValidateNotNull]
        public PSSignalRResource SignalRObject { get; set; }

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
                        this.LoadFromSignalRResourceId(SignalRObject.Id);
                        break;
                    case ResourceIdParameterSet:
                        this.LoadFromChildResourceId(ResourceId, Constants.SignalRReplicaResourceType);
                        break;
                    default:
                        throw new ArgumentException(Resources.ParameterSetError);
                }
                if (Name == null)
                {
                    var result = Microsoft.Azure.Management.SignalR.SignalRReplicasOperationsExtensions.List(Client.SignalRReplicas, ResourceGroupName, SignalRName);
                    WriteObject(result.Select(r => new PSReplicaResource(r)), true);
                }
                else
                {
                    var result = Microsoft.Azure.Management.SignalR.SignalRReplicasOperationsExtensions.Get(Client.SignalRReplicas, ResourceGroupName, SignalRName, Name);
                    WriteObject(new PSReplicaResource(result));
                }
            });
        }
    }
}