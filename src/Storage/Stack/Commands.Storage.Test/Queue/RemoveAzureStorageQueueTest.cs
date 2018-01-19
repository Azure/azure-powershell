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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Commands.Storage.Queue;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Queue
{
    public class RemoveAzureStorageQueueTest : StorageQueueTestBase
    {
        internal FakeRemoveAzureQueueCommand command = null;

        public RemoveAzureStorageQueueTest()
        {
            command = new FakeRemoveAzureQueueCommand(queueMock)
                {
                    CommandRuntime = MockCmdRunTime
                };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveQueueWithInvalidNameTest()
        {
            string name = "a*b";
            AssertThrows<ArgumentException>(() => command.RemoveAzureQueue(name),
                String.Format(Resources.InvalidQueueName, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveQueueWithNoExistQueueTest()
        {
            string name = "test";
            AssertThrows<ResourceNotFoundException>(() => command.RemoveAzureQueue(name),
                String.Format(Resources.QueueNotFound, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveQueueSuccessfullyTest()
        {
            string name = "test";

            MockCmdRunTime.ResetPipelines();
            AddTestQueues();
            bool removed = command.RemoveAzureQueue(name);
            Assert.False(removed);

            MockCmdRunTime.ResetPipelines();
            AddTestQueues();
            name = "text";
            command.confirm = true;
            removed = command.RemoveAzureQueue(name);
            Assert.True(removed);

            MockCmdRunTime.ResetPipelines();
            AddTestQueues();
            name = "text";
            command.Force = true;
            command.confirm = false;
            removed = command.RemoveAzureQueue(name);
            Assert.True(removed);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCommandRemoveAzureQueue()
        {
            string name = "test";
            command.Name = name;
            AssertThrows<ResourceNotFoundException>(() => command.ExecuteCmdlet(),
                String.Format(Resources.QueueNotFound, name));
        }
    }

    internal class FakeRemoveAzureQueueCommand : RemoveAzureStorageQueueCommand
    {
        public bool confirm = false;

        public FakeRemoveAzureQueueCommand(IStorageQueueManagement channel)
        {
            Channel = channel;
        }

        internal override bool ConfirmRemove(string message)
        {
            return confirm;
        }
    }
}
