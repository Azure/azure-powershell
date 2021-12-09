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
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;

    [TestClass]
    public class NewAzureStorageTableTest : StorageTableStorageTestBase
    {
        public NewAzureStorageTableCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            this.command = new NewAzureStorageTableCommand(this.tableMock)
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
        public void CreateAzureTableWithInvalidNameTest()
        {
            string[] invalidTableNames =
            {
                string.Empty,
                "a",
                "&*(",
            };

            foreach (string invalidTableName in invalidTableNames)
            {
                // v1 test
                AssertThrows<ArgumentException>(() => command.CreateAzureTable(invalidTableName),
                    String.Format(Resources.InvalidTableName, invalidTableName));

                // v2 test
                AssertThrows<ArgumentException>(() => command.CreateAzureTableV2(this.tableMock, invalidTableName),
                    String.Format(Resources.InvalidTableName, invalidTableName));
            }
        }

        [TestMethod]
        public void CreateAzureTableWithExistTableTest()
        {
            string existingTableName = "text";

            // v1 test
            this.AddTestTables();
            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureTable(existingTableName),
                String.Format(Resources.TableAlreadyExists, existingTableName));

            // v2 test
            this.tableMock.ClearAndAddTestTableV2(existingTableName);
            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureTableV2(this.tableMock, existingTableName),
                String.Format(Resources.TableAlreadyExists, existingTableName));
        }

        [TestMethod]
        public void CreateAzureTableSuccessfullyTest()
        {
            // v1 test
            string tableName = "test";
            AzureStorageTable table = command.CreateAzureTable(tableName);
            Assert.AreEqual(tableName, table.Name);

            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureTable(tableName),
                String.Format(Resources.TableAlreadyExists, tableName));

            // v2 test
            tableName = "text";
            table = command.CreateAzureTableV2(this.tableMock, tableName);
            Assert.AreEqual(tableName, table.Name);

            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureTableV2(this.tableMock, tableName),
                String.Format(Resources.TableAlreadyExists, tableName));
        }

        [TestMethod]
        public void ExcuteCommandNewTableTest()
        {
            // v1 test
            this.tableMock.IsTokenCredential = false;
            string name = "test";

            command.Name = name;
            command.ExecuteCmdlet();
            AzureStorageTable table = (AzureStorageTable)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.AreEqual(name, table.Name);

            // v2 test
            this.tableMock.IsTokenCredential = true;
            name = "test";
            this.MockCmdRunTime.ResetPipelines();

            command.Name = name;
            command.ExecuteCmdlet();
            table = (AzureStorageTable)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.AreEqual(name, table.Name);
        }
    }
}
