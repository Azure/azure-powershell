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
    /// Defines the Add-AzureSqlInstanceKeyVaultKey cmdlet
    /// </summary>
    ///
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceKeyVaultKey", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureRmSqlManagedInstanceKeyVaultKeyModel))]
    public class AddAzureRmSqlManagedInstanceKeyVaultKey : AzureRmSqlManagedInstanceKeyVaultKeyBase
    {
        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">Model to send to the update API</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> ApplyUserInputToModel(IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> model)
        {
            // Construct a new entity so we only send the relevant data to the server
            List<AzureRmSqlManagedInstanceKeyVaultKeyModel> newEntity = new List<AzureRmSqlManagedInstanceKeyVaultKeyModel>();
            newEntity.Add(new AzureRmSqlManagedInstanceKeyVaultKeyModel(
                resourceGroupName: this.ResourceGroupName,
                managedInstanceName: this.InstanceName,
                keyId: this.KeyId));
            return newEntity;
        }

        /// <summary>
        /// Sends the Firewall Rule update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> PersistChanges(IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> entity)
        {
            return new List<AzureRmSqlManagedInstanceKeyVaultKeyModel>() {
                ModelAdapter.AddAzureRmSqlManagedInstanceKeyVaultKey(entity.First())
            };
        }
    }
}
