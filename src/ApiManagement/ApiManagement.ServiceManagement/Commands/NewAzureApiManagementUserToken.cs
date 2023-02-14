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

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementUserToken")]
    [OutputType(typeof(PsApiManagementUserToken))]
    public class NewAzureApiManagementUserToken : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing user. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String UserId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "User Key to use when generating the Token. This parameter is optional.")]  
        [PSDefaultValue(Value = PsApiManagementUserKeyType.Primary, Help = "By Default Primary Key is used to generate token")]
        public PsApiManagementUserKeyType KeyType { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Expiry of the Token. If not specified, the token is created to expire after 8 hours." +
            " This parameter is optional.")]
        public DateTime? Expiry { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var userToken = Client.UserGetToken(
                Context,
                UserId,
                KeyType,
                Expiry ?? DateTime.UtcNow.AddHours(8));

            WriteObject(userToken);
        }
    }
}
