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

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common
{
    /// <summary>
    /// unit test for StorageCloudCmdletBase
    /// </summary>
    [TestClass]
    public class StorageCloudCmdletBaseTest : StorageTestBase
    {
        /// <summary>
        /// StorageCmdletBase command
        /// </summary>
        public StorageCloudCmdletBase<IStorageManagement> command = null;

        [TestInitialize]
        public void InitCommand()
        {
            MockCmdRunTime = new MockCommandRuntime();
            command = new StorageCloudCmdletBase<IStorageManagement>
            {
                CommandRuntime = MockCmdRunTime
            };
        }

        [TestCleanup]
        public void CleanCommand()
        {
            command = null;
        }

        [TestMethod]
        public void GetCloudStorageAccountFromContextTest()
        {
            CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;
            command.Context = new AzureStorageContext(account);
            Assert.AreEqual(command.Context, command.GetCmdletStorageContext());
        }

        [TestMethod]
        public void WriteObjectWithStorageContextWithNullContextTest()
        {
            AzureStorageBase item = new AzureStorageBase();
            command.WriteObjectWithStorageContext(item);

            AzureStorageBase contextItem = (AzureStorageBase)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.IsNotNull(contextItem);
            Assert.IsNull(contextItem.Context);
        }

        [TestMethod]
        public void WriteObjectWithStorageContextWithContextTest()
        {
            CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;
            command.Context = new AzureStorageContext(account);

            AzureStorageBase item = new AzureStorageBase();
            command.WriteObjectWithStorageContext(item);

            AzureStorageBase contextItem = (AzureStorageBase)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.IsNotNull(contextItem);
            Assert.AreEqual(command.Context, contextItem.Context);
        }

        [TestMethod]
        public void WriteObjectWithStorageContextWihtNullIEnumerableList()
        {
            IEnumerable<AzureStorageBase> itemList = null;
            command.WriteObjectWithStorageContext(itemList);
            Assert.AreEqual(0, MockCmdRunTime.OutputPipeline.Count);
        }

        [TestMethod]
        public void WriteObjectWithStorageContextWihtEnumerableList()
        {
            List<AzureStorageBase> itemList = new List<AzureStorageBase>();
            itemList.Add(new AzureStorageBase());
            itemList.Add(new AzureStorageBase());
            command.WriteObjectWithStorageContext(itemList);
            Assert.AreEqual(2, MockCmdRunTime.OutputPipeline.Count);
        }

        [TestMethod]
        public void ShouldInitServiceChannelTest()
        {
            CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;
            command.Context = new AzureStorageContext(account);
            string toss;
            Assert.IsFalse(command.TryGetStorageAccount(command.SMProfile, out toss));
        }
    }
}
