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
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Model;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Server.Cmdlet;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class AzureSqlDatabaseCopyCertAuthTests : SMTestBase
    {
        private DateTime TestStartTime { get; set; }

        // Change this if you wish to run against OneBox.
        private bool IsRunningAgainstOneBox { get { return false; } }

        private System.Management.Automation.PowerShell PowerShell { get; set; }

        AzureSubscription Subscription { get; set; }

        private AsyncExceptionManager ExceptionManager { get; set; }
        private MockHttpServer MockHttpServer { get; set; }

        private string HomeServer { get { return "cloud4"; } }
        private string PartnerServer { get { return "partnersrv"; } }

        [TestInitialize]
        public void InitializeTest()
        {
            TestStartTime = DateTime.Now;

            // This test uses the https endpoint, setup the certificates.
            MockHttpServer.SetupCertificates();
            PowerShell = System.Management.Automation.PowerShell.Create();
            Subscription = UnitTestHelper.SetupUnitTestSubscription(PowerShell);

            // Set names for the servers we'll use in PowerShell.
            PowerShell.Runspace.SessionStateProxy.SetVariable(
                "homeServerName", HomeServer);

            PowerShell.Runspace.SessionStateProxy.SetVariable(
                "partnerServerName", PartnerServer);

            // Create a new server
            HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                string.Format("UnitTest.{0}.{1}", TestContext.FullyQualifiedTestClassName, TestContext.TestName));

            ServerTestHelper.SetDefaultTestSessionSettings(testSession);

            // When testing production use RDFE
            // testSession.ServiceBaseUri = new Uri("https://management.core.windows.net");
            // When testing OneBox use Mock RDFE:
            if (IsRunningAgainstOneBox)
            {
                testSession.ServiceBaseUri = new Uri("https://management.dev.mscds.com:12346/");
            }

            testSession.RequestValidator =
                new Action<HttpMessage, HttpMessage.Request>(
                (expected, actual) =>
                {
                    Assert.AreEqual(expected.RequestInfo.Method, actual.Method);
                    Assert.IsTrue(
                        actual.UserAgent.Contains(ApiConstants.UserAgentHeaderValue),
                        "Missing proper UserAgent string.");
                });

            ExceptionManager = new AsyncExceptionManager();
            MockHttpServer = new MockHttpServer(ExceptionManager, MockHttpServer.DefaultHttpsServerPrefixUri,
                                                testSession);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            try
            {
                foreach (string server in new string[] {HomeServer, PartnerServer})
                {
                    PowerShell.InvokeBatchScript(
                        string.Format("Get-AzureSqlDatabase -ServerName {0} " +
                                        "| where {{ $_.Name -ne 'master' }} " +
                                        "| Remove-AzureSqlDatabase -ServerName {0} -Force",
                                        server));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cleaning up servers: {0}", ex.Message);
            }

            MockHttpServer.Dispose();
            ExceptionManager.Dispose();
            PowerShell.Dispose();

            // Save the mock session results
            MockServerHelper.SaveDefaultSessionCollection();
        }

        private void CreateDatabase(string serverName, string dbName, string dbVar = null, string dbNameVar = null)
        {

            PowerShell.InvokeBatchScript(
                @"$createdDb = New-AzureSqlDatabase" +
                @" -ServerName " + serverName +
                @" -DatabaseName " + dbName,
                @"$createdDb");

            if (dbVar != null)
            {
                PowerShell.InvokeBatchScript(dbVar + " = $createdDb", dbVar);
            }

            if (dbNameVar != null)
            {
                PowerShell.InvokeBatchScript(dbNameVar + " = $createdDb.Name", dbNameVar);
            }
        }

        /// <summary>
        /// Test starting non-continuous copies.
        /// </summary>
        [TestMethod]
        public void AzureSqlDatabaseCopyCertTests()
        {
            const string srcDbName = "testdb0";
            const string tgtName1 = "testdb0copy1";
            const string tgtName2 = "testdb0copy2";

            CreateDatabase(HomeServer, srcDbName, "$db0", "$dbName0");

            // Try some non-continuous database copies.
            Collection<PSObject> response = PowerShell.InvokeBatchScript(
                @"$copy1 = Start-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -Database $db0" +
                @" -PartnerServer $homeServerName" +
                @" -PartnerDatabase " + tgtName1,
                @"$copy1");

            VerifyDbCopyResponse(response, HomeServer, srcDbName, tgtName1, false);

            // When unspecified, the partner server should be the local server.
            response = PowerShell.InvokeBatchScript(
                @"$copy2 = Start-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -DatabaseName $dbName0" +
                @" -PartnerDatabase " + tgtName2,
                @"$copy2");

            VerifyDbCopyResponse(response, HomeServer, srcDbName, tgtName2, false);

            response = PowerShell.InvokeBatchScript("Get-AzureSqlDatabase $homeServerName");
            Assert.AreEqual(4, response.Count, "Expected a total of 4 databases with the new copies");

            Assert.AreEqual(0, PowerShell.Streams.Error.Count, "Unexpected Errors during run!");
            Assert.AreEqual(0, PowerShell.Streams.Warning.Count, "Unexpected Warnings during run!");
        }

        /// <summary>
        /// Test Start/Stop/Get a database copy using certificate authentication.
        /// </summary>
        [TestMethod]
        public void AzureSqlContinuousDatabaseCopyCertTests()
        {
            // Create some databases to be used in the tests.
            var dbNames = new string[] { "testdb0", "testdb1", "testdb2", "testdb3", "testdb4" };

            CreateDatabase(HomeServer, dbNames[0], "$db0", "$dbName0");
            CreateDatabase(HomeServer, dbNames[1], "$db1", "$dbName1");
            CreateDatabase(PartnerServer, dbNames[2], "$db2", "$dbName2");
            CreateDatabase(PartnerServer, dbNames[3], "$db3", "$dbName3");
            CreateDatabase(HomeServer, dbNames[4], "$db4", "$dbName4");

            Collection<PSObject> response;

            // Call Start-AzureSqlDatabaseCopy with different parameter sets.
            // After each call, we wait for seeding completion before moving on.
            // We test for seeding completion using Get-AzureSqlDatabaseCopy calls.

            response = PowerShell.InvokeBatchScript(
                @"$copy1 = Start-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -PartnerServer $partnerServerName" +
                @" -DatabaseName $dbName0" +
                @" -ContinuousCopy",
                @"$copy1");

            VerifyCcResponse(response, HomeServer, dbNames[0], PartnerServer, false);

            response = PowerShell.InvokeBatchScript(
                @"$copy2 = Start-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -Database $db1" +
                @" -PartnerServer $partnerServerName" +
                @" -PartnerDatabase $dbName1" +
                @" -Force" +
                @" -ContinuousCopy",
                @"$copy2");

            VerifyCcResponse(response, HomeServer, dbNames[1], PartnerServer, false);

            response = PowerShell.InvokeBatchScript(
                @"$copy3 = Start-AzureSqlDatabaseCopy" +
                @" -ServerName $partnerServerName" +
                @" -DatabaseName $dbName2" +
                @" -PartnerServer $homeServerName" +
                @" -ContinuousCopy",
                @"$copy3");

            // null = no RPO (the default)
            VerifyCcResponse(response, PartnerServer, dbNames[2], HomeServer, false);

            response = PowerShell.InvokeBatchScript(
                @"$copy4 = Start-AzureSqlDatabaseCopy" +
                @" -ServerName $partnerServerName" +
                @" -Database $db3" +
                @" -PartnerServer $homeServerName" +
                @" -PartnerDatabase $dbName3" +
                @" -Force" +
                @" -ContinuousCopy",
                @"$copy4");

            VerifyCcResponse(response, PartnerServer, dbNames[3], HomeServer, false);

            // Start a passive continuous copy
            response = PowerShell.InvokeBatchScript(
                @"$copy5 = Start-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -PartnerServer $partnerServerName" +
                @" -DatabaseName $dbName4" +
                @" -ContinuousCopy" +
                @" -OfflineSecondary",
                @"$copy5");

            VerifyCcResponse(response, HomeServer, dbNames[4], PartnerServer, false, true);

            // Wait for all of the new copies to reach catchup.
            WaitForSeedingCompletion(HomeServer, dbNames[0], PartnerServer);
            WaitForSeedingCompletion(HomeServer, dbNames[1], PartnerServer);
            WaitForSeedingCompletion(PartnerServer, dbNames[2], HomeServer);
            WaitForSeedingCompletion(PartnerServer, dbNames[3], HomeServer);
            WaitForSeedingCompletion(HomeServer, dbNames[4], PartnerServer);

            // Do some Get-AzureSqlDatabaseCopy calls with different parameter sets.

            response = PowerShell.InvokeBatchScript(
                @"Get-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -DatabaseCopy $copy1");

            VerifyCcResponse(response, HomeServer, dbNames[0], PartnerServer, false);

            response = PowerShell.InvokeBatchScript(
                @"Get-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -DatabaseName $dbName1" +
                @" -PartnerServer $partnerServerName" +
                @" -PartnerDatabase $dbName1");

            VerifyCcResponse(response, HomeServer, dbNames[1], PartnerServer, false);

            response = PowerShell.InvokeBatchScript(
                @"Get-AzureSqlDatabaseCopy" +
                @" -ServerName $partnerServerName" +
                @" -Database $db0");

            VerifyCcResponse(response, HomeServer, dbNames[0], PartnerServer, true);

            response = PowerShell.InvokeBatchScript(
                @"Get-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName");

            Assert.AreEqual(5, response.Count);
            DatabaseCopy[] allCopies = response.Select(obj => obj.BaseObject as DatabaseCopy).ToArray();
            foreach (var copy in allCopies)
            {
                Assert.IsNotNull(copy, "Expected object of type DatabaseCopy");
            }

            Array.Sort(allCopies,
                        (dbc1, dbc2) => string.Compare(dbc1.SourceDatabaseName, dbc2.SourceDatabaseName));

            VerifyCopyResponse(allCopies[0], HomeServer, dbNames[0], PartnerServer, dbNames[0], false, true, false);
            VerifyCopyResponse(allCopies[1], HomeServer, dbNames[1], PartnerServer, dbNames[1], false, true, false);
            VerifyCopyResponse(allCopies[2], PartnerServer, dbNames[2], HomeServer, dbNames[2], true, true, false);
            VerifyCopyResponse(allCopies[3], PartnerServer, dbNames[3], HomeServer, dbNames[3], true, true, false);
            VerifyCopyResponse(allCopies[4], HomeServer, dbNames[4], PartnerServer, dbNames[4], false, true, true);

            response = PowerShell.InvokeBatchScript(
                @"Get-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -PartnerServer $partnerServerName" +
                @" -PartnerDatabase $dbName0");

            VerifyCcResponse(response, HomeServer, dbNames[0], PartnerServer, false);

            // Call Stop-AzureSqlDatbaseCopy with different parameter sets.

            PowerShell.InvokeBatchScript(
                @"Stop-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -DatabaseCopy $copy1");

            PowerShell.InvokeBatchScript(
                @"Stop-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -Database $db1" +
                @" -ForcedTermination");

            PowerShell.InvokeBatchScript(
                @"Stop-AzureSqlDatabaseCopy" +
                @" -ServerName $partnerServerName" +
                @" -DatabaseName $dbName2" +
                @" -PartnerServer $homeServerName" +
                @" -PartnerDatabase $dbName2");

            PowerShell.InvokeBatchScript(
                @"Stop-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -DatabaseName $dbName3" +
                @" -ForcedTermination");

            PowerShell.InvokeBatchScript(
                @"Stop-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName" +
                @" -DatabaseName $dbName4" +
                @" -ForcedTermination");

            WaitForCopyTermination(HomeServer, dbNames[0], PartnerServer);
            WaitForCopyTermination(HomeServer, dbNames[1], PartnerServer);
            WaitForCopyTermination(PartnerServer, dbNames[2], HomeServer);
            WaitForCopyTermination(HomeServer, dbNames[3], PartnerServer);
            WaitForCopyTermination(HomeServer, dbNames[4], PartnerServer);

            // Make sure there are no longer any copies on the server.
            response = PowerShell.InvokeBatchScript(
                @"Get-AzureSqlDatabaseCopy" +
                @" -ServerName $homeServerName");

            Assert.AreEqual(0, response.Count, "Expected copies to have been terminated");

            Assert.AreEqual(0, PowerShell.Streams.Error.Count, "Unexpected Errors during run!");
            Assert.AreEqual(0, PowerShell.Streams.Warning.Count, "Unexpected Warnings during run!");
        }

        private void WaitForSeedingCompletion(string sourceServer, string sourceDb, string destServer)
        {
            for (int i = 0; i < 20; i++)
            {
                Collection<PSObject> testCopyCompleteResponse = PowerShell
                    .InvokeBatchScript(
                        @"Get-AzureSqlDatabaseCopy" +
                        @" -ServerName " + sourceServer +
                        @" -DatabaseName " + sourceDb +
                        @" -PartnerServer " + destServer);

                VerifyCcResponse(testCopyCompleteResponse, sourceServer, sourceDb, destServer, false);

                var testCopyComplete = (DatabaseCopy)testCopyCompleteResponse.First().BaseObject;
                if (testCopyComplete.ReplicationStateDescription == "CATCH_UP")
                {
                    return;
                }

                if (IsRunningAgainstOneBox)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                }
            }

            Assert.Fail("Continuous copy of source database " + sourceDb + " failed to reach CATCH_UP state");
        }

        private void WaitForCopyTermination(string sourceServer, string sourceDb, string destServer)
        {
            for (int i = 0; i < 20; i++)
            {
                Collection<PSObject> response = PowerShell
                    .InvokeBatchScript(
                        @"Get-AzureSqlDatabaseCopy" +
                        @" -ServerName " + sourceServer +
                        @" -DatabaseName " + sourceDb +
                        @" -PartnerServer " + destServer);

                if (response.Count == 0)
                {
                    return;
                }

                if (IsRunningAgainstOneBox)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                }
            }

            Assert.Fail("Continuous copy of source database " + sourceDb + " failed to be terminated");
        }

        private void VerifyCcResponse(Collection<PSObject> result, string sourceServer, string sourceDb,
                                        string destServer, bool isLocalDatabaseReplicationTarget, bool? isOfflineSecondary = null)
        {
            VerifyCopyResponse(result, sourceServer, sourceDb, destServer, sourceDb, isLocalDatabaseReplicationTarget, true, isOfflineSecondary);
        }

        private void VerifyDbCopyResponse(Collection<PSObject> result, string sourceServer, string sourceDb, 
                                        string destDb, bool isLocalDatabaseReplicationTarget)
        {
            VerifyCopyResponse(result, sourceServer, sourceDb, sourceServer, destDb, isLocalDatabaseReplicationTarget, false, false);
        }

        private void VerifyCopyResponse(Collection<PSObject> result, string sourceServer, string sourceDb,
                                        string destServer,  string destDb, bool isLocalDatabaseReplicationTarget,
                                        bool isContinuous, bool? isOfflineSecondary)
        {
            Assert.AreEqual(1, result.Count, "Expected exactly one result from cmdlet");
            var copy = result.First().BaseObject as DatabaseCopy;
            Assert.IsNotNull(copy, "Expected object of type DatabaseCopy");
            VerifyCopyResponse(copy, sourceServer, sourceDb, destServer, destDb, isLocalDatabaseReplicationTarget, isContinuous, isOfflineSecondary);
        }

        private void VerifyCopyResponse(DatabaseCopy copy, string sourceServer, string sourceDb,
                                        string destServer, string destDb, bool isLocalDatabaseReplicationTarget,
                                        bool isContinuous, bool? isOfflineSecondary)
        {
            Assert.AreEqual(sourceServer, copy.SourceServerName);
            Assert.AreEqual(sourceDb, copy.SourceDatabaseName);
            Assert.AreEqual(destServer, copy.DestinationServerName);
            Assert.AreEqual(destDb, copy.DestinationDatabaseName);
            Assert.AreEqual(isContinuous, copy.IsContinuous);
            Assert.AreEqual(isLocalDatabaseReplicationTarget, copy.IsLocalDatabaseReplicationTarget);
            Assert.IsTrue(copy.IsInterlinkConnected);
            if (isOfflineSecondary.HasValue)
            {
                Assert.AreEqual(isOfflineSecondary, copy.IsOfflineSecondary);
            }

            if (IsRunningAgainstOneBox)
            {
                Assert.IsTrue(copy.StartDate > TestStartTime);
                Assert.IsTrue(copy.StartDate < DateTime.Now);
                Assert.IsTrue(copy.ModifyDate > TestStartTime);
                Assert.IsTrue(copy.ModifyDate < DateTime.Now);
                Assert.IsTrue(copy.StartDate <= copy.ModifyDate);
            }

            switch (copy.ReplicationStateDescription)
            {
                case "PENDING":
                    Assert.IsTrue((int)copy.PercentComplete == 0);
                    break;

                case "SEEDING":
                    Assert.IsTrue(copy.PercentComplete > 0 && copy.PercentComplete < 100);
                    break;

                case "CATCH_UP":
                    Assert.AreEqual(100, copy.PercentComplete);
                    Assert.IsTrue(copy.IsContinuous);
                    break;

                case "":
                    // After forced terminate, on the other side.
                    Assert.IsFalse(copy.IsInterlinkConnected);
                    break;

                default:
                    Assert.Fail("Unexpected ReplicationStateDescription: " +
                                copy.ReplicationStateDescription);
                    break;
            }
        }
    }
}
