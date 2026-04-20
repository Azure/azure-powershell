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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.Cache
{
    [Cmdlet(
        "Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesCache",
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesCache))]
    [Alias("Get-AnfCache")]
    public class GetAzureRmNetAppFilesCache : AzureNetAppFilesCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF account")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts", nameof(ResourceGroupName))]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF capacity pool")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.NetApp/netAppAccounts/capacityPools", nameof(ResourceGroupName), nameof(AccountName))]
        public string PoolName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = "The name of the ANF cache")]
        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = "The name of the ANF cache")]
        [ValidateNotNullOrEmpty]
        [Alias("CacheName")]
        [ResourceNameCompleter(
            "Microsoft.NetApp/netAppAccounts/capacityPools/caches",
            nameof(ResourceGroupName),
            nameof(AccountName),
            nameof(PoolName))]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The resource id of the ANF cache")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(ParameterSetName = ParentObjectParameterSet, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The pool object containing the cache(s)")]
        [ValidateNotNullOrEmpty]
        public PSNetAppFilesPool PoolObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ResourceIdParameterSet)
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                var parentResources = resourceIdentifier.ParentResource.Split('/');
                AccountName = parentResources[1];
                PoolName = parentResources[3];
                Name = resourceIdentifier.ResourceName;
            }
            else if (ParameterSetName == ParentObjectParameterSet)
            {
                ResourceGroupName = PoolObject.ResourceGroupName;
                var nameParts = PoolObject.Name.Split('/');
                AccountName = nameParts[0];
                PoolName = nameParts[1];
            }

            if (Name != null)
            {
                var anfCache = AzureNetAppFilesManagementClient.Caches.Get(ResourceGroupName, AccountName, PoolName, Name);
                WriteObject(anfCache.ConvertToPs());
            }
            else
            {
                try
                {
                    var caches = AzureNetAppFilesManagementClient.Caches.List(ResourceGroupName, AccountName, PoolName).ToList();
                    List<PSNetAppFilesCache> psCaches = caches.ConvertToPS();
                    WriteObject(psCaches, true);
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
        }
    }
}
