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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer
{
    public class MockServerHelper
    {
        /// <summary>
        /// The private singleton collection that stores all mock sessions
        /// </summary>
        private static readonly HttpSessionCollection defaultSessionCollection =
            HttpSessionCollection.Load("MockSessions.xml");

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
        /// The singleton collection that stores all mock sessions
        /// </summary>
        public static HttpSessionCollection DefaultSessionCollection
        {
            get
            {
                return defaultSessionCollection;
            }
        }

        /// <summary>
        /// Save the default mock session collection to the test output directory.
        /// </summary>
        public static void SaveDefaultSessionCollection()
        {
            lock (defaultSessionCollection)
            {
                defaultSessionCollection.Save("MockSessions.xml");
            }
        }

        /// <summary>
        /// Execute a given function within a mock session context.
        /// </summary>
        /// <typeparam name="T">The return type of the function.</typeparam>
        /// <param name="testSession">The mock session information.</param>
        /// <param name="mockServerUri">The endpoint where the Mock Server should listen on.</param>
        /// <param name="func">The function to execute.</param>
        /// <returns>The function output.</returns>
        public static T ExecuteWithMock<T>(
            HttpSession testSession,
            Uri mockServerUri,
            Func<T> func)
        {
            using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
            {
                using (new MockHttpServer(exceptionManager, mockServerUri, testSession))
                {
                    return func();
                }
            }
        }
    }
}
