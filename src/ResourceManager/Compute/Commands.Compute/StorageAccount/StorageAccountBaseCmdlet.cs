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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Storage;
using System;

namespace Microsoft.Azure.Commands.Compute
{
    public abstract class StorageAccountBaseCmdlet : AzurePSCmdlet
    {
        private StorageManagementClient storageClient;

        protected const string alphaApiVersion = "2014-12-01-preview";
        protected const string authorizationToken = "none";
        protected const string validating = null;

        protected const string StorageAccountNounStr = "AzureStorageAccount";
        protected const string StorageAccountKeyNounStr = StorageAccountNounStr + "Key";

        protected const string StorageAccountNameAlias = "StorageAccountName";
        protected const string AccountNameAlias = "AccountName";

        protected const string StorageAccountTypeAlias = "StorageAccountType";
        protected const string AccountTypeAlias = "AccountType";

        public StorageManagementClient StorageClient
        {
            get
            {
                if (storageClient == null)
                {
                    storageClient = new StorageManagementClient(Profile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp
                    };
                }

                return storageClient;
            }

            set { storageClient = value; }
        }

        public string SubscriptionId
        {
            get
            {
                return Profile.Context.Subscription.Id.ToString();
            }
        }

        public string ApiVersion
        {
            get
            {
                return alphaApiVersion;
            }
        }

        public string AuthorizationToken
        {
            get
            {
                return authorizationToken;
            }
        }

        public string Validating
        {
            get
            {
                return validating;
            }
        }

        public IStorageAccountService StorageAccountService
        {
            get
            {
                return StorageClient.SrpManagementClient.StorageAccountService;
            }
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }
    }
}
