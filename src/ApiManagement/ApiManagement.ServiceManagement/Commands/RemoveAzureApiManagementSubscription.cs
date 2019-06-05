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

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementSubscription", SupportsShouldProcess = true, DefaultParameterSetName = ExpandedParameterSet)]
    [OutputType(typeof(bool), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet, ByResourceIdParameterSet })]
    public class RemoveAzureApiManagementSubscription : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names
        private const string ExpandedParameterSet = "ExpandedParameter";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";
        #endregion

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing subscription. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String SubscriptionId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementSubscription. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementSubscription InputObject { get; set; }

        [Parameter(
            ParameterSetName = ByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Arm ResourceId of Subscription. This parameter is required.")]
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
            string subscriptionId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                subscriptionId = InputObject.SubscriptionId;
                resourceGroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
            }
            else if (ParameterSetName.Equals(ExpandedParameterSet))
            {
                subscriptionId = SubscriptionId;
                resourceGroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
            }
            else
            {
                var subscriptionObject = new PsApiManagementSubscription(ResourceId);
                resourceGroupName = subscriptionObject.ResourceGroupName;
                serviceName = subscriptionObject.ServiceName;
                subscriptionId = subscriptionObject.SubscriptionId;
            }

            var actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.SubscriptionRemoveDescription, subscriptionId);
            var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.SubscriptionRemoveWarning, subscriptionId);

            // Do nothing if force is not specified and user cancelled the operation
            if (!ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            Client.SubscriptionRemove(resourceGroupName, serviceName, subscriptionId);

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
