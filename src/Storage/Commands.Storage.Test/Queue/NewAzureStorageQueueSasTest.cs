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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Queue.Cmdlet;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Queue
{
    [TestClass]
    public class NewAzureStorageQueueSasTest : StorageQueueTestBase
    {
        public NewAzureStorageQueueSasTokenCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new NewAzureStorageQueueSasTokenCommand(queueMock)
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
        public void SetupAccessPolicyPermissionTest()
        {
            SharedAccessQueuePolicy accessPolicy = new SharedAccessQueuePolicy();
            command.SetupAccessPolicyPermission(accessPolicy, "");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessQueuePermissions.None);
            accessPolicy.Permissions = SharedAccessQueuePermissions.Read;
            command.SetupAccessPolicyPermission(accessPolicy, "");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessQueuePermissions.Read);
            command.SetupAccessPolicyPermission(accessPolicy, "a");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessQueuePermissions.Add);
            command.SetupAccessPolicyPermission(accessPolicy, "aAaaa");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessQueuePermissions.Add);
            command.SetupAccessPolicyPermission(accessPolicy, "ru");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessQueuePermissions.Update | SharedAccessQueuePermissions.Read);
            command.SetupAccessPolicyPermission(accessPolicy, "ur");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessQueuePermissions.Update | SharedAccessQueuePermissions.Read);
            command.SetupAccessPolicyPermission(accessPolicy, "raUP");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessQueuePermissions.Add
                | SharedAccessQueuePermissions.Read | SharedAccessQueuePermissions.Update | SharedAccessQueuePermissions.ProcessMessages);
            command.SetupAccessPolicyPermission(accessPolicy, "UPrrrra");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessQueuePermissions.Add
                | SharedAccessQueuePermissions.Read | SharedAccessQueuePermissions.Update | SharedAccessQueuePermissions.ProcessMessages);
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "rwDl"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "x"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "rwx"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "ABC"));
        }
    }
}