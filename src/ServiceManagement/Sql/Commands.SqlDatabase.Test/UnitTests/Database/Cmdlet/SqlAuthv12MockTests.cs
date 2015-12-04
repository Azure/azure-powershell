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
// ---

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.TSql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class SqlAuthv12MockTests
    {
        public static string username = "testlogin";
        public static string password = "MyS3curePa$$w0rd";
        public static string manageUrl = "https://mysvr2.database.windows.net";

        [TestInitialize]
        public void Setup()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Do any test clean up here.
        }

        //[RecordMockDataResults("./")]
        [TestMethod]
        public void NewAzureSqlDatabaseWithSqlAuthv12()
        {
            var mockConn = new MockSqlConnection();
            TSqlConnectionContext.MockSqlConnection = mockConn;

            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuthV12(
                    powershell,
                    manageUrl,
                    username,
                    password,
                    "$context");

                Collection<PSObject> database1, database2, database3, database4;

                database1 = powershell.InvokeBatchScript(
                    @"$testdb1 = New-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb1 " +
                    @"-Force",
                    @"$testdb1");
                database2 = powershell.InvokeBatchScript(
                    @"$testdb2 = New-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb2 " +
                    @"-Collation Japanese_CI_AS " +
                    @"-Edition Basic " +
                    @"-MaxSizeGB 2 " +
                    @"-Force",
                    @"$testdb2");
                database3 = powershell.InvokeBatchScript(
                    @"$testdb3 = New-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb3 " +
                    @"-MaxSizeBytes 107374182400 " +
                    @"-Force",
                    @"$testdb3");
                var slo = powershell.InvokeBatchScript(
                    @"$so = Get-AzureSqlDatabaseServiceObjective " +
                    @"-Context $context " +
                    @"-ServiceObjectiveName S2 ",
                    @"$so");
                database4 = powershell.InvokeBatchScript(
                    @"$testdb4 = New-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb4 " +
                    @"-Edition Standard " +
                    @"-ServiceObjective $so " +
                    @"-Force",
                    @"$testdb4");

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                Services.Server.Database database = database1.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                ValidateDatabaseProperties(database, "testdb1", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", false, DatabaseTestHelper.StandardS0SloGuid);

                database = database2.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                ValidateDatabaseProperties(database, "testdb2", "Basic", 2, 2147483648L, "Japanese_CI_AS", false, DatabaseTestHelper.BasicSloGuid);

                database = database3.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                ValidateDatabaseProperties(database, "testdb3", "Standard", 100, 107374182400L, "SQL_Latin1_General_CP1_CI_AS", false, DatabaseTestHelper.StandardS0SloGuid);

                database = database4.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                ValidateDatabaseProperties(database, "testdb4", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", false, DatabaseTestHelper.StandardS2SloGuid);
            }
        }

        //[RecordMockDataResults("./")]
        [TestMethod]
        public void GetAzureSqlDatabaseWithSqlAuthv12()
        {
            var mockConn = new MockSqlConnection();
            TSqlConnectionContext.MockSqlConnection = mockConn;

            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuthV12(
                    powershell,
                    manageUrl,
                    username,
                    password,
                    "$context");

                Collection<PSObject> database1, database2, database3;

                database1 = powershell.InvokeBatchScript(
                    @"$testdb1 = Get-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb1 ",
                    @"$testdb1");
                database2 = powershell.InvokeBatchScript(
                    @"$testdb2 = Get-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-Database $testdb1 ",
                    @"$testdb2");
                database3 = powershell.InvokeBatchScript(
                    @"$testdb3 = Get-AzureSqlDatabase " +
                    @"-Context $context ",
                    @"$testdb3");

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                Services.Server.Database database = database1.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                ValidateDatabaseProperties(database, "testdb1", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", false, DatabaseTestHelper.StandardS0SloGuid);

                database = database2.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                ValidateDatabaseProperties(database, "testdb1", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", false, DatabaseTestHelper.StandardS0SloGuid);

                Assert.IsTrue(database3.Count == 5);
                foreach (var entry in database3)
                {
                    var db = entry.BaseObject as Services.Server.Database;
                    Assert.IsTrue(db != null, "Expecting a Database object");
                }
            }
        }

        //[RecordMockDataResults("./")]
        [TestMethod]
        public void SetAzureSqlDatabaseWithSqlAuthv12()
        {
            var mockConn = new MockSqlConnection();
            TSqlConnectionContext.MockSqlConnection = mockConn;

            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuthV12(
                    powershell,
                    manageUrl,
                    username,
                    password,
                    "$context");

                Collection<PSObject> database1, database2, database3, database4;

                database1 = powershell.InvokeBatchScript(
                    @"$testdb1 = Set-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb1 " +
                    @"-Edition Basic " +
                    @"-MaxSizeGb 1 " +
                    @"-Force " +
                    @"-PassThru ",
                    @"$testdb1");
                database2 = powershell.InvokeBatchScript(
                    @"$testdb2 = Set-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb2 " +
                    @"-Edition Standard " +
                    @"-MaxSizeBytes 107374182400 " +
                    @"-Force " +
                    @"-PassThru ",
                    @"$testdb2");
                database3 = powershell.InvokeBatchScript(
                    @"$testdb3 = Set-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb3 " +
                    @"-NewDatabaseName testdb3alt " +
                    @"-Force " +
                    @"-PassThru ",
                    @"$testdb3");
                var slo = powershell.InvokeBatchScript(
                    @"$so = Get-AzureSqlDatabaseServiceObjective " +
                    @"-Context $context " +
                    @"-ServiceObjectiveName S0 ",
                    @"$so");
                database4 = powershell.InvokeBatchScript(
                    @"$testdb4 = Set-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb4 " +
                    @"-ServiceObjective $so " +
                    @"-Force " +
                    @"-PassThru ",
                    @"$testdb4");

                //
                // Wait for operations to complete
                //

                database1 = powershell.InvokeBatchScript(
                    @"$testdb1 = Get-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb1 ",
                    @"$testdb1");
                database2 = powershell.InvokeBatchScript(
                    @"$testdb2 = Get-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb2 ",
                    @"$testdb2");
                database3 = powershell.InvokeBatchScript(
                    @"$testdb3 = Get-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb3alt ",
                    @"$testdb3");
                database4 = powershell.InvokeBatchScript(
                    @"$testdb4 = Get-AzureSqlDatabase " +
                    @"-Context $context " +
                    @"-DatabaseName testdb4 ",
                    @"$testdb4");

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                Services.Server.Database database = database1.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                ValidateDatabaseProperties(database, "testdb1", "Basic", 1, 1073741824L, "SQL_Latin1_General_CP1_CI_AS", false, DatabaseTestHelper.BasicSloGuid);

                database = database2.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                ValidateDatabaseProperties(database, "testdb2", "Standard", 100, 107374182400L, "Japanese_CI_AS", false, DatabaseTestHelper.StandardS0SloGuid);

                database = database3.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                ValidateDatabaseProperties(database, "testdb3alt", "Standard", 100, 107374182400L, "SQL_Latin1_General_CP1_CI_AS", false, DatabaseTestHelper.StandardS0SloGuid);

                database = database4.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                ValidateDatabaseProperties(database, "testdb4", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", false, DatabaseTestHelper.StandardS0SloGuid);
            }
        }

        #region Helpers

        /// <summary>
        /// Validate the properties of a database against the expected values supplied as input.
        /// </summary>
        /// <param name="database">The database object to validate</param>
        /// <param name="name">The expected name of the database</param>
        /// <param name="edition">The expected edition of the database</param>
        /// <param name="maxSizeGb">The expected max size of the database in GB</param>
        /// <param name="collation">The expected Collation of the database</param>
        /// <param name="isSystem">Whether or not the database is expected to be a system object.</param>
        internal static void ValidateDatabaseProperties(
            Services.Server.Database database,
            string name,
            string edition,
            int maxSizeGb,
            long maxSizeBytes,
            string collation,
            bool isSystem,
            Guid slo)
        {
            Assert.AreEqual(name, database.Name);
            Assert.AreEqual(edition, database.Edition);
            Assert.AreEqual(maxSizeGb, database.MaxSizeGB);
            Assert.AreEqual(maxSizeBytes, database.MaxSizeBytes);
            Assert.AreEqual(collation, database.CollationName);
            Assert.AreEqual(isSystem, database.IsSystemObject);
            // Assert.AreEqual(slo, database.ServiceObjectiveId);
        }

        #endregion
    }
}
