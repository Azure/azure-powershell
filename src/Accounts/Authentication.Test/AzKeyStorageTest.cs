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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Common.Authenticators.Test
{
    public class AzKeyStorageTest
    {
        private Mock<IStorage> storageMocker = null;
        private List<byte> storageChecker = null;
        private string dummpyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), Resources.AzureDirectoryName);
        private string keyStoreFileName = "azkeystore";

        public AzKeyStorageTest()
        {
            storageChecker = new List<byte>();
            storageMocker = new Mock<IStorage>();
            storageMocker.Setup(f => f.Create()).Returns(storageMocker.Object);
            storageMocker.Setup(f => f.WriteData(It.IsAny<byte[]>())).Callback((byte[] s) => { storageChecker.Clear(); storageChecker.AddRange(s); });
        }

        private static bool CompareJsonObjects(string expected, string acutal)
        {
            var expectedObjects = JsonConvert.DeserializeObject(expected, typeof(List<Object>)) as List<Object>;
            var expectedStrings = expectedObjects.ConvertAll(x => x.ToString());
            expectedStrings.Sort();
            var objects = JsonConvert.DeserializeObject(acutal, typeof(List<Object>)) as List<Object>;
            var acutalStrings = objects.ConvertAll(x => x.ToString());
            acutalStrings.Sort();
            return expectedStrings.SequenceEqual(acutalStrings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveKey()
        {
            using (var store = new AzKeyStore(dummpyPath, keyStoreFileName, true, storageMocker.Object))
            {
                IKeyStoreKey servicePrincipalKey = new ServicePrincipalKey("ServicePrincipalSecret", "6c984d31-5b4f-4734-b548-e230a248e347", "54821234-0000-0000-0000-b7b93a3e1234");
                var secret = "secret".ConvertToSecureString();
                store.SaveSecureString(servicePrincipalKey, secret);

                IKeyStoreKey certificatePassword = new ServicePrincipalKey("CertificatePassword", "6c984d31-5b4f-4734-b548-e230a248e347", "54821234-0000-0000-0000-b7b93a3e1234");
                var passowrd = "password".ConvertToSecureString();
                store.SaveSecureString(certificatePassword, passowrd);

                var result = Encoding.UTF8.GetString(storageChecker.ToArray());
                const string EXPECTEDSTRING = @"[{""keyType"":""ServicePrincipalKey"",""keyStoreKey"":""{\""appId\"":\""6c984d31-5b4f-4734-b548-e230a248e347\"",\""tenantId\"":\""54821234-0000-0000-0000-b7b93a3e1234\"",\""name\"":\""CertificatePassword\""}"",""valueType"":""SecureString"",""keyStoreValue"":""\""password\""""},{""keyType"":""ServicePrincipalKey"",""keyStoreKey"":""{\""appId\"":\""6c984d31-5b4f-4734-b548-e230a248e347\"",\""tenantId\"":\""54821234-0000-0000-0000-b7b93a3e1234\"",\""name\"":\""ServicePrincipalSecret\""}"",""valueType"":""SecureString"",""keyStoreValue"":""\""secret\""""}]";
                Assert.True(CompareJsonObjects(EXPECTEDSTRING, result));

                store.Clear();
            }
            storageMocker.Verify();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FindKey()
        {
            const string EXPECTED = @"[{""keyType"":""ServicePrincipalKey"",""keyStoreKey"":""{\""appId\"":\""6c984d31-5b4f-4734-b548-e230a248e347\"",\""tenantId\"":\""54821234-0000-0000-0000-b7b93a3e1234\"",\""name\"":\""ServicePrincipalSecret\""}"",""valueType"":""SecureString"",""keyStoreValue"":""\""secret\""""}]";
            storageChecker.AddRange(Encoding.UTF8.GetBytes(EXPECTED));
            using (var store = new AzKeyStore(dummpyPath, keyStoreFileName, true, storageMocker.Object))
            {
                storageMocker.Setup(f => f.ReadData()).Returns(storageChecker.ToArray());

                IKeyStoreKey servicePrincipalKey = new ServicePrincipalKey("ServicePrincipalSecret", "6c984d31-5b4f-4734-b548-e230a248e347", "54821234-0000-0000-0000-b7b93a3e1234");
                var secret = store.GetSecureString(servicePrincipalKey);
                Assert.Equal("secret", secret.ConvertToString());

                store.Clear();
            }
            storageMocker.Verify();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FindFallbackKey()
        {
            const string EXPECTED = @"[{""keyType"":""ServicePrincipalKey"",""keyStoreKey"":""{\""appId\"":\""6c984d31-5b4f-4734-b548-e230a248e347\"",\""tenantId\"":\""54821234-0000-0000-0000-b7b93a3e1234\"",\""name\"":\""ServicePrincipalSecret\""}"",""valueType"":""SecureString"",""keyStoreValue"":""\""secretFallback\""""}]";
            storageChecker.AddRange(Encoding.UTF8.GetBytes(EXPECTED));
            using (var store = new AzKeyStore(dummpyPath, keyStoreFileName, true, storageMocker.Object))
            {
                storageMocker.Setup(f => f.ReadData()).Returns(storageChecker.ToArray());

                IKeyStoreKey servicePrincipalKey = new ServicePrincipalKey("ServicePrincipalSecret", "6c984d31-5b4f-4734-b548-e230a248e347", "54826b22-38d6-0000-bad9-b7b93a3e9c5a");
                var secret = store.GetSecureString(servicePrincipalKey);
                Assert.Equal("secretFallback", secret.ConvertToString());

                store.Clear();
            }
            storageMocker.Verify();
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FindNoKey()
        {
            const string EXPECTED = @"[{""keyType"":""ServicePrincipalKey"",""keyStoreKey"":""{\""appId\"":\""6c984d31-5b4f-4734-b548-e230a248e347\"",\""tenantId\"":\""54821234-0000-0000-0000-b7b93a3e1234\"",\""name\"":\""ServicePrincipalSecret\""}"",""valueType"":""SecureString"",""keyStoreValue"":""\""secret\""""}]";
            storageChecker.AddRange(Encoding.UTF8.GetBytes(EXPECTED));
            using (var store = new AzKeyStore(dummpyPath, keyStoreFileName, true, storageMocker.Object))
            {
                storageMocker.Setup(f => f.ReadData()).Returns(storageChecker.ToArray());

                IKeyStoreKey servicePrincipalKey = new ServicePrincipalKey("CertificatePassword", "6c984d31-5b4f-4734-b548-e230a248e347", "54821234-0000-0000-0000-b7b93a3e1234");
                Assert.Throws<ArgumentException>(() => store.GetSecureString(servicePrincipalKey));

                store.Clear();
            }
            storageMocker.Verify();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveKey()
        {
            const string EXPECTED = @"[{""keyType"":""ServicePrincipalKey"",""keyStoreKey"":""{\""appId\"":\""6c984d31-5b4f-4734-b548-e230a248e347\"",\""tenantId\"":\""54821234-0000-0000-0000-b7b93a3e1234\"",\""name\"":\""ServicePrincipalSecret\""}"",""valueType"":""SecureString"",""keyStoreValue"":""\""secret\""""}]";
            storageChecker.AddRange(Encoding.UTF8.GetBytes(EXPECTED));
            using (var store = new AzKeyStore(dummpyPath, keyStoreFileName, true, storageMocker.Object))
            {
                storageMocker.Setup(f => f.ReadData()).Returns(storageChecker.ToArray());

                IKeyStoreKey servicePrincipalKey = new ServicePrincipalKey("ServicePrincipalSecret", "6c984d31-5b4f-4734-b548-e230a248e347", "54821234-0000-0000-0000-b7b93a3e1234");
                store.RemoveSecureString(servicePrincipalKey);

                var result = Encoding.UTF8.GetString(storageChecker.ToArray());
                var objects = JsonConvert.DeserializeObject<List<Object>>(result);
                Assert.Empty(objects);

                store.Clear();
            }
            storageMocker.Verify();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveNoKey()
        {
            const string EXPECTED = @"[{""keyType"":""ServicePrincipalKey"",""keyStoreKey"":""{\""appId\"":\""6c984d31-5b4f-4734-b548-e230a248e347\"",\""tenantId\"":\""54821234-0000-0000-0000-b7b93a3e1234\"",\""name\"":\""ServicePrincipalSecret\""}"",""valueType"":""SecureString"",""keyStoreValue"":""\""secret\""""}]";
            storageChecker.AddRange(Encoding.UTF8.GetBytes(EXPECTED));
            using (var store = new AzKeyStore(dummpyPath, keyStoreFileName, true, storageMocker.Object))
            {
                storageMocker.Setup(f => f.ReadData()).Returns(storageChecker.ToArray());

                IKeyStoreKey servicePrincipalKey = new ServicePrincipalKey("CertificatePassword", "6c984d31-5b4f-4734-b548-e230a248e347", "54821234-0000-0000-0000-b7b93a3e1234");
                store.RemoveSecureString(servicePrincipalKey);

                var result = Encoding.UTF8.GetString(storageChecker.ToArray());
                var objects = JsonConvert.DeserializeObject<List<Object>>(result);
                Assert.Single(objects);

                store.Clear();
            }
            storageMocker.Verify();
        }
    }
}
