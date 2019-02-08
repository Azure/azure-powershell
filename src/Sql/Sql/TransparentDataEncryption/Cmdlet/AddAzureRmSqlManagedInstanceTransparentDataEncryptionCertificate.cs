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
    /// Defines the Add-AzSqlManagedInstanceTransparentDataEncryptionCertificate cmdlet
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlManagedInstanceTransparentDataEncryptionCertificate", ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class AddAzureRmSqlManagedInstanceTransparentDataEncryptionCertificate : AzureSqlCmdletBase<IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel>, AzureSqlDatabaseTransparentDataEncryptionArmAdapter>
    {
        /// <summary>
        /// Parameter sets
        /// </summary>
        protected const string DefaultParameterSet = "AddAzureRmSqlManagedInstanceTransparentDataEncryptionCertificateDefaultParameterSet";
        
        /// <summary>
        ///  Defines whether the certificate was successfully added
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 0,
            HelpMessage = "The Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the agent server name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 1,
            HelpMessage = "The managed instance name")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string ManagedInstanceName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 2,
            HelpMessage = "The Private blob for Transparent Data Encryption Certificate. For detailed instructions on how to generate the blob go to https://aka.ms/tdecertprep")]
        [ValidateNotNullOrEmpty]
        public SecureString PrivateBlob { get; set; }

        /// <summary>
        /// Gets or sets the Password for Transparent Data Encryption Certificate
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 3,
            HelpMessage = "The Password for Transparent Data Encryption Certificate")]
        public SecureString Password { get; set; }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <returns>The server adapter</returns>
        protected override AzureSqlDatabaseTransparentDataEncryptionArmAdapter InitModelAdapter()
        {
            return new AzureSqlDatabaseTransparentDataEncryptionArmAdapter(DefaultProfile.DefaultContext);
        }
        
        /// <summary>
        /// Get entity returns null since the certificate has not been added.
        /// </summary>
        /// <returns>null, since the certificate does not exist</returns>
        protected override IEnumerable<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel> GetEntity()
        {
            return null;
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model"> Model to send to the update API</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel> ApplyUserInputToModel(IEnumerable<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel> model)
        {
            // Construct a new entity so we only send the relevant data to the server
            List<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel> newEntity = new List<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel>();
            newEntity.Add(new Model.AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ManagedInstanceName = this.ManagedInstanceName,
                PrivateBlob = this.PrivateBlob,
                Password = this.Password
            });
            return newEntity;
        }

        /// <summary>
        /// Sends the Firewall Rule update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel> PersistChanges(IEnumerable<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionCertificateModel> entity)
        {
            ModelAdapter.AddAzureRmSqlManagedInstanceTransparentDataEncryptionCertificate(entity.First());
            return entity;
        }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }
    }
}
