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
using Microsoft.Azure.Commands.Anf.Common;
using Microsoft.Azure.Commands.Anf.Models;
using Microsoft.Azure.Management.NetApp;

namespace Microsoft.Azure.Commands.Anf.Pool
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AnfPool"), OutputType(typeof(PSAnfPool))]
    public class RemoveAzureRmAnfPool : AzureAnfCmdletBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group of the ANF pool",
            ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF account",
            ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ANF pool",
            ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string PoolName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the ANF pool",
            ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {

                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResource = resourceIdentifier.ParentResource;
                AccountName = parentResource.Substring(parentResource.LastIndexOf('/') + 1);
                PoolName = resourceIdentifier.ResourceName;
            }

            AzureNetAppFilesManagementClient.Pools.Delete(ResourceGroupName, AccountName, PoolName);
        }
    }
}
