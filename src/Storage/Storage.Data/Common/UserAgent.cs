using Azure.Core;
using Azure.Core.Pipeline;

namespace Microsoft.WindowsAzure.Commands.Storage
{
    public class UserAgentPolicy : HttpPipelineSynchronousPolicy
    {
        private string _userAgent;

        public UserAgentPolicy(string userAgent)
        {
            _userAgent = userAgent;
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            message.Request.Headers.Add("User-Agent", _userAgent);
        }
    }
}
