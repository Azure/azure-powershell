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
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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

        protected static AccountType ParseAccountType(string accountType)
        {
            if (AccountTypeString.StandardLRS.Equals(accountType, StringComparison.OrdinalIgnoreCase))
            {
                return AccountType.StandardLRS;
            }
            if (AccountTypeString.StandardZRS.Equals(accountType, StringComparison.OrdinalIgnoreCase))
            {
                return AccountType.StandardZRS;
            }
            if (AccountTypeString.StandardGRS.Equals(accountType, StringComparison.OrdinalIgnoreCase))
            {
                return AccountType.StandardGRS;
            }
            if (AccountTypeString.StandardRAGRS.Equals(accountType, StringComparison.OrdinalIgnoreCase))
            {
                return AccountType.StandardRAGRS;
            }
            if (AccountTypeString.PremiumLRS.Equals(accountType, StringComparison.OrdinalIgnoreCase))
            {
                return AccountType.PremiumLRS;
            }
            throw new ArgumentOutOfRangeException("accountType");
        }

        protected void WriteStorageAccount(StorageModels.StorageAccount storageAccount)
        {
            WriteObject(PSStorageAccount.Create(storageAccount, this.StorageClient));
        }

        protected void WriteStorageAccountList(IList<StorageModels.StorageAccount> storageAccounts)
        {
            List<PSStorageAccount> output = new List<PSStorageAccount>();
            storageAccounts.ForEach(storageAccount => output.Add(PSStorageAccount.Create(storageAccount, this.StorageClient)));
            WriteObject(output, true);
        }
    }
}
