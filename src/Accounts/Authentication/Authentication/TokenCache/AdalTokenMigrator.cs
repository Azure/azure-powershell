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

using System;
using System.Linq;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Microsoft.Azure.Commands.Common.Authentication.Authentication.TokenCache
{
    public class AdalTokenMigrator
    {
        private const string TenantsString = "Tenants";

        private byte[] AdalToken { get; set; }

        private bool HasRegistered { get; set; }

        private Lazy<IAzureContextContainer> ContextContainerInitializer { get; set; }

        public AdalTokenMigrator(byte[] adalToken, Func<IAzureContextContainer> getContextContainer)
        {
            AdalToken = adalToken;
            ContextContainerInitializer = new Lazy<IAzureContextContainer>(getContextContainer);
        }

        public void MigrateFromAdalToMsal(string tokenCacheFile)
        {
            MsalCacheHelper cacheHelper = null;
            var builder = PublicClientApplicationBuilder.Create(Constants.PowerShellClientId);
            var clientApplication = builder.Build();
            clientApplication.UserTokenCache.SetBeforeAccess((TokenCacheNotificationArgs args) =>
            {
                if (AdalToken != null)
                {
                    try
                    {
                        args.TokenCache.DeserializeAdalV3(AdalToken);
                    }
                    catch (Exception)
                    {
                        //TODO:
                    }
                    finally
                    {
                        AdalToken = null;
                        if (!HasRegistered)
                        {
                            HasRegistered = true;
                            cacheHelper = MsalCacheHelperProvider.GetCacheHelper(tokenCacheFile);
                            cacheHelper.RegisterCache(clientApplication.UserTokenCache);
                        }
                    }
                }
            });
            clientApplication.UserTokenCache.SetAfterAccess((TokenCacheNotificationArgs args) =>
            {
                if(args.HasStateChanged)
                {
                    var bytes = args.TokenCache.SerializeAdalV3();
                }
            });


            var accounts = clientApplication.GetAccountsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            foreach (var account in accounts)
            {
                try
                {
                    var accountEnvironment = string.Format("https://{0}/", account.Environment);
                    var environment = AzureEnvironment.PublicEnvironments.Values.Where(e => e.ActiveDirectoryAuthority == accountEnvironment).FirstOrDefault();
                    if (environment == null)
                    {
                        // We cannot map the previous environment to one of the public environments
                        continue;
                    }

                    var scopes = new string[] { string.Format("{0}{1}", environment.ActiveDirectoryServiceEndpointResourceId, ".default") };

                    try
                    {
                        clientApplication.AcquireTokenSilent(scopes, account).ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                    catch //For MSA account, real AAD tenant must be specified, otherwise MSAL library will request token against its home tenant
                    {
                        var tenantId = GetTenantId(account.Username);
                        if(!string.IsNullOrEmpty(tenantId))
                        {
                            var uriBuilder = new UriBuilder(environment.ActiveDirectoryAuthority)
                            {
                                Path = tenantId
                            };
                            clientApplication.AcquireTokenSilent(scopes, account).WithTenantIdFromAuthority(uriBuilder.Uri).ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                        }
                    }
                    //TODO: Set HomeAccountId for migration
                }
                catch
                {
                    // Continue if we're unable to get the token for the current account
                    continue;
                }
            }
            cacheHelper?.UnregisterCache(clientApplication.UserTokenCache);
        }

        private string GetTenantId(string accountId)
        {
            var contextContainer = ContextContainerInitializer.Value;
            string tenantId = null;
            if (contextContainer != null)
            {
                var matchedAccount = contextContainer?.Accounts?.FirstOrDefault(account => string.Equals(account.Id, accountId, StringComparison.InvariantCultureIgnoreCase));
                if (matchedAccount != null && matchedAccount.ExtendedProperties.ContainsKey(TenantsString))
                {
                    tenantId = matchedAccount.ExtendedProperties[TenantsString]?.Split(',')?.FirstOrDefault();
                }
            }
            return tenantId;
        }
    }
}
