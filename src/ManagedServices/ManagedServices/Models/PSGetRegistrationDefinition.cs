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
    using Microsoft.Azure.Management.ManagedServices.Models;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSGetRegistrationDefinition : PSRegistrationDefinition
    {
        [Ps1Xml(Label = "Scope", Target = ViewControl.Table, Position = 4)]
        public string Scope { get; set; }

        public PSGetRegistrationDefinition(RegistrationDefinition registrationDefinition, string scope) : base(registrationDefinition)
        {
            if (registrationDefinition != null)
            {
                this.Id = registrationDefinition.Id;

                this.Name = registrationDefinition.Name;
                this.Type = registrationDefinition.Type;
                this.Plan = new PSPlan(registrationDefinition.Plan);
                this.Properties = new PSRegistrationDefinitionProperties(registrationDefinition.Properties);
                this.Scope = scope;
            }
        }

    }
}
