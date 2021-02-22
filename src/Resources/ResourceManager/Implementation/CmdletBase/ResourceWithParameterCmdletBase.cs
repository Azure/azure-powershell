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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    public abstract class ResourceWithParameterCmdletBase : ResourceManagerCmdletBase
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

        protected RuntimeDefinedParameterDictionary dynamicParameters;

        private Hashtable templateObject;

        private string templateFile;

        private string templateUri;

        private string templateSpecId;

        protected string protectedTemplateUri;

        private ITemplateSpecsClient templateSpecsClient;

        protected ResourceWithParameterCmdletBase()
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
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A file that has the template parameters.")]
        [Parameter(ParameterSetName = TemplateFileParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A file that has the template parameters.")]
        [Parameter(ParameterSetName = TemplateUriParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A file that has the template parameters.")]
        [Parameter(ParameterSetName = TemplateSpecResourceIdParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A file that has the template parameters.")]
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

        public virtual object GetDynamicParameters()
        {
            if (!this.IsParameterBound(c => c.SkipTemplateParameterPrompt))
            {
                // Resolve the static parameter names for this cmdlet:
                string[] staticParameterNames = this.GetStaticParameterNames();

                if (TemplateObject != null && TemplateObject != templateObject)
                {
                    templateObject = TemplateObject;
                    if (string.IsNullOrEmpty(TemplateParameterUri))
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            TemplateObject,
                            TemplateParameterObject,
                            this.ResolvePath(TemplateParameterFile),
                            staticParameterNames);
                    }
                    else
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            TemplateObject,
                            TemplateParameterObject,
                            TemplateParameterUri,
                            staticParameterNames);
                    }
                }
                else if (!string.IsNullOrEmpty(TemplateFile) &&
                    !TemplateFile.Equals(templateFile, StringComparison.OrdinalIgnoreCase))
                {
                    templateFile = TemplateFile;
                    if (string.IsNullOrEmpty(TemplateParameterUri))
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            this.ResolvePath(TemplateFile),
                            TemplateParameterObject,
                            this.ResolvePath(TemplateParameterFile),
                            staticParameterNames);
                    }
                    else
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            this.ResolvePath(TemplateFile),
                            TemplateParameterObject,
                            TemplateParameterUri,
                            staticParameterNames);
                    }
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
                    if (string.IsNullOrEmpty(TemplateParameterUri))
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            templateUri,
                            TemplateParameterObject,
                            this.ResolvePath(TemplateParameterFile),
                            staticParameterNames);
                    }
                    else
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            templateUri,
                            TemplateParameterObject,
                            TemplateParameterUri,
                            staticParameterNames);
                    }
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

                        if (!(templateSpecVersion.Template is JObject))
                        {
                            throw new InvalidOperationException("Unexpected type."); // Sanity check
                        }
                        templateObj = (JObject)templateSpecVersion.Template;
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

                    if (string.IsNullOrEmpty(TemplateParameterUri))
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            templateObj,
                            TemplateParameterObject,
                            this.ResolvePath(TemplateParameterFile),
                            staticParameterNames);
                    }
                    else
                    {
                        dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                            templateObj,
                            TemplateParameterObject,
                            TemplateParameterUri,
                            staticParameterNames);
                    }
                }
            }

            RegisterDynamicParameters(dynamicParameters);

            return dynamicParameters;
        }

        protected Hashtable GetTemplateParameterObject(Hashtable templateParameterObject)
        {
            // NOTE(jogao): create a new Hashtable so that user can re-use the templateParameterObject.
            var prameterObject = new Hashtable();
            if (templateParameterObject != null)
            {
                foreach (var parameterKey in templateParameterObject.Keys)
                {
                    // Let default behavior of a value parameter if not a KeyVault reference Hashtable
                    var hashtableParameter = templateParameterObject[parameterKey] as Hashtable;
                    if (hashtableParameter != null && hashtableParameter.ContainsKey("reference"))
                    {
                        prameterObject[parameterKey] = templateParameterObject[parameterKey];
                    }
                    else
                    {
                        prameterObject[parameterKey] = new Hashtable { { "value", templateParameterObject[parameterKey] } };
                    }
                }
            }

            // Load parameters from the file
            string templateParameterFilePath = this.ResolvePath(TemplateParameterFile);
            if (templateParameterFilePath != null && FileUtilities.DataStore.FileExists(templateParameterFilePath))
            {
                var parametersFromFile = TemplateUtility.ParseTemplateParameterFileContents(templateParameterFilePath);
                parametersFromFile.ForEach(dp =>
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

                        prameterObject[dp.Key] = parameter;
                    });
            }

            // Load dynamic parameters
            IEnumerable<RuntimeDefinedParameter> parameters = PowerShellUtilities.GetUsedDynamicParameters(this.AsJobDynamicParameters, MyInvocation);
            if (parameters.Any())
            {
                parameters.ForEach(dp => prameterObject[((ParameterAttribute)dp.Attributes[0]).HelpMessage] = new Hashtable { { "value", dp.Value } });
            }

            return prameterObject;
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
    }
}
