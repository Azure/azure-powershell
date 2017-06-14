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
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Set, Constants.ApiManagementLogger)]
    [OutputType(typeof(PsApiManagementLogger))]
    public class SetAzureApiManagementLogger : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of logger to update. This parameter is mandatory.")]
        [ValidateNotNullOrEmpty]
        public String LoggerId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "EventHub Entity name. This parameter is optional.")]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "EventHub Connection String with Send Policy Rights. This parameter is optional.")]
        public String ConnectionString { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Description of the Logger. This parameter is optional.")]
        public String Description { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Determines whether the records in the logger are buffered before publishing." +
                          " This parameter is optional and the default value is true. ")]
        public SwitchParameter IsBuffered { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of " +
                          "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementLogger type " +
                          " representing the modified logger will be written to output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var credentials = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(ConnectionString))
            {
                credentials.Add("name", Name);
                credentials.Add("connectionString", ConnectionString);
            }
            else if ((string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(ConnectionString)) ||
                (!string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(ConnectionString)))
            {
                WriteWarning("When updating Logger Credentials, we need to Provide both -Name and -ConnectionString parameters");
                return;
            }

            Client.LoggerSet(Context, LoggerTypeContract.AzureEventHub, LoggerId, Description, credentials, IsBuffered.IsPresent);

            if (PassThru)
            {
                var @logger = Client.LoggerById(Context, LoggerId);
                WriteObject(@logger);
            }
        }
    }
}
