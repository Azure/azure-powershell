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
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlServerDnsAlias cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDnsAlias",
        DefaultParameterSetName = GetByNameParameterSet),
        OutputType(typeof(AzureSqlManagedInstanceDnsAliasModel))]
    public class GetAzureSqlManagedInstanceDnsAlias : AzureSqlManagedInstanceDnsAliasCmdletBase
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
        /// Gets or sets the name of the Azure Sql Managed Instance DNS Alias
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet, Position = 2, HelpMessage = "Name of the managed instance DNS alias.")]
        [Parameter(Mandatory = false, ParameterSetName = GetByParentObjectParameterSet, Position = 1, HelpMessage = "Name of the managed instance DNS alias.")]
        [Alias("DnsAliasName")]
        [SupportsWildcards]
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Input object of the managed instance.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the instance dns alias resource id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByResourceIdParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Resource ID of the managed instance DNS alias.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> GetEntity()
        {
            ICollection<AzureSqlManagedInstanceDnsAliasModel> results = null;

            if (this.MyInvocation.BoundParameters.ContainsKey("Name") && !WildcardPattern.ContainsWildcardCharacters(Name))
            {
                results = new List<AzureSqlManagedInstanceDnsAliasModel>();
                results.Add(ModelAdapter.GetManagedInstanceDnsAlias(this.ResourceGroupName, this.InstanceName, this.Name));
            }
            else
            {
                results = ModelAdapter.ListManagedInstanceDnsAliases(this.ResourceGroupName, this.InstanceName);
            }

            return SubResourceWildcardFilter(Name, results);
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case GetByNameParameterSet:
                    // default case, we're getting RG, MI and DNS alias names directly from args
                    break;
                case GetByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, DNS alias name received directly from arg
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case GetByResourceIdParameterSet:
                    // we need to derive RG, MI and DNS alias name from resource id
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    Name = resourceInfo.ResourceName;
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
        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceDnsAliasModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceDnsAliasModel> model)
        {
            return model;
        }
    }
}
