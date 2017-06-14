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

    [Cmdlet(VerbsCommon.Get, Constants.ApiManagementGroup, DefaultParameterSetName = GetAll)]
    [OutputType(typeof(IList<PsApiManagementGroup>), ParameterSetName = new[] { GetAll, FindByUser, FindByProduct })]
    [OutputType(typeof(PsApiManagementGroup), ParameterSetName = new[] { GetById })]
    public class GetAzureApiManagementGroup : AzureApiManagementCmdletBase
    {
        private const string GetAll = "Get all groups";
        private const string GetById = "Get by group ID";
        private const string FindByUser = "Find groups by user";
        private const string FindByProduct = "Find groups by product";

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
            HelpMessage = "Identifier of a group. If specified will try to find group by the identifier. This parameter is optional.")]
        public String GroupId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Group name. If specified will try to find group by the name. This parameter is optional.")]
        public String Name { get; set; }

        [Parameter(
            ParameterSetName = FindByUser,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of existing user. If specified will return all groups the user belongs to. " +
                          "This parameter is optional.")]
        public String UserId { get; set; }

        [Parameter(
            ParameterSetName = FindByProduct,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of existing product. If specified will return all groups the product assigned to. " +
                          "This parameter is optional.")]
        public String ProductId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(GetAll))
            {
                var groups = Client.GroupsList(Context, Name, null, null);
                WriteObject(groups, true);
            }
            else if (ParameterSetName.Equals(GetById))
            {
                var group = Client.GroupById(Context, GroupId);
                WriteObject(group);
            }
            else if (ParameterSetName.Equals(FindByUser))
            {
                var groups = Client.GroupsList(Context, Name, UserId, null);
                WriteObject(groups, true);
            }
            else if (ParameterSetName.Equals(FindByProduct))
            {
                var groups = Client.GroupsList(Context, Name, null, ProductId);
                WriteObject(groups, true);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }
        }
    }
}
