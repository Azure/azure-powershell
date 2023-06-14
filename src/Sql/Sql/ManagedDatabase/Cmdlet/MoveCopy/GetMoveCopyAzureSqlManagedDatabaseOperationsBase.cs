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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    public abstract class GetMoveCopyAzureSqlManagedDatabaseOperationsBase : AzureSqlManagedDatabaseCmdletBase<IList<ManagedDatabaseMoveCopyOperation>>
    {
        protected const string GetMoveCopyManagedDatabaseOperationsByNameParameterSet = "GetMoveCopyManagedDatabaseOperationsByNameParameterSet";
        protected const string GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet = "GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet";
        protected const string GetMoveCopyManagedDatabaseOperationsByResourceIdParameterSet = "GetMoveCopyManagedDatabaseOperationsByResourceIdParameterSet";
        protected const string GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet = "GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet";

        [Parameter(Mandatory = false, HelpMessage = "Name of a database on Azure SQL Managed Instance.", ParameterSetName = GetMoveCopyManagedDatabaseOperationsByNameParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet, HelpMessage = "Name of a database on Azure SQL Managed Instance.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet, HelpMessage = "Name of a database on Azure SQL Managed Instance.")]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", nameof(ResourceGroupName), nameof(InstanceName))]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the target resource group.", ParameterSetName = GetMoveCopyManagedDatabaseOperationsByNameParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Name of the target resource group.", ParameterSetName = GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Name of the target resource group.", ParameterSetName = GetMoveCopyManagedDatabaseOperationsByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet, HelpMessage = "Name of the target resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the target Azure SQL Managed Instance.", ParameterSetName = GetMoveCopyManagedDatabaseOperationsByNameParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Name of the target Azure SQL Managed Instance.", ParameterSetName = GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Name of the target Azure SQL Managed Instance.", ParameterSetName = GetMoveCopyManagedDatabaseOperationsByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet, HelpMessage = "Name of the target Azure SQL Managed Instance.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(TargetResourceGroupName))]
        public string TargetInstanceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet, HelpMessage = "Managed database object.")]
        [ValidateNotNull]
        public AzureSqlManagedDatabaseModel DatabaseObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetMoveCopyManagedDatabaseOperationsByResourceIdParameterSet, HelpMessage = "Resource id of managed database.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet, HelpMessage = "Object that is returned from start move or copy operation using -PassThru parameter.")]
        [ValidateNotNullOrEmpty]
        public MoveCopyManagedDatabaseModel ModelObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return only latest opereation per managed database")]
        public SwitchParameter OnlyLatestPerDatabase { get; set; }

        /// <summary>
        /// Get the operation mode of the command. COPY or MOVE
        /// </summary>
        /// <returns>Operation mode</returns>
        protected abstract OperationMode GetOperationMode();


        protected override IList<ManagedDatabaseMoveCopyOperation> GetEntity()
        {

            switch (ParameterSetName)
            {
                case GetMoveCopyManagedDatabaseOperationsByResourceIdParameterSet:
                    var resourceInfo = new ResourceIdentifier(ResourceId);

                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Substring(resourceInfo.ParentResource.LastIndexOf("/") + 1);
                    DatabaseName = resourceInfo.ResourceName;
                    break;
                case GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet:
                    ResourceGroupName = DatabaseObject.ResourceGroupName;
                    InstanceName = DatabaseObject.ManagedInstanceName;
                    DatabaseName = DatabaseObject.Name;
                    break;
                case GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet:
                    ResourceGroupName = ModelObject.ResourceGroupName;
                    InstanceName = ModelObject.InstanceName;
                    DatabaseName = ModelObject.DatabaseName;
                    TargetInstanceName = ModelObject.TargetInstanceName;
                    TargetResourceGroupName = ModelObject.TargetResourceGroupName;
                    break;
            }

            var location = ModelAdapter.GetManagedInstanceLocation(ResourceGroupName, InstanceName);
            var model = new MoveCopyManagedDatabaseModel()
            {
                InstanceName = InstanceName,
                DatabaseName = DatabaseName,
                ResourceGroupName = ResourceGroupName,
                SubscriptionId = ModelAdapter.Context.Subscription.Id,
                TargetInstanceName = TargetInstanceName,
                TargetResourceGroupName = TargetResourceGroupName,
                Location = location,
                OperationMode = GetOperationMode(),
            };

            return ModelAdapter.ListMoveCopyOperations(model, OnlyLatestPerDatabase.IsPresent);
        }


    }
}
