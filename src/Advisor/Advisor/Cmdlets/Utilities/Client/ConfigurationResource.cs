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

namespace Microsoft.Azure.Commands.Advisor.Cmdlets.Utilities.Client
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Commands.Advisor.Cmdlets.Models;
    using Microsoft.Azure.Management.Advisor;
    using Microsoft.Azure.Management.Advisor.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Configuration Client utility class.
    /// </summary>
    public class ConfigurationResource
    {
        /// <summary>
        /// Gets the list of configurations associated with the current subscription in scope.
        /// </summary>
        /// <param name="advisorClient">Advisor Client</param>
        /// <returns>List of PsAzureAdvisorResourceRecommendationBase</returns>
        public List<PsAzureAdvisorConfigurationData> GetAllConfiguratioFromClient(IAdvisorManagementClient advisorClient)
        {
            AzureOperationResponse<IPage<ConfigData>> configurationOperationResponse = null;
            List<ConfigData> entirePageLinkRecommendationData = new List<ConfigData>();
            string nextPageLink = string.Empty;

            do
            {
                if (string.IsNullOrEmpty(nextPageLink))
                {
                    configurationOperationResponse = advisorClient.Configurations.ListBySubscriptionWithHttpMessagesAsync().Result;
                }
                else
                {
                    configurationOperationResponse = advisorClient.Configurations.ListBySubscriptionNextWithHttpMessagesAsync(nextPageLink).Result;
                }
                nextPageLink = configurationOperationResponse.Body.NextPageLink;

                // Add current page items to the List 
                entirePageLinkRecommendationData.AddRange(configurationOperationResponse.Body.ToList());
            }
            while (!string.IsNullOrEmpty(nextPageLink));

            // Convert to PsAzureAdvisorResourceRecommendationBase list and return 
            return PsAzureAdvisorConfigurationData.GetFromConfigurationData(entirePageLinkRecommendationData);
        }
    }
}
