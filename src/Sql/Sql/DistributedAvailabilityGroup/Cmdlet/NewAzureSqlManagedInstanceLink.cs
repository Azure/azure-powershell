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
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Managed Instance Link
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLink",
        DefaultParameterSetName = CreateByNameParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceLinkModel))]
    public class NewAzureSqlManagedInstanceLink : AzureSqlManagedInstanceLinkCmdletBase
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
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 1, HelpMessage = "Name of the managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 2, HelpMessage = "Managed Instance link name.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, Position = 1, HelpMessage = "Managed Instance link name.")]
        [ValidateNotNullOrEmpty]
        [Alias("LinkName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the partner availability group name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = "SQL server side availability group name.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "SQL server side availability group name.")]
        [ValidateNotNullOrEmpty]
        public string PartnerAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets the managed instance availability group name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = "Managed instance side availability group name.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "Managed instance side availability group name.")]
        [ValidateNotNullOrEmpty]
        public string InstanceAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets the target database/databases
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = "Database names in the distributed availability group.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "Database names in the distributed availability group.")]
        [ValidateNotNullOrEmpty]
        public string[] Database { get; set; }

        /// <summary>
        /// Gets or sets the partner endpoint
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = "SQL server side endpoint - IP or DNS resolvable name.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "SQL server side endpoint - IP or DNS resolvable name.")]
        [ValidateNotNullOrEmpty]
        public string PartnerEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the link failover mode - can be Manual if intended to
        /// be used for two-way failover with a supported SQL Server, or None
        /// for one-way failover to Azure. Possible values include: 'None',
        /// 'Manual'
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = CreateByNameParameterSet, HelpMessage = "The link failover mode - can be Manual if intended to be used for two-way failover with a supported SQL Server, or None for one-way failover to Azure.")]
        [Parameter(Mandatory = false, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "The link failover mode - can be Manual if intended to be used for two-way failover with a supported SQL Server, or None for one-way failover to Azure.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Manual", "None")]
        public string FailoverMode { get; set; }

        /// <summary>
        /// Gets or sets managed instance side link role. Possible values
        /// include: 'Primary', 'Secondary'
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = CreateByNameParameterSet, HelpMessage = "Managed instance side link role.")]
        [Parameter(Mandatory = false, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "Managed instance side link role.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Primary", "Secondary")]
        public string InstanceLinkRole { get; set; }

        /// <summary>
        /// Gets or sets database seeding mode – can be Automatic (default), or
        /// Manual for supported scenarios. Possible values include:
        /// 'Automatic', 'Manual'
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = CreateByNameParameterSet, HelpMessage = "Database seeding mode – can be Automatic (default), or Manual for supported scenarios.")]
        [Parameter(Mandatory = false, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "Database seeding mode – can be Automatic (default), or Manual for supported scenarios.")]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Value = "Automatic")]
        [PSArgumentCompleter("Automatic", "Manual")]
        public string SeedingMode { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case CreateByNameParameterSet:
                    // default case, we're getting all fields directly from args
                    break;
                case CreateByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, rest is received directly from args
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                default:
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.CreateAzureSqlInstanceLinkDescription, ResourceGroupName, InstanceName, Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.CreateAzureSqlInstanceLinkWarning, ResourceGroupName, InstanceName, Name),
                Properties.Resources.ShouldProcessCaption))
            {
                base.ExecuteCmdlet();
            }
        }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> GetEntity()
        {
            // We try to get the MI Link. Since this is a create, we don't want the link to exist
            try
            {
                ModelAdapter.GetManagedInstanceLink(ResourceGroupName, InstanceName, Name);
            }
            catch (ErrorResponseException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want. We looked and there is no link with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The Link already exists
            throw new PSArgumentException(
                string.Format(Properties.Resources.ManagedInstanceLinkAlreadyExists, Name, InstanceName),
                "Name");
        }


        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceLinkModel> model)
        {
            List<AzureSqlManagedInstanceLinkModel> newEntity = new List<AzureSqlManagedInstanceLinkModel>
            {
                new AzureSqlManagedInstanceLinkModel()
                {
                    ResourceGroupName = ResourceGroupName,
                    InstanceName = InstanceName,
                    Name = Name,
                    Databases = Database.Select(databaseName => new DistributedAvailabilityGroupDatabase { DatabaseName = databaseName }).ToList(),
                    InstanceAvailabilityGroupName = InstanceAvailabilityGroupName,
                    PartnerAvailabilityGroupName = PartnerAvailabilityGroupName,
                    InstanceLinkRole = InstanceLinkRole,
                    FailoverMode = FailoverMode,
                    PartnerEndpoint = PartnerEndpoint,
                    SeedingMode = SeedingMode
                }
            };
            return newEntity;
        }

        /// <summary>
        /// Create the new Failover Group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceLinkModel> entity)
        {
            return new List<AzureSqlManagedInstanceLinkModel>() {
                ModelAdapter.CreateManagedInstanceLink(entity.First())
            };
        }
    }
}
