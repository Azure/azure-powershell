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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Model;
using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Services;

namespace Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlServerKeyVaultKey cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlServerKeyVaultKey", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    public class GetAzureSqlServerKeyVaultKey : AzureSqlServerKeyVaultKeyCmdletBase
    {
        /// <summary>
        /// Gets or sets the KeyId of the Azure Key Vault Key
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The Azure Key Vault KeyId.")]
        [ValidateNotNullOrEmpty]
        public string KeyId { get; set; }

        /// <summary>
        /// Gets an Azure Sql Server Key Vault Key.
        /// </summary>
        /// <returns>If a keyId is specified, a single Server Key Vault Key, otherwise, all the Server Key Vault Keys on the Server</returns>
        protected override IEnumerable<AzureSqlServerKeyVaultKeyModel> GetEntity()
        {
            IList<AzureSqlServerKeyVaultKeyModel> results = new List<AzureSqlServerKeyVaultKeyModel>();

            // If no KeyId is supplied, then list all the server key vault keys
            //
            if (!this.MyInvocation.BoundParameters.ContainsKey("KeyId"))
            {
                results = ModelAdapter.List(this.ResourceGroupName, this.ServerName);
            }
            else
            {
                results.Add(ModelAdapter.Get(this.ResourceGroupName, this.ServerName, KeyId));
            }

            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlServerKeyVaultKeyModel> PersistChanges(IEnumerable<AzureSqlServerKeyVaultKeyModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlServerKeyVaultKeyModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerKeyVaultKeyModel> model)
        {
            return model;
        }
    }
}
