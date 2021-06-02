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
using System.Runtime.CompilerServices;

namespace Microsoft.Azure.Commands.Sql.Common
{
    public enum ResourceIdentityType
    {
        SystemAssigned,
        UserAssigned,
        None
    }

    public class ResourceIdentityHelper
    {       
        public static Management.Sql.Models.ResourceIdentity GetIdentityObjectFromType(string AssignIdentity, List<string> userAssignedIdentities)
        {
            Management.Sql.Models.ResourceIdentity identityResult = null;
            
            if (AssignIdentity.Equals(ResourceIdentityType.SystemAssigned))
            {
                identityResult = new Management.Sql.Models.ResourceIdentity()
                {
                    Type = ResourceIdentityType.SystemAssigned.ToString()
                };
            }

            if (AssignIdentity.Equals(ResourceIdentityType.UserAssigned) && userAssignedIdentities.Any())
            {
                Dictionary<string, UserIdentity> umiDict = new Dictionary<string, UserIdentity>();
                
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

            return identityResult;
        }

        public static Management.Sql.Models.ResourceIdentity GetIdentityObjectFromType(bool assignIdentityIsPresent, bool userAssignedIdentityIsPresent, List<string> userAssignedIdentities)
        {
            Management.Sql.Models.ResourceIdentity identityResult = null;

            if (assignIdentityIsPresent && userAssignedIdentityIsPresent)
            {
                Dictionary<string, UserIdentity> umiDict = new Dictionary<string, UserIdentity>();

                if (userAssignedIdentities != null && userAssignedIdentities.Any())
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
                else
                {
                    identityResult = new Management.Sql.Models.ResourceIdentity()
                    {
                        Type = ResourceIdentityType.SystemAssigned.ToString()
                    };
                }    
            }
            else if (assignIdentityIsPresent)
            {
                identityResult = new Management.Sql.Models.ResourceIdentity()
                {
                    Type = ResourceIdentityType.SystemAssigned.ToString()
                };
            }

            return identityResult;
        }
    }
}
