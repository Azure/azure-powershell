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
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    [TestClass]
    public class RemoveAzureStorageTableTest: StorageTableStorageTestBase
    {
        internal FakeRemoveAzureTableCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new FakeRemoveAzureTableCommand(tableMock)
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
        public void RemoveTableWithInvalidNameTest()
        {
            string name = "a*b";
            AssertThrows<ArgumentException>(() => command.RemoveAzureTable(name),
                String.Format(Resources.InvalidTableName, name));
        }

        [TestMethod]
        public void RemvoeTableWithNotExistsTableTest()
        {
            string name = "test";
            AssertThrows<ResourceNotFoundException>(() => command.RemoveAzureTable(name),
                String.Format(Resources.TableNotFound, name));
        }

        [TestMethod]
        public void RemoveTableSuccessfullyTest()
        {
            AddTestTables();
            string name = "test";
            bool removed = command.RemoveAzureTable(name);
            Assert.IsTrue(removed);

            AddTestTables();
            name = "text";
            command.confirm = true;
            removed = command.RemoveAzureTable(name);
            Assert.IsTrue(removed);

            AddTestTables();
            name = "text";
            command.Force = true;
            command.confirm = false;
            removed = command.RemoveAzureTable(name);
            Assert.IsTrue(removed);
        }

        [TestMethod]
        public void ExecuteCommandRemoveAzureTable()
        {
            string name = "test";
            command.Name = name;
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
