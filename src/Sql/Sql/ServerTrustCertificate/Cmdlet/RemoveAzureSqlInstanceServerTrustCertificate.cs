using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
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
        DefaultParameterSetName = DeleteByNameParameterSet,
        SupportsShouldProcess = true
        ), OutputType(typeof(AzureSqlInstanceServerTrustCertificateModel))]
    public class RemoveAzureSqlInstanceServerTrustCertificate : AzureSqlInstanceServerTrustCertificateCmdletBase
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
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 1, HelpMessage = "The name of the Azure SQL Managed Instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the certificate name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 2, HelpMessage = "The name of the certificate.")]
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, Position = 1, HelpMessage = "The name of the certificate.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/serverTrustCertificates", nameof(ResourceGroupName), nameof(InstanceName))]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "The instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel Instance { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "The certificate input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlInstanceServerTrustCertificateModel Certificate { get; set; }

        /// <summary>
        /// Gets or sets the certificate Resource Id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "The certificate resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case DeleteByNameParameterSet:
                    // default case, we're getting RG, MI and Cert names directly from args
                    break;
                case DeleteByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, Cert name received directly from arg
                    ResourceGroupName = Instance.ResourceGroupName;
                    InstanceName = Instance.ManagedInstanceName;
                    break;
                case DeleteByInputObjectParameterSet:
                    // we need to extract RG, MI and Certificate name directly from the Certificate object
                    ResourceGroupName = Certificate.ResourceGroupName;
                    InstanceName = Certificate.InstanceName;
                    CertificateName = Certificate.CertificateName;
                    break;
                case DeleteByResourceIdParameterSet:
                    // we need to derive RG, MI and Cert name from resource id
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    CertificateName = resourceInfo.ResourceName;
                    break;
                default:
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceServerTrustCertificateDescription, CertificateName, InstanceName),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceServerTrustCertificateWarning, CertificateName, InstanceName),
                Properties.Resources.ShouldProcessCaption))
            {
                base.ExecuteCmdlet();
            }
        }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> GetEntity()
        {
            return new List<AzureSqlInstanceServerTrustCertificateModel>() {
                ModelAdapter.GetServerTrustCertificate(ResourceGroupName, InstanceName, CertificateName)
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
            ModelAdapter.RemoveServerTrustCertificate(entityToDelete.ResourceGroupName, entityToDelete.InstanceName, entityToDelete.CertificateName);
            return entity;
        }
    }
}
