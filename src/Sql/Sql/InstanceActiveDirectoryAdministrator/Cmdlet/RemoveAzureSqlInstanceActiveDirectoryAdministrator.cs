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

using Microsoft.Azure.Commands.Sql.Auditing;
using Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryAdministrator.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.InstanceActiveDirectoryAdministrator.Cmdlet
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceActiveDirectoryAdministrator", DefaultParameterSetName = UseResourceGroupAndInstanceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(AzureSqlInstanceActiveDirectoryAdministratorModel))]
    public class RemoveAzureSqlInstanceActiveDirectoryAdministrator : AzureSqlInstanceActiveDirectoryAdministratorCmdletBase
    {
        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false,
        HelpMessage = "Defines whether to return the removed AD administrator")]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        protected override bool WriteResult() { return PassThru.IsPresent; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlInstanceActiveDirectoryAdministratorModel> GetEntity()
        {
            return new List<AzureSqlInstanceActiveDirectoryAdministratorModel>() {
                ModelAdapter.GetInstanceActiveDirectoryAdministrator(GetResourceGroupName(), GetInstanceName())
            };
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlInstanceActiveDirectoryAdministratorModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstanceActiveDirectoryAdministratorModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to managed instance
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlInstanceActiveDirectoryAdministratorModel> PersistChanges(IEnumerable<AzureSqlInstanceActiveDirectoryAdministratorModel> entity)
        {
            ModelAdapter.RemoveInstanceActiveDirectoryAdministrator(GetResourceGroupName(), GetInstanceName());
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceActiveDirectoryAdministratorDescription, GetInstanceName()),
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceActiveDirectoryAdministratorWarning, GetInstanceName()),
               Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }
    }
}
