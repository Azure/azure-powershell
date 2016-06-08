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
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, Constants.ApiManagementUser, DefaultParameterSetName = GetAll)]
    [OutputType(typeof(IList<PsApiManagementUser>), ParameterSetName = new[] { GetAll, FindBy })]
    [OutputType(typeof(PsApiManagementUser), ParameterSetName = new[] { GetById })]
    public class GetAzureApiManagementUser : AzureApiManagementCmdletBase
    {
        private const string GetAll = "Get all users";
        private const string GetById = "Get user by ID";
        private const string FindBy = "Find users";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = GetById,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of a user. If specified will try to find user by the identifier. This parameter is optional.")]
        public String UserId { get; set; }

        [Parameter(
            ParameterSetName = FindBy,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "User first name. If specified will try to find users by the first name. This parameter is optional.")]
        public String FirstName { get; set; }

        [Parameter(
            ParameterSetName = FindBy,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "User last name. If specified will try to find users by the last name. This parameter is optional.")]
        public String LastName { get; set; }

        [Parameter(
            ParameterSetName = FindBy,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "User state. If specified will try to find all users in the state. This parameter is optional.")]
        public PsApiManagementUserState? State { get; set; }

        [Parameter(
            ParameterSetName = FindBy,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "User email. If specified will try to find user by email. This parameter is optional.")]
        public String Email { get; set; }

        [Parameter(
            ParameterSetName = FindBy,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of existing group. If specified will try to find all users within the group. This parameter is optional.")]
        public String GroupId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(GetAll))
            {
                var users = Client.UsersList(Context, null, null, null, null, null);
                WriteObject(users, true);
            }
            else if (ParameterSetName.Equals(GetById))
            {
                var user = Client.UserById(Context, UserId);
                WriteObject(user);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }
        }
    }
}
