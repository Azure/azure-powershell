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
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Queue;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Queue
{
    public class NewAzureStorageQueueTest : StorageQueueTestBase
    {
        public NewAzureStorageQueueCommand command = null;

        public NewAzureStorageQueueTest()
        {
            command = new NewAzureStorageQueueCommand(queueMock)
                {
                    CommandRuntime = MockCmdRunTime
                };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateAzureQueueWithInvalidNameTest()
        {
            string name = String.Empty;
            AssertThrows<ArgumentException>(() => command.CreateAzureQueue(name),
                String.Format(Resources.InvalidQueueName, name));

            name = "a";
            AssertThrows<ArgumentException>(() => command.CreateAzureQueue(name),
                String.Format(Resources.InvalidQueueName, name));

            name = "&*(";
            AssertThrows<ArgumentException>(() => command.CreateAzureQueue(name),
                String.Format(Resources.InvalidQueueName, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateAzureQueueWithExistsQueueTest()
        {
            AddTestQueues();
            string name = "text";
            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureQueue(name),
                String.Format(Resources.QueueAlreadyExists, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateAzureQueueSuccessfullyTest()
        {
            MockCmdRunTime.ResetPipelines();
            string name = "test";
            AzureStorageQueue queue = command.CreateAzureQueue(name);
            Assert.Equal("test", queue.Name);

            MockCmdRunTime.ResetPipelines();
            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureQueue(name),
                String.Format(Resources.QueueAlreadyExists, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExcuteCommandNewQueueTest()
        {
            string name = "queuename";
            command.Name = name;
            command.ExecuteCmdlet();
            AzureStorageQueue queue = (AzureStorageQueue)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.Equal(name, queue.Name);
        }
    }
}
