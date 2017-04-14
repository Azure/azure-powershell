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
using Microsoft.Azure;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Subscriptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    /// <summary>
    /// Convenience client for azure profile and subscriptions.
    /// </summary>
    public class ProfileClient
    {
        public AzureSMProfile Profile { get; private set; }

        public Action<string> WarningLog;

        public Action<string> DebugLog;

        private void WriteDebugMessage(string message)
        {
            if (DebugLog != null)
            {
                DebugLog(message);
            }
        }

        private void WriteWarningMessage(string message)
        {
            if (WarningLog != null)
            {
                WarningLog(message);
            }
        }

        private void UpgradeProfile()
        {
            string oldProfileFilePath = Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.OldProfileFile);
            string oldProfileFilePathBackup = Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.OldProfileFileBackup);
            string newProfileFilePath = Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile);
            if (AzureSession.Instance.DataStore.FileExists(oldProfileFilePath))
            {
                string oldProfilePath = Path.Combine(AzureSession.Instance.ProfileDirectory,
                    AzureSession.Instance.OldProfileFile);

                try
                {
                    // Try to backup old profile
                    try
                    {
                        AzureSession.Instance.DataStore.CopyFile(oldProfilePath, oldProfileFilePathBackup);
                    }
                    catch
                    {
                        // Ignore any errors here
                    }

                    AzureSMProfile oldProfile = new AzureSMProfile(oldProfilePath);

                    if (AzureSession.Instance.DataStore.FileExists(newProfileFilePath))
                    {
                        // Merge profile files
                        AzureSMProfile newProfile = new AzureSMProfile(newProfileFilePath);
                        foreach (var environment in newProfile.Environments)
                        {
                            oldProfile.EnvironmentTable[environment.Name] = environment;
                        }
                        foreach (var subscription in newProfile.Subscriptions)
                        {
                            oldProfile.SubscriptionTable[subscription.GetId()] = subscription;
                        }
                        AzureSession.Instance.DataStore.DeleteFile(newProfileFilePath);
                    }

                    // If there were no load errors - delete backup file
                    if (oldProfile.ProfileLoadErrors.Count == 0)
                    {
                        try
                        {
                            AzureSession.Instance.DataStore.DeleteFile(oldProfileFilePathBackup);
                        }
                        catch
                        {
                            // Give up
                        }
                    }

                    // Save the profile to the disk
                    oldProfile.Save();

                    // Rename WindowsAzureProfile.xml to WindowsAzureProfile.json
                    AzureSession.Instance.DataStore.RenameFile(oldProfilePath, newProfileFilePath);

                }
                catch
                {
                    // Something really bad happened - try to delete the old profile
                    try
                    {
                        AzureSession.Instance.DataStore.DeleteFile(oldProfilePath);
                    }
                    catch
                    {
                        // Ignore any errors
                    }
                }

                // In case that we changed a disk profile, reload it
                if (Profile != null && Profile.ProfilePath == newProfileFilePath)
                {
                    Profile = new AzureSMProfile(Profile.ProfilePath);
                }
            }
        }

        public ProfileClient(AzureSMProfile profile)
        {
            Profile = profile;
            WarningLog = (s) => Debug.WriteLine(s);

            try
            {
                UpgradeProfile();
            }
            catch
            {
                // Should never fail in constructor
            }
        }

        #region Profile management

        /// <summary>
        /// Initializes AzureSMProfile using passed in certificate. The certificate
        /// is imported into a certificate store.
        /// </summary>
        /// <param name="environment">Environment object.</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="certificate">Certificate to use with profile.</param>
        /// <param name="storageAccount">Storage account name (optional).</param>
        /// <returns></returns>
        public void InitializeProfile(AzureEnvironment environment, Guid subscriptionId, X509Certificate2 certificate,
            string storageAccount)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            if (certificate == null)
            {
                throw new ArgumentNullException("certificate");
            }

            // Add environment if not public
            if (!AzureEnvironment.PublicEnvironments.ContainsKey(environment.Name))
            {
                AddOrSetEnvironment(environment);
            }

            // Add account
            var azureAccount = new AzureAccount
            {
                Id = certificate.Thumbprint,
                Type = AzureAccount.AccountType.Certificate
            };
            azureAccount.SetSubscriptions(subscriptionId.ToString());
            ImportCertificate(certificate);
            AddOrSetAccount(azureAccount);

            // Add subscription
            var azureSubscription = new AzureSubscription
            {
                Id = subscriptionId.ToString(),
                Name = subscriptionId.ToString(),
            };
            azureSubscription.SetEnvironment(environment.Name);
            if (!string.IsNullOrEmpty(storageAccount))
            {
                azureSubscription.SetStorageAccount(storageAccount);
            }
            azureSubscription.SetDefault();
            azureSubscription.SetAccount(certificate.Thumbprint);
            AddOrSetSubscription(azureSubscription);
        }

        /// <summary>
        /// Initializes AzureSMProfile using passed in access token.
        /// </summary>
        /// <param name="environment">Environment object.</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="accessToken">AccessToken to use with profile.</param>
        /// <param name="accountId">AccountId for the new account.</param>
        /// <param name="storageAccount">Storage account name (optional).</param>
        /// <returns></returns>
        public void InitializeProfile(AzureEnvironment environment, Guid subscriptionId, string accessToken,
            string accountId, string storageAccount)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            if (accessToken == null)
            {
                throw new ArgumentNullException("accessToken");
            }

            // Add environment if not public
            if (!AzureEnvironment.PublicEnvironments.ContainsKey(environment.Name))
            {
                AddOrSetEnvironment(environment);
            }

            // Add account
            var azureAccount = new AzureAccount
            {
                Id = accountId,
                Type = AzureAccount.AccountType.AccessToken
            };
            azureAccount.SetSubscriptions(subscriptionId.ToString());
            azureAccount.SetAccessToken(accessToken);
            AddOrSetAccount(azureAccount);

            // Add subscription
            var azureSubscription = new AzureSubscription
            {
                Id = subscriptionId.ToString(),
                Name = subscriptionId.ToString(),
            };
            azureSubscription.SetEnvironment(environment.Name);
            if (!string.IsNullOrEmpty(storageAccount))
            {
                azureSubscription.SetStorageAccount(storageAccount);
            }
            azureSubscription.SetDefault();
            azureSubscription.SetAccount(accountId);
            AddOrSetSubscription(azureSubscription);
        }

        /// <summary>
        /// Initializes AzureSMProfile using passed in account and optional password.
        /// </summary>
        /// <param name="environment">Environment object.</param>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="account">Azure account with AD username and tenant.</param>
        /// <param name="password">AD password (optional).</param>
        /// <param name="storageAccount">Storage account name (optional).</param>
        /// <returns></returns>
        public void InitializeProfile(AzureEnvironment environment, Guid subscriptionId, AzureAccount account,
            SecureString password, string storageAccount)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            if (account == null)
            {
                throw new ArgumentNullException("account");
            }

            // Add environment if not public
            if (!AzureEnvironment.PublicEnvironments.ContainsKey(environment.Name))
            {
                AddOrSetEnvironment(environment);
            }

            // Add account
            var azureAccount = AddAccountAndLoadSubscriptions(account, environment, password);

            // Add subscription
            if (!azureAccount.HasSubscription(subscriptionId))
            {
                throw new ArgumentException(string.Format(Resources.SubscriptionIdNotFoundMessage, subscriptionId));
            }
            var azureSubscription = GetSubscription(subscriptionId);
            if (!string.IsNullOrEmpty(storageAccount))
            {
                azureSubscription.SetStorageAccount(storageAccount);
            }
            AddOrSetSubscription(azureSubscription);
        }
        #endregion

        #region Account management

        public IAzureAccount AddAccountAndLoadSubscriptions(IAzureAccount account, IAzureEnvironment environment, SecureString password)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            if (account == null)
            {
                throw new ArgumentNullException("account");
            }

            var subscriptionsFromServer = ListSubscriptionsFromServer(
                                            account,
                                            environment,
                                            password,
                                            password == null ? ShowDialog.Always : ShowDialog.Never).ToList();

            // If account id is null the login failed
            if (account.Id != null)
            {
                // Update back Profile.Subscriptions
                foreach (var subscription in subscriptionsFromServer)
                {
                    AddOrSetSubscription(subscription);
                }

                if (Profile.DefaultSubscription == null)
                {
                    var firstSubscription = Profile.Subscriptions.FirstOrDefault();
                    if (firstSubscription != null)
                    {
                        SetSubscriptionAsDefault(firstSubscription.Name, firstSubscription.GetAccount());
                    }
                }

                return Profile.AccountTable[account.Id];
            }
            else
            {
                return null;
            }
        }

        public IAzureAccount AddOrSetAccount(IAzureAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("account", Resources.AccountNeedsToBeSpecified);
            }

            if (Profile.AccountTable.ContainsKey(account.Id))
            {
                Profile.AccountTable[account.Id] =
                    MergeAccountProperties(account, Profile.AccountTable[account.Id]);
            }
            else
            {
                Profile.AccountTable[account.Id] = account;
            }

            return Profile.AccountTable[account.Id];
        }

        public IAzureAccount GetAccountOrDefault(string accountName)
        {
            if (string.IsNullOrEmpty(accountName))
            {
                return Profile.DefaultContext.Account;
            }
            else if (Profile.AccountTable.ContainsKey(accountName))
            {
                return Profile.AccountTable[accountName];
            }
            else
            {
                throw new ArgumentException(string.Format("Account with name '{0}' does not exist.", accountName), "accountName");
            }
        }

        public IAzureAccount GetAccountOrNull(string accountName)
        {
            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentNullException("accountName");
            }

            if (Profile.AccountTable.ContainsKey(accountName))
            {
                return Profile.AccountTable[accountName];
            }
            else
            {
                return null;
            }
        }

        public IAzureAccount GetAccount(string accountName)
        {
            var account = GetAccountOrNull(accountName);

            if (account == null)
            {
                throw new ArgumentException(string.Format("Account with name '{0}' does not exist.", accountName), "accountName");
            }

            return account;
        }

        public IEnumerable<IAzureAccount> ListAccounts(string accountName)
        {
            List<IAzureAccount> accounts = new List<IAzureAccount>();

            if (!string.IsNullOrEmpty(accountName))
            {
                if (Profile.AccountTable.ContainsKey(accountName))
                {
                    accounts.Add(Profile.AccountTable[accountName]);
                }
            }
            else
            {
                accounts = Profile.Accounts.ToList();
            }

            return accounts;
        }

        public IAzureAccount RemoveAccount(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentNullException("accountId", Resources.UserNameNeedsToBeSpecified);
            }

            if (!Profile.AccountTable.ContainsKey(accountId))
            {
                throw new ArgumentException(Resources.UserNameIsNotValid, "accountId");
            }

            IAzureAccount account = Profile.AccountTable[accountId];
            Profile.AccountTable.Remove(account.Id);

            foreach (AzureSubscription subscription in account.GetSubscriptions(Profile).ToArray())
            {
                if (string.Equals(subscription.GetAccount(), accountId, StringComparison.InvariantCultureIgnoreCase))
                {
                    IAzureAccount remainingAccount = GetSubscriptionAccount(subscription.GetId());
                    // There's no default account to use, remove the subscription.
                    if (remainingAccount == null)
                    {
                        // Warn the user if the removed subscription is the default one.
                        if (subscription.IsPropertySet(AzureSubscription.Property.Default))
                        {
                            Debug.Assert(subscription.Equals(Profile.DefaultSubscription));
                            WriteWarningMessage(Resources.RemoveDefaultSubscription);
                        }

                        Profile.SubscriptionTable.Remove(subscription.GetId());
                    }
                    else
                    {
                        subscription.SetAccount(remainingAccount.Id);
                        AddOrSetSubscription(subscription);
                    }
                }
            }

            return account;
        }

        private IAzureAccount GetSubscriptionAccount(Guid subscriptionId)
        {
            List<IAzureAccount> accounts = ListSubscriptionAccounts(subscriptionId);
            IAzureAccount account = accounts.FirstOrDefault(a => a.Type != AzureAccount.AccountType.Certificate);

            if (account != null)
            {
                // Found a non-certificate account.
                return account;
            }

            // Use certificate account if its there.
            account = accounts.FirstOrDefault();

            return account;
        }

        #endregion

        #region Subscription management

        public IAzureSubscription AddOrSetSubscription(IAzureSubscription subscription)
        {
            if (subscription == null)
            {
                throw new ArgumentNullException("subscription", Resources.SubscriptionNeedsToBeSpecified);
            }
            if (subscription.GetEnvironment() == null)
            {
                throw new ArgumentNullException("subscription.Environment", Resources.EnvironmentNeedsToBeSpecified);
            }
            // Validate environment
            GetEnvironmentOrDefault(subscription.GetEnvironment());

            if (Profile.SubscriptionTable.ContainsKey(subscription.GetId()))
            {
                Profile.SubscriptionTable[subscription.GetId()] = MergeSubscriptionProperties(subscription, Profile.SubscriptionTable[subscription.GetId()]);
            }
            else
            {
                Debug.Assert(!string.IsNullOrEmpty(subscription.GetAccount()));
                if (!Profile.AccountTable.ContainsKey(subscription.GetAccount()))
                {
                    throw new KeyNotFoundException(string.Format("The specified account {0} does not exist in profile accounts", subscription.GetAccount()));
                }

                Profile.SubscriptionTable[subscription.GetId()] = subscription;
            }

            return Profile.SubscriptionTable[subscription.GetId()];
        }

        public IAzureSubscription RemoveSubscription(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", Resources.SubscriptionNameNeedsToBeSpecified);
            }

            var subscription = Profile.Subscriptions.FirstOrDefault(s => s.Name == name);

            if (subscription == null)
            {
                throw new ArgumentException(string.Format(Resources.SubscriptionNameNotFoundMessage, name), "name");
            }
            else
            {
                return RemoveSubscription(subscription.Id);
            }
        }

        public IAzureSubscription RemoveSubscription(Guid id)
        {
            if (!Profile.SubscriptionTable.ContainsKey(id))
            {
                throw new ArgumentException(string.Format(Resources.SubscriptionIdNotFoundMessage, id), "id");
            }

            var subscription = Profile.SubscriptionTable[id];

            if (subscription.IsPropertySet(AzureSubscription.Property.Default))
            {
                Debug.Assert(Profile.DefaultSubscription == subscription);
                WriteWarningMessage(Resources.RemoveDefaultSubscription);
            }

            Profile.SubscriptionTable.Remove(id);

            // Remove this subscription from its associated AzureAccounts
            List<IAzureAccount> accounts = ListSubscriptionAccounts(id);

            foreach (AzureAccount account in accounts)
            {
                account.RemoveSubscription(id);
                if (!account.IsPropertySet(AzureAccount.Property.Subscriptions))
                {
                    Profile.AccountTable.Remove(account.Id);
                }
            }

            return subscription;
        }

        public List<IAzureSubscription> RefreshSubscriptions(AzureEnvironment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            var subscriptionsFromServer = ListSubscriptionsFromServerForAllAccounts(environment);

            // Update back Profile.Subscriptions
            foreach (var subscription in subscriptionsFromServer)
            {
                // Resetting back default account
                if (Profile.SubscriptionTable.ContainsKey(subscription.GetId()))
                {
                    subscription.SetAccount(Profile.SubscriptionTable[subscription.GetId()].GetAccount());
                }
                AddOrSetSubscription(subscription);
            }

            return Profile.Subscriptions.ToList();
        }

        public IAzureSubscription GetSubscription(Guid id)
        {
            if (Profile.SubscriptionTable.ContainsKey(id))
            {
                return Profile.SubscriptionTable[id];
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.SubscriptionIdNotFoundMessage, id), "id");
            }
        }

        public IAzureSubscription GetSubscription(string name)
        {
            IAzureSubscription subscription = Profile.Subscriptions
                .FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (subscription != null)
            {
                return subscription;
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.SubscriptionNameNotFoundMessage, name), "name");
            }
        }

        public IAzureSubscription SetSubscriptionAsDefault(string name, string accountName)
        {
            if (name == null)
            {
                throw new ArgumentException(string.Format(Resources.InvalidSubscriptionName, name), "name");
            }

            var subscription = Profile.Subscriptions.FirstOrDefault(s => s.Name == name);

            if (subscription == null)
            {
                throw new ArgumentException(string.Format(Resources.SubscriptionNameNotFoundMessage, name), "name");
            }

            return SetSubscriptionAsDefault(subscription.GetId(), accountName);
        }

        public IAzureSubscription SetSubscriptionAsDefault(Guid id, string accountName)
        {
            IAzureSubscription subscription = GetSubscription(id);

            if (subscription != null)
            {
                if (subscription.IsPropertySet(AzureSubscription.Property.StorageAccount))
                {
                    GeneralUtilities.ClearCurrentStorageAccount();
                }

                Profile.DefaultSubscription = subscription;
                Profile.DefaultSubscription.SetAccount(accountName);
            }

            return subscription;
        }

        public void ClearAll()
        {
            Profile.Clear();
            Profile.Save();

            AzureSession.Instance.TokenCache.Clear();
        }

        public void ClearDefaultSubscription()
        {
            Profile.DefaultSubscription = null;
        }

        public void ImportCertificate(X509Certificate2 certificate)
        {
            AzureSession.Instance.DataStore.AddCertificate(certificate);
        }

        public List<IAzureAccount> ListSubscriptionAccounts(Guid subscriptionId)
        {
            return Profile.Accounts.Where(a => a.HasSubscription(subscriptionId)).ToList();
        }

        private IEnumerable<IAzureSubscription> ListSubscriptionsFromServerForAllAccounts(IAzureEnvironment environment)
        {
            // Get all AD accounts and iterate
            var accountNames = Profile.AccountTable.Keys;

            List<IAzureSubscription> subscriptions = new List<IAzureSubscription>();

            foreach (var accountName in accountNames.ToArray())
            {
                var account = Profile.AccountTable[accountName];

                if (account.Type != AzureAccount.AccountType.Certificate)
                {
                    subscriptions.AddRange(ListSubscriptionsFromServer(account, environment, null, ShowDialog.Never));
                }

                AddOrSetAccount(account);
            }

            if (subscriptions.Any())
            {
                return subscriptions;
            }
            else
            {
                return new AzureSubscription[0];
            }
        }

        private IEnumerable<IAzureSubscription> ListSubscriptionsFromServer(IAzureAccount account, IAzureEnvironment environment, SecureString password, string promptBehavior)
        {
            string[] tenants = null;
            try
            {
                if (!account.IsPropertySet(AzureAccount.Property.Tenants))
                {
                    tenants = LoadAccountTenants(account, environment, password, promptBehavior);
                }
                else
                {
                    var storedTenants = account.GetPropertyAsArray(AzureAccount.Property.Tenants);
                    if (account.Type == AzureAccount.AccountType.User && storedTenants.Count() == 1)
                    {
                        TracingAdapter.Information(Resources.AuthenticatingForSingleTenant, account.Id, storedTenants[0]);
                        AzureSession.Instance.AuthenticationFactory.Authenticate(account, environment, storedTenants[0], password,
                            promptBehavior);
                    }
                }
            }
            catch (AadAuthenticationException aadEx)
            {
                WriteOrThrowAadExceptionMessage(aadEx);
                return new AzureSubscription[0];
            }

            try
            {
                tenants = tenants ?? account.GetTenants();
                List<IAzureSubscription> rdfeSubscriptions = ListServiceManagementSubscriptions(account, environment,
                    password, ShowDialog.Never, tenants).ToList();

                // Set user ID
                foreach (var subscription in rdfeSubscriptions)
                {
                    account.SetOrAppendProperty(AzureAccount.Property.Subscriptions, subscription.Id.ToString());
                }

                if (rdfeSubscriptions.Any())
                {
                    return rdfeSubscriptions;
                }
                else
                {
                    return new AzureSubscription[0];
                }
            }
            catch (AadAuthenticationException aadEx)
            {
                WriteOrThrowAadExceptionMessage(aadEx);
                return new AzureSubscription[0];
            }
        }

        private string[] LoadAccountTenants(IAzureAccount account, IAzureEnvironment environment, SecureString password, string promptBehavior)
        {
            var commonTenantToken = AzureSession.Instance.AuthenticationFactory.Authenticate(account, environment,
                AuthenticationFactory.CommonAdTenant, password, promptBehavior);

            using (SubscriptionClient SubscriptionClient = AzureSession.Instance.ClientFactory
                        .CreateCustomClient<SubscriptionClient>(
                            new TokenCloudCredentials(commonTenantToken.AccessToken),
                            environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ServiceManagement)))
            {
                var subscriptionListResult = SubscriptionClient.Subscriptions.List();
                return subscriptionListResult.Subscriptions.Select(s => s.ActiveDirectoryTenantId).Distinct().ToArray();
            }
        }

        private IAzureSubscription MergeSubscriptionProperties(IAzureSubscription subscription1, IAzureSubscription subscription2)
        {
            if (subscription1 == null || subscription2 == null)
            {
                throw new ArgumentNullException("subscription1");
            }
            if (subscription1.Id != subscription2.Id)
            {
                throw new ArgumentException("Subscription Ids do not match.");
            }
            AzureSubscription mergedSubscription = new AzureSubscription
            {
                Id = subscription1.Id,
                Name = subscription1.Name,
                State = (subscription1.State != null &&
                         subscription1.State.Equals(subscription2.State, StringComparison.OrdinalIgnoreCase)) ?
                        subscription1.State : null,
            };

            foreach (var property in subscription1.ExtendedProperties.Keys.Union(subscription2.ExtendedProperties.Keys))
            {
                mergedSubscription.SetProperty(property, subscription1.IsPropertySet(property) ?
                    subscription1.GetProperty(property) : subscription2.GetProperty(property));
            }

            // Merge RegisteredResourceProviders
            var registeredProviders = subscription1.GetPropertyAsArray(AzureSubscription.Property.RegisteredResourceProviders)
                    .Union(subscription2.GetPropertyAsArray(AzureSubscription.Property.RegisteredResourceProviders), StringComparer.CurrentCultureIgnoreCase);

            mergedSubscription.SetProperty(AzureSubscription.Property.RegisteredResourceProviders, registeredProviders.ToArray());

            // Merge Tenants
            var tenants = subscription1.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                    .Union(subscription2.GetPropertyAsArray(AzureSubscription.Property.Tenants), StringComparer.CurrentCultureIgnoreCase);

            mergedSubscription.SetProperty(AzureSubscription.Property.Tenants, tenants.ToArray());

            return mergedSubscription;
        }

        private IAzureEnvironment MergeEnvironmentProperties(IAzureEnvironment environment1, IAzureEnvironment environment2)
        {
            if (environment1 == null || environment2 == null)
            {
                throw new ArgumentNullException("environment1");
            }
            if (!string.Equals(environment1.Name, environment2.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException("Environment names do not match.");
            }
            AzureEnvironment mergedEnvironment = new AzureEnvironment
            {
                Name = environment1.Name,
                ActiveDirectory = environment1.ActiveDirectory ?? environment2.ActiveDirectory,
                ActiveDirectoryServiceEndpointResourceId = environment1.ActiveDirectoryServiceEndpointResourceId ?? environment2.ActiveDirectoryServiceEndpointResourceId,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = environment1.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix ?? environment2.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix,
                AzureKeyVaultDnsSuffix = environment1.AzureKeyVaultDnsSuffix ?? environment2.AzureKeyVaultDnsSuffix,
                Gallery = environment1.Gallery ?? environment2.Gallery,
                GraphEndpointResourceId = environment1.GraphEndpointResourceId ?? environment2.GraphEndpointResourceId,
                AdTenant = environment1.AdTenant ?? environment2.AdTenant,
                AzureDataLakeStoreFileSystemEndpointSuffix = environment1.AzureDataLakeStoreFileSystemEndpointSuffix ?? environment2.AzureDataLakeStoreFileSystemEndpointSuffix,
                AzureKeyVaultServiceEndpointResourceId = environment1.AzureKeyVaultServiceEndpointResourceId ?? environment2.AzureKeyVaultServiceEndpointResourceId,
                Graph = environment1.Graph ?? environment2.Graph,
                ManagementPortal = environment1.ManagementPortal ?? environment2.ManagementPortal,
                OnPremise = environment1.OnPremise || environment2.OnPremise,
                PublishSettingsFile = environment1.PublishSettingsFile ?? environment2.PublishSettingsFile,
                ResourceManager = environment1.ResourceManager ?? environment2.ResourceManager,
                ServiceManagement = environment1.ServiceManagement ?? environment2.ServiceManagement,
                SqlDatabaseDnsSuffix = environment1.SqlDatabaseDnsSuffix ?? environment2.SqlDatabaseDnsSuffix,
                StorageEndpointSuffix = environment1.StorageEndpointSuffix ?? environment2.StorageEndpointSuffix,
                TrafficManagerDnsSuffix = environment1.TrafficManagerDnsSuffix ?? environment2.TrafficManagerDnsSuffix
            };

            // Merge all properties

            return mergedEnvironment;
        }

        private IAzureAccount MergeAccountProperties(IAzureAccount account1, IAzureAccount account2)
        {
            if (account1 == null || account2 == null)
            {
                throw new ArgumentNullException("account1");
            }
            if (!string.Equals(account1.Id, account2.Id, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException("Account Ids do not match.");
            }
            if (account1.Type != account2.Type)
            {
                throw new ArgumentException("Account1 types do not match.");
            }
            AzureAccount mergeAccount = new AzureAccount
            {
                Id = account1.Id,
                Type = account1.Type
            };

            foreach (var property in account1.ExtendedProperties.Keys.Union(account2.ExtendedProperties.Keys))
            {
                mergeAccount.SetProperty(property, account1.IsPropertySet(property) ?
                    account1.GetProperty(property) : account2.GetProperty(property));
            }


            // Merge Tenants
            var tenants = account1.GetPropertyAsArray(AzureAccount.Property.Tenants)
                    .Union(account2.GetPropertyAsArray(AzureAccount.Property.Tenants), StringComparer.CurrentCultureIgnoreCase);

            mergeAccount.SetProperty(AzureAccount.Property.Tenants, tenants.ToArray());

            // Merge Subscriptions
            var subscriptions = account1.GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                    .Union(account2.GetPropertyAsArray(AzureAccount.Property.Subscriptions), StringComparer.CurrentCultureIgnoreCase);

            mergeAccount.SetProperty(AzureAccount.Property.Subscriptions, subscriptions.ToArray());

            return mergeAccount;
        }

        private void CopyAccount(IAzureAccount sourceAccount, IAzureAccount targetAccount)
        {
            targetAccount.Id = sourceAccount.Id;
            targetAccount.Type = sourceAccount.Type;
        }

        private IEnumerable<IAzureSubscription> ListServiceManagementSubscriptions(IAzureAccount account, IAzureEnvironment environment, SecureString password, string promptBehavior, string[] tenants)
        {
            List<AzureSubscription> result = new List<AzureSubscription>();

            if (!environment.IsEndpointSet(AzureEnvironment.Endpoint.ServiceManagement))
            {
                return result;
            }

            foreach (var tenant in tenants)
            {
                try
                {
                    IAzureAccount tenantAccount = new AzureAccount();
                    CopyAccount(account, tenantAccount);
                    var tenantToken = AzureSession.Instance.AuthenticationFactory.Authenticate(tenantAccount, environment, tenant, password, ShowDialog.Never);
                    if (string.Equals(tenantAccount.Id, account.Id, StringComparison.InvariantCultureIgnoreCase))
                    {
                        tenantAccount = account;
                    }

                    tenantAccount.SetOrAppendProperty(AzureAccount.Property.Tenants, new string[] { tenant });
                    using (var subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomClient<SubscriptionClient>(
                            new TokenCloudCredentials(tenantToken.AccessToken),
                            environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ServiceManagement)))
                    {
                        var subscriptionListResult = subscriptionClient.Subscriptions.List();
                        foreach (var subscription in subscriptionListResult.Subscriptions)
                        {
                            // only add the subscription if it's actually in this tenant
                            if (subscription.ActiveDirectoryTenantId == tenant)
                            {
                                AzureSubscription psSubscription = new AzureSubscription();
                                tenantAccount.SetOrAppendProperty(AzureAccount.Property.Subscriptions,
                                    new string[] { psSubscription.Id.ToString() });
                                result.Add(psSubscription);
                            }
                        }
                    }

                    AddOrSetAccount(tenantAccount);
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

            return result;
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

        private void WriteOrThrowAadExceptionMessage(CloudException aadEx)
        {
            WriteDebugMessage(aadEx.Message);
        }

        #endregion

        #region Environment management

        public IAzureEnvironment GetEnvironmentOrDefault(string name)
        {
            if (string.IsNullOrEmpty(name) &&
                Profile.DefaultSubscription == null)
            {
                return AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            }
            else if (string.IsNullOrEmpty(name) &&
                Profile.DefaultSubscription != null)
            {
                return Profile.Context.Environment;
            }
            else if (Profile.EnvironmentTable.ContainsKey(name))
            {
                return Profile.EnvironmentTable[name];
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.EnvironmentNotFound, name));
            }
        }

        public IAzureEnvironment GetEnvironment(string name, string serviceEndpoint, string resourceEndpoint)
        {
            if (serviceEndpoint == null)
            {
                // Set to invalid value
                serviceEndpoint = Guid.NewGuid().ToString();
            }

            if (resourceEndpoint == null)
            {
                // Set to invalid value
                resourceEndpoint = Guid.NewGuid().ToString();
            }

            if (name != null)
            {
                if (Profile.EnvironmentTable.ContainsKey(name))
                {
                    return Profile.EnvironmentTable[name];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return Profile.Environments.FirstOrDefault(e =>
                    e.IsEndpointSetToValue(AzureEnvironment.Endpoint.ServiceManagement, serviceEndpoint) ||
                    e.IsEndpointSetToValue(AzureEnvironment.Endpoint.ResourceManager, resourceEndpoint));
            }
        }

        public List<IAzureEnvironment> ListEnvironments(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Profile.Environments.ToList();
            }
            else if (Profile.EnvironmentTable.ContainsKey(name))
            {
                return new[] { Profile.EnvironmentTable[name] }.ToList();
            }
            else
            {
                return new IAzureEnvironment[0].ToList();
            }
        }

        public IAzureEnvironment RemoveEnvironment(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", Resources.EnvironmentNameNeedsToBeSpecified);
            }
            if (AzureEnvironment.PublicEnvironments.ContainsKey(name))
            {
                throw new ArgumentException(Resources.RemovingDefaultEnvironmentsNotSupported, "name");
            }

            if (Profile.EnvironmentTable.ContainsKey(name))
            {
                var environment = Profile.EnvironmentTable[name];
                var subscriptions = Profile.Subscriptions.Where(s => s.GetEnvironment() == name).ToArray();
                foreach (var subscription in subscriptions)
                {
                    RemoveSubscription(subscription.Id);
                }
                Profile.EnvironmentTable.Remove(name);
                return environment;
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.EnvironmentNotFound, name), "name");
            }
        }

        public IAzureEnvironment AddOrSetEnvironment(IAzureEnvironment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment", Resources.EnvironmentNeedsToBeSpecified);
            }

            if (AzureEnvironment.PublicEnvironments.ContainsKey(environment.Name))
            {
                throw new InvalidOperationException(
                    string.Format(Resources.ChangingDefaultEnvironmentNotSupported, "environment"));
            }

            if (Profile.EnvironmentTable.ContainsKey(environment.Name))
            {
                Profile.EnvironmentTable[environment.Name] =
                    MergeEnvironmentProperties(environment, Profile.EnvironmentTable[environment.Name]);
            }
            else
            {
                Profile.EnvironmentTable[environment.Name] = environment;
            }

            return Profile.EnvironmentTable[environment.Name];
        }
        #endregion
    }
}