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
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementCache", SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementCache))]
    public class NewAzureApiManagementCache : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of new cache. Cache identifier (should be either 'default' or valid Azure region identifier). This parameter is optional. If not specified will be generated.")]
        public String CacheId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Redis Connection String. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ConnectionString { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Arm ResourceId of the Azure Redis Cache instance. This parameter is optional. ")]
        [ValidateLength(1, 2000)]
        public String AzureRedisResourceId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Cache Description. This parameter is optional.")]
        [ValidateLength(1, 2000)]
        public String Description { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Cache UseFromLocation. This parameter is optional, default value 'default'.")]
        [ValidateLength(1, 2000)]
        public String UseFromLocation { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string cacheId = CacheId ?? "default";

            if (ShouldProcess(CacheId, Resources.CreateCache))
            {
                var cache = Client.CacheCreate(
                    Context,
                    cacheId,
                    ConnectionString,
                    Description,
                    AzureRedisResourceId,
                    UseFromLocation ?? "default");

                WriteObject(cache);
            }
        }
    }
}
