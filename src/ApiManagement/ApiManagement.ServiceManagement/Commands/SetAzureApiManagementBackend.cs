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
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementBackend", SupportsShouldProcess = true, DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(PsApiManagementBackend))]
    public class SetAzureApiManagementBackend : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names
        protected const string ContextParameterSet = "ContextParameterSet";
        protected const string ByInputObjectParameterSet = "ByInputObject";
        #endregion

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of new backend. This parameter is required.")]
        public String BackendId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementBackend. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementBackend InputObject { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Backend Communication protocol. This parameter is optional.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("http", "soap")]
        public String Protocol { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Runtime Url for the Backend. This parameter is optional.")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(1, 2000)]
        public String Url { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Original uri of entity in external system backend points to. This parameter is optional.")]
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

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of " +
                          "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementBackend type " +
                          " representing the modified backend will be written to output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourcegroupName;
            string serviceName;
            string backendId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourcegroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                backendId = InputObject.BackendId;
            }
            else 
            {
                resourcegroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                backendId = BackendId;
            }

            if (ShouldProcess(backendId, Resources.SetBackend))
            {
                Client.BackendSet(
                    resourcegroupName,
                    serviceName,
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

                if (PassThru)
                {
                    var @backend = Client.BackendById(resourcegroupName, serviceName, backendId);
                    WriteObject(@backend);
                }
            }
        }
    }
}
