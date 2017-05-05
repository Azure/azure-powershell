﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.ServiceManagemenet.Common
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
                        foreach (var environment in newProfile.EnvironmentTable.Values)
                        {
                            oldProfile.EnvironmentTable[environment.Name] = environment;
                        }
                        foreach (var subscription in newProfile.SubscriptionTable.Values)
                        {
                            oldProfile.SubscriptionTable[Guid.Parse(subscription.Id)] = subscription;
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
                Name = subscriptionId.ToString()
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
                azureSubscription.SetProperty(AzureSubscription.Property.StorageAccount, storageAccount);
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

            if (subscriptionsFromServer == null ||
                subscriptionsFromServer.Count ==0 )
            {
                throw new ArgumentException(Resources.NoSubscriptionFoundForTenant);
            }
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
                    var firstSubscription = Profile.SubscriptionTable.Values.FirstOrDefault();
                    if (firstSubscription != null)
                    {
                        SetSubscriptionAsDefault(firstSubscription.Name, firstSubscription.GetProperty(AzureSubscription.Property.Account));
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
                accounts = Profile.AccountTable.Values.ToList();
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
                    IAzureAccount remainingAccount = GetSubscriptionAccount(Guid.Parse(subscription.Id));
                    // There's no default account to use, remove the subscription.
                    if (remainingAccount == null)
                    {
                        // Warn the user if the removed subscription is the default one.
                        if (subscription.IsPropertySet(AzureSubscription.Property.Default))
                        {
                            Debug.Assert(subscription.Equals(Profile.DefaultSubscription));
                            WriteWarningMessage(Resources.RemoveDefaultSubscription);
                        }

                        Profile.SubscriptionTable.Remove(Guid.Parse(subscription.Id));
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
            if (!subscription.IsPropertySet(AzureSubscription.Property.Environment))
            {
                throw new ArgumentNullException("subscription.Environment", Resources.EnvironmentNeedsToBeSpecified);
            }
            // Validate environment
            GetEnvironmentOrDefault(subscription.GetProperty(AzureSubscription.Property.Environment));
            var subscriptionId = Guid.Parse(subscription.Id);
            if (Profile.SubscriptionTable.ContainsKey(subscriptionId))
            {
                Profile.SubscriptionTable[subscriptionId] = MergeSubscriptionProperties(subscription, Profile.SubscriptionTable[subscriptionId]);
            }
            else
            {
                Debug.Assert(subscription.IsPropertySet(AzureSubscription.Property.Account));
                if (!Profile.AccountTable.ContainsKey(subscription.GetProperty(AzureSubscription.Property.Account)))
                {
                    throw new KeyNotFoundException(string.Format("The specified account {0} does not exist in profile accounts", subscription.GetProperty(AzureSubscription.Property.Account)));
                }

                Profile.SubscriptionTable[subscriptionId] = subscription;
            }

            return Profile.SubscriptionTable[subscriptionId];
        }

        public IAzureSubscription RemoveSubscription(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", Resources.SubscriptionNameNeedsToBeSpecified);
            }

            var subscription = Profile.SubscriptionTable.Values.FirstOrDefault(s => s.Name == name);

            if (subscription == null)
            {
                throw new ArgumentException(string.Format(Resources.SubscriptionNameNotFoundMessage, name), "name");
            }
            else
            {
                return RemoveSubscription(subscription.GetId());
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

        public List<IAzureSubscription> RefreshSubscriptions(IAzureEnvironment environment)
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

            return Profile.SubscriptionTable.Values.ToList();
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
            IAzureSubscription subscription = Profile.SubscriptionTable.Values
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

            var subscription = Profile.SubscriptionTable.Values.FirstOrDefault(s => s.Name == name);

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
                    Microsoft.WindowsAzure.Commands.Utilities.Common.GeneralUtilities.ClearCurrentStorageAccount();
                }

                Profile.DefaultSubscription = subscription;
                Profile.DefaultSubscription.SetAccount(accountName);
                subscription.SetDefault();
            }

            return subscription;
        }

        public void ClearAll()
        {
            Profile.AccountTable.Clear();
            Profile.DefaultSubscription = null;
            Profile.EnvironmentTable.Clear();
            Profile.SubscriptionTable.Clear();
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
            return Profile.AccountTable.Where(a => a.Value.HasSubscription(subscriptionId))
                .Select(a => a.Value).ToList();
        }

        public List<IAzureSubscription> ImportPublishSettings(string filePath, string environmentName)
        {
            var subscriptions = ListSubscriptionsFromPublishSettingsFile(filePath, environmentName);
            if (subscriptions.Any())
            {
                foreach (var subscription in subscriptions)
                {
                    AzureAccount account = new AzureAccount
                    {
                        Id = subscription.GetAccount(),
                        Type = AzureAccount.AccountType.Certificate
                    };
                    account.SetOrAppendProperty(AzureAccount.Property.Subscriptions, subscription.Id.ToString());
                    AddOrSetAccount(account);

                    if (!Profile.SubscriptionTable.ContainsKey(subscription.GetId()))
                    {
                        AddOrSetSubscription(subscription);
                    }

                    if (Profile.DefaultSubscription == null)
                    {
                        Profile.DefaultSubscription = subscription;
                    }
                }
            }

            return subscriptions;
        }

        private List<IAzureSubscription> ListSubscriptionsFromPublishSettingsFile(string filePath, string environment)
        {
            if (string.IsNullOrEmpty(filePath) || !AzureSession.Instance.DataStore.FileExists(filePath))
            {
                throw new ArgumentException(Resources.FilePathIsNotValid, "filePath");
            }
            return PublishSettingsImporter.ImportAzureSubscription(AzureSession.Instance.DataStore.ReadFileAsStream(filePath), this, environment).ToList();
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

        private IEnumerable<AzureSubscription> ListSubscriptionsFromServer(IAzureAccount account, IAzureEnvironment environment, SecureString password, string promptBehavior)
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
                tenants = tenants ?? account.GetPropertyAsArray(AzureAccount.Property.Tenants);
                List<AzureSubscription> rdfeSubscriptions = ListServiceManagementSubscriptions(account, environment,
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
                environment.AdTenant, password, promptBehavior);

            using (SubscriptionClient SubscriptionClient = AzureSession.Instance.ClientFactory
                        .CreateCustomClient<SubscriptionClient>(
                            new TokenCloudCredentials(commonTenantToken.AccessToken),
                            environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ServiceManagement)))
            {
                var subscriptionListResult = SubscriptionClient.Subscriptions.List();
                return subscriptionListResult.Subscriptions.Where(s => s.SubscriptionStatus == WindowsAzure.Subscriptions.Models.SubscriptionStatus.Active ||
                                                                       s.SubscriptionStatus == WindowsAzure.Subscriptions.Models.SubscriptionStatus.Warned)
                                                           .Select(s => s.ActiveDirectoryTenantId)
                                                           .Where(s => !string.IsNullOrWhiteSpace(s))
                                                           .Distinct().ToArray();
            }
        }

        private IAzureSubscription MergeSubscriptionProperties(IAzureSubscription subscription1, IAzureSubscription subscription2)
        {
            if (subscription1 == null || subscription2 == null)
            {
                throw new ArgumentNullException("subscription1");
            }
            if (!string.Equals(subscription1.Id, subscription2.Id, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Subscription Ids do not match.");
            }
            AzureSubscription mergedSubscription = new AzureSubscription
            {
                Id = subscription1.Id,
                Name = subscription1.Name,
                State = (subscription1.State != null &&
                         subscription1.State.Equals(subscription2.State, StringComparison.OrdinalIgnoreCase)) ?
                        subscription1.State : null
            };

            mergedSubscription.SetAccount(subscription1.GetAccount() ?? subscription2.GetAccount());
            mergedSubscription.SetEnvironment(subscription1.GetEnvironment());
            var sub1Keys = (subscription1.ExtendedProperties == null || subscription1.ExtendedProperties.Count < 1) ? new string[0] : subscription1.ExtendedProperties.Keys;
            var sub2Keys = (subscription2.ExtendedProperties == null || subscription2.ExtendedProperties.Count < 1) ? new string[0] : subscription2.ExtendedProperties.Keys;

            // Merge all properties
            foreach (string propertyKey in sub1Keys.Union(sub2Keys))
            {
                string propertyValue = null;
                if (subscription1.IsPropertySet(propertyKey))
                {
                    propertyValue = subscription1.GetProperty(propertyKey);
                }
                else if (subscription2.IsPropertySet(propertyKey))
                {
                    propertyValue = subscription2.GetProperty(propertyKey);
                }

                if (propertyValue != null)
                {
                    mergedSubscription.SetProperty(propertyKey, propertyValue);
                }
            }

            var s1prods = subscription1.GetPropertyAsArray(AzureSubscription.Property.RegisteredResourceProviders) ?? new string[0];
            var s2prods = subscription2.GetPropertyAsArray(AzureSubscription.Property.RegisteredResourceProviders) ?? new string[0];
            // Merge RegisteredResourceProviders
            var registeredProviders = s1prods.Union(s2prods, StringComparer.CurrentCultureIgnoreCase);

            mergedSubscription.SetProperty(AzureSubscription.Property.RegisteredResourceProviders, registeredProviders.ToArray());
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
                OnPremise = environment1.OnPremise,
            };

            foreach (var profile in environment1.VersionProfiles.Intersect(environment2.VersionProfiles))
            {
                mergedEnvironment.VersionProfiles.Add(profile);
            }

            var e1Keys = (environment1.ExtendedProperties == null || environment1.ExtendedProperties.Count < 1) ? new string[0] : environment1.ExtendedProperties.Keys;
            var e2Keys = (environment2.ExtendedProperties == null || environment2.ExtendedProperties.Count < 1) ? new string[0] : environment2.ExtendedProperties.Keys;

            // Merge all properties
            foreach (string propertyKey in e1Keys.Union(e2Keys))
            {
                mergedEnvironment.ExtendedProperties[propertyKey] = environment1.ExtendedProperties[propertyKey] 
                    ?? environment2.ExtendedProperties[propertyKey];
            }

            // Merge all properties
                mergedEnvironment.ActiveDirectoryAuthority = environment1.ActiveDirectoryAuthority ?? environment2.ActiveDirectoryAuthority;
                mergedEnvironment.ActiveDirectoryServiceEndpointResourceId = environment1.ActiveDirectoryServiceEndpointResourceId ?? environment2.ActiveDirectoryServiceEndpointResourceId;
                mergedEnvironment.AdTenant = environment1.AdTenant ?? environment2.AdTenant;
                mergedEnvironment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = environment1.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix ?? environment2.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix;
                mergedEnvironment.AzureDataLakeStoreFileSystemEndpointSuffix = environment1.AzureDataLakeStoreFileSystemEndpointSuffix ?? environment2.AzureDataLakeStoreFileSystemEndpointSuffix;
                mergedEnvironment.AzureKeyVaultDnsSuffix = environment1.AzureKeyVaultDnsSuffix ?? environment2.AzureKeyVaultDnsSuffix;
                mergedEnvironment.AzureKeyVaultServiceEndpointResourceId = environment1.AzureKeyVaultServiceEndpointResourceId ?? environment2.AzureKeyVaultServiceEndpointResourceId;
                mergedEnvironment.GalleryUrl = environment1.GalleryUrl ?? environment2.GalleryUrl;
                mergedEnvironment.GraphUrl = environment1.GraphUrl ?? environment2.GraphUrl;
                mergedEnvironment.GraphEndpointResourceId = environment1.GraphEndpointResourceId ?? environment2.GraphEndpointResourceId;
                mergedEnvironment.ManagementPortalUrl = environment1.ManagementPortalUrl ?? environment2.ManagementPortalUrl;
                mergedEnvironment.PublishSettingsFileUrl = environment1.PublishSettingsFileUrl ?? environment2.PublishSettingsFileUrl;
                mergedEnvironment.ResourceManagerUrl = environment1.ResourceManagerUrl ?? environment2.ResourceManagerUrl;
                mergedEnvironment.ServiceManagementUrl = environment1.ServiceManagementUrl ?? environment2.ServiceManagementUrl;
                mergedEnvironment.SqlDatabaseDnsSuffix = environment1.SqlDatabaseDnsSuffix ?? environment2.SqlDatabaseDnsSuffix;
                mergedEnvironment.StorageEndpointSuffix = environment1.StorageEndpointSuffix ?? environment2.StorageEndpointSuffix;
                mergedEnvironment.TrafficManagerDnsSuffix = environment1.TrafficManagerDnsSuffix ?? environment2.TrafficManagerDnsSuffix;

            return mergedEnvironment;
        }

        private AzureAccount MergeAccountProperties(IAzureAccount account1, IAzureAccount account2)
        {
            if (account1 == null || account2 == null)
            {
                throw new ArgumentNullException("account1");
            }
            if (!string.Equals(account1.Id, account2.Id, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException(string.Format("Account Ids '{0}', '{1}' do not match.", account1.Id, account2.Id));
            }
            if (!string.Equals(account1.Type, account2.Type, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException(string.Format("Account1 types '{0}', '{1}' do not match for account id {2}", account1.Type, account2.Type, account1.Id));
            }
            AzureAccount mergeAccount = new AzureAccount
            {
                Id = account1.Id,
                Type = account1.Type
            };

            var e1Keys = (account1.ExtendedProperties == null || account1.ExtendedProperties.Count < 1) ? new string[0] : account1.ExtendedProperties.Keys;
            var e2Keys = (account2.ExtendedProperties == null || account2.ExtendedProperties.Count < 1) ? new string[0] : account2.ExtendedProperties.Keys;

            // Merge all properties
            foreach (string propertyKey in e1Keys.Union(e2Keys))
            {
                mergeAccount.ExtendedProperties[propertyKey] = account1.ExtendedProperties[propertyKey]
                    ?? account2.ExtendedProperties[propertyKey];
            }

            var tenants1 = account1.GetPropertyAsArray(AzureAccount.Property.Tenants);
            var tenants2 = account2.GetPropertyAsArray(AzureAccount.Property.Tenants);
            if (tenants1 != null || tenants2 != null)
            {
                var tenants = (tenants1 == null ? tenants2 : (tenants2 == null ? tenants1 : tenants1.Union(tenants2)));
                mergeAccount.SetProperty(AzureAccount.Property.Tenants, tenants.ToArray());
            }

            var subscriptions1 = account1.GetPropertyAsArray(AzureAccount.Property.Subscriptions);
            var subscriptions2 = account2.GetPropertyAsArray(AzureAccount.Property.Subscriptions);
            if (subscriptions1 != null || subscriptions2 != null)
            {
                var subscriptions = (subscriptions1 == null ? subscriptions2 : (subscriptions2 == null ? subscriptions1 : subscriptions1.Union(subscriptions2)));
                mergeAccount.SetProperty(AzureAccount.Property.Subscriptions, subscriptions.ToArray());
            }


            return mergeAccount;
        }

        private void CopyAccount(IAzureAccount sourceAccount, IAzureAccount targetAccount)
        {
            targetAccount.Id = sourceAccount.Id;
            targetAccount.Type = sourceAccount.Type;
        }

        private IEnumerable<AzureSubscription> ListServiceManagementSubscriptions(IAzureAccount account, IAzureEnvironment environment, SecureString password, string promptBehavior, string[] tenants)
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
                                AzureSubscription psSubscription = new AzureSubscription
                                {
                                    Id = subscription.SubscriptionId,
                                    Name = subscription.SubscriptionName,
                                };
                                psSubscription.SetEnvironment(environment.Name);
                                psSubscription.SetProperty(AzureSubscription.Property.Tenants,
                                    subscription.ActiveDirectoryTenantId);
                                psSubscription.SetAccount(tenantAccount.Id);
                                tenantAccount.SetOrAppendProperty(AzureAccount.Property.Subscriptions,
                                    new string[] { psSubscription.Id });
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
                return Profile.DefaultContext.Environment;
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
                return Profile.EnvironmentTable.Values.FirstOrDefault(e =>
                    e.IsEndpointSetToValue(AzureEnvironment.Endpoint.ServiceManagement, serviceEndpoint) ||
                    e.IsEndpointSetToValue(AzureEnvironment.Endpoint.ResourceManager, resourceEndpoint));
            }
        }

        public List<IAzureEnvironment> ListEnvironments(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Profile.EnvironmentTable.Values.ToList();
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
                var subscriptions = Profile.SubscriptionTable.Values.Where(s => s.GetEnvironment() == name).ToArray();
                foreach (var subscription in subscriptions)
                {
                    RemoveSubscription(subscription.GetId());
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