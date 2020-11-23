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
using System.Collections;
using System.Collections.Generic;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    public abstract class StorageFileBaseCmdlet : AzureRMCmdlet
    {
        private StorageManagementClientWrapper storageClientWrapper;
        
        protected const string AccountNameAlias = "AccountName";
        protected const string NameAlias = "Name";

        protected const string StorageShareNounStr = "StorageShare";

        public const string StorageAccountResourceType = "Microsoft.Storage/storageAccounts";

        public IStorageManagementClient StorageClient
        {
            get
            {
                if (storageClientWrapper == null)
                {
                    storageClientWrapper = new StorageManagementClientWrapper(DefaultProfile.DefaultContext)
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
                return DefaultProfile.DefaultContext.Subscription.Id.ToString();
            }
        }

        protected void WriteShareList(IEnumerable<FileShareItem> shares)
        {
            if (shares != null)
            {
                List<PSShare> output = new List<PSShare>();
                shares.ForEach(share => output.Add(new PSShare(share)));
                WriteObject(output, true);
            }
        }

        public static Dictionary<string, string> CreateMetadataDictionary(Hashtable Metadata, bool validate)
        {
            Dictionary<string, string> MetadataDictionary = null;
            if (Metadata != null)
            {
                MetadataDictionary = new Dictionary<string, string>();

                string dirKey = null;
                string dirValue = null;
                foreach (DictionaryEntry entry in Metadata)
                {
                    dirKey = entry.Key.ToString();
                    if (entry.Value != null)
                    {
                        dirValue = entry.Value.ToString();
                    }
                    else
                    {
                        dirValue = string.Empty;
                    }
                    MetadataDictionary[dirKey] = dirValue;
                }
            }
            return MetadataDictionary;
        }
    }
}
