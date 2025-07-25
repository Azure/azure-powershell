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
    using System.Collections.Generic;
    using System.Linq;
    using global::Azure.Data.Tables;
    using Microsoft.Azure.Cosmos.Table;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;
    using Microsoft.WindowsAzure.Commands.Storage.Test.Service;

    [TestClass]
    public class GetAzureStorageTableTest : StorageTableStorageTestBase
    {
        public GetAzureStorageTableCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            this.command = new GetAzureStorageTableCommand(this.tableMock)
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
        public void ListTablesByNameWithEmptyListTest()
        {
            // v1 test
            IEnumerable<CloudTable> v1Tables = this.command.ListTablesByName(name: string.Empty);
            Assert.AreEqual(0, v1Tables.Count());

            // v2 test
            IEnumerable<AzureStorageTable> v2Tables = this.command.ListTablesByNameV2(this.tableMock, tableName: string.Empty);
            Assert.AreEqual(0, v2Tables.Count());
        }

        [TestMethod]
        public void ListTablesByNameSuccessfullyTest()
        {
            this.AddTestTables();
            this.tableMock.ClearAndAddTestTableV2("test", "text");

            Dictionary<string, int> tables = new Dictionary<string, int>
            {
                { string.Empty, 2 },
                { "te*t", 2 },
                { "tx*t", 0 },
                { "t?st", 1 },
                { "test", 1 },
            };

            foreach (KeyValuePair<string, int> table in tables)
            {
                // v1 test
                IEnumerable<CloudTable> v1Tables = this.command.ListTablesByName(name: table.Key);
                Assert.AreEqual(table.Value, v1Tables.Count());

                if (table.Value == 1)
                {
                    Assert.AreEqual("test", v1Tables.ToArray()[0].Name);
                }

                // v2 test
                IEnumerable<AzureStorageTable> v2Tables = this.command.ListTablesByNameV2(this.tableMock, tableName: table.Key);
                Assert.AreEqual(table.Value, v2Tables.Count());

                if (table.Value == 1)
                {
                    Assert.AreEqual("test", v2Tables.ToArray()[0].Name);
                }
            }
        }

        [TestMethod]
        public void ListTablesByNameWithInvalidNameTest()
        {
            string[] invalidTableNames =
            {
                "a",
                "xx%%d",
            };

            foreach (string invalidTableName in invalidTableNames)
            {
                // v1 test
                AssertThrows<ArgumentException>(
                    () => this.command.ListTablesByName(invalidTableName).ToList(),
                    String.Format(Resources.InvalidTableName, invalidTableName));

                // v2 test
                AssertThrows<ArgumentException>(
                    () => this.command.ListTablesByNameV2(this.tableMock, invalidTableName).ToList(),
                    String.Format(Resources.InvalidTableName, invalidTableName));
            }
        }

        [TestMethod]
        public void ListTablesByNameWithNoExistsTableTest()
        {
            string notExistingName = "abcdefg";

            // v1 test
            AssertThrows<ResourceNotFoundException>(
                () => this.command.ListTablesByName(notExistingName).ToList(),
                String.Format(Resources.TableNotFound, notExistingName));

            // v2 test
            AssertThrows<ResourceNotFoundException>(
                () => this.command.ListTablesByNameV2(this.tableMock, notExistingName).ToList(),
                String.Format(Resources.TableNotFound, notExistingName));
        }

        [TestMethod]
        public void ListTablesByPrefixWithInvalidPrefixTest()
        {
            string[] invalidPrefixes =
            {
                string.Empty,
                "?",
            };

            foreach (string invalidPrefix in invalidPrefixes)
            {
                // v1 test
                AssertThrows<ArgumentException>(
                    () => this.command.ListTablesByPrefix(invalidPrefix).ToList(),
                    String.Format(Resources.InvalidTableName, invalidPrefix));

                // v2 test
                AssertThrows<ArgumentException>(
                    () => this.command.ListTablesByPrefixV2(this.tableMock, invalidPrefix).ToList(),
                    String.Format(Resources.InvalidTableName, invalidPrefix));
            }
        }

        [TestMethod]
        public void ListTablesByPrefixSuccessfullyTest()
        {
            this.AddTestTables();
            this.tableMock.ClearAndAddTestTableV2("test", "text");

            Dictionary<string, int> tables = new Dictionary<string, int>
            {
                { "te", 2 },
                { "test", 1 },
            };

            foreach (KeyValuePair<string, int> table in tables)
            {
                // v1 test
                IEnumerable<CloudTable> v1Tables = this.command.ListTablesByPrefix(prefix: table.Key);
                Assert.AreEqual(table.Value, v1Tables.Count());

                if (table.Value == 1)
                {
                    Assert.AreEqual("test", v1Tables.ToArray()[0].Name);
                }

                // v2 test
                IEnumerable<AzureStorageTable> v2Tables = this.command.ListTablesByPrefixV2(this.tableMock, prefix: table.Key);
                Assert.AreEqual(table.Value, v2Tables.Count());

                if (table.Value == 1)
                {
                    Assert.AreEqual("test", v2Tables.ToArray()[0].Name);
                }
            }
        }

        [TestMethod]
        public void WriteTablesWithStorageContextTest()
        {
            // v1 test
            this.command.WriteTablesWithStorageContext((IEnumerable<CloudTable>)null);
            Assert.AreEqual(0, this.MockCmdRunTime.OutputPipeline.Count);

            this.MockCmdRunTime.ResetPipelines();
            this.command.WriteTablesWithStorageContext(new CloudTable[] { });
            Assert.AreEqual(0, this.MockCmdRunTime.OutputPipeline.Count);

            CloudTable[] v1Tables =
            {
                new CloudTable(new Uri($"{MockStorageTableManagement.TableEndPoint}test")),
                new CloudTable(new Uri($"{MockStorageTableManagement.TableEndPoint}text")),
            };

            this.MockCmdRunTime.ResetPipelines();
            this.command.WriteTablesWithStorageContext(v1Tables);
            Assert.AreEqual(2, this.MockCmdRunTime.OutputPipeline.Count);

            // v2 test
            this.MockCmdRunTime.ResetPipelines();
            this.command.WriteTablesWithStorageContext((IEnumerable<AzureStorageTable>)null);
            Assert.AreEqual(0, this.MockCmdRunTime.OutputPipeline.Count);

            this.MockCmdRunTime.ResetPipelines();
            this.command.WriteTablesWithStorageContext(new AzureStorageTable[] { });
            Assert.AreEqual(0, this.MockCmdRunTime.OutputPipeline.Count);

            TableClient[] v2Tables =
            {
                new TableClient(new Uri($"{MockStorageTableManagement.TableEndPoint}test")),
                new TableClient(new Uri($"{MockStorageTableManagement.TableEndPoint}text")),
            };

            this.MockCmdRunTime.ResetPipelines();
            this.command.WriteTablesWithStorageContext(v2Tables.Select(t => new AzureStorageTable(t)));
            Assert.AreEqual(2, this.MockCmdRunTime.OutputPipeline.Count);
        }

        [TestMethod]
        public void ExecuteCommandGetTableTest()
        {
            // v1 test
            this.tableMock.IsTokenCredential = false;
            AddTestTables();

            command.Name = "test";
            command.ExecuteCmdlet();
            Assert.AreEqual(1, MockCmdRunTime.OutputPipeline.Count);

            // v2 test
            this.tableMock.IsTokenCredential = true;
            this.tableMock.ClearAndAddTestTableV2("test", "text");
            this.MockCmdRunTime.ResetPipelines();

            command.Name = "test";
            command.ExecuteCmdlet();
            Assert.AreEqual(1, MockCmdRunTime.OutputPipeline.Count);
        }
    }
}
