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
<<<<<<< HEAD

using Hyak.Common;
using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Model;
=======
using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Model;
using Microsoft.Rest.Azure;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure SQL Server Active Directory administrator
    /// </summary>
<<<<<<< HEAD
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerActiveDirectoryAdministrator",ConfirmImpact = ConfirmImpact.Medium, SupportsShouldProcess = true), OutputType(typeof(AzureSqlServerActiveDirectoryAdministratorModel))]
=======
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerActiveDirectoryAdministrator", ConfirmImpact = ConfirmImpact.Medium, SupportsShouldProcess = true), OutputType(typeof(AzureSqlServerActiveDirectoryAdministratorModel))]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    public class SetAzureSqlServerActiveDirectoryAdministrator : AzureSqlServerActiveDirectoryAdministratorCmdletBase
    {
        /// <summary>
        /// Azure Active Directory display name for a user or group
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Specifies the display name of the user or group for whom to grant permissions. This display name must exist in the active directory associated with the current subscription.")]
        [ValidateNotNullOrEmpty()]
        public string DisplayName { get; set; }

        /// <summary>
        /// Azure Active Directory object id for a user or group
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Specifies the object ID of the user or group in Azure Active Directory for which to grant permissions.")]
        [ValidateNotNullOrEmpty()]
        public Guid ObjectId { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerActiveDirectoryAdministratorModel> GetEntity()
        {
            List<AzureSqlServerActiveDirectoryAdministratorModel> currentActiveDirectoryAdmins = null;
<<<<<<< HEAD
            try
            {
                currentActiveDirectoryAdmins = new List<AzureSqlServerActiveDirectoryAdministratorModel>()
                {
                    ModelAdapter.GetServerActiveDirectoryAdministrator(this.ResourceGroupName, this.ServerName),
                };
=======

            try
            {
                AzureSqlServerActiveDirectoryAdministratorModel model = ModelAdapter.GetServerActiveDirectoryAdministrator(this.ResourceGroupName, this.ServerName);

                if (model != null)
                {
                    currentActiveDirectoryAdmins = new List<AzureSqlServerActiveDirectoryAdministratorModel>();
                    currentActiveDirectoryAdmins.Add(model);
                }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    // Unexpected exception encountered
                    throw;
                }
            }
<<<<<<< HEAD
=======
            catch (Exception ex)
            {
                if ((ex.InnerException is CloudException ex1) &&
                     ex1.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw ex.InnerException ?? ex;
                }
            }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            return currentActiveDirectoryAdmins;
        }

        /// <summary>
        /// Create the list of models from a list of user input
        /// </summary>
        /// <param name="model">A IEnumerable of models retrieved from service</param>
        /// <returns>A list of models that was passed in</returns>
        protected override IEnumerable<AzureSqlServerActiveDirectoryAdministratorModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerActiveDirectoryAdministratorModel> model)
        {
<<<<<<< HEAD
            List<Model.AzureSqlServerActiveDirectoryAdministratorModel> newEntity = new List<AzureSqlServerActiveDirectoryAdministratorModel>();
=======
            List<Model.AzureSqlServerActiveDirectoryAdministratorModel> newEntity  = new List<AzureSqlServerActiveDirectoryAdministratorModel>();
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            newEntity.Add(new AzureSqlServerActiveDirectoryAdministratorModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                DisplayName = DisplayName,
<<<<<<< HEAD
                ObjectId = ObjectId,
=======
                ObjectId = ObjectId
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            });
            return newEntity;
        }

        /// <summary>
        /// Update the Azure SQL Server Active Directory administrator
        /// </summary>
        /// <param name="entity">A list of models to update the list</param>
        /// <returns>A list of the persisted entities</returns>
        protected override IEnumerable<AzureSqlServerActiveDirectoryAdministratorModel> PersistChanges(IEnumerable<AzureSqlServerActiveDirectoryAdministratorModel> entity)
        {
            return new List<AzureSqlServerActiveDirectoryAdministratorModel>() {
                ModelAdapter.UpsertServerActiveDirectoryAdministrator(this.ResourceGroupName, this.ServerName, entity.First())
            };
        }
    }
}
