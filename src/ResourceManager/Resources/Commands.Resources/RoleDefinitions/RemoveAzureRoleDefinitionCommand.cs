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

using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Deletes a given role definition.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmRoleDefinition"), OutputType(typeof(bool))]
    public class RemoveAzureRoleDefinitionCommand : ResourcesBaseCmdlet
    {
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Role definition id.")]
        public string Id { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            PSRoleDefinition roleDefinition = null;

            ConfirmAction(
                Force.IsPresent,
                string.Format(ProjectResources.RemoveRoleDefinition, Id),
                ProjectResources.RemoveRoleDefinition,
                Id,
                () => roleDefinition = PoliciesClient.RemoveRoleDefinition(Id));

            if (PassThru)
            {
                WriteObject(roleDefinition);
            }
        }
    }
}
