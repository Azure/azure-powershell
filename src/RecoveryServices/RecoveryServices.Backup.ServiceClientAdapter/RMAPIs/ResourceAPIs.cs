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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using RestAzureNS = Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Get azure resource
        /// </summary>
        /// <param name="resourceId">Resource id of the Azure resource to get</param>
        /// <returns>Generic resource returned from the service</returns>
        public GenericResource GetAzureResource(string resourceId)
        {
            GenericResource resource = RMAdapter.Client.Resources.GetByIdWithHttpMessagesAsync(
                resourceId,
                "2015-06-15", 
                null,
                cancellationToken: RMAdapter.CmdletCancellationToken).Result.Body;
            return resource;
        }

        /// <summary>
        /// Get storage accounts according to the query params
        /// </summary>
        /// <param name="storageAccountName">Name of the container to unregister</param>
        /// <param name="subscriptionId"></param>
        /// <returns>Generic resource returned from the service</returns>
        public GenericResource GetStorageAccountResource(string storageAccountName, string subscriptionId = null)
        {
            List<GenericResource> storageAccounts = null;
            GenericResource storageAccount = null;
            storageAccountName = storageAccountName.ToLower();
            ODataQuery<GenericResourceFilter> getItemQueryParams =
                new ODataQuery<GenericResourceFilter>(q =>
                q.ResourceType == "Microsoft.ClassicStorage/storageAccounts");

            // switch subscription context 
            string subscriptionContext = RMAdapter.Client.SubscriptionId;
            RMAdapter.Client.SubscriptionId = (subscriptionId != null)? subscriptionId: RMAdapter.Client.SubscriptionId;

            Func<RestAzureNS.IPage<GenericResource>> listAsync =
            () => RMAdapter.Client.Resources.ListWithHttpMessagesAsync(
                getItemQueryParams,
                cancellationToken: RMAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<GenericResource>> listNextAsync =
                nextLink => RMAdapter.Client.Resources.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: RMAdapter.CmdletCancellationToken).Result.Body;

            storageAccounts = HelperUtils.GetPagedRMList(listAsync, listNextAsync);
            storageAccount = storageAccounts.Find(account =>
                string.Compare(account.Name, storageAccountName) == 0);

            if (storageAccount == null)
            {
                getItemQueryParams = new ODataQuery<GenericResourceFilter>(q =>
                q.ResourceType == "Microsoft.Storage/storageAccounts");
                listAsync = () => RMAdapter.Client.Resources.ListWithHttpMessagesAsync(
                    getItemQueryParams,
                    cancellationToken: RMAdapter.CmdletCancellationToken).Result.Body;

                listNextAsync = nextLink => RMAdapter.Client.Resources.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: RMAdapter.CmdletCancellationToken).Result.Body;

                storageAccounts = HelperUtils.GetPagedRMList(listAsync, listNextAsync);
                storageAccount = storageAccounts.Find(account =>
                    string.Compare(account.Name, storageAccountName) == 0);
            }

            RMAdapter.Client.SubscriptionId = subscriptionContext;

            return storageAccount;
        }
    }
}