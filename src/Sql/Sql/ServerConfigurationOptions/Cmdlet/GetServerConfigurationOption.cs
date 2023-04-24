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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ServerConfigurationOptions.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerConfigurationOptions.Cmdlet
{

    /// <summary>
    /// Cmdlet to get a server configuration option
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerConfigurationOption",
        DefaultParameterSetName = GetByNameParameterSet),
        OutputType(typeof(ServerConfigurationOptionsModel))]
    public class GetServerConfigurationOption : ServerConfigurationOptionsCmdletBase
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByInstanceResourceIdParameterSet = "GetByInstanceResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, Position = 1, HelpMessage = "Name of Azure SQL Managed Instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the server configuration option name
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet, Position = 2, HelpMessage = "Name of the server configuration option.")]
        [Parameter(Mandatory = false, ParameterSetName = GetByParentObjectParameterSet, Position = 1, HelpMessage = "Name of the server configuration option.")]
        [Parameter(Mandatory = false, ParameterSetName = GetByInstanceResourceIdParameterSet, Position = 1, HelpMessage = "Name of the server configuration option.")]
        [PSArgumentCompleter("allowPolybaseExport")]
        [ValidateSet("allowPolybaseExport", IgnoreCase = true)]
        [Alias("ConfigOptionName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the server config option Resource Id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Server configuration option resource ID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the instance Resource Id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByInstanceResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Managed instance resource ID.")]
        [ValidateNotNullOrEmpty]
        public string InstanceResourceId { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case GetByNameParameterSet:
                    // default case, we're getting RG, MI and config option names directly from args
                    break;
                case GetByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, config option name received directly from arg
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case GetByResourceIdParameterSet:
                    // we need to derive RG, MI and config option name from resource id
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    Name = resourceInfo.ResourceName;
                    break;
                case GetByInstanceResourceIdParameterSet:
                    // we need to derive RG and MI name from managed instance resource id, config option name passed from arg
                    var instanceInfo = new ResourceIdentifier(InstanceResourceId);
                    ResourceGroupName = instanceInfo.ResourceGroupName;
                    InstanceName = instanceInfo.ResourceName;
                    break;
                default:
                    break;
            }
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Gets the server configuration option name if it's passed, otherwise list all available config options on the managed instance
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<ServerConfigurationOptionsModel> GetEntity()
        {
            ICollection<ServerConfigurationOptionsModel> results = new List<ServerConfigurationOptionsModel>();
            if (Name != null)
            {
                // we're ignoring the name right now because it can only be 'allowPolybaseExport' so SDK has it pinned
                results.Add(ModelAdapter.GetServerConfigurationOption(ResourceGroupName, InstanceName));
            }
            else
            {
                results = ModelAdapter.ListServerConfigurationOptions(ResourceGroupName, InstanceName);
            }
            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<ServerConfigurationOptionsModel> PersistChanges(IEnumerable<ServerConfigurationOptionsModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<ServerConfigurationOptionsModel> ApplyUserInputToModel(IEnumerable<ServerConfigurationOptionsModel> model)
        {
            return model;
        }
    }
}
