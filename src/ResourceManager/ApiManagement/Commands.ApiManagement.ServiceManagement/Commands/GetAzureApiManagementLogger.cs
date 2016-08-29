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

    [Cmdlet(VerbsCommon.Get, Constants.ApiManagementLogger, DefaultParameterSetName = GetAll)]
    [OutputType(typeof(IList<PsApiManagementLogger>), ParameterSetName = new[] { GetAll })]
    [OutputType(typeof(PsApiManagementLogger), ParameterSetName = new[] { GetById })]
    public class GetAzureApiManagementLogger : AzureApiManagementCmdletBase
    {
        private const string GetAll = "Get all loggers";
        private const string GetById = "Get by logger ID";

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
            HelpMessage = "Identifier of a logger. If specified will try to find logger by the identifier. This parameter is optional.")]
        public String LoggerId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(GetAll))
            {
                var loggers = Client.LoggersList(Context);
                WriteObject(loggers, true);
            }
            else if (ParameterSetName.Equals(GetById))
            {
                var logger = Client.LoggerById(Context, LoggerId);
                WriteObject(logger);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }
        }
    }
}
