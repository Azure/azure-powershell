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
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlInstanceServerTrustCertificateModel))]
    public class RemoveAzureSqlInstanceServerTrustCertificate : AzureSqlInstanceServerTrustCertificateCmdletBase
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByParentObjectParameterSet = "DeleteByParentObjectParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 1, HelpMessage = "Name of Azure SQL Managed Instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the certificate name
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 2, HelpMessage = "Name of the certificate.")]
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, Position = 1, HelpMessage = "Name of the certificate.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/serverTrustCertificates", nameof(ResourceGroupName), nameof(InstanceName))]
        [ValidateNotNullOrEmpty]
        [Alias("CertificateName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Instance input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Certificate input object.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlInstanceServerTrustCertificateModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the certificate Resource Id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DeleteByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Certificate resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Defines whether the cmdlets will output the model object at the end of its execution.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Defines whether to return the removed Server Trust Certificate")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out.
        /// </summary>
        protected override bool WriteResult()
        {
            return PassThru.IsPresent;
        }

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
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case DeleteByInputObjectParameterSet:
                    // we need to extract RG, MI and Certificate name directly from the Certificate object
                    ResourceGroupName = InputObject.ResourceGroupName;
                    InstanceName = InputObject.InstanceName;
                    Name = InputObject.Name;
                    break;
                case DeleteByResourceIdParameterSet:
                    // we need to derive RG, MI and Cert name from resource id
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    Name = resourceInfo.ResourceName;
                    break;
                default:
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceServerTrustCertificateDescription, ResourceGroupName, InstanceName, Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceServerTrustCertificateWarning, ResourceGroupName, InstanceName, Name),
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
                ModelAdapter.GetServerTrustCertificate(ResourceGroupName, InstanceName, Name)
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
            ModelAdapter.RemoveServerTrustCertificate(entityToDelete.ResourceGroupName, entityToDelete.InstanceName, entityToDelete.Name);
            return entity;
        }
    }
}
