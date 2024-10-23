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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

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
            internal const string Cold = "Cold";
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
            internal const string TierToCold = "TierToCold";
            internal const string TierToHot = "TierToHot";
        }

        protected struct AccountIdentityType
        {
            internal const string systemAssigned = "SystemAssigned";
            internal const string userAssigned = "UserAssigned";
            internal const string systemAssignedUserAssigned = "SystemAssignedUserAssigned";
            internal const string none = "None";
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

        public string SubscriptionId
        {
            get
            {
                return DefaultProfile.DefaultContext.Subscription.Id.ToString();
            }
        }

        protected static AccessTier ParseAccessTier(string accessTier)
        {
            AccessTier returnAccessTier;
            if (!Enum.TryParse<AccessTier>(accessTier, true, out returnAccessTier))
            {
                throw new ArgumentOutOfRangeException("AccessTier");
            }
            return returnAccessTier;
        }

        protected static Encryption ParseEncryption(bool storageEncryption = false, bool keyVaultEncryption = false, string keyName = null, string keyVersion = null, string keyVaultUri = null)
        {
            Encryption accountEncryption = new Encryption();

            if (storageEncryption)
            {
                accountEncryption.KeySource = "Microsoft.Storage";
            }
            if (keyVaultEncryption)
            {
                accountEncryption.KeySource = "Microsoft.Keyvault";
                accountEncryption.KeyVaultProperties = new KeyVaultProperties(keyName, keyVersion, keyVaultUri);
            }
            return accountEncryption;
        }

        protected void WriteStorageAccount(StorageModels.StorageAccount storageAccount, IAzureContext DefaultContext)
        {
            WriteObject(PSStorageAccount.Create(storageAccount, this.StorageClient, DefaultContext));
        }

        protected void WriteStorageAccountList(IEnumerable<StorageModels.StorageAccount> storageAccounts, IAzureContext DefaultContext)
        {
            List<PSStorageAccount> output = new List<PSStorageAccount>();
            storageAccounts.ForEach(storageAccount => output.Add(PSStorageAccount.Create(storageAccount, this.StorageClient, DefaultContext)));
            WriteObject(output, true);
        }

        public static string GetIdentityTypeString(string inputIdentityType)
        {
            if (inputIdentityType == null)
            {
                return null;
            }

            // The parameter validate set make sure the value must be systemAssigned or userAssigned or systemAssignedUserAssigned or None
            if (inputIdentityType.ToLower() == AccountIdentityType.systemAssigned.ToLower())
            {
                return IdentityType.SystemAssigned;
            }
            if (inputIdentityType.ToLower() == AccountIdentityType.userAssigned.ToLower())
            {
                return IdentityType.UserAssigned;
            }
            if (inputIdentityType.ToLower() == AccountIdentityType.systemAssignedUserAssigned.ToLower())
            {
                return IdentityType.SystemAssignedUserAssigned;
            }
            if (inputIdentityType.ToLower() == AccountIdentityType.none.ToLower())
            {
                return IdentityType.None;
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
