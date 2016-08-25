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

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementUser)]
    [OutputType(typeof(PsApiManagementUser))]
    public class NewAzureApiManagementUser : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of new user. This parameter is optional. If not specified will be genetated.")]
        public String UserId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "User first name. This parameter is required. Must be 1 to 100 characters long.")]
        [ValidateNotNullOrEmpty]
        public String FirstName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "User last name. This parameter is required. Must be 1 to 100 characters long.")]
        [ValidateNotNullOrEmpty]
        public String LastName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "User email. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Email { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "User password. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Password { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "User state. This parameter is optional. Default value is $null.")]
        public PsApiManagementUserState? State { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Note on the user. This parameter is optional. Default value is $null.")]
        public String Note { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string userId = UserId ?? Guid.NewGuid().ToString("N");

            var user = Client.UserCreate(Context, userId, FirstName, LastName, Password, Email, State, Note);

            WriteObject(user);
        }
    }
}
