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
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    public class NewAzureStorageTableTest : StorageTableStorageTestBase
    {
        public NewAzureStorageTableCommand command = null;

        public NewAzureStorageTableTest()
        {
            command = new NewAzureStorageTableCommand(tableMock)
                {
                    CommandRuntime = MockCmdRunTime
                };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateAzureTableWithInvalidNameTest()
        {
            string name = String.Empty;
            AssertThrows<ArgumentException>(() => command.CreateAzureTable(name),
                String.Format(Resources.InvalidTableName, name));

            name = "a";
            AssertThrows<ArgumentException>(() => command.CreateAzureTable(name),
                String.Format(Resources.InvalidTableName, name));

            name = "&*(";
            AssertThrows<ArgumentException>(() => command.CreateAzureTable(name),
                String.Format(Resources.InvalidTableName, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateAzureTableWithExistTableTest()
        {
            AddTestTables();
            string name = "text";
            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureTable(name),
                String.Format(Resources.TableAlreadyExists, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateAzureTableSuccessfullyTest()
        {
            string name = "test";
            AzureStorageTable table = command.CreateAzureTable(name);
            Assert.Equal("test", table.Name);

            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureTable(name),
                String.Format(Resources.TableAlreadyExists, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExcuteCommandNewTableTest()
        {
            string name = "tablename";
            command.Name = name;
            command.ExecuteCmdlet();
            AzureStorageTable table = (AzureStorageTable)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.Equal(name, table.Name);
        }
    }
}
