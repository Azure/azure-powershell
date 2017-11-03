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

using System;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    public static class AzureTenantExtensions
    {
        /// <summary>
        /// Get the tenant Id as a Guid
        /// </summary>
        /// <param name="tenant">The tenant to check</param>
        /// <returns>The tenant ID as a Guid</returns>
        public static Guid GetId(this IAzureTenant tenant)
        {
            return tenant.Id == null? Guid.Empty: new Guid(tenant.Id);
        }

        /// <summary>
        /// Copy tenaht properties from another tenant
        /// </summary>
        /// <param name="tenant"></param>
        /// <param name="other"></param>
        public static void CopyFrom(this IAzureTenant tenant, IAzureTenant other)
        {
            if (tenant != null && other != null)
            {
                tenant.Id = other.Id;
                tenant.Directory = other.Directory;
                tenant.CopyPropertiesFrom(other);
            }
        }

        /// <summary>
        /// Update the non-identity properties of this tenant, using another tenant
        /// </summary>
        /// <param name="tenant"></param>
        /// <param name="other"></param>
        public static void Update(this IAzureTenant tenant, IAzureTenant other)
        {
            if (tenant != null && other != null)
            {
                tenant.Directory = other.Directory?? tenant.Directory;
                tenant.UpdateProperties(other);
            }
        }
    }
}
