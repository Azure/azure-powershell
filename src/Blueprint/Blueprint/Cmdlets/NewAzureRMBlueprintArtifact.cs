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

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "BlueprintArtifact", DefaultParameterSetName = ParameterSetNames.SubscriptionScope), OutputType(typeof(PSBlueprint), typeof(PSPublishedBlueprint))]
    public class NewAzureRMBlueprintArtifact : BlueprintCmdletBase
    {
        #region Parameters
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

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipeline = true, HelpMessage = "To-Do")]
        [ValidateNotNull]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string PolicyDefinitionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreatePolicyAssignmentArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public Hashtable Parameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string ParameterFile { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string RoleDefinitionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateRoleAssignmentArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string[] PrincipalIds { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateTemplateArtifact, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string Template { get; set; }
        
        #endregion

        #region MyRegion

        public override void ExecuteCmdlet()
        {
            try
            {
                var scope = Utils.GetScopeForSubscription(Blueprint.Scope);

                switch (ParameterSetName)
                {
                    case ParameterSetNames.CreateRoleAssignmentArtifact:

                        var roleAssignmentArtifact = new RoleAssignmentArtifact
                        {
                            DisplayName = Name,
                            Description = Description,
                            RoleDefinitionId = RoleDefinitionId,
                            PrincipalIds = PrincipalIds,
                            ResourceGroup = ResourceGroup,
                            DependsOn = null
                        };

                        WriteObject(BlueprintClient.CreateArtifact(scope, Blueprint.Name, Name, roleAssignmentArtifact));

                        break;
                    case ParameterSetNames.CreatePolicyAssignmentArtifact:
                        var policyArtifact = new PolicyAssignmentArtifact
                        {
                            DisplayName = Name,
                            PolicyDefinitionId = PolicyDefinitionId,
                            Parameters = new Dictionary<string, ParameterValueBase>(),
                            DependsOn = null // To-Do: what to do with depends on?
                        };

                        WriteObject(BlueprintClient.CreateArtifact(scope, Blueprint.Name, Name, policyArtifact));

                        break;
                   case ParameterSetNames.CreateTemplateArtifact:
                      // PS C:\> New - AzBlueprintArtifact
                     //      - Name ‘vNic template’
                     //       -Blueprint $bp
                     //      - ResourceGroup ‘vNicResourceGroup’
                     //      -Template { }
                    //       -Parameter C:\parameters.json

                      
                       var resolvedTemplatePath = this.ResolveUserPath(Template);
                       var resolvedParameterPath = this.ResolveUserPath(ParameterFile);

                        if (!new FileInfo(resolvedTemplatePath).Exists)
                       {
                           throw new FileNotFoundException(string.Format("Add here the path"));
                       }

                       if (!new FileInfo(resolvedParameterPath).Exists)
                       {
                           throw new FileNotFoundException(string.Format("Add here the path"));
                       }

                        var templateArtifact = new TemplateArtifact
                       {
                           DisplayName = Name,
                           Description = Description,
                           ResourceGroup = ResourceGroup,
                           Parameters = new Dictionary<string, ParameterValueBase>(),
                           Template = File.ReadAllText(resolvedTemplatePath),
                           DependsOn = null // To-Do: do we need anything here for dependson? Add a new param for the cmdlet?
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
