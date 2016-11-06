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
    /// LogicApp client partial class for integration account schema operations.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Creates integration account schema.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountSchemaName">The integration account name.</param>
        /// <param name="integrationAccountSchema">The integration account schema object.</param>
        /// <returns>Newly created integration account schema object.</returns>
        public IntegrationAccountSchema CreateIntegrationAccountSchema(string resourceGroupName, string integrationAccountName, string integrationAccountSchemaName, IntegrationAccountSchema integrationAccountSchema)
        {
            if (!this.DoesIntegrationAccountSchemaExist(resourceGroupName, integrationAccountName,integrationAccountSchemaName))
            {
                return this.LogicManagementClient.IntegrationAccountSchemas.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountSchemaName, integrationAccountSchema);
            }
            else
            {
                throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                    Properties.Resource.ResourceAlreadyExists, integrationAccountSchemaName, resourceGroupName));
            }
        }

        /// <summary>
        /// Checks whether the integration account schema exists or not. 
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountSchemaName">The integration account schema name.</param>
        /// <returns>Boolean result indicating whether the integration account schema exists or not.</returns>
        private bool DoesIntegrationAccountSchemaExist(string resourceGroupName, string integrationAccountName, string integrationAccountSchemaName)
        {
            bool result = false;
            try
            {
                var schema = this.LogicManagementClient.IntegrationAccountSchemas.Get(resourceGroupName, integrationAccountName, integrationAccountSchemaName);
                result = schema != null;
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
        /// <param name="resourceGroupName">The integration account schema resource group.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountSchemaName">The integration account schema name.</param>
        /// <param name="integrationAccountSchema">The integration account schema object.</param>
        /// <returns>Updated integration account schema</returns>
        public IntegrationAccountSchema UpdateIntegrationAccountSchema(string resourceGroupName, string integrationAccountName, string integrationAccountSchemaName, IntegrationAccountSchema integrationAccountSchema)
        {
            return this.LogicManagementClient.IntegrationAccountSchemas.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountSchemaName, integrationAccountSchema);
        }

        /// <summary>
        /// Gets the integration account by name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountSchemaName">The integration account schema name.</param>
        /// <returns>Integration account schema object.</returns>
        public IntegrationAccountSchema GetIntegrationAccountSchema(string resourceGroupName, string integrationAccountName, string integrationAccountSchemaName)
        {
            return this.LogicManagementClient.IntegrationAccountSchemas.Get(resourceGroupName, integrationAccountName, integrationAccountSchemaName);
        }

        /// <summary>
        /// Gets the integration accounts schema by resource group name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <returns>List of integration account schemas.</returns>
        public IPage<IntegrationAccountSchema> ListIntegrationAccountSchemas(string resourceGroupName, string integrationAccountName)
        {            
            return this.LogicManagementClient.IntegrationAccountSchemas.List(resourceGroupName, integrationAccountName);
        }

        /// <summary>
        /// Removes the specified integration account schema.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountSchemaName">The integration account schema name.</param>
        public void RemoveIntegrationAccountSchema(string resourceGroupName, string integrationAccountName, string integrationAccountSchemaName)
        {
            this.LogicManagementClient.IntegrationAccountSchemas.Delete(resourceGroupName, integrationAccountName, integrationAccountSchemaName);
        }
    }
}