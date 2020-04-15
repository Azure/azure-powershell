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

using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.Rest.Azure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    public class BlueprintArtifactsCmdletBase : BlueprintCmdletBase
    {
        protected Dictionary<string, ParameterValue> GetPolicyAssignmentParameters(Hashtable policyParameter)
        {
            var policyAssignmentParameters = new Dictionary<string, ParameterValue>();

            foreach (var key in policyParameter.Keys)
            {
                var value = new ParameterValue(policyParameter[key], null);
                policyAssignmentParameters.Add(key.ToString(), value);
            }

            return policyAssignmentParameters;
        }

        protected string ValidateAndReturnFilePath(string filePath)
        {
            var templatePath = ResolveUserPath(filePath);

            if (templatePath == null || !AzureSession.Instance.DataStore.FileExists(templatePath))
            {
                throw new FileNotFoundException(string.Format("Can't find file at " + filePath));
            }

            return templatePath;
        }

        protected Dictionary<string, ParameterValue> GetTemplateParametersFromFile(string validatedFilePath)
        {
            Dictionary<string, ParameterValue> parameters = new Dictionary<string, ParameterValue>();

            JObject parsedJson = JObject.Parse(AzureSession.Instance.DataStore.ReadFileAsText(validatedFilePath));

            //To-Do: This could be done better by creating a type and deserializing the JSON file through converters. 
            var parametersHashtable = parsedJson["parameters"].ToObject<Dictionary<string, JObject>>();

            foreach (var key in parametersHashtable.Keys)
            {
                var kvp = parametersHashtable[key];
                var value = kvp["value"];
                var paramValue = new ParameterValue(value);
                parameters.Add(key, paramValue);
            }

            return parameters;
        }

        protected void ThrowIfArtifactNotExist(string scope, string blueprintName, string artifactName)
        {
            PSArtifact artifact = null;

            try
            {
                artifact = BlueprintClient.GetArtifact(scope, blueprintName, artifactName, null);
            }
            catch (Exception ex)
            {
                if (ex is CloudException cex && cex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    // if exception is for a reason other than .NotFound, pass it to the caller.
                    throw;
                }
            }

            if (artifact == null)
            {
                throw new Exception(string.Format(Resources.ArtifactNotExist, artifactName, blueprintName));
            }
        }
        protected void ThrowIfArtifactExits(string scope, string blueprintName, string artifactName)
        {
            PSArtifact artifact = null;

            try
            {
                artifact = BlueprintClient.GetArtifact(scope, blueprintName, artifactName, null);
            }
            catch (Exception ex)
            {
                if (ex is CloudException cex && cex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    // if exception is for a reason other than .NotFound, pass it to the caller.
                    throw;
                }
            }

            if (artifact != null)
            {
                throw new Exception(string.Format(Resources.ArtifactExists, artifactName, blueprintName));
            }
        }
    }
}
