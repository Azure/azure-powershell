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
using Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Cmdlet
{

    /// <summary>
    /// Cmdlet to create a new Server Trust certificate
    /// </summary>
    [Cmdlet(
        VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceServerTrustCertificate",
        DefaultParameterSetName = CreateByNameParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlInstanceServerTrustCertificateModel))]
    public class NewAzureSqlInstanceServerTrustCertificate : AzureSqlInstanceServerTrustCertificateCmdletBase
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
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the certificate name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 2, HelpMessage = "Name of the certificate.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, Position = 1, HelpMessage = "Name of the certificate.")]
        [ValidateNotNullOrEmpty]
        [Alias("CertificateName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the public key
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 3, HelpMessage = "Value of certificate encoded public key.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, Position = 2, HelpMessage = "Value of certificate encoded public key.")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("^0x[0-9a-fA-F]+$")]
        public string PublicKey { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case CreateByNameParameterSet:
                    // default case, we're getting RG, MI, Cert name and Public key directly from args
                    break;
                case CreateByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, Cert name and Public key received directly from arg
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                default:
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (!ShouldProcess(
              string.Format(CultureInfo.InvariantCulture, Properties.Resources.CreateAzureSqlInstanceServerTrustCertificateDescription, ResourceGroupName, InstanceName, Name),
              string.Format(CultureInfo.InvariantCulture, Properties.Resources.CreateAzureSqlInstanceServerTrustCertificateWarning, ResourceGroupName, InstanceName, Name),
              Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlInstanceServerTrustCertificateModel> GetEntity()
        {
            // We try to get the certificate. Since this is a create, we don't want the certificate to exist
            try
            {
                ModelAdapter.GetServerTrustCertificate(ResourceGroupName, InstanceName, Name);
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
            throw new PSArgumentException(string.Format(Properties.Resources.ServerTrustCertificateAlreadyExists, Name, InstanceName), "CertificateName");
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
                    Name = Name,
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
