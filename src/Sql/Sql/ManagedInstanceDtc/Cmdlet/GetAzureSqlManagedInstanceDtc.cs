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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Cmdlet
{

    /// <summary>
    /// Defines the Get-AzSqlInstance cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDtc",
        DefaultParameterSetName = GetByNameParameterSet),
        OutputType(typeof(AzureSqlManagedInstanceDtcModel))]
    public class GetAzureSqlManagedInstanceDtc : ManagedInstanceDtcCmdletBase
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, Position = 1, HelpMessage = "Name of the managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Input object of the managed instance.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the instance DTC resource id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByResourceIdParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Resource ID of the managed instance DTC.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        protected override AzureSqlManagedInstanceDtcModel GetEntity()
        {
            return ModelAdapter.GetManagedInstanceDtc(ResourceGroupName, InstanceName);
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case GetByNameParameterSet:
                    // Default case, we're getting RG and MI names directly from args.
                    break;
                case GetByParentObjectParameterSet:
                    // We need to extract RG and MI names from the Instance object.
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case GetByResourceIdParameterSet:
                    // We need to derive RG and MI names from resource id.
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    break;
                default:
                    break;
            }
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override AzureSqlManagedInstanceDtcModel PersistChanges(AzureSqlManagedInstanceDtcModel entity)
        {
            return entity;
        }
    }
}
