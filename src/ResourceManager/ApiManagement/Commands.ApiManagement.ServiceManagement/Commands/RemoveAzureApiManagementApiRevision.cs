﻿//  
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
    using Management.ApiManagement.Models;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementApiRevision",SupportsShouldProcess = true, DefaultParameterSetName = ByApiIdParameterSet)]
    [OutputType(typeof(bool), ParameterSetName = new [] { ByApiIdParameterSet, ByInputObjectParameterSet })]
    public class RemoveAzureApiManagementApiRevision : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        private const string ByApiIdParameterSet = "ByApiId";
        private const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        [Parameter(
            ParameterSetName = ByApiIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ByApiIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of the API. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }
        
        [Parameter(
            ParameterSetName = ByApiIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of the API Revision. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiRevision { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementApiRelease. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementApi InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string apiId = ApiId;
            string apiRevision = ApiRevision;
            string resourceGroupName;
            string serviceName;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                apiId = InputObject.ApiId;
                apiRevision = InputObject.ApiRevision;
                resourceGroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
            }
            else
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
            }

            var actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.ApiRevisionRemoveDescription, apiId, apiRevision);
            var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.ApiRevisionRemoveWarning, apiId, apiRevision);

            // Do nothing if force is not specified and user cancelled the operation
            if (!ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            string id = apiId.ApiRevisionIdentifier(apiRevision);
            Client.ApiRemoveRevision(resourceGroupName, serviceName, id);

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
