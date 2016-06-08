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
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient
{
    internal class WAPackIaaSRequestChannel : IRequestChannel
    {
        private readonly ILogger logger;

        public WAPackIaaSRequestChannel(ILogger logger = null)
        {
            this.logger = logger;
        }

        public List<T> IssueRequestAndGetResponse<T>(HttpWebRequest request, out WebHeaderCollection responseHeaders, string payload = null)
        {
            var jsonHelper = new JsonHelpers<T>();

            if (!String.IsNullOrWhiteSpace(payload))
            {
                var writer = new StreamWriter(request.GetRequestStream());
                writer.Write(payload);
                writer.Close();
            }

            try
            {
                string responseString;

                using (var response = request.GetResponse())
                {
                    responseHeaders = response.Headers;
                    responseString = response.ResponseToString();

                    if (logger != null)
                        logger.Log(LogLevel.Debug, request.Method + " " + request.RequestUri + " " + ((HttpWebResponse)response).StatusCode);
                }

                return request.Method == HttpMethod.Delete.ToString() ? new List<T>() : jsonHelper.Deserialize(responseString);
            }
            catch (WebException ex)
            {
                HttpStatusCode statusCode = ex.Response != null
                    ? ((HttpWebResponse)ex.Response).StatusCode
                    : HttpStatusCode.Unused;
                throw new WAPackWebException(statusCode, ex.Message, ex);
            }
        }
    }
}
