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

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    using System;
    using System.Globalization;
    using Microsoft.Azure.Cosmos.Table;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;

    [TestClass]
    public class NewAzureStorageTableStoredAccessPolicyTest : StorageTableStorageTestBase
    {
        public NewAzureStorageTableStoredAccessPolicyCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            this.command = new NewAzureStorageTableStoredAccessPolicyCommand(this.tableMock)
            {
                CommandRuntime = this.MockCmdRunTime
            };
        }

        [TestCleanup]
        public void CleanCommand()
        {
            this.clearTest();
            this.command = null;
        }

        [TestMethod]
        public void CreateAzureTableStoredAccessPolicyWithInvalidNameTest()
        {
            //policy name lenght longer than 64
            string policyName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string tableName = "sampleTable";
            AssertThrows<ArgumentException>(() => command.CreateAzureTableStoredAccessPolicy(command.Channel, tableName, policyName, null, null, null),
                String.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPolicyName, policyName));
        }

        [TestMethod]
        public void CreateAzureTableStoredAccessPolicySuccessTest()
        {
            string policyName = "Policy" + Guid.NewGuid();
            string tableName = "sampleTable";

            string permission = "rd";
            DateTime startTime = DateTime.Today;
            DateTime expiryTime = DateTime.Today.AddDays(1);
            command.CreateAzureTableStoredAccessPolicy(command.Channel, tableName, policyName, startTime, expiryTime, permission);

            SharedAccessTablePermissions expectedPermissions = SharedAccessTablePermissions.None;
            expectedPermissions |= SharedAccessTablePermissions.Query;
            expectedPermissions |= SharedAccessTablePermissions.Delete;
            SharedAccessTablePolicy resultPolicy = tableMock.tablePermissions.SharedAccessPolicies[policyName];
            Assert.IsNotNull(resultPolicy);
            Assert.AreEqual<SharedAccessTablePermissions>(expectedPermissions, resultPolicy.Permissions);
            Assert.AreEqual<DateTimeOffset?>(startTime.ToUniversalTime(), resultPolicy.SharedAccessStartTime);
            Assert.AreEqual<DateTimeOffset?>(expiryTime.ToUniversalTime(), resultPolicy.SharedAccessExpiryTime);
        }

        [TestMethod]
        public void CreateStoredAccessPolicyAlreadyExistsTest()
        {
            string policyName = "Policy" + Guid.NewGuid();
            string tableName = "sampleTable";

            command.Table = tableName;
            command.Policy = policyName;
            command.CreateAzureTableStoredAccessPolicy(command.Channel, tableName, policyName, null, null, null);
            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureTableStoredAccessPolicy(command.Channel, tableName, policyName, null, null, null),
                String.Format(CultureInfo.CurrentCulture, Resources.PolicyAlreadyExists, policyName));
        }

        [TestMethod]
        public void CreateStoredAccessPolicyInvalidExpiryTime()
        {
            string policyName = "Policy" + Guid.NewGuid();
            string tableName = "sampleTable";

            DateTime? startTime = DateTime.Today;
            DateTime? expiryTime = DateTime.Today.AddDays(-1);
            DateTimeOffset? expectedSharedAccessStartTime = startTime.Value.ToUniversalTime();
            DateTimeOffset? expectedSharedAccessExpiryTime = expiryTime.Value.ToUniversalTime();
            AssertThrows<ArgumentException>(() => command.CreateAzureTableStoredAccessPolicy(command.Channel, tableName, policyName, startTime, expiryTime, null),
                String.Format(CultureInfo.CurrentCulture, Resources.ExpiryTimeGreatThanStartTime, expectedSharedAccessExpiryTime, expectedSharedAccessStartTime));
        }
    }
}
