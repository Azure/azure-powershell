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

using Microsoft.Azure.Graph.RBAC.Models;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    internal static class ActiveDirectoryClientExtensions
    {
        public static PSADObject ToPSADObject(this User user)
        {
            return new PSADObject()
            {
                DisplayName = user.DisplayName,
                Id = user.ObjectId
            };
        }

        public static PSADObject ToPSADObject(this ADGroup group)
        {
            return new PSADObject()
            {
                DisplayName = group.DisplayName,
                Id = group.ObjectId
            };
        }

        public static PSADObject ToPSADObject(this AADObject obj)
        {
            if (obj == null) throw new ArgumentNullException();

            if (obj.ObjectType == typeof(User).Name)
            {
                return new PSADUser()
                {
                    DisplayName = obj.DisplayName,
                    Id = obj.ObjectId,
                    Type = obj.ObjectType,
                    UserPrincipalName = obj.UserPrincipalName
                };
            }
            else if (obj.ObjectType == "Group")
            {
                return new PSADGroup()
                {
                    DisplayName = obj.DisplayName,
                    Id = obj.ObjectId,
                    Type = obj.ObjectType,
                    SecurityEnabled = obj.SecurityEnabled,
                    MailNickname = !string.IsNullOrEmpty(obj.Mail) ? obj.Mail :
                        !string.IsNullOrEmpty(obj.MailNickname) ? obj.MailNickname :
                        obj.AdditionalProperties.ContainsKey("mailNickname") ? obj.AdditionalProperties["mailNickname"]?.ToString() : null,
                    Description = obj.AdditionalProperties.ContainsKey("description") ? obj.AdditionalProperties["description"]?.ToString() : null
                };
            }
            else if (obj.ObjectType == typeof(ServicePrincipal).Name)
            {
                return new PSADServicePrincipal()
                {
                    DisplayName = obj.DisplayName,
                    Id = obj.ObjectId,
                    Type = obj.ObjectType,
                    ServicePrincipalNames = obj.ServicePrincipalNames.ToArray()
                };
            }
            else
            {
                return new PSADObject()
                {
                    DisplayName = obj.DisplayName,
                    Id = obj.ObjectId,
                    Type = obj.ObjectType
                };
            }
        }

        public static PSADObject ToPSADGroup(this AADObject obj)
        {
            return new PSADObject()
            {
                DisplayName = obj.DisplayName,
                Id = obj.ObjectId
            };
        }

        public static PSADUser ToPSADUser(this User user)
        {
            return new PSADUser()
            {
                DisplayName = user.DisplayName,
                Id = user.ObjectId,
                UserPrincipalName = user.UserPrincipalName,
                Type = user.UserType,
                UsageLocation = user.UsageLocation,
                GivenName = user.GivenName,
                Surname = user.Surname,
                AccountEnabled = user.AccountEnabled,
                MailNickname = user.MailNickname,
                Mail = user.Mail
            };
        }

        public static PSADGroup ToPSADGroup(this ADGroup group)
        {
            return new PSADGroup()
            {
                DisplayName = group.DisplayName,
                Id = group.ObjectId,
                SecurityEnabled = group.SecurityEnabled,
                MailNickname =  !string.IsNullOrEmpty(group.Mail) ? group.Mail : group.AdditionalProperties.ContainsKey("mailNickname") ? group.AdditionalProperties["mailNickname"]?.ToString() : null,
                Description = group.AdditionalProperties.ContainsKey("description") ? group.AdditionalProperties["description"]?.ToString() : null
            };
        }

        public static PSADServicePrincipal ToPSADServicePrincipal(this ServicePrincipal servicePrincipal)
        {
            return new PSADServicePrincipal()
            {
                DisplayName = servicePrincipal.DisplayName,
                Id = servicePrincipal.ObjectId,
                ApplicationId = Guid.Parse(servicePrincipal.AppId),
                ServicePrincipalNames = servicePrincipal.ServicePrincipalNames.ToArray()
            };
        }

        public static PSADApplication ToPSADApplication(this Application application)
        {
            if (application != null)
            {
                return new PSADApplication()
                {
                    ObjectId = application.ObjectId,
                    DisplayName = application.DisplayName,
                    ApplicationId = Guid.Parse(application.AppId),
                    IdentifierUris = application.IdentifierUris,
                    HomePage = application.Homepage,
                    ReplyUrls = application.ReplyUrls,
                    AppPermissions = application.AppPermissions,
                    AvailableToOtherTenants = application.AvailableToOtherTenants ?? false
                };
            }
            else
            {
                return null;
            }
        }

        public static KeyCredential ToGraphKeyCredential(this PSADKeyCredential PSKeyCredential)
        {
            return new KeyCredential
            {
                StartDate = PSKeyCredential.StartDate,
                EndDate = PSKeyCredential.EndDate,
                KeyId = PSKeyCredential.KeyId.ToString(),
                Value = PSKeyCredential.CertValue,
                Type = "AsymmetricX509Cert",
                Usage = "Verify"
            };
        }

        public static PasswordCredential ToGraphPasswordCredential(this PSADPasswordCredential PSPasswordCredential)
        {
            return new PasswordCredential
            {
                StartDate = PSPasswordCredential.StartDate,
                EndDate = PSPasswordCredential.EndDate,
                KeyId = PSPasswordCredential.KeyId.ToString(),
                Value = PSPasswordCredential.Password
            };
        }

        public static PSADCredential ToPSADCredential(this KeyCredential credential)
        {
            return new PSADCredential
            {
                KeyId = credential.KeyId,
                StartDate = credential.StartDate == null ? string.Empty : credential.StartDate.ToString(),
                EndDate = credential.EndDate == null ? string.Empty : credential.EndDate.ToString(),
                Type = credential.Type
            };
        }

        public static PSADCredential ToPSADCredential(this PasswordCredential credential)
        {
            return new PSADCredential
            {
                KeyId = credential.KeyId,
                StartDate = credential.StartDate == null ? string.Empty : credential.StartDate.ToString(),
                EndDate = credential.EndDate == null ? string.Empty : credential.EndDate.ToString(),
                Type = "Password"
            };
        }
    }
}
