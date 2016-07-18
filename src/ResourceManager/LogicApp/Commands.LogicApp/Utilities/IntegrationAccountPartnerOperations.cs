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

namespace Microsoft.Azure.Commands.LogicApp.Utilities
{
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Azure.Management.Logic;
    using System.Management.Automation;
    using System.Globalization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// LogicApp client partial class for integration account partner operations.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Creates integration account partner.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountPartnerName">The integration account partner name.</param>
        /// <param name="integrationAccountPartner">The integration account partner object.</param>
        /// <returns>Newly created integration account partner object.</returns>
        public IntegrationAccountPartner CreateIntegrationAccountPartner(string resourceGroupName, string integrationAccountName, string integrationAccountPartnerName, IntegrationAccountPartner integrationAccountPartner)
        {
            if (!this.DoesIntegrationAccountPartnerExist(resourceGroupName, integrationAccountName, integrationAccountPartnerName))
            {
                return this.LogicManagementClient.IntegrationAccountPartners.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountPartnerName, integrationAccountPartner);
            }
            else
            {
                throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                    Properties.Resource.ResourceAlreadyExists, integrationAccountPartnerName, resourceGroupName));
            }
        }

        /// <summary>
        /// Checks whether the integration account partner exists or not. 
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account object.</param>
        /// <param name="integrationAccountPartnerName">The integration account partner name.</param>
        /// <returns>Boolean result indicating whether the integration account partner exists or not.</returns>
        private bool DoesIntegrationAccountPartnerExist(string resourceGroupName, string integrationAccountName, string integrationAccountPartnerName)
        {
            bool result = false;
            try
            {
                var partner = this.LogicManagementClient.IntegrationAccountPartners.Get(resourceGroupName, integrationAccountName, integrationAccountPartnerName);
                result = partner != null;
            }
            catch
            {
                result = false;
            }
            return result;
        }        

        /// <summary>
        /// Updates the integration account partner.
        /// </summary>
        /// <param name="resourceGroupName">The integration account partner resource group.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountPartnerName">The integration account partner name.</param>
        /// <param name="integrationAccountPartner">The integration account partner object.</param>
        /// <returns>Updated integration account partner.</returns>
        public IntegrationAccountPartner UpdateIntegrationAccountPartner(string resourceGroupName, string integrationAccountName, string integrationAccountPartnerName, IntegrationAccountPartner integrationAccountPartner)
        {
            return this.LogicManagementClient.IntegrationAccountPartners.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountPartnerName, integrationAccountPartner);
        }

        /// <summary>
        /// Gets the integration account partner by name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountPartnerName">The integration account partner name.</param>
        /// <returns>Integration account partner object.</returns>
        public IntegrationAccountPartner GetIntegrationAccountPartner(string resourceGroupName, string integrationAccountName, string integrationAccountPartnerName)
        {
            return this.LogicManagementClient.IntegrationAccountPartners.Get(resourceGroupName, integrationAccountName, integrationAccountPartnerName);
        }

        /// <summary>
        /// Gets the integration account partners by resource group name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <returns>List of integration account partners.</returns>
        public IPage<IntegrationAccountPartner> ListIntegrationAccountPartner(string resourceGroupName, string integrationAccountName)
        {
            return this.LogicManagementClient.IntegrationAccountPartners.List(resourceGroupName, integrationAccountName);
        }

        /// <summary>
        /// Removes the specified integration account partner.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountPartnerName">The integration account partner name.</param>
        public void RemoveIntegrationAccountPartner(string resourceGroupName, string integrationAccountName, string integrationAccountPartnerName)
        {
            this.LogicManagementClient.IntegrationAccountPartners.Delete(resourceGroupName, integrationAccountName, integrationAccountPartnerName);
        }
    }
}