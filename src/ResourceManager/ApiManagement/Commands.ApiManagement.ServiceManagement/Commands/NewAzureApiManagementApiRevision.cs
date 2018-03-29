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
    using Management.ApiManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System;
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementApiRevision)]
    [OutputType(typeof(PsApiManagementApiRevision))]
    public class NewAzureApiManagementApiRevision : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier for API whose Revision is to be created. ")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Revision Identifier of the Api.")]
        [ValidateNotNullOrEmpty]
        public String RevisionId { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var newApi = Client.ApiCreateRevision(Context, ApiId, RevisionId);

            // Create Operations
            CreateOperations(Context, newApi);

            // Add to Products
            AddApiToProducts(Context, newApi);

            WriteObject(newApi);
        }

        void CreateOperations(PsApiManagementContext Context, PsApiManagementApi newApi)
        {
            var operations = Client.OperationList(Context, ApiId);
            if (operations != null && operations.Any())
            {
                WriteProgress(new ProgressRecord(0, "New-AzureRmApiManagementApiRevision", "Api Revision created. Adding operations..."));

                foreach (var operation in operations)
                {
                    try
                    {
                        Client.OperationCreate(
                            Context,
                            newApi.ApiId,
                            operation.OperationId,
                            operation);

                        WriteProgress(
                            new ProgressRecord(
                                0,
                                "New-AzureRmApiManagementApiRevision",
                                string.Format("... operation {0} added.", operation.OperationId))
                            );
                    }
                    catch (Exception ex)
                    {
                        WriteProgress(
                            new ProgressRecord(
                                0,
                                "New-AzureRmApiManagementApiRevision",
                                string.Format("... failed to add operation {0} due to error {1}.", operation.OperationId, ex))
                            );
                    }
                }
            }
        }

        void AddApiToProducts(PsApiManagementContext Context, PsApiManagementApi newApi)
        {
            var products = Client.ProductListByApi(Context, ApiId);
            if (products != null && products.Any())
            {
                WriteProgress(new ProgressRecord(0, "New-AzureRmApiManagementApiRevision", "Api Revision created. Adding to products..."));

                foreach (var product in products)
                {
                    try
                    {
                        Client.ApiAddToProduct(
                            Context,
                            product.ProductId,
                            newApi.ApiId);

                        WriteProgress(
                            new ProgressRecord(
                                0,
                                "New-AzureRmApiManagementApiRevision",
                                string.Format("... added to product {0}.", product.ProductId))
                            );
                    }
                    catch (Exception ex)
                    {
                        WriteProgress(
                            new ProgressRecord(
                                0,
                                "New-AzureRmApiManagementApiRevision",
                                string.Format("... failed to add to product {0} due to error {1}.", product.ProductId, ex))
                            );
                    }
                }
            }
        }
    }
}
