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

using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementBackend, SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementBackend))]
    public class NewAzureApiManagementBackend : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of new backend. This parameter is optional. If not specified will be generated.")]
        public String BackendId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Backend Communication protocol. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("http", "soap")]
        public String Protocol { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Runtime Url for the Backend. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(1, 2000)]
        public String Url { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Management Uri of the Resource in External System. This parameter is optional. " +
                          "This url can be the Arm Resource Id of Logic Apps, Function Apps or Api Apps. ")]
        [ValidateLength(1, 2000)]
        public String ResourceId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Backend Title. This parameter is optional.")]
        [ValidateLength(1, 300)]
        public String Title { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Backend Description. This parameter is optional.")]
        [ValidateLength(1, 2000)]
        public String Description { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Whether to Skip Certificate Chain Validation when talking to the Backend. This parameter is optional.")]
        public bool? SkipCertificateChainValidation { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Whether to skip Certificate Name Validation when talking to the Backend. This parameter is optional.")]
        public bool? SkipCertificateNameValidation { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Credential to be used when talking to the Backend. This parameter is optional.")]
        public PsApiManagementBackendCredential Credential { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Proxy Server details to be used while sending request to the Backend. This parameter is optional.")]
        public PsApiManagementBackendProxy Proxy { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Service Fabric Cluster Backend details. This parameter is optional.")]
        public PsApiManagementServiceFabric ServiceFabricCluster { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string backendId = BackendId ?? Guid.NewGuid().ToString("N");

            if (ShouldProcess(BackendId, Resources.CreateBackend))
            {
                var backend = Client.BackendCreate(
                    Context,
                    backendId,
                    Url,
                    Protocol,
                    Title,
                    Description,
                    ResourceId,
                    SkipCertificateChainValidation,
                    SkipCertificateNameValidation,
                    Credential,
                    Proxy,
                    ServiceFabricCluster);

                WriteObject(backend);
            }
        }
    }
}
