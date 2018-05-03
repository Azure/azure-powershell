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
using Microsoft.Azure.Management.MachineLearning.WebServices.Util;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.MachineLearning.Cmdlets
{
    [Cmdlet(
        VerbsCommon.Add,
        "AzureRmMlWebServiceRegionalProperty",
        SupportsShouldProcess = true)]
    [OutputType(typeof(WebService))]
    public class AddAzureMLWebServiceRegionalProperty : WebServicesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group for the Azure ML web service.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true, 
            ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The name of the web service")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of region")]
        [LocationCompleter("Microsoft.MachineLearning/webServices")]
        [ValidateNotNullOrEmpty]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void RunCmdlet()
        {
            if (ShouldProcess(this.Name, @"Creating the new web service property for the specific region.."))
            {
                if (this.Force.IsPresent 
                    || ShouldContinue(
                            Resources.CreateNewRegionalProperties.FormatInvariant(this.Name, this.Region),
                            string.Empty))
                {
                    this.WebServicesClient.CreateRegionalProperties(this.ResourceGroupName, this.Name, this.Region);

                    // Fetch this region's WebService object
                    WebService service = this.WebServicesClient.GetAzureMlWebService(this.ResourceGroupName, this.Name, this.Region);
                    this.WriteObject(service);
                }
            }
        }
    }
}
