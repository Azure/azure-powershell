using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Cmdlet
{

    /// <summary>
    /// Cmdlet to create a new Server Trust certificate
    /// </summary>
    [Cmdlet(
        VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceServerTrustCertificate",
        DefaultParameterSetName = CreateParameterSet
        ),
        OutputType(typeof(AzureSqlInstanceServerTrustCertificateModel))]
    public class NewAzureSqlInstanceServerTrustCertificate : AzureSqlInstanceServerTrustCertificateCmdletBase
    {
        private const string CreateParameterSet = "CreateParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = CreateParameterSet,
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
            ParameterSetName = CreateParameterSet,
            Position = 1,
            ValueFromPipeline = true,
            HelpMessage = "The name of the Azure SQL Managed Instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the certificate name
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = CreateParameterSet,
            Position = 2,
            ValueFromPipeline = true,
            HelpMessage = "The name of the certificate.")]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        /// <summary>
        /// Gets or sets the public key
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = CreateParameterSet,
            Position = 3,
            ValueFromPipeline = true,
            HelpMessage = "The value of certificate encoded public key.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^0x[0-9a-fA-F]+$")]
        public string PublicKey { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> GetEntity()
        {
            // We try to get the certificate. Since this is a create, we don't want the certificate to exist
            try
            {
                ModelAdapter.GetServerTrustCertificate(ResourceGroupName, InstanceName, CertificateName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want. We looked and there is no certificate with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The certificate already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerTrustCertificateAlreadyExists, CertificateName, InstanceName),
                "CertificateName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstanceServerTrustCertificateModel> model)
        {
            List<AzureSqlInstanceServerTrustCertificateModel> newEntity = new List<AzureSqlInstanceServerTrustCertificateModel>
            {
                new AzureSqlInstanceServerTrustCertificateModel()
                {
                    ResourceGroupName = ResourceGroupName,
                    InstanceName = InstanceName,
                    CertificateName = CertificateName,
                    PublicKey = PublicKey,
                }
            };
            return newEntity;
        }

        /// <summary>
        /// Create the new Failover Group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> PersistChanges(IEnumerable<AzureSqlInstanceServerTrustCertificateModel> entity)
        {
            return new List<AzureSqlInstanceServerTrustCertificateModel>() {
                ModelAdapter.UpsertServerTrustCertificate(entity.First())
            };
        }
    }
}
