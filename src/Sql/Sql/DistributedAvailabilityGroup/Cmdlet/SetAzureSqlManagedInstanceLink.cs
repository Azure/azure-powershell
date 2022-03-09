using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Cmdlet
{
    /// <summary>
    /// Cmdlet to update Managed Instance Link
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLink",
        DefaultParameterSetName = SetByNameParameterSet, SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceLinkModel))]
    public class SetAzureSqlManagedInstanceLink : AzureSqlManagedInstanceLinkCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentObjectParameterSet = "SetByParentObjectParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet, Position = 0, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet, Position = 1, HelpMessage = "The name of the Azure SQL Managed Instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet, Position = 2, HelpMessage = "The name of the Managed Instance link.")]
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet, Position = 1, HelpMessage = "The name of the Managed Instance link.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/distributedAvailabilityGroups", nameof(ResourceGroupName), nameof(InstanceName))]
        [ValidateNotNullOrEmpty]
        public string LinkName { get; set; }

        /// <summary>
        /// Gets or sets the replication mode
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet, Position = 3, HelpMessage = "The value of replication mode. Possible values include 'Sync' and 'Async'.")]
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet, Position = 2, HelpMessage = "The value of replication mode. Possible values include 'Sync' and 'Async'.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet, Position = 1, HelpMessage = "The value of replication mode. Possible values include 'Sync' and 'Async'.")]
        [Parameter(Mandatory = true, ParameterSetName = SetByResourceIdParameterSet, Position = 1, HelpMessage = "The value of replication mode. Possible values include 'Sync' and 'Async'.")]
        [PSArgumentCompleter("Sync", "Async")]
        [ValidateNotNullOrEmpty]
        public string ReplicationMode { get; set; }

        /// <summary>
        /// Gets or sets the instance Resource Id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The Managed Instance Link resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "The instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel Instance { get; set; }

        /// <summary>
        /// Gets or set the input mi link object
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = SetByInputObjectParameterSet, Position = 0, HelpMessage = "The Managed Instance Link input object.")]
        [ValidateNotNull]
        public AzureSqlManagedInstanceLinkModel ManagedInstanceLink { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> GetEntity()
        {
            return new List<AzureSqlManagedInstanceLinkModel>() { ModelAdapter.GetManagedInstanceLink(ResourceGroupName, InstanceName, LinkName) };
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case SetByNameParameterSet:
                    // default case, we're getting RG, MI and MiLink names directly from args
                    break;
                case SetByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, MiLink name received directly from arg
                    ResourceGroupName = Instance.ResourceGroupName;
                    InstanceName = Instance.ManagedInstanceName;
                    break;
                case SetByInputObjectParameterSet:
                    // we need to extract RG, MI and MiLink name directly from the MiLink object but replication mode can be either from the object or from arg
                    ResourceGroupName = ManagedInstanceLink.ResourceGroupName;
                    InstanceName = ManagedInstanceLink.InstanceName;
                    LinkName = ManagedInstanceLink.LinkName;
                    ReplicationMode = this.IsParameterBound(c => c.ReplicationMode) ? ReplicationMode : ManagedInstanceLink.ReplicationMode;
                    break;
                case SetByResourceIdParameterSet:
                    // we need to derive RG, MI and MiLink name from resource id
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    LinkName = resourceInfo.ResourceName;
                    break;
                default:
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceLinkDescription, ResourceGroupName, InstanceName, LinkName),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceLinkWarning, ResourceGroupName, InstanceName, LinkName),
                Properties.Resources.ShouldProcessCaption))
            {
                base.ExecuteCmdlet();
            }
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceLinkModel> model)
        {
            List<AzureSqlManagedInstanceLinkModel> newEntity = new List<AzureSqlManagedInstanceLinkModel> { };
            var updatedModel = model.First();
            updatedModel.ReplicationMode = ReplicationMode;
            newEntity.Add(updatedModel);
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
                ModelAdapter.UpdateManagedInstanceLink(entity.First())
            };
        }
    }
}
