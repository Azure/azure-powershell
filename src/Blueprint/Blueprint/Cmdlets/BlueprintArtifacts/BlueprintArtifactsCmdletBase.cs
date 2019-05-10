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
using System.Management.Automation;
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    public class BlueprintArtifactsCmdletBase : BlueprintCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.ArtifactsByBlueprint, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactName)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateArtifactByInputFile, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactName)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactName)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactName)]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactType)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactType)]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactType)]
        [ValidateNotNullOrEmpty]
        public PSArtifactKind Type { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ArtifactsByBlueprint, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateArtifactByInputFile, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [ValidateNotNull]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDescription)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDescription)]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDescription)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDependsOn)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDependsOn)]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDependsOn)]
        public List<string> DependsOn { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactPolicyDefinitionId)]
        [ValidateNotNullOrEmpty]
        public string PolicyDefinitionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactPolicyDefinitionParameter)]
        [ValidateNotNullOrEmpty]
        public Hashtable PolicyDefinitionParameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactTemplateParameterFile)]
        [ValidateNotNullOrEmpty]
        public string TemplateParameterFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactTemplateFile)]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactRoleDefinitionId)]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactRoleDefinitionPrincipalId)]
        [ValidateNotNullOrEmpty]
        public string[] RoleDefinitionPrincipalId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactResourceGroup)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactResourceGroup)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactResourceGroup)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        //Alternatively, user can provide a artifactFile
        [Parameter(ParameterSetName = ParameterSetNames.CreateArtifactByInputFile, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactFile)]
        [ValidateNotNullOrEmpty]
        public string ArtifactFile { get; set; }

        #endregion
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

            //To-Do: This could be done better by creating a type and deserializing the JSON file through converters. 
            var parametersHashtable = parsedJson["parameters"].ToObject<Dictionary<string, JObject>>();

            foreach (var key in parametersHashtable.Keys)
            {
                var kvp = parametersHashtable[key];
                var value = kvp["value"].ToString();
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
