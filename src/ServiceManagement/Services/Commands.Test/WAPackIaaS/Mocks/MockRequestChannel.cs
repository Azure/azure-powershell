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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient;

namespace Microsoft.WindowsAzure.Commands.Test.WAPackIaaS.Mocks
{
    internal class MockRequestChannel : IRequestChannel
    {
        //Queue of simulated server responses. One tuple (if present) is dequeued and returned
        //to the client for each call to IssueRequestAndGetResponse 
        private Queue<Tuple<List<object>, WebHeaderCollection>> requestResponseQueue;

        //Stores a list of client requests sent through the channel. Unit tests can check the list.
        public List<Tuple<HttpWebRequest, string>> ClientRequests;

        private Dictionary<string, object> expectedValues;
        private Dictionary<string, string> expectedHeaders;

        public MockRequestChannel()
        {
            requestResponseQueue = new Queue<Tuple<List<object>, WebHeaderCollection>>();
            ClientRequests = new List<Tuple<HttpWebRequest, string>>();
            expectedValues = new Dictionary<string, object>();
            expectedHeaders = new Dictionary<string, string>();
        }

        public static MockRequestChannel Create()
        {
            return new MockRequestChannel();
        }

        /// <summary>
        /// Enqueues a response list and a list of headers to return to clients
        /// </summary>
        /// <param name="response">
        /// A list of objects. For example, could be list of VirtualMachines to simulate
        /// a response to a client's GET.
        /// </param>
        /// <param name="responseHeaders">List of headers to be returned to the client.</param>
        /// <returns></returns>
        public MockRequestChannel AddReturnObject(List<object> response, WebHeaderCollection responseHeaders)
        {
            var toEnqueue = new Tuple<List<object>, WebHeaderCollection>(response, responseHeaders);
            requestResponseQueue.Enqueue(toEnqueue);
            return this;
        }

        public MockRequestChannel AddReturnObject(object response, WebHeaderCollection responseHeaders)
        {
            return this.AddReturnObject(new List<object> { response }, responseHeaders);
        }

        public MockRequestChannel AddReturnObject(object response)
        {
            return this.AddReturnObject(new List<object> {response}, null);
        }

        public MockRequestChannel AddReturnObject(List<object> response)
            {
            return this.AddReturnObject(response, null);
            }

        public List<T> IssueRequestAndGetResponse<T>(HttpWebRequest requestInfo, out WebHeaderCollection responseHeaders, string payload = null)
        {
            //Record the request that the client made so that we can examine it later in test code
            ClientRequests.Add(new Tuple<HttpWebRequest,string>(requestInfo, payload));

            var responseList = new List<T>();
            responseHeaders = null;
            
            if (requestResponseQueue.Any())
            {
                var tuple = requestResponseQueue.Dequeue();

                //Response can be null if we need to return empty list, but still need to set headers
                //E.g., for testing DELETE
                if (tuple.Item1 != null)
                    responseList = tuple.Item1.Select(obj => (T)obj).ToList();
                responseHeaders = tuple.Item2;
            }

            return responseList;
        }

        internal IList<T> DeserializeClientPayload<T>(string payload)
        {
            var jsonHelper = new JsonHelpers<T>();
            return jsonHelper.Deserialize(payload);
        }

        public MockRequestChannel AddExpectedValue(string varName, object expectedValue)
        {
            expectedValues.Add(varName, expectedValue);
            return this;
        }

        public MockRequestChannel AddExpectedHeader(string headerName, string headerValue)
        {
            expectedHeaders.Add(headerName, headerValue);
            return this;
        }

        private void VerifyValues(HttpWebRequest request)
        {
            foreach (var value in expectedValues)
            {
                var property = request.GetType().GetProperty(value.Key);

                if (property == null)
                    throw new ArgumentNullException();

                object actualValue = property.GetValue(request, null);
                Assert.Equal(value.Value, actualValue);
            }
        }

        private void VerifyHeaders(WebHeaderCollection actualHeaders)
        {
            foreach (var eHeader in this.expectedHeaders)
            {
                Assert.Equal(actualHeaders[eHeader.Key], eHeader.Value);
            }
        }
    }
}
