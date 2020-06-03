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

using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Management.ResourceManager.Version2019_06_01.Models.Utilities
{
    public static class TenantIdDescriptionExtensions
    {
        public static AzureTenant ToAzureTenant(this TenantIdDescription other, IAccessToken accessToken)
        {
            var tenant = new AzureTenant() { Id = other.TenantId };
            tenant.SetProperty(AzureTenant.Property.Directory, accessToken?.GetDomain());

            if (!string.IsNullOrEmpty(other.DisplayName))
            {
                tenant.SetOrAppendProperty(AzureTenant.Property.DisplayName, other.DisplayName);
            }

            if (null != other.TenantCategory)
            {
                tenant.SetOrAppendProperty(AzureTenant.Property.TenantCategory, other.TenantCategory?.ToSerializedValue());
            }

            if (other.Domains != null && other.Domains.Any())
            {
                tenant.SetOrAppendProperty(AzureTenant.Property.Domains, other.Domains.ToArray());
            }

            if (!string.IsNullOrEmpty(other.CountryCode))
            {
                tenant.SetOrAppendProperty(AzureTenant.Property.CountryCode, other.CountryCode);

            }
            return tenant;
        }
    }
}
