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
using Microsoft.Rest;
using Microsoft.Rest.Azure;
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

        public PSADUser CreateUser(UserCreateParameters userCreateParam)
        {
                return GraphClient.Users.Create(userCreateParam).ToPSADUser();
        }

        public PSADUser UpdateUser(string upnOrObjectId, UserUpdateParameters userUpdateParam)
        {
            GraphClient.Users.Update(upnOrObjectId, userUpdateParam);
            return GraphClient.Users.Get(upnOrObjectId).ToPSADUser();
        }

        public void RemoveUser(string upnOrObjectId)
        {
            GraphClient.Users.Delete(upnOrObjectId);
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
            Rest.Azure.IPage<AADObject> result = null;

            if (options.Paging)
            {
                if (string.IsNullOrEmpty(options.NextLink))
                {
                    result = GraphClient.Groups.GetGroupMembers(options.Id);
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
                result = GraphClient.Groups.GetGroupMembers(options.Id);
                members.AddRange(result.Select(u => u.ToPSADObject()));

                while (!string.IsNullOrEmpty(result.NextPageLink))
                {
                    result = GraphClient.Groups.GetGroupMembersNext(result.NextPageLink);
                    members.AddRange(result.Select(u => u.ToPSADObject()));
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

        public void UpdateApplication(string appObjectId, ApplicationUpdateParameters parameters)
        {
            GraphClient.Applications.Patch(appObjectId, parameters);
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
                ReplyUrls = createParameters.ReplyUrls,
                AvailableToOtherTenants = createParameters.AvailableToOtherTenants,
                PasswordCredentials = passwordCredentials,
                KeyCredentials = keyCredentials
            };

            try
            {
                return GraphClient.Applications.Create(graphParameters).ToPSADApplication();
            }
            catch (GraphErrorException ce)
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

        private void ValidateKeyCredential(KeyCredential credential)
        {
            if (credential == null || string.IsNullOrEmpty(credential.KeyId) || string.IsNullOrEmpty(credential.Value) ||
                string.IsNullOrEmpty(credential.Type) || string.IsNullOrEmpty(credential.Usage) || credential.StartDate == null || credential.EndDate == null)
            {
                throw new InvalidOperationException(ProjectResources.KeyCredentialNotValid);
            }
        }

        private void ValidatePasswordCredential(PasswordCredential credential)
        {
            if (credential == null || string.IsNullOrEmpty(credential.KeyId) || string.IsNullOrEmpty(credential.Value) ||
                credential.StartDate == null || credential.EndDate == null)
            {
                throw new InvalidOperationException(ProjectResources.PasswordCredentialNotValid);
            }
        }

        private List<KeyCredential> GetAppKeyCredentials(string appObjectId)
        {
            return GraphClient.Applications.ListKeyCredentials(appObjectId).ToList();
        }

        private List<PasswordCredential> GetAppPasswordCredentials(string appObjectId)
        {
            return GraphClient.Applications.ListPasswordCredentials(appObjectId).ToList();
        }

        private void PatchAppKeyCredentials(string appObjectId, List<KeyCredential> keyCredentails)
        {
            if (keyCredentails == null)
            {
                keyCredentails = new List<KeyCredential>();
            }

            GraphClient.Applications.UpdateKeyCredentials(appObjectId, new KeyCredentialsUpdateParameters(keyCredentails));
        }

        private void PatchAppPasswordCredentials(string appObjectId, List<PasswordCredential> passwordCredentials)
        {
            if (passwordCredentials == null)
            {
                passwordCredentials = new List<PasswordCredential>();
            }

            GraphClient.Applications.UpdatePasswordCredentials(appObjectId, new PasswordCredentialsUpdateParameters(passwordCredentials));
        }

        public PSADCredential CreateAppKeyCredential(string appObjectId, KeyCredential credential)
        {
            ValidateKeyCredential(credential);

            var keyCredsList = GetAppKeyCredentials(appObjectId);

            // Add new KeyCredential to existing KeyCredential list
            keyCredsList.Add(credential);

            PatchAppKeyCredentials(appObjectId, keyCredsList);

            return credential.ToPSADCredential();
        }

        public PSADCredential CreateAppPasswordCredential(string appObjectId, PasswordCredential credential)
        {
            ValidatePasswordCredential(credential);

            var passwordCredsList = GetAppPasswordCredentials(appObjectId);

            // Add new PasswordCredential to existing KeyCredential list
            passwordCredsList.Add(credential);

            PatchAppPasswordCredentials(appObjectId, passwordCredsList);

            return credential.ToPSADCredential();
        }

        public List<PSADCredential> GetAppCredentials(string appObjectId)
        {
            List<PSADCredential> CredentialList = new List<PSADCredential>();

            var keyCredsList = GetAppKeyCredentials(appObjectId);
            CredentialList.AddRange(keyCredsList.Select(kc => kc.ToPSADCredential()));

            var passwordCredsList = GetAppPasswordCredentials(appObjectId);
            CredentialList.AddRange(passwordCredsList.Select(pc => pc.ToPSADCredential()));

            return CredentialList;
        }


        public void RemoveAppCredentialByKeyId(string appObjectId, Guid keyId)
        {
            var keyCredsList = GetAppKeyCredentials(appObjectId);

            var toBeDeletedKeyCred = keyCredsList.Find(kc => Guid.Parse(kc.KeyId) == keyId);

            if (toBeDeletedKeyCred != null)
            {
                keyCredsList.Remove(toBeDeletedKeyCred);
                PatchAppKeyCredentials(appObjectId, keyCredsList);
            }
            else
            {
                var passwordCredsList = GetAppPasswordCredentials(appObjectId);
                var toBeDeletedPasswwordCred = passwordCredsList.Find(pc => Guid.Parse(pc.KeyId) == keyId);

                if (toBeDeletedPasswwordCred != null)
                {
                    passwordCredsList.Remove(toBeDeletedPasswwordCred);
                    PatchAppPasswordCredentials(appObjectId, passwordCredsList);
                }
            }
        }

        public void RemoveAllAppCredentials(string appObjectId)
        {
            PatchAppKeyCredentials(appObjectId, keyCredentails: null);
            PatchAppPasswordCredentials(appObjectId, passwordCredentials: null);
        }

        public string GetObjectIdFromApplicationId(string applicationId)
        {
            var odataQueryFilter = new Rest.Azure.OData.ODataQuery<Application>(a => a.AppId == applicationId);
            var app = GetApplicationWithFilters(odataQueryFilter).SingleOrDefault();
            if (app == null)
            {
                throw new InvalidOperationException(String.Format(ProjectResources.ApplicationWithAppIdDoesntExist, applicationId));
            }
            return app.ObjectId.ToString();
        }


        private List<KeyCredential> GetSpKeyCredentials(string spObjectId)
        {
            return GraphClient.ServicePrincipals.ListKeyCredentials(spObjectId).ToList();
        }

        private List<PasswordCredential> GetSpPasswordCredentials(string spObjectId)
        {
            return GraphClient.ServicePrincipals.ListPasswordCredentials(spObjectId).ToList();
        }

        private void PatchSpKeyCredentials(string spObjectId, List<KeyCredential> keyCredentails)
        {
            if (keyCredentails == null)
            {
                keyCredentails = new List<KeyCredential>();
            }

            GraphClient.ServicePrincipals.UpdateKeyCredentials(spObjectId, new KeyCredentialsUpdateParameters(keyCredentails));
        }

        private void PatchSpPasswordCredentials(string spObjectId, List<PasswordCredential> passwordCredentials)
        {
            if (passwordCredentials == null)
            {
                passwordCredentials = new List<PasswordCredential>();
            }

            GraphClient.ServicePrincipals.UpdatePasswordCredentials(spObjectId, new PasswordCredentialsUpdateParameters(passwordCredentials));
        }


        public PSADCredential CreateSpKeyCredential(string spObjectId, KeyCredential credential)
        {
            ValidateKeyCredential(credential);

            var keyCredsList = GetSpKeyCredentials(spObjectId);

            // Add new KeyCredential to existing KeyCredential list
            keyCredsList.Add(credential);

            PatchSpKeyCredentials(spObjectId, keyCredsList);

            return credential.ToPSADCredential();
        }

        public PSADCredential CreateSpPasswordCredential(string spObjectId, PasswordCredential credential)
        {
            ValidatePasswordCredential(credential);

            var passwordCredsList = GetSpPasswordCredentials(spObjectId);

            // Add new PasswordCredential to existing KeyCredential list
            passwordCredsList.Add(credential);

            PatchSpPasswordCredentials(spObjectId, passwordCredsList);

            return credential.ToPSADCredential();
        }

        public List<PSADCredential> GetSpCredentials(string spObjectId)
        {
            List<PSADCredential> CredentialList = new List<PSADCredential>();

            var keyCredsList = GetSpKeyCredentials(spObjectId);
            CredentialList.AddRange(keyCredsList.Select(kc => kc.ToPSADCredential()));

            var passwordCredsList = GetSpPasswordCredentials(spObjectId);
            CredentialList.AddRange(passwordCredsList.Select(pc => pc.ToPSADCredential()));

            return CredentialList;
        }

        public void RemoveSpCredentialByKeyId(string spObjectId, Guid keyId)
        {
            var keyCredsList = GetSpKeyCredentials(spObjectId);

            var toBeDeletedKeyCred = keyCredsList.Find(kc => Guid.Parse(kc.KeyId) == keyId);

            if (toBeDeletedKeyCred != null)
            {
                keyCredsList.Remove(toBeDeletedKeyCred);
                PatchSpKeyCredentials(spObjectId, keyCredsList);
            }
            else
            {
                var passwordCredsList = GetSpPasswordCredentials(spObjectId);
                var toBeDeletedPasswwordCred = passwordCredsList.Find(pc => Guid.Parse(pc.KeyId) == keyId);

                if (toBeDeletedPasswwordCred != null)
                {
                    passwordCredsList.Remove(toBeDeletedPasswwordCred);
                    PatchSpPasswordCredentials(spObjectId, passwordCredsList);
                }
            }
        }

        public void RemoveAllSpCredentials(string spObjectId)
        {
            PatchSpKeyCredentials(spObjectId, keyCredentails: null);
            PatchSpPasswordCredentials(spObjectId, passwordCredentials: null);
        }

        public string GetObjectIdFromSPN(string spn)
        {
            var odataQueryFilter = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.ServicePrincipalNames.Contains(spn));
            var sp = GraphClient.ServicePrincipals.List(odataQueryFilter).SingleOrDefault();
            if (sp == null)
            {
                throw new InvalidOperationException(String.Format(ProjectResources.ServicePrincipalWithSPNDoesntExist, spn));
            }

            return sp.ObjectId;
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
            IList<PasswordCredential> passwordCredentials = createParameters.PasswordCredentials != null
                ? createParameters.PasswordCredentials.Select(psCredential => psCredential.ToGraphPasswordCredential()).ToList()
                : null;

            IList<KeyCredential> keyCredentials = createParameters.KeyCredentials != null
                ? createParameters.KeyCredentials.Select(psCredential => psCredential.ToGraphKeyCredential()).ToList()
                : null;

            ServicePrincipalCreateParameters graphParameters = new ServicePrincipalCreateParameters
            {
                AppId = createParameters.ApplicationId.ToString(),
                AccountEnabled = createParameters.AccountEnabled,
                KeyCredentials = keyCredentials,
                PasswordCredentials = passwordCredentials
            };

            try
            {
                return GraphClient.ServicePrincipals.Create(graphParameters).ToPSADServicePrincipal();
            }
            catch (GraphErrorException ce)
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