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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Commands.Storage.ScenarioTest.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest
{
    /// <summary>
    /// this class contains all the functional test cases for PowerShell Table cmdlets
    /// </summary>
    [TestClass]
    class CLITableFunc
    {
        private static CloudStorageAccount _StorageAccount;

        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Trace.WriteLine("ClassInit");
            Test.FullClassName = testContext.FullyQualifiedTestClassName;

            _StorageAccount = TestBase.GetCloudStorageAccountFromConfig();

            // import module
            string moduleFilePath = Test.Data.Get("ModuleFilePath");
            if (moduleFilePath.Length > 0)
                PowerShellAgent.ImportModule(moduleFilePath);

            // $context = New-AzureStorageContext -ConnectionString ...
            PowerShellAgent.SetStorageContext(_StorageAccount.ToString(true));
        }

        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            Trace.WriteLine("ClasssCleanup");
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Trace.WriteLine("TestInit");
            Test.Start(TestContext.FullyQualifiedTestClassName, TestContext.TestName);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Trace.WriteLine("TestCleanup");
            // do not clean up the blobs here for investigation
            // every test case should do cleanup in its init
            Test.End(TestContext.FullyQualifiedTestClassName, TestContext.TestName);
        }

        #endregion

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void CreateInvalidTable()
        {
            CreateInvalidTable(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void CreateExistingTable()
        {
            CreateExistingTable(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void TableListOperations()
        {
            TableListOperations(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void GetNonExistingTable()
        {
            GetNonExistingTable(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void EnumerateAllTables()
        {
            EnumerateAllTables(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void RemoveNonExistingTable()
        {
            RemoveNonExistingTable(new PowerShellAgent());
        }

        [TestMethod]
        [TestCategory(Tag.Function)]
        public void RemoveTableWithoutForce()
        {
            RemoveTableWithoutForce(new PowerShellAgent());
        }

        /// <summary>
        /// Functional Cases : for New-AzureStorageTable
        /// 1. Create a list of new Tables (Positive 2)
        /// 2. Create a list of Tables that already exist (Negative 4)
        /// 3. Create a list of Tables that some of them already exist (Negative 5)
        /// 
        /// Functional Cases : for Get-AzureStorageTable
        /// 4.	Get a list of Tables by using wildcards in the name (Positive 4)
        /// 5.	Get a list of tables by using Prefix parameter (Positive 2)
        /// 
        /// Functional Cases : for Remove-AzureStorageTable
        /// 6.	Remove a list of existing Tables by using pipeline (Positive 4)
        /// </summary>
        internal void TableListOperations(Agent agent)
        {
            string PREFIX = Utility.GenNameString("uniqueprefix");
            string[] TABLE_NAMES = new string[] { Utility.GenNameString(PREFIX), Utility.GenNameString(PREFIX), Utility.GenNameString(PREFIX) };

            // PART_EXISTING_NAMES differs only the last element with Table_NAMES
            string[] PARTLY_EXISTING_NAMES = new string[TABLE_NAMES.Length];
            Array.Copy(TABLE_NAMES, PARTLY_EXISTING_NAMES, TABLE_NAMES.Length - 1);
            PARTLY_EXISTING_NAMES[TABLE_NAMES.Length - 1] = Utility.GenNameString(PREFIX);

            string[] MERGED_NAMES = TABLE_NAMES.Union(PARTLY_EXISTING_NAMES).ToArray();
            Array.Sort(MERGED_NAMES);

            // Generate the comparison data
            Collection<Dictionary<string, object>> comp = new Collection<Dictionary<string, object>>();
            foreach (string name in MERGED_NAMES)
            {
                comp.Add(Utility.GenComparisonData(StorageObjectType.Table, name));
            }

            CloudTableClient tableClient = _StorageAccount.CreateCloudTableClient();

            // Check if all the above Tables have been removed
            foreach (string name in MERGED_NAMES)
            {
                CloudTable Table = tableClient.GetTableReference(name);
                Table.DeleteIfExists();
            }

            //--------------1. New operation--------------
            Test.Assert(agent.NewAzureStorageTable(TABLE_NAMES), Utility.GenComparisonData("NewAzureStorageTable", true));
            // Verification for returned values
            Test.Assert(agent.Output.Count == TABLE_NAMES.Count(), "{0} row returned : {1}", TABLE_NAMES.Count(), agent.Output.Count);

            // Check if all the above tables have been created
            foreach (string name in TABLE_NAMES)
            {
                CloudTable table = tableClient.GetTableReference(name);
                Test.Assert(table.Exists(), "table {0} should exist", name);
            }

            try
            {
                //--------------2. New operation--------------
                Test.Assert(!agent.NewAzureStorageTable(TABLE_NAMES), Utility.GenComparisonData("NewAzureStorageTable", false));
                // Verification for returned values
                Test.Assert(agent.Output.Count == 0, "0 row returned : {0}", agent.Output.Count);
                int i = 0;
                foreach (string name in TABLE_NAMES)
                {
                    Test.Assert(agent.ErrorMessages[i].Equals(String.Format("Table '{0}' already exists.", name)), agent.ErrorMessages[i]);
                    ++i;
                }

                //--------------3. New operation--------------
                Test.Assert(!agent.NewAzureStorageTable(PARTLY_EXISTING_NAMES), Utility.GenComparisonData("NewAzureStorageTable", false));
                // Verification for returned values
                Test.Assert(agent.Output.Count == 1, "1 row returned : {0}", agent.Output.Count);

                // Check if all the above tables have been created
                foreach (string name in TABLE_NAMES)
                {
                    CloudTable table = tableClient.GetTableReference(name);
                    Test.Assert(table.Exists(), "table {0} should exist", name);
                }

                //--------------4. Get operation--------------
                Test.Assert(agent.GetAzureStorageTable("*" + PREFIX + "*"), Utility.GenComparisonData("GetAzureStorageTable", true));
                // Verification for returned values
                agent.OutputValidation(_StorageAccount.CreateCloudTableClient().ListTables(PREFIX));

                // use Prefix parameter
                Test.Assert(agent.GetAzureStorageTableByPrefix(PREFIX), Utility.GenComparisonData("GetAzureStorageTableByPrefix", true));
                // Verification for returned values
                agent.OutputValidation(_StorageAccount.CreateCloudTableClient().ListTables(PREFIX));
            }
            finally { 
                //--------------5. Remove operation--------------
                Test.Assert(agent.RemoveAzureStorageTable(MERGED_NAMES), Utility.GenComparisonData("RemoveAzureStorageTable", true));
                // Check if all the above tables have been removed
                foreach (string name in TABLE_NAMES)
                {
                    CloudTable table = tableClient.GetTableReference(name);
                    Test.Assert(!table.Exists(), "table {0} should not exist", name);
                }
            }
        }

        /// <summary>
        /// Negative Functional Cases : for New-AzureStorageTable 
        /// 1. Create a Table that already exists (Negative 3)
        /// </summary>
        internal void CreateExistingTable(Agent agent)
        {
            string TABLE_NAME = Utility.GenNameString("existing");

            // create table if not exists
            CloudTable table = _StorageAccount.CreateCloudTableClient().GetTableReference(TABLE_NAME);
            table.CreateIfNotExists();

            try
            {
                //--------------New operation--------------
                Test.Assert(!agent.NewAzureStorageTable(TABLE_NAME), Utility.GenComparisonData("NewAzureStorageTable", false));
                // Verification for returned values
                Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);
                Test.Assert(agent.ErrorMessages[0].Equals(String.Format("Table '{0}' already exists.", TABLE_NAME)), agent.ErrorMessages[0]);
            }
            finally
            {
                // Recover the environment
                table.DeleteIfExists();
            }
        }

        /// <summary>
        /// Negative Functional Cases : for New-AzureStorageTable 
        /// 1. Create a new table with an invalid table name (Negative 1)
        /// </summary>
        internal void CreateInvalidTable(Agent agent)
        {
            string tableName = Utility.GenNameString("abc_");

            //--------------New operation--------------
            Test.Assert(!agent.NewAzureStorageTable(tableName), Utility.GenComparisonData("NewAzureStorageTable", false));
            // Verification for returned values
            Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);
            Test.Assert(agent.ErrorMessages[0].StartsWith(String.Format("Table name '{0}' is invalid.", tableName)), agent.ErrorMessages[0]);
        }


        /// <summary>
        /// Negative Functional Cases : for Get-AzureStorageTable 
        /// 1. Get a non-existing table (Negative 1)
        /// </summary>
        internal void GetNonExistingTable(Agent agent)
        {
            string TABLE_NAME = Utility.GenNameString("nonexisting");

            // Delete the table if it exists
            CloudTable table = _StorageAccount.CreateCloudTableClient().GetTableReference(TABLE_NAME);
            table.DeleteIfExists();

            //--------------Get operation--------------
            Test.Assert(!agent.GetAzureStorageTable(TABLE_NAME), Utility.GenComparisonData("GetAzureStorageTable", false));
            // Verification for returned values
            Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);
            Test.Assert(agent.ErrorMessages[0].Equals(String.Format("Can not find table '{0}'.", TABLE_NAME)), agent.ErrorMessages[0]);
        }

        /// <summary>
        /// Functional Cases : for Get-AzureStorageTable
        /// 1. Validate that all the tables can be enumerated (Positive 5)
        /// </summary>
        internal void EnumerateAllTables(Agent agent)
        {
            //--------------Get operation--------------
            Test.Assert(agent.GetAzureStorageTable(""), Utility.GenComparisonData("EnumerateAllTables", false));

            // Verification for returned values
            agent.OutputValidation(_StorageAccount.CreateCloudTableClient().ListTables());
        }

        /// <summary>
        /// Negative Functional Cases : for Remove-AzureStorageTable 
        /// 1. Remove a non-existing table (Negative 2)
        /// </summary>
        internal void RemoveNonExistingTable(Agent agent)
        {
            string TABLE_NAME = Utility.GenNameString("nonexisting");

            // Delete the table if it exists
            CloudTable table = _StorageAccount.CreateCloudTableClient().GetTableReference(TABLE_NAME);
            table.DeleteIfExists();

            //--------------Remove operation--------------
            Test.Assert(!agent.RemoveAzureStorageTable(TABLE_NAME), Utility.GenComparisonData("RemoveAzureStorageTable", false));
            // Verification for returned values
            Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);
            Test.Assert(agent.ErrorMessages[0].Equals(String.Format("Can not find table '{0}'.", TABLE_NAME)), agent.ErrorMessages[0]);
        }

        /// <summary>
        /// Negative Functional Cases : for Remove-AzureStorageTable 
        /// 1. Remove the table without by force (Negative 3)
        /// </summary>
        internal void RemoveTableWithoutForce(Agent agent)
        {
            string TABLE_NAME = Utility.GenNameString("withoutforce");

            // create table if not exists
            CloudTable table = _StorageAccount.CreateCloudTableClient().GetTableReference(TABLE_NAME);
            table.CreateIfNotExists();

            try
            {
                //--------------Remove operation--------------
                Test.Assert(!agent.RemoveAzureStorageTable(TABLE_NAME, false), Utility.GenComparisonData("RemoveAzureStorageTable", false));
                // Verification for returned values
                Test.Assert(agent.Output.Count == 0, "Only 0 row returned : {0}", agent.Output.Count);
                Test.Assert(agent.ErrorMessages[0].StartsWith("A command that prompts the user failed because"), agent.ErrorMessages[0]);
            }
            finally
            {
                // Recover the environment
                table.DeleteIfExists();
            }
        }
    }
}
