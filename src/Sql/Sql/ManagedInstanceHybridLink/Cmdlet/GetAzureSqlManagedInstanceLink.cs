using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Server Trust certificate
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLink",
        DefaultParameterSetName = GetByNameParameterSet
        ),
        OutputType(typeof(AzureSqlManagedInstanceLinkModel))]
    public class GetAzureSqlManagedInstanceLink : AzureSqlManagedInstanceLinkCmdletBase
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByParentObjectParameterSet = "GetByParentObjectParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            Position = 1,
            ValueFromPipeline = true,
            HelpMessage = "The name of the Azure SQL Managed Instance")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = GetByNameParameterSet,
            Position = 2,
            ValueFromPipeline = true,
            HelpMessage = "The name of the MI link")]
        [ValidateNotNullOrEmpty]
        public string LinkName { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> GetEntity()
        {
            ICollection<AzureSqlManagedInstanceLinkModel> results = new List<AzureSqlManagedInstanceLinkModel>();
            if (LinkName != null)
            {
                results.Add(ModelAdapter.GetManagedInstanceLink(ResourceGroupName, InstanceName, LinkName));
            }
            else
            {
                results = ModelAdapter.ListManagedInstanceLinks(ResourceGroupName, InstanceName);
            }
            return results;
        }


        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceLinkModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceLinkModel> model)
        {
            return model;
        }
    }
}
