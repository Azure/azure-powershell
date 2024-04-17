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
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlServer cmdlet
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServer", ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true), OutputType(typeof(Model.AzureSqlServerModel))]
    public class NewAzureSqlServer : AzureSqlServerCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "SQL Database server name.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// The SQL administrator credentials for the server
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The SQL administrator credentials for the server. Optional when Azure Active Directory only is enabled and an Azure Active Directory administrator is specified.")]
        public PSCredential SqlAdministratorCredentials { get; set; }

        /// <summary>
        /// The location in which to create the server
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The location in which to create the server")]
        [LocationCompleter("Microsoft.Sql/servers")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// The tags to associate with the Azure Sql Database Server
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Server")]
        [Alias("Tag")]
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Gets or sets the server version
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Determines which version of Sql Azure Server is created")]
        [ValidateNotNullOrEmpty]
        public string ServerVersion { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Generate and assign a Microsoft Entra Identity for this server for use with key management services like Azure KeyVault.")]
        public SwitchParameter AssignIdentity { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Takes a flag, enabled/disabled, to specify whether public network access to server is allowed or not. When disabled, only connections made through Private Links can reach this server.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string PublicNetworkAccess { get; set; }
        
        [Parameter(Mandatory = false,
            HelpMessage = "When enabled, only outbound connections allowed by the outbound firewall rules will succeed.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string RestrictOutboundNetworkAccess { get; set; }

        /// <summary>
        /// Gets or sets the managed instance minimal tls version
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Minimal Tls Version for the Sql Azure Managed Instance. Options are: 1.0, 1.1 and 1.2 ")]
        [ValidateSet("None", "1.0", "1.1", "1.2")]
        [PSArgumentCompleter("None", "1.0", "1.1", "1.2")]
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

        /// <summary>
        /// List of user assigned identities.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "List of user assigned identities")]
        public List<string> UserAssignedIdentityId { get; set; }

        /// <summary>
        /// Type of identity to be assigned to the server..
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Type of Identity to be used. Possible values are SystemAssigned, UserAssigned, 'SystemAssigned,UserAssigned' and None.")]
        [PSArgumentCompleter("SystemAssigned", "UserAssigned", "\"SystemAssigned,UserAssigned\"", "None")]
        public string IdentityType { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Enable Active Directory Only Authentication on the server
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Enable Active Directory Only Authentication on the server.")]
        public SwitchParameter EnableActiveDirectoryOnlyAuthentication { get; set; }

        /// <summary>
        /// Azure Active Directory display name for a user or group
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies the display name of the user, group or application which is the Microsoft Entra administrator for the server. This display name must exist in the active directory associated with the current subscription.")]
        public string ExternalAdminName { get; set; }

        /// <summary>
        /// Azure Active Directory object id for a user, group or application
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies the object ID of the user, group or application which is the Microsoft Entra administrator.")]
        public Guid? ExternalAdminSID { get; set; }

        /// <summary>
        /// The Federated Client id use in server for cross tenant cmk
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies the Federated client ID of the server when using Cross-Tenant CMK, Do not set this value if you do not intent to use Cross-Tenant CMK")]
        public Guid? FederatedClientId { get; set; }

        /// <summary>
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (this.EnableActiveDirectoryOnlyAuthentication.IsPresent && this.ExternalAdminName == null)
            {
                throw new PSArgumentException(Properties.Resources.MissingExternalAdmin, "ExternalAdminName");
            }

            if (!this.EnableActiveDirectoryOnlyAuthentication.IsPresent && this.SqlAdministratorCredentials == null)
            {
                throw new PSArgumentException(Properties.Resources.MissingSQLAdministratorCredentials, "SqlAdministratorCredentials");
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the server already exists in this resource group.
        /// </summary>
        /// <returns>Null if the server doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetServer(this.ResourceGroupName, this.ServerName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no server with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The server already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerNameExists, this.ServerName),
                "ServerName");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the server doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerModel> model)
        {
            if (!Sql.Services.Util.ValidateServerName(this.ServerName))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ServerNameInvalid, this.ServerName), "ServerName");
            }

            List<Model.AzureSqlServerModel> newEntity = new List<Model.AzureSqlServerModel>();
            newEntity.Add(new Model.AzureSqlServerModel()
            {
                Location = this.Location,
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                ServerVersion = this.ServerVersion,
                SqlAdministratorPassword = (this.SqlAdministratorCredentials != null) ? this.SqlAdministratorCredentials.Password : null,
                SqlAdministratorLogin = (this.SqlAdministratorCredentials != null) ? this.SqlAdministratorCredentials.UserName : null,
                Tags = TagsConversionHelper.CreateTagDictionary(Tags, validate: true),
                Identity = ResourceIdentityHelper.GetIdentityObjectFromType(this.AssignIdentity.IsPresent, this.IdentityType ?? null, UserAssignedIdentityId, null),
                MinimalTlsVersion = (this.MinimalTlsVersion != null) ? this.MinimalTlsVersion : "1.2",
                PublicNetworkAccess = this.PublicNetworkAccess,
                RestrictOutboundNetworkAccess = this.RestrictOutboundNetworkAccess,
                PrimaryUserAssignedIdentityId = this.PrimaryUserAssignedIdentityId,
                KeyId = this.KeyId,
                FederatedClientId = this.FederatedClientId,
                Administrators = new Management.Sql.Models.ServerExternalAdministrator()
                {
                    AzureAdOnlyAuthentication = (this.EnableActiveDirectoryOnlyAuthentication.IsPresent) ? (bool?)true : null,
                    Login = this.ExternalAdminName,
                    Sid = this.ExternalAdminSID
                }              
            });
            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the server
        /// </summary>
        /// <param name="entity">The server to create</param>
        /// <returns>The created server</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> PersistChanges(IEnumerable<Model.AzureSqlServerModel> entity)
        {
            return new List<Model.AzureSqlServerModel>() {
                ModelAdapter.UpsertServer(entity.First())
            };
        }
    }
}
