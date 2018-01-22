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

using System;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Common.Cmdlet;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common.Cmdlet
{
    public class NewAzureStorageContextTest : StorageTestBase
    {
        /// <summary>
        /// StorageCmdletBase command
        /// </summary>
        public NewAzureStorageContext command = null;

        public NewAzureStorageContextTest()
        {
            command = new NewAzureStorageContext
            {
                CommandRuntime = new MockCommandRuntime()
            };
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStorageAccountByNameAndKeyTest()
        {
            AssertThrows<FormatException>(()=>command.GetStorageAccountByNameAndKey("a", "key", false));
            // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            command.GetStorageAccountByNameAndKey("a", "Xg+4nFQ832QfisuH/CkQwdQUmlqrZebQTJWpAQZ6klWjTVsIBVZy5xNdCDje4EWP0gdWK8vIFAX8LOmz85Wmcg==", false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStorageAccountBySasTokenTest()
        {
            command.GetStorageAccountBySasToken("a", "?st=d", true);
            AssertThrows<Exception>(()=>command.GetStorageAccountBySasToken("a", string.Empty, false));
            AssertThrows<Exception>(() => command.GetStorageAccountBySasToken("a", "token", false));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStorageAccountByConnectionStringTest()
        {
            AssertThrows<ArgumentNullException>(() => command.GetStorageAccountByConnectionString(String.Empty));
            AssertThrows<Exception>(() => command.GetStorageAccountByConnectionString("connection string"));

            Assert.NotNull(command.GetStorageAccountByConnectionString("UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://myProxyUri"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetLocalDevelopmentStorageAccountTest()
        {
            Assert.NotNull(command.GetLocalDevelopmentStorageAccount());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAnonymousStorageAccountTest()
        {
            Assert.NotNull(command.GetAnonymousStorageAccount("a", false));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStorageAccountWithEndPointTest()
        {
            string name = string.Empty;
            StorageCredentials credential = new StorageCredentials();
            AssertThrows<ArgumentException>(() => command.GetStorageAccountWithEndPoint(credential, name, false), String.Format(Resources.ObjectCannotBeNull, StorageNouns.StorageAccountName));

            name = "test";
            Assert.NotNull(command.GetStorageAccountWithEndPoint(credential, name, false));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteNewAzureStorageContextCmdlet()
        {
            AssertThrows<ArgumentException>(() => command.ExecuteCmdlet(), Resources.DefaultStorageCredentialsNotFound);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetDefaultEndPointDomainTest()
        {
            Assert.Equal(command.GetDefaultEndPointDomain(), Resources.DefaultStorageEndPointDomain);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetStorageAccountByConnectionStringAndSasToken()
        {
            // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            string sasToken = "?st=2013-09-03T04%3A12%3A15Z&se=2013-09-03T05%3A12%3A15Z&sr=c&sp=r&sig=fN2NPxLK99tR2%2BWnk48L3lMjutEj7nOwBo7MXs2hEV8%3D";
            string endpoint = "http://storageaccountname.blob.core.windows.net";
            string connectionString = String.Format("BlobEndpoint={0};QueueEndpoint={0};TableEndpoint={0};SharedAccessSignature={1}", endpoint, sasToken);
            CloudStorageAccount account = command.GetStorageAccountByConnectionString(connectionString);
            AzureStorageContext context = new AzureStorageContext(account);
            connectionString = String.Format("BlobEndpoint={0};SharedAccessSignature={1}", endpoint, sasToken);
            account = command.GetStorageAccountByConnectionString(connectionString);
            context = new AzureStorageContext(account);
        }
    }
}
