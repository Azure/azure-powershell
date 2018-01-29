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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class SetAzureStorageTableStoredAccessPolicyTest : StorageTableStorageTestBase
    {
        public SetAzureStorageTableStoredAccessPolicyCommand command = null;

        public SetAzureStorageTableStoredAccessPolicyTest()
        {
            command = new SetAzureStorageTableStoredAccessPolicyCommand(tableMock)
            {
                CommandRuntime = MockCmdRunTime
            };
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetStoredAccessPolicyNotExistsTest()
        {
            clearTest();
            string policyName = "Policy" + Guid.NewGuid();
            string tableName = "sampleTable";

            command.Table = tableName;
            command.Policy = policyName;
            AssertThrows<ArgumentException>(() => command.SetAzureTableStoredAccessPolicy(command.Channel, tableName, policyName, null, null, null, false, false),
                string.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName)); 

            clearTest();
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetStoredAccessPolicySuccessTest()
        {
            AddTestStoredAccessPolicy();
            string policyName = TestPolicy1;
            string tableName = "sampleTable";

            string permission = "u";
            DateTime startTime = DateTime.Today;
            DateTime expiryTime = DateTime.Today.AddDays(2);
            command.SetAzureTableStoredAccessPolicy(command.Channel, tableName, policyName, startTime, expiryTime, permission, false, false);

            SharedAccessTablePermissions expectedPermissions = SharedAccessTablePermissions.None;
            expectedPermissions |= SharedAccessTablePermissions.Update;
            SharedAccessTablePolicy resultPolicy = tableMock.tablePermissions.SharedAccessPolicies[policyName];
            Assert.NotNull(resultPolicy);
            Assert.Equal<SharedAccessTablePermissions>(expectedPermissions, resultPolicy.Permissions);
            Assert.Equal<DateTimeOffset?>(startTime.ToUniversalTime(), resultPolicy.SharedAccessStartTime);
            Assert.Equal<DateTimeOffset?>(expiryTime.ToUniversalTime(), resultPolicy.SharedAccessExpiryTime);
        }
    }
}
