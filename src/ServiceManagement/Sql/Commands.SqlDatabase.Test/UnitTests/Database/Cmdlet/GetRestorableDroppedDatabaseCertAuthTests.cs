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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Server.Cmdlet;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class GetRestorableDroppedDatabaseCertAuthTests : SMTestBase
    {
        private const string deletionDateStringFormat = "yyyy-MM-ddTHH:mm:ss.FFFZ";

        private static System.Management.Automation.PowerShell powershell;

        private static string serverName;

        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            powershell = System.Management.Automation.PowerShell.Create();

            MockHttpServer.SetupCertificates();

            UnitTestHelper.SetupUnitTestSubscription(powershell);

            serverName = SqlDatabaseTestSettings.Instance.ServerName;
            powershell.Runspace.SessionStateProxy.SetVariable("serverName", serverName);

            // Create atleast two test databases
            NewAzureSqlDatabaseTests.CreateTestDatabasesWithCertAuth(powershell);

            // Remove the test databases
            NewAzureSqlDatabaseTests.RemoveTestDatabasesWithCertAuth(powershell);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            powershell.Streams.ClearStreams();

            // Save the mock session results
            MockServerHelper.SaveDefaultSessionCollection();
        }

        /// <summary>
        /// Test Get/Set/Remove a database using certificate authentication.
        /// </summary>
        [TestMethod]
        public void GetRestorableDroppedDatabaseWithCertAuth()
        {
            var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTest.GetRestorableDroppedDatabaseWithCertAuth");
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

            using (var exceptionManager = new AsyncExceptionManager())
            {
                Collection<PSObject> databases, database1, database2;

                using(new MockHttpServer(exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    databases = powershell.InvokeBatchScript(
                        @"Get-AzureSqlDatabase -RestorableDropped -ServerName $serverName");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                // Expecting testdb1, testdb2, possibly dropped databases from previous runs
                Assert.IsTrue(
                    databases.Count >= 2,
                    "Expecting at-least two RestorableDroppedDatabase objects");

                Assert.IsTrue(
                    databases[0].BaseObject is RestorableDroppedDatabase,
                    "Expecting a RestorableDroppedDatabase object");

                Assert.IsTrue(
                    databases[1].BaseObject is RestorableDroppedDatabase,
                    "Expecting a RestorableDroppedDatabase object");

                var database1Object = (RestorableDroppedDatabase)databases[0].BaseObject;
                var database1DeletionDate = database1Object.DeletionDate.ToUniversalTime().ToString(deletionDateStringFormat);

                var database2Object = (RestorableDroppedDatabase)databases[1].BaseObject;
                var database2DeletionDate = database2Object.DeletionDate.ToUniversalTime().ToString(deletionDateStringFormat);

                using (new MockHttpServer(
                    exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    database1 = powershell.InvokeBatchScript(
                        @"Get-AzureSqlDatabase -RestorableDropped " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName " + database1Object.Name + @" " +
                        @"-DatabaseDeletionDate " + database1DeletionDate);
                    database2 = powershell.InvokeBatchScript(
                        @"Get-AzureSqlDatabase -RestorableDropped " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName " + database2Object.Name + @" " +
                        @"-DatabaseDeletionDate " + database2DeletionDate);
                }

                Assert.IsTrue(
                    database1.Single().BaseObject is RestorableDroppedDatabase,
                    "Expecting a RestorableDroppedDatabase object");
                var refreshedDatabase1Object = (RestorableDroppedDatabase)database1.Single().BaseObject;
                Assert.AreEqual(
                    database1Object.Name, refreshedDatabase1Object.Name,
                    "Expected db name to be " + database1Object.Name);

                Assert.IsTrue(
                    database2.Single().BaseObject is RestorableDroppedDatabase,
                    "Expecting a RestorableDroppedDatabase object");
                var refreshedDatabase2Object = (RestorableDroppedDatabase)database2.Single().BaseObject;
                Assert.AreEqual(
                    database2Object.Name, refreshedDatabase2Object.Name,
                    "Expected db name to be " + database2Object.Name);
                Assert.AreEqual(
                    database2Object.Edition, refreshedDatabase2Object.Edition,
                    "Expected edition to be " + database2Object.Edition);
                Assert.AreEqual(
                    database2Object.MaxSizeBytes, refreshedDatabase2Object.MaxSizeBytes,
                    "Expected max size to be " + database2Object.MaxSizeBytes);
            }
        }

        [TestMethod]
        public void GetRestorableDroppedDatabaseWithCertAuthByPipe()
        {
            var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTest.GetRestorableDroppedDatabaseWithCertAuthByPipe");
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

            using (var exceptionManager = new AsyncExceptionManager())
            {
                Collection<PSObject> databases, database1, database2;
                using (new MockHttpServer(
                    exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    databases = powershell.InvokeBatchScript(
                        @"Get-AzureSqlDatabase -RestorableDropped " +
                        @"-ServerName $serverName");
                }

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Warnings during run!");
                powershell.Streams.ClearStreams();

                // Expecting testdb1, testdb2, possibly dropped databases from previous runs
                Assert.IsTrue(
                    databases.Count >= 2,
                    "Expecting at-least two RestorableDroppedDatabase objects");

                Assert.IsTrue(
                    databases[0].BaseObject is RestorableDroppedDatabase,
                    "Expecting a RestorableDroppedDatabase object");

                Assert.IsTrue(
                    databases[1].BaseObject is RestorableDroppedDatabase,
                    "Expecting a RestorableDroppedDatabase object");

                var database1Object = (RestorableDroppedDatabase)databases[0].BaseObject;
                var database1DeletionDate = database1Object.DeletionDate.ToUniversalTime().ToString(deletionDateStringFormat);

                var database2Object = (RestorableDroppedDatabase)databases[1].BaseObject;
                var database2DeletionDate = database2Object.DeletionDate.ToUniversalTime().ToString(deletionDateStringFormat);

                using (new MockHttpServer(
                    exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    powershell.InvokeBatchScript(
                        @"$testdb1 = Get-AzureSqlDatabase -RestorableDropped " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName " + database1Object.Name + @" " +
                        @"-DatabaseDeletionDate " + database1DeletionDate);

                    powershell.InvokeBatchScript(
                        @"$testdb2 = Get-AzureSqlDatabase -RestorableDropped " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName " + database2Object.Name + @" " +
                        @"-DatabaseDeletionDate " + database2DeletionDate);

                    database1 = powershell.InvokeBatchScript(
                        @"$testdb1 | Get-AzureSqlDatabase");

                    database2 = powershell.InvokeBatchScript(
                        @"$testdb2 | Get-AzureSqlDatabase");
                }

                Assert.IsTrue(
                    database1.Single().BaseObject is RestorableDroppedDatabase,
                    "Expecting a RestorableDroppedDatabase object");
                var refreshedDatabase1Object = (RestorableDroppedDatabase)database1.Single().BaseObject;
                Assert.AreEqual(
                    database1Object.Name, refreshedDatabase1Object.Name,
                    "Expected db name to be " + database1Object.Name);

                Assert.IsTrue(
                    database2.Single().BaseObject is RestorableDroppedDatabase,
                    "Expecting a RestorableDroppedDatabase object");
                var refreshedDatabase2Object = (RestorableDroppedDatabase)database2.Single().BaseObject;
                Assert.AreEqual(
                    database2Object.Name, refreshedDatabase2Object.Name,
                    "Expected db name to be " + database2Object.Name);
                Assert.AreEqual(
                    database2Object.Edition, refreshedDatabase2Object.Edition,
                    "Expected edition to be " + database2Object.Edition);
                Assert.AreEqual(
                    database2Object.MaxSizeBytes, refreshedDatabase2Object.MaxSizeBytes,
                    "Expected max size to be " + database2Object.MaxSizeBytes);
            }
        }

        [TestMethod]
        public void GetRestorableDroppedDatabaseWithCertAuthNonExistentDb()
        {
            var testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                "UnitTest.GetRestorableDroppedDatabaseWithCertAuthNonExistentDb");
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

            using (var exceptionManager = new AsyncExceptionManager())
            {
                using (new MockHttpServer(
                    exceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri, testSession))
                {
                    powershell.InvokeBatchScript(
                        @"Get-AzureSqlDatabase -RestorableDropped " +
                        @"-ServerName $serverName " +
                        @"-DatabaseName testdbnonexistent " +
                        @"-DatabaseDeletionDate '10/01/2013 12:00:00 AM'");
                }

                Assert.AreEqual(
                    1, powershell.Streams.Error.Count,
                    "Expecting errors");
                Assert.AreEqual(
                    1, powershell.Streams.Warning.Count,
                    "Expecting tracing IDs");
                Assert.AreEqual(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Resource with the name '{0}' does not exist. To continue, specify a valid resource name.",
                        "testdbnonexistent,2013-10-01T00:00:00.000Z"),
                    powershell.Streams.Error.First().Exception.Message,
                    "Unexpected error message");
                Assert.IsTrue(
                    powershell.Streams.Warning[0].Message.StartsWith("Request Id"),
                    "Expecting Client Request Id");
            }
        }
    }
}
