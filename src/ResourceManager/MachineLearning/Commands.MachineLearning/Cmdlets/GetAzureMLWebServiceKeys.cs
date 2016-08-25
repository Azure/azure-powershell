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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.MachineLearning.Utilities;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;

namespace Microsoft.Azure.Commands.MachineLearning.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, WebServicesCmdletBase.CommandletSuffix + "Keys")]
    [OutputType(typeof(WebServiceKeys))]
    public class GetAzureMLWebServiceKeys : WebServicesCmdletBase
    {
        private const string GetKeysByGroupAndName = 
            "Get an Azure ML web service's access keys given its name and resource group.";
        private const string GetKeysByInstance = 
            "Get the access kesy for the given web service instance.";

        [Parameter(
            ParameterSetName = GetAzureMLWebServiceKeys.GetKeysByGroupAndName, 
            Mandatory = true, 
            HelpMessage = "The name of the resource group for the Azure ML web services.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = GetAzureMLWebServiceKeys.GetKeysByGroupAndName, 
            Mandatory = true, 
            HelpMessage = "The name of the web service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = GetAzureMLWebServiceKeys.GetKeysByInstance, 
            Mandatory = true, 
            HelpMessage = "The web service instance to get the keys for.", 
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public WebService MlWebService { get; set; }

        protected override void RunCmdlet()
        {
            if (string.Equals(
                        this.ParameterSetName, 
                        GetAzureMLWebServiceKeys.GetKeysByInstance, 
                        StringComparison.OrdinalIgnoreCase))
            {
                string subscriptionId, resourceGroup, webServiceName;
                if (!CmdletHelpers.TryParseMlWebServiceMetadataFromResourceId(
                                    this.MlWebService.Id, 
                                    out subscriptionId, 
                                    out resourceGroup, 
                                    out webServiceName))
                {
                    throw new ValidationMetadataException(Resources.InvalidWebServiceIdOnObject);
                }

                this.ResourceGroupName = resourceGroup;
                this.Name = webServiceName;
            }

            WebServiceKeys storageKeys = 
                this.WebServicesClient.GetAzureMlWebServiceKeys(this.ResourceGroupName, this.Name);
            this.WriteObject(storageKeys);
        }
    }
}
