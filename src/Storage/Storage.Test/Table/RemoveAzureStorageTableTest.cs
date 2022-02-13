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
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;

    [TestClass]
    public class RemoveAzureStorageTableTest: StorageTableStorageTestBase
    {
        internal FakeRemoveAzureTableCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            this.command = new FakeRemoveAzureTableCommand(this.tableMock)
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
        public void RemoveTableWithInvalidNameTest()
        {
            string tableName = "a*b";

            // v1 test
            AssertThrows<ArgumentException>(() => command.RemoveAzureTable(tableName),
                String.Format(Resources.InvalidTableName, tableName));

            // v2 test
            AssertThrows<ArgumentException>(() => command.RemoveAzureTableV2(this.tableMock, tableName),
                String.Format(Resources.InvalidTableName, tableName));
        }

        [TestMethod]
        public void RemvoeTableWithNotExistsTableTest()
        {
            string tableName = "test";

            // v1 test
            AssertThrows<ResourceNotFoundException>(() => command.RemoveAzureTable(tableName),
                String.Format(Resources.TableNotFound, tableName));

            // v2 test
            AssertThrows<ResourceNotFoundException>(() => command.RemoveAzureTableV2(this.tableMock, tableName),
                String.Format(Resources.TableNotFound, tableName));
        }

        [TestMethod]
        public void RemoveTableSuccessfullyTest()
        {
            // v1 test
            AddTestTables();
            bool removed = command.RemoveAzureTable("test");
            Assert.IsTrue(removed);

            AddTestTables();
            command.confirm = true;
            removed = command.RemoveAzureTable("text");
            Assert.IsTrue(removed);

            AddTestTables();
            command.Force = true;
            command.confirm = false;
            removed = command.RemoveAzureTable("text");
            Assert.IsTrue(removed);

            // v2 test
            this.tableMock.ClearAndAddTestTableV2("test", "text");
            removed = command.RemoveAzureTableV2(this.tableMock, "test");
            Assert.IsTrue(removed);

            this.tableMock.ClearAndAddTestTableV2("test", "text");
            command.confirm = true;
            removed = command.RemoveAzureTableV2(this.tableMock, "text");
            Assert.IsTrue(removed);

            this.tableMock.ClearAndAddTestTableV2("test", "text");
            command.Force = true;
            command.confirm = false;
            removed = command.RemoveAzureTableV2(this.tableMock, "text");
            Assert.IsTrue(removed);
        }

        [TestMethod]
        public void ExecuteCommandRemoveAzureTable()
        {
            // v1 test
            string name = "test";
            command.Name = name;
            AssertThrows<ResourceNotFoundException>(() => command.ExecuteCmdlet(),
                String.Format(Resources.TableNotFound, name));

            // v2 test
            this.tableMock.IsTokenCredential = true;
            AssertThrows<ResourceNotFoundException>(() => command.ExecuteCmdlet(),
                String.Format(Resources.TableNotFound, name));
        }
    }

    internal class FakeRemoveAzureTableCommand : RemoveAzureStorageTableCommand
    {
        public bool confirm = false;

        public FakeRemoveAzureTableCommand(IStorageTableManagement channel)
        {
            Channel = channel;
        }

        internal override bool ConfirmRemove(string message)
        {
            return confirm;
        }
    }
}
