using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.Rest.Azure;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    public class BlueprintArtifactsCmdletBase : BlueprintCmdletBase
    {

        // To-Do: Update error message
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

        protected Dictionary<string, ParameterValueBase> GetPolicyAssignmentParameters(Hashtable policyParameter)
        {
            var policyAssignmentParameters = new Dictionary<string, ParameterValueBase>();

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

            if (templatePath == null || !File.Exists(templatePath))
            {
                throw new FileNotFoundException(string.Format("Can't find file at " + filePath));
            }

            return templatePath;
        }

        protected Dictionary<string, ParameterValueBase> GetTemplateParametersFromFile(string validatedFilePath)
        {
            Dictionary<string, ParameterValueBase> parameters = new Dictionary<string, ParameterValueBase>();

            JObject parsedJson = JObject.Parse(File.ReadAllText(validatedFilePath));
            //To-Do: Next action is to find a better way to check if parameters exists and parse.  // Missing schema here.
            var parametersHashtable = parsedJson["parameters"].ToObject<Dictionary<string, JObject>>();

            foreach (var key in parametersHashtable.Keys)
            {
                var kvp = parametersHashtable[key];
                var value = kvp["value"].ToString();
                var paramValue = new ParameterValue(value);
                parameters.Add(key, paramValue);
            }
            //paramObjects.ForEach(kvp => parameters.Add(kvp.Key, kvp.Value));

            return parameters;
        }
    }
}
