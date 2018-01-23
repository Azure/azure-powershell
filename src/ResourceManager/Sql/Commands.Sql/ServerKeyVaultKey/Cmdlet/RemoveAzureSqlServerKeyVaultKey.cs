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
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Model;
using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Services;

namespace Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzureRmSqlServerKeyVaultKey cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlServerKeyVaultKey", SupportsShouldProcess = true)]
    public class RemoveAzureSqlServerKeyVaultKey : AzureSqlServerKeyVaultKeyCmdletBase
    {
        /// <summary>
        /// Gets or sets the KeyId of the Azure Key Vault Key
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The Azure Key Vault KeyId.")]
        [ValidateNotNullOrEmpty]
        public string KeyId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerKeyVaultKeyModel> GetEntity()
        {
            return new List<AzureSqlServerKeyVaultKeyModel>() {
                ModelAdapter.Get(this.ResourceGroupName, this.ServerName, this.KeyId)
            };
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerKeyVaultKeyModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerKeyVaultKeyModel> model)
        {
            return model;
        }

        /// <summary>
        /// Removes the ServerKeyVaultKey with KeyId from the server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerKeyVaultKeyModel> PersistChanges(IEnumerable<AzureSqlServerKeyVaultKeyModel> entity)
        {
            ModelAdapter.Delete(this.ResourceGroupName, this.ServerName, this.KeyId);
            return entity;
        }
    }
}
