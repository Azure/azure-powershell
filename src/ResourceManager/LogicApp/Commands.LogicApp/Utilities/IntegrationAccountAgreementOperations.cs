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
    /// LogicApp client partial class for integration account agreement operations.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Creates integration account agreement.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <param name="integrationAccountAgreement">The integration account agreement object.</param>
        /// <returns>Newly created integration account agreement object.</returns>
        public IntegrationAccountAgreement CreateIntegrationAccountAgreement(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName, IntegrationAccountAgreement integrationAccountAgreement)
        {
            if (!this.DoesIntegrationAccountAgreementExist(resourceGroupName, integrationAccountName, integrationAccountAgreementName))
            {
                return this.LogicManagementClient.IntegrationAccountAgreements.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountAgreementName, integrationAccountAgreement);
            }
            else
            {
                throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                    Properties.Resource.ResourceAlreadyExists, integrationAccountAgreementName, resourceGroupName));
            }
        }

        /// <summary>
        /// Checks whether the integration account agreement exists or not. 
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account object.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <returns>Boolean result indicating whether the integration account agreement exists or not.</returns>
        private bool DoesIntegrationAccountAgreementExist(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName)
        {
            bool result = false;
            try
            {
                var agreement = this.LogicManagementClient.IntegrationAccountAgreements.Get(resourceGroupName, integrationAccountName, integrationAccountAgreementName);
                result = agreement != null;
            }
            catch
            {
                result = false;
            }
            return result;
        }        

        /// <summary>
        /// Updates the integration account agreement.
        /// </summary>
        /// <param name="resourceGroupName">The integration account agreement resource group.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <param name="integrationAccountAgreement">The integration account agreement object.</param>
        /// <returns>Updated integration account agreement</returns>
        public IntegrationAccountAgreement UpdateIntegrationAccountAgreement(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName, IntegrationAccountAgreement integrationAccountAgreement)
        {
            return this.LogicManagementClient.IntegrationAccountAgreements.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountAgreementName, integrationAccountAgreement);
        }

        /// <summary>
        /// Gets the integration account agreement by name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        /// <returns>Integration account agreement object.</returns>
        public IntegrationAccountAgreement GetIntegrationAccountAgreement(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName)
        {
            return this.LogicManagementClient.IntegrationAccountAgreements.Get(resourceGroupName, integrationAccountName, integrationAccountAgreementName);
        }

        /// <summary>
        /// Gets the integration account agreements by resource group name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account agreement resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <returns>List of integration account agreements.</returns>
        public IPage<IntegrationAccountAgreement> ListIntegrationAccountAgreements(string resourceGroupName, string integrationAccountName)
        {
            return this.LogicManagementClient.IntegrationAccountAgreements.List(resourceGroupName, integrationAccountName);
        }

        /// <summary>
        /// Removes the specified integration account agreement.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAgreementName">The integration account agreement name.</param>
        public void RemoveIntegrationAccountAgreement(string resourceGroupName, string integrationAccountName, string integrationAccountAgreementName)
        {
            this.LogicManagementClient.IntegrationAccountAgreements.Delete(resourceGroupName, integrationAccountName, integrationAccountAgreementName);
        }
    }
}