using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Server Trust certificate
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLink",
        DefaultParameterSetName = RemoveParameterSet,
        SupportsShouldProcess = true
        ),
        OutputType(typeof(AzureSqlManagedInstanceLinkModel))]
    public class RemoveAzureSqlManagedInstanceLink : AzureSqlManagedInstanceLinkCmdletBase
    {
        private const string RemoveParameterSet = "RemoveParameterSet";
        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveParameterSet,
            Position = 1,
            ValueFromPipeline = true,
            HelpMessage = "The name of the Azure SQL Managed Instance")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveParameterSet,
            Position = 2,
            ValueFromPipeline = true,
            HelpMessage = "The name of the MI link")]
        [ValidateNotNullOrEmpty]
        public string LinkName { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter AllowDataLoss { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

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
        /// Deletes the certificate.
        /// </summary>
        /// <param name="entity">The certificate being deleted</param>
        /// <returns>The instance that was deleted</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceLinkModel> entity)
        {
            ModelAdapter.RemoveManagedInstanceLink(ResourceGroupName, InstanceName, LinkName);
            return entity;
        }
        
        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlInstanceServerTrustCertificateDescription, LinkName, InstanceName),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlInstanceServerTrustCertificateWarning, LinkName, InstanceName),
               Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
