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
    [Cmdlet(VerbsData.Export, WebServicesCmdletBase.CommandletSuffix)]
    public class ExportWebServiceDefinition : AzureRMCmdlet
    {
        private const string ExportToFileParamSet = "Export to file.";
        private const string ExportToStringParamSet = "Export to JSON string.";

        [Parameter(Mandatory = true, HelpMessage = "The web service definition object to export.")]
        [ValidateNotNullOrEmpty]
        public WebService WebService { get; set; }

        [Parameter(ParameterSetName = ExportWebServiceDefinition.ExportToFileParamSet, Mandatory = true, HelpMessage = "Path to a file on disk where to export the web service definition in JSON format.")]
        [ValidateNotNullOrEmpty]
        public string ToFile { get; set; }

        [Parameter(ParameterSetName = ExportWebServiceDefinition.ExportToStringParamSet, Mandatory = true, HelpMessage = "The actual web service definition as a JSON string.")]
        public SwitchParameter ToJsonString { get; set; }

        public override void ExecuteCmdlet()
        {
            string serializedDefinition = ModelsSerializationUtil.GetAzureMLWebServiceDefinitionJsonFromObject(this.WebService);
            if (!string.IsNullOrWhiteSpace(this.ToFile))
            {
               File.WriteAllText(this.ToFile, serializedDefinition);
            }
            else
            {
                Console.WriteLine(serializedDefinition);
            }
        }
    }
}
