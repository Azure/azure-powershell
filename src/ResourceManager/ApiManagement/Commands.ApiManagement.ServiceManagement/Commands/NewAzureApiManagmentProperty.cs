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

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementProperty)]
    [OutputType(typeof(PsApiManagementProperty))]
    public class NewAzureApiManagementProperty : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of new property. This parameter is optional." +
                          " If not specified will be generated.")]
        public String PropertyId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of the property. Maximum length is 100 characters." +
                          " It may contain only letters, digits, period, dash, and underscore characters." +
                          " This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Value of the property. Can contain policy expressions. Maximum length is 1000 characters." +
                          " It may not be empty or consist only of whitespace. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Value { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Determines whether the value is a secret and should be encrypted or not." +
                          " This parameter is optional. Default Value is false.")]
        public SwitchParameter Secret { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Tags to be associated with Property. This parameter is optional.")]
        public string[] Tags { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string propertyId = PropertyId ?? Guid.NewGuid().ToString("N");

            var logger = Client.PropertyCreate(
                Context,
                propertyId,
                Name,
                Value,
                Secret,
                Tags);

            WriteObject(logger);
        }
    }
}
