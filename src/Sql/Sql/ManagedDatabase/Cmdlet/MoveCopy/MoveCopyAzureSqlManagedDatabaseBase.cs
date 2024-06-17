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
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Services;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    public abstract class MoveCopyAzureSqlManagedDatabaseBase : AzureSqlManagedDatabaseCmdletBase<MoveCopyManagedDatabaseModel>
    {
        protected const string MoveCopyManagedDatabaseByNameParameterSet = "MoveCopyManagedDatabaseByNameParameterSet";
        protected const string MoveCopyManagedDatabaseByInputObjectParameterSet = "MoveCopyManagedDatabaseByInputObjectParameterSet";
        protected const string MoveCopyManagedDatabaseByResourceIdParameterSet = "MoveCopyManagedDatabaseByResourceIdParameterSet";
        protected const string MoveCopyManagedDatabaseByOperationsObjectParameterSet = "MoveCopyManagedDatabaseByOperationObjectParameterSet";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the instance database.", ParameterSetName = MoveCopyManagedDatabaseByNameParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Name of the instance database.", ParameterSetName = MoveCopyManagedDatabaseByOperationsObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", nameof(ResourceGroupName), nameof(InstanceName))]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = MoveCopyManagedDatabaseByNameParameterSet, HelpMessage = "Name of the source instance.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MoveCopyManagedDatabaseByInputObjectParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = MoveCopyManagedDatabaseByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = MoveCopyManagedDatabaseByOperationsObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        public override string InstanceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = MoveCopyManagedDatabaseByNameParameterSet, HelpMessage = "Name of the source resource group.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MoveCopyManagedDatabaseByInputObjectParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = MoveCopyManagedDatabaseByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = MoveCopyManagedDatabaseByOperationsObjectParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Id of the target subscription.", ParameterSetName = MoveCopyManagedDatabaseByNameParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Id of the target subscription.", ParameterSetName = MoveCopyManagedDatabaseByInputObjectParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Id of the target subscription.", ParameterSetName = MoveCopyManagedDatabaseByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TargetSubscriptionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the target resource group.", ParameterSetName = MoveCopyManagedDatabaseByNameParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Name of the target resource group.", ParameterSetName = MoveCopyManagedDatabaseByInputObjectParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Name of the target resource group.", ParameterSetName = MoveCopyManagedDatabaseByResourceIdParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of the target Azure SQL Managed Instance.", ParameterSetName = MoveCopyManagedDatabaseByNameParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Name of the target Azure SQL Managed Instance.", ParameterSetName = MoveCopyManagedDatabaseByInputObjectParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Name of the target Azure SQL Managed Instance.", ParameterSetName = MoveCopyManagedDatabaseByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(TargetResourceGroupName))]
        public string TargetInstanceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveCopyManagedDatabaseByInputObjectParameterSet, HelpMessage = "Managed database object.")]
        [ValidateNotNull]
        public AzureSqlManagedDatabaseModel DatabaseObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = MoveCopyManagedDatabaseByOperationsObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Managed database move or copy operation object.")]
        [ValidateNotNullOrEmpty]
        [Alias("Operation")]
        public ManagedDatabaseMoveCopyOperation MoveCopyOperationObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MoveCopyManagedDatabaseByResourceIdParameterSet, HelpMessage = "Resource id of managed database.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "Signal to receive output from a cmdlet which does not return anything")]
        public SwitchParameter PassThru { get; set; }

        protected abstract string ShouldProcessConfirmationMessage { get; }

        protected override MoveCopyManagedDatabaseModel GetEntity()
        {
            switch (ParameterSetName)
            {
                case MoveCopyManagedDatabaseByInputObjectParameterSet:
                    ResourceGroupName = DatabaseObject.ResourceGroupName;
                    InstanceName = DatabaseObject.ManagedInstanceName;
                    DatabaseName = DatabaseObject.Name;
                    break;
                case MoveCopyManagedDatabaseByResourceIdParameterSet:
                    var resourceInfo = new ResourceIdentifier(ResourceId);

                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Substring(resourceInfo.ParentResource.LastIndexOf("/") + 1);
                    DatabaseName = resourceInfo.ResourceName;
                    break;
                case MoveCopyManagedDatabaseByOperationsObjectParameterSet:
                    var sourceInfo = new ResourceIdentifier(MoveCopyOperationObject.SourceManagedInstanceId);
                    ResourceGroupName = sourceInfo.ResourceGroupName;
                    InstanceName = sourceInfo.ResourceName;

                    var targetInfo = new ResourceIdentifier(MoveCopyOperationObject.TargetManagedInstanceId);
                    TargetInstanceName = targetInfo.ResourceName;
                    TargetResourceGroupName = targetInfo.ResourceGroupName;

                    DatabaseName = MoveCopyOperationObject.SourceDatabaseName;
                    break;
            }

            return new MoveCopyManagedDatabaseModel()
            {
                InstanceName = InstanceName,
                DatabaseName = DatabaseName,
                ResourceGroupName = ResourceGroupName,
                SubscriptionId = ModelAdapter.Context.Subscription.Id,
                TargetInstanceName = TargetInstanceName,
                TargetResourceGroupName = TargetResourceGroupName ?? ResourceGroupName,
                TargetSubscriptionId = TargetSubscriptionId ?? ModelAdapter.Context.Subscription.Id
            };
        }

        protected override bool WriteResult()
        {
            return PassThru.IsPresent;
        }

        /// <summary>
        /// Always return true because APIs for moving/copying doesn't return anything
        /// </summary>
        /// <param name="model">Ignored param</param>
        /// <returns></returns>
        protected override object TransformModelToOutputObject(MoveCopyManagedDatabaseModel model)
        {
            return true;
        }

        protected override string GetResourceId(MoveCopyManagedDatabaseModel model)
        {
            var sourceDatabase = new ResourceIdentifier()
            {
                Subscription = model.SubscriptionId,
                ResourceGroupName = model.ResourceGroupName,
                ParentResource = $"managedInstances/{model.InstanceName}",
                ResourceType = "Microsoft.Sql/managedInstances/databases",
                ResourceName = model.DatabaseName,
            };

            return sourceDatabase.ToString();
        }

        protected override string GetConfirmActionProcessMessage()
        {
            return ShouldProcessConfirmationMessage;
        }
    }
}
