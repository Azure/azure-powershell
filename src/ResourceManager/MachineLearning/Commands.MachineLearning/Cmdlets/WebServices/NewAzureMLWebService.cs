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
        VerbsCommon.New, 
        WebServicesCmdletBase.CommandletSuffix,
        SupportsShouldProcess = true)]
    [OutputType(typeof(WebService))]
    public class NewAzureMLWebService : WebServicesCmdletBase
    {
        protected const string CreateFromFileParameterSet = "CreateFromFile";
        protected const string CreateFromObjectParameterSet = "CreateFromInstance";
       
        [Parameter(
            Mandatory = true, 
            HelpMessage = "The name of the resource group for the Azure ML web service.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The location of the AzureML.")]
        [LocationCompleter("Microsoft.MachineLearning/webServices")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }
        
        [Parameter(Mandatory = true, HelpMessage = "The name of the web service")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = NewAzureMLWebService.CreateFromFileParameterSet, 
            Mandatory = true, 
            HelpMessage = "The definition of the new web service.")]
        [ValidateNotNullOrEmpty]
        public string DefinitionFile { get; set; }

        [Parameter(
            ParameterSetName = NewAzureMLWebService.CreateFromObjectParameterSet, 
            Mandatory = true, 
            HelpMessage = "The definition of the new web service.", 
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public WebService NewWebServiceDefinition { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void RunCmdlet()
        {
            this.ConfirmAction(
                this.Force.IsPresent,
                Resources.NewServiceWarning.FormatInvariant(this.Name), 
                "Creating the new web service", 
                this.Name, 
                () => {
                    if (string.Equals(
                                this.ParameterSetName,
                                NewAzureMLWebService.CreateFromFileParameterSet,
                                StringComparison.OrdinalIgnoreCase))
                    {
                        string jsonDefinition = 
                                CmdletHelpers.GetWebServiceDefinitionFromFile(
                                                this.SessionState.Path.CurrentFileSystemLocation.Path,
                                                this.DefinitionFile);
                        var webServiceFromJson = 
                                ModelsSerializationUtil.GetAzureMLWebServiceFromJsonDefinition(jsonDefinition);

                        // The name and location in command line parameters overwrite the content from 
                        // Web Service Definition json file.
                        this.NewWebServiceDefinition = new WebService(
                                                                this.Location, 
                                                                webServiceFromJson.Properties, 
                                                                webServiceFromJson.Id, 
                                                                this.Name, webServiceFromJson.Type, 
                                                                webServiceFromJson.Tags);
                    }

                    WebService newWebService =
                        this.WebServicesClient.CreateAzureMlWebService(
                                                    this.ResourceGroupName,
                                                    this.Name,
                                                    this.NewWebServiceDefinition);
                    this.WriteObject(newWebService);
                });
        }
    }
}
