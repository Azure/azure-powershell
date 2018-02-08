﻿﻿// ----------------------------------------------------------------------------------
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
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Storage;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Common
{
    /// <summary>
    /// unit test for StorageCloudCmdletBase
    /// </summary>
    public class StorageCloudCmdletBaseTest : StorageTestBase
    {
        /// <summary>
        /// StorageCmdletBase command
        /// </summary>
        public StorageCloudCmdletBase<IStorageManagement> command = null;

        public StorageCloudCmdletBaseTest()
        {
            MockCmdRunTime = new MockCommandRuntime();
            command = new StorageCloudCmdletBase<IStorageManagement>
            {
                CommandRuntime = MockCmdRunTime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetCloudStorageAccountFromContextTest()
        {
            CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;
            command.Context = new AzureStorageContext(account);
            Assert.Equal(command.Context, command.GetCmdletStorageContext());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WriteObjectWithStorageContextWithNullContextTest()
        {
            AzureStorageBase item = new AzureStorageBase();
            command.WriteObjectWithStorageContext(item);

            AzureStorageBase contextItem = (AzureStorageBase)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.NotNull(contextItem);
            Assert.Null(contextItem.Context);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WriteObjectWithStorageContextWithContextTest()
        {
            CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;
            command.Context = new AzureStorageContext(account);

            AzureStorageBase item = new AzureStorageBase();
            command.WriteObjectWithStorageContext(item);

            AzureStorageBase contextItem = (AzureStorageBase)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.NotNull(contextItem);
            Assert.Equal(command.Context, contextItem.Context);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WriteObjectWithStorageContextWihtNullIEnumerableList()
        {
            IEnumerable<AzureStorageBase> itemList = null;
            command.WriteObjectWithStorageContext(itemList);
            Assert.Equal(0, MockCmdRunTime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WriteObjectWithStorageContextWihtEnumerableList()
        {
            List<AzureStorageBase> itemList = new List<AzureStorageBase>();
            itemList.Add(new AzureStorageBase());
            itemList.Add(new AzureStorageBase());
            command.WriteObjectWithStorageContext(itemList);
            Assert.Equal(2, MockCmdRunTime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldInitServiceChannelTest()
        {
            CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;
            command.Context = new AzureStorageContext(account);
            string toss;
            Assert.False(command.TryGetStorageAccount(command.RMProfile, out toss));
        }
    }
}
