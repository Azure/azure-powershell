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

    [Cmdlet(VerbsCommon.Set, Constants.ApiManagementProduct)]
    [OutputType(typeof(PsApiManagementProduct))]
    public class SetAzureApiManagementProduct : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing Product. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ProductId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Product title. This parameter is required.")]
        public String Title { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Product description. This parameter is optional.")]
        public String Description { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Legal terms of use of the product. This parameter is optional.")]
        public String LegalTerms { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Whether the product requires subscription or not. This parameter is optional. Default value is $true.")]
        public bool? SubscriptionRequired { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Whether subscription to the product requires approval or not. This parameter is optional. Default value is $false.")]
        public bool? ApprovalRequired { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Maximum number of simultaneous subscriptions. This parameter is optional. Default value is 1.")]
        public Int32? SubscriptionsLimit { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Product state. One of: NotPublished, Published. This parameter is optional. Default value is NotPublished.")]
        public PsApiManagementProductState? State { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of" +
                          " Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementProduct " +
                          "type representing the modified product.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            Client.ProductSet(
                Context,
                ProductId,
                Title,
                Description,
                LegalTerms,
                SubscriptionRequired,
                ApprovalRequired,
                SubscriptionsLimit,
                State);

            if (PassThru)
            {
                var product = Client.ProductById(Context, ProductId);
                WriteObject(product);
            }
        }
    }
}
