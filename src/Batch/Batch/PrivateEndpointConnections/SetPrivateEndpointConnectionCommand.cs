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

using System.Management.Automation;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Commands.Batch.Properties;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BatchPrivateEndpointConnection", SupportsShouldProcess = true, DefaultParameterSetName = AccountResourceGroupAndNameParameterSet)]
    [OutputType(typeof(void))]
    public class SetBatchPrivateEndpointConnectionCommand : BatchCmdletBase
    {
        private const string AccountResourceGroupAndNameParameterSet = "AccountResourceGroupAndName";

        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = AccountResourceGroupAndNameParameterSet, HelpMessage = "Specifies the name of the Batch account.")]
        [ResourceNameCompleter("Microsoft.Batch/batchAccounts", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = AccountResourceGroupAndNameParameterSet, HelpMessage = "Specifies the name of the resource group that contains the Batch account.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = Constants.IdParameterSet, HelpMessage = "The resource id of the Private Endpoint Connection.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = AccountResourceGroupAndNameParameterSet, HelpMessage = "The name of the private endpoint connection")]
        [ResourceNameCompleter("Microsoft.Batch/batchAccounts/privateEndpointConnections", nameof(ResourceGroupName), nameof(AccountName))] // TODO: Test this
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AccountResourceGroupAndNameParameterSet, HelpMessage = "The private link service connection status")]
        [Parameter(Mandatory = true, ParameterSetName = Constants.IdParameterSet, HelpMessage = "The private link service connection status")]
        [ValidateNotNullOrEmpty]
        public PrivateLinkServiceConnectionStatus Status { get; set; }

        [Parameter(ParameterSetName = AccountResourceGroupAndNameParameterSet, HelpMessage = "The private link service connection descrption")]
        [Parameter(ParameterSetName = Constants.IdParameterSet, HelpMessage = "The private link service connection description")]
        public string Description { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ParameterSetName = Constants.InputObjectParameterSet,
            HelpMessage = "The Private Endpoint.")]
        [ValidateNotNullOrEmpty]
        public PSPrivateEndpointConnection PrivateEndpointConnection { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            if (ShouldProcess("AzureBatchPrivateEndpointConnection"))
            {
                WriteVerboseWithTimestamp(Resources.BeginMAMLCall, nameof(SetBatchPrivateEndpointConnectionCommand));
                if (!string.IsNullOrEmpty(AccountName) && !string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
                {
                    BatchClient.UpdatePrivateEndpointConnection(ResourceGroupName, AccountName, Name, Status, Description);
                }
                else if (!string.IsNullOrEmpty(ResourceId))
                {
                    var resourceId = new ResourceIdentifier(ResourceId);
                    var parentResource = resourceId.ParentResource.Split(new[] { '/' })[1];
                    BatchClient.UpdatePrivateEndpointConnection(resourceId.ResourceGroupName, parentResource, resourceId.ResourceName, Status, Description);
                }
                else
                {
                    var resourceId = new ResourceIdentifier(PrivateEndpointConnection.Id);
                    var parentResource = resourceId.ParentResource.Split(new[] { '/' })[1];
                    BatchClient.UpdatePrivateEndpointConnection(
                        resourceId.ResourceGroupName,
                        parentResource,
                        resourceId.ResourceName,
                        PrivateEndpointConnection.PrivateLinkServiceConnectionState.Status,
                        PrivateEndpointConnection.PrivateLinkServiceConnectionState.Description);
                }
                WriteVerboseWithTimestamp(Resources.EndMAMLCall, nameof(SetBatchPrivateEndpointConnectionCommand));
            }
        }
    }
}
