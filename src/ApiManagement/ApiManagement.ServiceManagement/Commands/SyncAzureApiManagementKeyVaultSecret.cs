//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;
    using System;
    using System.Management.Automation;

    [Cmdlet("Sync", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementKeyVaultSecret", SupportsShouldProcess = true, DefaultParameterSetName = ResourceIdParameterSet)]
    [OutputType(typeof(PsApiManagementKeyVaultEntity), ParameterSetName = new[] { ResourceIdParameterSet, ByInputObjectParameterSet })]
    public class SyncAzureApiManagementKeyVaultSecret : AzureApiManagementCmdletBase
    {
        #region ParameterSets
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string ByInputObjectParameterSet = "ByInputObject";
        #endregion

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm ResourceId of the Keyvault Based object. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = false,
            HelpMessage = "Instance of PsApiManagementCert. This parameter or NameValue is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementCertificate InputObjectCert { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = false,
            HelpMessage = "Instance of PsApiManagementNamedvalue. This parameter or Certificate is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementNamedValue InputObjectNamedvalue { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            bool isCert;

            string entityId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                if (InputObjectNamedvalue != null)
                {
                    isCert = false;
                    entityId = InputObjectNamedvalue.NamedValueId;
                    resourceGroupName = InputObjectNamedvalue.ResourceGroupName;
                    serviceName = InputObjectNamedvalue.ServiceName;
                }
                else if (InputObjectCert != null)
                {
                    isCert = true;
                    entityId = InputObjectCert.CertificateId;
                    resourceGroupName = InputObjectCert.ResourceGroupName;
                    serviceName = InputObjectCert.ServiceName;
                }
                else
                {
                    throw new InvalidOperationException(string.Format("Object not exist."));
                }
            }
            else
            {
                var split = ResourceId.Split('/');
                var entityType = split[split.Length - 2];
                if (string.Equals(entityType, "certificates", StringComparison.OrdinalIgnoreCase))
                {
                    isCert = true;
                    var psBackend = new PsApiManagementCertificate(ResourceId);
                    resourceGroupName = psBackend.ResourceGroupName;
                    serviceName = psBackend.ServiceName;
                    entityId = psBackend.CertificateId;
                }
                else if (string.Equals(entityType, "namedvalues", StringComparison.OrdinalIgnoreCase))
                {
                    isCert = false;
                    var psBackend = new PsApiManagementNamedValue(ResourceId);
                    resourceGroupName = psBackend.ResourceGroupName;
                    serviceName = psBackend.ServiceName;
                    entityId = psBackend.NamedValueId;
                }
                else
                {
                    throw new InvalidOperationException(string.Format("Object with Id {0} supported for a KeyVault refresh.", ResourceId));
                }
            }

            if (string.IsNullOrEmpty(entityId))
            {
                throw new InvalidOperationException(string.Format("Object with Id {0} supported for a KeyVault refresh.", entityId));

            }

            if (ShouldProcess(entityId, Resources.RefreshKeyVaultBasedObject))
            {
                if (isCert)
                {
                    var entity = Client.CertificateKeyVaultRefresh(resourceGroupName, serviceName, entityId);
                    WriteObject(entity);
                }
                else
                {
                    var entity = Client.NamedValueKeyVaultRefresh(resourceGroupName, serviceName, entityId);
                    WriteObject(entity);
                }
            }
        }
    }
}
