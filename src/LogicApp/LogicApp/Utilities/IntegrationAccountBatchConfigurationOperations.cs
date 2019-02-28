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
    using Microsoft.Azure.Commands.LogicApp.Models;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// LogicApp client partial class for integration account batch configuration operations.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Creates integration account batch configuration.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountBatchConfigurationName">The integration account batch configuration name.</param>
        /// <param name="integrationAccountBatchConfiguration">The integration account batch configuration object.</param>
        /// <returns>Newly created integration account batch configuration object.</returns>
        public PSIntegrationAccountBatchConfiguration CreateIntegrationAccountBatchConfiguration(string resourceGroupName, string integrationAccountName, string integrationAccountBatchConfigurationName, BatchConfiguration integrationAccountBatchConfiguration)
        {
            if (!this.DoesIntegrationAccountBatchConfigurationExist(resourceGroupName, integrationAccountName, integrationAccountBatchConfigurationName))
            {
                var batchConfiguration =  this.LogicManagementClient.IntegrationAccountBatchConfigurations.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountBatchConfigurationName, integrationAccountBatchConfiguration);

                return new PSIntegrationAccountBatchConfiguration(batchConfiguration);
            }
            else
            {
                throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture,
                    Properties.Resource.ResourceAlreadyExists, integrationAccountBatchConfigurationName, resourceGroupName));
            }
        }

        /// <summary>
        /// Checks whether the integration account batch configuration exists or not. 
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account object.</param>
        /// <param name="integrationAccountBatchConfigurationName">The integration account batch configuration name.</param>
        /// <returns>Boolean result indicating whether the integration account batch configuration exists or not.</returns>
        private bool DoesIntegrationAccountBatchConfigurationExist(string resourceGroupName, string integrationAccountName, string integrationAccountBatchConfigurationName)
        {
            var result = false;
            try
            {
                var batchConfiguration = this.LogicManagementClient.IntegrationAccountAssemblies.Get(resourceGroupName, integrationAccountName, integrationAccountBatchConfigurationName);
                result = batchConfiguration != null;
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
        /// <param name="resourceGroupName">The integration account batch configuration resource group.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountBatchConfigurationName">The integration account batch configuration name.</param>
        /// <param name="integrationAccountBatchConfiguration">The integration account batch configuration object.</param>
        /// <returns>Updated integration account batch configuration</returns>
        public PSIntegrationAccountBatchConfiguration UpdateIntegrationAccountBatchConfiguration(string resourceGroupName, string integrationAccountName, string integrationAccountBatchConfigurationName, BatchConfiguration integrationAccountBatchConfiguration)
        {
            var updatedBatchConfiguration = this.LogicManagementClient.IntegrationAccountBatchConfigurations.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountBatchConfigurationName, integrationAccountBatchConfiguration);

            return new PSIntegrationAccountBatchConfiguration(updatedBatchConfiguration);
        }

        /// <summary>
        /// Gets the integration account batch configuration by name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountBatchConfigurationName">The integration account batch configuration name.</param>
        /// <returns>Integration account batch configuration object.</returns>
        public PSIntegrationAccountBatchConfiguration GetIntegrationAccountBatchConfiguration(string resourceGroupName, string integrationAccountName, string integrationAccountBatchConfigurationName)
        {
            var batchConfiguration = this.LogicManagementClient.IntegrationAccountBatchConfigurations.Get(resourceGroupName, integrationAccountName, integrationAccountBatchConfigurationName);

            return new PSIntegrationAccountBatchConfiguration(batchConfiguration);
        }

        /// <summary>
        /// Gets the integration account assemblies by resource group name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <returns>List of integration account batch configurations.</returns>
        public IEnumerable<PSIntegrationAccountBatchConfiguration> ListIntegrationAccountBatchConfigurations(string resourceGroupName, string integrationAccountName)
        {
            var batchConfigurations = this.LogicManagementClient.IntegrationAccountBatchConfigurations.List(resourceGroupName, integrationAccountName);

            return batchConfigurations.Select(batchConfiguration => new PSIntegrationAccountBatchConfiguration(batchConfiguration));
        }

        /// <summary>
        /// Removes the specified integration account batch configuration.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountBatchConfigurationName">The integration account batch configuration name.</param>
        public void RemoveIntegrationAccountBatchConfiguration(string resourceGroupName, string integrationAccountName, string integrationAccountBatchConfigurationName)
        {
            this.LogicManagementClient.IntegrationAccountAssemblies.Delete(resourceGroupName, integrationAccountName, integrationAccountBatchConfigurationName);
        }
    }
}