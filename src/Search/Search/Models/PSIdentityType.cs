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

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public enum PSIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        UserAssigned = 2,
        SystemAssignedUserAssigned = 3,
    }

    internal static class PSIdentityTypeEnumExtension
    {
        internal static PSIdentityType? ParsePSIdentityType(this string value)
        {
            switch (value)
            {
                case "None":
                    return PSIdentityType.None;
                case "SystemAssigned":
                    return PSIdentityType.SystemAssigned;
                case "UserAssigned":
                    return PSIdentityType.UserAssigned;
                case "SystemAssigned, UserAssigned":
                    return PSIdentityType.SystemAssignedUserAssigned;
            }
            return null;
        }

        internal static string ToString(this PSIdentityType value)
        {
            switch (value)
            {
                case PSIdentityType.None:
                    return "None";
                case PSIdentityType.SystemAssigned:
                    return "SystemAssigned";
                case PSIdentityType.UserAssigned:
                    return "UserAssigned";
                case PSIdentityType.SystemAssignedUserAssigned:
                    return "SystemAssigned, UserAssigned";
            }
            return null;
        }
    }
}
