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
//

namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.Models;

    [Cmdlet("Update", "AzureApiManagementHostname"), OutputType(typeof(ApiManagementAttributes))]
    public class UpdateAzureApiManagementHostname : ApiManagementCmdletBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "ApiManagementAttributes returned by Get-AzureApiManagement. Use PortalHostnameConfiguration and ProxyHostnameConfiguration to update hostnames.")]
        [ValidateNotNull]
        public ApiManagementAttributes ApiManagementAttributes { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecuteCmdLetWrap(() =>
            {
                ApiManagementLongRunningOperation longRunningOperation =
                    this.Client.BeginUpdateHostname(
                        this.ApiManagementAttributes.ResourceGroupName,
                        this.ApiManagementAttributes.Name,
                        this.ApiManagementAttributes.PortalHostnameConfiguration,
                        this.ApiManagementAttributes.ProxyHostnameConfiguration);

                longRunningOperation = WaitForOperationToComplete(longRunningOperation);
                bool success = string.IsNullOrWhiteSpace(longRunningOperation.Error);
                if (!success)
                {
                    WriteErrorWithTimestamp(longRunningOperation.Error);
                }
                else
                {
                    WriteObject(longRunningOperation.ApiManagementAttributes);
                }
            });
        }
    }
}