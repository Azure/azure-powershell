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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Interfaces;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Version2021_01_01.Utilities;
using Microsoft.Azure.Management.ResourceManager.Version2021_01_01;
using Microsoft.Azure.Management.ResourceManager.Version2021_01_01.Models;
using Microsoft.Azure.Management.ResourceManager.Version2021_01_01.Models.Utilities;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;

namespace Common.Authentication.Test.Cmdlets
{
    [Cmdlet(VerbsCommunications.Connect, "AzAccount")]
    public class ConnectAccount : AzureRMCmdlet
    {
        private IAzureTokenCache _cache;
        private IAzureEnvironment _environment;
        private IProfileOperations _profile;
        private PSCredential _credential;

        [Parameter(Mandatory = true)]
        public IAzureAccount Account { get; set; }

        [Parameter(Mandatory = false)]
        public string TenantId { get; set; }

        [Parameter(Mandatory = false)]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false)]
        public string SubscriptionName { get; set; }

        [Parameter(Mandatory = false)]
        public string UserName { get; set; }

        [Parameter(Mandatory = false)]
        public string Password { get; set; }

        [Parameter(Mandatory = false)]
        public string ApplicationId { get; set; }

        [Parameter(Mandatory = false)]
        public string CertificateThumbprint { get; set; }

        protected override void BeginProcessing()
        {
            _profile = new AzureRmAutosaveProfile(
                (DefaultProfile as AzureRmProfile),
                ProtectedFileProvider.CreateFileProvider(
                    Path.Combine(AzureSession.Instance.ARMProfileDirectory, AzureSession.Instance.ARMProfileFile),
                    FileProtection.ExclusiveWrite));
            var context = _profile.DefaultContext;
            _cache = AzureSession.Instance.TokenCache;
            if (_profile != null && context != null && context.TokenCache != null)
            {
                _cache = context.TokenCache;
            }

            _environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                _credential = new PSCredential(UserName, ConvertToSecureString(Password));
            }
            base.BeginProcessing();
        }

        public override void ExecuteCmdlet()
        {
            SecureString password = null;
            if (_credential != null)
            {
                Account.Id = _credential.UserName;
                password = _credential.Password;
            }

            if (!string.IsNullOrEmpty(ApplicationId))
            {
                Account.Id = ApplicationId;
            }

            if (!string.IsNullOrEmpty(CertificateThumbprint))
            {
                Account.SetThumbprint(CertificateThumbprint);
            }

            if (!string.IsNullOrEmpty(TenantId))
            {
                Account.SetProperty(AzureAccount.Property.Tenants, new[] { TenantId });
            }

#if NETSTANDARD
            if (!string.IsNullOrEmpty(Password))
            {
                Account.SetProperty(AzureAccount.Property.ServicePrincipalSecret, Password);
            }
#endif

            if (AzureRmProfileProvider.Instance.Profile == null)
            {
                ResourceManagerProfileProvider.InitializeResourceManagerProfile(true);
            }

            Login(
                Account,
                _environment,
                TenantId,
                SubscriptionId,
                SubscriptionName,
                password,
                (s) => Console.WriteLine(s));
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        private void Login(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenantId,
            string subscriptionId,
            string subscriptionName,
            SecureString password,
            Action<string> promptAction)
        {
            IAzureSubscription newSubscription = null;
            IAzureTenant newTenant = null;
            string promptBehavior =
                (password == null &&
                 account.Type != AzureAccount.AccountType.AccessToken &&
                 account.Type != AzureAccount.AccountType.ManagedService &&
                 !account.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
                ? ShowDialog.Always : ShowDialog.Never;

            // (tenant and subscription are present) OR
            // (tenant is present and subscription is not provided)
            if (!string.IsNullOrEmpty(tenantId))
            {
                Guid tempGuid = Guid.Empty;
                if (!Guid.TryParse(tenantId, out tempGuid))
                {
                    var tenant = ListAccountTenants(
                        account,
                        environment,
                        password,
                        promptBehavior,
                        promptAction)?.FirstOrDefault();
                    if (tenant == null || tenant.Id == null)
                    {
                        throw new ArgumentNullException(string.Format("Could not find tenant id for provided tenant domain '{0}'. Please ensure that " +
                                                                      "the provided service principal is found in the provided tenant domain.", tenantId));
                    }

                    tenantId = tenant.Id;
                }

                var token = AcquireAccessToken(
                    account,
                    environment,
                    tenantId,
                    password,
                    promptBehavior,
                    promptAction);
                if (TryGetTenantSubscription(
                    token,
                    account,
                    environment,
                    tenantId,
                    subscriptionId,
                    subscriptionName,
                    out newSubscription,
                    out newTenant))
                {
                    account.SetOrAppendProperty(AzureAccount.Property.Tenants, new[] { newTenant.Id.ToString() });
                }
            }
            // (tenant is not provided and subscription is present) OR
            // (tenant is not provided and subscription is not provided)
            else
            {
                var tenants = ListAccountTenants(account, environment, password, promptBehavior, promptAction)
                    .Select(s => s.Id.ToString()).ToList();
                account.SetProperty(AzureAccount.Property.Tenants, null);
                string accountId = null;

                foreach (var tenant in tenants)
                {
                    IAzureTenant tempTenant;
                    IAzureSubscription tempSubscription;

                    IAccessToken token = null;

                    try
                    {
                        token = AcquireAccessToken(account, environment, tenant, password, ShowDialog.Auto, null);
                        if (accountId == null)
                        {
                            accountId = account.Id;
                            account.SetOrAppendProperty(AzureAccount.Property.Tenants, tenant);
                        }
                        else if (accountId.Equals(account.Id, StringComparison.OrdinalIgnoreCase))
                        {
                            account.SetOrAppendProperty(AzureAccount.Property.Tenants, tenant);
                        }
                        else
                        {   // if account ID is different from the first tenant account id we need to ignore current tenant
                            account.Id = accountId;
                            token = null;
                        }
                    }
                    catch
                    {
                        // Unable to acquire token for tenant
                    }

                    if (token != null &&
                        newTenant == null &&
                        TryGetTenantSubscription(token, account, environment, tenant, subscriptionId, subscriptionName, out tempSubscription, out tempTenant))
                    {
                        // If no subscription found for the given token/tenant
                        // discard tempTenant value unless current token/tenant is the last one.
                        if (tempSubscription != null || tenant.Equals(tenants[tenants.Count - 1]))
                        {
                            newTenant = tempTenant;
                            newSubscription = tempSubscription;
                        }
                    }
                }
            }

            if (newSubscription == null)
            {
                if (subscriptionId != null)
                {
                    throw new PSInvalidOperationException(String.Format("The provided account {0} does not have access to subscription ID '{1}'. Please try logging in with different credentials or a different subscription ID.", account.Id, subscriptionId));
                }
                else if (subscriptionName != null)
                {
                    throw new PSInvalidOperationException(String.Format("The provided account {0} does not have access to subscription name '{1}'. Please try logging in with different credentials or a different subscription name.", account.Id, subscriptionName));
                }

                var newContext = new AzureContext(account, environment, newTenant);
                if (!_profile.TrySetDefaultContext(null, newContext))
                {
                    // Unable to set default context
                }
            }
            else
            {
                var newContext = new AzureContext(newSubscription, account, environment, newTenant);
                if (!_profile.TrySetDefaultContext(null, newContext))
                {
                    // Unable to set default context
                }

                if (!newSubscription.State.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
                {
                    // Selected subscription is not in an "enabled" state
                }
            }

            _profile.DefaultContext.TokenCache = _cache;
            var defaultContext = _profile.DefaultContext;
            var subscriptions = ListSubscriptions(tenantId).Take(25);
            foreach (var subscription in subscriptions)
            {
                IAzureTenant tempTenant = new AzureTenant()
                {
                    Id = subscription.GetTenant()
                };

                var tempContext = new AzureContext(subscription, account, environment, tempTenant);
                tempContext.TokenCache = _cache;
                string tempName = null;
                if (!_profile.TryGetContextName(tempContext, out tempName))
                {
                    // Unable to get context name for subscription
                    continue;
                }

                if (!_profile.TrySetContext(tempName, tempContext))
                {
                    // Cannot create a context for subscription
                }

                _profile.TrySetDefaultContext(defaultContext);
                _profile.TryRemoveContext("Default");
            }

            _profile.Dispose();
        }

        private List<AzureTenant> ListAccountTenants(
            IAzureAccount account,
            IAzureEnvironment environment,
            SecureString password,
            string promptBehavior,
            Action<string> promptAction)
        {
            List<AzureTenant> result = new List<AzureTenant>();
            var commonTenant = account.GetCommonTenant();
            try
            {
                var commonTenantToken = AcquireAccessToken(
                    account,
                    environment,
                    commonTenant,
                    password,
                    promptBehavior,
                    promptAction);

                SubscriptionClient subscriptionClient = null;
                try
                {
                    subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                        environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                        new TokenCredentials(commonTenantToken.AccessToken) as ServiceClientCredentials,
                        AzureSession.Instance.ClientFactory.GetCustomHandlers());
                    //TODO: Fix subscription client to not require subscriptionId
                    result = MergeTenants(account, subscriptionClient.Tenants.List(), commonTenantToken);
                }
                finally
                {
                    // In test mode, we are reusing the client since disposing of it will
                    // fail some tests (due to HttpClient being null)
                    if (subscriptionClient != null && !TestMockSupport.RunningMocked)
                    {
                        subscriptionClient.Dispose();
                    }
                }
            }
            catch
            {
                // Unable to acquire token for tenant
                if (account.IsPropertySet(AzureAccount.Property.Tenants))
                {
                    result =
                        account.GetPropertyAsArray(AzureAccount.Property.Tenants)
                            .Select(ti =>
                            {
                                var tenant = new AzureTenant();

                                Guid guid;
                                if (Guid.TryParse(ti, out guid))
                                {
                                    tenant.Id = ti;
                                    tenant.Directory = AccessTokenExtensions.GetDomain(account.Id);
                                }
                                else
                                {
                                    tenant.Directory = ti;
                                }

                                return tenant;
                            }).ToList();
                }
                if (!result.Any())
                {
                    throw;
                }

            }

            return result;
        }

        private IAccessToken AcquireAccessToken(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenantId,
            SecureString password,
            string promptBehavior,
            Action<string> promptAction)
        {
            if (account.Type == AzureAccount.AccountType.AccessToken)
            {
                tenantId = tenantId ?? account.GetCommonTenant();
                return new SimpleAccessToken(account, tenantId);
            }

            return AzureSession.Instance.AuthenticationFactory.Authenticate(
                account,
                environment,
                tenantId,
                password,
                promptBehavior,
                promptAction,
                new Dictionary<string, object>()
                {
                    {AuthenticationFactory.TokenCacheParameterName, _cache},
                    {AuthenticationFactory.CmdletContextParameterName,  _cmdletContext}
                });
        }

        private IEnumerable<IAzureSubscription> ListSubscriptions(string tenantIdOrDomain = "")
        {
            List<IAzureSubscription> subscriptions = new List<IAzureSubscription>();
            var tenants = ListTenants(tenantIdOrDomain);
            foreach (var tenant in tenants)
            {
                try
                {
                    subscriptions.AddRange(
                        ListAllSubscriptionsForTenant(
                            (tenant.GetId() == Guid.Empty) ? tenant.Directory : tenant.Id.ToString()));
                }
                catch (AadAuthenticationException)
                {
                    // Could not authenticate user account with given tenant. Subscriptions in this tenant will not be listed.
                }

            }

            return subscriptions;
        }

        private IEnumerable<AzureSubscription> ListAllSubscriptionsForTenant(
            string tenantId)
        {
            IAzureAccount account = _profile.DefaultContext.Account;
            IAzureEnvironment environment = _profile.DefaultContext.Environment;
            SecureString password = null;
            string promptBehavior = ShowDialog.Never;
            IAccessToken accessToken = null;
            try
            {
                accessToken = AcquireAccessToken(account, environment, tenantId, password, promptBehavior, null);
            }
            catch
            {
                // Unable to acquire token for tenant
                return new List<AzureSubscription>();
            }

            SubscriptionClient subscriptionClient = null;
            subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                    environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                    new TokenCredentials(accessToken.AccessToken) as ServiceClientCredentials,
                    AzureSession.Instance.ClientFactory.GetCustomHandlers());

            AzureContext context = new AzureContext(_profile.DefaultContext.Subscription, account, environment,
                CreateTenantFromString(tenantId, accessToken.TenantId));

            return subscriptionClient.ListAllSubscriptions().Select(s => s.ToAzureSubscription(context.Account, context.Environment, accessToken.TenantId));
        }

        private static AzureTenant CreateTenantFromString(string tenantOrDomain, string accessTokenTenantId)
        {
            AzureTenant result = new AzureTenant();
            Guid id;
            if (Guid.TryParse(tenantOrDomain, out id))
            {
                result.Id = tenantOrDomain;
            }
            else
            {
                result.Id = accessTokenTenantId;
                result.Directory = tenantOrDomain;
            }

            return result;
        }

        private List<AzureTenant> ListTenants(string tenant = "")
        {
            if (!string.IsNullOrEmpty(tenant))
            {
                return new List<AzureTenant>() { CreateTenant(tenant) };
            }

            List<AzureTenant> tenants = ListAccountTenants(_profile.DefaultContext.Account, _profile.DefaultContext.Environment, null, ShowDialog.Never, null);
            return tenants.Where(t => string.IsNullOrEmpty(tenant) ||
                                         tenant.Equals(t.Id.ToString(), StringComparison.OrdinalIgnoreCase) ||
                                         tenant.Equals(t.Directory, StringComparison.OrdinalIgnoreCase))
                                 .ToList();
        }

        private AzureTenant CreateTenant(string tenantIdOrDomain)
        {
            var tenant = new AzureTenant();
            Guid tenantIdGuid;
            if (Guid.TryParse(tenantIdOrDomain, out tenantIdGuid))
            {
                tenant.Id = tenantIdGuid.ToString();
            }
            else
            {
                tenant.Directory = tenantIdOrDomain;
            }
            return tenant;
        }

        private bool TryGetTenantSubscription(IAccessToken accessToken,
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenantId,
            string subscriptionId,
            string subscriptionName,
            out IAzureSubscription subscription,
            out IAzureTenant tenant)
        {
            using (var subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                        environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                        new TokenCredentials(accessToken.AccessToken) as ServiceClientCredentials,
                        AzureSession.Instance.ClientFactory.GetCustomHandlers()))
            {
                Subscription subscriptionFromServer = null;

                try
                {
                    if (subscriptionId != null)
                    {
                        subscriptionFromServer = subscriptionClient.Subscriptions.Get(subscriptionId);
                    }
                    else
                    {
                        var subscriptions = (subscriptionClient.ListAllSubscriptions().ToList() ??
                                                new List<Subscription>())
                                            .Where(s => "enabled".Equals(s.State.ToString(), StringComparison.OrdinalIgnoreCase) ||
                                                        "warned".Equals(s.State.ToString(), StringComparison.OrdinalIgnoreCase));

                        account.SetProperty(AzureAccount.Property.Subscriptions, subscriptions.Select(i => i.SubscriptionId).ToArray());

                        if (subscriptions.Any())
                        {
                            if (subscriptionName != null)
                            {
                                subscriptionFromServer = subscriptions.FirstOrDefault(
                                    s => s.DisplayName.Equals(subscriptionName, StringComparison.OrdinalIgnoreCase));
                            }
                            else
                            {
                                if (subscriptions.Count() > 1)
                                {
                                    // TenantId contains more than one active subscription. First one will be selected for further use.
                                }
                                subscriptionFromServer = subscriptions.First();
                            }
                        }
                    }
                }
                catch (CloudException ex)
                {
                    // Warning
                    if (ex != null) { }
                }

                if (subscriptionFromServer != null)
                {
                    subscription = new AzureSubscription
                    {
                        Id = subscriptionFromServer.SubscriptionId,
                        Name = subscriptionFromServer.DisplayName,
                        State = subscriptionFromServer.State.ToString()
                    };

                    subscription.SetAccount(accessToken.UserId);
                    subscription.SetEnvironment(environment.Name);
                    subscription.SetTenant(accessToken.TenantId);

                    tenant = new AzureTenant();
                    tenant.Id = accessToken.TenantId;
                    return true;
                }

                subscription = null;

                if (accessToken != null && accessToken.TenantId != null)
                {
                    tenant = new AzureTenant();
                    tenant.Id = accessToken.TenantId;
                    return true;
                }

                tenant = null;
                return false;
            }
        }

        public List<AzureTenant> MergeTenants(IAzureAccount account, IEnumerable<TenantIdDescription> tenants, IAccessToken token)
        {
            List<AzureTenant> result = null;
            if (tenants != null)
            {
                var existingTenants = new List<AzureTenant>();
                account.SetProperty(AzureAccount.Property.Tenants, null);
                tenants.ForEach((t) =>
                {
                    existingTenants.Add(new AzureTenant { Id = t.TenantId, Directory = token.GetDomain() });
                    account.SetOrAppendProperty(AzureAccount.Property.Tenants, t.TenantId);
                });

                result = existingTenants;
            }

            return result;
        }

        private SecureString ConvertToSecureString(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            var securePassword = new SecureString();

            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            securePassword.MakeReadOnly();
            return securePassword;
        }

        internal class SimpleAccessToken : IAccessToken
        {
            public const string _defaultTokenType = "Bearer";
            private string _tokenType;

            public string AccessToken { get; private set; }
            public string LoginType { get { return Microsoft.Azure.Commands.Common.Authentication.LoginType.OrgId; } }
            public string TenantId { get; private set; }
            public string UserId { get; private set; }

            public string HomeAccountId => throw new NotImplementedException();

            public IDictionary<string, string> ExtendedProperties => throw new NotImplementedException();

            public SimpleAccessToken(IAzureAccount account, string tenantId, string tokenType = _defaultTokenType)
            {
                if (account == null)
                {
                    throw new ArgumentNullException("account");
                }
                if (string.IsNullOrWhiteSpace(account.Id))
                {
                    throw new ArgumentOutOfRangeException("account", "AccountId must be provided to use an AccessToken credential.");
                }
                if (account.Type != AzureAccount.AccountType.AccessToken ||
                    !account.IsPropertySet(AzureAccount.Property.AccessToken))
                {
                    throw new ArgumentException("To create an access token credential, you must provide an access token account.");
                }
                this.UserId = account.Id;
                this._tokenType = tokenType;
                this.AccessToken = account.GetProperty(AzureAccount.Property.AccessToken);
                this.TenantId = tenantId;
            }

            public void AuthorizeRequest(Action<string, string> authTokenSetter)
            {
                authTokenSetter(_tokenType, AccessToken);
            }
        }
    }
}
