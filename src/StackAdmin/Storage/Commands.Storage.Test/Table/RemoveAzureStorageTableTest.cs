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
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    public class RemoveAzureStorageTableTest: StorageTableStorageTestBase
    {
        internal FakeRemoveAzureTableCommand command = null;

        public RemoveAzureStorageTableTest()
        {
            command = new FakeRemoveAzureTableCommand(tableMock)
                {
                    CommandRuntime = MockCmdRunTime
                };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveTableWithInvalidNameTest()
        {
            string name = "a*b";
            AssertThrows<ArgumentException>(() => command.RemoveAzureTable(name),
                String.Format(Resources.InvalidTableName, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemvoeTableWithNotExistsTableTest()
        {
            string name = "test";
            AssertThrows<ResourceNotFoundException>(() => command.RemoveAzureTable(name),
                String.Format(Resources.TableNotFound, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveTableSuccessfullyTest()
        {
            AddTestTables();
            string name = "test";
            bool removed = command.RemoveAzureTable(name);
            Assert.False(removed);

            AddTestTables();
            name = "text";
            command.confirm = true;
            removed = command.RemoveAzureTable(name);
            Assert.True(removed);

            AddTestTables();
            name = "text";
            command.Force = true;
            command.confirm = false;
            removed = command.RemoveAzureTable(name);
            Assert.True(removed);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
