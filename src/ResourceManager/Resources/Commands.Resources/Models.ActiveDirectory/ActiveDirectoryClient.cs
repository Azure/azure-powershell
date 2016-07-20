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

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

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
            GraphClient = AzureSession.ClientFactory.CreateArmClient<GraphRbacManagementClient>(
                context, AzureEnvironment.Endpoint.Graph);

            GraphClient.TenantID = context.Tenant.Id.ToString();
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
            Rest.Azure.IPage<ServicePrincipal> result = null;
            ServicePrincipal servicePrincipal = null;

            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    servicePrincipal = GraphClient.ServicePrincipals.Get(options.Id);
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
                    servicePrincipal = GraphClient.ServicePrincipals.List(new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.ServicePrincipalNames.Contains(options.SPN))).FirstOrDefault();
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
                        result = GraphClient.ServicePrincipals.List(new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.DisplayName.StartsWith(options.SearchString)));
                    }
                    else
                    {
                        result = GraphClient.ServicePrincipals.ListNext(options.NextLink);
                    }

                    servicePrincipals.AddRange(result.Select(u => u.ToPSADServicePrincipal()));
                    options.NextLink = result.NextPageLink;
                }
                else
                {
                    result = GraphClient.ServicePrincipals.List(new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.DisplayName.StartsWith(options.SearchString)));
                    servicePrincipals.AddRange(result.Select(u => u.ToPSADServicePrincipal()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = GraphClient.ServicePrincipals.ListNext(result.NextPageLink);
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
            Rest.Azure.IPage<User> result = null;
            User user = null;

            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    user = GraphClient.Users.Get(Normalize(options.Id));
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
                    result = GraphClient.Users.List(new Rest.Azure.OData.ODataQuery<User>(u => u.UserPrincipalName == upnOrMail));
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
                        result = GraphClient.Users.List(new Rest.Azure.OData.ODataQuery<User>(u => u.DisplayName.StartsWith(options.SearchString)));
                    }
                    else
                    {
                        result = GraphClient.Users.ListNext(options.NextLink);
                    }

                    users.AddRange(result.Select(u => u.ToPSADUser()));
                    options.NextLink = result.NextPageLink;
                }
                else
                {
                    result = GraphClient.Users.List(new Rest.Azure.OData.ODataQuery<User>(u => u.DisplayName.StartsWith(options.SearchString)));
                    users.AddRange(result.Select(u => u.ToPSADUser()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = GraphClient.Users.ListNext(result.NextPageLink);
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
            var groupsIds = GraphClient.Users.GetMemberGroups(objectId.ToString(), new UserGetMemberGroupsParameters());
            var groupsResult = GraphClient.Objects.GetObjectsByObjectIds(new GetObjectsParameters { ObjectIds = groupsIds.ToList() });
            result.AddRange(groupsResult.Select(g => g.ToPSADGroup()));

            return result;
        }

        public List<PSADObject> GetObjectsByObjectId(List<string> objectIds)
        {
            List<PSADObject> result = new List<PSADObject>();
            var adObjects = GraphClient.Objects.GetObjectsByObjectIds(new GetObjectsParameters { ObjectIds = objectIds, IncludeDirectoryObjectReferences = true });
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
                    group = GraphClient.Groups.Get(options.Id);
                }
                catch {  /* The group does not exist, ignore the exception */ }

                if (group != null)
                {
                    groups.Add(group.ToPSADGroup());
                }
            }
            else
            {
                Rest.Azure.IPage<ADGroup> result = null;
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

                        result = GraphClient.Groups.List(odataQuery);
                    }
                    else
                    {
                        result = GraphClient.Groups.ListNext(options.NextLink);
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

                    result = GraphClient.Groups.List(odataQuery);
                    groups.AddRange(result.Select(g => g.ToPSADGroup()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = GraphClient.Groups.ListNext(result.NextPageLink);
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
                Rest.Azure.IPage<AADObject> result = null;

                if (options.Paging)
                {
                    if (string.IsNullOrEmpty(options.NextLink))
                    {
                        result = GraphClient.Groups.GetGroupMembers(group.Id.ToString());
                    }
                    else
                    {
                        result = GraphClient.Groups.GetGroupMembersNext(options.NextLink);
                    }

                    members.AddRange(result.Select(u => u.ToPSADObject()));
                    options.NextLink = result.NextPageLink;
                }
                else
                {
                    result = GraphClient.Groups.GetGroupMembers(group.Id.ToString());
                    members.AddRange(result.Select(u => u.ToPSADObject()));

                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = GraphClient.Groups.GetGroupMembersNext(result.NextPageLink);
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

            try
            {
                return GraphClient.Applications.Create(graphParameters).ToPSADApplication();
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.Forbidden)
                {
                    AADObject currentUser = GraphClient.Objects.GetCurrentUser();
                    if (currentUser != null && string.Equals(currentUser.UserType, "Guest", StringComparison.InvariantCultureIgnoreCase))
                    {
                        throw new InvalidOperationException(ProjectResources.CreateApplicationNotAllowedGuestUser);
                    }
                }

                throw;
            }
        }

        public void RemoveApplication(string applicationObjectId)
        {
            GraphClient.Applications.Delete(applicationObjectId.ToString());
        }

        public PSADApplication GetApplication(string applicationObjectId)
        {
            return GraphClient.Applications.Get(applicationObjectId.ToString()).ToPSADApplication();
        }

        public IEnumerable<PSADApplication> GetApplicationWithFilters(Rest.Azure.OData.ODataQuery<Application> odataQueryFilter)
        {
            return GraphClient.Applications.List(odataQueryFilter).Select(a => a.ToPSADApplication());
        }

        public PSADServicePrincipal CreateServicePrincipal(CreatePSServicePrincipalParameters createParameters)
        {
            ServicePrincipalCreateParameters graphParameters = new ServicePrincipalCreateParameters
            {
                AppId = createParameters.ApplicationId.ToString(),
                AccountEnabled = createParameters.AccountEnabled
            };

            try
            {
                return GraphClient.ServicePrincipals.Create(graphParameters).ToPSADServicePrincipal();
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.Forbidden)
                {
                    AADObject currentUser = GraphClient.Objects.GetCurrentUser();
                    if (currentUser != null && string.Equals(currentUser.UserType, "Guest", StringComparison.InvariantCultureIgnoreCase))
                    {
                        throw new InvalidOperationException(ProjectResources.CreateServicePrincipalNotAllowedGuestUser);
                    }
                }

                throw;
            }
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
                GraphClient.ServicePrincipals.Delete(objectId);
            }
            else
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.ServicePrincipalDoesntExist, objectId));
            }

            return servicePrincipal;
        }
    }
}