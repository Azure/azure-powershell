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

using System.Management.Automation;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;

namespace Microsoft.Azure.Commands.MachineLearning.Cmdlets
{
    [Cmdlet(VerbsCommon.New, WebServicesCmdletBase.CommandletSuffix)]
    public class NewAzureMLWebService : WebServicesCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the resource group for the Azure ML web service.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }
        
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the web service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The location of the AzureML.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The definition of the new web service")]
        [ValidateNotNullOrEmpty]
        public WebService NewWebServiceDefinition { get; set; }

        protected override void RunCmdlet()
        {
            WebService newWebService = this.WebServicesClient.CreateAzureMlWebService(this.SubscriptionId, this.ResourceGroupName, this.Location, this.Name, this.NewWebServiceDefinition);
            this.WriteObject(newWebService);
        }
    }
}
