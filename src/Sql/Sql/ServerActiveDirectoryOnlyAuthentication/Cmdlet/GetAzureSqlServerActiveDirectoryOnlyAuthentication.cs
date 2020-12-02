﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Sql.ServerActiveDirectoryOnlyAuthentication.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerActiveDirectoryOnlyAuthentication.Cmdlet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerActiveDirectoryOnlyAuthentication", DefaultParameterSetName = UseResourceGroupAndServerNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlServerActiveDirectoryOnlyAuthenticationModel))]
    public class GetAzureSqlServerActiveDirectoryOnlyAuthentication : AzureSqlServerActiveDirectoryOnlyAuthenticationCmdletBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerActiveDirectoryOnlyAuthenticationModel> GetEntity()
        {
            ICollection<AzureSqlServerActiveDirectoryOnlyAuthenticationModel> results;

            results = ModelAdapter.ListServerActiveDirectoryOnlyAuthentications(GetResourceGroupName(), GetServerName());

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerActiveDirectoryOnlyAuthenticationModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerActiveDirectoryOnlyAuthenticationModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerActiveDirectoryOnlyAuthenticationModel> PersistChanges(IEnumerable<AzureSqlServerActiveDirectoryOnlyAuthenticationModel> entity)
        {
            return entity;
        }
    }
}
