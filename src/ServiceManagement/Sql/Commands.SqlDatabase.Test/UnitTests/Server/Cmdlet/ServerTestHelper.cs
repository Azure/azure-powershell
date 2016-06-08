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
using Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.Server.Cmdlet
{
    public static class ServerTestHelper
    {
        /// <summary>
        /// Defines the service base Uri to use for common functions
        /// </summary>
        internal static Uri CommonServiceBaseUri
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Set the default mock session settings to modify request and responses.
        /// </summary>
        /// <param name="testSession"></param>
        public static void SetDefaultTestSessionSettings(HttpSession testSession)
        {
            testSession.ServiceBaseUri = ServerTestHelper.CommonServiceBaseUri;
            testSession.RequestModifier =
                new Action<HttpMessage.Request>(
                    (request) =>
                    {
                        // To run the tests targetting production uncomment the below line and substitute in a valid subscription ID.
                        // request.RequestUri = new Uri(request.RequestUri.OriginalString.Replace("00000000-0000-0000-0001-000000000001", "<subscription_id>"));
                    });
            testSession.ResponseModifier =
                new Action<HttpMessage>(
                    (message) =>
                    {
                    });
        }
    }
}
