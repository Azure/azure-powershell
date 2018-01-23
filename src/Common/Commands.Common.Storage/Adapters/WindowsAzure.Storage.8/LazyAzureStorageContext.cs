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
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    public class LazyAzureStorageContext : AzureStorageContext
    {
        Func<string, CloudStorageAccount> _factory;
        CloudStorageAccount _account = null;
        public LazyAzureStorageContext(Func<string, CloudStorageAccount> accountFactory, string accountName)
        {
            _factory = accountFactory;
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
    }
}

