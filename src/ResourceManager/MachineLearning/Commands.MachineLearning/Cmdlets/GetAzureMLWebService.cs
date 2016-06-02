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
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;

namespace Microsoft.Azure.Commands.MachineLearning
{
    [Cmdlet(VerbsCommon.Get, WebServicesCmdletBase.CommandletSuffix)]
    [OutputType(typeof(WebService), typeof(WebService[]))]
    public class GetAzureMLWebService : WebServicesCmdletBase
    {
        [Parameter(
            Mandatory = false, 
            HelpMessage = "The name of the resource group for the Azure ML web service.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "The name of the web service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        protected override void RunCmdlet()
        {
            // If this is a simple get web service by name operation, resolve it as such
            if (!string.IsNullOrWhiteSpace(this.ResourceGroupName) && 
                !string.IsNullOrWhiteSpace(this.Name))
            {
                WebService service =
                    this.WebServicesClient.GetAzureMlWebService(this.ResourceGroupName, this.Name);
                this.WriteObject(service);
            }
            else
            {
                IList<WebService> services;
                if (!string.IsNullOrWhiteSpace(this.ResourceGroupName))
                {
                    services = this.WebServicesClient.GetAzureMlWebServicesBySubscriptionAndGroupAsync(
                                                        this.ResourceGroupName,
                                                        null,
                                                        this.CancellationToken).Result;
                }
                else
                {
                    services = this.WebServicesClient.GetAzureMlWebServicesBySubscriptionAsync(
                                                        null,
                                                        this.CancellationToken).Result;
                }

                foreach (var service in services)
                {
                    this.WriteObject(service, true);
                }
            }
        }
    }
}
