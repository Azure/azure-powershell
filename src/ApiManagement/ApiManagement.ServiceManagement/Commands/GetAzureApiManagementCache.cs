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

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementCache", DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(PsApiManagementCache), ParameterSetName = new[] { ContextParameterSet, ResourceIdParameterSet })]
    public class GetAzureApiManagementCache : AzureApiManagementCmdletBase
    {
        #region ParameterSetNames
        private const string ContextParameterSet = "ContextParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        #endregion

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm Resource Identifier of a cache. If specified will try to find cache by the identifier. This parameter is required.")]
        public String ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            Mandatory = false,
            HelpMessage = "The identifier of the Cache entity. This parameter is optional.")]
        public String CacheId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string cacheId;

            if (ParameterSetName.Equals(ContextParameterSet))
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                cacheId = CacheId;
            }
            else
            {
                var cache = new PsApiManagementCache(ResourceId);
                resourceGroupName = cache.ResourceGroupName;
                serviceName = cache.ServiceName;
                cacheId = cache.CacheId;
            }

            if (string.IsNullOrEmpty(cacheId))
            {
                var caches = Client.CacheList(resourceGroupName, serviceName);
                WriteObject(caches, true);
            }
            else 
            {
                var cache = Client.CacheGetById(
                    resourceGroupName, 
                    serviceName, 
                    cacheId);
                WriteObject(cache);
            }
        }
    }
}
