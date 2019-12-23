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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Storage.Test.Service;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Queue
{
    public class StorageQueueTestBase : StorageTestBase
    {
        public MockStorageQueueManagement queueMock = null;

        [TestInitialize]
        public void InitMock()
        {
            queueMock = new MockStorageQueueManagement();
            MockCmdRunTime = new MockCommandRuntime();
        }

        [TestCleanup]
        public void CleanMock()
        {
            queueMock = null;
        }

        public void AddTestQueues()
        {
            queueMock.queueList.Clear();
            string testUri = "https://127.0.0.1/account/test";
            string textUri = "https://127.0.0.1/account/text";
            queueMock.queueList.Add(new CloudQueue(new Uri(testUri)));
            queueMock.queueList.Add(new CloudQueue(new Uri(textUri)));
        }
    }
}
