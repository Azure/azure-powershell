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

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models
{
    using System;
    using Microsoft.Azure.Management.ManagedServices.Models;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSRegistrationDefinition
    {
        [Ps1Xml(Label = "ManagedByTenantId", Target = ViewControl.Table, ScriptBlock = "$_.Properties.ManagedByTenantId", Position = 1)]
        [Ps1Xml(Label = "PrincipalId", Target = ViewControl.Table, ScriptBlock = "$_.Properties.Authorization.PrincipalId", Position = 2)]
        [Ps1Xml(Label = "RoleDefinitionId", Target = ViewControl.Table, ScriptBlock = "$_.Properties.Authorization.RoleDefinitionId", Position = 3)]
        public PSRegistrationDefinitionProperties Properties { get; set; }

        public PSPlan Plan { get; set; }

        public string Id { get; set; }

        public string Type { get; set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 0)]
        public string Name { get; set; }

        public PSRegistrationDefinition(RegistrationDefinition registrationDefinition)
        {
            if (registrationDefinition != null)
            {
                this.Id = registrationDefinition.Id;

                this.Name = registrationDefinition.Name;
                this.Type = registrationDefinition.Type;
                this.Plan = new PSPlan(registrationDefinition.Plan);
                this.Properties = new PSRegistrationDefinitionProperties(registrationDefinition.Properties);
            }

        }
    }
}
