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

    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementCache", SupportsShouldProcess = true, DefaultParameterSetName = ExpandedParameterSet)]
    [OutputType(typeof(PsApiManagementCache), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet, ByResourceIdParameterSet })]
    public class UpdateAzureApiManagementCache : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        protected const string ExpandedParameterSet = "ExpandedParameter";
        protected const string ByInputObjectParameterSet = "ByInputObject";
        protected const string ByResourceIdParameterSet = "ByResourceId";

        #endregion

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of new cache. This parameter is required.")]
        public String CacheId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementCache. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementCache InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm ResourceId of Cache. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ResourceId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Redis Connection String. This parameter is optional.")]
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

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of " +
            "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementCache type " +
            " representing the modified cache will be written to output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourcegroupName;
            string serviceName;
            string cacheId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourcegroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                cacheId = InputObject.CacheId;
            }
            else if (ParameterSetName.Equals(ExpandedParameterSet))
            {
                resourcegroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                cacheId = CacheId;
            }
            else
            {
                var cache = new PsApiManagementCache(ResourceId);
                resourcegroupName = cache.ResourceGroupName;
                serviceName = cache.ServiceName;
                cacheId = cache.CacheId;
            }

            if (ShouldProcess(cacheId, Resources.SetCache))
            {
                Client.CacheSet(
                    resourcegroupName,
                    serviceName,
                    cacheId,
                    ConnectionString,
                    Description,
                    ResourceId,
                    UseFromLocation,
                    InputObject);

                if (PassThru)
                {
                    var cache = Client.CacheGetById(resourcegroupName, serviceName, cacheId);
                    WriteObject(cache);
                }
            }
        }
    }
}
