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

using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Management.Sql.DataSyncV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to update an existing sync member
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlSyncMemberV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(AzureSqlSyncMemberModelV2))]
    public class UpdateAzureSqlSyncMemberV2 : AzureSqlSyncMemberCmdletBaseV2
    {
        /// <summary>
        /// Gets or sets the sync member name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The sync member name.")]
        [Alias("SyncMemberName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the credential (username and password) of the Azure SQL Database. 
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The credential (username and password) of the Azure SQL Database.")]
        public PSCredential MemberDatabaseCredential { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use private link connection
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Whether to use private link when connecting to this sync member.")]
        public bool? UsePrivateLinkConnection { get; set; }

        /// <summary>
        /// Gets or sets the sync member resource Id
        /// </summary>
        /// <value>
        /// The sync member database id (only for sync member using Azure SQL Database), e.g. "subscriptions/{subscriptionId}/resourceGroups/{syncDatabaseResourceGroup01}/servers/{syncMemberServer01}/databases/{syncMemberDatabaseName01}"
        /// </value>
        /// <remarks>
        /// This needs to be a sync member sql azure database id (i.e. full arm uri) so that we can validate calling user's R/W access to this database via RBAC.
        /// </remarks>
        [Parameter(Mandatory = false, HelpMessage = "The resource ID for the sync member database, used if UsePrivateLinkConnection is set to true.")]
        public string SyncMemberAzureDatabaseResourceId { get; set; }

        ///<summary>
        /// Gets or sets the Database Authentication type of the sync member database
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Database Authentication type of the sync member database.")]
        [ValidateSet("password", "userAssigned", IgnoreCase = true)]
        public string MemberDatabaseAuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets the identity ID of the sync member database in case of user assigned identity authentication
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The identity ID of the sync member DB in case of UAMI Authentication")]
        public string IdentityId { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncMemberModelV2> GetEntity()
        {
            return new List<AzureSqlSyncMemberModelV2>() {
               ModelAdapter.GetSyncMember(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName, this.Name)
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlSyncMemberModelV2> ApplyUserInputToModel(IEnumerable<AzureSqlSyncMemberModelV2> model)
        {
            AzureSqlSyncMemberModelV2 newModel = model.First();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UsePrivateLinkConnection)))
            {
                if (this.UsePrivateLinkConnection.GetValueOrDefault() && !MyInvocation.BoundParameters.ContainsKey(nameof(SyncMemberAzureDatabaseResourceId)))
                {
                    throw new PSArgumentException(
                        Microsoft.Azure.Commands.Sql.Properties.Resources.SyncMemberIdRequired, nameof(SyncMemberAzureDatabaseResourceId));
                }

                newModel.UsePrivateLinkConnection = this.UsePrivateLinkConnection;
                newModel.SyncMemberAzureDatabaseResourceId = this.SyncMemberAzureDatabaseResourceId;
            }


            if (!MyInvocation.BoundParameters.ContainsKey(nameof(MemberDatabaseAuthenticationType)) ||
                this.MemberDatabaseAuthenticationType.Equals("password", StringComparison.OrdinalIgnoreCase))
            {
                if (MyInvocation.BoundParameters.ContainsKey("MemberDatabaseCredential"))
                {
                    newModel.MemberDatabaseUserName = this.MemberDatabaseCredential.UserName;
                    newModel.MemberDatabasePassword = this.MemberDatabaseCredential.Password;
                }
                else
                {
                    newModel.MemberDatabaseUserName = null;
                    newModel.MemberDatabasePassword = null;
                }

                newModel.Identity = new DataSyncParticipantIdentity
                {
                    Type = "None"
                };
            }
            else if (this.MemberDatabaseAuthenticationType.Equals("userAssigned", StringComparison.OrdinalIgnoreCase))
            {
                if (!MyInvocation.BoundParameters.ContainsKey(nameof(IdentityId)) ||
                    string.IsNullOrEmpty(this.IdentityId))
                {
                    newModel.Identity = new DataSyncParticipantIdentity
                    {
                        Type = "UserAssigned"
                    };
                }
                else
                {
                    newModel.Identity = AzureSqlSyncIdentityHelper.CreateUserAssignedIdentity(this.IdentityId);
                }
            }
            else
            {
                throw new PSArgumentException(
                        Microsoft.Azure.Commands.Sql.Properties.Resources.InvalidDatabaseAuthenticationType,
                        nameof(MemberDatabaseAuthenticationType));
            }

            return model;
        }

        /// <summary>
        /// Update the sync member
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncMemberModelV2> PersistChanges(IEnumerable<AzureSqlSyncMemberModelV2> entity)
        {
            return new List<AzureSqlSyncMemberModelV2>() {
                ModelAdapter.UpdateSyncMember(entity.First())
            };
        }
    }
}
