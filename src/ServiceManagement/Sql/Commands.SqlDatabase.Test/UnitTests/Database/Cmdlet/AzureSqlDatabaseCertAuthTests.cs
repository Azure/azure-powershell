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
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Server.Cmdlet;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    [TestClass]
    public class AzureSqlDatabaseTests : SMTestBase
    {
        [TestCleanup]
        public void CleanupTest()
        {
            // Save the mock session results
            MockServerHelper.SaveDefaultSessionCollection();
        }

        /// <summary>
        /// Test Get/Set/Remove a database using certificate authentication.
        /// </summary>
        [TestMethod]
        public void AzureSqlDatabaseCertTests()
        {
            // This test uses the https endpoint, setup the certificates.
            MockHttpServer.SetupCertificates();

            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
            {
                // Setup the subscription used for the test
                AzureSubscription subscription =
                    UnitTestHelper.SetupUnitTestSubscription(powershell);

                powershell.Runspace.SessionStateProxy.SetVariable(
                    "serverName",
                    SqlDatabaseTestSettings.Instance.ServerName);

                // Create a new server
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTest.AzureSqlDatabaseCertTests");
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

                Collection<PSObject> newDatabaseResult1 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"New-AzureSqlDatabase" +
                            @" -ServerName $serverName" +
                            @" -DatabaseName testdbcert1");
                    });

                Collection<PSObject> newDatabaseResult2 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"New-AzureSqlDatabase" +
                            @" -ServerName $serverName" +
                            @" -DatabaseName testdbcert2" +
                            @" -Edition Business" +
                            @" -MaxSizeGB 10" +
                            @" -Collation Japanese_CI_AS");
                    });

                // Create a database of size 100MB Default Edition (Standard)
                Collection<PSObject> newDatabaseResult3 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"New-AzureSqlDatabase" +
                            @" -ServerName $serverName" +
                            @" -DatabaseName testdbcert4" +
                            @" -MaxSizeBytes 104857600");
                    });

                Collection<PSObject> getDatabaseResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase" +
                            @" $serverName");
                    });

                Collection<PSObject> getSingleDatabaseResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase" +
                            @" $serverName" +
                            @" -DatabaseName testdbcert1");
                    });

                Collection<PSObject> getSingleDatabaseResult2 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase" +
                            @" $serverName" +
                            @" -DatabaseName testdbcert4");
                    });

                Collection<PSObject> setDatabaseNameResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable("db", newDatabaseResult1.FirstOrDefault());
                        return powershell.InvokeBatchScript(
                            @"$db | Set-AzureSqlDatabase" +
                            @" -NewDatabaseName testdbcert3" +
                            @" -PassThru");
                    });

                Collection<PSObject> setDatabaseSizeResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable("db", newDatabaseResult1.FirstOrDefault());
                        return powershell.InvokeBatchScript(
                            @"$db | Set-AzureSqlDatabase" +
                            @" -MaxSizeGB 5" +
                            @" -PassThru");
                    });

                Collection<PSObject> setDatabaseSizeResult2 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Set-AzureSqlDatabase" +
                            @" -ServerName $serverName" +
                            @" -DatabaseName testdbcert4" +
                            @" -MaxSizeBytes 1073741824" +
                            @" -passthru");
                    });

                Collection<PSObject> P1 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"$P1 = Get-AzureSqlDatabaseServiceObjective" +
                            @" -Server $serverName" +
                            @" -ServiceObjectiveName ""P1""",
                            @"$P1");
                    });

                Collection<PSObject> P2 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.InvokeBatchScript(
                            @"$SLO = Get-AzureSqlDatabaseServiceObjective" +
                            @" -Server $serverName");

                        return powershell.InvokeBatchScript(
                            @"$P2 = Get-AzureSqlDatabaseServiceObjective" +
                            @" -Server $serverName" +
                            @" -ServiceObjective ($slo | where-object { $_.name -match ""P2"" })",
                            @"$P2");
                    });


                Collection<PSObject> setDatabaseSlo = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Set-AzureSqlDatabase" +
                            @" -ServerName $serverName" +
                            @" -DatabaseName testdbcert4" +
                            @" -Edition Premium" +
                            @" -MaxSizeGb 10" +
                            @" -ServiceObjective $P2" +
                            @" -passthru" +
                            @" -Force");
                    });


                Collection<PSObject> removeDatabaseResult1 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable("db1", newDatabaseResult1.FirstOrDefault());
                        powershell.Runspace.SessionStateProxy.SetVariable("db2", newDatabaseResult2.FirstOrDefault());
                        powershell.Runspace.SessionStateProxy.SetVariable("db3", newDatabaseResult3.FirstOrDefault());
                        powershell.InvokeBatchScript(@"$db1 | Remove-AzureSqlDatabase -Force");
                        powershell.InvokeBatchScript(@"$db2 | Remove-AzureSqlDatabase -Force");
                        powershell.InvokeBatchScript(@"$db3 | Remove-AzureSqlDatabase -Force");
                        return powershell.InvokeBatchScript(@"Get-AzureSqlDatabase $serverName");
                    });

                Collection<PSObject> newPremiumP1DatabaseResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {  
                        return powershell.InvokeBatchScript(
                                @"New-AzureSqlDatabase" +
                                @" -ServerName $serverName" +
                                @" -DatabaseName ""testdbcertPremiumDBP1""" +
                                @" -Edition Premium" +
                                @" -ServiceObjective $P1" +
                                @" -MaxSizeGb 10");
                    });

                Collection<PSObject> newPremiumP2DatabaseResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                                @"New-AzureSqlDatabase" +
                                @" -ServerName $serverName" +
                                @" -DatabaseName ""testdbcertPremiumDBP2""" +
                                @" -Edition Premium" +
                                @" -ServiceObjective $P2" +
                                @" -MaxSizeGb 10");
                    });

                // There is a known issue about the Get-AzureSqlDatabaseOperation that it returns all
                // operations which has the required database name no matter it's been deleted and recreated.
                // So when run it against the mock session, please use the hard coded testsDBName.
                // Run against onebox, please use the one with NewGuid(). 
                // This unit test should be updated once that behavior get changed which was already been 
                // created as a task.

                string getOperationDbName = null;
                if (testSession.ServiceBaseUri == null)
                {
                    getOperationDbName = "testdbcertGetOperationDbName_08abc738-1381-4164-ae5e-03a4fe59b6d2";
                }
                else
                {
                    getOperationDbName = "testdbcertGetOperationDbName_" + Guid.NewGuid().ToString();
                }

                Collection<PSObject> newOperationDbResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            string.Format(
                                CultureInfo.InvariantCulture,
                                @"$getOperationDb = New-AzureSqlDatabase" +
                                @" -ServerName $serverName" +
                                @" -DatabaseName ""{0}""",
                                getOperationDbName),
                                @"$getOperationDb");
                    });
                
                Collection<PSObject> getDatabaseOperationByDbResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {                        
                        return powershell.InvokeBatchScript(
                            string.Format(
                                CultureInfo.InvariantCulture,
                                @"Get-AzureSqlDatabaseOperation" +
                                @" -ServerName $serverName" +
                                @" -Database $getOperationDb"));
                    });

                Collection<PSObject> getDatabaseOperationByNameResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            string.Format(
                                CultureInfo.InvariantCulture,
                                @"$getOperation = Get-AzureSqlDatabaseOperation" +
                                @" -ServerName $serverName" +
                                @" -DatabaseName ""{0}""",
                                getOperationDbName),
                                @"$getOperation");
                    });

                Collection<PSObject> getDatabaseOperationByIdResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            string.Format(
                                CultureInfo.InvariantCulture,
                                @"Get-AzureSqlDatabaseOperation" +
                                @" -ServerName $serverName" +
                                @" -OperationGuid $getOperation[0].Id"));
                    });

                Collection<PSObject> removeDatabaseResult2 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable("premiumP1", newPremiumP1DatabaseResult.FirstOrDefault());
                        powershell.Runspace.SessionStateProxy.SetVariable("premiumP2", newPremiumP2DatabaseResult.FirstOrDefault());
                        powershell.Runspace.SessionStateProxy.SetVariable("operationDb", newOperationDbResult.FirstOrDefault());
                        powershell.InvokeBatchScript(@"$premiumP1 | Remove-AzureSqlDatabase -Force");
                        powershell.InvokeBatchScript(@"$premiumP2 | Remove-AzureSqlDatabase -Force");
                        powershell.InvokeBatchScript(@"$operationDb | Remove-AzureSqlDatabase -Force");
                        return powershell.InvokeBatchScript(@"Get-AzureSqlDatabase $serverName");
                    });

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Unexpected Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Unexpected Warnings during run!");

                // Validate New-AzureSqlDatabase
                Services.Server.Database[] databases = new Services.Server.Database[] { newDatabaseResult1.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                // Note: Because the object is piped, this is the final state of the 
                // database object, after all the Set- cmdlet has run.
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbcert3", "Standard", 5, 5368709120L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                databases = new Services.Server.Database[] { newDatabaseResult2.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                //TODO: change below to business
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbcert2", "Business", 10, 10737418240L, "Japanese_CI_AS", "Business", false, DatabaseTestHelper.BusinessSloGuid);

                databases = new Services.Server.Database[] { newDatabaseResult3.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbcert4", "Standard", 0, 104857600L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                // Validate Get-AzureSqlDatabase                
                databases = getDatabaseResult.Select(r => r.BaseObject as Services.Server.Database).ToArray();
                Assert.AreEqual(4, databases.Length, "Expecting 4 databases");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                Assert.IsNotNull(databases[1], "Expecting a Database object.");
                Assert.IsNotNull(databases[2], "Expecting a Database object.");
                Assert.IsNotNull(databases[3], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[1], "master", "System", 5, 5368709120L, "SQL_Latin1_General_CP1_CI_AS", "System2", true, DatabaseTestHelper.System2SloGuid);
                DatabaseTestHelper.ValidateDatabaseProperties(databases[3], "testdbcert1", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);
                DatabaseTestHelper.ValidateDatabaseProperties(databases[2], "testdbcert2", "Business", 10, 10737418240L, "Japanese_CI_AS", "Business", false, DatabaseTestHelper.BusinessSloGuid);
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbcert4", "Standard", 0, 104857600L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                databases = new Services.Server.Database[] { getSingleDatabaseResult.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbcert1", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                databases = new Services.Server.Database[] { getSingleDatabaseResult2.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbcert4", "Standard", 0, 104857600L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                // Validate Set-AzureSqlDatabase
                databases = new Services.Server.Database[] { setDatabaseNameResult.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbcert3", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                databases = new Services.Server.Database[] { setDatabaseSizeResult.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbcert3", "Standard", 5, 5368709120L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                databases = new Services.Server.Database[] { setDatabaseSizeResult2.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbcert4", "Standard", 1, 1073741824L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                databases = new Services.Server.Database[] { setDatabaseSlo.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbcert4", "Standard", 1, 1073741824L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.PremiumP2SloGuid);

                // Validate New-AzureSqlDatabase for Premium Edition Database
                VerifyCreatePremiumDb(newPremiumP1DatabaseResult, "testdbcertPremiumDBP1", (P1.Single().BaseObject as ServiceObjective).Id.ToString());
                VerifyCreatePremiumDb(newPremiumP2DatabaseResult, "testdbcertPremiumDBP2", (P2.Single().BaseObject as ServiceObjective).Id.ToString());

                // Validate Get-AzureSqlDatabaseServiceObjective
                var SLOP1 = P1.Single().BaseObject as ServiceObjective;
                Assert.AreEqual("P1", SLOP1.Name);
                Assert.IsNotNull(SLOP1.DimensionSettings, "Expecting some Dimension Setting objects.");
                Assert.AreEqual(1, SLOP1.DimensionSettings.Count(), "Expecting 1 Dimension Setting.");
                Assert.AreEqual("Premium P1 resource allocation.", SLOP1.DimensionSettings[0].Description, "Expecting Dimension Setting description as Resource capacity is reserved.");
                
                var SLOP2 = P2.Single().BaseObject as ServiceObjective;
                Assert.AreEqual("P2", SLOP2.Name);
                Assert.IsNotNull(SLOP2.DimensionSettings, "Expecting some Dimension Setting objects.");
                Assert.AreEqual(1, SLOP2.DimensionSettings.Count(), "Expecting 1 Dimension Setting.");
                Assert.AreEqual("Premium P2 resource allocation.", SLOP2.DimensionSettings[0].Description, "Expecting Dimension Setting description as Resource capacity is reserved.");
                
                // Validate Get-AzureSqlDatabaseOperation
                VerifyGetAzureSqlDatabaseOperation(getOperationDbName, getDatabaseOperationByDbResult);
                VerifyGetAzureSqlDatabaseOperation(getOperationDbName, getDatabaseOperationByNameResult);
                VerifyGetAzureSqlDatabaseOperation(getOperationDbName, getDatabaseOperationByIdResult);

                // Validate Remove-AzureSqlDatabase
                databases = new Services.Server.Database[] { removeDatabaseResult1.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting no databases");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "master", "System", 5, 5368709120L, "SQL_Latin1_General_CP1_CI_AS", "System2", true, DatabaseTestHelper.System2SloGuid);

                databases = new Services.Server.Database[] { removeDatabaseResult2.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting no databases");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "master", "System", 5, 5368709120L, "SQL_Latin1_General_CP1_CI_AS", "System2", true, DatabaseTestHelper.System2SloGuid);
            }
        }

        /// <summary>
        /// Test Get/Set/Remove a database using certificate authentication.
        /// </summary>
        [TestMethod]
        public void AzureSqlDatabaseEditionsTests()
        {
            // This test uses the https endpoint, setup the certificates.
            MockHttpServer.SetupCertificates();

            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
            {
                // Setup the subscription used for the test
                AzureSubscription subscription =
                    UnitTestHelper.SetupUnitTestSubscription(powershell);

                powershell.Runspace.SessionStateProxy.SetVariable(
                    "serverName",
                    SqlDatabaseTestSettings.Instance.ServerV2);

                // Create a new server
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTest.AzureSqlDatabaseEditionsTests");
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

                Collection<PSObject> newDatabaseResult1 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"($db = New-AzureSqlDatabase -ServerName $serverName -DatabaseName testdbeditions1)");
                    });

                Collection<PSObject> newDatabaseResult2 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"New-AzureSqlDatabase" +
                            @" -ServerName $serverName" +
                            @" -DatabaseName testdbeditions2" +
                            @" -Edition Standard");
                    });

                Collection<PSObject> newDatabaseResult3 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"($db3 = New-AzureSqlDatabase" +
                            @" -ServerName $serverName" +
                            @" -DatabaseName testdbeditions3" +
                            @" -Edition Basic)");
                    });

                Collection<PSObject> newDatabaseResult4 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"New-AzureSqlDatabase" +
                            @" -ServerName $serverName" +
                            @" -DatabaseName testdbeditions4" +
                            @" -Edition Premium");
                    });

                Collection<PSObject> serviceObjectives = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"($so = Get-AzureSqlDatabaseServiceObjective -Server $serverName)");
                    });

                Collection<PSObject> newDatabaseResult5 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"New-AzureSqlDatabase" +
                            @" -ServerName $serverName" +
                            @" -DatabaseName testdbeditions5" +
                            @" -Edition Standard" +
                            @" -ServiceObjective ($so | where-object { $_.name -match ""S2"" })");
                    });

                Collection<PSObject> getSingleDatabaseResult1 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase $serverName -DatabaseName testdbeditions1");
                    });

                Collection<PSObject> getSingleDatabaseResult2 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"$db | Get-AzureSqlDatabase");
                    });

                Collection<PSObject> setDatabaseObjective1 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Set-AzureSqlDatabase -ServerName $serverName -DatabaseName testdbeditions2 -ServiceObjective ($so | where-object { $_.name -match ""S2"" }) -Force");
                    });

                Collection<PSObject> setDatabaseObjective2 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Set-AzureSqlDatabase -ServerName $serverName -DatabaseName $db3.Name -Edition Standard -MaxSizeGB 1 -ServiceObjective ($so | where-object { $_.name -match ""S1"" }) -Force");
                    });

                Collection<PSObject> getDatabaseResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabase" +
                            @" $serverName");
                    });

                Collection<PSObject> removeDatabaseResult = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        powershell.Runspace.SessionStateProxy.SetVariable("db1", newDatabaseResult1.FirstOrDefault());
                        powershell.Runspace.SessionStateProxy.SetVariable("db2", newDatabaseResult2.FirstOrDefault());
                        powershell.Runspace.SessionStateProxy.SetVariable("db3", newDatabaseResult3.FirstOrDefault());
                        powershell.Runspace.SessionStateProxy.SetVariable("db4", newDatabaseResult4.FirstOrDefault());
                        powershell.Runspace.SessionStateProxy.SetVariable("db5", newDatabaseResult5.FirstOrDefault());
                        powershell.InvokeBatchScript(@"$db1 | Remove-AzureSqlDatabase -Force");
                        powershell.InvokeBatchScript(@"$db2 | Remove-AzureSqlDatabase -Force");
                        powershell.InvokeBatchScript(@"$db3 | Remove-AzureSqlDatabase -Force");
                        powershell.InvokeBatchScript(@"$db4 | Remove-AzureSqlDatabase -Force");
                        powershell.InvokeBatchScript(@"$db5 | Remove-AzureSqlDatabase -Force");
                        return powershell.InvokeBatchScript( @"Get-AzureSqlDatabase $serverName");
                    });

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Unexpected Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Unexpected Warnings during run!");

                // Validate New-AzureSqlDatabase
                Services.Server.Database[] databases = new Services.Server.Database[] { newDatabaseResult1.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbeditions1", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                databases = new Services.Server.Database[] { newDatabaseResult2.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbeditions2", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);

                databases = new Services.Server.Database[] { newDatabaseResult3.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbeditions3", "Basic", 2, 2147483648L, "SQL_Latin1_General_CP1_CI_AS", "Basic", false, DatabaseTestHelper.BasicSloGuid);

                databases = new Services.Server.Database[] { newDatabaseResult4.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbeditions4", "Premium", 500, 536870912000L, "SQL_Latin1_General_CP1_CI_AS", "P1", false, DatabaseTestHelper.PremiumP1SloGuid);

                databases = new Services.Server.Database[] { newDatabaseResult5.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting one database");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbeditions5", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", "S2", false, DatabaseTestHelper.StandardS2SloGuid);


                // Validate Get-AzureSqlDatabase                
                databases = getDatabaseResult.Select(r => r.BaseObject as Services.Server.Database).ToArray();
                Assert.AreEqual(6, databases.Length, "Expecting 3 databases");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                Assert.IsNotNull(databases[1], "Expecting a Database object.");
                Assert.IsNotNull(databases[2], "Expecting a Database object.");
                Assert.IsNotNull(databases[3], "Expecting a Database object.");
                Assert.IsNotNull(databases[4], "Expecting a Database object.");
                Assert.IsNotNull(databases[5], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[1], "master", "System", 5, 5368709120L, "SQL_Latin1_General_CP1_CI_AS", "System2", true, DatabaseTestHelper.System2SloGuid);
                DatabaseTestHelper.ValidateDatabaseProperties(databases[3], "testdbeditions1", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS0SloGuid);
                DatabaseTestHelper.ValidateDatabaseProperties(databases[4], "testdbeditions2", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", "S0", false, DatabaseTestHelper.StandardS2SloGuid);
                DatabaseTestHelper.ValidateDatabaseProperties(databases[5], "testdbeditions3", "Basic", 2, 2147483648L, "SQL_Latin1_General_CP1_CI_AS", "Basic", false, DatabaseTestHelper.StandardS1SloGuid);
                DatabaseTestHelper.ValidateDatabaseProperties(databases[2], "testdbeditions4", "Premium", 500, 536870912000L, "SQL_Latin1_General_CP1_CI_AS", "P1", false, DatabaseTestHelper.PremiumP1SloGuid);
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "testdbeditions5", "Standard", 250, 268435456000L, "SQL_Latin1_General_CP1_CI_AS", "S2", false, DatabaseTestHelper.StandardS2SloGuid);

                // Validate Get-AzureSqlDatabaseServiceObjective
                var sos = serviceObjectives.Select(x => x.BaseObject as ServiceObjective).ToArray();
                Assert.AreEqual(10, sos.Count());
                ValidateServiceObjectiveProperties(sos[0], "System", "", 1, "Used for master database only.");
                ValidateServiceObjectiveProperties(sos[1], "System2", "", 1, "");
                ValidateServiceObjectiveProperties(sos[2], "Basic", "", 1, "Basic resource allocation.");
                ValidateServiceObjectiveProperties(sos[3], "S0", "", 1, "Standard S0 resource allocation.");
                ValidateServiceObjectiveProperties(sos[4], "S1", "", 1, "Standard S1 resource allocation.");
                ValidateServiceObjectiveProperties(sos[5], "S2", "", 1, "Standard S2 resource allocation.");
                ValidateServiceObjectiveProperties(sos[6], "S3", "", 1, "Standard S3 resource allocation.");
                ValidateServiceObjectiveProperties(sos[7], "P1", "", 1, "Premium P1 resource allocation.");
                ValidateServiceObjectiveProperties(sos[8], "P2", "", 1, "Premium P2 resource allocation.");
                ValidateServiceObjectiveProperties(sos[9], "P3", "", 1, "Premium P3 resource allocation.");

                // Validate Remove-AzureSqlDatabase
                databases = new Services.Server.Database[] { removeDatabaseResult.Single().BaseObject as Services.Server.Database };
                Assert.AreEqual(1, databases.Length, "Expecting no databases");
                Assert.IsNotNull(databases[0], "Expecting a Database object.");
                DatabaseTestHelper.ValidateDatabaseProperties(databases[0], "master", "System", 5, 5368709120L, "SQL_Latin1_General_CP1_CI_AS", "System2", true, DatabaseTestHelper.System2SloGuid);
            }
        }

        /// <summary>
        /// Verify that the Get-AzureSqlDatabseServerQuota cmdlets work using certificate authentication
        /// </summary>
        [TestMethod]
        public void AzureSqlDatabaseServerQuotaCertAuthTest()
        {
            // This test uses the https endpoint, setup the certificates.
            MockHttpServer.SetupCertificates();

            using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
            {
                // Setup the subscription used for the test
                AzureSubscription subscription =
                    UnitTestHelper.SetupUnitTestSubscription(powershell);

                powershell.Runspace.SessionStateProxy.SetVariable(
                    "serverName",
                    SqlDatabaseTestSettings.Instance.ServerV2);

                // Create a new server
                HttpSession testSession = MockServerHelper.DefaultSessionCollection.GetSession(
                    "UnitTest.AzureSqlDatabaseServerQuotaCertAuthTest");
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

                Collection<PSObject> getQuota1 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabaseServerQuota -ServerName $serverName");
                    });

                Collection<PSObject> getQuota2 = MockServerHelper.ExecuteWithMock(
                    testSession,
                    MockHttpServer.DefaultHttpsServerPrefixUri,
                    () =>
                    {
                        return powershell.InvokeBatchScript(
                            @"Get-AzureSqlDatabaseServerQuota -ServerName $serverName -QuotaName premium_databases");
                    });

                Assert.AreEqual(0, powershell.Streams.Error.Count, "Unexpected Errors during run!");
                Assert.AreEqual(0, powershell.Streams.Warning.Count, "Unexpected Warnings during run!");

                // Validate Get-AzureSqlDatabaseServerQuota
                var quotas = getQuota1.Select(x => ((IEnumerable)x.BaseObject).Cast<Model.SqlDatabaseServerQuotaContext>().Single() ).ToArray();
                Assert.AreEqual(1, quotas.Length, "Expecting one server quota");
                Assert.IsNotNull(quotas[0], "Expecting a server quota.");
                Assert.AreEqual("premium_databases", quotas[0].Name);
                Assert.AreEqual(SqlDatabaseTestSettings.Instance.ServerV2, quotas[0].ServerName);
                Assert.AreEqual("Microsoft.SqlAzure.ServerQuota", quotas[0].Type);
                Assert.AreEqual("100", quotas[0].Value);
                Assert.AreEqual("Normal", quotas[0].State);

                quotas = getQuota2.Select(x => ((IEnumerable)x.BaseObject).Cast<Model.SqlDatabaseServerQuotaContext>().Single()).ToArray();
                Assert.AreEqual(1, quotas.Length, "Expecting server quota");
                Assert.IsNotNull(quotas[0], "Expecting a server quota.");
                Assert.AreEqual("premium_databases", quotas[0].Name);
                Assert.AreEqual(SqlDatabaseTestSettings.Instance.ServerV2, quotas[0].ServerName);
                Assert.AreEqual("Microsoft.SqlAzure.ServerQuota", quotas[0].Type);
                Assert.AreEqual("100", quotas[0].Value);
                Assert.AreEqual("Normal", quotas[0].State);
            }
        }

        /// <summary>
        /// Validate that the service objective properties match the expected values
        /// </summary>
        /// <param name="so">The service objective object</param>
        /// <param name="name">The expected name for the service objective</param>
        /// <param name="description">The expected description for the service objective</param>
        /// <param name="dimSettingsCount">The expected number of dimension settings</param>
        /// <param name="desc">A list of the expected descriptions for each dimension setting</param>
        private static void ValidateServiceObjectiveProperties(ServiceObjective so, string name, string description, int dimSettingsCount, params string[] desc)
        {

            Assert.AreEqual(name, so.Name);
            Assert.AreEqual(description, so.Description);
            Assert.IsNotNull(so.DimensionSettings, "Expecting some Dimension Setting objects.");
            Assert.AreEqual(dimSettingsCount, so.DimensionSettings.Count(), "Expecting 1 Dimension Setting.");
            for (int i = 0; i < dimSettingsCount; i++)
            {
                Assert.AreEqual(desc[i], so.DimensionSettings[i].Description);
            }
        }

        private static void VerifyGetAzureSqlDatabaseOperation(string getOperationDbName, Collection<PSObject> getDatabaseOperationByIdResult)
        {
            var operations = getDatabaseOperationByIdResult.Select(r => r.BaseObject as DatabaseOperation).ToArray();
            Assert.AreEqual(operations.Count(), 1, "Expecting 1 operation");
            Assert.AreEqual(operations[0].Name, "CREATE DATABASE", "Expecting CREATE DATABASE operation");
            Assert.AreEqual(operations[0].State, "COMPLETED", "Expecting operation COMPLETED");
            Assert.AreEqual(operations[0].DatabaseName, getOperationDbName, string.Format("Expecting Database name: {0}", getOperationDbName));
            Assert.AreEqual(operations[0].PercentComplete, 100, "Expecting operation completed 100%");
        }

        private static Services.Server.Database[] VerifyCreatePremiumDb(Collection<PSObject> newPremiumP1DatabaseResult, string databaseName, string serviceObjectiveId)
        {
            Services.Server.Database[] databases = new Services.Server.Database[] { newPremiumP1DatabaseResult.Single().BaseObject as Services.Server.Database };
            Assert.AreEqual(1, databases.Length, "Expecting one database");
            Assert.IsNotNull(databases[0], "Expecting a Database object.");
            Assert.AreEqual(databases[0].Name, databaseName, string.Format("Expecting Database Name:{0}, actual is:{1}", databaseName, databases[0].Name));
            
             Assert.AreEqual("Premium", databases[0].Edition);
             Assert.AreEqual(databases[0].AssignedServiceObjectiveId, Guid.Parse(serviceObjectiveId), string.Format("Expecting Database Edition:{0}, actual is:{1}", serviceObjectiveId, databases[0].AssignedServiceObjectiveId));
             
            Assert.AreEqual("SQL_Latin1_General_CP1_CI_AS", databases[0].CollationName);
            return databases;
        }
    }
}

