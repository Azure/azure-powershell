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
using Microsoft.Azure.Commands.Batch.Properties;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BatchPrivateEndpointConnection", DefaultParameterSetName = AccountAndResourceGroupParameterSet)]
    [OutputType(typeof(PSPrivateEndpointConnection))]
    public class GetBatchPrivateEndpointConnectionCommand : BatchCmdletBase
    {
        private const string AccountAndResourceGroupParameterSet = "AccountAndResourceGroup";
        private const string AccountResourceGroupAndNameParameterSet = "AccountResourceGroupAndName";

        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = AccountAndResourceGroupParameterSet, HelpMessage = "Specifies the name of the Batch account.")]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = AccountResourceGroupAndNameParameterSet, HelpMessage = "Specifies the name of the Batch account.")]
        [ResourceNameCompleter("Microsoft.Batch/batchAccounts", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = AccountAndResourceGroupParameterSet, HelpMessage = "Specifies the name of the resource group that contains the Batch account.")]
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = AccountResourceGroupAndNameParameterSet, HelpMessage = "Specifies the name of the resource group that contains the Batch account.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = Constants.IdParameterSet, HelpMessage = "The resource id of the Private Endpoint Connection.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = AccountResourceGroupAndNameParameterSet, HelpMessage = "The name of the private endpoint connection to get.")]
        [ResourceNameCompleter("Microsoft.Batch/batchAccounts/privateEndpointConnections", nameof(ResourceGroupName), nameof(AccountName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = AccountAndResourceGroupParameterSet, HelpMessage = "The maximum number of results to return.")]
        public int MaxCount { get; set; } = Constants.DefaultMaxCount;

        protected override void ExecuteCmdletImpl()
        {
            WriteVerboseWithTimestamp(Resources.BeginMAMLCall, nameof(GetBatchPrivateEndpointConnectionCommand));
            if (!string.IsNullOrEmpty(AccountName) && !string.IsNullOrEmpty(ResourceGroupName))
            {
                // List
                if(string.IsNullOrEmpty(Name))
                {
                    foreach (var result in BatchClient.ListPrivateEndpointConnections(ResourceGroupName, AccountName, MaxCount))
                    {
                        WriteObject(result);
                    }
                }
                // Get
                else
                {
                    var result = BatchClient.GetPrivateEndpointConnection(ResourceGroupName, AccountName, Name);
                    WriteObject(result);
                }
            }
            else
            {
                var resourceId = new ResourceIdentifier(ResourceId);
                var parentResource = resourceId.ParentResource.Split(new[] { '/' })[1];
                var result = BatchClient.GetPrivateEndpointConnection(resourceId.ResourceGroupName, parentResource, resourceId.ResourceName);
                WriteObject(result);
            }
            WriteVerboseWithTimestamp(Resources.EndMAMLCall, nameof(GetBatchPrivateEndpointConnectionCommand));
        }
    }
}
