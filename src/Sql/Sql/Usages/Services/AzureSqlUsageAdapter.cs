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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Usages.Models;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.Usages.Services
{
    public class AzureSqlUsageAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlUsageCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs the usage adapter
        /// </summary>
        /// <param name="context"></param>
        public AzureSqlUsageAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlUsageCommunicator(Context);
        }

        /// <summary>
        /// Returns a list of instance pool usages
        /// </summary>
        /// <param name="resourceGroupName">The resource group name</param>
        /// <param name="instancePoolName">The instance pool name</param>
        /// <param name="expandChildren">Whether to show the resource children's usage</param>
        /// <returns>A list of instance pool usages</returns>
        public List<AzureSqlUsageModel> ListInstancePoolUsages(
            string resourceGroupName, string instancePoolName, bool? expandChildren)
        {
            var resp = Communicator.ListByInstancePool(resourceGroupName, instancePoolName, expandChildren).ToList();
            return resp.Select(usageResp => CreateUsageModelFromResponse(usageResp)).ToList();
        }

        /// <summary>
        /// Creates the usage model from the usage response
        /// </summary>
        /// <param name="usageResp">The usage response</param>
        /// <returns>The AzureSqlUsageModel from the usage resp</returns>
        public AzureSqlUsageModel CreateUsageModelFromResponse(Usage usageResp)
        {
            return new AzureSqlUsageModel()
            {
                Id = usageResp.Id,
                CurrentValue = usageResp.CurrentValue,
                Limit = usageResp.Limit,
                RequestedLimit = usageResp.RequestedLimit,
                Type = usageResp.Type,
                Unit = usageResp.Unit,
                Name = usageResp.Name.Value,
            };
        }
    }
}
