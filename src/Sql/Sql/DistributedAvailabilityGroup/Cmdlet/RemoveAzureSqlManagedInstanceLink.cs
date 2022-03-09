using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Cmdlet
{
    /// <summary>
    /// Cmdlet to remove a Managed Instance Link
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLink",
        DefaultParameterSetName = DeleteByNameParameterSet,
        SupportsShouldProcess = true
        ),
        OutputType(typeof(AzureSqlManagedInstanceLinkModel))]
    public class RemoveAzureSqlManagedInstanceLink : AzureSqlManagedInstanceLinkCmdletBase
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByParentObjectParameterSet = "DeleteByParentObjectParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 0, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 1, HelpMessage = "The name of the Azure SQL Managed Instance")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 2, HelpMessage = "The name of the Managed Instance link")]
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, Position = 1, HelpMessage = "The name of the Managed Instance link")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/distributedAvailabilityGroups", nameof(ResourceGroupName), nameof(InstanceName))]
        [ValidateNotNullOrEmpty]
        public string LinkName { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "The instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel Instance { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "The Managed Instance Link input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceLinkModel ManagedInstanceLink { get; set; }

        /// <summary>
        /// Gets or sets the MI Link Resource Id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The Managed Instance Link resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {

            switch (ParameterSetName)
            {
                case DeleteByNameParameterSet:
                    // default case, we're getting RG, MI and Link names directly from args
                    break;
                case DeleteByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, Link name received directly from arg
                    ResourceGroupName = Instance.ResourceGroupName;
                    InstanceName = Instance.ManagedInstanceName;
                    break;
                case DeleteByInputObjectParameterSet:
                    // we need to extract RG, MI and MiLink name directly from the MiLink object
                    ResourceGroupName = ManagedInstanceLink.ResourceGroupName;
                    InstanceName = ManagedInstanceLink.InstanceName;
                    LinkName = ManagedInstanceLink.LinkName;
                    break;
                case DeleteByResourceIdParameterSet:
                    // we need to derive RG, MI and Link name from resource id
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
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceLinkDescription, ResourceGroupName, InstanceName, LinkName),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceLinkWarning, ResourceGroupName, InstanceName, LinkName),
                Properties.Resources.ShouldProcessCaption))
            {
                // message prompt requiring the customer to explicitly confirm the delete operation
                if (Force || ShouldContinue(Properties.Resources.RemoveAzureSqlInstanceServerTrustCertificateAllowDataLoss, Properties.Resources.ShouldProcessCaption))
                {
                    base.ExecuteCmdlet();
                }
            }            
        }


        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> GetEntity()
        {
            return new List<AzureSqlManagedInstanceLinkModel>() {
                ModelAdapter.GetManagedInstanceLink(ResourceGroupName, InstanceName, LinkName)
            };
        }

        /// <summary>
        /// Apply user input. Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceLinkModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the mi link.
        /// </summary>
        /// <param name="entity">The link being deleted</param>
        /// <returns>The instance that was deleted</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceLinkModel> entity)
        {
            ModelAdapter.RemoveManagedInstanceLink(ResourceGroupName, InstanceName, LinkName);
            return entity;
        }

    }
}
