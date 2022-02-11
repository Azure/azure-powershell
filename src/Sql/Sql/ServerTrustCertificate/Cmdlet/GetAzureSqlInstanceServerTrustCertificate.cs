using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Cmdlet
{

    /// <summary>
    /// Cmdlet to create a new Server Trust certificate
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceServerTrustCertificate",
        DefaultParameterSetName = GetByNameParameterSet
        ), 
        OutputType(typeof(AzureSqlInstanceServerTrustCertificateModel))]
    public class GetAzureSqlInstanceServerTrustCertificate : AzureSqlInstanceServerTrustCertificateCmdletBase
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
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, Position = 1, ValueFromPipeline = true, HelpMessage = "The name of the Azure SQL Managed Instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the certificate name
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet, Position = 2, ValueFromPipeline = true, HelpMessage = "The name of the certificate.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/serverTrustCertificates", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        /// <summary>
        /// Gets the certificate if name is passed, otherwise list all available certificates on the managed instance
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> GetEntity()
        {
            ICollection<AzureSqlInstanceServerTrustCertificateModel> results = new List<AzureSqlInstanceServerTrustCertificateModel>();
            if (CertificateName != null)
            {
                results.Add(ModelAdapter.GetServerTrustCertificate(ResourceGroupName, ManagedInstanceName, CertificateName));
            }
            else
            {
                results = ModelAdapter.ListServerTrustCertificates(ResourceGroupName, ManagedInstanceName);
            }
            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> PersistChanges(IEnumerable<AzureSqlInstanceServerTrustCertificateModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstanceServerTrustCertificateModel> model)
        {
            return model;
        }
    }
}
