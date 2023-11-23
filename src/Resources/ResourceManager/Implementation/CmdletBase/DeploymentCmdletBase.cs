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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

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

        protected RuntimeDefinedParameterDictionary dynamicParameters;

        private Hashtable templateObject;

        private string templateFile;

        private string templateUri;

        private string templateSpecId;

        protected string protectedTemplateUri;

        protected IReadOnlyDictionary<string, TemplateParameterFileParameter> bicepparamFileParameters;

        private ITemplateSpecsClient templateSpecsClient;

        protected DeploymentCmdletBase()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
        }

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

        /// <summary>
        /// Gets or sets the Template Specs Azure SDK client
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
            TemplateFile = this.TryResolvePath(TemplateFile);
            TemplateParameterFile = this.TryResolvePath(TemplateParameterFile);
            base.OnBeginProcessing();
        }

        private string GetParameterJsonFilePath()
        {
            if (BicepUtility.IsBicepparamFile(TemplateParameterFile))
            {
                return null;
            }
            
            if (!string.IsNullOrEmpty(TemplateParameterUri))
            {
                return TemplateParameterUri;
            }

            return this.ResolvePath(TemplateParameterFile);
        }

        public new virtual object GetDynamicParameters()
        {
            if (BicepUtility.IsBicepFile(TemplateUri))
            {
                throw new PSInvalidOperationException($"The -{nameof(TemplateUri)} parameter is not supported with .bicep files. Please download the file and pass it using -{nameof(TemplateFile)}.");
            }

            var isBicepParamFile = BicepUtility.IsBicepparamFile(TemplateParameterFile);
            if (!isBicepParamFile && string.IsNullOrEmpty(TemplateFile) && string.IsNullOrEmpty(TemplateUri) && string.IsNullOrEmpty(TemplateSpecId) && TemplateObject == null)
            {
                throw new PSInvalidOperationException($"One of the -{nameof(TemplateFile)}, -{nameof(TemplateUri)}, -{nameof(TemplateSpecId)} or -{nameof(TemplateObject)} parameters must be supplied unless a .bicepparam file is supplied with parameter -{nameof(TemplateParameterFile)}.");
            }

            if (BicepUtility.IsBicepparamFile(TemplateParameterFile) && !string.IsNullOrEmpty(TemplateFile) && !BicepUtility.IsBicepFile(TemplateFile))
            {
                throw new PSInvalidOperationException($"Parameter -{nameof(TemplateFile)} only permits .bicep files if a .bicepparam file is supplied with parameter -{nameof(TemplateParameterFile)}.");
            }

            if (BicepUtility.IsBicepparamFile(TemplateParameterFile) && (!string.IsNullOrEmpty(TemplateUri) || !string.IsNullOrEmpty(TemplateSpecId) || TemplateObject != null))
            {
                throw new PSInvalidOperationException($"Parameters -{nameof(TemplateUri)}, -{nameof(TemplateSpecId)} or -{nameof(TemplateObject)} cannot be used if a .bicepparam file is supplied with parameter -{nameof(TemplateParameterFile)}.");
            }

            if (BicepUtility.IsBicepparamFile(TemplateParameterFile))
            {
                BuildAndUseBicepParameters(emitWarnings: false);
            }

            if (BicepUtility.IsBicepFile(TemplateFile))
            {
                BuildAndUseBicepTemplate();
            }
               
            if (!this.IsParameterBound(c => c.SkipTemplateParameterPrompt))
            {
                // Resolve the static parameter names for this cmdlet:
                string[] staticParameterNames = this.GetStaticParameterNames();
                var combinedParameterObject = GetCombinedTemplateParameterObject();
                var jsonParamFilePath = BicepUtility.IsBicepparamFile(TemplateParameterFile) ? null : this.ResolvePath(TemplateParameterFile);

                if (TemplateObject != null && TemplateObject != templateObject)
                {
                    templateObject = TemplateObject;
                    dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        TemplateObject,
                        combinedParameterObject,
                        GetParameterJsonFilePath(),
                        staticParameterNames);
                }
                else if (!string.IsNullOrEmpty(TemplateFile) &&
                    !TemplateFile.Equals(templateFile, StringComparison.OrdinalIgnoreCase))
                {
                    templateFile = TemplateFile;
                    dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        this.ResolvePath(TemplateFile),
                        combinedParameterObject,
                        GetParameterJsonFilePath(),
                        staticParameterNames);
                }
                else if (!string.IsNullOrEmpty(TemplateUri) &&
                    !TemplateUri.Equals(templateUri, StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrEmpty(protectedTemplateUri))
                    {
                        templateUri = TemplateUri;
                    }
                    else
                    {
                        templateUri = protectedTemplateUri;
                    }

                    dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        templateUri,
                        combinedParameterObject,
                        GetParameterJsonFilePath(),
                        staticParameterNames);
                }
                else if (!string.IsNullOrEmpty(TemplateSpecId) &&
                    !TemplateSpecId.Equals(templateSpecId, StringComparison.OrdinalIgnoreCase))
                {
                    templateSpecId = TemplateSpecId;
                    ResourceIdentifier resourceIdentifier = new ResourceIdentifier(templateSpecId);
                    if(!resourceIdentifier.ResourceType.Equals("Microsoft.Resources/templateSpecs/versions", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException("No version found in Resource ID");
                    }

                    if (!string.IsNullOrEmpty(resourceIdentifier.Subscription) &&
                        TemplateSpecsClient.SubscriptionId != resourceIdentifier.Subscription)
                    {
                        // The template spec is in a different subscription than our default
                        // context. Force the client to use that subscription:
                        TemplateSpecsClient.SubscriptionId = resourceIdentifier.Subscription;
                    }
                    JObject templateObj = (JObject)null;
                    try
                    {
                        var templateSpecVersion = TemplateSpecsClient.TemplateSpecVersions.Get(
                            ResourceIdUtility.GetResourceGroupName(templateSpecId),
                            ResourceIdUtility.GetResourceName(templateSpecId).Split('/')[0],
                            resourceIdentifier.ResourceName);

                        if (!(templateSpecVersion.MainTemplate is JObject))
                        {
                            throw new InvalidOperationException("Unexpected type."); // Sanity check
                        }
                        templateObj = (JObject)templateSpecVersion.MainTemplate;
                    }
                    catch (TemplateSpecsErrorException e)
                    {
                        //If the templateSpec resourceID is pointing to a non existant resource
                        if(e.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                        {
                            //By returning null, we are introducing parity in the way templateURI and templateSpecId are validated. Gives a cleaner error message in line with the error message for invalid templateURI
                            return null;
                        }
                        //Throw for any other error that is not due to a 404 for the template resource.
                        throw;
                    }

                    dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        templateObj,
                        combinedParameterObject,
                        GetParameterJsonFilePath(),
                        staticParameterNames);
                }
            }

            RegisterDynamicParameters(dynamicParameters);

            return dynamicParameters;
        }

        private static void AddToParametersHashtable(IReadOnlyDictionary<string, TemplateParameterFileParameter> parameters, Hashtable parameterObject)
        {
            parameters.ForEach(dp =>
            {
                var parameter = new Hashtable();
                if (dp.Value.Value != null)
                {
                    parameter.Add("value", dp.Value.Value);
                }
                if (dp.Value.Reference != null)
                {
                    parameter.Add("reference", dp.Value.Reference);
                }

                parameterObject[dp.Key] = parameter;
            });
        }

        protected Hashtable GetTemplateParameterObject()
        {
            var parameterObject = new Hashtable();
            if (bicepparamFileParameters != null)
            {
                BuildAndUseBicepParameters(emitWarnings: true);
                AddToParametersHashtable(bicepparamFileParameters, parameterObject);
                return parameterObject;
            }

            if (TemplateParameterObject != null)
            {
                foreach (var parameterKey in TemplateParameterObject.Keys)
                {
                    // Let default behavior of a value parameter if not a KeyVault reference Hashtable
                    var hashtableParameter = TemplateParameterObject[parameterKey] as Hashtable;
                    if (hashtableParameter != null && hashtableParameter.ContainsKey("reference"))
                    {
                        parameterObject[parameterKey] = TemplateParameterObject[parameterKey];
                    }
                    else
                    {
                        parameterObject[parameterKey] = new Hashtable { { "value", TemplateParameterObject[parameterKey] } };
                    }
                }
            }

            // Load parameters from the file
            string templateParameterFilePath = this.ResolvePath(TemplateParameterFile);
            if (templateParameterFilePath != null)
            {
                // Check whether templateParameterFilePath exists
                if (FileUtilities.DataStore.FileExists(templateParameterFilePath))
                {
                    var parametersFromFile = TemplateUtility.ParseTemplateParameterFileContents(templateParameterFilePath);
                    AddToParametersHashtable(parametersFromFile, parameterObject);
                }
                else
                {
                    // To not break previous behavior, just output a warning.
                    WriteWarning("${templateParameterFilePath} does not exist");
                }
            }

            var dynamicParams = GetDynamicParametersDictionary();
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

        protected void BuildAndUseBicepTemplate()
        {
            TemplateFile = BicepUtility.Create().BuildFile(this.ResolvePath(TemplateFile), this.WriteVerbose, this.WriteWarning);
        }

        private IReadOnlyDictionary<string, object> GetDynamicParametersDictionary()
        {
            var dynamicParams = PowerShellUtilities.GetUsedDynamicParameters(this.AsJobDynamicParameters, MyInvocation);

            return dynamicParams.ToDictionary(
                x => ((ParameterAttribute)x.Attributes[0]).HelpMessage,
                x => x.Value);
        }

        protected void BuildAndUseBicepParameters(bool emitWarnings)
        {
            BicepUtility.OutputCallback nullCallback = null;
            var output = BicepUtility.Create().BuildParams(this.ResolvePath(TemplateParameterFile), GetDynamicParametersDictionary(), this.WriteVerbose, emitWarnings ? this.WriteWarning : nullCallback);
            bicepparamFileParameters = TemplateUtility.ParseTemplateParameterJson(output.parametersJson);

            if (TemplateObject == null && 
                string.IsNullOrEmpty(TemplateFile) && 
                string.IsNullOrEmpty(TemplateUri) && 
                string.IsNullOrEmpty(TemplateSpecId))
            {
                // When .bicepparam support was first introduced, we were missing the validation to block overriding the 'using' path in these cmdlets.
                // We need to be careful to retain this behavior to avoid breaking existing users, until it is re-introduced intentionally with https://github.com/Azure/bicep/issues/10333.

                if (!string.IsNullOrEmpty(output.templateJson))
                {
                    TemplateObject = JsonConvert.DeserializeObject<Hashtable>(output.templateJson);
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
        }

        private Hashtable GetCombinedTemplateParameterObject()
        {
            if (bicepparamFileParameters != null)
            {
                // The TemplateParameterObject property expects parameters to be in a different format to the parameters file JSON.
                // Here we convert from { "foo": { "value": "blah" } } to { "foo": "blah" }
                // with the exception of KV secret references which are left as { "foo": { "reference": ... } }
                var parameters = new Hashtable();
                foreach (var paramName in bicepparamFileParameters.Keys)
                {
                    var param = bicepparamFileParameters[paramName];
                    if (param.Value != null)
                    {
                        parameters[paramName] = param.Value;
                    }
                    if (param.Reference != null)
                    {
                        var parameter = new Hashtable();
                        parameter.Add("reference", param.Reference);
                        parameters[paramName] = parameter;
                    }
                }

                return parameters;
            }

            return TemplateParameterObject;
        }
    }
}
