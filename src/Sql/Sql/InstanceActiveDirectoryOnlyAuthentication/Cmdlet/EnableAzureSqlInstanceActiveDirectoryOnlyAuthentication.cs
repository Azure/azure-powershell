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

using Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryOnlyAuthentication.Model;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryOnlyAuthentication.Cmdlet
{
    /// <summary>
    /// Disables the Azure Active Directory only authentication of a specific SQL Managed Instance.
    /// </summary>
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceActiveDirectoryOnlyAuthentication", DefaultParameterSetName = UseResourceGroupAndInstanceNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel))]
    public class EnableAzureSqlInstanceActiveDirectoryOnlyAuthentication : AzureSqlInstanceActiveDirectoryOnlyAuthenticationCmdletBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel> GetEntity()
        {
            List<AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel> currentActiveDirectoryOnlyAuthentications = null;

            try
            {
                AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel model = ModelAdapter.GetInstanceActiveDirectoryOnlyAuthentication(GetResourceGroupName(), GetInstanceName());

                if (model != null)
                {
                    currentActiveDirectoryOnlyAuthentications = new List<AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel>();
                    currentActiveDirectoryOnlyAuthentications.Add(model);
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

            return currentActiveDirectoryOnlyAuthentications;
        }

        /// <summary>
        /// Create the list of models from a list of user input
        /// </summary>
        /// <param name="model">A IEnumerable of models retrieved from service</param>
        /// <returns>A list of models that was passed in</returns>
        protected override IEnumerable<AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel> model)
        {
            List<Model.AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel> newEntity = new List<AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel>();
            newEntity.Add(new AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel()
            {
                ResourceGroupName = GetResourceGroupName(),
                InstanceName = GetInstanceName(),
                AzureADOnlyAuthentication = true
            });
            return newEntity;
        }

        /// <summary>
        /// Update the Azure SQL Managed Instance Active Directory only authentication
        /// </summary>
        /// <param name="entity">A list of models to update the list</param>
        /// <returns>A list of the persisted entities</returns>
        protected override IEnumerable<AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel> PersistChanges(IEnumerable<AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel> entity)
        {
            return new List<AzureSqlInstanceActiveDirectoryOnlyAuthenticationModel>() {
                ModelAdapter.UpsertAzureADOnlyAuthenticaion(GetResourceGroupName(), GetInstanceName(), entity.FirstOrDefault())
            };
        }
    }
}
