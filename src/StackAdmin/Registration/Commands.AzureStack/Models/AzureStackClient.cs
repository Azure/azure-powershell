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

namespace Microsoft.Azure.Commands.AzureStack
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Management.AzureStack;
    using Microsoft.Azure.Management.AzureStack.Models;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Rest.Azure;

    public class AzureStackClient
    {
        private AzureStackManagementClient client;

        public const string Namespace = "Microsoft.AzureStack";
        public const string RegistrationsTypeName = Namespace + "/Registrations";

        public const string RegistrationsCmdletName = ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AzureStackRegistration";
        public const string ActivationKeyCmdletName = ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AzureStackActivationKey";
        public const string ProductsCmdletName = ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AzureStackProduct";
        public const string ProductDetailsCmdletName = ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AzureStackProductDetails";
        public const string CustomerSubscriptionsCmdletName = ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AzureStackCustomerSubscription";

        public AzureStackClient(IAzureContext context)
        {
            client = AzureSession.Instance.ClientFactory.CreateArmClient<AzureStackManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        public AzureStackClient() { }

        #region registrations
        public Registration CreateRegistration(string resourceGroupName, string registrationName, string token)
        {
            var param = new RegistrationParameter
            {
                Location = Registration.Location,
                RegistrationToken = token
            };

            return client.Registrations.CreateOrUpdate(resourceGroupName, registrationName, param);
        }

        public Registration UpdateRegistration(string resourceGroupName, string registrationName, string token)
        {
            var param = new RegistrationParameter
            {
                Location = Registration.Location,
                RegistrationToken = token
            };

            return client.Registrations.Update(resourceGroupName, registrationName, param);
        }

        public void DeleteRegistration(string resourceGroupName, string registrationName)
        {
            client.Registrations.Delete(resourceGroupName, registrationName);
        }

        public Registration GetRegistration(string resourceGroupName, string registrationName)
        {
            return client.Registrations.Get(resourceGroupName, registrationName);
        }

        public IPage<Registration> ListRegistrations(string resourceGroupName)
        {
            return client.Registrations.List(resourceGroupName);
        }

        public IPage<Registration> ListRegistrationsUsingNextLink(string nextLink)
        {
            return client.Registrations.ListNext(nextLink);
        }

        public ActivationKeyResult GetActivationKey(string resourceGroupName, string registrationName)
        {
            return client.Registrations.GetActivationKey(resourceGroupName, registrationName);
        }
        #endregion

        #region products
        public Product GetProduct(string resourceGroupName, string registrationName, string productName)
        {
            return client.Products.Get(resourceGroupName, registrationName, productName);
        }

        public IPage<Product> ListProducts(string resourceGroupName, string registrationName)
        {
            return client.Products.List(resourceGroupName, registrationName);
        }

        public IPage<Product> ListProductsUsingNextLink(string nextLink)
        {
            return client.Products.ListNext(nextLink);
        }

        public ExtendedProduct ListProductDetails(string resourceGroupName, string registrationName, string productName)
        {
            return client.Products.ListDetails(resourceGroupName, registrationName, productName);
        }
        #endregion

        #region customer subscriptions
        public CustomerSubscription CreateCustomerSubscription(string resourceGroupName, string registrationName, string subscriptionName, string tenantId)
        {
            var param = new CustomerSubscription
            {
                TenantId = tenantId
            };

            return client.CustomerSubscriptions.Create(resourceGroupName, registrationName, subscriptionName, param);
        }

        public void DeleteCustomerSubscription(string resourceGroupName, string registrationName, string subscriptionName)
        {
            client.CustomerSubscriptions.Delete(resourceGroupName, registrationName, subscriptionName);
        }

        public CustomerSubscription GetCustomerSubscription(string resourceGroupName, string registrationName, string subscriptionName)
        {
            return client.CustomerSubscriptions.Get(resourceGroupName, registrationName, subscriptionName);
        }

        public IPage<CustomerSubscription> ListCustomerSubscriptions(string resourceGroupName, string registrationNam)
        {
            return client.CustomerSubscriptions.List(resourceGroupName, registrationNam);
        }

        public IPage<CustomerSubscription> ListCustomerSubscriptionsUsingNextLink(string nextLink)
        {
            return client.CustomerSubscriptions.ListNext(nextLink);
        }
        #endregion
    }
}
