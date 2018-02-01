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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;
using Microsoft.WindowsAzure.Storage.Table;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    public class NewAzureStorageTableSasTest : StorageTableStorageTestBase
    {
        public NewAzureStorageTableSasTokenCommand command = null;

        public NewAzureStorageTableSasTest()
        {
            command = new NewAzureStorageTableSasTokenCommand(tableMock)
                {
                    CommandRuntime = MockCmdRunTime
                };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetupAccessPolicyPermissionTest()
        {
            SharedAccessTablePolicy accessPolicy = new SharedAccessTablePolicy();
            command.SetupAccessPolicyPermission(accessPolicy, "");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.None);
            accessPolicy.Permissions = SharedAccessTablePermissions.Add;
            command.SetupAccessPolicyPermission(accessPolicy, "");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.Add);
            command.SetupAccessPolicyPermission(accessPolicy, "u");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.Update);
            command.SetupAccessPolicyPermission(accessPolicy, "uUUU");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.Update);
            command.SetupAccessPolicyPermission(accessPolicy, "drrq");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.Delete | SharedAccessTablePermissions.Query);
            command.SetupAccessPolicyPermission(accessPolicy, "rq");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.Query);
            command.SetupAccessPolicyPermission(accessPolicy, "q");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.Query);
            command.SetupAccessPolicyPermission(accessPolicy, "r");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.Query);
            command.SetupAccessPolicyPermission(accessPolicy, "qd");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.Delete | SharedAccessTablePermissions.Query);
            command.SetupAccessPolicyPermission(accessPolicy, "audq");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.Add 
                | SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Update | SharedAccessTablePermissions.Delete);
            command.SetupAccessPolicyPermission(accessPolicy, "dqaaaau");
            Assert.Equal(accessPolicy.Permissions, SharedAccessTablePermissions.Add
                | SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Update | SharedAccessTablePermissions.Delete);
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "rwDl"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "x"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "rwx"));
            AssertThrows<ArgumentException>(() => command.SetupAccessPolicyPermission(accessPolicy, "ABC"));
        }
    }
}
