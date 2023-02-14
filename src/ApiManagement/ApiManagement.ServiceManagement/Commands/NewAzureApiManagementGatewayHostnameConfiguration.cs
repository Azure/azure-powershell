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
    using System;
    using System.Management.Automation;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementGatewayHostnameConfiguration", SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementGatewayHostnameConfiguration))]
    public class NewAzureApiManagementGatewayHostnameConfiguration : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing gateway. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String GatewayId { get; set; }

        [Parameter(
                   ValueFromPipelineByPropertyName = true,
                   Mandatory = false,
                   HelpMessage = "Identifier of new gateway hostname confiuration. This parameter is optional. If not specified will be generated.")]
        public String GatewayHostnameConfigurationId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Hostname. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Hostname { get; set; }

        [Parameter(
                   ValueFromPipelineByPropertyName = true,
                   Mandatory = true,
                   HelpMessage = "A resource identifier for the existing certificate id. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String CertificateResourceId { get; set; }

        [Parameter(
           ValueFromPipelineByPropertyName = true,
           Mandatory = false,
           HelpMessage = "Flag to enforce NegotiateClientCertificate. This parameter is optional.")]
        public SwitchParameter NegotiateClientCertificate { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string hostnameId = GatewayHostnameConfigurationId ?? Guid.NewGuid().ToString("N");

            var config = Client.GatewayHostnameConfigurationCreate(Context, GatewayId, hostnameId, Hostname, CertificateResourceId, NegotiateClientCertificate.IsPresent);

            WriteObject(config);
        }
    }
}
