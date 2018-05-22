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
        Constants.ApiManagementApiVersionSet,
        DefaultParameterSetName = ExpandedParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureApiManagementApiVersionSet : AzureApiManagementCmdletBase
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
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementApiVersionSet. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementApiVersionSet InputObject { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of the API Version Set. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiVersionSetId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string apiVersionSetId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                apiVersionSetId = InputObject.ApiVersionSetId;
                resourceGroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
            }
            else
            {
                apiVersionSetId = ApiVersionSetId;
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
            }

            var actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.ApiVersionSetRemoveDescription, apiVersionSetId);
            var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.ApiVersionSetRemoveWarning, apiVersionSetId);

            // Do nothing if force is not specified and user cancelled the operation
            if (!ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            Client.ApiVersionSetRemove(resourceGroupName, serviceName, ApiVersionSetId);

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
