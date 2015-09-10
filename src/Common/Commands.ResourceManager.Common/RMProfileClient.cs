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
using Microsoft.Azure.Commands.ResourceManager.Common.Properties;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class RMProfileClient
    {
        private AzureRMProfile _profile;

        public RMProfileClient(AzureRMProfile profile)
        {
            _profile = profile;
        }

        public AzureRMProfile Login(AzureAccount account, AzureEnvironment environment, string tenantId)
        {
            var tenant = string.IsNullOrEmpty(tenantId) ? AuthenticationFactory.CommonAdTenant : tenantId;

            var commonTenantToken = AzureSession.AuthenticationFactory.Authenticate(account, environment, tenant, null, ShowDialog.Auto);

            using (SubscriptionClient SubscriptionClient = AzureSession.ClientFactory.CreateCustomClient<SubscriptionClient>(
                new TokenCloudCredentials(commonTenantToken.AccessToken),
                environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ServiceManagement)))
            {
                var tenantListResult = SubscriptionClient.Tenants.List();

                if (!string.IsNullOrEmpty(tenantId) && !tenantListResult.TenantIds.Any(s => s.TenantId.Equals(tenantId, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException(string.Format(Resources.TenantNotFound, tenantId));
                }

                _profile.
                //ListResourceManagerSubscriptions


                //_profile.DefaultContext = new AzureContext();
            }

            return _profile;
        }

        public IEnumerable<string> GetTenantSubscriptions(AzureAccount account, AzureEnvironment environment, string tenantId, SecureString password)
        {
            try
            {
                var tenantAccount = new AzureAccount();
                CopyAccount(account, tenantAccount);
                var tenantToken = AzureSession.AuthenticationFactory.Authenticate(tenantAccount, environment, tenantId, password, ShowDialog.Never);
                if (string.Equals(tenantAccount.Id, account.Id, StringComparison.InvariantCultureIgnoreCase))
                {
                    tenantAccount = account;
                }

                tenantAccount.SetOrAppendProperty(AzureAccount.Property.Tenants, new string[] { tenantId });

                using (var subscriptionClient = AzureSession.ClientFactory.CreateCustomClient<SubscriptionClient>(
                            new TokenCloudCredentials(tenantToken.AccessToken),
                            environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
                {
                    var subscriptionListResult = subscriptionClient.Subscriptions.List();

                    return subscriptionListResult.Subscriptions.Select(s => s.SubscriptionId);
                }


            }
            catch (CloudException cEx)
            {
                WriteOrThrowAadExceptionMessage(cEx);
            }
            catch (AadAuthenticationException aadEx)
            {
                WriteOrThrowAadExceptionMessage(aadEx);
            }
        }

        private void CopyAccount(AzureAccount sourceAccount, AzureAccount targetAccount)
        {
            targetAccount.Id = sourceAccount.Id;
            targetAccount.Type = sourceAccount.Type;
        }

        private void WriteOrThrowAadExceptionMessage(AadAuthenticationException aadEx)
        {
            if (aadEx is AadAuthenticationFailedWithoutPopupException)
            {
                WriteDebugMessage(aadEx.Message);
            }
            else if (aadEx is AadAuthenticationCanceledException)
            {
                WriteWarningMessage(aadEx.Message);
            }
            else
            {
                throw aadEx;
            }
        }
    }
}
