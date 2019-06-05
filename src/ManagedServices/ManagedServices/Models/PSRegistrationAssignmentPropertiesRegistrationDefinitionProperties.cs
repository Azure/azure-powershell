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
using System.Collections.Generic;

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models
{
    public class PSRegistrationAssignmentPropertiesRegistrationDefinitionProperties
    {
        public string Description { get; set; }

        public string RegistrationDefinitionName { get; set; }

        public string ManageeTenantId { get; set; }

        public string ManageeTenantName { get; set; }

        public string ManagedByTenantId { get; set; }

        public string ManagedByTenantName { get; set; }

        public IList<PSAuthorization> Authorization { get; set; }

        public PSRegistrationAssignmentPropertiesRegistrationDefinitionProperties(RegistrationAssignmentPropertiesRegistrationDefinitionProperties properties)
        {
            this.Description = properties.Description;
            this.RegistrationDefinitionName = properties.RegistrationDefinitionName;
            this.ManagedByTenantId = properties.ManagedByTenantId;
            this.ManagedByTenantName = properties.ManagedByTenantName;
            this.ManageeTenantId = properties.ManageeTenantId;
            this.ManageeTenantName = properties.ManageeTenantName;

            this.Authorization = new List<PSAuthorization>();
            foreach (var authorization in properties.Authorizations)
            {
                Authorization.Add(new PSAuthorization(authorization));
            }
        }
    }
}