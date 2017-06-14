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

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementGroup)]
    [OutputType(typeof(PsApiManagementGroup))]
    public class NewAzureApiManagementGroup : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of new group. This parameter is optional. If not specified will be generated.")]
        public String GroupId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Group name. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Group description. This parameter is optional.")]
        public String Description { get; set; }

        [Parameter(
           ValueFromPipelineByPropertyName = true,
           Mandatory = false,
           HelpMessage = "Group Type." +
                         " Custom Group is User defined Group." +
                         " System Group includes Administrator, Developers and Guests. You cannot create or update a System Group. " +
                         " External Group is groups from External Identity Provider like Azure Active Directory." +
                         " This parameter is optional and by default assumed to be a Custom Group.")]
        public PsApiManagementGroupType? Type { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "For external groups, this property contains the id of the group from the external identity provider," +
                          " e.g. Azure Active Directory aad://contoso5api.onmicrosoft.com/groups/12ad42b1-592f-4664-a77b4250-2f2e82579f4c;" +
                          " otherwise the value is null.")]
        public String ExternalId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string groupId = GroupId ?? Guid.NewGuid().ToString("N");

            var group = Client.GroupCreate(Context, groupId, Name, Description, Type, ExternalId);

            WriteObject(group);
        }
    }
}
