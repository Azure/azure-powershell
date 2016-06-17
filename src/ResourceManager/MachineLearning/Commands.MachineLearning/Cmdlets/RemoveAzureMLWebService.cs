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
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.MachineLearning
{
    [Cmdlet(
        VerbsCommon.Remove, 
        WebServicesCmdletBase.CommandletSuffix,
        SupportsShouldProcess = true)]
    [OutputType(typeof(void))]
    public class RemoveAzureMLWebService : WebServicesCmdletBase
    {
        protected const string RemoveByNameGroupParameterSet = 
            "Remove an Azure ML web service resouce by name and resource group.";
        protected const string RemoveByObjectParameterSet = 
            "Remove an Azure ML web service specified as an object.";

        [Parameter(
            ParameterSetName = RemoveAzureMLWebService.RemoveByNameGroupParameterSet, 
            Mandatory = true, 
            HelpMessage = "The name of the resource group for the Azure ML web service.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = RemoveAzureMLWebService.RemoveByNameGroupParameterSet, 
            Mandatory = true, 
            HelpMessage = "The name of the web service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = RemoveAzureMLWebService.RemoveByObjectParameterSet, 
            Mandatory = true, 
            HelpMessage = "The machine learning web service object.", 
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public WebService MlWebService { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void RunCmdlet()
        {
            if (ShouldProcess(this.Name, @"Deleting machine learning web service.."))
            {
                if (string.Equals(
                                this.ParameterSetName,
                                RemoveAzureMLWebService.RemoveByObjectParameterSet,
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

                if (this.Force.IsPresent || 
                    ShouldContinue(
                        Resources.RemoveMlServiceWarning.FormatInvariant(this.Name), 
                        string.Empty))
                {
                    this.WebServicesClient.DeleteAzureMlWebService(
                                                                this.ResourceGroupName,
                                                                this.Name);
                }
            }
        }
    }
}
