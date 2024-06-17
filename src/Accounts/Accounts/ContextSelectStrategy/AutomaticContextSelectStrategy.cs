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

using Microsoft.Azure.Commands.Profile.Properties;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Linq;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using ProfileMessages = Microsoft.Azure.Commands.Profile.Properties.Resources;
using Microsoft.Azure.Commands.Profile.Utilities;
using System.Security;
using Microsoft.Identity.Client;
using System.Management.Automation.Language;
using Azure.Core;
using Microsoft.Azure.Commands.Profile.Models;


namespace Microsoft.Azure.Commands.Profile.ContextSelectStrategy
{
    /// <summary>
    /// Select the first found subscription in the first found home tenant
    /// If no subscription found for the given tenant,
    /// Continue to look for matched subscripitons until one subscription is retrived
    /// </summary>
    public class AutomaticContextSelectStrategy : ContextSelectStrategy
    {
        RMProfileClient ProfileClient;

        public AutomaticContextSelectStrategy(RMProfileClient profileClient)
        {
            ProfileClient = profileClient;

        }

        public override (IAzureTenant, IAzureSubscription) GetDefaultTenantAndSubscription(ContextSelectParameter selectParameter)
        {  
            IAzureTenant defaultTenant = null;
            IAzureSubscription defaultSubscription = null;

            if (string.IsNullOrEmpty(selectParameter.TenantIdOrName))
            {
                (defaultTenant, defaultSubscription) = GetDefaultTenantAndSubscriptionForCurrentAccount(selectParameter);
            }
            // tenant is not provided, subscription may be provided 
            else
            // tenant is provided, subscription may be provided
            {
                (defaultTenant, defaultSubscription) = GetDefaultSubscriptionForSpecificTenant(selectParameter.Account, selectParameter.Environment,
                    selectParameter.TenantIdOrName, selectParameter.SubscriptionId, selectParameter.SubscriptionName,
                    selectParameter.Password,
                    selectParameter.PromptAction, selectParameter.PromptBehavior,
                    selectParameter.OpenIDConfigDoc);
            }
            WriteWarningMessage(string.Format(
                    "TenantId '{0}' may contain more than one active subscription. First one will be selected for further use. " +
                    "To select another subscription, use Set-AzContext.", defaultTenant.Id));
            WriteWarningMessage(
                "To override which subscription Connect-AzAccount selects by default, " +
                "use `Update-AzConfig -DefaultSubscriptionForLogin 00000000-0000-0000-0000-000000000000`. " +
                "Go to https://go.microsoft.com/fwlink/?linkid=2200610 for more information.");
            return (defaultTenant, defaultSubscription);
        }


        /// <summary>
        /// Get the first matched subscription from given subscription
        /// </summary>
        /// <param name="account"></param>
        /// <param name="environment"></param>
        /// <param name="tenantIdOrName"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="subscriptionName"></param>
        /// <param name="password"></param>
        /// <param name="promptAction"></param>
        /// <param name="promptBehavior"></param>
        /// <param name="openIDConfigDoc"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private (IAzureTenant, IAzureSubscription) GetDefaultSubscriptionForSpecificTenant(IAzureAccount account, IAzureEnvironment environment,
            string tenantIdOrName, string subscriptionId, string subscriptionName, SecureString password, Action<string> promptAction, string promptBehavior,
            IOpenIDConfiguration openIDConfigDoc)
        {
            IAzureTenant defaultTenant = null;
            IAzureSubscription defaultSubscription = null;
            IAccessToken token = null;
            try
            {
                token = ProfileClient.AcquireAccessToken(
                    account,
                    environment,
                    tenantIdOrName,
                    password,
                    promptBehavior,
                    promptAction);

                if (!Guid.TryParse(tenantIdOrName, out Guid _))
                {
                    try
                    {
                        var tid = openIDConfigDoc.TenantId;
                        token = new RawAccessToken()
                        {
                            AccessToken = token.AccessToken,
                            LoginType = token.LoginType,
                            TenantId = tid,
                            UserId = token.UserId,
                            HomeAccountId = token.HomeAccountId,
                        };

                        WriteDebugMessage(string.Format(ProfileMessages.TenantDomainToTenantIdMessage, tenantIdOrName, token.TenantId));
                        var tenantName = tenantIdOrName;
                        // tenantIdOrName -> TenantIdOnly
                        tenantIdOrName = token.TenantId;
                    }
                    finally
                    {
                        WriteDebugMessage(string.Format(ProfileMessages.OpenIDAbsoluteUriMessage, tenantIdOrName, openIDConfigDoc.AbsoluteUri));
                        WriteDebugMessage(string.Format(ProfileMessages.OpenIDConfigurationDocInJsonMessage, openIDConfigDoc.OpenIDConfigDoc));
                    }
                }
            }
            catch (Exception e)
            {
                string baseMessage = string.Format(ProfileMessages.TenantDomainNotFound, tenantIdOrName);
                var typeMessageMap = new Dictionary<string, string>
                            {
                                { AzureAccount.AccountType.ServicePrincipal, string.Format(ProfileMessages.ServicePrincipalTenantDomainNotFound, account.Id) },
                                { AzureAccount.AccountType.User, ProfileMessages.UserTenantDomainNotFound },
                                { AzureAccount.AccountType.ManagedService, ProfileMessages.MSITenantDomainNotFound }
                            };
                string typeMessage = typeMessageMap.ContainsKey(account.Type) ? typeMessageMap[account.Type] : string.Empty;
                throw new ArgumentNullException(string.Format($"{e.Message}{Environment.NewLine}{baseMessage} {typeMessage}"), e);
            }

            if (ProfileClient.TryGetTenantSubscription(
                token,
                account,
                environment,
                subscriptionId,
                subscriptionName,
                true,
                out defaultSubscription,
                out defaultTenant))
            {
                account.SetOrAppendProperty(AzureAccount.Property.Tenants, new[] { defaultTenant.Id.ToString() });

            }
            return (defaultTenant, defaultSubscription);
        }

        private (IAzureTenant, IAzureSubscription) GetDefaultTenantAndSubscriptionForCurrentAccount(ContextSelectParameter selectParameter)
        {

            IAzureTenant defaultTenant = null;
            IAzureSubscription defaultSubscription = null;

            var _queriedTenants = ProfileClient.ListAccountTenants(selectParameter.Account, selectParameter.Environment, selectParameter.Password, selectParameter.PromptBehavior, selectParameter.PromptAction).ToList();
            selectParameter.Account.SetProperty(AzureAccount.Property.Tenants, null);
            string accountId = null;
            IAzureTenant tempTenant = null;
            IAzureSubscription tempSubscription = null;

            foreach (var tenant in _queriedTenants)
            {
                tempTenant = null;
                tempSubscription = null;

                IAccessToken token = null;

                try
                {
                    token = ProfileClient.AcquireAccessToken(selectParameter.Account, selectParameter.Environment, tenant.Id, selectParameter.Password, ShowDialog.Auto, null);
                    if (accountId == null)
                    {
                        accountId = selectParameter.Account.Id;
                        selectParameter.Account.SetOrAppendProperty(AzureAccount.Property.Tenants, tenant.Id);
                    }
                    else if (accountId.Equals(selectParameter.Account.Id, StringComparison.OrdinalIgnoreCase))
                    {
                        selectParameter.Account.SetOrAppendProperty(AzureAccount.Property.Tenants, tenant.Id);
                    }
                    else
                    {   // if selectParameter.Account ID is different from the first tenant selectParameter.Account id we need to ignore current tenant

                        WriteWarningMessage(string.Format(
                            ProfileMessages.AccountIdMismatch,
                            selectParameter.Account.Id,
                            tenant.Id,
                            accountId));
                        selectParameter.Account.Id = accountId;
                        token = null;
                    }
                }
                catch (Exception e)
                {
                    WriteWarningMessage(string.Format(ProfileMessages.UnableToAqcuireToken, tenant.Id, e.Message));
                    WriteDebugMessage(string.Format(ProfileMessages.UnableToAqcuireToken, tenant.Id, e.ToString()));
                }
                if (token != null && defaultTenant == null &&
                    ProfileClient.TryGetTenantSubscription(token, selectParameter.Account, selectParameter.Environment, selectParameter.SubscriptionId, selectParameter.SubscriptionName, false, out tempSubscription, out tempTenant))
                {
                    // If no subscription found for the given token/tenant，discard tempTenant value.
                    // Continue to look for matched subscripitons until one subscription retrived by its home tenant is found.
                    if (tempSubscription != null)
                    {
                        defaultSubscription = tempSubscription;
                        if (tempSubscription.GetTenant() == tempSubscription.GetHomeTenant())
                        {
                            defaultTenant = tempTenant;
                        }
                    }
                }
            }
            defaultSubscription = defaultSubscription ?? tempSubscription;
            defaultTenant = defaultTenant ??
                (defaultSubscription != null ? new AzureTenant() { Id = defaultSubscription.GetTenant() } : tempTenant);

            return (defaultTenant, defaultSubscription);
        }

        private void WriteDebugMessage(string v) => ProfileClient.WriteDebugMessage(v);
        private void WriteWarningMessage(string v) => ProfileClient.WriteWarningMessage(v);
        private void WriteInformationMessage(string v) => ProfileClient.WriteInformationMessage(v);
    }
}