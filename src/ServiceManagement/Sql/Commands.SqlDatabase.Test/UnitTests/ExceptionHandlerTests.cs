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
using System.Globalization;
using System.Management.Automation;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Server.Cmdlet
{
    [TestClass]
    public class ExceptionHandlerTests : SMTestBase
    {
        [TestMethod]
        public void ServiceResourceErrorTest()
        {
            string serverRequestId = Guid.NewGuid().ToString();

            string errorMessage =
@"<Error xmlns=""Microsoft.SqlServer.Management.Framework.Web.Services"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><Message>Resource with the name 'FirewallRule1' does not exist. To continue, specify a valid resource name.</Message><InnerError i:nil=""true""/></Error>";
            WebException exception = MockHttpServer.CreateWebException(
                HttpStatusCode.NotFound,
                errorMessage,
                (context) =>
                {
                    context.Response.Headers.Add(Constants.RequestIdHeaderName, serverRequestId);
                });

            string requestId;
            ErrorRecord errorRecord = SqlDatabaseExceptionHandler.RetrieveExceptionDetails(
                exception,
                out requestId);

            Assert.AreEqual(serverRequestId, requestId);
            Assert.AreEqual("Resource with the name 'FirewallRule1' does not exist. To continue, specify a valid resource name.", errorRecord.Exception.Message);
        }

        [TestMethod]
        public void SqlDatabaseManagementErrorTest()
        {
            string serverRequestId = Guid.NewGuid().ToString();

            string errorMessage =
@"<Error xmlns=""http://schemas.microsoft.com/sqlazure/2010/12/"">
  <Code>40647</Code>
  <Message>Subscription '00000000-1111-2222-3333-444444444444' does not have the server 'server0001'.</Message>
  <Severity>16</Severity>
  <State>1</State>
</Error>";
            WebException exception = MockHttpServer.CreateWebException(
                HttpStatusCode.BadRequest,
                errorMessage,
                (context) =>
                {
                    context.Response.Headers.Add(Constants.RequestIdHeaderName, serverRequestId);
                });

            string requestId;
            ErrorRecord errorRecord = SqlDatabaseExceptionHandler.RetrieveExceptionDetails(
                exception,
                out requestId);

            string expectedErrorDetails = string.Format(
                CultureInfo.InvariantCulture,
                Microsoft.WindowsAzure.Commands.SqlDatabase.Properties.Resources.DatabaseManagementErrorFormat,
                40647,
                "Subscription '00000000-1111-2222-3333-444444444444' does not have the server 'server0001'.");
            Assert.AreEqual(serverRequestId, requestId);
            Assert.AreEqual(expectedErrorDetails, errorRecord.Exception.Message);
        }
    }
}
