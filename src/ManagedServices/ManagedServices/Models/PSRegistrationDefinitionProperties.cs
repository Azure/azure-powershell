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
<<<<<<< HEAD
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    using System.Collections.Generic;

    public class PSRegistrationDefinitionProperties
    {
        public string Description { get; set; }

<<<<<<< HEAD
        public string Name { get; set; }
=======
        public string DisplayName { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        public string ManagedByTenantId { get; set; }

        public string ProvisioningState { get; }

        public string ManagedByTenantName { get; }

        public IList<PSAuthorization> Authorization { get; set; }

        public PSRegistrationDefinitionProperties(RegistrationDefinitionProperties registrationDefinitionProperties)
        {
            this.Description = registrationDefinitionProperties.Description;
<<<<<<< HEAD
            this.Name = registrationDefinitionProperties.RegistrationDefinitionName;
=======
            this.DisplayName = registrationDefinitionProperties.RegistrationDefinitionName;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            this.ManagedByTenantId = registrationDefinitionProperties.ManagedByTenantId;
            this.ManagedByTenantName = registrationDefinitionProperties.ManagedByTenantName;
            this.ProvisioningState = registrationDefinitionProperties.ProvisioningState;

            this.Authorization = new List<PSAuthorization>();
            foreach (var authorization in registrationDefinitionProperties.Authorizations)
            {
                this.Authorization.Add(new PSAuthorization(authorization));
            }
        }
    }
}