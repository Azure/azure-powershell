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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.Models.ActiveDirectory
{
    public class ActiveDirectoryClient
    {
        public GraphRbacManagementClient GraphClient { get; private set; }

        /// <summary>
        /// Creates new ActiveDirectoryClient using AzureSubscription.
        /// </summary>
        /// <param name="authenticationFactory"></param>
        /// <param name="clientFactory"></param>
        /// <param name="context"></param>
        public ActiveDirectoryClient(IAuthenticationFactory authenticationFactory, IClientFactory clientFactory, AzureContext context)
        {
            AccessTokenCredential creds = (AccessTokenCredential)authenticationFactory.GetSubscriptionCloudCredentials(context);
            GraphClient = clientFactory.CreateCustomArmClient<GraphRbacManagementClient>(
                context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.Graph),
                creds);
            GraphClient.TenantID = creds.TenantID;
            GraphClient.SubscriptionId = creds.SubscriptionId;
        }

        public PSADObject GetADObject(ADObjectFilterOptions options)
        {
            PSADObject result = null;

            Debug.Assert(options != null);

            if (IsSet(options.SignInName, options.Mail, options.UPN, options.Id))
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
            ServicePrincipal servicePrincipal = null;

            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    servicePrincipal = GraphClient.ServicePrincipal.Get(options.Id);
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
                    servicePrincipal = GraphClient.ServicePrincipal
                                        .List(new ODataQuery<ServicePrincipal>(item => item.ServicePrincipalNames.Contains(options.SPN)))
                                        .FirstOrDefault();
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (servicePrincipal != null)
                {
                    servicePrincipals.Add(servicePrincipal.ToPSADServicePrincipal());
                }
            }
            else
            {
                IPage<ServicePrincipal> result;

                if (options.Paging)
                {
                    if (string.IsNullOrEmpty(options.NextLink))
                    {
                        result = GraphClient.ServicePrincipal
                                    .List(new ODataQuery<ServicePrincipal>(item => item.DisplayName.StartsWith(options.SearchString)));
                    }
                    else
                    {
                        result = GraphClient.ServicePrincipal.ListNext(options.NextLink);
                    }

                    servicePrincipals.AddRange(result.Select(u => u.ToPSADServicePrincipal()));
                    options.NextLink = result.NextPageLink;
                }
                else
                {
                    result = GraphClient.ServicePrincipal.List(new ODataQuery<ServicePrincipal>(item => item.DisplayName.StartsWith(options.SearchString)));
                    servicePrincipals.AddRange(result.Select(u => u.ToPSADServicePrincipal()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = GraphClient.ServicePrincipal.ListNext(result.NextPageLink);
                        servicePrincipals.AddRange(result.Select(u => u.ToPSADServicePrincipal()));
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
            IPage<User> result;
            User user = null;

            if (!string.IsNullOrEmpty(options.Id) || !string.IsNullOrEmpty(options.UPN))
            {
                try
                {
                    user = GraphClient.User.Get(Normalize(options.Id) ?? Normalize(options.UPN));
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (user != null)
                {
                    users.Add(user.ToPSADUser());
                }
            }
            else if (!string.IsNullOrEmpty(options.Mail) || !string.IsNullOrEmpty(options.SignInName))
            {
                try
                {
                    user = GraphClient.User
                            .List(new ODataQuery<User>(item => item.SignInName == (Normalize(options.Mail) ?? Normalize(options.SignInName))))
                            .FirstOrDefault();
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
                        result = GraphClient.User.List(new ODataQuery<User>(item => item.DisplayName.StartsWith(options.SearchString)));
                    }
                    else
                    {
                        result = GraphClient.User.ListNext(options.NextLink);
                    }

                    users.AddRange(result.Select(u => u.ToPSADUser()));
                    options.NextLink = result.NextPageLink;
                }
                else
                {
                    result = GraphClient.User.List(new ODataQuery<User>(item => item.DisplayName.StartsWith(options.SearchString)));
                    users.AddRange(result.Select(u => u.ToPSADUser()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = GraphClient.User.ListNext(result.NextPageLink);
                        users.AddRange(result.Select(u => u.ToPSADUser()));
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
            var groupsIds = GraphClient.User.GetMemberGroups(user.Id.ToString(), new UserGetMemberGroupsParameters());
            var groupsResult = GraphClient.Objects.GetObjectsByObjectIds(new GetObjectsParameters { ObjectIds = groupsIds.ToList() });
            result.AddRange(groupsResult.Select(g => g.ToPSADGroup()));

            return result;
        }

        public List<PSADObject> GetObjectsByObjectId(List<string> objectIds)
        {
            List<PSADObject> result = new List<PSADObject>();
            var adObjects = GraphClient.Objects.GetObjectsByObjectIds(
                new GetObjectsParameters
                {
                    ObjectIds = objectIds,
                    IncludeDirectoryObjectReferences = true
                });
            result.AddRange(adObjects.Select(o => o.ToPSADObject()));
            return result;
        }

        public List<PSADGroup> FilterGroups(ADObjectFilterOptions options)
        {
            List<PSADGroup> groups = new List<PSADGroup>();
            ADGroup group = null;

            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    group = GraphClient.Group.Get(options.Id);
                }
                catch {  /* The group does not exist, ignore the exception */ }

                if (group != null)
                {
                    groups.Add(group.ToPSADGroup());
                }
            }
            else
            {
                IPage<ADGroup> result;

                if (options.Paging)
                {
                    if (string.IsNullOrEmpty(options.NextLink))
                    {
                        result = GraphClient.Group.List(new ODataQuery<ADGroup>(
                            item => item.Mail == options.Mail && item.DisplayName.StartsWith(options.SearchString)));
                    }
                    else
                    {
                        result = GraphClient.Group.ListNext(options.NextLink);
                    }

                    groups.AddRange(result.Select(g => g.ToPSADGroup()));
                    options.NextLink = result.NextPageLink;
                }
                else
                {
                    result = GraphClient.Group.List(new ODataQuery<ADGroup>(
                        item => item.Mail == options.Mail && item.DisplayName.StartsWith(options.SearchString)));
                    groups.AddRange(result.Select(g => g.ToPSADGroup()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = GraphClient.Group.ListNext(result.NextPageLink);
                        groups.AddRange(result.Select(g => g.ToPSADGroup()));
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
                IPage<AADObject> result;

                if (options.Paging)
                {
                    if (string.IsNullOrEmpty(options.NextLink))
                    {
                        result = GraphClient.Group.GetGroupMembers(group.Id.ToString());
                    }
                    else
                    {
                        result = GraphClient.Group.GetGroupMembersNext(options.NextLink);
                    }

                    members.AddRange(result.Select(u => u.ToPSADObject()));
                    options.NextLink = result.NextPageLink;
                }
                else
                {
                    result = GraphClient.Group.GetGroupMembers(group.Id.ToString());
                    members.AddRange(result.Select(u => u.ToPSADObject()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = GraphClient.Group.GetGroupMembersNext(result.NextPageLink);
                        members.AddRange(result.Select(u => u.ToPSADObject()));
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

        public PSADApplication CreateApplication(CreatePSApplicationParameters createParameters)
        {
            IList<PasswordCredential> passwordCredentials = createParameters.PasswordCredentials != null
                ? createParameters.PasswordCredentials.Select(psCredential => psCredential.ToGraphPasswordCredential()).ToList()
                : null;

            IList<KeyCredential> keyCredentials = createParameters.KeyCredentials != null
                ? createParameters.KeyCredentials.Select(psCredential => psCredential.ToGraphKeyCredential()).ToList()
                : null;

            ApplicationCreateParameters graphParameters = new ApplicationCreateParameters
            {
                DisplayName = createParameters.DisplayName,
                Homepage = createParameters.HomePage,
                IdentifierUris = createParameters.IdentifierUris,
                PasswordCredentials = passwordCredentials,
                KeyCredentials = keyCredentials
            };

            return GraphClient.Application.Create(graphParameters).ToPSADApplication();
        }

        public void RemoveApplication(string applicationObjectId)
        {
            GraphClient.Application.Delete(applicationObjectId.ToString());
        }

        public PSADServicePrincipal CreateServicePrincipal(CreatePSServicePrincipalParameters createParameters)
        {
            ServicePrincipalCreateParameters graphParameters = new ServicePrincipalCreateParameters
            {
                AppId = createParameters.ApplicationId.ToString(),
                AccountEnabled = createParameters.AccountEnabled
            };

            return GraphClient.ServicePrincipal.Create(graphParameters).ToPSADServicePrincipal();
        }

        public PSADServicePrincipal RemoveServicePrincipal(string objectId)
        {
            ADObjectFilterOptions options = new ADObjectFilterOptions
            {
                Id = objectId.ToString()
            };

            PSADServicePrincipal servicePrincipal = FilterServicePrincipals(options).FirstOrDefault();
            if (servicePrincipal != null)
            {
                GraphClient.ServicePrincipal.Delete(objectId);
            }
            else
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.ServicePrincipalDoesntExist, objectId));
            }

            return servicePrincipal;
        }
    }
}
