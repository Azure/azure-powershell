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

using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Groups.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users.Models;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    internal static class ActiveDirectoryClientExtensions
    {
        public static PSADObject ToPSADObject(this Common.MSGraph.Version1_0.DirectoryObjects.Models.MicrosoftGraphDirectoryObject obj)
        {
            if (obj == null) throw new ArgumentNullException();

            if (obj.IsUser())
            {
                return JsonConvert.DeserializeObject<MicrosoftGraphUser>(JsonConvert.SerializeObject(obj)).ToPSADUser();
            }
            if (obj.IsServicePrincipal())
            {
                return JsonConvert.DeserializeObject<MicrosoftGraphServicePrincipal>(JsonConvert.SerializeObject(obj)).ToPSADServicePrincipal();
            }
            if (obj.IsGroup())
            {
                return JsonConvert.DeserializeObject<MicrosoftGraphGroup>(JsonConvert.SerializeObject(obj)).ToPSADGroup();
            }

            return new PSADObject()
            {
                Id = obj.Id,
                DeletionTimestamp = obj.DeletedDateTime
            };
        }

        public static bool IsUser(this Common.MSGraph.Version1_0.DirectoryObjects.Models.MicrosoftGraphDirectoryObject obj)
        {
            return string.Equals(obj.Odatatype, "#microsoft.graph.user", StringComparison.OrdinalIgnoreCase);
        }
        public static bool IsServicePrincipal(this Common.MSGraph.Version1_0.DirectoryObjects.Models.MicrosoftGraphDirectoryObject obj)
        {
            return string.Equals(obj.Odatatype, "#microsoft.graph.servicePrincipal", StringComparison.OrdinalIgnoreCase);
        }
        public static bool IsGroup(this Common.MSGraph.Version1_0.DirectoryObjects.Models.MicrosoftGraphDirectoryObject obj)
        {
            return string.Equals(obj.Odatatype, "#microsoft.graph.group", StringComparison.OrdinalIgnoreCase);
        }

        public static PSADUser ToPSADUser(this MicrosoftGraphUser user)
        {
            return new PSADUser()
            {
                DisplayName = user.DisplayName,
                Id = user.Id,
                DeletionTimestamp = user.DeletedDateTime,
                UserPrincipalName = user.UserPrincipalName,
                Type = user.UserType ?? "User",
                UsageLocation = user.UsageLocation,
                GivenName = user.GivenName,
                Surname = user.Surname,
                AccountEnabled = user.AccountEnabled,
                MailNickname = user.MailNickname,
                Mail = user.Mail,
                ImmutableId = user.OnPremisesImmutableId,
                AdditionalProperties = user.AdditionalProperties
            };
        }

        public static PSADGroup ToPSADGroup(this MicrosoftGraphGroup group)
        {
            return new PSADGroup()
            {
                DisplayName = group.DisplayName,
                Id = group.Id,
                DeletionTimestamp = group.DeletedDateTime,
                Type = "Group",
                SecurityEnabled = group.SecurityEnabled,
                MailNickname = !string.IsNullOrEmpty(group.Mail) ? group.Mail : group.AdditionalProperties.ContainsKey("mailNickname") ? group.AdditionalProperties["mailNickname"]?.ToString() : null,
                Description = group.AdditionalProperties.ContainsKey("description") ? group.AdditionalProperties["description"]?.ToString() : null,
                MailEnabled = group.MailEnabled,
                AdditionalProperties = group.AdditionalProperties
            };
        }

        public static PSADServicePrincipal ToPSADServicePrincipal(this MicrosoftGraphServicePrincipal servicePrincipal)
        {
            return new PSADServicePrincipal()
            {
                DisplayName = servicePrincipal.DisplayName,
                Id = servicePrincipal.Id,
                DeletionTimestamp = servicePrincipal.DeletedDateTime,
                ApplicationId = String.IsNullOrEmpty(servicePrincipal.AppId)? (Guid?)null : Guid.Parse(servicePrincipal.AppId),
                Type = "ServicePrincipal",
                ServicePrincipalNames = servicePrincipal.ServicePrincipalNames.ToArray(),
                AdditionalProperties = servicePrincipal.AdditionalProperties
            };
        }
    }
}
