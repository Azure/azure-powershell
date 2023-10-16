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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.IO;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase
{
    public class DeploymentStacksCreateCmdletBase : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        protected string protectedTemplateUri;

        protected DeploymentStacksCreateCmdletBase()
        {
        }

        internal const string ParameterlessTemplateFileParameterSetName = "ByTemplateFileWithNoParameters";
        internal const string ParameterlessTemplateUriParameterSetName = "ByTemplateUriWithNoParameters";
        internal const string ParameterlessTemplateSpecParameterSetName = "ByTemplateSpecWithNoParameters";

        internal const string ParameterFileTemplateFileParameterSetName = "ByTemplateFileWithParameterFile";
        internal const string ParameterFileTemplateUriParameterSetName = "ByTemplateUriWithParameterFile";
        internal const string ParameterFileTemplateSpecParameterSetName = "ByTemplateSpecWithParameterFile";

        internal const string ParameterUriTemplateFileParameterSetName = "ByTemplateFileWithParameterUri";
        internal const string ParameterUriTemplateUriParameterSetName = "ByTemplateUriWithParameterUri";
        internal const string ParameterUriTemplateSpecParameterSetName = "ByTemplateSpecWithParameterUri";

        internal const string ParameterObjectTemplateFileParameterSetName = "ByTemplateFileWithParameterObject";
        internal const string ParameterObjectTemplateUriParameterSetName = "ByTemplateUriWithParameterObject";
        internal const string ParameterObjectTemplateSpecParameterSetName = "ByTemplateSpecWithParameterObject";

        internal const string ByParameterFileWithNoTemplateParameterSetName = "ByParameterFileWithNoTemplate";

        [Parameter(ParameterSetName = ParameterFileTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterUriTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterlessTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "TemplateFile to be used to create the stack.")]
        public string TemplateFile { get; set; }

        [Parameter(ParameterSetName = ParameterFileTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterUriTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterlessTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Template to be used to create the stack.")]
        public string TemplateUri { get; set; }

        [Parameter(ParameterSetName = ParameterFileTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterUriTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack.")]
        [Parameter(ParameterSetName = ParameterlessTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the TemplateSpec to be used to create the stack.")]
        public string TemplateSpecId { get; set; }

        [Parameter(ParameterSetName = ParameterFileTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        [Parameter(ParameterSetName = ParameterFileTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        [Parameter(ParameterSetName = ParameterFileTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        [Parameter(ParameterSetName = ByParameterFileWithNoTemplateParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        public string TemplateParameterFile { get; set; }

        [Parameter(ParameterSetName = ParameterUriTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template.")]
        [Parameter(ParameterSetName = ParameterUriTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template.")]
        [Parameter(ParameterSetName = ParameterUriTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Location of the Parameter file to use for the template.")]
        public string TemplateParameterUri { get; set; }

        [Parameter(ParameterSetName = ParameterObjectTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = ParameterObjectTemplateSpecParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        public Hashtable TemplateParameterObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Skips the PowerShell dynamic parameter processing that checks if the provided template parameter contains all necessary parameters used by the template. " +
                                            "This check would prompt the user to provide a value for the missing parameters, but providing the -SkipTemplateParameterPrompt will ignore this prompt and " +
                                            "error out immediately if a parameter was found not to be bound in the template. For non-interactive scripts, -SkipTemplateParameterPrompt can be provided " +
                                            "to provide a better error message in the case where not all required parameters are satisfied.")]
        public SwitchParameter SkipTemplateParameterPrompt { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The query string (for example, a SAS token) to be used with the TemplateUri parameter. Would be used in case of linked templates")]
        public string QueryString { get; set; }

        #endregion

        /// <summary>
        /// Compiled Template JSON. This is not directly settable via cmdlet invocation. It is instead only set if a .bicep file is compiled into JSON.
        /// </summary>
        protected string TemplateJson { get; set; }

        private (Hashtable parameters, string templateJson, string templateSpecId) GetParametersAndMetadataFromFile()
        {
            var isBicepParamFile = BicepUtility.IsBicepparamFile(TemplateParameterFile);
            if (!isBicepParamFile && string.IsNullOrEmpty(TemplateFile) && string.IsNullOrEmpty(TemplateUri) && string.IsNullOrEmpty(TemplateSpecId))
            {
                throw new PSInvalidOperationException($"One of the -{nameof(TemplateFile)}, -{nameof(TemplateUri)} or -{nameof(TemplateSpecId)} parameters must be supplied unless a .bicepparam file is supplied with parameter -{nameof(TemplateParameterFile)}.");
            }

            if (isBicepParamFile && !string.IsNullOrEmpty(TemplateFile) && !BicepUtility.IsBicepFile(TemplateFile))
            {
                throw new PSInvalidOperationException($"Parameter -{nameof(TemplateFile)} only permits .bicep files if a .bicepparam file is supplied with parameter -{nameof(TemplateParameterFile)}.");
            }

            if (isBicepParamFile && (!string.IsNullOrEmpty(TemplateUri) || !string.IsNullOrEmpty(TemplateSpecId)))
            {
                throw new PSInvalidOperationException($"Parameters -{nameof(TemplateUri)} or -{nameof(TemplateSpecId)} cannot be used if a .bicepparam file is supplied with parameter -{nameof(TemplateParameterFile)}.");
            }

            var parameterFilePath = this.TryResolvePath(TemplateParameterFile);
            if (!File.Exists(parameterFilePath))
            {
                throw new PSInvalidOperationException(string.Format(ProjectResources.InvalidFilePath, TemplateParameterFile));
            }

            var result = ResolveBicepParameterFile(parameterFilePath);
            var parameters = (result != null) ? 
                this.GetParametersFromJson(result.parametersJson) :
                this.GetParameterObject(parameterFilePath);
            var templateJson = result?.templateJson;
            var templateSpecId = result?.templateSpecId;

            return (parameters, templateJson, templateSpecId);
        }

        protected Hashtable ResolveParameters()
        {
            var output = GetParametersAndMetadataFromFile();

            if (string.IsNullOrEmpty(TemplateFile) && 
                string.IsNullOrEmpty(TemplateUri) && 
                string.IsNullOrEmpty(TemplateSpecId))
            {
                // When .bicepparam support was first introduced, we were missing the validation to block overriding the 'using' path in these cmdlets.
                // We need to be careful to retain this behavior to avoid breaking existing users, until it is re-introduced intentionally with https://github.com/Azure/bicep/issues/10333.

                if (!string.IsNullOrEmpty(output.templateJson))
                {
                    TemplateJson = output.templateJson;
                }
                else if (!string.IsNullOrEmpty(output.templateSpecId))
                {
                    TemplateSpecId = output.templateSpecId;
                }
                else
                {
                    // This shouldn't happen in practice - the Bicep CLI will return either templateJson or templateSpecId (or fail to run entirely).
                    throw new PSInvalidOperationException(string.Format(ProjectResources.InvalidFilePath, TemplateParameterFile));
                }
            }

            return output.parameters;
        }
    }
}