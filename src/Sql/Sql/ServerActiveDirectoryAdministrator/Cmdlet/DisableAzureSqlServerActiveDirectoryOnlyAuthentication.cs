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

using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Model;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerActiveDirectoryAdministrator.Cmdlet
{
    /// <summary>
    /// Disables the Azure Active Directory only authentication of a specific SQL server.
    /// </summary>
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerActiveDirectoryOnlyAuthentication", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlServerActiveDirectoryAdministratorModel))]
    public class DisableAzureSqlServerActiveDirectoryOnlyAuthentication : AzureSqlServerActiveDirectoryAdministratorCmdletBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerActiveDirectoryAdministratorModel> GetEntity()
        {
            List<AzureSqlServerActiveDirectoryAdministratorModel> currentActiveDirectoryAdmins = null;

            try
            {
                AzureSqlServerActiveDirectoryAdministratorModel model = ModelAdapter.GetServerActiveDirectoryAdministrator(this.ResourceGroupName, this.ServerName);

                if (model != null)
                {
                    currentActiveDirectoryAdmins = new List<AzureSqlServerActiveDirectoryAdministratorModel>();
                    currentActiveDirectoryAdmins.Add(model);
                }
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    // Unexpected exception encountered
                    throw;
                }
            }
            catch (Exception ex)
            {
                if ((ex.InnerException is CloudException ex1) &&
                     ex1.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw ex.InnerException ?? ex;
                }
            }

            return currentActiveDirectoryAdmins;
        }

        /// <summary>
        /// Update the Azure SQL Server Active Directory administrator
        /// </summary>
        /// <param name="entity">A list of models to update the list</param>
        /// <returns>A list of the persisted entities</returns>
        protected override IEnumerable<AzureSqlServerActiveDirectoryAdministratorModel> PersistChanges(IEnumerable<AzureSqlServerActiveDirectoryAdministratorModel> entity)
        {
            return new List<AzureSqlServerActiveDirectoryAdministratorModel>() {
                ModelAdapter.DisableAzureADOnlyAuthenticaion(this.ResourceGroupName, this.ServerName)
            };
        }
    }
}
