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
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Management.Blueprint.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using ParameterSetNames = Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintArtifact", DefaultParameterSetName = ParameterSetNames.CreateTemplateArtifact), OutputType(typeof(Artifact))]
    public class NewAzureRMBlueprintArtifact : BlueprintArtifactsCmdletBase
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

        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public Hashtable PolicyParameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
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

                ThrowIfArtifactExits(scope, Blueprint.Name, Name);

                switch (ParameterSetName)
                {
                    case ParameterSetNames.CreateArtifactByInputFile:
                        var artifact = JsonConvert.DeserializeObject<Artifact>(File.ReadAllText(ResolveUserPath(ArtifactFile)),
                            DefaultJsonSettings.DeserializerSettings);

                        WriteObject(BlueprintClient.CreateArtifact(scope, Blueprint.Name, Name, artifact));
                        break;
                    case ParameterSetNames.CreateRoleAssignmentArtifact:
                        // Check if chosen -Type parameter matches with parameters set
                        if (!Type.Equals(PSArtifactKind.RoleAssignmentArtifact)) throw new PSInvalidOperationException("Artifact type mismatch."); ;

                        var roleAssignmentArtifact = new RoleAssignmentArtifact
                        {
                            DisplayName = Name,
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

                        var policyAssignmentParameters = GetPolicyAssignmentParameters(PolicyParameter);

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

                        var parameters = GetTemplateParametersFromFile(ValidateAndReturnFilePath(TemplateParameterFile));
 
                        var templateArtifact = new TemplateArtifact
                        {
                            DisplayName = Name,
                            Description = Description,
                            ResourceGroup = ResourceGroupName,
                            Parameters = parameters,
                            Template = JObject.Parse(File.ReadAllText(ValidateAndReturnFilePath(TemplateFile))),
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
