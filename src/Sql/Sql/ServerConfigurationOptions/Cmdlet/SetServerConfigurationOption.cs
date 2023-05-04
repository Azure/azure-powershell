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
using Microsoft.Azure.Commands.Sql.ServerConfigurationOptions.Model;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerConfigurationOptions.Cmdlet
{

    /// <summary>
    /// Cmdlet to set a value of server configuration option
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerConfigurationOption",
        DefaultParameterSetName = CreateByNameParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(ServerConfigurationOptionsModel))]
    public class SetServerConfigurationOptions : ServerConfigurationOptionsCmdletBase
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 1, HelpMessage = "Name of Azure SQL Managed Instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the server configuration option name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 2, HelpMessage = "Name of the server configuration option.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, Position = 1, HelpMessage = "Name of the server configuration option.")]
        [PSArgumentCompleter("allowPolybaseExport")]
        [ValidateSet("allowPolybaseExport", IgnoreCase = true)]
        [Alias("ConfigOptionName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the public key
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 3, HelpMessage = "Value of the server configuration option.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, Position = 2, HelpMessage = "Value of the server configuration option.")]
        [PSArgumentCompleter("0", "1")]
        [ValidateSet("0", "1")]
        [Alias("ConfigOptionValue")]
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case CreateByNameParameterSet:
                    // default case, we're getting RG, MI, config option name and Public key directly from args
                    break;
                case CreateByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, config option name and Public key received directly from arg
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                default:
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (!ShouldProcess(
              string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetServerConfigurationOptionDescription, Value, Name, InstanceName, ResourceGroupName),
              string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetServerConfigurationOptionWarning, Value, Name, InstanceName, ResourceGroupName),
              Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }

        protected override IEnumerable<ServerConfigurationOptionsModel> GetEntity()
        {
            // server configuration option will always exist, and Set-* should always override it
            return null;
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<ServerConfigurationOptionsModel> ApplyUserInputToModel(IEnumerable<ServerConfigurationOptionsModel> model)
        {
            List<ServerConfigurationOptionsModel> newEntity = new List<ServerConfigurationOptionsModel>
            {
                new ServerConfigurationOptionsModel()
                {
                    ResourceGroupName = ResourceGroupName,
                    InstanceName = InstanceName,
                    Name = Name,
                    Value = Value,
                }
            };
            return newEntity;
        }

        /// <summary>
        /// Create the new Failover Group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<ServerConfigurationOptionsModel> PersistChanges(IEnumerable<ServerConfigurationOptionsModel> entity)
        {
            return new List<ServerConfigurationOptionsModel>() {
                ModelAdapter.SetConfigurationOption(entity.First())
            };
        }
    }
}
