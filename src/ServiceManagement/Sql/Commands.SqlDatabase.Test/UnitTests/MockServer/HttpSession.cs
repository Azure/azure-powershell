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
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer
{
    /// <summary>
    /// Stores information about a session of Http messages.
    /// </summary>
    [DataContract(Name = "HttpSession")]
    public class HttpSession
    {
        [DataMember(Order = 0)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        public HttpMessageCollection Messages { get; set; }

        /// <summary>
        /// Validates that the request contain the proper messages. The first param is the expected
        /// request, and the second param is the actual request.
        /// </summary>
        public Action<HttpMessage, HttpMessage.Request> RequestValidator { get; set; }

        /// <summary>
        /// An action that allows request to be modified prior to sending it to the server.
        /// </summary>
        public Action<HttpMessage.Request> RequestModifier { get; set; }

        /// <summary>
        /// An action that allows response to be modified prior to sending it to the client.
        /// </summary>
        public Action<HttpMessage> ResponseModifier { get; set; }

        /// <summary>
        /// The real service's base Uri. If specifed the requests will be forwarded to a
        /// real service.
        /// </summary>
        public Uri ServiceBaseUri { get; set; }

        /// <summary>
        /// A dictionary to store extra session properties.
        /// </summary>
        public Dictionary<string, string> SessionProperties { get; set; }
    }
}
