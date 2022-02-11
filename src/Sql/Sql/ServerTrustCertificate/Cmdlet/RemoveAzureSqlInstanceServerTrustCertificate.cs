using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Cmdlet
{

    /// <summary>
    /// Cmdlet to remove Server Trust certificate
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceServerTrustCertificate",
        DefaultParameterSetName = RemoveParameterSet,
        SupportsShouldProcess = true
        ), OutputType(typeof(AzureSqlInstanceServerTrustCertificateModel))]
    public class RemoveAzureSqlInstanceServerTrustCertificate : AzureSqlInstanceServerTrustCertificateCmdletBase
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
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the certificate name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemoveParameterSet,
            Position = 2,
            ValueFromPipeline = true,
            HelpMessage = "The name of the certificate")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/serverTrustCertificates", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

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

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> GetEntity()
        {
            return new List<AzureSqlInstanceServerTrustCertificateModel>() {
                ModelAdapter.GetServerTrustCertificate(ResourceGroupName, ManagedInstanceName, CertificateName)
            };
        }

        /// <summary>
        /// Apply user input. Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstanceServerTrustCertificateModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the certificate.
        /// </summary>
        /// <param name="entity">The certificate being deleted</param>
        /// <returns>The instance that was deleted</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> PersistChanges(IEnumerable<AzureSqlInstanceServerTrustCertificateModel> entity)
        {
            var entityToDelete = entity.First();
            ModelAdapter.RemoveServerTrustCertificate(entityToDelete.ResourceGroupName, entityToDelete.ManagedInstanceName, entityToDelete.CertificateName);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlInstanceServerTrustCertificateDescription, this.CertificateName, this.ManagedInstanceName),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlInstanceServerTrustCertificateWarning, this.CertificateName, this.ManagedInstanceName),
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
