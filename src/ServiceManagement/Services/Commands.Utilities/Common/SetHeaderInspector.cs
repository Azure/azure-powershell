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

using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public class HeadersInspector : IClientMessageInspector, IEndpointBehavior
    {
        public Dictionary<string, string> RequestHeaders { get; set; }

        public List<string> RemoveHeaders { get; set; }

        public WebHeaderCollection ResponseHeaders { get; set; }

        public HeadersInspector(params string[] requestHeaders)
        {
            Debug.Assert(requestHeaders.Length % 2 == 0);
            RequestHeaders = new Dictionary<string, string>();
            RemoveHeaders = new List<string>();

            for (int i = 0, j = 0; i < requestHeaders.Length / 2; i++, j += 2)
            {
                RequestHeaders[requestHeaders[j]] = requestHeaders[j + 1];
            }
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            HttpResponseMessageProperty responseProperties =
                (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];

            ResponseHeaders = responseProperties.Headers;
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
            {
                var property = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

                foreach (KeyValuePair<string, string> pair in RequestHeaders)
                {
                    property.Headers.Add(pair.Key, pair.Value);
                }

                foreach (string headerName in RemoveHeaders)
                {
                    try { property.Headers.Remove(headerName); }
                    catch { /* The header name does not exist, continue.*/ }
                }
            }
            return request;
        }

        #region IEndpointBehavior Members

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(this);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }

        public void Validate(ServiceEndpoint endpoint) { }

        #endregion
    }
}
