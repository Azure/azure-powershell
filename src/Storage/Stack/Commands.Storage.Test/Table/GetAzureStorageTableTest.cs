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
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;
using Microsoft.WindowsAzure.Storage.Table;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    public class GetAzureStorageTableTest : StorageTableStorageTestBase
    {
        public GetAzureStorageTableCommand command = null;

        public GetAzureStorageTableTest()
        {
            command = new GetAzureStorageTableCommand(tableMock)
                {
                    CommandRuntime = MockCmdRunTime
                };
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListTablesByNameWithEmptyNameTest()
        {
            List<CloudTable> tableList = command.ListTablesByName("").ToList();
            Assert.Equal(0, tableList.Count);

            AddTestTables();
            tableList = command.ListTablesByName("").ToList();
            Assert.Equal(2, tableList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListTablesByNameWithWildCardTest()
        {
            AddTestTables();

            List<CloudTable> tableList = command.ListTablesByName("te*t").ToList();
            Assert.Equal(2, tableList.Count);

            tableList = command.ListTablesByName("tx*t").ToList();
            Assert.Equal(0, tableList.Count);

            tableList = command.ListTablesByName("t?st").ToList();
            Assert.Equal(1, tableList.Count);
            Assert.Equal("test", tableList[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListTablesByNameWithInvalidNameTest()
        {
            string invalidName = "a";
            AssertThrows<ArgumentException>(() => command.ListTablesByName(invalidName).ToList(),
                String.Format(Resources.InvalidTableName, invalidName));

            invalidName = "xx%%d";
            AssertThrows<ArgumentException>(() => command.ListTablesByName(invalidName).ToList(),
                String.Format(Resources.InvalidTableName, invalidName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListTablesByNameWithNoExistsTableTest()
        {
            string notExistingName = "abcdefg";
            AssertThrows<ResourceNotFoundException>(() => command.ListTablesByName(notExistingName).ToList(),
                String.Format(Resources.TableNotFound, notExistingName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListTablesByNameSuccessfullyTest()
        {
            AddTestTables();
            List<CloudTable> tableList = command.ListTablesByName("text").ToList();
            Assert.Equal(1, tableList.Count);
            Assert.Equal("text", tableList[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListTablesByPrefixWithInvalidPrefixTest()
        {
            AssertThrows<ArgumentException>(() => command.ListTablesByPrefix(String.Empty),
                String.Format(Resources.InvalidTableName, String.Empty));

            string prefix = "?";
            AssertThrows<ArgumentException>(() => command.ListTablesByPrefix(prefix),
                String.Format(Resources.InvalidTableName, prefix));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListTablesByPrefixSuccessfullyTest()
        {
            AddTestTables();
            MockCmdRunTime.ResetPipelines();
            List<CloudTable> tableList = command.ListTablesByPrefix("te").ToList();
            Assert.Equal(2, tableList.Count);

            tableList = command.ListTablesByPrefix("tes").ToList();
            Assert.Equal(1, tableList.Count);
            Assert.Equal("test", tableList[0].Name);

            tableList = command.ListTablesByPrefix("testx").ToList();
            Assert.Equal(0, tableList.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WriteTablesWithStorageContextTest()
        {
            command.WriteTablesWithStorageContext(null);
            Assert.Equal(0, MockCmdRunTime.OutputPipeline.Count);

            MockCmdRunTime.ResetPipelines();
            command.WriteTablesWithStorageContext(tableMock.tableList);
            Assert.Equal(0, MockCmdRunTime.OutputPipeline.Count);

            AddTestTables();
            MockCmdRunTime.ResetPipelines();
            command.WriteTablesWithStorageContext(tableMock.tableList);
            Assert.Equal(2, MockCmdRunTime.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCommandGetTableTest()
        {
            AddTestTables();
            command.Name = "test";
            command.ExecuteCmdlet();
            Assert.Equal(1, MockCmdRunTime.OutputPipeline.Count);
        }
    }
}
