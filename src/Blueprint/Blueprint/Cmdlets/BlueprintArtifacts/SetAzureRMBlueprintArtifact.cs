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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintArtifact", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSetNames.UpdateTemplateArtifact), OutputType(typeof(Artifact))]
    public class SetAzureRmBlueprintArtifact : BlueprintArtifactsCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.UpdateArtifactByInputFile, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactName)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactName)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactName)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactType)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactType)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactType)]
        [ValidateNotNullOrEmpty]
        public PSArtifactKind Type { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateArtifactByInputFile, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateTemplateArtifact, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateRoleAssignmentArtifact, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [ValidateNotNull]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDescription)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateRoleAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDescription)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDescription)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDependsOn)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateRoleAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDependsOn)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactDependsOn)]
        public List<string> DependsOn { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactPolicyDefinitionId)]
        [ValidateNotNullOrEmpty]
        public string PolicyDefinitionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactPolicyDefinitionParameter)]
        public Hashtable PolicyDefinitionParameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactTemplateParameterFile)]
        [ValidateNotNullOrEmpty]
        public string TemplateParameterFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactTemplateFile)]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactRoleDefinitionId)]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactRoleDefinitionPrincipalId)]
        [ValidateNotNullOrEmpty]
        public string[] RoleDefinitionPrincipalId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.UpdatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactResourceGroup)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateRoleAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactResourceGroup)]
        [Parameter(ParameterSetName = ParameterSetNames.UpdateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactResourceGroup)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        //Alternatively, user can provide a artifactFile
        [Parameter(ParameterSetName = ParameterSetNames.UpdateArtifactByInputFile, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.ArtifactFile)]
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
                    case ParameterSetNames.UpdateArtifactByInputFile:
                        if (ShouldProcess(Utils.GetDefinitionLocationId(scope), string.Format(Resources.UpdateArtifactShouldProcessString, Name)))
                        {
                            var artifact = JsonConvert.DeserializeObject<Artifact>(
                                AzureSession.Instance.DataStore.ReadFileAsText(ResolveUserPath(ArtifactFile)),
                                DefaultJsonSettings.DeserializerSettings);

                            WriteObject(BlueprintClient.CreateArtifact(scope, Blueprint.Name, Name, artifact));
                        }

                        break;
                    case ParameterSetNames.UpdateRoleAssignmentArtifact:
                        if (ShouldProcess(Utils.GetDefinitionLocationId(scope), string.Format(Resources.UpdateArtifactShouldProcessString, Name)))
                        {
                            // Check if chosen -Type parameter matches with parameters set
                            if (!Type.Equals(PSArtifactKind.RoleAssignmentArtifact))
                                throw new PSInvalidOperationException("Artifact type mismatch.");

                            var roleAssignmentArtifact = new RoleAssignmentArtifact
                            {
                                DisplayName = Name,
                                Description = Description,
                                RoleDefinitionId = RoleDefinitionId,
                                PrincipalIds = RoleDefinitionPrincipalId,
                                ResourceGroup = ResourceGroupName,
                                DependsOn = DependsOn
                            };

                            WriteObject(BlueprintClient.CreateArtifact(scope, Blueprint.Name, Name,
                                roleAssignmentArtifact));
                        }

                        break;
                    case ParameterSetNames.UpdatePolicyAssignmentArtifact:
                        if (ShouldProcess(Utils.GetDefinitionLocationId(scope), string.Format(Resources.UpdateArtifactShouldProcessString, Name)))
                        {
                            if (!Type.Equals(PSArtifactKind.PolicyAssignmentArtifact))
                                throw new PSInvalidOperationException("Artifact type mismatch.");

                            var policyAssignmentParameters = GetPolicyAssignmentParameters(PolicyDefinitionParameter);

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
                        }

                        break;
                    case ParameterSetNames.UpdateTemplateArtifact:
                        if (ShouldProcess(Utils.GetDefinitionLocationId(scope), string.Format(Resources.UpdateArtifactShouldProcessString, Name)))
                        {
                            if (!Type.Equals(PSArtifactKind.TemplateArtifact))
                                throw new PSInvalidOperationException("Artifact type mismatch.");

                            var parameters =
                                GetTemplateParametersFromFile(ValidateAndReturnFilePath(TemplateParameterFile));

                            var templateArtifact = new TemplateArtifact
                            {
                                DisplayName = Name,
                                Description = Description,
                                ResourceGroup = ResourceGroupName,
                                Parameters = parameters,
                                Template = JObject.Parse(AzureSession.Instance.DataStore.ReadFileAsText(ValidateAndReturnFilePath(TemplateFile))),
                                DependsOn = DependsOn
                            };

                            WriteObject(BlueprintClient.CreateArtifact(scope, Blueprint.Name, Name,
                                templateArtifact));
                        }

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
