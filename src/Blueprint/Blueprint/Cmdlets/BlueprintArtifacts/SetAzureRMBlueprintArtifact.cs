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

using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.Blueprint.Models;
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintArtifact", DefaultParameterSetName = ParameterSetNames.CreateTemplateArtifact), OutputType(typeof(Artifact))]
    public class SetAzureRmBlueprintArtifact : BlueprintArtifactsCmdletBase
    {
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
                            PrincipalIds = RoleDefinitionPrincipalId,
                            ResourceGroup = ResourceGroupName,
                            DependsOn = DependsOn
                        };

                        WriteObject(BlueprintClient.CreateArtifact(scope, Blueprint.Name, Name, roleAssignmentArtifact));

                        break;
                    case ParameterSetNames.CreatePolicyAssignmentArtifact:
                        if (!Type.Equals(PSArtifactKind.PolicyAssignmentArtifact)) throw new PSInvalidOperationException("Artifact type mismatch.");

                        Dictionary<string, ParameterValueBase> policyAssignmentParameters = new Dictionary<string, ParameterValueBase>();

                        foreach (var key in PolicyDefinitionParameter.Keys)
                        {
                            var value = new ParameterValue(PolicyDefinitionParameter[key], null);
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
                            //To-Do: This could be done better by creating a type and deserializing the JSON file through converters. 
                            var parametersHashtable = parsedJson["parameters"].ToObject<Dictionary<string, JObject>>();

                            foreach (var key in parametersHashtable.Keys)
                            {
                                var kvp = parametersHashtable[key];
                                var value = kvp["value"].ToString();
                                var paramValue = new ParameterValue(value);
                                parameters.Add(key, paramValue);
                            }
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
    }
}
