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

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using StorageModels = Microsoft.Azure.Management.Storage.Models;
using Track2 = Azure.ResourceManager.Storage;
using Track2Models = Azure.ResourceManager.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    public abstract class StorageAccountBaseCmdlet : AzureRMCmdlet
    {
        private StorageManagementClientWrapper storageClientWrapper;

        protected const string StorageAccountNounStr = "StorageAccount";
        protected const string StorageAccountKeyNounStr = StorageAccountNounStr + "Key";
        protected const string StorageAccountRuleNounStr = StorageAccountNounStr + "NetworkRule";
        protected const string StorageAccountRuleSetNounStr = StorageAccountRuleNounStr + "Set";
        protected const string StorageAccountFailoverNounStr = StorageAccountNounStr + "Failover";
        protected const string StorageAccountHierarchicalNamespaceUpgradeNounStr = StorageAccountNounStr + "HierarchicalNamespaceUpgrade";

        protected const string StorageAccountNameAlias = "StorageAccountName";
        protected const string AccountNameAlias = "AccountName";
        protected const string NameAlias = "Name";

        protected const string StorageAccountTypeAlias = "StorageAccountType";
        protected const string AccountTypeAlias = "AccountType";
        protected const string Account_TypeAlias = "Type";
        
        protected const string StorageAccountKeySourceStr = StorageAccountNounStr + "EncryptionKeySource";

        protected const string TagsAlias = "Tags";

        protected const string StorageAccountNameAvailabilityStr = "AzureRmStorageAccountNameAvailability";

        protected const string StorageUsageNounStr = "AzureRmStorageUsage";

        internal const string StandardGZRS = "Standard_GZRS";
        internal const string StandardRAGZRS = "Standard_RAGZRS";

        protected struct AccountAccessTier
        {
            internal const string Hot = "Hot";
            internal const string Cool = "Cool";
        }
        protected struct AzureBlobType
        {
            public const string BlockBlob = "blockBlob";
            public const string PageBlob = "pageBlob";
            public const string AppendBlob = "appendBlob";
        }
        protected struct ManagementPolicyAction
        {
            internal const string TierToCool = "TierToCool";
            internal const string TierToArchive = "TierToArchive";
            internal const string Delete = "Delete";
        }

        protected struct AccountIdentityType
        {
            internal const string SystemAssigned = "SystemAssigned";
            internal const string UserAssigned = "UserAssigned";
            internal const string SystemAssignedUserAssigned = "SystemAssignedUserAssigned";
            internal const string SystemAssignedUserAssignedTrack2 = "SystemAssigned, UserAssigned";
            internal const string None = "None";
        }

        protected struct RoutingChoiceType
        {
            internal const string MicrosoftRouting = "MicrosoftRouting";
            internal const string InternetRouting = "InternetRouting";
        }

        protected struct KeyType
        {
            internal const string Service = "Service";
            internal const string Account = "Account";
        }

        protected struct SkuNameType
        {
            internal const string StandardLRS = "Standard_LRS";
            internal const string StandardGRS = "Standard_GRS";
            internal const string StandardRagrs = "Standard_RAGRS";
            internal const string StandardZRS = "Standard_ZRS";
            internal const string PremiumLRS = "Premium_LRS";
            internal const string PremiumZRS = "Premium_ZRS";
            internal const string StandardGzrs = "Standard_GZRS";
            internal const string StandardRagzrs = "Standard_RAGZRS";
        }

        protected struct StorageKindType
        {
            internal const string Storage = "Storage";
            internal const string StorageV2 = "StorageV2";
            internal const string BlobStorage = "BlobStorage";
            internal const string FileStorage = "FileStorage";
            internal const string BlockBlobStorage = "BlockBlobStorage";
        }

        protected struct MinimumTlsVersionType
        {
            internal const string TLS10 = "TLS1_0";
            internal const string TLS11 = "TLS1_1";
            internal const string TLS12 = "TLS1_2";
        }


        [Flags]
        public enum EncryptionSupportServiceEnum
        {
            None = 0,
            Blob = 1,
            File = 2
        }

        protected struct DefaultSharePermissionType
        {
            internal const string None = "None";
            internal const string StorageFileDataSmbShareReader = "StorageFileDataSmbShareReader";
            internal const string StorageFileDataSmbShareContributor = "StorageFileDataSmbShareContributor";
            internal const string StorageFileDataSmbShareElevatedContributor = "StorageFileDataSmbShareElevatedContributor";
            internal const string StorageFileDataSmbShareOwner = "StorageFileDataSmbShareOwner";
        }

        public IStorageManagementClient StorageClient
        {
            get
            {
                if (storageClientWrapper == null)
                {
                    storageClientWrapper = new StorageManagementClientWrapper(DefaultProfile.DefaultContext);
                }

                this.storageClientWrapper.VerboseLogger = WriteVerboseWithTimestamp;
                this.storageClientWrapper.ErrorLogger = WriteErrorWithTimestamp;
                return storageClientWrapper.StorageManagementClient;
            }

            set { storageClientWrapper = new StorageManagementClientWrapper(value); }
        }

        private Track2StorageManagementClient _track2StorageManagementClient;
        public Track2StorageManagementClient StorageClientTrack2
        {
            get
            {
                return _track2StorageManagementClient ?? (_track2StorageManagementClient = new Track2StorageManagementClient(
                    Microsoft.Azure.Commands.Common.Authentication.AzureSession.Instance.ClientFactory,
                    DefaultContext));
            }

            set { _track2StorageManagementClient = value; }
        }

        public string SubscriptionId
        {
            get
            {
                return DefaultProfile.DefaultContext.Subscription.Id.ToString();
            }
        }


        protected static Track2Models.AccessTier ParseAccessTier(string accessTier)
        {
            Track2Models.AccessTier returnAccessTier;
            if (!Enum.TryParse<Track2Models.AccessTier>(accessTier, true, out returnAccessTier))
            {
                throw new ArgumentOutOfRangeException("AccessTier");
            }
            return returnAccessTier;
        }

        protected static Track2Models.Encryption ParseEncryption(bool storageEncryption = false, bool keyVaultEncryption = false, string keyName = null, string keyVersion = null, string keyVaultUri = null)
        {
            // TODO: Fix the KeySource value. It should be null or empty. Input KeyVault for a placeholder.
            Track2Models.Encryption accountEncryption =
                new Track2Models.Encryption(Track2Models.KeySource.MicrosoftKeyvault);

            if (storageEncryption)
            {
                accountEncryption.KeySource = Track2Models.KeySource.MicrosoftStorage;
            }
            if (keyVaultEncryption)
            {
                accountEncryption.KeySource = Track2Models.KeySource.MicrosoftKeyvault;
                accountEncryption.KeyVaultProperties = new Track2Models.KeyVaultProperties();
                accountEncryption.KeyVaultProperties.KeyName = keyName;
                accountEncryption.KeyVaultProperties.KeyVersion = keyVersion;
                accountEncryption.KeyVaultProperties.KeyVaultUri = new Uri(keyVaultUri);
            }
            return accountEncryption;
        }

        public static CloudStorageAccount GetCloudStorageAccount(Track2.StorageAccountResource storageAccountResource)
        {
            Uri blobEndpoint = storageAccountResource.Data.PrimaryEndpoints.Blob != null ? new Uri(storageAccountResource.Data.PrimaryEndpoints.Blob) : null;
            Uri queueEndpoint = storageAccountResource.Data.PrimaryEndpoints.Queue != null ? new Uri(storageAccountResource.Data.PrimaryEndpoints.Queue) : null;
            Uri tableEndpoint = storageAccountResource.Data.PrimaryEndpoints.Table != null ? new Uri(storageAccountResource.Data.PrimaryEndpoints.Table) : null;
            Uri fileEndpoint = storageAccountResource.Data.PrimaryEndpoints.File != null ? new Uri(storageAccountResource.Data.PrimaryEndpoints.File) : null;
            string key = null;
            if (storageAccountResource.GetKeys()?.Value?.Keys != null && storageAccountResource.GetKeys().Value.Keys.Count > 0)
            {
                key = storageAccountResource.GetKeys().Value.Keys[0].Value;
            } 
            else
            {
                throw new InvalidJobStateException("Could not fetch storage account keys to build storage account context.");
            }
            StorageCredentials storageCredentials = new Azure.Storage.Auth.StorageCredentials(storageAccountResource.Data.Name, key);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(
                storageCredentials,
                new StorageUri(blobEndpoint),
                new StorageUri(queueEndpoint),
                new StorageUri(tableEndpoint),
                new StorageUri(fileEndpoint));

            return cloudStorageAccount;
        }

        protected void WriteStorageAccount(Track2.StorageAccountResource storageAccountResource)
        {
            WriteObject(PSStorageAccount.Create(storageAccountResource, this.StorageClientTrack2));
        }

        public static string GetIdentityTypeString(string inputIdentityType)
        {
            if (inputIdentityType == null)
            {
                return null;
            }

            // The parameter validate set make sure the value must be systemAssigned or userAssigned or systemAssignedUserAssigned or None
            if (inputIdentityType.ToLower() == AccountIdentityType.SystemAssigned.ToLower())
            {
                return AccountIdentityType.SystemAssigned;
            }
            if (inputIdentityType.ToLower() == AccountIdentityType.UserAssigned.ToLower())
            {
                return AccountIdentityType.UserAssigned;
            }
            if (inputIdentityType.ToLower() == AccountIdentityType.SystemAssignedUserAssigned.ToLower())
            {
                return AccountIdentityType.SystemAssignedUserAssigned;
            }
            if (inputIdentityType.ToLower() == AccountIdentityType.None.ToLower())
            {
                return AccountIdentityType.None;
            }
            throw new ArgumentException("The value for AssignIdentityType is not valid, the valid value are: \"None\", \"SystemAssigned\", \"UserAssigned\", or \"SystemAssignedUserAssigned\"", "AssignIdentityType");
        }

        // Make the input string value case is aligned with the test API defination.
        public static string NormalizeString<T>(string input)
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (input.ToLower() == field.GetRawConstantValue().ToString().ToLower())
                {
                    return (string)field.GetRawConstantValue().ToString();
                }
            }
            return input;
        }

        // Make the input string[] value case is aligned with the test API defination.
        public static string[] NormalizeStringArray<T>(string[] input)
        {
            if (input != null)
            {
                List<string> stringList = new List<string>();
                foreach (string s in input)
                {
                    stringList.Add(NormalizeString<T>(s));
                }
                return stringList.ToArray();
            }
            return input;
        }
    }
}
