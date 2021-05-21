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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Utilities;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using AuthenticationMessages = Microsoft.Azure.Commands.Common.Authentication.Properties.Resources;
using ProfileMessages = Microsoft.Azure.Commands.Profile.Properties.Resources;
using ResourceMessages = Microsoft.Azure.Commands.ResourceManager.Common.Properties.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class RMProfileClient
    {
        private IProfileOperations _profile;
        private IAzureTokenCache _cache;
        public Action<string> WarningLog;
        public Action<string> DebugLog;

        private IAzureContext DefaultContext
        {
            get
            {
                if(_profile == null || _profile.DefaultContext == null || _profile.DefaultContext.Account == null)
                {
                    throw new PSInvalidOperationException(ResourceMessages.RunConnectAccount);
                }
                return _profile.DefaultContext;
            }
        }

        public RMProfileClient(IProfileOperations profile)
        {
            _profile = profile;
            var context = _profile.DefaultContext;
            _cache = AzureSession.Instance.TokenCache;
            if (_profile != null && context != null &&
                context.TokenCache != null)
            {
                _cache = context.TokenCache;
            }
            SubscriptionAndTenantClient = new SubscriptionClientProxy(t => WriteWarningMessage(t));
        }

        /// <summary>
        /// Set the default context
        /// </summary>
        /// <param name="contextName">The name of the context to set as the default</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool TrySetDefaultContext(string contextName)
        {
            return _profile.TrySetDefaultContext(contextName);
        }
        /// <summary>
        /// Rename the given named context
        /// </summary>
        /// <param name="sourceContext">The name of the context to change</param>
        /// <param name="targetContext">The enw name for the context</param>
        /// <returns>true if the rename was successful, otherwise falkse</returns>
        public bool TryRenameContext(string sourceContext, string targetContext)
        {
            return _profile.TryRenameContext(sourceContext, targetContext);
        }

        /// <summary>
        /// Remove the given named context
        /// </summary>
        /// <param name="contextName">The context name</param>
        /// <returns>true if the context was found and removed, otherwise false</returns>
        public bool TryRemoveContext(string contextName)
        {
            return _profile.TryRemoveContext(contextName);
        }

        /// <summary>
        /// Remove the given context
        /// </summary>
        /// <param name="context">The context to remove</param>
        /// <returns>true if the context was found and removed, otherwise false</returns>
        public bool TryRemoveContext(IAzureContext context)
        {
            bool result = false;
            string contextName;
            if (_profile.TryFindContext(context, out contextName))
            {
                result = TryRemoveContext(contextName);
            }

            return result;
        }

        public AzureRmProfile Login(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenantId,
            string subscriptionId,
            string subscriptionName,
            SecureString password,
            bool skipValidation,
            Action<string> promptAction,
            string name = null,
            bool shouldPopulateContextList = true,
            int maxContextPopulation = Profile.ConnectAzureRmAccountCommand.DefaultMaxContextPopulation,
            string authScope = null)
        {
            IAzureSubscription newSubscription = null;
            IAzureTenant newTenant = null;
            string promptBehavior =
                (password == null &&
                 account.Type != AzureAccount.AccountType.AccessToken &&
                 account.Type != AzureAccount.AccountType.ManagedService &&
                 !account.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
                ? ShowDialog.Always : ShowDialog.Never;

            SubscritpionClientCandidates.Reset();

            bool needDataPlanAuthFirst = !string.IsNullOrEmpty(authScope);
            if(needDataPlanAuthFirst)
            {
                var token = AcquireAccessToken(account, environment, tenantId, password, promptBehavior, promptAction, authScope);
                promptBehavior = ShowDialog.Never;
            }

            if (skipValidation)
            {
                if (string.IsNullOrEmpty(subscriptionId) || string.IsNullOrEmpty(tenantId))
                {
                    throw new PSInvalidOperationException(Resources.SubscriptionOrTenantMissing);
                }

                newSubscription = new AzureSubscription
                {
                    Id = subscriptionId
                };

                newSubscription.SetOrAppendProperty(AzureSubscription.Property.Tenants, tenantId);
                newSubscription.SetOrAppendProperty(AzureSubscription.Property.Account, account.Id);

                newTenant = new AzureTenant
                {
                    Id = tenantId
                };
            }
            else
            {
                // (tenant and subscription are present) OR
                // (tenant is present and subscription is not provided)
                if (!string.IsNullOrEmpty(tenantId))
                {
                    Guid tempGuid = Guid.Empty;
                    if (!Guid.TryParse(tenantId, out tempGuid))
                    {
                        var tenants = ListAccountTenants(account, environment, password, promptBehavior, promptAction);
                        var homeTenants = tenants.FirstOrDefault(t => t.IsHome);
                        var tenant = homeTenants ?? tenants.FirstOrDefault();
                        if (tenant == null || tenant.Id == null)
                        {
                            string baseMessage = string.Format(ProfileMessages.TenantDomainNotFound, tenantId);
                            var typeMessageMap = new Dictionary<string, string>
                            {
                                { AzureAccount.AccountType.ServicePrincipal, string.Format(ProfileMessages.ServicePrincipalTenantDomainNotFound, account.Id) },
                                { AzureAccount.AccountType.User, ProfileMessages.UserTenantDomainNotFound },
                                { AzureAccount.AccountType.ManagedService, ProfileMessages.MSITenantDomainNotFound }
                            };
                            string typeMessage = typeMessageMap.ContainsKey(account.Type) ? typeMessageMap[account.Type] : string.Empty;
                            throw new ArgumentNullException(string.Format("{0} {1}", baseMessage, typeMessage));
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
                        subscriptionId,
                        subscriptionName,
                        true,
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
                    IAzureTenant tempTenant = null;
                    IAzureSubscription tempSubscription = null;
                    foreach (var tenant in tenants)
                    {
                        tempTenant = null;
                        tempSubscription = null;

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
                                WriteWarningMessage(string.Format(
                                    ProfileMessages.AccountIdMismatch,
                                    account.Id,
                                    tenant,
                                    accountId));
                                account.Id = accountId;
                                token = null;
                            }
                        }
                        catch(Exception e)
                        {
                            WriteWarningMessage(string.Format(ProfileMessages.UnableToAqcuireToken, tenant, e.Message));
                            WriteDebugMessage(string.Format(ProfileMessages.UnableToAqcuireToken, tenant, e.ToString()));
                        }

                        if (token != null &&
                            newTenant == null &&
                            TryGetTenantSubscription(token, account, environment, subscriptionId, subscriptionName, false, out tempSubscription, out tempTenant))
                        {
                            // If no subscription found for the given token/tenant，discard tempTenant value.
                            // Continue to look for matched subscripitons until one subscription retrived by its home tenant is found.
                            if (tempSubscription != null)
                            {
                                newSubscription = tempSubscription;
                                if (tempSubscription.GetTenant() == tempSubscription.GetHomeTenant())
                                {
                                    newTenant = tempTenant;
                                }
                            }
                        }
                    }
                    newSubscription = newSubscription ?? tempSubscription;
                    newTenant = newTenant ??
                        (newSubscription != null ? new AzureTenant() { Id = newSubscription.GetTenant() } : tempTenant);
                }
            }

            shouldPopulateContextList &= _profile.DefaultContext?.Account == null;
            if (newSubscription == null)
            {
                if (subscriptionId != null)
                {
                    throw new PSInvalidOperationException(String.Format(ResourceMessages.SubscriptionIdNotFound, account.Id, subscriptionId));
                }
                else if (subscriptionName != null)
                {
                    throw new PSInvalidOperationException(String.Format(ResourceMessages.SubscriptionNameNotFound, account.Id, subscriptionName));
                }

                var newContext = new AzureContext(account, environment, newTenant);
                if (!_profile.TrySetDefaultContext(name, newContext))
                {
                    WriteWarningMessage(string.Format(ProfileMessages.CannotSetDefaultContext, newContext.ToString()));
                }
            }
            else
            {
                var newContext = new AzureContext(newSubscription, account, environment, newTenant);
                if (!_profile.TrySetDefaultContext(name, newContext))
                {
                    WriteWarningMessage(string.Format(ProfileMessages.CannotSetDefaultContext, newContext.ToString()));
                }

                if (!skipValidation && !newSubscription.State.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
                {
                    WriteWarningMessage(string.Format(
                                   ProfileMessages.SelectedSubscriptionNotActive,
                                   newSubscription.State));
                }
            }

            _profile.DefaultContext.TokenCache = _cache;
            if (shouldPopulateContextList && maxContextPopulation != 0)
            {
                var defaultContext = _profile.DefaultContext;
                var subscriptions = maxContextPopulation > 0 ? ListSubscriptions(tenantId).Take(maxContextPopulation) : ListSubscriptions(tenantId);

                foreach (var subscription in subscriptions)
                {
                    IAzureTenant tempTenant = new AzureTenant()
                    {
                        Id = subscription.GetProperty(AzureSubscription.Property.Tenants)
                    };

                    var tempContext = new AzureContext(subscription, account, environment, tempTenant);
                    tempContext.TokenCache = _cache;
                    string tempName = null;
                    if (!_profile.TryGetContextName(tempContext, out tempName))
                    {
                        WriteWarningMessage(string.Format(Resources.CannotGetContextName, subscription.Id));
                        continue;
                    }

                    if (!_profile.TrySetContext(tempName, tempContext))
                    {
                        WriteWarningMessage(string.Format(Resources.CannotCreateContext, subscription.Id));
                    }
                }

                _profile.TrySetDefaultContext(defaultContext);
                _profile.TryRemoveContext("Default");
            }

            return _profile.ToProfile();
        }

        public IAzureContext SetCurrentContext(string subscriptionNameOrId, string tenantId, string name = null)
        {
            IAzureSubscription subscription = null;
            IAzureTenant tenant = null;
            Guid subscriptionId;
            IAzureContext context = new AzureContext();
            context.CopyFrom(_profile.DefaultContext);
            if (!string.IsNullOrWhiteSpace(subscriptionNameOrId))
            {
                if (Guid.TryParse(subscriptionNameOrId, out subscriptionId))
                {
                    TryGetSubscriptionById(tenantId, subscriptionNameOrId, out subscription);
                }
                else
                {
                    TryGetSubscriptionByName(tenantId, subscriptionNameOrId, out subscription);
                }

                if (subscription == null)
                {
                    throw new ArgumentException(ProfileMessages.SubscriptionOrTenantRequired);
                }

                var tenantFromSubscription = subscription.GetTenant();
                tenant = string.IsNullOrWhiteSpace(tenantId) ? (string.IsNullOrEmpty(tenantFromSubscription) ? context.Tenant : CreateTenant(tenantFromSubscription)):  CreateTenant(tenantId);
            }
            else if (!string.IsNullOrWhiteSpace(tenantId))
            {
                subscription = GetFirstSubscription(tenantId);
                tenant = CreateTenant(tenantId);
            }
            else
            {
                throw new ArgumentException(ProfileMessages.SubscriptionOrTenantRequired);
            }

            context.WithTenant(tenant).WithSubscription(subscription);
            _profile.TrySetDefaultContext(name, context);
            _profile.DefaultContext.ExtendedProperties.Clear();
            return context;
        }

        public List<AzureTenant> ListTenants(string tenant = "")
        {
            IList<AzureTenant> tenants = ListAccountTenants(DefaultContext.Account, DefaultContext.Environment, null, ShowDialog.Never, null);
            return tenants.Where(t => string.IsNullOrEmpty(tenant) ||
                                         tenant.Equals(t.Id.ToString(), StringComparison.OrdinalIgnoreCase) ||
                                         Array.Exists(t.GetPropertyAsArray(AzureTenant.Property.Domains), e => tenant.Equals(e, StringComparison.OrdinalIgnoreCase)))
                                 .ToList();
        }

        public bool TryGetSubscriptionById(string tenantId, string subscriptionId, out IAzureSubscription subscription)
        {
            Guid subscriptionIdGuid;
            subscription = null;
            if (Guid.TryParse(subscriptionId, out subscriptionIdGuid))
            {
                var subscriptionList = ListSubscriptions(tenantId).Where(s => s.GetId() == subscriptionIdGuid);
                subscription = subscriptionList.FirstOrDefault(s => s.GetTenant() == s.GetHomeTenant()) ??
                    subscriptionList.FirstOrDefault();
            }
            return subscription != null;
        }

        public bool TryGetSubscriptionByName(string tenantId, string subscriptionName, out IAzureSubscription subscription)
        {
            IEnumerable<IAzureSubscription> subscriptionList = ListSubscriptions(tenantId);
            subscriptionList = subscriptionList.Where(s => s.Name.Equals(subscriptionName, StringComparison.OrdinalIgnoreCase));
            subscription = subscriptionList.FirstOrDefault(s => s.GetTenant() == s.GetHomeTenant()) ??
                subscriptionList.FirstOrDefault();
            return subscription != null;
        }

        private IAzureSubscription GetFirstSubscription(string tenantId)
        {
            IEnumerable<IAzureSubscription> subscriptionList = ListSubscriptions(tenantId);
            return subscriptionList.FirstOrDefault();
        }

        public IAzureEnvironment AddOrSetEnvironment(IAzureEnvironment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment", AuthenticationMessages.EnvironmentNeedsToBeSpecified);
            }

            if (AzureEnvironment.PublicEnvironments.ContainsKey(environment.Name))
            {
                throw new InvalidOperationException(
                    string.Format(AuthenticationMessages.ChangingDefaultEnvironmentNotSupported, "environment"));
            }

            IAzureEnvironment result = null;
            _profile.TrySetEnvironment(environment, out result);
            return result;
        }

        public List<IAzureEnvironment> ListEnvironments(string name)
        {
            var result = new List<IAzureEnvironment>();
            IAzureEnvironment environment;
            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddRange(_profile.Environments);
            }
            else if (_profile.TryGetEnvironment(name, out environment))
            {
                result.Add(environment);
            }

            return result;
        }

        public IAzureEnvironment RemoveEnvironment(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", AuthenticationMessages.EnvironmentNameNeedsToBeSpecified);
            }
            if (AzureEnvironment.PublicEnvironments.ContainsKey(name))
            {
                throw new ArgumentException(AuthenticationMessages.RemovingDefaultEnvironmentsNotSupported, "name");
            }

            IAzureEnvironment environment;
            if (_profile.TryRemoveEnvironment(name, out environment))
            {
                return environment;
            }
            else
            {
                throw new ArgumentException(string.Format(AuthenticationMessages.EnvironmentNotFound, name), "name");
            }
        }

        public IAccessToken AcquireAccessToken(string tenantId, Action<string> promptAction = null)
        {
            return AcquireAccessToken(
                _profile.DefaultContext.Account,
                _profile.DefaultContext.Environment,
                tenantId, null,
                ShowDialog.Auto,
                promptAction);
        }

        public IEnumerable<IAzureSubscription> ListSubscriptions(string tenantIdOrDomain = "")
        {
            List<AzureTenant> tenants = string.IsNullOrEmpty(tenantIdOrDomain) ? ListTenants(tenantIdOrDomain) :
    new List<AzureTenant>() { CreateTenant(tenantIdOrDomain) };

            List<IAzureSubscription> subscriptions = new List<IAzureSubscription>();

            foreach (var tenant in tenants)
            {
                try
                {
                    subscriptions.AddRange(
                        ListAllSubscriptionsForTenant(
                            (tenant.GetId() == Guid.Empty) ? tenant.Directory : tenant.Id.ToString()));
                }
                catch (AadAuthenticationException e)
                {
                    WriteWarningMessage(string.Format(
                        ProfileMessages.UnableToLogin,
                        _profile.DefaultContext.Account,
                        tenant));
                    WriteDebugMessage(e.ToString());
                }

            }

            return subscriptions;
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

        private IAccessToken AcquireAccessToken(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenantId,
            SecureString password,
            string promptBehavior,
            Action<string> promptAction,
            string resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
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
                _cache,
                resourceId);
        }

        private bool TryGetTenantSubscription(IAccessToken accessToken,
            IAzureAccount account,
            IAzureEnvironment environment,
            string subscriptionId,
            string subscriptionName,
            bool isTenantPresent,
            out IAzureSubscription subscription,
            out IAzureTenant tenant)
        {
            subscription = null;
            if (accessToken != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(subscriptionId))
                    {
                        subscription = SubscriptionAndTenantClient?.GetSubscriptionById(subscriptionId, accessToken, new AzureAccount { Id = accessToken.UserId }, environment);
                    }
                    else
                    {
                        var subscriptions = SubscriptionAndTenantClient?.ListAllSubscriptionsForTenant(accessToken, new AzureAccount { Id = accessToken.UserId }, environment)?.ToList()
                            .Where(s => "enabled".Equals(s.State.ToString(), StringComparison.OrdinalIgnoreCase) || "warned".Equals(s.State.ToString(), StringComparison.OrdinalIgnoreCase));

                        account.SetProperty(AzureAccount.Property.Subscriptions, subscriptions.Select(i => i.GetId().ToString()).ToArray());

                        if (subscriptions.Any())
                        {
                            if (!string.IsNullOrEmpty(subscriptionName))
                            {
                                subscription = subscriptions.FirstOrDefault(
                                    s => s.Name.Equals(subscriptionName, StringComparison.OrdinalIgnoreCase));
                            }
                            else
                            {
                                if (subscriptions.Count() > 1)
                                {
                                    WriteWarningMessage(string.Format(
                                        "TenantId '{0}' contains more than one active subscription. First one will be selected for further use. " +
                                        "To select another subscription, use Set-AzContext.",
                                        accessToken.TenantId));
                                }
                                subscription = subscription ?? subscriptions.First();
                            }
                        }
                    }
                }
                catch (CloudException ex)
                {
                    //Error "InvalidAuthenticationTokenTenant" means tenant and subscription mismatches.
                    //If tenant is not present, we're iterating all tenants until finding right tenant for specified subscription,
                    //in this case, InvalidAuthenticationTokenTenant message is expected and we should ignore it.
                    if (isTenantPresent || !string.Equals(ex.Body?.Code, "InvalidAuthenticationTokenTenant", StringComparison.OrdinalIgnoreCase))
                    {
                        WriteWarningMessage(ex.Message);
                        WriteDebugMessage(ex.ToString());
                    }
                }

                if (subscription != null)
                {
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
            }
            tenant = null;
            return false;
        }

        private List<AzureTenant> ListAccountTenants(
            IAzureAccount account,
            IAzureEnvironment environment,
            SecureString password,
            string promptBehavior,
            Action<string> promptAction)
        {
            IList<AzureTenant> result = new List<AzureTenant>();
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

                result = SubscriptionAndTenantClient?.ListAccountTenants(commonTenantToken, environment);
            }
            catch(Exception e)
            {
                WriteWarningMessage(string.Format(ProfileMessages.UnableToAqcuireToken, commonTenant, e.Message));
                WriteDebugMessage(string.Format(ProfileMessages.UnableToAqcuireToken, commonTenant, e.ToString()));
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

            return result.ToList();
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
            catch(Exception e)
            {
                WriteWarningMessage(string.Format(ProfileMessages.UnableToAqcuireToken, tenantId, e.Message));
                WriteDebugMessage(string.Format(ProfileMessages.UnableToAqcuireToken, tenantId, e.ToString()));
                return new List<AzureSubscription>();
            }

            return SubscriptionAndTenantClient?.ListAllSubscriptionsForTenant(accessToken, account, environment);
        }

        private void WriteWarningMessage(string message)
        {
            if (WarningLog != null)
            {
                WarningLog(message);
            }
        }

        private void WriteDebugMessage(string message)
        {
            if(DebugLog != null)
            {
                DebugLog(message);
            }
        }

        public ISubscriptionClientWrapper SubscriptionAndTenantClient = null;
    }
}
