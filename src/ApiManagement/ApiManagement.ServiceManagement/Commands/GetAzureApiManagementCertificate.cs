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
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementCertificate", DefaultParameterSetName = ContextParameterSet, SupportsShouldProcess= true)]
    [OutputType(typeof(PsApiManagementCertificate), ParameterSetName = new[] { ContextParameterSet, ResourceIdParameterSet })]
    public class GetAzureApiManagementCertificate : AzureApiManagementCmdletBase
    {
        #region ParameterSets
        private const string ContextParameterSet = "ContextParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        #endregion

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of the certificate. If specified will find certificate by the identifier. This parameter is optional. ")]
        public String CertificateId { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm Resource Identifier of the Certificate." +
            " If specified will try to find certificate by the identifier. This parameter is required.")]
        public String ResourceId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string certificateId;

            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                var psBackend = new PsApiManagementCertificate(ResourceId);
                resourceGroupName = psBackend.ResourceGroupName;
                serviceName = psBackend.ServiceName;
                certificateId = psBackend.CertificateId;
            }
            else
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                certificateId = CertificateId;
            }

            if (string.IsNullOrEmpty(certificateId))
            {
                var certificates = Client.CertificateList(resourceGroupName, serviceName);
                WriteObject(certificates, true);
            }
            else
            {
                var certificate = Client.CertificateById(resourceGroupName, serviceName, certificateId);
                WriteObject(certificate);
            }
        }
    }
}
