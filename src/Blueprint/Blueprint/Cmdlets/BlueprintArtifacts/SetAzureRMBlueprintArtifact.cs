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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Blueprint.Models;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;
using ParameterHelpMessages = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterHelpMessages;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintArtifact", DefaultParameterSetName = ParameterSetNames.CreateTemplateArtifact), OutputType(typeof(Artifact))]
    public class SetAzureRmBlueprintArtifact : BlueprintArtifactsCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.CreateArtifactByInputFile, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public PSArtifactKind Type { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateArtifactByInputFile, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipeline = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipeline = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipeline = true, HelpMessage = "To-Do")]
        [ValidateNotNull]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        public List<string> DependsOn { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string PolicyDefinitionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public Hashtable PolicyParameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string TemplateParameterFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string[] PrincipalIds { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        //Alternatively, user can provide a artifactFile
        [Parameter(ParameterSetName = ParameterSetNames.CreateArtifactByInputFile, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string ArtifactFile { get; set; }

        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            try
            {
                var scope = Blueprint.Scope;
                ThrowIfArtifactNotExist(scope, Blueprint.Name, Name);

                switch (ParameterSetName)
                {
                    case ParameterSetNames.CreateArtifactByInputFile:
                        var artifact = JsonConvert.DeserializeObject<Artifact>(File.ReadAllText(ResolveUserPath(ArtifactFile)),
                            DefaultJsonSettings.DeserializerSettings);


                        WriteObject(BlueprintClient.CreateArtifact(scope, Blueprint.Name, Name, artifact));
                        break;
                    case ParameterSetNames.CreateRoleAssignmentArtifact:
                        if (!Type.Equals(PSArtifactKind.RoleAssignmentArtifact)) throw new PSInvalidOperationException("Artifact type mismatch."); ;

                        var roleAssignmentArtifact = new RoleAssignmentArtifact
                        {
                            DisplayName = null,
                            Description = Description,
                            RoleDefinitionId = RoleDefinitionId,
                            PrincipalIds = PrincipalIds,
                            ResourceGroup = ResourceGroupName,
                            DependsOn = DependsOn
                        };

                        WriteObject(BlueprintClient.CreateArtifact(scope, Blueprint.Name, Name, roleAssignmentArtifact));

                        break;
                    case ParameterSetNames.CreatePolicyAssignmentArtifact:
                        if (!Type.Equals(PSArtifactKind.PolicyAssignmentArtifact)) throw new PSInvalidOperationException("Artifact type mismatch.");

                        Dictionary<string, ParameterValueBase> policyAssignmentParameters = new Dictionary<string, ParameterValueBase>();

                        foreach (var key in PolicyParameter.Keys)
                        {
                            var value = new ParameterValue(PolicyParameter[key], null);
                            policyAssignmentParameters.Add(key.ToString(), value);
                        }

                        var policyArtifact = new PolicyAssignmentArtifact
                        {
                            DisplayName = Name,
                            Description = Description,
                            PolicyDefinitionId = PolicyDefinitionId,
                            Parameters = policyAssignmentParameters,
                            DependsOn = DependsOn,
                            ResourceGroup = ResourceGroupName
                        };

                        WriteObject(BlueprintClient.CreateArtifact(scope, Blueprint.Name, Name, policyArtifact));

                        break;
                    case ParameterSetNames.CreateTemplateArtifact:
                        if (!Type.Equals(PSArtifactKind.TemplateArtifact)) throw new PSInvalidOperationException("Artifact type mismatch."); ;

                        var templatePath = ResolveUserPath(TemplateFile);
                        var parameterFilePath = ResolveUserPath(TemplateParameterFile);

                        if (!new FileInfo(templatePath).Exists)
                        {
                            throw new FileNotFoundException(string.Format("Add here the path"));
                        }

                        Dictionary<string, ParameterValueBase> parameters = new Dictionary<string, ParameterValueBase>();
                        if (this.IsParameterBound(c => c.TemplateParameterFile))
                        {
                            if (parameterFilePath == null || !new FileInfo(parameterFilePath).Exists)
                            {
                                throw new FileNotFoundException(string.Format("Add here the path"));
                            }

                            // Missing schema here.
                            JObject parsedJson = JObject.Parse(File.ReadAllText(parameterFilePath));
                            //To-Do: Next action is to find a better way to check if parameters exists and parse.
                            var parametersHashtable = parsedJson["parameters"].ToObject<Dictionary<string, JObject>>();

                            foreach (var key in parametersHashtable.Keys)
                            {
                                var kvp = parametersHashtable[key];
                                var value = kvp["value"].ToString();
                                var paramValue = new ParameterValue(value);
                                parameters.Add(key, paramValue);
                            }
                            //paramObjects.ForEach(kvp => parameters.Add(kvp.Key, kvp.Value));
                        }

                        var templateArtifact = new TemplateArtifact
                        {
                            DisplayName = Name,
                            Description = Description,
                            ResourceGroup = ResourceGroupName,
                            Parameters = parameters,
                            Template = JObject.Parse(File.ReadAllText(templatePath)),
                            DependsOn = DependsOn
                        };

                        WriteObject(BlueprintClientWithVersion.CreateArtifact(scope, Blueprint.Name, Name, templateArtifact));
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
        #endregion

        //To-Do: Update exception messages below

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
    }
}
