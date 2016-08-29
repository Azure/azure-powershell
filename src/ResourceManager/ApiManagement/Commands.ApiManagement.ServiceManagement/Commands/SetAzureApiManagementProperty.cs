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

    [Cmdlet(VerbsCommon.Set, Constants.ApiManagementProperty)]
    [OutputType(typeof(PsApiManagementProperty))]
    public class SetAzureApiManagementProperty : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of property to update. This parameter is mandatory.")]
        [ValidateNotNullOrEmpty]
        public String PropertyId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Name of the property. Maximum length is 100 characters. " +
                          "It may contain only letters, digits, period, dash, and underscore characters. " +
                          "This parameter is optional.")]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Value of the property. Can contain policy expressions. Maximum length is 1000 characters. " +
                          "It may not be empty or consist only of whitespace." +
                          " This parameter is optional.")]
        public String Value { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Whether the property is a secret and its value should be encrypted. This parameter is optional.")]
        public bool? Secret { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Tags associated with a property. This parameter is optional.")]
        public string[] Tags { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of " +
                          "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementProperty type " +
                          "representing the modified property will be written to output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            Client.PropertySet(
                Context,
                PropertyId,
                Name,
                Value,
                Secret,
                Tags);

            if (PassThru)
            {
                var @property = Client.PropertyById(Context, PropertyId);
                WriteObject(@property);
            }
        }
    }
}
