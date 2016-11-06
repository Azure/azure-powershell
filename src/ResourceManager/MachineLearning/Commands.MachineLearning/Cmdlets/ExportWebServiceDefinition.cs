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
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Azure.Management.MachineLearning.WebServices.Util;

namespace Microsoft.Azure.Commands.MachineLearning.Cmdlets
{
    [Cmdlet(
        VerbsData.Export, 
        WebServicesCmdletBase.CommandletSuffix, 
        SupportsShouldProcess = true)]
    [OutputType(typeof(string))]
    public class ExportWebServiceDefinition : WebServicesCmdletBase
    {
        private const string ExportToFileParamSet = "Export to file.";
        private const string ExportToStringParamSet = "Export to JSON string.";

        [Parameter(
            Mandatory = true, 
            HelpMessage = "The web service definition object to export.",
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public WebService WebService { get; set; }

        [Parameter(
            ParameterSetName = ExportWebServiceDefinition.ExportToFileParamSet,
            Mandatory = true, 
            HelpMessage = "Path to a file on disk where to export the web service definition in JSON format.")]
        [ValidateNotNullOrEmpty]
        public string OutputFile { get; set; }

        [Parameter(
            ParameterSetName = ExportWebServiceDefinition.ExportToStringParamSet, 
            Mandatory = true, 
            HelpMessage = "The actual web service definition as a JSON string.")]
        public SwitchParameter ToJsonString { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(
            Mandatory = false, 
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void RunCmdlet()
        {
            string serializedDefinition = 
                ModelsSerializationUtil.GetAzureMLWebServiceDefinitionJsonFromObject(this.WebService);

            if (!string.IsNullOrWhiteSpace(this.OutputFile))
            {
                var currentPath = this.SessionState.Path.CurrentFileSystemLocation.Path;
                var definitionFileFullPath =
                        Path.IsPathRooted(this.OutputFile) ?
                            this.OutputFile :
                            Path.Combine(currentPath, this.OutputFile);

                bool fileExisting = File.Exists(definitionFileFullPath);
                this.ConfirmAction(
                    this.Force || !fileExisting,
                    "Want to overwriting the output file?",
                    "Overwriting the output file",
                    definitionFileFullPath,
                    () => File.WriteAllText(definitionFileFullPath, serializedDefinition));
            }
            else
            {
                this.WriteObject(serializedDefinition);
            }
        }
    }
}
