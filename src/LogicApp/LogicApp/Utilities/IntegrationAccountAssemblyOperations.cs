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
    /// LogicApp client partial class for integration account assembly operations.
    /// </summary>
    public partial class IntegrationAccountClient
    {
        /// <summary>
        /// Creates integration account assembly.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAssemblyName">The integration account assembly name.</param>
        /// <param name="integrationAccountAssembly">The integration account assembly object.</param>
        /// <returns>Newly created integration account assembly object.</returns>
        public PSIntegrationAccountAssembly CreateIntegrationAccountAssembly(string resourceGroupName, string integrationAccountName, string integrationAccountAssemblyName, AssemblyDefinition integrationAccountAssembly)
        {
            if (!this.DoesIntegrationAccountAssemblyExist(resourceGroupName, integrationAccountName, integrationAccountAssemblyName))
            {
                var assembly = this.LogicManagementClient.IntegrationAccountAssemblies.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountAssemblyName, integrationAccountAssembly);

                return new PSIntegrationAccountAssembly(assembly);
            }
            else
            {
                throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, Properties.Resource.ResourceAlreadyExists, integrationAccountAssemblyName, resourceGroupName));
            }
        }

        /// <summary>
        /// Checks whether the integration account assembly exists or not. 
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account object.</param>
        /// <param name="integrationAccountAssemblyName">The integration account assembly name.</param>
        /// <returns>Boolean result indicating whether the integration account assembly exists or not.</returns>
        private bool DoesIntegrationAccountAssemblyExist(string resourceGroupName, string integrationAccountName, string integrationAccountAssemblyName)
        {
            var result = false;
            try
            {
                var assembly = this.LogicManagementClient.IntegrationAccountAssemblies.Get(resourceGroupName, integrationAccountName, integrationAccountAssemblyName);
                result = assembly != null;
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
        /// <param name="resourceGroupName">The integration account assembly resource group.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAssemblyName">The integration account assembly name.</param>
        /// <param name="integrationAccountAssembly">The integration account assembly object.</param>
        /// <returns>Updated integration account assembly</returns>
        public PSIntegrationAccountAssembly UpdateIntegrationAccountAssembly(string resourceGroupName, string integrationAccountName, string integrationAccountAssemblyName, AssemblyDefinition integrationAccountAssembly)
        {
            var updatedAssembly = this.LogicManagementClient.IntegrationAccountAssemblies.CreateOrUpdate(resourceGroupName, integrationAccountName, integrationAccountAssemblyName, integrationAccountAssembly);

            return new PSIntegrationAccountAssembly(updatedAssembly);
        }

        /// <summary>
        /// Gets the integration account assembly by name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAssemblyName">The integration account assembly name.</param>
        /// <returns>Integration account assembly object.</returns>
        public PSIntegrationAccountAssembly GetIntegrationAccountAssembly(string resourceGroupName, string integrationAccountName, string integrationAccountAssemblyName)
        {
            var assembly = this.LogicManagementClient.IntegrationAccountAssemblies.Get(resourceGroupName, integrationAccountName, integrationAccountAssemblyName);

            return new PSIntegrationAccountAssembly(assembly);
        }

        /// <summary>
        /// Gets the integration account assemblies by resource group name.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <returns>List of integration account assemblies.</returns>
        public IEnumerable<PSIntegrationAccountAssembly> ListIntegrationAccountAssemblies(string resourceGroupName, string integrationAccountName)
        {
            var assemblies = this.LogicManagementClient.IntegrationAccountAssemblies.List(resourceGroupName, integrationAccountName);

            return assemblies.Select(assembly => new PSIntegrationAccountAssembly(assembly));
        }

        /// <summary>
        /// Removes the specified integration account assembly.
        /// </summary>
        /// <param name="resourceGroupName">The integration account resource group name.</param>
        /// <param name="integrationAccountName">The integration account name.</param>
        /// <param name="integrationAccountAssemblyName">The integration account assembly name.</param>
        public void RemoveIntegrationAccountAssembly(string resourceGroupName, string integrationAccountName, string integrationAccountAssemblyName)
        {
            this.LogicManagementClient.IntegrationAccountAssemblies.Delete(resourceGroupName, integrationAccountName, integrationAccountAssemblyName);
        }
    }
}