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
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Server.Cmdlet;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class NewAzureSqlDatabaseTests : SMTestBase
    {
        /// <summary>
        /// Initialize the necessary environment for the tests.
        /// </summary>
        [TestInitialize]
        public void SetupTest()
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
        public void NewAzureSqlDatabaseWithSqlAuth()
        {
            // InitializeTest will test this scenario
        }

        [TestMethod]
        public void NewAzureSqlDatabaseWithSqlAuthDuplicateName()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");

                // Issue another create testdb1, causing a failure
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTest.NewAzureSqlDatabaseWithSqlAuthDuplicateName");
                DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
                testSession.RequestValidator =
                    new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsNotNull(actual.UserAgent);
                        switch (expected.Index)
                        {
                            // Request 0-1: Create testdb1
                            case 0:
                            case 1:
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
                    Services.Server.ServerDataServiceSqlAuth context;
                    using (new MockHttpServer(
                        exceptionManager,
                        MockHttpServer.DefaultServerPrefixUri,
                        testSession))
                    {
                        Collection<PSObject> ctxPsObject = powershell.InvokeBatchScript("$context");
                        context = (Services.Server.ServerDataServiceSqlAuth)ctxPsObject.First().BaseObject;
                        powershell.InvokeBatchScript(
                            @"New-AzureSqlDatabase " +
                            @"-Context $context " +
                            @"-DatabaseName testdb1 " +
                            @"-Force");
                    }
                }

                Assert.AreEqual(1, powershell.Streams.Error.Count, "Expecting errors");
                Assert.AreEqual(2, powershell.Streams.Warning.Count, "Expecting tracing IDs");
                Assert.AreEqual(
                    "Database 'testdb1' already exists. Choose a different database name.",
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

        /// <summary>
        /// Create $testdb1 and $testdb2 on the given context.
        /// </summary>
        /// <param name="powershell">The powershell instance containing the context.</param>
        /// <param name="contextVariable">The variable name that holds the server context.</param>
        public static void CreateTestDatabasesWithSqlAuth(
            System.Management.Automation.PowerShell powershell,
            string contextVariable)
        {
            HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTest.Common.CreateTestDatabasesWithSqlAuth");
            DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
            testSession.RequestValidator =
                new Action<HttpMessage, HttpMessage.Request>(
                (expected, actual) =>
                {
                    Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                    Assert.IsNotNull(actual.UserAgent);
                    switch (expected.Index)
                    {
                        // Request 0-2: Create testdb1
                        // Request 3-5: Create testdb2
                        // Request 6-8: Create testdb3
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
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
                Collection<PSObject> database1, database2, database3;
                using (new MockHttpServer(
                    exceptionManager,
                    MockHttpServer.DefaultServerPrefixUri,
                    testSession))
                {
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
                        @"-Edition Web " +
                        @"-MaxSizeGB 5 " +
                        @"-Force",
                        @"$testdb2");
                    database3 = powershell.InvokeBatchScript(
                        @"$testdb3 = New-AzureSqlDatabase " +
                        @"-Context $context " +
                        @"-DatabaseName testdb3 " +
                        @"-MaxSizeBytes 104857600 " +
                        @"-Force",
                        @"$testdb3");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                Services.Server.Database database = database1.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb1", "Web", 1, 1073741824L, "SQL_Latin1_General_CP1_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);

                database = database2.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb2", "Web", 5, 5368709120L, "Japanese_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);

                database = database3.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb3", "Web", 0, 104857600L, "SQL_Latin1_General_CP1_CI_AS", "Shared", false, DatabaseTestHelper.SharedSloGuid);

            }
        }

        /// <summary>
        /// Removes $testdb1 and $testdb2 on the given context.
        /// </summary>
        /// <param name="powershell">The powershell instance containing the context.</param>
        /// <param name="contextVariable">The variable name that holds the server context.</param>
        public static void RemoveTestDatabasesWithSqlAuth(
            System.Management.Automation.PowerShell powershell,
            string contextVariable)
        {
            HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTest.Common.RemoveTestDatabasesWithSqlAuth");
            DatabaseTestHelper.SetDefaultTestSessionSettings(testSession);
            testSession.RequestValidator =
                new Action<HttpMessage, HttpMessage.Request>(
                (expected, actual) =>
                {
                    Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                    Assert.IsNotNull(actual.UserAgent);
                    switch (expected.Index)
                    {
                        // Request 0-5: Remove database requests
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
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
                        @"Remove-AzureSqlDatabase " +
                        @"-Context $context " +
                        @"-DatabaseName testdb1 " +
                        @"-Force");
                    powershell.InvokeBatchScript(
                        @"Remove-AzureSqlDatabase " +
                        @"-Context $context " +
                        @"-DatabaseName testdb2 " +
                        @"-Force");
                    powershell.InvokeBatchScript(
                        @"Remove-AzureSqlDatabase " +
                        @"-Context $context " +
                        @"-DatabaseName testdb3 " +
                        @"-Force");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();
            }
        }

        /// <summary>
        /// Helper function to create the test databases.
        /// </summary>
        public static void CreateTestDatabasesWithSqlAuth()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");

                // Create the 2 test databases
                NewAzureSqlDatabaseTests.CreateTestDatabasesWithSqlAuth(
                    powershell,
                    "$context");
            }
        }

        /// <summary>
        /// Helper function to create the test databases.
        /// </summary>
        public static void CreateTestDatabasesWithCertAuth(System.Management.Automation.PowerShell powershell)
        {
            HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTest.Common.CreateTestDatabasesWithCertAuth");

            ServerTestHelper.SetDefaultTestSessionSettings(testSession);

            testSession.RequestValidator =
                new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsTrue(
                            actual.UserAgent.Contains(ApiConstants.UserAgentHeaderValue),
                            "Missing proper UserAgent string.");
                    });

            using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
            {
                Collection<PSObject> database1, database2, database3;
                using (new MockHttpServer(
                    exceptionManager,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    testSession))
                {
                    database1 = powershell.InvokeBatchScript(
                        @"$testdb1 = New-AzureSqlDatabase " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName testdb1 " +
                        @"-Force",
                        @"$testdb1");
                    database2 = powershell.InvokeBatchScript(
                        @"$testdb2 = New-AzureSqlDatabase " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName testdb2 " +
                        @"-Collation Japanese_CI_AS " +
                        @"-Edition Standard " +
                        @"-MaxSizeGB 5 " +
                        @"-Force",
                        @"$testdb2");
                    database3 = powershell.InvokeBatchScript(
                        @"$testdb3 = New-AzureSqlDatabase " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName testdb3 " +
                        @"-MaxSizeBytes 104857600 " +
                        @"-Force",
                        @"$testdb3");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                Services.Server.Database database = database1.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb1", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                database = database2.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb2", "Standard", 250, 268435456000L, "Japanese_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                database = database3.Single().BaseObject as Services.Server.Database;
                Assert.IsTrue(database != null, "Expecting a Database object");
                DatabaseTestHelper.ValidateDatabaseProperties(database, "testdb3", "Standard", 0, 104857600L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);
            }
        }

        /// <summary>
        /// Helper function to remove the test databases.
        /// </summary>
        public static void RemoveTestDatabasesWithSqlAuth()
        {
            using (System.Management.Automation.PowerShell powershell =
                System.Management.Automation.PowerShell.Create())
            {
                // Create a context
                NewAzureSqlDatabaseServerContextTests.CreateServerContextSqlAuth(
                    powershell,
                    "$context");

                // Remove the 2 test databases
                NewAzureSqlDatabaseTests.RemoveTestDatabasesWithSqlAuth(
                    powershell,
                    "$context");
            }
        }

        /// <summary>
        /// Helper function to remove the test databases.
        /// </summary>
        public static void RemoveTestDatabasesWithCertAuth(System.Management.Automation.PowerShell powershell)
        {
            HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTest.Common.RemoveTestDatabasesWithCertAuth");

            ServerTestHelper.SetDefaultTestSessionSettings(testSession);

            testSession.RequestValidator =
                new Action<HttpMessage, HttpMessage.Request>(
                    (expected, actual) =>
                    {
                        Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                        Assert.IsTrue(
                            actual.UserAgent.Contains(ApiConstants.UserAgentHeaderValue),
                            "Missing proper UserAgent string.");
                    });

            using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
            {
                using (new MockHttpServer(
                    exceptionManager,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    testSession))
                {
                    powershell.InvokeBatchScript(
                        @"Remove-AzureSqlDatabase " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName testdb1 " +
                        @"-Force");
                    powershell.InvokeBatchScript(
                        @"Remove-AzureSqlDatabase " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName testdb2 " +
                        @"-Force");
                    powershell.InvokeBatchScript(
                        @"Remove-AzureSqlDatabase " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName testdb3 " +
                        @"-Force");
                }

                powershell.Streams.ClearStreams();
            }
        }
    }
}
