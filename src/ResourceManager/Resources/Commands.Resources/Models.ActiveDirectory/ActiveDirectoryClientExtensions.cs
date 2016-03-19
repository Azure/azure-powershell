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
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Resources.Models.ActiveDirectory
{
    internal static class ActiveDirectoryClientExtensions
    {
        public static PSADObject ToPSADObject(this User user)
        {
            return new PSADObject()
            {
                DisplayName = user.DisplayName,
                Id = new Guid(user.ObjectId)
            };
        }

        public static PSADObject ToPSADObject(this Group group)
        {
            return new PSADObject()
            {
                DisplayName = group.DisplayName,
                Id = new Guid(group.ObjectId)
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
                    Id = new Guid(obj.ObjectId),
                    Type = obj.ObjectType,
                    UserPrincipalName = obj.UserPrincipalName,
                    Mail = obj.Mail
                };
            }
            else if (obj.ObjectType == typeof(Group).Name)
            {
                return new PSADGroup()
                {
                    DisplayName = obj.DisplayName,
                    Type = obj.ObjectType,
                    Id = new Guid(obj.ObjectId),
                    SecurityEnabled = obj.SecurityEnabled/*,
                    Mail = group.Mail*/
                };

            }
            else if (obj.ObjectType == typeof(ServicePrincipal).Name)
            {
                return new PSADServicePrincipal()
                {
                    DisplayName = obj.DisplayName,
                    Id = new Guid(obj.ObjectId),
                    Type = obj.ObjectType,
                    ServicePrincipalName = obj.ServicePrincipalNames.FirstOrDefault()
                };
            }
            else
            {
                return new PSADObject()
                {
                    DisplayName = obj.DisplayName,
                    Id = new Guid(obj.ObjectId),
                    Type = obj.ObjectType
                };
            }
        }

        public static PSADObject ToPSADGroup(this AADObject obj)
        {
            return new PSADObject()
            {
                DisplayName = obj.DisplayName,
                Id = new Guid(obj.ObjectId)
            };
        }

        public static PSADUser ToPSADUser(this User user)
        {
            return new PSADUser()
            {
                DisplayName = user.DisplayName,
                Id = new Guid(user.ObjectId),
                UserPrincipalName = user.UserPrincipalName,
                Mail = user.Mail 
            };
        }

        public static PSADGroup ToPSADGroup(this Group group)
        {
            return new PSADGroup()
            {
                DisplayName = group.DisplayName,
                Id = new Guid(group.ObjectId),
                SecurityEnabled = group.SecurityEnabled/*,
                Mail = group.Mail*/
            };
        }

        public static PSADServicePrincipal ToPSADServicePrincipal(this ServicePrincipal servicePrincipal)
        {
            return new PSADServicePrincipal()
            {
                DisplayName = servicePrincipal.DisplayName,
                Id = new Guid(servicePrincipal.ObjectId),
                ApplicationId = Guid.Parse(servicePrincipal.AppId),
                ServicePrincipalName = servicePrincipal.ServicePrincipalNames.FirstOrDefault()
            };
        }

        public static PSADApplication ToPSADApplication(this Application application)
        {
            if (application != null)
            {
                return new PSADApplication()
                {
                    ApplicationObjectId = Guid.Parse(application.ObjectId),
                    Type = application.ObjectType,
                    ApplicationId = Guid.Parse(application.AppId),
                    IdentifierUris = application.IdentifierUris,
                    DisplayName= application.DisplayName,
                    ReplyUrls = application.ReplyUrls,
                    AppPermissions = application.AppPermissions,
                    AvailableToOtherTenants = application.AvailableToOtherTenants
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
                KeyId = PSKeyCredential.KeyId,
                Type = PSKeyCredential.Type,
                Usage = PSKeyCredential.Usage,
                Value = PSKeyCredential.Value
            };
        }

        public static PasswordCredential ToGraphPasswordCredential(this PSADPasswordCredential PSPasswordCredential)
        {
            return new PasswordCredential
            {
                 StartDate = PSPasswordCredential.StartDate,
                 EndDate = PSPasswordCredential.EndDate,
                 KeyId = PSPasswordCredential.KeyId,
                 Value = PSPasswordCredential.Value
            };
        }
    }
}
