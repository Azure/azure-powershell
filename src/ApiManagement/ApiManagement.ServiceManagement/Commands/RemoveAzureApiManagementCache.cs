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
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementCache", SupportsShouldProcess = true, DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(bool), ParameterSetName = new [] { ContextParameterSet, ByInputObjectParameterSet, ByResourceIdParameterSet })]
    public class RemoveAzureApiManagementCache : AzureApiManagementCmdletBase
    {
        #region ParameterSets
        const string ContextParameterSet = "ContextParameterSetName";
        const string ByInputObjectParameterSet = "ByInputObjectParameterSet";
        const string ByResourceIdParameterSet = "ByResourceIdParameterSet";
        #endregion

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing cacheId. This parameter is required.")]
        [ValidateNotNullOrEmpty]
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
            HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional. Default value is false.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourceGroupName;
            string serviceName;
            string cacheId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourceGroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                cacheId = InputObject.CacheId;
            }
            else if (ParameterSetName.Equals(ByResourceIdParameterSet))
            {
                var cache = new PsApiManagementCache(ResourceId);
                resourceGroupName = cache.ResourceGroupName;
                serviceName = cache.ServiceName;
                cacheId = cache.CacheId;
            }
            else
            {
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                cacheId = CacheId;
            }

            var actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.CacheRemoveDescription, cacheId);
            var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.CacheRemoveWarning, cacheId);

            // Do nothing if force is not specified and user cancelled the operation
            if (!ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            Client.CacheRemove(resourceGroupName, serviceName, cacheId);

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
