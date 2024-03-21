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
        private const string CreateByNameParameterSetWithTargetDatabase = "CreateByNameParameterSetWithTargetDatabase";
        private const string CreateByParentObjectParameterSetWithTargetDatabase = "CreateByParentObjectParameterSetWithTargetDatabase";

        private const string ResourceGroupNameHelpMessage = "Name of the resource group.";
        private const string InstanceNameHelpMessage = "Name of Azure SQL Managed Instance.";
        private const string LinkNameHelpMessage = "Name of the instance link.";
        private const string TargetDatabaseHelpMessage = "Name of the target database.";
        private const string DatabasesHelpMessage = "Database names in the distributed availability group.";
        private const string FailoverModeHelpMessage = "Link failover mode.";
        private const string InstanceAvailabilityGroupNameHelpMessage = "Name of the managed instance side availability group.";
        private const string InstanceLinkRoleHelpMessage = "Managed instance side link role.";
        private const string PartnerAvailabilityGroupNameHelpMessage = "Name of the SQL server side availability group.";
        private const string PartnerEndpointHelpMessage = "SQL server side endpoint - IP or DNS resolvable name.";
        private const string ReplicationModeHelpMessage = "Replication mode of the link.";
        private const string SeedingModeHelpMessage = "Database seeding mode.";
        private const string InputObjectHelpMessage = "Instance input object.";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 0, HelpMessage = ResourceGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, Position = 0, HelpMessage = ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 1, HelpMessage = InstanceNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, Position = 1, HelpMessage = InstanceNameHelpMessage)]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 2, HelpMessage = LinkNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, Position = 1, HelpMessage = LinkNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, Position = 2, HelpMessage = LinkNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSetWithTargetDatabase, Position = 1, HelpMessage = LinkNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        [Alias("LinkName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the target database name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, HelpMessage = TargetDatabaseHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSetWithTargetDatabase, HelpMessage = TargetDatabaseHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string TargetDatabase { get; set; }

        /// <summary>
        /// Gets or sets database names in the distributed availability group
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = DatabasesHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = DatabasesHelpMessage)]
        [ValidateNotNullOrEmpty]
        public List<string> Databases { get; set; }

        /// <summary>
        /// Gets or sets the link failover mode - can be Manual if intended to
        /// be used for two-way failover with a supported SQL Server, or None
        /// for one-way failover to Azure. Possible values include: 'None',
        /// 'Manual'
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = FailoverModeHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = FailoverModeHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, HelpMessage = FailoverModeHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSetWithTargetDatabase, HelpMessage = FailoverModeHelpMessage)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Manual", "None")]
        public string FailoverMode { get; set; }

        /// <summary>
        /// Gets or sets managed instance side availability group name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = InstanceAvailabilityGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = InstanceAvailabilityGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, HelpMessage = InstanceAvailabilityGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSetWithTargetDatabase, HelpMessage = InstanceAvailabilityGroupNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        [Alias("SecondaryAvailabilityGroupName")]
        public string InstanceAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets managed instance side link role. Possible values
        /// include: 'Primary', 'Secondary'
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = InstanceLinkRoleHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = InstanceLinkRoleHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, HelpMessage = InstanceLinkRoleHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSetWithTargetDatabase, HelpMessage = InstanceLinkRoleHelpMessage)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Primary", "Secondary")]
        public string InstanceLinkRole { get; set; }

        /// <summary>
        /// Gets or sets SQL server side availability group name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = PartnerAvailabilityGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = PartnerAvailabilityGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, HelpMessage = PartnerAvailabilityGroupNameHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSetWithTargetDatabase, HelpMessage = PartnerAvailabilityGroupNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        [Alias("PrimaryAvailabilityGroupName")]
        public string PartnerAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets SQL server side endpoint - IP or DNS resolvable name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = PartnerEndpointHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = PartnerEndpointHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, HelpMessage = PartnerEndpointHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSetWithTargetDatabase, HelpMessage = PartnerEndpointHelpMessage)]
        [ValidateNotNullOrEmpty]
        [Alias("SourceEndpoint")]
        public string PartnerEndpoint { get; set; }

        /// <summary>
        /// Gets or sets replication mode of the link. Possible values include:
        /// 'Async', 'Sync'
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = ReplicationModeHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = ReplicationModeHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, HelpMessage = ReplicationModeHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSetWithTargetDatabase, HelpMessage = ReplicationModeHelpMessage)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Async", "Sync")]
        public string ReplicationMode { get; set; }

        /// <summary>
        /// Gets or sets database seeding mode – can be Automatic (default), or
        /// Manual for supported scenarios. Possible values include:
        /// 'Automatic', 'Manual'
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = CreateByNameParameterSet, HelpMessage = SeedingModeHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = SeedingModeHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = CreateByNameParameterSetWithTargetDatabase, HelpMessage = SeedingModeHelpMessage)]
        [Parameter(Mandatory = false, ParameterSetName = CreateByParentObjectParameterSetWithTargetDatabase, HelpMessage = SeedingModeHelpMessage)]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Value = "Automatic")]
        [PSArgumentCompleter("Automatic", "Manual")]
        public string SeedingMode { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = InputObjectHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSetWithTargetDatabase, ValueFromPipeline = true, Position = 0, HelpMessage = InputObjectHelpMessage)]
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
                case CreateByNameParameterSetWithTargetDatabase:
                    // we need to create a list from one database for backward compatibility
                    Databases = new List<string> { TargetDatabase };
                    break;
                case CreateByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, rest is received directly from args
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case CreateByParentObjectParameterSetWithTargetDatabase:
                    // we need to extract RG and MI name from the Instance object, rest is received directly from args
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;

                    // we need to create a list from one database for backward compatibility
                    Databases = new List<string> { TargetDatabase };
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
                    Databases = Databases.Select(databaseName => new DistributedAvailabilityGroupDatabase { DatabaseName = databaseName }).ToList(),
                    FailoverMode = FailoverMode,
                    InstanceAvailabilityGroupName = InstanceAvailabilityGroupName,
                    InstanceLinkRole = InstanceLinkRole,
                    PartnerAvailabilityGroupName = PartnerAvailabilityGroupName,
                    PartnerEndpoint = PartnerEndpoint,
                    ReplicationMode = ReplicationMode,
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
