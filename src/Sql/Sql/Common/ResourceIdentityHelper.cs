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
    public enum ResourceIdentityType
    {
        SystemAssigned,
        SystemAssignedUserAssigned,
        UserAssigned,
        None
    }

    public class ResourceIdentityHelper
    {
        public static Management.Sql.Models.ResourceIdentity GetIdentityObjectFromType(bool assignIdentityIsPresent, string resourceIdentityType, List<string> userAssignedIdentities, Management.Sql.Models.ResourceIdentity existingResourceIdentity)
        {
            Management.Sql.Models.ResourceIdentity identityResult = null;

            // If the user passes in IdentityType as None, then irrespective of previous config, we set the IdentityType to be None.
            //
            if (resourceIdentityType != null && resourceIdentityType.Equals(ResourceIdentityType.None.ToString()))
            {
                identityResult = new Management.Sql.Models.ResourceIdentity()
                {
                    Type = ResourceIdentityType.None.ToString()
                };

                return identityResult;
            }

            if (resourceIdentityType != null && assignIdentityIsPresent && resourceIdentityType.Equals(ResourceIdentityType.SystemAssignedUserAssigned.ToString()))
            {
                Dictionary<string, UserIdentity> umiDict = new Dictionary<string, UserIdentity>();

                if (userAssignedIdentities == null)
                {
                    throw new PSArgumentNullException("The list of user assigned identity ids needs to be passed if the IdentityType is UserAssigned or SystemAssignedUserAssigned");
                }

                if (existingResourceIdentity != null && userAssignedIdentities.Any()
                    && existingResourceIdentity.UserAssignedIdentities != null)
                {
                    foreach (string identity in userAssignedIdentities)
                    {
                        existingResourceIdentity.UserAssignedIdentities.Add(identity, new UserIdentity());
                    }

                    identityResult = new Management.Sql.Models.ResourceIdentity()
                    {
                        Type = "SystemAssigned,UserAssigned"
                    };
                }
                else if (userAssignedIdentities.Any())
                {
                    foreach (string identity in userAssignedIdentities)
                    {
                        umiDict.Add(identity, new UserIdentity());
                    }

                    identityResult = new Management.Sql.Models.ResourceIdentity()
                    {
                        Type = "SystemAssigned,UserAssigned",
                        UserAssignedIdentities = umiDict
                    };
                }
            }
            else if (resourceIdentityType != null && assignIdentityIsPresent && resourceIdentityType.Equals(ResourceIdentityType.UserAssigned.ToString()))
            {
                Dictionary<string, UserIdentity> umiDict = new Dictionary<string, UserIdentity>();

                if (userAssignedIdentities == null)
                {
                    throw new PSArgumentNullException("The list of user assigned identity ids needs to be passed if the IdentityType is UserAssigned or SystemAssignedUserAssigned");
                }

                if (existingResourceIdentity != null && userAssignedIdentities.Any()
                    && existingResourceIdentity.UserAssignedIdentities != null)
                {
                    foreach (string identity in userAssignedIdentities)
                    {
                        existingResourceIdentity.UserAssignedIdentities.Add(identity, new UserIdentity());
                    }

                    identityResult = new Management.Sql.Models.ResourceIdentity()
                    {
                        Type = ResourceIdentityType.UserAssigned.ToString()
                    };
                }
                else if (userAssignedIdentities.Any())
                {
                    foreach (string identity in userAssignedIdentities)
                    {
                        umiDict.Add(identity, new UserIdentity());
                    }

                    identityResult = new Management.Sql.Models.ResourceIdentity()
                    {
                        Type = ResourceIdentityType.UserAssigned.ToString(),
                        UserAssignedIdentities = umiDict
                    };
                }
            }
            else if (assignIdentityIsPresent)
            {
                if (existingResourceIdentity != null)
                {
                    identityResult = existingResourceIdentity;
                    identityResult.Type = ResourceIdentityType.SystemAssigned.ToString();
                }
                else
                {
                    identityResult = new Management.Sql.Models.ResourceIdentity()
                    {
                        Type = ResourceIdentityType.SystemAssigned.ToString()
                    };
                }       
            }
            
            if (!assignIdentityIsPresent && existingResourceIdentity != null && existingResourceIdentity.PrincipalId != null)
            {
                identityResult = existingResourceIdentity;
            }

            return identityResult;

        }
    }
}
