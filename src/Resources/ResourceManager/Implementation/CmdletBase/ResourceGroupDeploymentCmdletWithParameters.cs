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

using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    public abstract class ResourceGroupDeploymentCmdletWithParameters : DeploymentCmdletBase
    {
        protected const string ResourceGroupParameterSetWithTemplateObjectParameterObject = "ResourceGroupWithTemplateObjectAndParameterObject";
        protected const string ResourceGroupParameterSetWithTemplateObjectParameterFile = "ResourceGroupWithTemplateObjectAndParameterFile";
        protected const string ResourceGroupParameterSetWithTemplateFileParameterObject = "ResourceGroupWithTemplateFileAndParameterObject";
        protected const string ResourceGroupParameterSetWithTemplateFileParameterFile = "ResourceGroupWithTemplateFileAndParameterFile";
        protected const string ResourceGroupParameterSetWithParameterlessTemplateObject = "ResourceGroupWithTemplateObjectAndNoParameters";
        protected const string ResourceGroupParameterSetWithParameterlessTemplateFile = "ResourceGroupWithTemplateFileWithAndNoParameters";

        protected ResourceGroupDeploymentCmdletWithParameters() : base()
        {
        }

        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateObjectParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateFileParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        public override Hashtable TemplateParameterObject { get; set; }

        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateObjectParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A Uri or local path to the file that has the template parameters.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateFileParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A Uri or local path to the file that has the template parameters.")]
        [ValidateNotNullOrEmpty]
        [Alias("TemplateParameterUri")]
        public override string TemplateParameterFile { get; set; }

        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateObjectParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateObjectParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithParameterlessTemplateObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [ValidateNotNull]
        public override Hashtable TemplateObject { get; set; }

        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateFileParameterObject,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri or local path to the template file.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithTemplateFileParameterFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri or local path to the template file.")]
        [Parameter(ParameterSetName = ResourceGroupParameterSetWithParameterlessTemplateFile,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri or local path to the template file.")]
        [ValidateNotNullOrEmpty]
        [Alias("TemplateUri")]
        public override string TemplateFile { get; set; }
    }
}
