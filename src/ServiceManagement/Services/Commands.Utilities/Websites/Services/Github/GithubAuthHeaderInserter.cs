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
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.Github
{
    public class GithubAutHeaderInserter : IClientMessageInspector, IEndpointBehavior
    {
        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        #region IClientMessageInspector Members

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {

        }

        //All our requests need to have the custom authorization headers
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            //Get the HttpRequestMessage property from the message
            var httpreq = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            string username = GetLogin(Username);
            byte[] authbytes = Encoding.ASCII.GetBytes(string.Concat(username, ":", Password));
            string base64 = Convert.ToBase64String(authbytes);
            string authorization = string.Concat("Basic ", base64);

            if (httpreq == null)
            {
                httpreq = new HttpRequestMessageProperty();
                request.Properties.Add(HttpRequestMessageProperty.Name, httpreq);
            }

            httpreq.Headers["authorization"] = authorization;

            return null;
        }

        public static string GetLogin(string username)
        {
            string s = username;
            int stop = s.IndexOf("\\");
            return (stop > -1) ? s.Substring(stop + 1, s.Length - stop - 1) : username;
        }

        #endregion

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
