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
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class SetAzureSqlDatabaseTests : SMTestBase
    {
        [TestInitialize]
        public void InitializeTest()
        {
            // Create 2 test databases
            NewAzureSqlDatabaseTests.CreateTestDatabasesWithSqlAuth();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            // Remove the test databases
            NewAzureSqlDatabaseTests.RemoveTestDatabasesWithSqlAuth();

            // Save the mock session results
            MockServerHelper.SaveDefaultSessionCollection();
        }

        [TestMethod]
        public void SetAzureSqlDatabaseSizeWithSqlAuth()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");

                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.SetAzureSqlDatabaseSizeWithSqlAuth");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsNotNull(actual.UserAgent);
                        if (expected.Index < 10)
                        {
                            // Request 0-2: Set testdb1 with new MaxSize
                            // Request 3-5: Set testdb2 with new MaxSize
                            // Request 6-7: Get updated testdb1
                            // Request 8-9: Get updated testdb2
                            DatabaseTestHelper.ValidateHeadersForODataRequest(
                                expected.RequestInfo,
                                actual);
                        }
                        else
                        {
                            Assert.Fail("No more requests expected.");
                        }
                    });

                using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
                {
                    // Create context with both ManageUrl and ServerName overriden
                    Collection<PSObject> database1,database2;
                    using (new MockHttpServer(
                        exceptionManager,
                        MockHttpServer.DefaultServerPrefixUri,
                        testSession))
                    {
                        database1 = powershell.InvokeBatchScript(
                            @"Set-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName testdb1 " +
                            @"-MaxSizeGB 5 " +
                            @"-Force " +
                            @"-PassThru");

                        // Set the database to 100MB
                        database2 = powershell.InvokeBatchScript(
                            @"Set-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName testdb2 " +
                            @"-MaxSizeBytes 104857600 " +
                            @"-Force " +
                            @"-PassThru");
                    }

                    Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                    Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                    powershell.Streams.ClearStreams();

                    Services.Server.Database database = database1.Single().BaseObject as Services.Server.Database;
                    Assert.IsTrue(database != null, "Expecting a Database object");
                    DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb1", "Web", 5, 5368709120L, "SQL_Latin1_General_CP1_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);

                    database = database2.Single().BaseObject as Services.Server.Database;
                    Assert.IsTrue(database != null, "Expecting a Database object");
                    DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb2", "Web", 0, 104857600L, "Japanese_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);
                }
            }
        }

        [TestMethod]
        public void SetAzureSqlDatabaseNameWithSqlAuth()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$contextCleanup");

                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.SetAzureSqlDatabaseNameWithSqlAuth");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsNotNull(actual.UserAgent);
                        if (expected.Index < 10)
                        {
                            // Request 0-4: Set testdb1 with new name of new_testdb1
                            // Request 5-9: Set new_testdb1 with new name of testdb1
                            DatabaseTestHelper.ValidateHeadersForODataRequest(
                                expected.RequestInfo,
                                actual);
                        }
                        else
                        {
                            Assert.Fail("No more requests expected.");
                        }
                    });

                using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
                {
                    // Create context with both ManageUrl and ServerName overriden
                    Collection<PSObject> database;
                    using (new MockHttpServer(
                        exceptionManager,
                        MockHttpServer.DefaultServerPrefixUri,
                        testSession))
                    {
                        database = powershell.InvokeBatchScript(
                           @"Set-AzureSqlDatabase " +
                           @"-Context $context " +
                           @"-DatabaseName testdb1 " +
                           @"-NewName new_testdb1 " +
                           @"-Force " +
                           @"-PassThru");
                        powershell.InvokeBatchScript(
                           @"Set-AzureSqlDatabase " +
                           @"-Context $contextCleanup " +
                           @"-DatabaseName new_testdb1 " +
                           @"-NewName testdb1 " +
                           @"-Force");
                    }

                    Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                    Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                    powershell.Streams.ClearStreams();

                    Services.Server.Database databaseObj = database.Single().BaseObject as Services.Server.Database;
                    Assert.IsNotNull(databaseObj, "Expecting a Database object");
                    DatabaseTestHelper.ValidateDatabaseProperties(databaseObj, "new_testdb1", "Web", 1, 1073741824L, "SQL_Latin1_General_CP1_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);
                }
            }
        }

        [TestMethod]
        public void SetAzureSqlDatabaseServiceObjectiveWithSqlAuth()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");

                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.SetAzureSqlDatabaseServiceObjectiveWithSqlAuth");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsNotNull(actual.UserAgent);
                        switch (expected.Index)
                        {
                            // Request 0-1: Get Service Objective
                            case 0:
                            case 1:
                            // Request 2-7: Get/Update/Re-Get testdb2
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                                DatabaseTestHelper.ValidateHeadersForODataRequest(
                                    expected.RequestInfo,
                                    actual);
                                break;
                            default:
                                Assert.Fail("No more requests expected.");
                                break;
                        }
                    });

                using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
                {
                    // Create context with both ManageUrl and ServerName overriden
                    Collection<PSObject> database;
                    using (new MockHttpServer(
                        exceptionManager,
                        MockHttpServer.DefaultServerPrefixUri,
                        testSession))
                    {
                        powershell.InvokeBatchScript(
                            @"$slo = Get-AzureSqlDatabaseServiceObjective " +
                            @"-Context $context " +
                            @"-ServiceObjectiveName ""P1""");

                        database = powershell.InvokeBatchScript(
                            @"Set-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName testdb2 " +
                            @"-ServiceObjective $slo " +
                            @"-Force " +
                            @"-PassThru");
                    }

                    Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                    Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                    powershell.Streams.ClearStreams();

                    Services.Server.Database databaseObj = database.Single().BaseObject as Services.Server.Database;
                    Assert.IsNotNull(databaseObj, "Expecting a Database object");
                    Assert.AreEqual("testdb2", databaseObj.Name, "Expected db name to be testdb2");
                    Assert.AreEqual((byte)0, databaseObj.ServiceObjectiveAssignmentState, "Expected assignment state to be complete");
                    DatabaseTestHelper.ValidateDatabaseProperties(databaseObj, "testdb2", "Web", 5, 5368709120L, "Japanese_CI_AS", "Shared", false, DatabaseTestHelper.PremiumP1SloGuid);
                }
            }
        }

        [TestMethod]
        public void SetAzureSqlPremiumDatabaseServiceObjectiveWithSqlAuth()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.SetAzureSqlPremiumDatabaseServiceObjectiveWithSqlAuth");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);                

                using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
                {
                    // Create context with both ManageUrl and ServerName overriden
                    Collection<PSObject> premiumDB;
                    using (new MockHttpServer(
                        exceptionManager,
                        MockHttpServer.DefaultServerPrefixUri,
                        testSession))
                    {
                        powershell.InvokeBatchScript(
                            @"$P1 = Get-AzureSqlDatabaseServiceObjective" +
                            @" -Context $context" +
                            @" -ServiceObjectiveName ""P1""");

                        powershell.InvokeBatchScript(
                            @"$premiumDB_P1 = New-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName SetAzureSqlPremiumDatabaseTests_P1 " +
                            @"-Edition Premium " +
                            @"-ServiceObjective $P1 ");

                        premiumDB = powershell.InvokeBatchScript(
                            @"Set-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName SetAzureSqlPremiumDatabaseTests_P1 " +
                            @"-Edition Business " +
                            @"-Force " +
                            @"-PassThru");

                        powershell.InvokeBatchScript(
                            @"Remove-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName SetAzureSqlPremiumDatabaseTests_P1 " +
                            @"-Force ");
                    }

                    Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                    Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                    powershell.Streams.ClearStreams();


                    Services.Server.Database premiumDBObj = premiumDB.Single().BaseObject as Services.Server.Database;
                    Assert.IsNotNull(premiumDBObj, "Expecting a Database object");

                    DatabaseTestHelper.ValidateDatabaseProperties(premiumDBObj, "SetAzureSqlPremiumDatabaseTests_P1", "Premium", 10, 10737418240L, "SQL_Latin1_General_CP1_CI_AS", "P1", false, DatabaseTestHelper.PremiumP1SloGuid);
                }
            }
        }
    }
}
