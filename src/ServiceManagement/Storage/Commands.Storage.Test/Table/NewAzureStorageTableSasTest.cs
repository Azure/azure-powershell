// ----------------------------------------------------------------------------------
//
// Copyright 2012 Microsoft Corporation
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
using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;
using Microsoft.WindowsAzure.Storage.Table;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    [TestClass]
    public class NewAzureStorageTableSasTest : StorageTableStorageTestBase
    {
        public NewAzureStorageTableSasTokenCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new NewAzureStorageTableSasTokenCommand(tableMock)
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
            SharedAccessTablePolicy accessPolicy = new SharedAccessTablePolicy();
            command.SetupAccessPolicyPermission(accessPolicy, "");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.None);
            accessPolicy.Permissions = SharedAccessTablePermissions.Add;
            command.SetupAccessPolicyPermission(accessPolicy, "");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.Add);
            command.SetupAccessPolicyPermission(accessPolicy, "u");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.Update);
            command.SetupAccessPolicyPermission(accessPolicy, "uUUU");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.Update);
            command.SetupAccessPolicyPermission(accessPolicy, "drrq");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.Delete | SharedAccessTablePermissions.Query);
            command.SetupAccessPolicyPermission(accessPolicy, "rq");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.Query);
            command.SetupAccessPolicyPermission(accessPolicy, "q");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.Query);
            command.SetupAccessPolicyPermission(accessPolicy, "r");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.Query);
            command.SetupAccessPolicyPermission(accessPolicy, "qd");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.Delete | SharedAccessTablePermissions.Query);
            command.SetupAccessPolicyPermission(accessPolicy, "audq");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.Add 
                | SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Update | SharedAccessTablePermissions.Delete);
            command.SetupAccessPolicyPermission(accessPolicy, "dqaaaau");
            Assert.AreEqual(accessPolicy.Permissions, SharedAccessTablePermissions.Add
                | SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Update | SharedAccessTablePermissions.Delete);
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "rwDl"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "x"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "rwx"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "ABC"));
        }
    }
}
