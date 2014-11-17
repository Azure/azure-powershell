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
                    Id = new Guid(obj.ObjectId)/*,
                    Mail = group.Mail*/
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
                Mail = user.SignInName
            };
        }

        public static PSADGroup ToPSADGroup(this Group group)
        {
            return new PSADGroup()
            {
                DisplayName = group.DisplayName,
                Id = new Guid(group.ObjectId)/*,
                Mail = group.Mail*/
            };
        }

        public static PSADServicePrincipal ToPSADServicePrincipal(this ServicePrincipal servicePrincipal)
        {
            return new PSADServicePrincipal()
            {
                DisplayName = servicePrincipal.DisplayName,
                Id = new Guid(servicePrincipal.ObjectId),
                ServicePrincipalName = servicePrincipal.ServicePrincipalNames.FirstOrDefault()
            };
        }
    }
}
