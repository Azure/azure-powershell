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
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Subscriptions.Rdfe;

namespace Microsoft.WindowsAzure.Commands.Test.Profile
{
    public class MockRdfeSubscriptionClient : Microsoft.Azure.Subscriptions.Rdfe.SubscriptionClient
    {
        private IList<string> _subscriptions = new List<string>();
        public string Tenant { get; set; }
        public IList<String> ReturnedSubscriptions
        {
            get { return this._subscriptions; }

            set { this._subscriptions = value; }
        }

        protected override SubscriptionClient WithHandler(ServiceClient<SubscriptionClient> newClient, DelegatingHandler handler)
        {
            return newClient as SubscriptionClient;
        }

        public override SubscriptionClient WithHandler(DelegatingHandler handler)
        {
            return this;
        }

        public override Microsoft.Azure.Subscriptions.Rdfe.ISubscriptionOperations Subscriptions
        {
            get { return MockRdfeSubscriptionOperations.Create(this.ReturnedSubscriptions, this.Tenant); }
        }
    }
    public class MockRdfeSubscriptionOperations : Microsoft.Azure.Subscriptions.Rdfe.ISubscriptionOperations
    {
        private List<string> _subscriptions = new List<string>();
        private string _tenant = Guid.NewGuid().ToString();

        private MockRdfeSubscriptionOperations()
        {
        }

        /// <summary>
        /// Create a subscription mock using the given set of subscriptions
        /// </summary>
        /// <param name="knownSubscriptions">The list of existing subscriptions.</param>
        /// <returns>A mock of RDFE subscription operations</returns>
        public static MockRdfeSubscriptionOperations Create(IList<string> knownSubscriptions, string tenant)
        {
            var operations = new MockRdfeSubscriptionOperations();
            foreach (var subscription in knownSubscriptions)
            {
                operations._subscriptions.Add(subscription);
            }

            operations._tenant = tenant;
            return operations;
        }

        private Azure.Subscriptions.Rdfe.Models.Subscription CreateSubscription(string subscriptionId)
        {
            return new Azure.Subscriptions.Rdfe.Models.Subscription
            {
                SubscriptionId = subscriptionId,
                SubscriptionName = string.Format("Test Mock Subscription {0}", subscriptionId),
                SubscriptionStatus = Microsoft.Azure.Subscriptions.Rdfe.Models.SubscriptionStatus.Active,
                ActiveDirectoryTenantId = _tenant.ToString()
            };
        }

        public Task<Azure.Subscriptions.Rdfe.Models.SubscriptionListOperationResponse> ListAsync(System.Threading.CancellationToken cancellationToken)
        {
            var response = new Azure.Subscriptions.Rdfe.Models.SubscriptionListOperationResponse
            {
                StatusCode = HttpStatusCode.OK,
                Subscriptions = CreateSubscriptionList()
            };
            return Task.FromResult(response);
        }

        private IList<Azure.Subscriptions.Rdfe.Models.Subscription> CreateSubscriptionList()
        {
            var result = new List<Azure.Subscriptions.Rdfe.Models.Subscription>();
            foreach (var subscriptionId in this._subscriptions)
            {
                result.Add(CreateSubscription(subscriptionId));
            }

            return result;
        }
    }

    public class MockCsmSubscriptionClient : Microsoft.Azure.Subscriptions.Csm.SubscriptionClient
    {
        private IList<string> _subscriptions = new List<string>();
        private IList<string> _tenants = new List<string>();
        public IList<String> ReturnedSubscriptions
        {
            get { return this._subscriptions; }

            set { this._subscriptions = value; }
        }

        public IList<String> ReturnedTenants
        {
            get { return this._tenants; }

            set { this._tenants = value; }
        }

        public override Azure.Subscriptions.Csm.ISubscriptionOperations Subscriptions
        {
            get
            {
                return MockCsmSubscriptionOperations.Create(this.ReturnedSubscriptions);
            }
        }

        public override Azure.Subscriptions.Csm.ITenantOperations Tenants
        {
            get
            {
                return MockCsmTenantOperations.Create(this.ReturnedTenants);
            }
        }

        public override Azure.Subscriptions.Csm.SubscriptionClient WithHandler(DelegatingHandler handler)
        {
            return this;
        }
    }

    public class MockCsmTenantOperations : Microsoft.Azure.Subscriptions.Csm.ITenantOperations
    {
        private IList<string> _tenants = new List<string>();

        /// <summary>
        /// Create a tenant mock using the given set of tenants
        /// </summary>
        /// <param name="knownTenants">The list of existing tenants.</param>
        /// <returns>A mock of CSM tenant operations</returns>
        public static MockCsmTenantOperations Create(IList<string> knownTenants)
        {
            var operations = new MockCsmTenantOperations();
            foreach (var tenant in knownTenants)
            {
                operations._tenants.Add(tenant);
            }

            return operations;
        }

        public Task<Azure.Subscriptions.Csm.Models.TenantListResult> ListAsync(System.Threading.CancellationToken cancellationToken)
        {
            var result = new Azure.Subscriptions.Csm.Models.TenantListResult
            {
                StatusCode = HttpStatusCode.OK,
                TenantIds = CreateTenantList()
            };

            return Task.FromResult(result);
        }

        private static Azure.Subscriptions.Csm.Models.TenantIdDescription CreateTenant(string tenantId)
        {
            return new Azure.Subscriptions.Csm.Models.TenantIdDescription
            {
                TenantId = tenantId,
                Id = tenantId
            };
        }

        private IList<Azure.Subscriptions.Csm.Models.TenantIdDescription> CreateTenantList()
        {
            var result = new List<Azure.Subscriptions.Csm.Models.TenantIdDescription>();
            foreach (var tenant in this._tenants)
            {
                result.Add(CreateTenant(tenant));
            }

            return result;
        }
    }

    public class MockCsmSubscriptionOperations : Microsoft.Azure.Subscriptions.Csm.ISubscriptionOperations
    {
        private IList<string> _subscriptions = new List<string>();

        /// <summary>
        /// Create a subscription mock using the given set of subscriptions
        /// </summary>
        /// <param name="knownSubscriptions">The list of existing subscriptions.</param>
        /// <returns>A mock of CSM subscription operations</returns>
        public static MockCsmSubscriptionOperations Create(IList<string> knownSubscriptions)
        {
            var operations = new MockCsmSubscriptionOperations();
            foreach (var subscription in knownSubscriptions)
            {
                operations._subscriptions.Add(subscription);
            }

            return operations;
        }

        public Task<Azure.Subscriptions.Csm.Models.GetSubscriptionResult> GetAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken)
        {
            Azure.Subscriptions.Csm.Models.Subscription subscriptionToReturn = null;
            var statusCode = HttpStatusCode.NotFound;
            if (_subscriptions.Contains(subscriptionId))
            {
                var foundSubscription = _subscriptions.IndexOf(subscriptionId);
                subscriptionToReturn = CreateSubscription(_subscriptions[foundSubscription]);
                statusCode = HttpStatusCode.OK;
            }

            var result = new Azure.Subscriptions.Csm.Models.GetSubscriptionResult
            {
                StatusCode = statusCode,
                Subscription = subscriptionToReturn
            };

            return Task.FromResult(result);
        }

        public Task<Azure.Subscriptions.Csm.Models.SubscriptionListResult> ListAsync(System.Threading.CancellationToken cancellationToken)
        {
            var result = new Azure.Subscriptions.Csm.Models.SubscriptionListResult
            {
                StatusCode = HttpStatusCode.OK,
                Subscriptions = CreateSubscriptionList()
            };

            return Task.FromResult(result);
        }

        private static Azure.Subscriptions.Csm.Models.Subscription CreateSubscription(string subscriptionId)
        {
            return new Azure.Subscriptions.Csm.Models.Subscription
            {
                SubscriptionId = subscriptionId,
                State = "Ready",
                Id = subscriptionId,
                DisplayName = string.Format("Test Mock Subscription {0}", subscriptionId)
            };
        }

        private IList<Azure.Subscriptions.Csm.Models.Subscription> CreateSubscriptionList()
        {
            var result = new List<Azure.Subscriptions.Csm.Models.Subscription>();
            foreach (var subscriptionId in this._subscriptions)
            {
                result.Add(CreateSubscription(subscriptionId));
            }

            return result;
        }
    }

    public static class ProfileClientHelper
    {
        public static Microsoft.Azure.Subscriptions.Rdfe.SubscriptionClient CreateRdfeSubscriptionClient(
            Guid tenantToReturn = default(Guid), params string[] subscriptionsToReturn)
        {
            return new MockRdfeSubscriptionClient
            {
                ReturnedSubscriptions = subscriptionsToReturn,
                Tenant = tenantToReturn.ToString()
            };
        }

        public static Microsoft.Azure.Subscriptions.Csm.SubscriptionClient CreateCsmSubscriptionClient(
            IList<string> subscriptionsToReturn, IList<string> tenantsToReturn)
        {
            return new MockCsmSubscriptionClient
            {
                ReturnedSubscriptions = subscriptionsToReturn,
                ReturnedTenants = tenantsToReturn
            };
        }
    }
}
