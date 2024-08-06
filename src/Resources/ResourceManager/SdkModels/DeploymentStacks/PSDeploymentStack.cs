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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkExtensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStacks;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public class PSDeploymentStack
    {

        public string id { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public string resourcesCleanupAction { get; set; }

        public string resourceGroupsCleanupAction { get; set; }

        public string managementGroupsCleanupAction { get; set; }

        public SystemData systemData { get; set; }

        public string location { get; set; }

        public DenySettings denySettings { get; set; }

        public Dictionary<string, DeploymentVariable> outputs { get; set; }

        public IDictionary<string, PSDeploymentStackParameter> parameters { get; set; }

        public IDictionary<string, string> tags { get; set; }

        public DeploymentStacksParametersLink parametersLink { get; set; }

        public DeploymentStacksDebugSetting debugSetting { get; set; }

        public string provisioningState { get; set; }

        public string deploymentScope { get; set; }

        public string description { get; set; }

        public string duration { get; set; }

        public IList<ManagedResourceReference> resources { get; set; }

        public IList<ResourceReference> detachedResources { get; set; }

        public IList<ResourceReferenceExtended> failedResources { get; set; }

        public IList<ResourceReference> deletedResources { get; set; }

        public string deploymentId { get; set; }

        public ErrorDetail error { get; set; }

        public string correlationId { get; set; }

        public PSDeploymentStack() { }

        internal PSDeploymentStack(DeploymentStack deploymentStack)
        {
            this.id = deploymentStack.Id;
            this.name = deploymentStack.Name;
            this.type = deploymentStack.Type;
            this.systemData = deploymentStack.SystemData;
            this.resourcesCleanupAction = deploymentStack.ActionOnUnmanage.Resources;
            this.resourceGroupsCleanupAction = deploymentStack.ActionOnUnmanage.ResourceGroups;
            this.managementGroupsCleanupAction = deploymentStack.ActionOnUnmanage.ManagementGroups;
            this.location = deploymentStack.Location;
            this.parametersLink = deploymentStack.ParametersLink;
            this.debugSetting = deploymentStack.DebugSetting;
            this.provisioningState = deploymentStack.ProvisioningState;
            this.deploymentScope = deploymentStack.DeploymentScope;
            this.description = deploymentStack.Description;
            this.resources = deploymentStack.Resources;
            this.denySettings = deploymentStack.DenySettings;
            this.detachedResources = deploymentStack.DetachedResources;
            this.deletedResources = deploymentStack.DeletedResources;
            this.failedResources = deploymentStack.FailedResources;
            this.deploymentId = deploymentStack.DeploymentId;
            this.duration = deploymentStack.Duration;
            this.error = deploymentStack.Error;
            this.parametersLink = deploymentStack.ParametersLink;
            this.tags = deploymentStack.Tags;
            this.correlationId = deploymentStack.CorrelationId;


            // Convert the raw outputs and parameters objects to dictionaries.
            this.parameters = deploymentStack.Parameters != null ? ConvertParameterDictionary(deploymentStack.Parameters) : null;
            this.outputs = deploymentStack.Outputs != null ? ConvertOutputDictionary(deploymentStack.Outputs) : null;
        }

        public static string ConstructDeploymentStacksParametersTable(IDictionary<string, PSDeploymentStackParameter> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            var maxNameLength = 15;
            dictionary.Keys.ForEach(k => maxNameLength = Math.Max(maxNameLength, k.Length + 2));

            var maxTypeLength = 25;
            dictionary.Values.ForEach(v => maxTypeLength = Math.Max(maxTypeLength, v.Type.Length + 2));

            StringBuilder result = new StringBuilder();

            var rawParameters = dictionary.Where(entry => entry.Value.KeyVaultReference == null);
            var refParameters = dictionary.Where(entry => entry.Value.KeyVaultReference != null);

            if (rawParameters.Count() > 0)
            {
                string rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxTypeLength + "}  {2, -10}\r\n";
                result.AppendLine();
                result.AppendFormat(rowFormat, "Name", "Type", "Value");
                result.AppendFormat(rowFormat, GeneralUtilities.GenerateSeparator(maxNameLength, "="), GeneralUtilities.GenerateSeparator(maxTypeLength, "="), GeneralUtilities.GenerateSeparator(10, "="));

                foreach (KeyValuePair<string, PSDeploymentStackParameter> pair in rawParameters)
                {
                    result.AppendFormat(rowFormat, pair.Key, pair.Value.Type,
                        JsonConvert.SerializeObject(pair.Value.Value).Indent(maxNameLength + maxTypeLength + 4).Trim());
                }
            }

            if (refParameters.Count() > 0)
            {
                string rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxTypeLength + "}  {2, -10}  {3, -15}  {4, -10}\r\n";
                result.AppendLine();
                result.AppendFormat(rowFormat, "Name", "Type", "SecretName", "SecretVersion", "KeyVault");
                result.AppendFormat(rowFormat, GeneralUtilities.GenerateSeparator(maxNameLength, "="), GeneralUtilities.GenerateSeparator(maxTypeLength, "="), GeneralUtilities.GenerateSeparator(10, "="), GeneralUtilities.GenerateSeparator(15, "="), GeneralUtilities.GenerateSeparator(10, "="));

                foreach (KeyValuePair<string, PSDeploymentStackParameter> pair in refParameters)
                { 
                    result.AppendFormat(rowFormat, pair.Key, pair.Value.Type, pair.Value.KeyVaultReference.SecretName, pair.Value.KeyVaultReference.SecretVersion, pair.Value.KeyVaultReference.KeyVault.Id);
                }
          
            }

            return result.ToString();
        }

        public string GetFormattedParameterTable()
        {
            return ConstructDeploymentStacksParametersTable(this.parameters);
        }

        public string GetFormattedOutputTable()
        {
            return ResourcesExtensions.ConstructDeploymentVariableTable(this.outputs);
        }

        public string GetFormattedTagTable()
        {
            return ResourcesExtensions.ConstructTagsTableFromIDictionary(this.tags);
        }

        private const char Whitespace = ' ';

        public string GetFormattedErrorString()
        {
            return this.error == null
                ? string.Empty
                : GetFormattedErrorString(this.error).TrimEnd('\r', '\n');
        }

        private static string GetFormattedErrorString(ErrorDetail error, int level = 0)
        {
            if (error.Details == null)
            {
                return string.Format(ProjectResources.DeploymentOperationErrorMessageNoDetails, error.Message, error.Code);
            }

            string errorDetail = null;

            foreach (ErrorDetail detail in error.Details)
            {
                errorDetail += GetIndentation(level) + GetFormattedErrorString(detail, level + 1) + System.Environment.NewLine;
            }

            return string.Format(ProjectResources.DeploymentOperationErrorMessage, error.Message, error.Code, errorDetail);
        }

        private static string GetIndentation(int l)
        {
            return new StringBuilder().Append(Whitespace, l * 2).Append(" - ").ToString();
        }

        internal static PSDeploymentStack FromAzureSDKDeploymentStack(DeploymentStack stack)
        {
            return stack != null
                ? new PSDeploymentStack(stack)
                : null;
        }


        /// <summary>
        /// This conversion method is required to fit the outputs in the deployment stack response object into a custom powershell object that has additional structure and 
        /// custom output formatting. It also enables type population for outputs that are not returned with an explict type.
        /// </summary>
        /// <param name="outputs">The outputs of the deployment stack response object.</param>
        internal static Dictionary<string, DeploymentVariable> ConvertOutputDictionary(object outputs)
        {
            var outputsPS = new Dictionary<string, DeploymentVariable>();

            // Extract DeploymentVariables from the passed in json object.
            var jObject = JObject.Parse(outputs.ToString());
            foreach (var props in jObject.Properties())
            {
                outputsPS[props.Name] = ExtractDeploymentVariableFromJObject(props.Value as JObject);
            }

            // Continue deserialize if the type of Value in DeploymentVariable is array.
            outputsPS?.Values.ForEach(dv =>
            { 
                if ("Array".Equals(dv?.Type) && dv?.Value != null)
                {
                    dv.Value = dv.Value.ToString().FromJson<object[]>();
                }
            });

            return outputsPS;
        }

        /// <summary>
        /// This conversion method is required to fit the parameters in the deployment stack response object into a custom powershell object that has additional structure and 
        /// custom output formatting. It also enables type population for parameters that are not returned with an explict type.
        /// </summary>
        /// <param name="parameters">The deployment parameters of the deployment stack response object.</param>
        internal static Dictionary<string, PSDeploymentStackParameter> ConvertParameterDictionary(IDictionary<string, DeploymentParameter> parameters)
        {
            var parametersPS = new Dictionary<string, PSDeploymentStackParameter>();

            foreach (var key in parameters.Keys)
            {
                // Each entry will be an explicit parameter value or a key vault reference, both of which can include type.
                PSDeploymentStackParameter parameter;
                if (parameters[key].Reference != null)
                {
                    parameter = new PSDeploymentStackParameter { KeyVaultReference = parameters[key].Reference };

                    if (parameters[key].Type != null)
                    {
                        parameter.Type = parameters[key].Type;
                    }
                    else
                    {
                        // If type does not exist, secret value is unknown and the type cannot be inferred:
                        parameter.Type = "unknown";
                    }
                }
                else
                {
                    // If the type is not present, attempt to infer:
                    parameter = new PSDeploymentStackParameter { Value = parameters[key].Value, Type = parameters[key].Type != null ? parameters[key].Type : ExtractDeploymentStackParameterValueType(parameters[key].Value) };
                    if (parameter.Value != null && "Array".Equals(parameter.Type))
                    {
                        parameter.Value = JsonConvert.DeserializeObject<object[]>(parameter.Value.ToString());
                    }
                }

                parametersPS.Add(key, parameter);
            }

            return parametersPS;
        }

        internal static DeploymentVariable ExtractDeploymentVariableFromJObject(JObject jObject)
        {
            // Attempt to desialize the DeploymentVariable:
            var dVar = jObject.ToString().FromJson<DeploymentVariable>();

            // If the type is null, attempt to infer the type:
            if (dVar.Type is null)
            {
                JToken value; 
                var hasValue = jObject.TryGetValue("value", out value);
                
                // Value was there, we can infer the type:
                if (hasValue)
                {
                    // interpret type and find matching ARM type:
                    switch (value.Type)
                    {
                        case JTokenType.String:
                            dVar.Type = "string";
                            break;
                        case JTokenType.Array:
                            dVar.Type = "array";
                            break;
                        case JTokenType.Integer:
                            dVar.Type = "integer";
                            break;
                        case JTokenType.Boolean:
                            dVar.Type = "boolean";
                            break;
                        default:
                            dVar.Type = "object";
                            break;
                    }
                }
            }
            
            return dVar;
        }

        internal static string ExtractDeploymentStackParameterValueType(object value)
        {
            // Switch on the value's type in an attempt to infer type from value:
            switch (value)
            {
                case int _:
                    return "int";
                case string _:
                    return "string";
                case bool _:
                    return "bool";
                case JArray _:
                    return "array";
                default:
                    return "object";
            }
        }
    }
}