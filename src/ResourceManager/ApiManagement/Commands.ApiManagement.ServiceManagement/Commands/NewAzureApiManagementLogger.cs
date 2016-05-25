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
    using Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementLogger)]
    [OutputType(typeof(PsApiManagementLogger))]
    public class NewAzureApiManagementLogger : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of new logger. This parameter is optional. If not specified will be generated.")]
        public String LoggerId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "EventHub Entity name. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "EventHub Connection String with Send Policy Rights. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ConnectionString { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Logger description. This parameter is optional.")]
        public String Description { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Whether the logs should be buffered before sending to EventHub. This parameter is optional.")]
        public bool? IsBuffered { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string loggerId = LoggerId ?? Guid.NewGuid().ToString("N");

            var credentials = new Dictionary<string, string>();
            credentials.Add("name", Name);
            credentials.Add("connectionString", ConnectionString);

            var logger = Client.LoggerCreate(
                Context,
                LoggerTypeContract.AzureEventHub,
                loggerId,
                Description,
                credentials,
                IsBuffered ?? true);

            WriteObject(logger);
        }
    }
}
