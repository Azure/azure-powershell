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

using Microsoft.Azure.Commands.Management.Search.Models;
using Microsoft.Azure.Commands.Management.Search.SearchService;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Search;
using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Search
{
    public abstract class SearchServiceBaseCmdlet : AzureRMCmdlet
    {
        protected const string SearchServiceNounStr = "AzureRmSearchService";
        protected const string SearchServiceAdminKeyNounStr = "AzureRmSearchAdminKey";
        protected const string SearchServiceAdminKeyPairNounStr = "AzureRmSearchAdminKeyPair";
        protected const string SearchServiceQueryKeyNounStr = "AzureRmSearchQueryKey";

        protected const string InputObjectParameterSetName = "InputObjectParameterSet";
        protected const string ResourceNameParameterSetName = "ResourceNameParameterSet";
        protected const string ResourceIdParameterSetName = "ResourceIdParameterSet";
        protected const string ResourceGroupParameterSetName = "ResourceGroupParameterSet";

        protected const string InputObjectHelpMessage = "Search Service Input Object.";
        protected const string ResourceIdHelpMessage = "Search Service Resource Id.";
        protected const string ForceHelpMessage = "Do not ask for confirmation.";

        protected const string ResourceGroupHelpMessage = "Resource Group name.";
        protected const string ResourceNameHelpMessage = "Search Service name.";
        protected const string SkuHelpMessage = "Search Service Sku.";
        protected const string LocationHelpMessage = "Search Service location.";
        protected const string PartitionCountHelpMessage = "Search Service partition count.";
        protected const string ReplicaCountHelpMessage = "Search Service replica count.";
        protected const string HostingModeHelpMessage = "Search Service hosting mode.";
        protected const string KeyKindHelpMessage = "Search Service admin key kind (Primary/Secondary).";
        protected const string QueryKeyNameHelpMessage = "Search Service query key name.";
        protected const string QueryKeyValueHelpMessage = "Search Service query key value.";
        protected const string PassThruHelpMessage = "This Cmdlet does not return an object by default. If this switch is specified, it returns true if successful.";

        protected const string ParentObjectParameterSetName = "ParentObjectParameterSet";
        protected const string ParentResourceIdParameterSetName = "ParentResourceIdParameterSet";

        private SearchManagementClientWrapper searchClientWrapper;

        public ISearchManagementClient SearchClient
        {
            get
            {
                if (searchClientWrapper == null)
                {
                    searchClientWrapper = new SearchManagementClientWrapper(DefaultProfile.DefaultContext);
                }

                searchClientWrapper.VerboseLogger = WriteVerboseWithTimestamp;
                searchClientWrapper.ErrorLogger = WriteErrorWithTimestamp;

                return searchClientWrapper.SearchManagementClient;
            }

            set
            {
                searchClientWrapper = new SearchManagementClientWrapper(value);
            }
        }

        protected void WriteSearchService(Azure.Management.Search.Models.SearchService searchService)
        {
            if (searchService != null)
            {
                WriteObject(PSSearchService.Create(searchService));
            }
        }

        protected void WriteSearchServiceList(IEnumerable<Azure.Management.Search.Models.SearchService> searchServices)
        {
            var output = new List<PSSearchService>();
            if (searchServices != null)
            {
                searchServices.ForEach(svc => output.Add(PSSearchService.Create(svc)));
            }

            WriteObject(output, true);
        }

        protected void WriteAdminKey(AdminKeyResult adminKeyResult)
        {
            if (adminKeyResult != null)
            {
                WriteObject(PSSearchAdminKey.Create(adminKeyResult));
            }
        }

        protected void WriteQueryKey(QueryKey queryKey)
        {
            if (queryKey != null)
            {
                WriteObject(PSSearchQueryKey.Create(queryKey));
            }
        }

        protected void WriteQueryKeyList(IEnumerable<QueryKey> queryKeys)
        {
            var output = new List<PSSearchQueryKey>();
            if (queryKeys != null)
            {
                queryKeys.ForEach(key => output.Add(PSSearchQueryKey.Create(key)));
            }

            WriteObject(output, true);
        }

        protected void CatchThrowInnerException(Action action)
        {
            try
            {
                action();
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }
        }
    }
}
