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
using RDFESubscriptionClient = Microsoft.WindowsAzure.Subscriptions.SubscriptionClient;
using CSMSubscriptionClient = Microsoft.Azure.Subscriptions.SubscriptionClient;

namespace Microsoft.WindowsAzure.Commands.Test.Profile
{
    public class MockRdfeSubscriptionClient : RDFESubscriptionClient
    {
        private IList<string> _subscriptions = new List<string>();

        public string Tenant { get; set; }

        public IList<string> ReturnedSubscriptions
        {
            get { return this._subscriptions; }

            set { this._subscriptions = value; }
        }

        protected override RDFESubscriptionClient WithHandler(ServiceClient<RDFESubscriptionClient> newClient, DelegatingHandler handler)
        {
            return newClient as RDFESubscriptionClient;
        }

        public override RDFESubscriptionClient WithHandler(DelegatingHandler handler)
        {
            return this;
        }

        public override Microsoft.WindowsAzure.Subscriptions.ISubscriptionOperations Subscriptions
        {
            get { return MockRdfeSubscriptionOperations.Create(this.ReturnedSubscriptions, this.Tenant); }
        }
    }
    public class MockRdfeSubscriptionOperations : Microsoft.WindowsAzure.Subscriptions.ISubscriptionOperations
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

        private WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse.Subscription CreateSubscription(string subscriptionId)
        {
            return new WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse.Subscription
            {
                SubscriptionId = subscriptionId,
                SubscriptionName = string.Format("Test Mock Subscription {0}", subscriptionId),
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Active,
                ActiveDirectoryTenantId = _tenant.ToString()
            };
        }

        public Task<WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse> ListAsync(System.Threading.CancellationToken cancellationToken)
        {
            var response = new WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse
            {
                StatusCode = HttpStatusCode.OK,
                Subscriptions = CreateSubscriptionList()
            };
            return Task.FromResult(response);
        }

        private IList<WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse.Subscription> CreateSubscriptionList()
        {
            var result = new List<WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse.Subscription>();
            foreach (var subscriptionId in this._subscriptions)
            {
                result.Add(CreateSubscription(subscriptionId));
            }

            return result;
        }
    }

    public class MockCsmSubscriptionClient : Microsoft.Azure.Subscriptions.SubscriptionClient
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

        public override Azure.Subscriptions.ISubscriptionOperations Subscriptions
        {
            get
            {
                return MockCsmSubscriptionOperations.Create(this.ReturnedSubscriptions);
            }
        }

        public override Azure.Subscriptions.ITenantOperations Tenants
        {
            get
            {
                return MockCsmTenantOperations.Create(this.ReturnedTenants);
            }
        }

        public override Azure.Subscriptions.SubscriptionClient WithHandler(DelegatingHandler handler)
        {
            return this;
        }
    }

    public class MockCsmTenantOperations : Microsoft.Azure.Subscriptions.ITenantOperations
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

        public Task<Azure.Subscriptions.Models.TenantListResult> ListAsync(System.Threading.CancellationToken cancellationToken)
        {
            var result = new Azure.Subscriptions.Models.TenantListResult
            {
                StatusCode = HttpStatusCode.OK,
                TenantIds = CreateTenantList()
            };

            return Task.FromResult(result);
        }

        private static Azure.Subscriptions.Models.TenantIdDescription CreateTenant(string tenantId)
        {
            return new Azure.Subscriptions.Models.TenantIdDescription
            {
                TenantId = tenantId,
                Id = tenantId
            };
        }

        private IList<Azure.Subscriptions.Models.TenantIdDescription> CreateTenantList()
        {
            var result = new List<Azure.Subscriptions.Models.TenantIdDescription>();
            foreach (var tenant in this._tenants)
            {
                result.Add(CreateTenant(tenant));
            }

            return result;
        }
    }

    public class MockCsmSubscriptionOperations : Microsoft.Azure.Subscriptions.ISubscriptionOperations
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

        public Task<Azure.Subscriptions.Models.GetSubscriptionResult> GetAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken)
        {
            Azure.Subscriptions.Models.Subscription subscriptionToReturn = null;
            var statusCode = HttpStatusCode.NotFound;
            if (_subscriptions.Contains(subscriptionId))
            {
                var foundSubscription = _subscriptions.IndexOf(subscriptionId);
                subscriptionToReturn = CreateSubscription(_subscriptions[foundSubscription]);
                statusCode = HttpStatusCode.OK;
            }

            var result = new Azure.Subscriptions.Models.GetSubscriptionResult
            {
                StatusCode = statusCode,
                Subscription = subscriptionToReturn
            };

            return Task.FromResult(result);
        }

        public Task<Azure.Subscriptions.Models.SubscriptionListResult> ListAsync(System.Threading.CancellationToken cancellationToken)
        {
            var result = new Azure.Subscriptions.Models.SubscriptionListResult
            {
                StatusCode = HttpStatusCode.OK,
                Subscriptions = CreateSubscriptionList()
            };

            return Task.FromResult(result);
        }

        public Task<Azure.Subscriptions.Models.SubscriptionListResult> ListNextAsync(string nextLink, System.Threading.CancellationToken cancellationToken)
        {
            var result = new Azure.Subscriptions.Models.SubscriptionListResult
            {
                StatusCode = HttpStatusCode.OK,
                Subscriptions = CreateSubscriptionList()
            };

            return Task.FromResult(result);
        }

        public Task<Azure.Subscriptions.Models.LocationListResult> ListLocationsAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken)
        {
            var result = new Azure.Subscriptions.Models.LocationListResult();
            result.Locations = new List<Azure.Subscriptions.Models.Location>();

            return Task.FromResult(result);
        }

        private static Azure.Subscriptions.Models.Subscription CreateSubscription(string subscriptionId)
        {
            return new Azure.Subscriptions.Models.Subscription
            {
                SubscriptionId = subscriptionId,
                State = "Ready",
                Id = subscriptionId,
                DisplayName = string.Format("Test Mock Subscription {0}", subscriptionId)
            };
        }

        private IList<Azure.Subscriptions.Models.Subscription> CreateSubscriptionList()
        {
            var result = new List<Azure.Subscriptions.Models.Subscription>();
            foreach (var subscriptionId in this._subscriptions)
            {
                result.Add(CreateSubscription(subscriptionId));
            }

            return result;
        }
    }

    public static class ProfileClientHelper
    {
        public static Microsoft.WindowsAzure.Subscriptions.SubscriptionClient CreateRdfeSubscriptionClient(
            Guid tenantToReturn = default(Guid), params string[] subscriptionsToReturn)
        {
            return new MockRdfeSubscriptionClient
            {
                ReturnedSubscriptions = subscriptionsToReturn,
                Tenant = tenantToReturn.ToString()
            };
        }

        public static Microsoft.Azure.Subscriptions.SubscriptionClient CreateCsmSubscriptionClient(
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
