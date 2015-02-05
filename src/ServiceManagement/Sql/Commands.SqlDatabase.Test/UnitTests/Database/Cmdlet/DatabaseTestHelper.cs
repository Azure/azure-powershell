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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Database.Cmdlet
{
    public static class DatabaseTestHelper
    {
        /// <summary>
        /// The unique GUID for identifying the Shared SLO.
        /// </summary>
        public static readonly Guid SharedSloGuid = new Guid("910b4fcb-8a29-4c3e-958f-f7ba794388b2");
        
        /// <summary>
        /// The unique GUID for identifying the System SLO.
        /// </summary>
        public static readonly Guid SystemSloGuid = new Guid("26e021db-f1f9-4c98-84c6-92af8ef433d7");

        /// <summary>
        /// The unique GUID for identifying the System2 SLO.
        /// </summary>
        public static readonly Guid System2SloGuid = new Guid("620323bf-2879-4807-b30d-c2e6d7b3b3aa");

        /// <summary>
        /// The unique GUID for identifying the Business SLO.
        /// </summary>
        public static readonly Guid BusinessSloGuid = new Guid("4518ce8e-6026-4113-b4fd-3b5d777c6881");
        
        /// <summary>
        /// The unique GUID for identifying the Basic SLO.
        /// </summary>
        public static readonly Guid BasicSloGuid = new Guid("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c");

        /// <summary>
        /// The unique GUID for identifying the Standard S2 SLO.
        /// </summary>
        public static readonly Guid StandardS2SloGuid = new Guid("455330e1-00cd-488b-b5fa-177c226f28b7");

        /// <summary>
        /// The unique GUID for identifying the Standard S1 SLO.
        /// </summary>
        public static readonly Guid StandardS1SloGuid = new Guid("1b1ebd4d-d903-4baa-97f9-4ea675f5e928");

        /// <summary>
        /// The unique GUID for identifying the Standard S0 SLO.
        /// </summary>
        public static readonly Guid StandardS0SloGuid = new Guid("f1173c43-91bd-4aaa-973c-54e79e15235b");

        /// <summary>
        /// The unique GUID for identifying the Premium P1 SLO.
        /// </summary>
        public static readonly Guid PremiumP1SloGuid = new Guid("7203483a-c4fb-4304-9e9f-17c71c904f5d");

        /// <summary>
        /// The unique GUID for identifying the Premium P2 SLO.
        /// </summary>
        public static readonly Guid PremiumP2SloGuid = new Guid("a7d1b92d-c987-4375-b54d-2b1d0e0f5bb0");

        /// <summary>
        /// The unique GUID for identifying the Premium P3 SLO.
        /// </summary>
        public static readonly Guid PremiumP3SloGuid = new Guid("a7c4c615-cfb1-464b-b252-925be0a19446");


        /// <summary>
        /// Set the default mock session settings to modify request and responses.
        /// </summary>
        /// <param name="testSession"></param>
        public static void SetDefaultTestSessionSettings(HttpSession testSession)
        {
            testSession.ServiceBaseUri = MockServerHelper.CommonServiceBaseUri;
            testSession.SessionProperties["Servername"] = "myserver01";
            testSession.SessionProperties["Username"] = "testuser";
            testSession.SessionProperties["Password"] = "testp@ss1";
            testSession.ResponseModifier =
                new Action<HttpMessage>(
                    (message) =>
                    {
                        DatabaseTestHelper.FixODataResponseUri(
                            message.ResponseInfo,
                            testSession.ServiceBaseUri,
                            MockHttpServer.DefaultServerPrefixUri);
                    });
            testSession.RequestModifier =
                new Action<HttpMessage.Request>(
                    (request) =>
                    {
                        DatabaseTestHelper.FixODataRequestPayload(
                            request,
                            testSession.ServiceBaseUri,
                            MockHttpServer.DefaultServerPrefixUri);
                    });
        }

        /// <summary>
        /// Helper function to validate headers for GetAccessToken request.
        /// </summary>
        public static void ValidateGetAccessTokenRequest(
            HttpMessage.Request expected,
            HttpMessage.Request actual)
        {
            Assert.IsTrue(
                actual.RequestUri.AbsoluteUri.EndsWith("GetAccessToken"),
                "Incorrect Uri specified for GetAccessToken");
            Assert.IsTrue(
                actual.Headers.Contains("sqlauthorization"),
                "sqlauthorization header does not exist in the request");
            Assert.AreEqual(
                expected.Headers["sqlauthorization"],
                actual.Headers["sqlauthorization"],
                "sqlauthorization header does not match");
            Assert.IsNull(
                actual.RequestText,
                "There should be no request text for GetAccessToken");
        }

        /// <summary>
        /// Helper function to validate headers for Service request.
        /// </summary>
        public static void ValidateHeadersForServiceRequest(
            HttpMessage.Request expected,
            HttpMessage.Request actual)
        {
            Assert.IsTrue(
                actual.Headers.Contains(DataServiceConstants.AccessTokenHeader),
                "AccessToken header does not exist in the request");
            Assert.IsTrue(
                actual.Headers.Contains("x-ms-client-session-id"),
                "session-id header does not exist in the request");
            Assert.IsTrue(
                actual.Headers.Contains("x-ms-client-request-id"),
                "request-id header does not exist in the request");
            Assert.IsTrue(
                actual.Cookies.Contains(DataServiceConstants.AccessCookie),
                "AccessCookie does not exist in the request");
        }

        /// <summary>
        /// Helper function to validate headers for OData request.
        /// </summary>
        public static void ValidateHeadersForODataRequest(
            HttpMessage.Request expected,
            HttpMessage.Request actual)
        {
            DatabaseTestHelper.ValidateHeadersForServiceRequest(expected, actual);
            Assert.IsTrue(
                actual.Headers.Contains("DataServiceVersion"),
                "DataServiceVersion header does not exist in the request");
            Assert.AreEqual(
                expected.Headers["DataServiceVersion"],
                actual.Headers["DataServiceVersion"],
                "DataServiceVersion header does not match");
        }

        /// <summary>
        /// Modifies the OData get responses to use the mock server's Uri.
        /// </summary>
        public static void FixODataResponseUri(
            HttpMessage.Response response,
            Uri serviceUri,
            Uri mockServerUri)
        {
            if (serviceUri != null &&
                response.ResponseText.Contains("dataservices") &&
                response.ResponseText.Contains("</entry>"))
            {
                response.ResponseText =
                    response.ResponseText.Replace(serviceUri.ToString(), mockServerUri.ToString());
            }

            if (serviceUri != null &&
                response.Headers.Contains("Location"))
            {
                response.Headers["Location"] = response.Headers["Location"].Replace(
                    serviceUri.ToString(),
                    mockServerUri.ToString());
            }
        }

        /// <summary>
        /// Modifies the OData get request to use the real server's Uri.
        /// </summary>
        public static void FixODataRequestPayload(
            HttpMessage.Request request,
            Uri serviceUri,
            Uri mockServerUri)
        {
            // Fix the $link Uris
            if (serviceUri != null &&
                request.RequestText != null &&
                request.RequestText.Contains("dataservices"))
            {
                request.RequestText =
                    request.RequestText.Replace(mockServerUri.ToString(), serviceUri.ToString());
            }
        }

        /// <summary>
        /// Validate the properties of a database against the expected values supplied as input.
        /// </summary>
        /// <param name="database">The database object to validate</param>
        /// <param name="name">The expected name of the database</param>
        /// <param name="edition">The expected edition of the database</param>
        /// <param name="maxSizeGb">The expected max size of the database in GB</param>
        /// <param name="collation">The expected Collation of the database</param>
        /// <param name="sloName">The expected Service Objective name</param>
        /// <param name="isSystem">Whether or not the database is expected to be a system object.</param>
        internal static void ValidateDatabaseProperties(
            Services.Server.Database database, 
            string name, 
            string edition, 
            int maxSizeGb, 
            long maxSizeBytes, 
            string collation, 
            string sloName, 
            bool isSystem, 
            Guid? assignedServiceObjectiveId)
        {
            Assert.AreEqual(name, database.Name);
            Assert.AreEqual(edition, database.Edition);
            Assert.AreEqual(maxSizeGb, database.MaxSizeGB);
            Assert.AreEqual(maxSizeBytes, database.MaxSizeBytes);
            Assert.AreEqual(collation, database.CollationName);
            Assert.AreEqual(sloName, database.ServiceObjective.Name);
            Assert.AreEqual(isSystem, database.IsSystemObject);
            Assert.AreEqual(assignedServiceObjectiveId, database.AssignedServiceObjectiveId);
        }

    }
}
