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

    [Cmdlet(VerbsCommon.Get, Constants.ApiManagementProperty, DefaultParameterSetName = GetAll)]
    [OutputType(typeof(IList<PsApiManagementProperty>), ParameterSetName = new[] { GetAll, FindByName, FindByTag })]
    [OutputType(typeof(PsApiManagementProperty), ParameterSetName = new[] { GetById })]
    public class GetAzureApiManagementProperty : AzureApiManagementCmdletBase
    {
        private const string GetAll = "Get all properties";
        private const string GetById = "Get by property ID";
        private const string FindByName = "Find properties containing Name";
        private const string FindByTag = "Find properties by Tag";

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
            HelpMessage = "Identifier of a property. If specified will try to find property by the identifier. This parameter is optional.")]
        public String PropertyId { get; set; }

        [Parameter(
            ParameterSetName = FindByName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Finds Properties with names containing the string Name. This parameter is optional.")]
        public String Name { get; set; }

        [Parameter(
            ParameterSetName = FindByTag,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Finds Properties associated with a Tag. If specified will return all properties associated with a tag. This parameter is optional.")]
        public String Tag { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(GetAll))
            {
                var properties = Client.PropertiesList(Context);
                WriteObject(properties, true);
            }
            else if (ParameterSetName.Equals(GetById))
            {
                var property = Client.PropertyById(Context, PropertyId);
                WriteObject(property);
            }
            else if (ParameterSetName.Equals(FindByName))
            {
                var properties = Client.PropertyByName(Context, Name);
                WriteObject(properties, true);
            }
            else if (ParameterSetName.Equals(FindByTag))
            {
                var properties = Client.PropertyByTag(Context, Tag);
                WriteObject(properties, true);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }
        }
    }
}
