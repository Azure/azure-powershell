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

using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.Azure.Commands.Resources.Models.ActiveDirectory
{
    public class ActiveDirectoryClient
    {
        public GraphRbacManagementClient GraphClient { get; private set; }

        /// <summary>
        /// Creates new ActiveDirectoryClient using WindowsAzureSubscription.
        /// </summary>
        /// <param name="context"></param>
        public ActiveDirectoryClient(AzureContext context)
        {
            AccessTokenCredential creds = (AccessTokenCredential)AzureSession.AuthenticationFactory.GetSubscriptionCloudCredentials(context);
            GraphClient = AzureSession.ClientFactory.CreateCustomClient<GraphRbacManagementClient>(
                creds.TenantID,
                creds,
                context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.Graph));
        }

        public PSADObject GetADObject(ADObjectFilterOptions options)
        {
            PSADObject result = null;

            Debug.Assert(options != null);

            if (IsSet(options.Mail, options.UPN, options.Id))
            {
                result = FilterUsers(options).FirstOrDefault();
            }

            if (result == null && IsSet(options.SPN, options.Id))
            {
                result = FilterServicePrincipals(options).FirstOrDefault();
            }

            if (result == null && IsSet(options.Mail, options.Id))
            {
                result = FilterGroups(options).FirstOrDefault();
            }

            return result;
        }

        private static bool IsSet(params string[] strings)
        {
            return strings.Any(s => !string.IsNullOrEmpty(s));
        }

        private static string Normalize(string s)
        {
            return string.IsNullOrEmpty(s) ? null : s;
        }

        public List<PSADServicePrincipal> FilterServicePrincipals(ADObjectFilterOptions options)
        {
            List<PSADServicePrincipal> servicePrincipals = new List<PSADServicePrincipal>();
            ServicePrincipalListResult result = new ServicePrincipalListResult();
            ServicePrincipal servicePrincipal = null;

            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    servicePrincipal = GraphClient.ServicePrincipal.Get(options.Id).ServicePrincipal;
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
                    servicePrincipal = GraphClient.ServicePrincipal.GetByServicePrincipalName(options.SPN).ServicePrincipals.FirstOrDefault();
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
                        result = GraphClient.ServicePrincipal.List(options.SearchString);
                    }
                    else
                    {
                        result = GraphClient.ServicePrincipal.ListNext(options.NextLink);
                    }

                    servicePrincipals.AddRange(result.ServicePrincipals.Select(u => u.ToPSADServicePrincipal()));
                    options.NextLink = result.NextLink;
                }
                else
                {
                    result = GraphClient.ServicePrincipal.List(options.SearchString);
                    servicePrincipals.AddRange(result.ServicePrincipals.Select(u => u.ToPSADServicePrincipal()));

                    while (!string.IsNullOrEmpty(result.NextLink))
                    {
                        result = GraphClient.ServicePrincipal.ListNext(result.NextLink);
                        servicePrincipals.AddRange(result.ServicePrincipals.Select(u => u.ToPSADServicePrincipal()));
                    }
                }
            }

            return servicePrincipals;
        }

        public List<PSADServicePrincipal> FilterServices()
        {
            return FilterServicePrincipals(new ADObjectFilterOptions());
        }

        public List<PSADUser> FilterUsers(ADObjectFilterOptions options)
        {
            List<PSADUser> users = new List<PSADUser>();
            UserListResult result = new UserListResult();
            User user = null;

            if (!string.IsNullOrEmpty(options.Id) || !string.IsNullOrEmpty(options.UPN))
            {
                try
                {
                    user = GraphClient.User.Get(Normalize(options.Id) ?? Normalize(options.UPN)).User;
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (user != null)
                {
                    users.Add(user.ToPSADUser());
                }
            }
            else if (!string.IsNullOrEmpty(options.Mail))
            {
                try
                {
                    user = GraphClient.User.GetBySignInName(options.Mail).Users.FirstOrDefault();
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (user != null)
                {
                    users.Add(user.ToPSADUser());
                }
            }
            else
            {
                if (options.Paging)
                {
                    if (string.IsNullOrEmpty(options.NextLink))
                    {
                        result = GraphClient.User.List(null, options.SearchString);
                    }
                    else
                    {
                        result = GraphClient.User.ListNext(options.NextLink);
                    }

                    users.AddRange(result.Users.Select(u => u.ToPSADUser()));
                    options.NextLink = result.NextLink;
                }
                else
                {
                    result = GraphClient.User.List(null, options.SearchString);
                    users.AddRange(result.Users.Select(u => u.ToPSADUser()));

                    while (!string.IsNullOrEmpty(result.NextLink))
                    {
                        result = GraphClient.User.ListNext(result.NextLink);
                        users.AddRange(result.Users.Select(u => u.ToPSADUser()));
                    }
                }
            }

            return users;
        }

        public List<PSADUser> FilterUsers()
        {
            return FilterUsers(new ADObjectFilterOptions());
        }

        public List<PSADObject> ListUserGroups(string principal)
        {
            List<PSADObject> result = new List<PSADObject>();
            Guid objectId = GetObjectId(new ADObjectFilterOptions { UPN = principal });
            PSADObject user = GetADObject(new ADObjectFilterOptions { Id = objectId.ToString() });
            var groupsIds = GraphClient.User.GetMemberGroups(new UserGetMemberGroupsParameters { ObjectId = user.Id.ToString() }).ObjectIds;
            var groupsResult = GraphClient.Objects.GetObjectsByObjectIds(new GetObjectsParameters { Ids = groupsIds });
            result.AddRange(groupsResult.AADObject.Select(g => g.ToPSADGroup()));

            return result;
        }

        public List<PSADGroup> FilterGroups(ADObjectFilterOptions options)
        {
            List<PSADGroup> groups = new List<PSADGroup>();
            Group group = null;

            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    group = GraphClient.Group.Get(options.Id).Group;
                }
                catch {  /* The group does not exist, ignore the exception */ }

                if (group != null)
                {
                    groups.Add(group.ToPSADGroup());
                }
            }
            else
            {
                GroupListResult result = new GroupListResult();

                if (options.Paging)
                {
                    if (string.IsNullOrEmpty(options.NextLink))
                    {
                        result = GraphClient.Group.List(options.Mail, options.SearchString);
                    }
                    else
                    {
                        result = GraphClient.Group.ListNext(options.NextLink);
                    }

                    groups.AddRange(result.Groups.Select(g => g.ToPSADGroup()));
                    options.NextLink = result.NextLink;
                }
                else
                {
                    result = GraphClient.Group.List(options.Mail, options.SearchString);
                    groups.AddRange(result.Groups.Select(g => g.ToPSADGroup()));

                    while (!string.IsNullOrEmpty(result.NextLink))
                    {
                        result = GraphClient.Group.ListNext(result.NextLink);
                        groups.AddRange(result.Groups.Select(g => g.ToPSADGroup()));
                    }
                }
            }

            return groups;
        }

        public List<PSADGroup> FilterGroups()
        {
            return FilterGroups(new ADObjectFilterOptions());
        }

        public List<PSADObject> GetGroupMembers(ADObjectFilterOptions options)
        {
            List<PSADObject> members = new List<PSADObject>();
            PSADObject group = FilterGroups(options).FirstOrDefault();

            if (group != null)
            {
                GetObjectsResult result = new GetObjectsResult();

                if (options.Paging)
                {
                    if (string.IsNullOrEmpty(options.NextLink))
                    {
                        result = GraphClient.Group.GetGroupMembers(group.Id.ToString());
                    }
                    else
                    {
                        result = GraphClient.Group.GetGroupMembersNext(result.NextLink);
                    }

                    members.AddRange(result.AADObject.Select(u => u.ToPSADObject()));
                    options.NextLink = result.NextLink;
                }
                else
                {
                    result = GraphClient.Group.GetGroupMembers(group.Id.ToString());
                    members.AddRange(result.AADObject.Select(u => u.ToPSADObject()));

                    while (!string.IsNullOrEmpty(result.NextLink))
                    {
                        result = GraphClient.Group.GetGroupMembersNext(result.NextLink);
                        members.AddRange(result.AADObject.Select(u => u.ToPSADObject()));
                    }
                }
            }

            return members;
        }

        public Guid GetObjectId(ADObjectFilterOptions options)
        {
            Guid principalId;
            if (options != null && options.Id != null
                && Guid.TryParse(options.Id, out principalId))
            {
                // do nothing, we have parsed the guid
            }
            else
            {
                PSADObject adObj = GetADObject(options);

                if (adObj == null)
                {
                    throw new KeyNotFoundException("The provided information does not map to an AD object id.");
                }

                principalId = adObj.Id;
            }

            return principalId;
        }
    }
}
