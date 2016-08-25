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

    [Cmdlet(VerbsData.Save, Constants.ApiManagementTenantGitConfiguration, SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementOperationResult))]
    public class SaveAzureApiManagementTenantConfiguration : AzureApiManagementCmdletBase
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
            HelpMessage = "Name of the Git branch in which to commit the current configuration snapshot. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Branch { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If true, the current configuration database is committed to the Git repository," +
                          " even if the Git repository has newer changes that would be overwritten. " +
                          "This parameter is optional.")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of" +
                          " Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementOperationResult type" +
                          " representing the operation result will be written to output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.SaveTenantConfigurationDescription, Branch);
            var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.SaveTenantConfigurationWarning, Branch);

            // Do nothing if force is not specified and user cancelled the operation
            if (!ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            ExecuteTenantConfigurationLongRunningCmdletWrap(
                () => Client.BeginSaveTenantGitConfiguration(
                    Context,
                    Branch,
                    Force.IsPresent),
                PassThru.IsPresent
                );
        }
    }
}
