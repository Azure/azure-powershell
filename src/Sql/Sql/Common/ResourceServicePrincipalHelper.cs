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

using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.Sql.Common
{
    public enum ResourceServicePrincipalType
    {
        SystemAssigned,
        None
    }

    public class ResourceServicePrincipalHelper
    {
        public static ServicePrincipal GetServicePrincipalObjectFromType(string resourceServicePrincipalType)
        {
            ServicePrincipal servicePrincipalResult = null;

            if (resourceServicePrincipalType != null && resourceServicePrincipalType.Equals(ResourceServicePrincipalType.None.ToString()))
            {
                servicePrincipalResult = new ServicePrincipal()
                {
                    Type = ResourceIdentityType.None.ToString()
                };
            }
            else if (resourceServicePrincipalType != null && resourceServicePrincipalType.Equals(ResourceServicePrincipalType.SystemAssigned.ToString()))
            {
                servicePrincipalResult = new ServicePrincipal()
                {
                    Type = ResourceIdentityType.SystemAssigned.ToString()
                };
            }

            return servicePrincipalResult;
        }

        public static Management.Sql.Models.ServicePrincipal UnwrapServicePrincipalObject(ServicePrincipal servicePrincipal)
        {
            if (servicePrincipal == null)
                return null;

            return new Management.Sql.Models.ServicePrincipal(
                servicePrincipal.PrincipalId,
                servicePrincipal.ClientId,
                servicePrincipal.TenantId,
                servicePrincipal.Type);
        }

        public static ServicePrincipal WrapServicePrincipalObject(Management.Sql.Models.ServicePrincipal servicePrincipal)
        {
            if (servicePrincipal == null)
                return null;

            return new ServicePrincipal(
                servicePrincipal.PrincipalId,
                servicePrincipal.ClientId,
                servicePrincipal.TenantId,
                servicePrincipal.Type);
        }
    }
}
