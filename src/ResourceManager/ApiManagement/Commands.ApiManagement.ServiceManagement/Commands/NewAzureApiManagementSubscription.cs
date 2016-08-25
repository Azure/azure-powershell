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
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementSubscription)]
    [OutputType(typeof(PsApiManagementSubscription))]
    public class NewAzureApiManagementSubscription : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of new subscription. This parameter is optional." +
                          " If not specified will be generated.")]
        public String SubscriptionId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Subscription name. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing user - the subscriber. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String UserId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing product to subscribe to. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ProductId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription primary key. This parameter is optional. If not specified will be generated automatically." +
                          " Must be 1 to 300 characters long.")]
        public String PrimaryKey { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription secondary key. This parameter is optional. If not specified will be generated automatically." +
                          " Must be 1 to 300 characters long.")]
        public String SecondaryKey { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Subscription state. This parameter is optional. Default value is $null.")]
        public PsApiManagementSubscriptionState? State { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var subscriptionId = SubscriptionId ?? Guid.NewGuid().ToString("N");

            var subscription = Client.SubscriptionCreate(
                Context,
                subscriptionId,
                ProductId,
                UserId,
                Name,
                PrimaryKey,
                SecondaryKey,
                State);

            WriteObject(subscription);
        }
    }
}
