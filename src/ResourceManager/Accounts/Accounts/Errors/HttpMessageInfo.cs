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

using Hyak.Common;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Profile.Errors
{
    public class HttpMessageInfo
    {
        public HttpMessageInfo(CloudHttpErrorInfo message)
        {
            if (message != null)
            {
                foreach (var header in message.Headers)
                {
                    Headers[header.Key] = header.Value;
                }

                Body = message.Content;
            }
        }

        public HttpMessageInfo(HttpMessageWrapper message)
        {
            if (message != null)
            {
                foreach (var header in message.Headers)
                {
                    Headers[header.Key] = header.Value;
                }

                Body = message.Content;
            }
        }
        public IDictionary<string, IEnumerable<string>> Headers { get; } = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);

        public string Body { get; set; }
    }
}
