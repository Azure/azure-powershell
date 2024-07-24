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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
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
    [CmdletOutputBreakingChangeWithVersion(typeof(AzureSqlManagedInstanceLinkModel), "13.0.0", "6.0.0",
        DeprecatedOutputProperties = new String[] { "TargetDatabase", "PrimaryAvailabilityGroupName", "SecondaryAvailabilityGroupName",
            "SourceEndpoint", "SourceReplicaId", "TargetReplicaId", "LinkState", "LastHardenedLsn" },
        NewOutputProperties = new String[] { "Databases", "DistributedAvailabilityGroupName ", "InstanceAvailabilityGroupName", "PartnerAvailabilityGroupName",
            "InstanceLinkRole", "PartnerLinkRole", "FailoverMode", "SeedingMode", "PartnerEndpoint" })]
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
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 1, HelpMessage = "Name of Azure SQL Managed Instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 2, HelpMessage = "Name of the instance link.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, Position = 1, HelpMessage = "Name of the instance link.")]
        [ValidateNotNullOrEmpty]
        [Alias("LinkName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the primary availability group name
        /// </summary>
        [CmdletParameterBreakingChangeWithVersion("PrimaryAvailabilityGroupName", "13.0.0", "6.0.0", ReplaceMentCmdletParameterName = "PartnerAvailabilityGroupName")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = "Name of the primary availability group.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "Name of the primary availability group.")]
        [ValidateNotNullOrEmpty]
        public string PrimaryAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets the secondary availability group name
        /// </summary>
        [CmdletParameterBreakingChangeWithVersion("SecondaryAvailabilityGroupName", "13.0.0", "6.0.0", ReplaceMentCmdletParameterName = "InstanceAvailabilityGroupName")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = "Name of the secondary availability group.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "Name of the secondary availability group.")]
        [ValidateNotNullOrEmpty]
        public string SecondaryAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets the target database
        /// </summary>
        [CmdletParameterBreakingChangeWithVersion("TargetDatabase", "13.0.0", "6.0.0", ChangeDescription = "The parameter 'TargetDatabase' is being replaced by parameter 'Databases'. The type of new parameter is changing from 'String' to 'List<String>'")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = "Name of the target database.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "Name of the target database.")]
        [ValidateNotNullOrEmpty]
        public string TargetDatabase { get; set; }

        /// <summary>
        /// Gets or sets the source endpoint
        /// </summary>
        [CmdletParameterBreakingChangeWithVersion("SourceEndpoint", "13.0.0", "6.0.0", ReplaceMentCmdletParameterName = "PartnerEndpoint")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = "IP adress of the source endpoint.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "IP adress of the source endpoint.")]
        [ValidateNotNullOrEmpty]
        public string SourceEndpoint { get; set; }

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
            catch (CloudException ex)
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
                    PrimaryAvailabilityGroupName = PrimaryAvailabilityGroupName,
                    SecondaryAvailabilityGroupName = SecondaryAvailabilityGroupName,
                    TargetDatabase = TargetDatabase,
                    SourceEndpoint = SourceEndpoint,
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
