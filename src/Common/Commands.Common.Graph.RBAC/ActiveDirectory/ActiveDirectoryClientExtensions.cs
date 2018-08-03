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

using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using System;
using System.Linq;

namespace Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory
{
    internal static class ActiveDirectoryClientExtensions
    {
        public static PSADObject ToPSADObject(this User user)
        {
            var adObj = new PSADObject() { DisplayName = user.DisplayName };
            return AssignObjectId(adObj, user.ObjectId);
        }

        public static PSADObject ToPSADObject(this ADGroup group)
        {
            var adObj = new PSADObject() { DisplayName = group.DisplayName };
            return AssignObjectId(adObj, group.ObjectId);
        }

        public static PSADObject AssignObjectId(PSADObject adObj, string objectId)
        {
            Guid objectIdGuid;

            if (Guid.TryParse(objectId, out objectIdGuid))
            {
                adObj.Id = objectIdGuid;
            }
            else
            {
                adObj.AdfsId = objectId;
            }

            return adObj;
        }

        public static PSADObject ToPSADObject(this AADObject obj)
        {
            if (obj == null) throw new ArgumentNullException();

            if (obj.ObjectType == typeof(User).Name)
            {
                var adUser = new PSADUser()
                {
                    DisplayName = obj.DisplayName,
                    Type = obj.ObjectType,
                    UserPrincipalName = obj.UserPrincipalName
                };

                return AssignObjectId(adUser, obj.ObjectId);
            }
            else if (obj.ObjectType == "Group")
            {
                var adGroup = new PSADGroup()
                {
                    DisplayName = obj.DisplayName,
                    Type = obj.ObjectType,
                    SecurityEnabled = obj.SecurityEnabled,
                    MailNickname = obj.Mail
                };
                return AssignObjectId(adGroup, obj.ObjectId);
            }
            else if (obj.ObjectType == typeof(ServicePrincipal).Name)
            {
                var adSp = new PSADServicePrincipal()
                {
                    DisplayName = obj.DisplayName,
                    Type = obj.ObjectType,
                    ServicePrincipalNames = obj.ServicePrincipalNames.ToArray()
                };

                return AssignObjectId(adSp, obj.ObjectId);
            }
            else
            {
                var adObj = new PSADObject()
                {
                    DisplayName = obj.DisplayName,
                    Type = obj.ObjectType
                };

                return AssignObjectId(adObj, obj.ObjectId);
            }
        }

        public static PSADObject ToPSADGroup(this AADObject obj)
        {
            var adObj = new PSADObject()
            {
                DisplayName = obj.DisplayName,
            };

            return AssignObjectId(adObj, obj.ObjectId);
        }

        public static PSADUser ToPSADUser(this User user)
        {
            var adUser = new PSADUser()
            {
                DisplayName = user.DisplayName,
                UserPrincipalName = user.UserPrincipalName,
                Type = user.ObjectType
            };

            return (PSADUser) AssignObjectId(adUser, user.ObjectId);
        }

        public static PSADGroup ToPSADGroup(this ADGroup group)
        {
            var adGroup = new PSADGroup()
            {
                DisplayName = group.DisplayName,
                SecurityEnabled = group.SecurityEnabled,
                Type = group.ObjectType,
                MailNickname = group.Mail
            };

            return (PSADGroup) AssignObjectId(adGroup, group.ObjectId);
        }

        public static PSADServicePrincipal ToPSADServicePrincipal(this ServicePrincipal servicePrincipal)
        {
            var adSp = new PSADServicePrincipal()
            {
                DisplayName = servicePrincipal.DisplayName,
                ApplicationId = Guid.Parse(servicePrincipal.AppId),
                ServicePrincipalNames = servicePrincipal.ServicePrincipalNames.ToArray(),
                Type = servicePrincipal.ObjectType
            };

            return (PSADServicePrincipal) AssignObjectId(adSp, servicePrincipal.ObjectId);
        }

        public static PSADApplication ToPSADApplication(this Application application)
        {
            if (application != null)
            {
                return new PSADApplication()
                {
                    ObjectId = Guid.Parse(application.ObjectId),
                    DisplayName = application.DisplayName,
                    Type = application.ObjectType,
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
                Type= "AsymmetricX509Cert",
                Usage= "Verify"
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
