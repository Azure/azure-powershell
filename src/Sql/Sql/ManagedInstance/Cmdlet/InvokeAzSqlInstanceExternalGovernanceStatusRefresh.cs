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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceExternalGovernanceStatusRefresh", SupportsShouldProcess = true), OutputType(typeof(RefreshExternalGovernanceMIModel))]
    public class InvokeAzSqlInstanceExternalGovernanceStatusRefresh : AzureSqlInstanceRefreshExternalGovernanceCmdletBase
    {
        /// <summary>
        /// Get the refresh external governance status.
        /// </summary>
        /// <returns>Refresh external governance status.</returns>
        protected override RefreshExternalGovernanceMIModel GetEntity()
        {
            return new RefreshExternalGovernanceMIModel();
        }

        /// <summary>
        /// Apply user input to model.
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override RefreshExternalGovernanceMIModel ApplyUserInputToModel(RefreshExternalGovernanceMIModel model)
        {
            model.ResourceGroupName = ResourceGroupName;
            model.InstanceName = InstanceName;
            return model;
        }

        /// <summary>
        /// Sends the refresh external governance status to the service.
        /// </summary>
        /// <param name="entity">The refresh external governance entity.</param>
        /// <returns>The response object from the service</returns>
        protected override RefreshExternalGovernanceMIModel PersistChanges(RefreshExternalGovernanceMIModel entity)
        {
            return ModelAdapter.RefreshExternalGovernanceStatus(entity.ResourceGroupName, entity.InstanceName);
        }
    }
}
