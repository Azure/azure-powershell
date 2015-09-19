// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
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

using System.Collections.Generic;
using Commands.Storage.ScenarioTest.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Table;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Functional.Table
{
    /// <summary>
    /// functional test for remove-azurestorage table
    /// </summary>
    [TestClass]
    public class RemoveTable : TestBase
    {
        [ClassInitialize()]
        public static void ClassInit(TestContext testContext)
        {
            TestBase.TestClassInitialize(testContext);
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            TestBase.TestClassCleanup();
        }

        /// <summary>
        /// 2.	Remove a list of existing tables by using wildcards.
        /// 8.8	Remove-AzureStorageQueue Positive Functional Cases
        ///     2.	Remove a list of existing queues by using wildcards.
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Table)]
        [TestCategory(PsTag.RemoveTable)]
        public void RemoveTableByWildCardAndPipeline()
        {
            int tableCount = GetRandomTestCount();
            string tablePrefix = "removetable";
            List<string> queueNames = Utility.GenNameLists(tablePrefix, tableCount);
            List<CloudTable> containers = tableUtil.CreateTable(queueNames);

            ((PowerShellAgent)agent).AddPipelineScript(string.Format("Get-AzureStorageTable {0}*", tablePrefix));
            Test.Assert(agent.RemoveAzureStorageTable(string.Empty), "Remove table using wildcard and pipeline should be successed");
            containers.ForEach(table => Test.Assert(!table.Exists(), string.Format("the specified table '{0}' should not exist", table.Name)));
        }

        /// <summary>
        /// Remove an table without force parameter should confirm this operation
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Table)]
        [TestCategory(PsTag.RemoveTable)]
        public void RemoveTableNeedConfirmation()
        {
            CloudTable table = tableUtil.CreateTable();

            try
            {
                Test.Assert(!agent.RemoveAzureStorageTable(table.Name, false), "remove an table without force should throw a confirmation exception");
                ExpectedContainErrorMessage(ConfirmExceptionMessage);
                Test.Assert(table.Exists(), "the table should exist");
            }
            finally
            {
                tableUtil.RemoveTable(table.Name);
            }
        }
    }
}
