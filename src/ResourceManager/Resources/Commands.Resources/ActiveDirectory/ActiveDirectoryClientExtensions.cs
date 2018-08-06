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

using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Resources.ActiveDirectory
{
    internal static class ActiveDirectoryClientExtensions
    {

        private static string ApplicationWithAppIdDoesntExist = "Application with AppId '{0}' does not exist.";

        public static List<PSADServicePrincipal> ListServicePrincipals(this ActiveDirectoryClient ADClient, ADObjectFilterOptions options)
        {
            List<PSADServicePrincipal> servicePrincipals = new List<PSADServicePrincipal>();
            IPage<ServicePrincipal> result = null;
            ServicePrincipal servicePrincipal = null;

            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    servicePrincipal = ADClient.GraphClient.ServicePrincipals.Get(options.Id);
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (servicePrincipal != null)
                {
                    servicePrincipals.Add(servicePrincipal.ToPSADServicePrincipal());
                }
            }
            else if (!string.IsNullOrEmpty(options.SPN))
            {
                try
                {
                    var odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.ServicePrincipalNames.Contains(options.SPN));
                    servicePrincipal = ADClient.GraphClient.ServicePrincipals.List(odataQuery.ToString()).FirstOrDefault();
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (servicePrincipal != null)
                {
                    servicePrincipals.Add(servicePrincipal.ToPSADServicePrincipal());
                }
            }
            else
            {

                if (options.Paging)
                {
                    if (string.IsNullOrEmpty(options.NextLink))
                    {
                        var odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.DisplayName.StartsWith(options.SearchString));
                        result = ADClient.GraphClient.ServicePrincipals.List(odataQuery);
                    }
                    else
                    {
                        result = ADClient.GraphClient.ServicePrincipals.ListNext(options.NextLink);
                    }

                    servicePrincipals.AddRange(result.Select(u => u.ToPSADServicePrincipal()));
                    options.NextLink = result.NextPageLink;
                }
                else
                {
                    var odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.DisplayName.StartsWith(options.SearchString));
                    result = ADClient.GraphClient.ServicePrincipals.List(odataQuery.ToString());
                    servicePrincipals.AddRange(result.Select(u => u.ToPSADServicePrincipal()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = ADClient.GraphClient.ServicePrincipals.ListNext(result.NextPageLink);
                        servicePrincipals.AddRange(result.Select(u => u.ToPSADServicePrincipal()));
                    }
                }
            }

            return servicePrincipals;
        }

        public static List<PSADUser> ListUsers(this ActiveDirectoryClient ADClient, ADObjectFilterOptions options)
        {
            List<PSADUser> users = new List<PSADUser>();
            IPage<User> result = null;
            User user = null;

            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    user = ADClient.GraphClient.Users.Get(Normalize(options.Id));
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (user != null)
                {
                    users.Add(user.ToPSADUser());
                }
            }
            else if (!string.IsNullOrEmpty(options.UPN) || !string.IsNullOrEmpty(options.Mail))
            {
                try
                {
                    string upnOrMail = Normalize(options.UPN) ?? Normalize(options.Mail);
                    var odataQuery = new Rest.Azure.OData.ODataQuery<User>(u => u.UserPrincipalName == upnOrMail);
                    result = ADClient.GraphClient.Users.List(odataQuery);
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (result != null)
                {
                    users.AddRange(result.Select(u => u.ToPSADUser()));
                }
            }
            else
            {
                if (options.Paging)
                {
                    if (string.IsNullOrEmpty(options.NextLink))
                    {
                        var odataQuery = new Rest.Azure.OData.ODataQuery<User>(u => u.DisplayName.StartsWith(options.SearchString));
                        result = ADClient.GraphClient.Users.List(odataQuery.ToString());
                    }
                    else
                    {
                        result = ADClient.GraphClient.Users.ListNext(options.NextLink);
                    }

                    users.AddRange(result.Select(u => u.ToPSADUser()));
                    options.NextLink = result.NextPageLink;
                }
                else
                {
                    var odataQuery = new Rest.Azure.OData.ODataQuery<User>(u => u.DisplayName.StartsWith(options.SearchString));
                    result = ADClient.GraphClient.Users.List(odataQuery.ToString());
                    users.AddRange(result.Select(u => u.ToPSADUser()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = ADClient.GraphClient.Users.ListNext(result.NextPageLink);
                        users.AddRange(result.Select(u => u.ToPSADUser()));
                    }
                }

            }

            return users;
        }

        public static List<PSADGroup> ListGroups(this ActiveDirectoryClient ADClient, ADObjectFilterOptions options)
        {
            List<PSADGroup> groups = new List<PSADGroup>();

            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    // use GetObjectsByObjectId to handle Redirects in the CSP scenario
                    PSADGroup group = ADClient.GetObjectsByObjectId(new List<string> { options.Id }).FirstOrDefault() as PSADGroup;
                    if (group != null)
                    {
                        groups.Add(group);
                    }
                }
                catch {  /* The group does not exist, ignore the exception */ }
            }
            else
            {
                IPage<ADGroup> result = null;
                Rest.Azure.OData.ODataQuery<ADGroup> odataQuery = null;

                if (options.Paging)
                {
                    if (string.IsNullOrEmpty(options.NextLink))
                    {
                        if (options.Mail != null)
                        {
                            odataQuery = new Rest.Azure.OData.ODataQuery<ADGroup>(g => g.Mail == options.Mail);
                        }
                        else
                        {
                            odataQuery = new Rest.Azure.OData.ODataQuery<ADGroup>(g => g.DisplayName.StartsWith(options.SearchString));
                        }

                        result = ADClient.GraphClient.Groups.List(odataQuery);
                    }
                    else
                    {
                        result = ADClient.GraphClient.Groups.ListNext(options.NextLink);
                    }

                    groups.AddRange(result.Select(g => g.ToPSADGroup()));
                    options.NextLink = result.NextPageLink;
                }
                else
                {

                    if (options.Mail != null)
                    {
                        odataQuery = new Rest.Azure.OData.ODataQuery<ADGroup>(g => g.Mail == options.Mail);
                    }
                    else
                    {
                        odataQuery = new Rest.Azure.OData.ODataQuery<ADGroup>(g => g.DisplayName.StartsWith(options.SearchString));
                    }

                    result = ADClient.GraphClient.Groups.List(odataQuery.ToString());
                    groups.AddRange(result.Select(g => g.ToPSADGroup()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = ADClient.GraphClient.Groups.ListNext(result.NextPageLink);
                        groups.AddRange(result.Select(g => g.ToPSADGroup()));
                    }
                }
            }

            return groups;
        }

        public static List<PSADObject> ListGroupMembers(this ActiveDirectoryClient ADClient, ADObjectFilterOptions options)
        {
            List<PSADObject> members = new List<PSADObject>();
            IPage<AADObject> result = null;

            if (options.Paging)
            {
                if (string.IsNullOrEmpty(options.NextLink))
                {
                    result = ADClient.GraphClient.Groups.GetGroupMembers(options.Id);
                }
                else
                {
                    result = ADClient.GraphClient.Groups.GetGroupMembersNext(options.NextLink);
                }

                members.AddRange(result.Select(u => u.ToPSADObject()));
                options.NextLink = result.NextPageLink;
            }
            else
            {
                result = ADClient.GraphClient.Groups.GetGroupMembers(options.Id);
                members.AddRange(result.Select(u => u.ToPSADObject()));

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = ADClient.GraphClient.Groups.GetGroupMembersNext(result.NextPageLink);
                    members.AddRange(result.Select(u => u.ToPSADObject()));
                }
            }

            return members;
        }

        public static List<PSADObject> ListObjectsByObjectId(this ActiveDirectoryClient ADClient, List<string> objectIds)
        {
            List<PSADObject> result = new List<PSADObject>();
            IPage<AADObject> adObjects;
            int objectIdBatchCount;
            for (int i = 0; i < objectIds.Count; i += 1000)
            {
                if ((i + 1000) > objectIds.Count)
                {
                    objectIdBatchCount = objectIds.Count - i;
                }
                else
                {
                    objectIdBatchCount = 1000;
                }
                adObjects = ADClient.GraphClient.Objects.GetObjectsByObjectIds(new GetObjectsParameters { ObjectIds = objectIds.GetRange(i, objectIdBatchCount), IncludeDirectoryObjectReferences = true });
                result.AddRange(adObjects.Select(o => o.ToPSADObject()));
            }
            return result;
        }

        public static Guid ListAppObjectIdFromApplicationId(this ActiveDirectoryClient ADClient, Guid applicationId)
        {
            var applicationIdString = applicationId.ToString();
            var odataQueryFilter = new Rest.Azure.OData.ODataQuery<Application>(a => a.AppId == applicationIdString);
            var app = ADClient.ListApplicationWithFilters(odataQueryFilter).SingleOrDefault();
            if (app == null)
            {
                throw new InvalidOperationException(string.Format(ApplicationWithAppIdDoesntExist, applicationId));
            }
            return app.ObjectId;
        }

        public static IEnumerable<PSADApplication> ListApplicationWithFilters(this ActiveDirectoryClient ADClient, Rest.Azure.OData.ODataQuery<Application> odataQueryFilter)
        {
            return ADClient.GraphClient.Applications.List(odataQueryFilter.ToString()).Select(a => a.ToPSADApplication());
        }

        private static PSADApplication ToPSADApplication(this Application application)
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

        private static PSADServicePrincipal ToPSADServicePrincipal(this ServicePrincipal servicePrincipal)
        {
            return new PSADServicePrincipal()
            {
                DisplayName = servicePrincipal.DisplayName,
                Id = new Guid(servicePrincipal.ObjectId),
                ApplicationId = Guid.Parse(servicePrincipal.AppId),
                ServicePrincipalNames = servicePrincipal.ServicePrincipalNames.ToArray(),
                Type = servicePrincipal.ObjectType
            };
        }

        private static PSADUser ToPSADUser(this User user)
        {
            return new PSADUser()
            {
                DisplayName = user.DisplayName,
                Id = new Guid(user.ObjectId),
                UserPrincipalName = user.UserPrincipalName,
                Type = user.ObjectType
            };
        }

        private static PSADGroup ToPSADGroup(this ADGroup group)
        {
            return new PSADGroup()
            {
                DisplayName = group.DisplayName,
                Id = new Guid(group.ObjectId),
                SecurityEnabled = group.SecurityEnabled,
                Type = group.ObjectType
            };
        }

        private static PSADObject ToPSADObject(this AADObject obj)
        {
            if (obj == null) throw new ArgumentNullException();

            if (obj.ObjectType == typeof(User).Name)
            {
                return new PSADUser()
                {
                    DisplayName = obj.DisplayName,
                    Id = new Guid(obj.ObjectId),
                    Type = obj.ObjectType,
                    UserPrincipalName = obj.UserPrincipalName
                };
            }
            else if (obj.ObjectType == "Group")
            {
                return new PSADGroup()
                {
                    DisplayName = obj.DisplayName,
                    Type = obj.ObjectType,
                    Id = new Guid(obj.ObjectId),
                    SecurityEnabled = obj.SecurityEnabled
                };

            }
            else if (obj.ObjectType == typeof(ServicePrincipal).Name)
            {
                return new PSADServicePrincipal()
                {
                    DisplayName = obj.DisplayName,
                    Id = new Guid(obj.ObjectId),
                    Type = obj.ObjectType,
                    ServicePrincipalNames = obj.ServicePrincipalNames.ToArray()
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

        private static string Normalize(string s)
        {
            return string.IsNullOrEmpty(s) ? null : s;
        }
    }
}
