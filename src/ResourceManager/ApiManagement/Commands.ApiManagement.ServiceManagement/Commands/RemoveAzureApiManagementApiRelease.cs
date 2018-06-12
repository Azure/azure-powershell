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
    using System.Globalization;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Remove,
        Constants.ApiManagementApiRelease,
        DefaultParameterSetName = ByApiReleaseIdParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureApiManagementApiRelease : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        private const string ByApiReleaseIdParameterSet = "ByApiReleaseId";
        private const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        [Parameter(
            ParameterSetName = ByApiReleaseIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementApiRelease. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementApiRelease InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByApiReleaseIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of the API. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = ByApiReleaseIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of the API Release. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ReleaseId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string apiId;
            string releaseId;
                
            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                apiId = InputObject.ApiId;
                releaseId = InputObject.ReleaseId;
                resourceGroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
            }
            else
            {
                apiId = ApiId;
                releaseId = ReleaseId;
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
            }

            var actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.ApiReleaseRemoveDescription, releaseId);
            var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.ApiReleaseRemoveWarning, releaseId);
            
            // Do nothing if force is not specified and user cancelled the operation
            if (!ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            Client.ApiReleaseRemove(resourceGroupName, serviceName, apiId, releaseId);

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
