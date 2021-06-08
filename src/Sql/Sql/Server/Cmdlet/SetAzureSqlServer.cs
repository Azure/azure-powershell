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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlServer cmdlet
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(Model.AzureSqlServerModel))]
    public class SetAzureSqlServer : AzureSqlServerCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "SQL Database server name.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// The new SQL administrator password for the server.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The new SQL administrator password for the server.")]
        [ValidateNotNull]
        public SecureString SqlAdministratorPassword { get; set; }

        /// <summary>
        /// The tags to associate with the server.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the server.")]
        [Alias("Tag")]
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Gets or sets the server version
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Which server version to change to.")]
        [ValidateNotNullOrEmpty]
        public string ServerVersion { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Generate and assign an Azure Active Directory Identity for this server for use with key management services like Azure KeyVault.")]
        public SwitchParameter AssignIdentity { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Takes a flag, enabled/disabled, to specify whether public network access to server is allowed or not. When disabled, only connections made through Private Links can reach this server.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string PublicNetworkAccess { get; set; }

        /// <summary>
        /// Gets or sets the sql server minimal tls version
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Minimal Tls Version for the Sql Azure Managed Instance. Options are: 1.0, 1.1 and 1.2 ")]
        [ValidateSet("1.0", "1.1", "1.2")]
        [PSArgumentCompleter("1.0", "1.1", "1.2")]
        public string MinimalTlsVersion { get; set; }

        /// <summary>
        /// Id of the primary user assigned identity
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The primary user managed identity(UMI) id")]
        public string PrimaryUserAssignedIdentityId { get; set; }

        /// <summary>
        /// URI of the key to use for encryption
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Key Vault URI for encryption")]
        public string KeyId { get; set; }

        // <summary>
        /// List of user assigned identities.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "List of user assigned identities")]
        public List<string> UserAssignedIdentityId { get; set; }

        // <summary>
        /// Type of identity to be assigned to the server..
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Type of Identity to be used. Possible values are SystemAsssigned, UserAssigned, SystemAssignedUserAssigned and None.")]
        [PSArgumentCompleter("SystemAssigned", "UserAssigned", "SystemAssignedUserAssigned", "None")]
        public string IdentityType { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Get the server to update
        /// </summary>
        /// <returns>The server being updated</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> GetEntity()
        {
            return new List<Model.AzureSqlServerModel>() { ModelAdapter.GetServer(this.ResourceGroupName, this.ServerName) };
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerModel> model)
        {
            if (!Sql.Services.Util.ValidateServerName(this.ServerName))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ServerNameInvalid, this.ServerName), "ServerName");
            }

            // Construct a new entity so we only send the relevant data to the server
            List<Model.AzureSqlServerModel> updateData = new List<Model.AzureSqlServerModel>();
            updateData.Add(new Model.AzureSqlServerModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                SqlAdministratorPassword = this.SqlAdministratorPassword,
                Tags = TagsConversionHelper.ReadOrFetchTags(this, model.FirstOrDefault().Tags),
                ServerVersion = this.ServerVersion,
                Location = model.FirstOrDefault().Location,
                Identity = ResourceIdentityHelper.GetIdentityObjectFromType(this.AssignIdentity.IsPresent, this.IdentityType ?? null, UserAssignedIdentityId, model.FirstOrDefault().Identity),
                PublicNetworkAccess = this.PublicNetworkAccess,
                MinimalTlsVersion = this.MinimalTlsVersion,
                SqlAdministratorLogin = model.FirstOrDefault().SqlAdministratorLogin,
                PrimaryUserAssignedIdentityId = this.PrimaryUserAssignedIdentityId ?? model.FirstOrDefault().PrimaryUserAssignedIdentityId,
                KeyId = this.KeyId
            });
            return updateData;
        }

        /// <summary>
        /// Sends the server update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> PersistChanges(IEnumerable<Model.AzureSqlServerModel> entity)
        {
            return new List<Model.AzureSqlServerModel>() { ModelAdapter.UpsertServer(entity.First()) };
        }
    }
}
