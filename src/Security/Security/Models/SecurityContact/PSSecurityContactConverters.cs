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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Models.SecurityContacts
{
    public static class PSSecurityTaskConverters
    {
        public static PSSecurityContact ConvertToPSType(this SecurityContact value)
        {
            return new PSSecurityContact()
            {
                Id = value.Id,
                Name = value.Name,
                Email = value.Email,
                Phone = value.Phone,
                AlertNotifications = value.AlertNotifications,
                AlertsToAdmins = value.AlertsToAdmins
            };
        }

        public static List<PSSecurityContact> ConvertToPSType(this IEnumerable<SecurityContact> value)
        {
            return value.Select(sc => sc.ConvertToPSType()).ToList();
        }
    }
}
