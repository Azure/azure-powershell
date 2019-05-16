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
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PSRegistrationAssignmentProperties
    {
        public string RegistrationDefinitionId { get; set; }

        public ProvisioningState? ProvisioningState { get; }

        public PSRegistrationAssignmentPropertiesRegistrationDefinition RegistrationDefinition { get; }

        public PSRegistrationAssignmentProperties(RegistrationAssignmentProperties registrationAssignmentProperties)
        {
           this.RegistrationDefinitionId = registrationAssignmentProperties.RegistrationDefinitionId;
            this.ProvisioningState = registrationAssignmentProperties.ProvisioningState;
            this.RegistrationDefinition = new PSRegistrationAssignmentPropertiesRegistrationDefinition(registrationAssignmentProperties.RegistrationDefinition);
        }
    }
}
