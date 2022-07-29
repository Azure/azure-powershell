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

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Net.Http.Headers;
using static Azure.Core.HttpHeader;

namespace Microsoft.Azure.Commands.TestFx.Policies
{
    public class UserAgentPolicy : HttpPipelineSynchronousPolicy
    {
        private readonly IList<ProductInfoHeaderValue> _userAgents;

        public UserAgentPolicy()
        {
            _userAgents = new List<ProductInfoHeaderValue>();
        }

        public UserAgentPolicy(ProductInfoHeaderValue[] userAgents)
        {
            _userAgents = userAgents;
        }

        public void AddUserAgent(ProductInfoHeaderValue userAgent)
        {
            _userAgents.Add(userAgent);
        }

        public void AddUserAgent(ProductInfoHeaderValue[] userAgents)
        {
            userAgents.ForEach(agent => _userAgents.Add(agent));
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            _userAgents?.ForEach(agent => message.Request.Headers.Add(Names.UserAgent, agent.ToString()));
        }
    }
}