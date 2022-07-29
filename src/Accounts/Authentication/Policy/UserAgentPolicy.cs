using Azure.Core;
using Azure.Core.Pipeline;

using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static Azure.Core.HttpHeader;

namespace Microsoft.Azure.Commands.Common.Authentication.Policy
{
    internal class UserAgentPolicy: HttpPipelineSynchronousPolicy
    {
        private IList<ProductInfoHeaderValue> userAgents;

        public UserAgentPolicy() 
        {
            userAgents = new List<ProductInfoHeaderValue>();
        }

        public UserAgentPolicy(ProductInfoHeaderValue[] userAgent)
        {
            userAgents = userAgent;
        }

        public void AddUserAgent(ProductInfoHeaderValue userAgent)
        {
            userAgents.Add(userAgent);
        }

        public void AddUserAgent(ProductInfoHeaderValue[] userAgent)
        {
            userAgents?.ForEach((agent) => {
                userAgents.Add(agent);
            });
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            userAgents?.ForEach((agent) => {
                message.Request.Headers.Add(Names.UserAgent, agent.ToString());
            });
        }
          
    }
}
