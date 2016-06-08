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
    public class GetAzureSqlDatabaseTests : SMTestBase
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
        public void GetAzureSqlDatabaseWithSqlAuth()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");

                // Query the created test databases
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.GetAzureSqlDatabaseWithSqlAuth");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsNotNull(actual.UserAgent);
                        // 0 - 5
                        // Get all databases + ServiceObjective lookup
                        // 6 - 11
                        // get database requests, 2 requests per get.
                        if(expected.Index > 11)
                        {
                            Assert.Fail("No More Requests Expected");
                        }
                        else
                        {
                            DatabaseTestHelper.ValidateHeadersForODataRequest(
                                expected.RequestInfo,
                                actual);
                        }
                    });

                using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
                {
                    // Retrieve all databases then each individual ones
                    Collection<PSObject> databases, database1, database2, database3;
                    using (new MockHttpServer(
                        exceptionManager,
                        MockHttpServer.DefaultServerPrefixUri,
                        testSession))
                    {
                        databases = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase " +
                            @"-Context $context");
                        database1 = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName testdb1");
                        database2 = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName testdb2");
                        database3 = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName testdb3");
                    }

                    Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                    Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                    powershell.Streams.ClearStreams();

                    // Expecting master, testdb1, testdb2, testdb3
                    Assert.AreEqual(4, databases.Count, "Expecting four Database objects");

                    Services.Server.Database database = database1.Single().BaseObject as Services.Server.Database;
                    Assert.IsNotNull(database, "Expecting a Database object");
                    DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb1", "Web", 1, 1073741824L, "SQL_Latin1_General_CP1_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);

                    database = database2.Single().BaseObject as Services.Server.Database;
                    Assert.IsTrue(database != null, "Expecting a Database object");
                    DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb2", "Web", 5, 5368709120L, "Japanese_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);

                    database = database3.Single().BaseObject as Services.Server.Database;
                    Assert.IsTrue(database != null, "Expecting a Database object");
                    DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb3", "Web", 0, 104857600L, "SQL_Latin1_General_CP1_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);
                }
            }
        }

        [TestMethod]
        public void GetAzureSqlDatabaseWithSqlAuthByPipe()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");

                // Query the created test databases
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.GetAzureSqlDatabaseWithSqlAuthByPipe");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsNotNull(actual.UserAgent);
                        if (expected.Index < 12)
                        {
                            // Request 0-3: Get all databases + ServiceObjectives requests
                            // Request 4-11: 4 Get databases, 2 requests per get call
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
                    Collection<PSObject> databases, database1, database2;
                    using (new MockHttpServer(
                        exceptionManager,
                        MockHttpServer.DefaultServerPrefixUri,
                        testSession))
                    {
                        databases = powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase " +
                            @"-Context $context");
                        powershell.InvokeBatchScript(
                            @"$testdb1 = Get-AzureSqlDatabase $context -DatabaseName testdb1");
                        powershell.InvokeBatchScript(
                            @"$testdb2 = Get-AzureSqlDatabase $context -DatabaseName testdb2");
                        database1 = powershell.InvokeBatchScript(
                            @"$testdb1 | Get-AzureSqlDatabase");
                        database2 = powershell.InvokeBatchScript(
                            @"$testdb2 | Get-AzureSqlDatabase");
                    }

                    Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                    Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                    powershell.Streams.ClearStreams();

                    // Expecting master, testdb1, testdb2
                    Assert.AreEqual(
                        3, 
                        databases.Count, 
                        "Expecting three Database objects");

                    Services.Server.Database database1Obj = database1.Single().BaseObject as Services.Server.Database;
                    Assert.IsNotNull(database1Obj, "Expecting a Database object");
                    DatabaseTestHelper.ValidateDatabaseProperties(database1Obj, "testdb1", "Web", 1, 1073741824L, "SQL_Latin1_General_CP1_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);

                    Services.Server.Database database2Obj = database2.Single().BaseObject as Services.Server.Database;
                    Assert.IsNotNull(database2Obj, "Expecting a Database object");
                    DatabaseTestHelper.ValidateDatabaseProperties(database2Obj, "testdb2", "Web", 5, 5368709120L, "Japanese_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);
                }
            }
        }
        
        [TestMethod]
        public void GetAzureSqlDatabaseWithSqlAuthNonExistentDb()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");

                // Query a non-existent test database
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTests.GetAzureSqlDatabaseWithSqlAuthNonExistentDb");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsNotNull(actual.UserAgent);
                        switch (expected.Index)
                        {
                            // Request 0-2: Get database requests
                            case 0:
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
                    using (new MockHttpServer(
                        exceptionManager,
                        MockHttpServer.DefaultServerPrefixUri,
                        testSession))
                    {
                        powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName testdb3");
                    }
                }

                Assert.AreEqual(1, powershell.Streams.Error.Count, "Expecting errors");
                Assert.AreEqual(2, powershell.Streams.Warning.Count, "Expecting tracing IDs");
                Assert.AreEqual(
                    "Database 'myserver01.testdb3' not found.",
                    powershell.Streams.Error.First().Exception.Message,
                    "Unexpected error message");
                Assert.IsTrue(
                    powershell.Streams.Warning.Any(w => w.Message.StartsWith("Client Session Id")),
                    "Expecting Client Session Id");
                Assert.IsTrue(
                    powershell.Streams.Warning.Any(w => w.Message.StartsWith("Client Request Id")),
                    "Expecting Client Request Id");
                powershell.Streams.ClearStreams();
            }
        }
    }
}
