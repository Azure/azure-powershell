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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.Resources;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    public abstract class DeploymentCmdletBase : ResourceManagerCmdletBase
    {
        protected const string TemplateObjectParameterObjectParameterSetName = "ByTemplateObjectAndParameterObject";
        protected const string TemplateObjectParameterFileParameterSetName = "ByTemplateObjectAndParameterFile";
        protected const string TemplateObjectParameterUriParameterSetName = "ByTemplateObjectAndParameterUri";

        protected const string TemplateFileParameterObjectParameterSetName = "ByTemplateFileAndParameterObject";
        protected const string TemplateFileParameterFileParameterSetName = "ByTemplateFileAndParameterFile";
        protected const string TemplateFileParameterUriParameterSetName = "ByTemplateFileAndParameterUri";

        protected const string TemplateUriParameterObjectParameterSetName = "ByTemplateUriAndParameterObject";
        protected const string TemplateUriParameterFileParameterSetName = "ByTemplateUriAndParameterFile";
        protected const string TemplateUriParameterUriParameterSetName = "ByTemplateUriAndParameterUri";

        protected const string ParameterlessTemplateObjectParameterSetName = "ByTemplateObjectWithNoParameters";
        protected const string ParameterlessTemplateFileParameterSetName = "ByTemplateFileWithNoParameters";
        protected const string ParameterlessTemplateUriParameterSetName = "ByTemplateUriWithNoParameters";

        protected const string TemplateSpecResourceIdParameterSetName = "ByTemplateSpecResourceId";
        protected const string TemplateSpecResourceIdParameterFileParameterSetName = "ByTemplateSpecResourceIdAndParams";
        protected const string TemplateSpecResourceIdParameterUriParameterSetName = "ByTemplateSpecResourceIdAndParamsUri";
        protected const string TemplateSpecResourceIdParameterObjectParameterSetName = "ByTemplateSpecResourceIdAndParamsObject";
        
        protected const string ByParameterFileWithNoTemplateParameterSetName = "ByParameterFileWithNoTemplate";

        [Parameter(ParameterSetName = TemplateObjectParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = TemplateFileParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = TemplateUriParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = TemplateSpecResourceIdParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        public Hashtable TemplateParameterObject { get; set; }

        [Parameter(ParameterSetName = TemplateObjectParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        [Parameter(ParameterSetName = TemplateFileParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        [Parameter(ParameterSetName = TemplateUriParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        [Parameter(ParameterSetName = TemplateSpecResourceIdParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        [Parameter(ParameterSetName = ByParameterFileWithNoTemplateParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Parameter file to use for the template.")]
        [ValidateNotNullOrEmpty]
        public string TemplateParameterFile { get; set; }

        /// <summary>
        /// Used to store bicep params that have been built by a bicep parameter file. These are kept as a standalone property and not assigned to TemplateParameterObject, as TemplateParameterFile
        /// needs to stick around for building the bicep param file in GetTemplateParameterObject() and having both would cause the parameter set resolver to complain. 
        /// </summary>
        private Dictionary<string, TemplateParameterFileParameter> bicepparamFileParameters;

        [Parameter(ParameterSetName = TemplateObjectParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template parameter file.")]
        [Parameter(ParameterSetName = TemplateFileParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template parameter file.")]
        [Parameter(ParameterSetName = TemplateUriParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template parameter file.")]
        [Parameter(ParameterSetName = TemplateSpecResourceIdParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template parameter file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateParameterUri { get; set; }

        [Parameter(ParameterSetName = TemplateObjectParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [Parameter(ParameterSetName = TemplateObjectParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [Parameter(ParameterSetName = TemplateObjectParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [Parameter(ParameterSetName = ParameterlessTemplateObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the template.")]
        [ValidateNotNull]
        public Hashtable TemplateObject { get; set; }

        [Parameter(ParameterSetName = TemplateFileParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the template file. Supported template file type: json and bicep.")]
        [Parameter(ParameterSetName = TemplateFileParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = TemplateFileParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParameterlessTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(ParameterSetName = TemplateUriParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template file.")]
        [Parameter(ParameterSetName = TemplateUriParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = TemplateUriParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = ParameterlessTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string TemplateUri { get; set; }

        protected string protectedTemplateUri;

        [Parameter(ParameterSetName = TemplateSpecResourceIdParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource ID of the templateSpec to be deployed.")]
        [Parameter(ParameterSetName = TemplateSpecResourceIdParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource ID of the templateSpec to be deployed.")]
        [Parameter(ParameterSetName = TemplateSpecResourceIdParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource ID of the templateSpec to be deployed.")]
        [Parameter(ParameterSetName = TemplateSpecResourceIdParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource ID of the templateSpec to be deployed.")]
        [ValidateNotNullOrEmpty]
        public string TemplateSpecId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Skips the PowerShell dynamic parameter processing that checks if the provided template parameter contains all necessary parameters used by the template. " +
                                                    "This check would prompt the user to provide a value for the missing parameters, but providing the -SkipTemplateParameterPrompt will ignore this prompt and " +
                                                    "error out immediately if a parameter was found not to be bound in the template. For non-interactive scripts, -SkipTemplateParameterPrompt can be provided " +
                                                    "to provide a better error message in the case where not all required parameters are satisfied.")]
        public SwitchParameter SkipTemplateParameterPrompt { get; set; }

        private ITemplateSpecsClient templateSpecsClient;

        /// <summary>
        /// TemplateSpecsClient for making template spec sdk calls. On first access, it will be initialized before being returned.
        /// </summary>
        public ITemplateSpecsClient TemplateSpecsClient
        {
            get
            {
                if (this.templateSpecsClient == null)
                {
                    this.templateSpecsClient =
                        AzureSession.Instance.ClientFactory.CreateArmClient<TemplateSpecsClient>(
                            DefaultContext,
                            AzureEnvironment.Endpoint.ResourceManager
                        );
                }

                return this.templateSpecsClient;
            }

            set { this.templateSpecsClient = value; }
        }

        protected override void OnBeginProcessing()
        {
            // Resolve file paths to ensure the files exist:
            TemplateFile = this.ResolvePath(TemplateFile);
            TemplateParameterFile = this.ResolvePath(TemplateParameterFile);

            if (BicepUtility.IsBicepparamFile(TemplateParameterFile))
            {
                // Even though these were already built in dynamic parameter logic, they should be built again in case
                // used dynamic parameter values have changed. This could also affect TemplateObject and TemplateSpec
                // parameters (side affect of references within bicepparam files), so it should be done before processing:
                BuildAndUseBicepParameters(emitWarnings: true);
            }

            base.OnBeginProcessing();
        }

        /// <summary>
        /// Attempts to load dynamic parameters from populated template/template parameter properties.
        /// Runs on every tab complete and before processing on execution.
        /// It will silently fail (exception is caught and not visible to user) until required properties are popluated.
        /// </summary>
        public new virtual object GetDynamicParameters()
        {
            var isBicepParamFile = BicepUtility.IsBicepparamFile(TemplateParameterFile);

            // Ensure required properties are populated for dynamic parameter extration:
            DynamicParameterValidityCheck(isBicepParamFile);

            if (isBicepParamFile)
            {
                // A bicep param file can include a template that needs to be extracted, along with the params themselves:
                BuildAndUseBicepParameters(emitWarnings: false);
            }

            if (BicepUtility.IsBicepFile(TemplateFile))
            {
                // Build bicep file:
                BuildAndUseBicepTemplate();
            }

            var dynamicParameters = new RuntimeDefinedParameterDictionary();
            
            if (!this.IsParameterBound(c => c.SkipTemplateParameterPrompt))
            {
                string[] staticParameterNames = GetStaticParameterNames();
                
                var templateContent = TemplateUtility.ExtractTemplateContent(this.ResolvePath(TemplateFile), (!string.IsNullOrEmpty(protectedTemplateUri) ? protectedTemplateUri : TemplateUri), 
                    TemplateSpecId, TemplateSpecsClient, TemplateObject);

                // If bicep params were built, those should be used:
                var templateParameterObject = bicepparamFileParameters != null ? ParameterUtility.RestructureBicepParameters(bicepparamFileParameters) : TemplateParameterObject;
                var templateParams = templateParameterObject != null ? templateParameterObject : 
                    TemplateUtility.ExtractTemplateParameterContent(this.ResolvePath(TemplateParameterFile), TemplateParameterUri);

                dynamicParameters = TemplateUtility.GetDynamicParameters(templateContent, templateParams, staticParameterNames);
            }

            RegisterDynamicParameters(dynamicParameters);

            return dynamicParameters;
        }

        /// <summary>
        /// Extra checks related to bicep that must be made before attempting to extract dynamic parameters.
        /// </summary>
        private void DynamicParameterValidityCheck(bool isBicepParamFile)
        {   
            if (BicepUtility.IsBicepFile(TemplateUri))
            {
                throw new PSInvalidOperationException($"The -{nameof(TemplateUri)} parameter is not supported with .bicep files. Please download the file and pass it using -{nameof(TemplateFile)}.");
            }

            if (!isBicepParamFile && string.IsNullOrEmpty(TemplateFile) && string.IsNullOrEmpty(TemplateUri) && string.IsNullOrEmpty(TemplateSpecId) && TemplateObject == null)
            {
                throw new PSInvalidOperationException($"One of the -{nameof(TemplateFile)}, -{nameof(TemplateUri)}, -{nameof(TemplateSpecId)} or -{nameof(TemplateObject)} parameters must be supplied unless a .bicepparam file is supplied with parameter -{nameof(TemplateParameterFile)}.");
            }

            if (isBicepParamFile && !string.IsNullOrEmpty(TemplateFile) && !BicepUtility.IsBicepFile(TemplateFile))
            {
                throw new PSInvalidOperationException($"Parameter -{nameof(TemplateFile)} only permits .bicep files if a .bicepparam file is supplied with parameter -{nameof(TemplateParameterFile)}.");
            }

            if (isBicepParamFile && (!string.IsNullOrEmpty(TemplateUri) || !string.IsNullOrEmpty(TemplateSpecId) || TemplateObject != null))
            {
                throw new PSInvalidOperationException($"Parameters -{nameof(TemplateUri)}, -{nameof(TemplateSpecId)} or -{nameof(TemplateObject)} cannot be used if a .bicepparam file is supplied with parameter -{nameof(TemplateParameterFile)}.");
            }
        }

        /// <summary>
        /// Gets the names of the static parameters defined for this cmdlet.
        /// </summary>
        protected string[] GetStaticParameterNames()
        {
            if (MyInvocation.MyCommand != null)
            {
                // We're running inside the shell... parameter information will already
                // be resolved for us:
                return MyInvocation.MyCommand.Parameters.Keys.ToArray();
            }

            // This invocation is internal (e.g: through a unit test), fallback to
            // collecting the command/parameter info explicitly from our current type:

            CmdletAttribute cmdletAttribute = (CmdletAttribute)this.GetType()
                .GetCustomAttributes(typeof(CmdletAttribute), true)
                .FirstOrDefault();

            if (cmdletAttribute == null)
            {
                throw new InvalidOperationException(
                    $"Expected type '{this.GetType().Name}' to have CmdletAttribute."
                );
            }

            // The command name we provide for the temporary CmdletInfo isn't consumed
            // anywhere other than instantiation, but let's resolve it anyway:
            string commandName = $"{cmdletAttribute.VerbName}-{cmdletAttribute.NounName}";

            CmdletInfo cmdletInfo = new CmdletInfo(commandName, this.GetType());
            return cmdletInfo.Parameters.Keys.ToArray();
        }

        /// <summary>
        /// Fetches currently used dynamic parameters from the command line.
        /// </summary>
        private IReadOnlyDictionary<string, object> GetUsedDynamicParametersAsDictionary()
        {
            var dynamicParams = PowerShellUtilities.GetUsedDynamicParameters(this.AsJobDynamicParameters, MyInvocation);

            return dynamicParams.ToDictionary(
                x => ((ParameterAttribute)x.Attributes[0]).HelpMessage,
                x => x.Value);
        }
        
        /// <summary>
        /// Used to evaluate the combination of template parameters from passed in static properties and those
        /// extracted via dynamic parameter logic.
        /// </summary>
        /// <returns></returns>
        protected Hashtable GetTemplateParameterObject()
        {
            var parameterObject = new Hashtable();
            
            if (bicepparamFileParameters != null)
            {   
                ParameterUtility.AddTemplateFileParametersToHashtable(bicepparamFileParameters, parameterObject);

                // For bicep params, dynamic parameters have already been taken into account when the file
                // was built, so no more checks need to be made:
                return parameterObject;
            }

            // Load parameters from the object:
            if (TemplateParameterObject != null)
            {
                ParameterUtility.AddTemplateObjectParametersToHashtable(TemplateParameterObject, parameterObject);
            }
            // Load parameters from the file:
            else if (TemplateParameterFile != null)
            {
                // Check whether templateParameterFilePath exists:
                if (FileUtilities.DataStore.FileExists(TemplateParameterFile))
                {
                    var parametersFromFile = TemplateUtility.ParseTemplateParameterFileContents(TemplateParameterFile);
                    ParameterUtility.AddTemplateFileParametersToHashtable(parametersFromFile, parameterObject);
                }
                else
                {
                    // To not break previous behavior, just output a warning.
                    WriteWarning("${templateParameterFilePath} does not exist");
                }
            }

            // Load in dynamic parameters that were provided. They will override 
            // parameters passed in other ways:
            var dynamicParams = GetUsedDynamicParametersAsDictionary();
            foreach (var param in dynamicParams)
            {
                parameterObject[param.Key] = new Hashtable { { "value", param.Value } };
            }

            return parameterObject;
        }

        protected string GetDeploymentDebugLogLevel(string deploymentDebugLogLevel)
        {
            string debugSetting = string.Empty;
            if (!string.IsNullOrEmpty(deploymentDebugLogLevel))
            {
                switch (deploymentDebugLogLevel.ToLower())
                {
                    case "all":
                        debugSetting = "RequestContent,ResponseContent";
                        break;
                    case "requestcontent":
                        debugSetting = "RequestContent";
                        break;
                    case "responsecontent":
                        debugSetting = "ResponseContent";
                        break;
                    case "none":
                        debugSetting = null;
                        break;
                }
            }

            return debugSetting;
        }

        /// <summary>
        /// Attempts to build the bicep param file. If no other template file, uri, or spec is present, a template or template spec
        /// will try to be extracted from the bicep param build output.
        /// </summary>
        /// <param name="emitWarnings">Choice for whether to emit bicep build warnings.</param>
        /// <exception cref="PSInvalidOperationException"></exception>
        protected void BuildAndUseBicepParameters(bool emitWarnings)
        {
            BicepUtility.OutputCallback nullCallback = null;
            // Whatever currently used dynamic parameters are set will be used as override parameters when building the parameter file:
            var output = BicepUtility.Create().BuildBicepParamFile(this.ResolvePath(TemplateParameterFile), GetUsedDynamicParametersAsDictionary(), this.WriteVerbose, emitWarnings ? this.WriteWarning : nullCallback);
            bicepparamFileParameters = TemplateUtility.ParseTemplateParameterJson(output.parametersJson);

            // If there is no template provided, extraction from the bicep parameter output should be attempted:
            if (TemplateObject == null && 
                string.IsNullOrEmpty(TemplateFile) && 
                string.IsNullOrEmpty(TemplateUri) && 
                string.IsNullOrEmpty(TemplateSpecId))
            {
                // When .bicepparam support was first introduced, we were missing the validation to block overriding the 'using' path in these cmdlets.
                // We need to be careful to retain this behavior to avoid breaking existing users, until it is re-introduced intentionally with https://github.com/Azure/bicep/issues/10333.

                if (!string.IsNullOrEmpty(output.templateJson))
                {
                    TemplateObject = output.templateJson.FromJson<Hashtable>();
                }
                else if (!string.IsNullOrEmpty(output.templateSpecId))
                {
                    TemplateSpecId = output.templateSpecId;
                }
                else
                {
                    // This shouldn't happen in practice - the Bicep CLI will return either templateJson or templateSpecId (or fail to run entirely).
                    // TODO: This should happen during dynamic parameter execution when the param file does not include a template.
                    // For some reason though the evaluation of the param file is thinking it has a template even though it shouldn't.
                    throw new PSInvalidOperationException(string.Format(ProjectResources.InvalidFilePath, TemplateParameterFile));
                }
            }
        } 

        /// <summary>
        /// Constructs a TemplateObject from the bicep file located at the TemplateFile address. 
        /// </summary>
        protected void BuildAndUseBicepTemplate()
        {
            var templateJson = BicepUtility.Create().BuildBicepFile(this.ResolvePath(TemplateFile), this.WriteVerbose, this.WriteWarning);
            TemplateObject = templateJson.FromJson<Hashtable>();
            TemplateFile = null;
        }
    }
}
