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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.Pool
{
    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesPool",
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesPool))]
    [Alias("Get-AnfPool")]
    public class GetAzureRmNetAppFilesPool : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group of the ANF pool",
            ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF account",
            ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts", nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the ANF pool",
            ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("PoolName")]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts/capacityPools", nameof(ResourceGroupName), nameof(AccountName))]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the ANF pool",
            ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The account object containing the pool to return",
            ParameterSetName = ObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesAccount AccountObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResource = resourceIdentifier.ParentResource;
                AccountName = parentResource.Substring(parentResource.LastIndexOf('/') + 1);
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = AccountObject.ResourceGroupName;
                AccountName = AccountObject.Name;
            }

            if (Name != null)
            {
                var anfPool = AzureNetAppFilesManagementClient.Pools.Get(ResourceGroupName, AccountName, Name);
                WriteObject(anfPool.ToPsNetAppFilesPool());
            }
            else
            {
                var anfPool = AzureNetAppFilesManagementClient.Pools.List(ResourceGroupName, AccountName).Select(e => e.ToPsNetAppFilesPool());
                WriteObject(anfPool, true);
            }
        }
    }
}
