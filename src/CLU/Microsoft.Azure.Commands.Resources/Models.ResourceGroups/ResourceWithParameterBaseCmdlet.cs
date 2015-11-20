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

using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    public abstract class ResourceWithParameterBaseCmdlet : ResourcesBaseCmdlet
    {
        protected const string BaseParameterSetName = "Default";
        protected const string TemplateFileParameterObjectParameterSetName = "Deployment via template file and template parameters object";
        protected const string TemplateFileParameterFileParameterSetName = "Deployment via template file and template parameters file";
        protected const string TemplateFileParameterUriParameterSetName = "Deployment via template file template parameters uri";
        protected const string TemplateUriParameterObjectParameterSetName = "Deployment via template uri and template parameters object";
        protected const string TemplateUriParameterFileParameterSetName = "Deployment via template uri and template parameters file";
        protected const string TemplateUriParameterUriParameterSetName = "Deployment via template uri and template parameters uri";
        protected const string ParameterlessTemplateFileParameterSetName = "Deployment via template file without parameters";
        protected const string ParameterlessGalleryTemplateParameterSetName = "Deployment via Gallery without parameters";
        protected const string ParameterlessTemplateUriParameterSetName = "Deployment via template uri without parameters";
        
        protected RuntimeDefinedParameterDictionary dynamicParameters;

        private string templateFile;

        private string templateUri;

        protected ResourceWithParameterBaseCmdlet()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
        }

        [Parameter(ParameterSetName = TemplateFileParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = TemplateUriParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        public Hashtable TemplateParameterObject { get; set; }

        [Parameter(ParameterSetName = TemplateFileParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A file that has the template parameters.")]
        [Parameter(ParameterSetName = TemplateUriParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A file that has the template parameters.")]
        [ValidateNotNullOrEmpty]
        public string TemplateParameterFile { get; set; }

        [Parameter(ParameterSetName = TemplateFileParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template parameter file.")]
        [Parameter(ParameterSetName = TemplateUriParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template parameter file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateParameterUri { get; set; }

        [Parameter(ParameterSetName = TemplateFileParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the template file.")]
        [Parameter(ParameterSetName = TemplateFileParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the template file.")]
        [Parameter(ParameterSetName = TemplateFileParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the template file.")]
        [Parameter(ParameterSetName = ParameterlessTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the template file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(ParameterSetName = TemplateUriParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template file.")]
        [Parameter(ParameterSetName = TemplateUriParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template file.")]
        [Parameter(ParameterSetName = TemplateUriParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template file.")]
        [Parameter(ParameterSetName = ParameterlessTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateUri { get; set; }
        
        protected Hashtable GetTemplateParameterObject(Hashtable templateParameterObject)
        {
            templateParameterObject = templateParameterObject ?? new Hashtable();

            // Load parameters from the file
            string templateParameterFilePath = TemplateParameterFile;
            if (templateParameterFilePath != null && FileUtilities.DataStore.FileExists(templateParameterFilePath))
            {
                var parametersFromFile = this.ParseTemplateParameterFileContents(templateParameterFilePath);
                parametersFromFile.ForEach(dp => templateParameterObject[dp.Key] = dp.Value.Value);
            }

            // Load dynamic parameters
            IEnumerable<RuntimeDefinedParameter> parameters = PowerShellUtilities.GetUsedDynamicParameters(dynamicParameters, MyInvocation);
            if (parameters.Any())
            {
                parameters.ForEach(dp => templateParameterObject[((ParameterAttribute)dp.Attributes[0]).HelpMessage] = dp.Value);
            }

            return templateParameterObject;
        }

        private Dictionary<string, TemplateFileParameterV1> ParseTemplateParameterFileContents(string templateParameterFilePath)
        {
            Dictionary<string, TemplateFileParameterV1> parameters = new Dictionary<string, TemplateFileParameterV1>();

            if (!string.IsNullOrEmpty(templateParameterFilePath) && 
                FileUtilities.DataStore.FileExists(templateParameterFilePath))
            {
                try
                {
                    parameters = JsonConvert.DeserializeObject<Dictionary<string, TemplateFileParameterV1>>(
                        FileUtilities.DataStore.ReadFileAsText(templateParameterFilePath));
                }
                catch (JsonSerializationException)
                {
                    parameters = new Dictionary<string, TemplateFileParameterV1>(
                        JsonConvert.DeserializeObject<TemplateFileParameterV2>(FileUtilities.DataStore.ReadFileAsText(templateParameterFilePath)).Parameters);
                }
            }

            return parameters;
        }
    }
}
