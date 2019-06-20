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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.AzureStack.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Get", AzureStackClient.ProductDetailsCmdletName), OutputType(typeof(ExtendedProductResult))]
    public class GetAzureStackProductDetails : AzureStackCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of resource group where Azure Stack registration is created.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of Azure Stack registration.")]
        [ValidateNotNullOrEmpty]
        public string RegistrationName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, HelpMessage = "Name of Azure Stack product.")]
        [ValidateNotNullOrEmpty]
        public string ProductName { get; set; }

        public override void ExecuteCmdlet()
        {
            ValidateResourceGroupName(ResourceGroupName);
            ValidateResourceName(RegistrationName);

            var resource = AzsClient.ListProductDetails(ResourceGroupName, RegistrationName, ProductName);
            WriteObject(new ExtendedProductResult(resource));
        }
    }
}