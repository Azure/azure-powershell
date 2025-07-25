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

using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Cmdlet
{
    /// <summary>
    /// Defines the Revalidate-AzSqlServerTransparentDataEncryptionProtector cmdlet
    /// </summary>
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerTransparentDataEncryptionProtectorRevalidation", SupportsShouldProcess = true), OutputType(typeof(AzureSqlServerTransparentDataEncryptionProtectorModel))]
    public class InvokeAzureSqlServerTransparentDataEncryptionProtectorRevalidation : AzureSqlServerTransparentDataEncryptionProtectorCmdletBase
    {
        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Get the Transparent Data Encryption to revalidate
        /// </summary>
        /// <returns>The Transparent Data Encryption being revalidated</returns>
        protected override IEnumerable<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> GetEntity()
        {
            return new List<Model.AzureSqlServerTransparentDataEncryptionProtectorModel>() { ModelAdapter.GetEncryptionProtector(this.ResourceGroupName, this.ServerName) };
        }
        
        /// <summary>
        /// No change to the model
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> model)
        {
            return model;
        }

        /// <summary>
        /// Sends the TDE protector revalidate request to the service
        /// </summary>
        /// <param name="entity">The encryption protector entity to revalidate</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> PersistChanges(IEnumerable<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> entity)
        {
            ModelAdapter.RevalidateEncryptionProtector(entity.First().ResourceGroupName, entity.First().ServerName);
            return entity;
        }
    }
}
