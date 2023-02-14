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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.Batch;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists private link resources
        /// </summary>
        /// <param name="resourceGroup">The resource group</param>
        /// <param name="accountName">The account name</param>
        /// <param name="maxResults">The max results</param>
        /// <returns>The private link resources</returns>
        public virtual IEnumerable<PSPrivateLinkResource> ListPrivateLinkResources(string resourceGroup, string accountName, int? maxResults = null)
        {
            if (resourceGroup == null)
            {
                throw new ArgumentNullException(nameof(resourceGroup));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            WriteVerbose(string.Format(Resources.GetPrivateLinkResourceNoFilter, resourceGroup, accountName));

            var result = ListAllPrivateLinkResources(
                resourceGroup,
                accountName,
                maxResults).Select(PSPrivateLinkResource.CreateFromPrivateLinkResource);

            return result;
        }

        public virtual PSPrivateLinkResource GetPrivateLinkResource(string resourceGroup, string accountName, string name)
        {
            if (resourceGroup == null)
            {
                throw new ArgumentNullException(nameof(resourceGroup));
            }
            if (accountName == null)
            {
                throw new ArgumentNullException(nameof(accountName));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            WriteVerbose(string.Format(Resources.GetPrivateLinkResourceByName, name));

            var result =
                PSPrivateLinkResource.CreateFromPrivateLinkResource(
                    BatchManagementClient.PrivateLinkResource.Get(
                        resourceGroup,
                        accountName,
                        name));

            return result;
        }

        internal IEnumerable<PrivateLinkResource> ListAllPrivateLinkResources(string resourceGroup, string accountName, int? maxResults = null)
        {
            var privateLinkResources = new List<PrivateLinkResource>();
            var privateLinkResourcesPartial = BatchManagementClient.PrivateLinkResource.ListByBatchAccount(resourceGroup, accountName, maxResults);

            privateLinkResources.AddRange(privateLinkResourcesPartial);

            while(privateLinkResourcesPartial.NextPageLink != null)
            {
                privateLinkResourcesPartial = BatchManagementClient.PrivateLinkResource.ListByBatchAccountNext(privateLinkResourcesPartial.NextPageLink);
                privateLinkResources.AddRange(privateLinkResourcesPartial);
            }

            return privateLinkResources;
        }
    }
}
