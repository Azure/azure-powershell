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

        protected const string StorageAccountNounStr = "AzureRmStorageAccount";
        protected const string StorageAccountKeyNounStr = StorageAccountNounStr + "Key";

        protected const string StorageAccountNameAlias = "StorageAccountName";
        protected const string AccountNameAlias = "AccountName";

        protected const string StorageAccountTypeAlias = "StorageAccountType";
        protected const string AccountTypeAlias = "AccountType";
        protected const string Account_TypeAlias = "Type";

        protected const string TagsAlias = "Tags";

        protected const string StorageAccountNameAvailabilityStr = "AzureRmStorageAccountNameAvailability";

        protected const string StorageUsageNounStr = "AzureRmStorageUsage";

        protected struct AccountTypeString
        {
            internal const string StandardLRS = "Standard_LRS";
            internal const string StandardZRS = "Standard_ZRS";
            internal const string StandardGRS = "Standard_GRS";
            internal const string StandardRAGRS = "Standard_RAGRS";
            internal const string PremiumLRS = "Premium_LRS";
        }
        protected struct AccountKind
        {
            internal const string Storage = "Storage";
            internal const string BlobStorage = "BlobStorage";
        }
        protected struct AccountAccessTier
        {
            internal const string Hot = "Hot";
            internal const string Cool = "Cool";
        }
        public enum EncryptionSupportServiceEnum
        {
            Blob = 1
        }

        public IStorageManagementClient StorageClient
        {
            get
            {
                if (storageClientWrapper == null)
                {
                    storageClientWrapper = new StorageManagementClientWrapper(DefaultProfile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp
                    };
                }

                return storageClientWrapper.StorageManagementClient;
            }

            set { storageClientWrapper = new StorageManagementClientWrapper(value); }
        }

        public string SubscriptionId
        {
            get
            {
                return DefaultProfile.Context.Subscription.Id.ToString();
            }
        }

        protected static SkuName ParseSkuName(string skuName)
        {
            SkuName returnSkuName;
            if (!Enum.TryParse<SkuName>(skuName.Replace("_", ""), true, out returnSkuName))
            {
                throw new ArgumentOutOfRangeException("SkuName");
            }
            return returnSkuName;
        }

        protected static Kind? ParseAccountKind(string accountKind)
        {
            Kind returnKind;
            if (accountKind == null)
            {
                return null;
            }
            else if (!Enum.TryParse<Kind>(accountKind, true, out returnKind))
            {
                throw new ArgumentOutOfRangeException("Kind");
            }
            return returnKind;
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

        protected static Encryption ParseEncryption(EncryptionSupportServiceEnum? EnableService, EncryptionSupportServiceEnum? DisableService = null)
        {
            //DisableService and EnableService should not have overlap
            if (DisableService != null && EnableService != null)
            {
                if ((DisableService & EnableService) != 0)
                    throw new ArgumentOutOfRangeException("EnableEncryptionService, DisableEncryptionService", String.Format("EnableEncryptionService and DisableEncryptionService should no have overlap Service: {0}", DisableService & EnableService));
            }

            Encryption accountEncryption = new Encryption();
            accountEncryption.Services = new EncryptionServices();
            if (EnableService != null && (EnableService & EncryptionSupportServiceEnum.Blob) == EncryptionSupportServiceEnum.Blob)
            {
                accountEncryption.Services.Blob = new EncryptionService();
                accountEncryption.Services.Blob.Enabled = true;
            }
            if (DisableService != null && (DisableService & EncryptionSupportServiceEnum.Blob) == EncryptionSupportServiceEnum.Blob)
            {
                accountEncryption.Services.Blob = new EncryptionService();
                accountEncryption.Services.Blob.Enabled = false;
            }
            return accountEncryption;
        }

        protected void WriteStorageAccount(StorageModels.StorageAccount storageAccount)
        {
            WriteObject(PSStorageAccount.Create(storageAccount, this.StorageClient));
        }

        protected void WriteStorageAccountList(IEnumerable<StorageModels.StorageAccount> storageAccounts)
        {
            List<PSStorageAccount> output = new List<PSStorageAccount>();
            storageAccounts.ForEach(storageAccount => output.Add(PSStorageAccount.Create(storageAccount, this.StorageClient)));
            WriteObject(output, true);
        }
    }
}
