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
using Microsoft.Azure.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using System;

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    public class LazyAzureStorageContext : AzureStorageContext
    {
        Func<string, CloudStorageAccount> _factory;
        CloudStorageAccount _account = null;
        Func<AzureSessionCredential> _track2OAuthTokenFactory;
        private AzureSessionCredential _track2OauthToken = null;
        public LazyAzureStorageContext(Func<string, CloudStorageAccount> accountFactory, string accountName, Func<AzureSessionCredential> track2OAuthTokenFactory = null)
        {
            _factory = accountFactory;
            _track2OAuthTokenFactory = track2OAuthTokenFactory;
            Name = accountName;
            Context = this;
            StorageAccountName = accountName;
        }

        public override string BlobEndPoint
        {
            get
            {
                return StorageAccount.BlobEndpoint.ToString();
            }
        }
        public override string TableEndPoint
        {
            get
            {
                return StorageAccount.TableEndpoint.ToString();
            }
        }

        public override string QueueEndPoint
        {
            get
            {
                return StorageAccount.QueueEndpoint.ToString();
            }
        }

        public override string FileEndPoint
        {
            get
            {
                return StorageAccount.FileEndpoint.ToString();
            }
        }

        public override CloudStorageAccount StorageAccount
        {
            get
            {
                if (_account == null)
                {
                    _account = _factory(StorageAccountName);
                }

                return _account;
            }
        }

        public override AzureSessionCredential Track2OauthToken { 
            get
            {
                if (_track2OauthToken == null)
                {
                   _track2OauthToken = _track2OAuthTokenFactory();
                    return _track2OauthToken;
                }
                return _track2OauthToken;
            }
        }
    }
}

