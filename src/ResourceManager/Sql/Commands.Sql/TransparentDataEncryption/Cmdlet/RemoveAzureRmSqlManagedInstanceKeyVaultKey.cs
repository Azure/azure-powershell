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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Adapter;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;


namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzureRmSqlManagedInstanceKeyVaultKey cmdlet
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceKeyVaultKey", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureRmSqlManagedInstanceKeyVaultKeyModel))]
    public class RemoveAzureRmSqlManagedInstanceKeyVaultKey : AzureRmSqlManagedInstanceKeyVaultKeyBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> GetEntity()
        {
            AzureRmSqlManagedInstanceKeyVaultKeyModel azureRmSqlManagedInstanceKeyVaultKeyModel = new AzureRmSqlManagedInstanceKeyVaultKeyModel(
                resourceGroupName: this.ResourceGroupName,
                managedInstanceName: this.InstanceName,
                keyId: this.KeyId);

            return new List<AzureRmSqlManagedInstanceKeyVaultKeyModel>() {
                ModelAdapter.GetAzureRmSqlManagedInstanceKeyVaultKey(azureRmSqlManagedInstanceKeyVaultKeyModel)
            };
        }
        /// <summary>
        /// Sends the Firewall Rule update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> PersistChanges(IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> entity)
        {
            AzureRmSqlManagedInstanceKeyVaultKeyModel azureRmSqlManagedInstanceKeyVaultKeyModel = new AzureRmSqlManagedInstanceKeyVaultKeyModel(
                resourceGroupName: this.ResourceGroupName,
                managedInstanceName: this.InstanceName,
                keyId: this.KeyId);

            ModelAdapter.RemoveAzureRmSqlManagedInstanceKeyVaultKey(azureRmSqlManagedInstanceKeyVaultKeyModel);
            return entity;
        }
    }
}
