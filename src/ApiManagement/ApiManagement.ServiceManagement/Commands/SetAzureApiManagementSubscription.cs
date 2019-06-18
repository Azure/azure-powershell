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
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;
    using System;
    using System.Management.Automation;

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementSubscription", DefaultParameterSetName = ByInputObjectParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementSubscription), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet})]
    public class SetAzureApiManagementSubscription : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        protected const string ExpandedParameterSet = "ExpandedParameter";
        protected const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
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
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The Scope of the Subscription, whether it is Api Scope /apis/{apiId} or Product Scope /products/{productId} or Global API Scope /apis or Global scope /. This parameter is required.")]
        public String Scope { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The owner of the subscription. This parameter is optional.")]
        public String UserId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription name. This parameter is optional.")]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription primary key. This parameter is optional." +
                          " If not specified will be generated automatically." +
                          " Must be 1 to 300 characters long.")]
        public String PrimaryKey { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription secondary key. This parameter is optional." +
                          " If not specified will be generated automatically." +
                          " Must be 1 to 300 characters long.")]
        public String SecondaryKey { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription state. This parameter is optional. Default value is $null.")]
        public PsApiManagementSubscriptionState? State { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription expiration date. This parameter is optional. Default value is $null.")]
        public DateTime? ExpiresOn { get; set; }


        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription state comment. This parameter is optional. Default value is $null.")]
        public string StateComment { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of" +
                          " Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementSubscripition type" +
                          " representing the modified subscription.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourcegroupName;
            string serviceName;
            string subscriptionId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourcegroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                subscriptionId = InputObject.SubscriptionId;
            }
            else
            {
                resourcegroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                subscriptionId = SubscriptionId;
            }

            if (ShouldProcess(subscriptionId, Resources.SetSubscription))
            {
                Client.SubscriptionSet(
                    resourcegroupName,
                    serviceName,
                    subscriptionId,
                    Name,
                    Scope,
                    UserId,
                    PrimaryKey,
                    SecondaryKey,
                    State,
                    ExpiresOn,
                    StateComment,
                    InputObject);

                if (PassThru)
                {
                    var subscription = Client.SubscriptionById(
                        resourcegroupName,
                        serviceName,
                        subscriptionId);
                    WriteObject(subscription);
                }
            }
        }
    }
}
