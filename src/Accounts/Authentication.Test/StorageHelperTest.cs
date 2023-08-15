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
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Xunit;

namespace Common.Authenticators.Test
{
    public class StorageHelperTest
    {
        private Mock<IStorage> storageMocker = null;
        private Mock<IKeyCache> keystoreMocker = null; 
        private string profilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), Resources.AzureDirectoryName);
        private string keyStoreFileName = "azkeystore";

        public StorageHelperTest()
        {
            storageMocker = new Mock<IStorage>();
            storageMocker.Setup(f => f.Create()).Returns(storageMocker.Object);
            keystoreMocker = new Mock<IKeyCache>();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoadFromStorageTest()
        {
            const string EXPECTED = @"[{""keyType"":""ServicePrincipalKey"",""keyStoreKey"":""{\""appId\"":\""6c984d31-5b4f-4734-b548-e230a248e347\"",\""tenantId\"":\""54821234-0000-0000-0000-b7b93a3e1234\"",\""name\"":\""ServicePrincipalSecret\""}"",""valueType"":""SecureString"",""keyStoreValue"":""\""secret\""""}]";
            string actual = null;
            List<byte> storageChecker = new List<byte>();
            storageChecker.AddRange(Encoding.UTF8.GetBytes(EXPECTED));
            storageMocker.Setup(f => f.ReadData()).Returns(storageChecker.ToArray());
            keystoreMocker.Setup(f => f.Deserialize(It.IsAny<byte[]>(), It.IsAny<bool>())).Callback(
                (byte[] s, bool c) => { actual = Encoding.UTF8.GetString(s); });
            var helper = StorageHelper.GetStorageHelperAsync(true, keyStoreFileName, profilePath
                , keystoreMocker.Object, storageMocker.Object).GetAwaiter().GetResult();
            helper.LoadFromCachedStorage(keystoreMocker.Object);
            Assert.Equal(EXPECTED, actual);
            storageMocker.Verify();
            keystoreMocker.Verify();
            StorageHelper.TryClearLockedStorageHelper();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveToStorageTest()
        {
            const string EXPECTED = @"[{""keyType"":""ServicePrincipalKey"",""keyStoreKey"":""{\""appId\"":\""6c984d31-5b4f-4734-b548-e230a248e347\"",\""tenantId\"":\""54821234-0000-0000-0000-b7b93a3e1234\"",\""name\"":\""ServicePrincipalSecret\""}"",""valueType"":""SecureString"",""keyStoreValue"":""\""secret\""""}]";
            List<byte> storageChecker = new List<byte>(), keystoreChecker = new List<byte>();
            keystoreChecker.AddRange(Encoding.UTF8.GetBytes(EXPECTED));

            storageMocker.Setup(f => f.WriteData(It.IsAny<byte[]>())).Callback(
                (byte[] s) => { storageChecker.AddRange(s); });
            keystoreMocker.Setup(f => f.Serialize()).Returns(keystoreChecker.ToArray());

            var helper = StorageHelper.GetStorageHelperAsync(true, keyStoreFileName, profilePath
                , keystoreMocker.Object, storageMocker.Object).GetAwaiter().GetResult();
            helper.WriteToCachedStorage(keystoreMocker.Object);

            string actual = Encoding.UTF8.GetString(storageChecker.ToArray());
            Assert.Equal(EXPECTED, actual);
            storageMocker.Verify();
            keystoreMocker.Verify();
            StorageHelper.TryClearLockedStorageHelper();
        }
    }
}
