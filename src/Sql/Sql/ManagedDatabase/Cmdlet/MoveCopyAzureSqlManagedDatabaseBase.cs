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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using System.Management.Automation;
using System.Collections;

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
        public AzureSqlManagedDatabaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the instance object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = MoveCopyManagedDatabaseByInstanceObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The managed instance object")]
        [ValidateNotNullOrEmpty]
        [Alias("ParentObject")]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MoveCopyManagedDatabaseByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        protected override MoveCopyManagedDatabaseModel GetEntity()
        {
            switch (ParameterSetName)
            {
                case MoveCopyManagedDatabaseByInputObjectParameterSet:
                    ResourceGroupName = InputObject.ResourceGroupName;
                    InstanceName = InputObject.ManagedInstanceName;
                    DatabaseName = InputObject.Name;
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

            var sourceManagedDatabase = ModelAdapter.GetManagedDatabase(ResourceGroupName, InstanceName, DatabaseName);

            return new MoveCopyManagedDatabaseModel()
            {
                ManagedInstanceName = InstanceName,
                Name = DatabaseName,
                ResourceGroupName = ResourceGroupName,
                SubscriptionId = ModelAdapter.Context.Subscription.Id,
                TargetManagedInstanceName = TargetInstanceName,
                TargetResourceGroupName = TargetResourceGroupName ?? ResourceGroupName,
                Location = sourceManagedDatabase.Location
            };
        }
    }
}