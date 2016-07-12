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

    [Cmdlet(VerbsData.Publish, Constants.ApiManagementTenantGitConfiguration, SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementOperationResult))]
    public class PublishAzureApiManagementTenantConfiguration : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of the Git branch from which the configuration is to be deployed to the configuration database." +
                          " This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Branch { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Enforce deleting subscriptions to products that are deleted in this update. " +
                          "This parameter is optional. Default value is false.")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified will only validate the changes in the specified git Branch and not deploy. " +
                          "This parameter is optional. Default value is false.")]
        public SwitchParameter ValidateOnly { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementOperationResult" +
                          " type representing the operation result will be written to output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ValidateOnly.IsPresent)
            {
                ExecuteTenantConfigurationLongRunningCmdletWrap(
                    () => Client.BeginValidateTenantGitConfiguration(
                        Context,
                        Branch,
                        Force.IsPresent),
                    PassThru.IsPresent
                    );
            }
            else
            {
                // confirm with user before pushing the update.
                if (!ShouldProcess(
                    Resources.PublishTenantConfigurationDescription,
                    Resources.PublishTenantConfigurationWarning,
                    Resources.ShouldProcessCaption))
                {
                    return;
                }

                ExecuteTenantConfigurationLongRunningCmdletWrap(
                    () => Client.BeginPublishTenantGitConfiguration(
                        Context,
                        Branch,
                        Force.IsPresent),
                    PassThru.IsPresent
                    );
            }
        }
    }
}
