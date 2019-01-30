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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Table
{
    [TestClass]
    public class NewAzureStorageTableTest : StorageTableStorageTestBase
    {
        public NewAzureStorageTableCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new NewAzureStorageTableCommand(tableMock)
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

        [TestMethod]
        public void CreateAzureTableWithExistTableTest()
        {
            AddTestTables();
            string name = "text";
            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureTable(name),
                String.Format(Resources.TableAlreadyExists, name));
        }

        [TestMethod]
        public void CreateAzureTableSuccessfullyTest()
        {
            string name = "test";
            AzureStorageTable table = command.CreateAzureTable(name);
            Assert.AreEqual("test", table.Name);

            AssertThrows<ResourceAlreadyExistException>(() => command.CreateAzureTable(name),
                String.Format(Resources.TableAlreadyExists, name));
        }

        [TestMethod]
        public void ExcuteCommandNewTableTest()
        {
            string name = "tablename";
            command.Name = name;
            command.ExecuteCmdlet();
            AzureStorageTable table = (AzureStorageTable)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.AreEqual(name, table.Name);
        }
    }
}
