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
using System.Text;

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

        public static PSADObject ToPSADObject(this DirectoryObject obj)
        {
            if (obj == null) throw new ArgumentNullException();

            if(obj is User user)
            {
                return new PSADUser()
                {
                    DisplayName = user.DisplayName,
                    Id = user.ObjectId,
                    DeletionTimestamp = user.DeletionTimestamp,
                    UserPrincipalName = user.UserPrincipalName,
                    AccountEnabled = user.AccountEnabled,
                    GivenName = user.GivenName,
                    Mail = user.Mail,
                    MailNickname = user.MailNickname,
                    Surname = user.Surname,
                    UsageLocation = user.UsageLocation,
                    Type = "User"
                };
            }
            else if(obj is ADGroup group)
            {
                return new PSADGroup()
                {
                    DisplayName = group.DisplayName,
                    Id = group.ObjectId,
                    Type = "Group",
                    DeletionTimestamp = group.DeletionTimestamp,
                    SecurityEnabled = group.SecurityEnabled,
                    MailEnabled = group.MailEnabled,
                    MailNickname = !string.IsNullOrEmpty(group.Mail) ? group.Mail :
                        !string.IsNullOrEmpty(group.MailNickname) ? group.MailNickname :
                        group.AdditionalProperties.ContainsKey("mailNickname") ? group.AdditionalProperties["mailNickname"]?.ToString() : null,
                    Description = group.AdditionalProperties.ContainsKey("description") ? group.AdditionalProperties["description"]?.ToString() : null
                };
            }
            else if(obj is ServicePrincipal sp)
            {
                return new PSADServicePrincipal()
                {
                    DisplayName = sp.DisplayName,
                    Id = sp.ObjectId,
                    Type = "ServicePrincipal",
                    ServicePrincipalNames = sp.ServicePrincipalNames.ToArray()
                };
            }
            else
            {
                return new PSADObject()
                {
                    Id = obj.ObjectId,
                    DeletionTimestamp = obj.DeletionTimestamp
                };
            }
        }

        public static PSADObject ToPSADGroup(this DirectoryObject obj)
        {
            return new PSADObject()
            {
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
                Mail = user.Mail,
                ImmutableId = user.ImmutableId,
                AdditionalProperties = user.AdditionalProperties
            };
        }

        public static PSADGroup ToPSADGroup(this ADGroup group)
        {
            return new PSADGroup()
            {
                DisplayName = group.DisplayName,
                Id = group.ObjectId,
                DeletionTimestamp = group.DeletionTimestamp,
                SecurityEnabled = group.SecurityEnabled,
                MailNickname =  !string.IsNullOrEmpty(group.Mail) ? group.Mail : group.AdditionalProperties.ContainsKey("mailNickname") ? group.AdditionalProperties["mailNickname"]?.ToString() : null,
                Description = group.AdditionalProperties.ContainsKey("description") ? group.AdditionalProperties["description"]?.ToString() : null,
                MailEnabled = group.MailEnabled,
                AdditionalProperties = group.AdditionalProperties
            };
        }

        public static PSADServicePrincipal ToPSADServicePrincipal(this ServicePrincipal servicePrincipal)
        {
            return new PSADServicePrincipal()
            {
                DisplayName = servicePrincipal.DisplayName,
                Id = servicePrincipal.ObjectId,
                DeletionTimestamp = servicePrincipal.DeletionTimestamp,
                ApplicationId = Guid.Parse(servicePrincipal.AppId),
                Type = "ServicePrincipal",
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
                    DeletionTimestamp = application.DeletionTimestamp,
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
                Type = credential.Type,
                Usage = credential.Usage,
                CustomKeyIdentifier = credential.CustomKeyIdentifier
            };
        }

        public static PSADCredential ToPSADCredential(this PasswordCredential credential)
        {
            PSADCredential ret = new PSADCredential
            {
                KeyId = credential.KeyId,
                StartDate = credential.StartDate == null ? string.Empty : credential.StartDate.ToString(),
                EndDate = credential.EndDate == null ? string.Empty : credential.EndDate.ToString(),
                Type = "Password"
            };

            if(credential.CustomKeyIdentifier != null && credential.CustomKeyIdentifier.Length > 0)
            {
                try
                {
                    ret.CustomKeyIdentifier = Encoding.UTF8.GetString(credential.CustomKeyIdentifier);
                }
                catch
                {
                    // Ignore this property if service response cannot be converted to string
                }
            }

            return ret;
        }
    }
}
