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
    /// LogicApp client partial class for integration account map operations.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Creates integration account map.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountMapName">The integration account map name.</param>
        /// <param name="integrationAccountMap">The integration account map object.</param>
        /// <returns>Newly created integration account map object.</returns>
        public IntegrationAccountMap CreateIntegrationAccountMap(string resourceGroupName, string integrationAccountName, string integrationAccountMapName, IntegrationAccountMap integrationAccountMap)
        {
            if (!this.DoesIntegrationAccountMapExist(resourceGroupName, integrationAccountName,integrationAccountMapName))
            {
                return this.LogicManagementClient.IntegrationAccountMaps.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountMapName, integrationAccountMap);
            }
            else
            {
                throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                    Properties.Resource.ResourceAlreadyExists, integrationAccountMapName, resourceGroupName));
            }
        }

        /// <summary>
        /// Checks whether the integration account map exists or not. 
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account object.</param>
        /// <param name="integrationAccountMapName">The integration account map name.</param>
        /// <returns>Boolean result indicating whether the integration account map exists or not.</returns>
        private bool DoesIntegrationAccountMapExist(string resourceGroupName, string integrationAccountName, string integrationAccountMapName)
        {
            bool result = false;
            try
            {
                var map = this.LogicManagementClient.IntegrationAccountMaps.Get(resourceGroupName, integrationAccountName, integrationAccountMapName);
                result = map != null;
            }
            catch
            {
                result = false;
            }
            return result;
        }        

        /// <summary>
        /// Updates the integration account.
        /// </summary>
        /// <param name="resourceGroupName">The integration account map resource group.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountMapName">The integration account map name.</param>
        /// <param name="integrationAccountMap">The integration account map object.</param>
        /// <returns>Updated integration account map</returns>
        public IntegrationAccountMap UpdateIntegrationAccountMap(string resourceGroupName, string integrationAccountName, string integrationAccountMapName, IntegrationAccountMap integrationAccountMap)
        {
            return this.LogicManagementClient.IntegrationAccountMaps.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountMapName, integrationAccountMap);
        }

        /// <summary>
        /// Gets the integration account map by name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountMapName">The integration account map name.</param>
        /// <returns>Integration account map object.</returns>
        public IntegrationAccountMap GetIntegrationAccountMap(string resourceGroupName, string integrationAccountName, string integrationAccountMapName)
        {
            return this.LogicManagementClient.IntegrationAccountMaps.Get(resourceGroupName, integrationAccountName, integrationAccountMapName);
        }

        /// <summary>
        /// Gets the integration account maps by resource group name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <returns>List of integration account schemas.</returns>
        public IPage<IntegrationAccountMap> ListIntegrationAccountMaps(string resourceGroupName, string integrationAccountName)
        {
            return this.LogicManagementClient.IntegrationAccountMaps.List(resourceGroupName, integrationAccountName);
        }

        /// <summary>
        /// Removes the specified integration account map.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountMapName">The integration account map name.</param>
        public void RemoveIntegrationAccountMap(string resourceGroupName, string integrationAccountName, string integrationAccountMapName)
        {
            this.LogicManagementClient.IntegrationAccountMaps.Delete(resourceGroupName, integrationAccountName, integrationAccountMapName);
        }
    }
}