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

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementNamedValueSecretValue", DefaultParameterSetName = Default)]
    [OutputType(typeof(PsApiManagementNamedValueSecretValue))]
    public class GetAzureApiManagementNamedValueSecretValue : AzureApiManagementCmdletBase
    {
        private const string Default = "Default";
        private const string GetById = "GetByNamedValueId";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = GetById,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of a the named value. This parameter is required.")]
        public String NamedValueId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (!string.IsNullOrEmpty(NamedValueId))
            {
                var property = Client.NamedValueSecretValueById(Context, NamedValueId);
                WriteObject(property);
            }
            else
            {
                throw new InvalidOperationException("Named Value Id not provided");
            }
        }
    }
}
