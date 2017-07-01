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

using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Get the available role Definitions for certain resource types.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRoleDefinition"), OutputType(typeof(List<PSRoleDefinition>))]
    public class GetAzureRoleDefinitionCommand : ResourcesBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleDefinitionName, HelpMessage = "Role definition name. For e.g. Reader, Contributor, Virtual Machine Contributor.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleDefinitionId, HelpMessage = "Role definition id.")]
        [ValidateGuidNotEmpty]
        public Guid Id { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ParameterSet.RoleDefinitionName, HelpMessage = "Scope of the existing role definition.")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ParameterSet.RoleDefinitionId, HelpMessage = "Scope of the existing role definition.")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = ParameterSet.RoleDefinitionCustom, HelpMessage = "Scope of the existing role definition.")]
        public string Scope { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleDefinitionCustom,
            HelpMessage = "If specified, only displays the custom created roles in the directory.")]
        public SwitchParameter Custom { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleDefinitionName, HelpMessage = "If specified, displays the the roles at and below scope.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleDefinitionCustom, HelpMessage = "If specified, displays the the roles at and below scope.")]
        public SwitchParameter AtScopeAndBelow { get; set; }

        public override void ExecuteCmdlet()
        {
            FilterRoleDefinitionOptions options = new FilterRoleDefinitionOptions
            {
                CustomOnly = Custom.IsPresent ? true : false,
                ScopeAndBelow = AtScopeAndBelow.IsPresent ? true : false,
                Scope = Scope,
                ResourceIdentifier = new ResourceIdentifier
                {
                    Subscription = DefaultProfile.DefaultContext.Subscription.Id.ToString()
                },
                RoleDefinitionId = Id,
                RoleDefinitionName = Name,
            };

            AuthorizationClient.ValidateScope(options.Scope, true);

            WriteObject(PoliciesClient.FilterRoleDefinitions(options), enumerateCollection: true);
        }
    }
}