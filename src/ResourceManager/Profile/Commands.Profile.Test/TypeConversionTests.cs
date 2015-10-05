using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using Xunit;
using Xunit.Extensions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class TypeConversionTests
    {
       [Fact]
       [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertNullAzureSubscriptions()
        { 
            Assert.Null((PSAzureSubscription)null);
            var subscription = (PSAzureSubscription) (new AzureSubscription());
            Assert.NotNull(subscription);
            Assert.Null(subscription.CurrentStorageAccountName);
            Assert.Equal(Guid.Empty.ToString(), subscription.SubscriptionId);
            Assert.Null(subscription.SubscriptionName);
            Assert.Null(subscription.TenantId);
            Assert.NotNull(subscription.ToString());
        }

        [Theory, 
        InlineData(null, null, null, null, null),
        InlineData("user@contoso.org", "Test Subscription", "AzureCloud", "juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "AzureCloud", "AccountName=juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "AzureCloud", "key1 = value1; AccountName = juststorageaccountname", "juststorageaccountname")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertValidAzureSubscriptions(string account, string name, string environment, string storageAccount, string expectedAccountName)
        {
            var oldSubscription = new AzureSubscription()
            {
                Account = account,
                Environment = environment,
                Id = Guid.NewGuid(),
                Name = name
            };
            oldSubscription.SetProperty(AzureSubscription.Property.StorageAccount, storageAccount);
            oldSubscription.SetProperty(AzureSubscription.Property.Tenants, Guid.NewGuid().ToString());
            var subscription = (PSAzureSubscription) oldSubscription;
            Assert.Equal(oldSubscription.Name, subscription.SubscriptionName);
            Assert.Equal(oldSubscription.Id.ToString(), subscription.SubscriptionId);
            Assert.Equal(oldSubscription.GetProperty(AzureSubscription.Property.Tenants), subscription.TenantId);
            Assert.Equal(expectedAccountName, subscription.CurrentStorageAccountName);
            Assert.Equal(storageAccount, subscription.CurrentStorageAccount);
            Assert.NotNull(subscription.ToString());
        }

       [Fact]
       [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertNullPSAzureSubscriptions()
        { 
            Assert.Null((AzureSubscription)null);
            var subscription = (AzureSubscription) (new PSAzureSubscription());
            Assert.NotNull(subscription);
            Assert.False(subscription.IsPropertySet(AzureSubscription.Property.StorageAccount));
            Assert.False(subscription.IsPropertySet(AzureSubscription.Property.Tenants));
            Assert.Equal(Guid.Empty, subscription.Id);
            Assert.Null(subscription.Name);
        }

        [Theory, 
        InlineData(null, null),
        InlineData("Test Subscription", "juststorageaccountname"),
        InlineData("Test Subscription", "AccountName=juststorageaccountname")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertValidPSAzureSubscriptions(string name, string storageAccount)
        {
            var oldSubscription = new PSAzureSubscription()
            {
                CurrentStorageAccount = storageAccount,
                SubscriptionId = Guid.NewGuid().ToString(),
                SubscriptionName = name,
                TenantId = Guid.NewGuid().ToString()
            };
            var subscription = (AzureSubscription) oldSubscription;
            Assert.Equal(oldSubscription.SubscriptionName, subscription.Name);
            Assert.Equal(oldSubscription.SubscriptionId, subscription.Id.ToString());
            Assert.Equal(oldSubscription.TenantId, subscription.GetProperty(AzureSubscription.Property.Tenants));
            Assert.Equal(storageAccount, subscription.GetProperty(AzureSubscription.Property.StorageAccount));
        }

       [Fact]
       [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertNullAzureTenants()
        { 
            Assert.Null((PSAzureTenant)null);
            var tenant = (PSAzureTenant) (new AzureTenant());
            Assert.NotNull(tenant);
            Assert.Null(tenant.Domain);
            Assert.Equal(Guid.Empty.ToString(), tenant.TenantId);
            Assert.NotNull(tenant.ToString());
        }

        [Theory, 
        InlineData(null),
        InlineData("contoso.org")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertValidAzureTenants(string domain)
        {
            var oldTenant = new AzureTenant()
            {
                Domain = domain,
                Id = Guid.NewGuid(),
            };
            var tenant = (PSAzureTenant) oldTenant;
            Assert.Equal(oldTenant.Domain, tenant.Domain);
            Assert.Equal(oldTenant.Id.ToString(), tenant.TenantId);
            Assert.NotNull(tenant.ToString());
        }

       [Fact]
       [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertNullPSAzureTenants()
        { 
            Assert.Null((AzureTenant)null);
            var tenant = (AzureTenant) (new PSAzureTenant());
            Assert.NotNull(tenant);
            Assert.Null(tenant.Domain);
            Assert.Equal(Guid.Empty, tenant.Id);
        }

       [Theory, 
       InlineData(null),
       InlineData("contoso.org")]
       [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertValidPSAzureTenants(string domain)
        {
            var oldTenant = new PSAzureTenant()
            {
                Domain = domain,
                TenantId = Guid.NewGuid().ToString()
            };
            var tenant = (AzureTenant) oldTenant;
            Assert.Equal(oldTenant.Domain, tenant.Domain);
            Assert.Equal(oldTenant.TenantId, tenant.Id.ToString());
        }

               [Fact]
       [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertNullAzureAccounts()
        { 
            Assert.Null((PSAzureRmAccount)null);
            var account = (PSAzureRmAccount) (new AzureAccount());
            Assert.NotNull(account);
            Assert.Null(account.Id);
            Assert.Equal(default(AzureAccount.AccountType).ToString(), account.AccountType);
            Assert.Null(account.ToString());
        }

        [Theory, 
        InlineData(null, AzureAccount.AccountType.AccessToken),
        InlineData("user@contoso.org", AzureAccount.AccountType.User),
        InlineData("user@contoso.org", AzureAccount.AccountType.Certificate),
        InlineData("user@contoso.org", AzureAccount.AccountType.ServicePrincipal)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertValidAzureAccounts(string id, AzureAccount.AccountType type)
        {
            var oldAccount = new AzureAccount()
            {
                Type = type,
                Id = id
            };

            var account = (PSAzureRmAccount) oldAccount;
            Assert.Equal(oldAccount.Type.ToString(), account.AccountType);
            Assert.Equal(oldAccount.Id, account.Id);
            Assert.DoesNotThrow(() => account.ToString());
        }

       [Fact]
       [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertNullPSAzureAccounts()
        { 
            Assert.Null((AzureAccount)null);
            var account = (AzureAccount) (new PSAzureRmAccount());
            Assert.NotNull(account);
            Assert.Null(account.Id);
            Assert.Equal(default(AzureAccount.AccountType), account.Type);
        }

       [Theory, 
        InlineData(null, AzureAccount.AccountType.AccessToken),
        InlineData("user@contoso.org", AzureAccount.AccountType.User),
        InlineData("user@contoso.org", AzureAccount.AccountType.Certificate),
        InlineData("user@contoso.org", AzureAccount.AccountType.ServicePrincipal)]
       [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertValidPSAzureAccounts(string id, AzureAccount.AccountType type)
        {
            var oldAccount = new PSAzureRmAccount
            {
                Id = id,
                AccountType = type.ToString()
            };
            var account = (AzureAccount) oldAccount;
            Assert.Equal(oldAccount.AccountType, account.Type.ToString());
            Assert.Equal(oldAccount.Id, account.Id);
        }

       [Fact]
       [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertNullAzureContexts()
        { 
            Assert.Null((PSAzureContext)null);
            var context = (PSAzureContext) (new AzureContext(null, null, null, null));
            Assert.NotNull(context);
            Assert.Null(context.Account);
            Assert.Null(context.Tenant);
            Assert.Null(context.Environment);
            Assert.Null(context.Subscription);
            Assert.NotNull(context.ToString());
        }

        [Theory, 
        InlineData("user@contoso.org", "Test Subscription", "juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "AccountName=juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "key1 = value1; AccountName = juststorageaccountname", "juststorageaccountname")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertValidAzureContexts(string account, string subscriptionName, string storageAccount, string expectedAccountName)
        {
            string domain = GetDomainName(account);
            var tenantId = Guid.NewGuid();
            var oldContext = new AzureContext(

                account: new AzureAccount() {Id = account, Type = AzureAccount.AccountType.User},
                environment: AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                subscription: new AzureSubscription() {Id=Guid.NewGuid(), Account=account, Environment=EnvironmentName.AzureCloud, Name=subscriptionName},
                tenant: new AzureTenant() {Id=tenantId, Domain = domain} );
            oldContext.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, storageAccount);
            oldContext.Subscription.SetProperty(AzureSubscription.Property.Tenants, tenantId.ToString());
            var context = (PSAzureContext) oldContext;
            Assert.NotNull(context);
            Assert.NotNull(context.Account);
            Assert.Equal(oldContext.Account.Type.ToString(), context.Account.AccountType);
            Assert.Equal(oldContext.Account.Id, context.Account.Id);
            Assert.NotNull(context.Tenant);
            Assert.Equal(oldContext.Tenant.Domain, context.Tenant.Domain);
            Assert.Equal(oldContext.Tenant.Id.ToString(), context.Tenant.TenantId);
            Assert.NotNull(context.Subscription);
            Assert.Equal(oldContext.Subscription.Name, context.Subscription.SubscriptionName);
            Assert.Equal(oldContext.Subscription.Id.ToString(), context.Subscription.SubscriptionId);
            Assert.Equal(oldContext.Subscription.GetProperty(AzureSubscription.Property.Tenants), context.Subscription.TenantId);
            Assert.Equal(expectedAccountName, context.Subscription.CurrentStorageAccountName);
            Assert.Equal(storageAccount, context.Subscription.CurrentStorageAccount);
            Assert.NotNull(context.ToString());
        }

        private static string GetDomainName(string account)
        {
            string result = null;
            if (!string.IsNullOrWhiteSpace(account) && account.Contains("@"))
            {
                var parts = account.Split(new char[] {'@'}, 2, StringSplitOptions.RemoveEmptyEntries);
                result = parts[1];
            }

            return result;
        }

       [Fact]
       [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertNullPSAzureContexts()
        { 
            Assert.Null((AzureContext)null);
            var context = (AzureContext) (new PSAzureContext());
            Assert.NotNull(context);
            Assert.Null(context.Account);
            Assert.Null(context.Environment);
            Assert.Null(context.Subscription);
            Assert.Null(context.Tenant);
        }

        [Theory, 
        InlineData("user@contoso.org", "Test Subscription", "juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "AccountName=juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "key1 = value1; AccountName = juststorageaccountname", "juststorageaccountname")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void CanConvertValidPSAzureContexts(string account, string subscription, string storageAccount, string storageAccountName)
        {
            var tenantId = Guid.NewGuid();
            var subscriptionId = Guid.NewGuid();
            var domain = GetDomainName(account);
            var oldContext = new PSAzureContext()
            {
                Account = new PSAzureRmAccount
                {
                    Id = account,
                    AccountType = "User"
                },
                Environment = (PSAzureEnvironment)AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                Subscription = 
                new PSAzureSubscription {
                    CurrentStorageAccount = storageAccount,
                    CurrentStorageAccountName= storageAccountName,
                    SubscriptionId = subscriptionId.ToString(),
                    SubscriptionName = subscription,
                    TenantId = tenantId.ToString()
                },
                Tenant = new PSAzureTenant
                {
                    Domain=domain,
                    TenantId = tenantId.ToString()
                }
            };
            var context = (AzureContext) oldContext;
            Assert.NotNull(context);
            Assert.NotNull(context.Account);
            Assert.Equal(oldContext.Account.AccountType, context.Account.Type.ToString());
            Assert.Equal(oldContext.Account.Id, context.Account.Id);
            Assert.NotNull(context.Tenant);
            Assert.Equal(oldContext.Tenant.Domain, context.Tenant.Domain);
            Assert.Equal(oldContext.Tenant.TenantId, context.Tenant.Id.ToString());
            Assert.NotNull(context.Subscription);
            Assert.Equal(oldContext.Subscription.SubscriptionName, context.Subscription.Name);
            Assert.Equal(oldContext.Subscription.SubscriptionId, context.Subscription.Id.ToString());
            Assert.True(context.Subscription.IsPropertySet(AzureSubscription.Property.Tenants));
            Assert.Equal(oldContext.Subscription.TenantId, context.Subscription.GetProperty(AzureSubscription.Property.Tenants));
            Assert.True(context.Subscription.IsPropertySet(AzureSubscription.Property.StorageAccount));
            Assert.Equal(storageAccount, context.Subscription.GetProperty(AzureSubscription.Property.StorageAccount));
        }


    }
}
