using Azure.Core;
using Azure.Core.Pipeline;

using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Policy
{
    internal class AzPsHttpPipelineSynchronousPolicy: HttpPipelineSynchronousPolicy
    {
        ProductInfoHeaderValue[] _userAgents;

        public AzPsHttpPipelineSynchronousPolicy(ProductInfoHeaderValue[] userAgent)
        {
            _userAgents = userAgent;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            _userAgents?.ForEach((agent)=> {
                message.Request.Headers.Add("Custom-Header", agent.ToString());
            });
        }
    }
}
