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

using Microsoft.Azure.Management.ManagedServices.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models
{
    public class PSRegistrationAssignmentPropertiesRegistrationDefinition
    {        
        public PSRegistrationAssignmentPropertiesRegistrationDefinitionProperties Properties { get; set; }

        public Plan Plan { get; set; }

        public string Id { get; }

        public string Type { get; }

        public string Name { get; }

        public PSRegistrationAssignmentPropertiesRegistrationDefinition(RegistrationAssignmentPropertiesRegistrationDefinition registrationDefinition)
        {
            if (registrationDefinition != null)
            {
                this.Plan = registrationDefinition.Plan;
                this.Id = registrationDefinition.Id;
                this.Type = registrationDefinition.Type;
                this.Name = registrationDefinition.Name;
                this.Properties = new PSRegistrationAssignmentPropertiesRegistrationDefinitionProperties(registrationDefinition.Properties);
            }
        }
    }
}