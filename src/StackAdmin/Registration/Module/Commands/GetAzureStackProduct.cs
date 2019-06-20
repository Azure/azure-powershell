// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.AzureStack
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.AzureStack.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.AzureStack.Models;
    using Microsoft.Rest.Azure;

    [Cmdlet("Get", AzureStackClient.ProductsCmdletName), OutputType(typeof(ProductResult))]
    public class GetAzureStackProduct : AzureStackCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group where Azure Stack registration is created.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of Azure Stack registration.")]
        [ValidateNotNullOrEmpty]
        public string RegistrationName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of Azure Stack product.")]
        public string ProductName { get; set; }

        public override void ExecuteCmdlet()
        {
            ValidateResourceGroupName(ResourceGroupName);
            ValidateResourceName(RegistrationName);

            if (!string.IsNullOrEmpty(ProductName))
            {
                var resource = AzsClient.GetProduct(ResourceGroupName, RegistrationName, ProductName);
                WriteObject(new ProductResult(resource));
            }
            else
            {
                IPage<Product> response = AzsClient.ListProducts(ResourceGroupName, RegistrationName);
                List<ProductResult> list = new List<ProductResult>();
                foreach (Product resource in response)
                {
                    list.Add(new ProductResult(resource));
                }
                WriteObject(list, true);

                while (!string.IsNullOrEmpty(response.NextPageLink))
                {
                    // List using next link
                    response = AzsClient.ListProductsUsingNextLink(response.NextPageLink);
                    list = new List<ProductResult>();
                    foreach (Product resource in response)
                    {
                        list.Add(new ProductResult(resource));
                    }
                    WriteObject(list, true);
                }
            }
        }
    }
}