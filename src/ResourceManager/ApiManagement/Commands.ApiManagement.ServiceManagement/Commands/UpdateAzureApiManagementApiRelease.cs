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
    using Models;
    using Properties;

    [Cmdlet(VerbsData.Update, 
        Constants.ApiManagementApiRelease, 
        DefaultParameterSetName = ExpandedParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementApiRelease), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet })]
    public class UpdateAzureApiManagementApiRelease : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names
        
        private const string ExpandedParameterSet = "ExpandedParameter";
        private const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }
        
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedParameterSet,
            Mandatory = true,
            HelpMessage = "Identifier for the Api Revision ReleaseId. This parameter is required.")]
        public String ReleaseId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedParameterSet,
            Mandatory = true,
            HelpMessage = "Identifier of existing API. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }
                
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Api Release Notes. This parameter is optional.")]
        public String Note { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of type Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiRelease.")]
        public PsApiManagementApiRelease InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If specified then instance of" +
                          " Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiRelease type " +
                          "representing the set API Release.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string apiId;
            string releaseId;

            if (ParameterSetName == ExpandedParameterSet)
            {
                // get identity properties from individual variables
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                apiId = ApiId;
                releaseId = ReleaseId;
            }
            else
            {
                // get identity properties from InputObject
                resourceGroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                apiId = InputObject.ApiId;
                releaseId = InputObject.ReleaseId;
            }

            if (ShouldProcess(releaseId, Resources.UpdateApiRelease))
            {                          
                Client.UpdateApiRelease(
                    resourceGroupName,
                    serviceName,
                    apiId,
                    releaseId,
                    Note,
                    InputObject);

                if (PassThru.IsPresent)
                {
                    var apiRelease = Client.GetApiReleaseById(resourceGroupName, serviceName, apiId, releaseId);
                    WriteObject(apiRelease);
                }
            }
        }
    }
}
