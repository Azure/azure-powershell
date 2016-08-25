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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlServer cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlServer",
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlServer : AzureSqlServerCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "SQL Database server name.")]
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

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

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
            // Construct a new entity so we only send the relevant data to the server
            List<Model.AzureSqlServerModel> updateData = new List<Model.AzureSqlServerModel>();
            updateData.Add(new Model.AzureSqlServerModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                SqlAdministratorPassword = this.SqlAdministratorPassword,
                Tags = TagsConversionHelper.CreateTagDictionary(Tags, validate: true),
                ServerVersion = this.ServerVersion,
                Location = model.FirstOrDefault().Location,
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
