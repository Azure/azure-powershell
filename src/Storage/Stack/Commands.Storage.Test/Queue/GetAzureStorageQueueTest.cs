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
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Queue
{
    public class GetAzureStorageQueueTest : StorageQueueTestBase
    {
        public GetAzureStorageQueueCommand command = null;

        public GetAzureStorageQueueTest()
        {
            command = new GetAzureStorageQueueCommand(queueMock)
            {
                CommandRuntime = MockCmdRunTime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListQueuesByNameWithEmptyNameTest()
        {
            List<CloudQueue> queueList = command.ListQueuesByName("").ToList();
            Assert.Equal(0, queueList.Count);

            AddTestQueues();
            queueList = command.ListQueuesByName("").ToList();
            Assert.Equal(2, queueList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListQueuesByNameWithWildCardTest()
        {
            List<CloudQueue> queueList = command.ListQueuesByName("te*t").ToList();
            Assert.Equal(0, queueList.Count);

            AddTestQueues();

            queueList = command.ListQueuesByName("te*t").ToList();
            Assert.Equal(2, queueList.Count);

            queueList = command.ListQueuesByName("tx*t").ToList();
            Assert.Equal(0, queueList.Count);

            queueList = command.ListQueuesByName("t?st").ToList();
            Assert.Equal(1, queueList.Count);
            Assert.Equal("test", queueList[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListQueuesByNameWithInvalidNameTest()
        {
            string invalidName = "a";
            AssertThrows<ArgumentException>(() => command.ListQueuesByName(invalidName).ToList(),
                String.Format(Resources.InvalidQueueName, invalidName));
            invalidName = "xx%%d";
            AssertThrows<ArgumentException>(() => command.ListQueuesByName(invalidName).ToList(),
                String.Format(Resources.InvalidQueueName, invalidName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListQueuesByNameWitNotExistsQueueTest()
        {
            string notExistingName = "abcdefg";
            AssertThrows<ResourceNotFoundException>(() => command.ListQueuesByName(notExistingName).ToList(),
                String.Format(Resources.QueueNotFound, notExistingName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListQueuesByNameSuccessfullyTest()
        {
            AddTestQueues();

            MockCmdRunTime.ResetPipelines();
            List<CloudQueue> queueList = command.ListQueuesByName("text").ToList();
            Assert.Equal(1, queueList.Count);
            Assert.Equal("text", queueList[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListQueuesByPrefixWithEmptyPrefixTest()
        {
            AssertThrows<ArgumentException>(() => command.ListQueuesByPrefix(String.Empty),
                String.Format(Resources.InvalidQueueName, String.Empty));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListQueuesByPrefixWithInvalidPrefixTest()
        {
            string prefix = "?";
            AssertThrows<ArgumentException>(() => command.ListQueuesByPrefix(prefix).ToList(), String.Format(Resources.InvalidQueueName, prefix));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListQueuesByPrefixSuccessfullyTest()
        {
            AddTestQueues();

            List<CloudQueue> queueList = command.ListQueuesByPrefix("te").ToList();
            Assert.Equal(2, queueList.Count);
            Assert.True(queueList.Any(item => item.Name == "test"));
            Assert.True(queueList.Any(item => item.Name == "text"));

            queueList = command.ListQueuesByPrefix("testx").ToList();
            Assert.Equal(0, queueList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WriteQueueWithCountTest()
        {
            command.WriteQueueWithCount(null);
            Assert.Equal(0, MockCmdRunTime.OutputPipeline.Count);

            MockCmdRunTime.ResetPipelines();
            command.WriteQueueWithCount(queueMock.queueList);
            Assert.Equal(0, MockCmdRunTime.OutputPipeline.Count);

            AddTestQueues();
            MockCmdRunTime.ResetPipelines();
            command.WriteQueueWithCount(queueMock.queueList);
            Assert.Equal(2, MockCmdRunTime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCommandGetQueueTest()
        {
            AddTestQueues();
            command.Name = "test";
            command.ExecuteCmdlet();
            Assert.Equal(1, MockCmdRunTime.OutputPipeline.Count);

            AzureStorageQueue queue = (AzureStorageQueue)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.Equal(command.Name, queue.Name);
        }
    }
}
