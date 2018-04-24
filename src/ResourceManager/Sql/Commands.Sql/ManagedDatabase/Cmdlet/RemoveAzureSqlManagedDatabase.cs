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

using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlManagedDatabase", SupportsShouldProcess = true)]
    public class RemoveAzureSqlManagedDatabase : AzureSqlManagedDatabaseCmdletBase<IEnumerable<AzureSqlManagedDatabaseModel>>
    {
        protected const string RemoveByNameAndResourceGroupParameterSet =
            "Remove a Managed Database from cmdlet input parameters";

        protected const string RemoveByInputObjectParameterSet =
            "Remove a Managed Database from AzureSqlManagedDatabaseModel instance definition";

        protected const string RemoveByResourceIdParameterSet =
            "Remove a Managed Database from an Azure resource id";

        /// <summary>
        /// Gets or sets the name of the managed database to remove.
        /// </summary>
        [Parameter(ParameterSetName = RemoveByNameAndResourceGroupParameterSet, 
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the Azure SQL Managed Database to remove.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string ManagedDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure Sql Managed Instance
        /// </summary>
        [Parameter(ParameterSetName = RemoveByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The Azure Sql Managed Instance name.")]
        [ValidateNotNullOrEmpty]
        public override string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = RemoveByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Managed database object to remove
        /// </summary>
        [Parameter(ParameterSetName = RemoveByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Managed Database object to remove")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedDatabaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the Managed database to remove
        /// </summary>
        [Parameter(ParameterSetName = RemoveByResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of Managed Database object to remove")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseModel> GetEntity()
        {
            return new List<Model.AzureSqlManagedDatabaseModel>() {
                ModelAdapter.GetManagedDatabase(this.ResourceGroupName, this.ManagedInstanceName, this.ManagedDatabaseName)
            };
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedDatabaseModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to managed instance
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseModel> PersistChanges(IEnumerable<AzureSqlManagedDatabaseModel> entity)
        {
            ModelAdapter.RemoveManagedDatabase(this.ResourceGroupName, this.ManagedInstanceName, this.ManagedDatabaseName);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlDatabaseDescription, this.ManagedDatabaseName, this.ManagedInstanceName),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlDatabaseWarning, this.ManagedDatabaseName, this.ManagedInstanceName),
               Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            if (string.Equals(this.ParameterSetName, RemoveByInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                ManagedInstanceName = InputObject.ManagedInstanceName;
                ManagedDatabaseName = InputObject.Name;
            }
            else if (string.Equals(this.ParameterSetName, RemoveByResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                ManagedInstanceName = resourceInfo.ParentResource.Split(new[] { '/' })[1];
                ManagedDatabaseName = resourceInfo.ResourceName;
            }

            base.ExecuteCmdlet();
        }
    }
}
