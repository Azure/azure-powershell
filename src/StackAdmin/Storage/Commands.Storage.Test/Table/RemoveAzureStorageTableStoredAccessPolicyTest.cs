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
    using System.Linq;

    public class RemoveAzureStorageTableStoredAccessPolicyTest : StorageTableStorageTestBase
    {
        public RemoveAzureStorageTableStoredAccessPolicyCommand command = null;

        public RemoveAzureStorageTableStoredAccessPolicyTest()
        {
            command = new RemoveAzureStorageTableStoredAccessPolicyCommand(tableMock)
            {
                CommandRuntime = MockCmdRunTime
            };
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveStoredAccessPolicyNotExistsTest()
        {
            AddTestStoredAccessPolicy();
            string policyName = "Policy" + Guid.NewGuid();
            string tableName = "sampleTable";

            AssertThrows<ResourceNotFoundException>(() => command.RemoveAzureTableStoredAccessPolicy(tableMock, tableName, policyName),
                String.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
            clearTest();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveStoredAccessPolicySuccessTest()
        {
            AddTestStoredAccessPolicy();
            string policyName = TestPolicy1;
            string tableName = "sampleTable";

            command.RemoveAzureTableStoredAccessPolicy(tableMock, tableName, policyName);
            Assert.True(!tableMock.tablePermissions.SharedAccessPolicies.Keys.Contains(policyName));

            clearTest();
        }
    }
}
