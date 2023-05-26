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

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    public abstract class MoveCopyAzureSqlManagedDatabaseBase : AzureSqlManagedDatabaseCmdletBase<MoveCopyManagedDatabaseModel>
    {
        protected const string MoveCopyManagedDatabaseByNameParameterSet = "MoveCopyManagedDatabaseByNameParameterSet";
        protected const string MoveCopyManagedDatabaseByInputObjectParameterSet = "MoveCopyManagedDatabaseByInputObjectParameterSet";
        protected const string MoveCopyManagedDatabaseByResourceIdParameterSet = "MoveCopyManagedDatabaseByResourceIdParameterSet";
        protected const string MoveCopyManagedDatabaseByInstanceObjectParameterSet = "MoveCopyManagedDatabaseByInstanceObjectParameterSet";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the instance database.", ParameterSetName = MoveCopyManagedDatabaseByNameParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "The managed instance object", ParameterSetName = MoveCopyManagedDatabaseByInstanceObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("Name")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", nameof(ResourceGroupName), nameof(InstanceName))]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of the target resource group.", ParameterSetName = MoveCopyManagedDatabaseByNameParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "The name of the target resource group.", ParameterSetName = MoveCopyManagedDatabaseByInputObjectParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "The name of the target resource group.", ParameterSetName = MoveCopyManagedDatabaseByResourceIdParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the target managed instance.", ParameterSetName = MoveCopyManagedDatabaseByNameParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "The name of the target managed instance.", ParameterSetName = MoveCopyManagedDatabaseByInputObjectParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "The name of the target managed instance.", ParameterSetName = MoveCopyManagedDatabaseByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(TargetResourceGroupName))]
        public string TargetInstanceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveCopyManagedDatabaseByInputObjectParameterSet)]
        [ValidateNotNull]
        public AzureSqlManagedDatabaseModel DatabaseObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = MoveCopyManagedDatabaseByInstanceObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The managed instance object")]
        [ValidateNotNullOrEmpty]
        [Alias("ParentObject")]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MoveCopyManagedDatabaseByResourceIdParameterSet)]
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
                case MoveCopyManagedDatabaseByInstanceObjectParameterSet:
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
            }

            return new MoveCopyManagedDatabaseModel()
            {
                ManagedInstanceName = InstanceName,
                Name = DatabaseName,
                ResourceGroupName = ResourceGroupName,
                SubscriptionId = ModelAdapter.Context.Subscription.Id,
                TargetManagedInstanceName = TargetInstanceName,
                TargetResourceGroupName = TargetResourceGroupName ?? ResourceGroupName,
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
                ParentResource = $"managedInstances/{model.ManagedInstanceName}",
                ResourceType = "Microsoft.Sql/managedInstances/databases",
                ResourceName = model.Name,
            };

            return sourceDatabase.ToString();
        }

        protected override string GetConfirmActionProcessMessage()
        {
            return ShouldProcessConfirmationMessage;
        }
    }
}