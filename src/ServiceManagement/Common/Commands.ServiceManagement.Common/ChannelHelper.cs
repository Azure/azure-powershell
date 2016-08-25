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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Xml;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class ChannelHelper
    {
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateServiceManagementChannel<T>(X509Certificate2 cert)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>();
            factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
            factory.Credentials.ClientCertificate.Certificate = cert;

            var channel = factory.CreateChannel();
            return channel;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateServiceManagementChannel<T>(Binding binding, X509Certificate2 cert)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>(binding);
            factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
            factory.Credentials.ClientCertificate.Certificate = cert;

            var channel = factory.CreateChannel();
            return channel;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateServiceManagementChannel<T>(ServiceEndpoint endpoint, X509Certificate2 cert)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>(endpoint);
            factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
            factory.Credentials.ClientCertificate.Certificate = cert;

            var channel = factory.CreateChannel();
            return channel;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateServiceManagementChannel<T>(string endpointConfigurationName, X509Certificate2 cert)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>(endpointConfigurationName);
            factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
            factory.Credentials.ClientCertificate.Certificate = cert;

            var channel = factory.CreateChannel();
            return channel;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateServiceManagementChannel<T>(Type channelType, X509Certificate2 cert)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>(channelType);
            factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
            factory.Credentials.ClientCertificate.Certificate = cert;

            var channel = factory.CreateChannel();
            return channel;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateServiceManagementChannel<T>(Uri remoteUri, X509Certificate2 cert)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>(remoteUri);
            factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
            factory.Credentials.ClientCertificate.Certificate = cert;

            var channel = factory.CreateChannel();
            return channel;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateServiceManagementChannel<T>(Uri remoteUri, string username, string password, params IEndpointBehavior[] behaviors)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>(remoteUri);
            factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
            foreach (IEndpointBehavior behavior in behaviors)
            {
                factory.Endpoint.Behaviors.Add(behavior);
            }
            WebHttpBinding wb = factory.Endpoint.Binding as WebHttpBinding;
            wb.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            wb.Security.Mode = WebHttpSecurityMode.Transport;

            if (!string.IsNullOrEmpty(username))
            {
                factory.Credentials.UserName.UserName = username;
            }
            if (!string.IsNullOrEmpty(password))
            {
                factory.Credentials.UserName.Password = password;
            }

            return factory.CreateChannel();
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateServiceManagementChannel<T>(Binding binding, Uri remoteUri, X509Certificate2 cert, params IEndpointBehavior[] behaviors)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>(binding, remoteUri);
            factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
            factory.Credentials.ClientCertificate.Certificate = cert;
            foreach (IEndpointBehavior behavior in behaviors)
            {
                factory.Endpoint.Behaviors.Add(behavior);
            }

            var channel = factory.CreateChannel();
            return channel;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateServiceManagementChannel<T>(Binding binding, Uri remoteUri, params IEndpointBehavior[] behaviors)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>(binding, remoteUri);
            factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
            foreach (IEndpointBehavior behavior in behaviors)
            {
                factory.Endpoint.Behaviors.Add(behavior);
            }

            var channel = factory.CreateChannel();
            return channel;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateServiceManagementChannel<T>(string endpointConfigurationName, Uri remoteUri, X509Certificate2 cert)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>(endpointConfigurationName, remoteUri);
            factory.Endpoint.Behaviors.Add(new ServiceManagementClientOutputMessageInspector());
            factory.Credentials.ClientCertificate.Certificate = cert;

            var channel = factory.CreateChannel();
            return channel;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposing the factory would also dispose the channel we are returning.")]
        public static T CreateChannel<T>(Binding binding, Uri remoteUri, X509Certificate2 cert, params IEndpointBehavior[] behaviors)
            where T : class
        {
            WebChannelFactory<T> factory = new WebChannelFactory<T>(binding, remoteUri);
            factory.Credentials.ClientCertificate.Certificate = cert;
            foreach (IEndpointBehavior behavior in behaviors)
            {
                factory.Endpoint.Behaviors.Add(behavior);
            }

            var channel = factory.CreateChannel();
            return channel;
        }

        public static bool TryGetExceptionDetails(CommunicationException exception, out ServiceManagementError errorDetails)
        {
            HttpStatusCode httpStatusCode;
            string operationId;
            return TryGetExceptionDetails(exception, out errorDetails, out httpStatusCode, out operationId);
        }

        public static bool TryGetExceptionDetails(CommunicationException exception, out ServiceManagementError errorDetails, out HttpStatusCode httpStatusCode, out string operationId)
        {
            errorDetails = null;
            httpStatusCode = 0;
            operationId = null;

            if (exception == null)
            {
                return false;
            }

            if (exception.Message == "Internal Server Error")
            {
                httpStatusCode = HttpStatusCode.InternalServerError;
                return true;
            }

            WebException wex = exception.InnerException as WebException;

            if (wex == null)
            {
                return false;
            }

            HttpWebResponse response = wex.Response as HttpWebResponse;
            if (response == null)
            {
                return false;
            }

            //httpStatusCode = response.StatusCode;
            //if (httpStatusCode == HttpStatusCode.Forbidden)
            //{
            //    return true;
            //}

            if (response.Headers != null)
            {
                operationId = response.Headers[ApiConstants.OperationTrackingIdHeader];
            }

            // Don't wrap responseStream in a using statement to prevent it
            // from being disposed twice (as it's disposed by reader if it is
            // successfully disposed).
            Stream responseStream = null;
            try
            {
                responseStream = response.GetResponseStream();
                if (responseStream.Length == 0)
                {
                    return false;
                }

                try
                {
                    using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(responseStream, new XmlDictionaryReaderQuotas()))
                    {
                        // Release the reference to responseStream since it
                        // will be closed when the reader is diposed
                        responseStream = null;

                        DataContractSerializer ser = new DataContractSerializer(typeof(ServiceManagementError));
                        errorDetails = (ServiceManagementError)ser.ReadObject(reader, true);
                    }
                }
                catch (SerializationException)
                {
                    return false;
                }
            }
            finally
            {
                if (responseStream != null)
                {
                    responseStream.Dispose();
                }
            }

            return true;
        }

        public static string EncodeToBase64String(string original)
        {
            if (string.IsNullOrEmpty(original))
            {
                return original;
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(original));
        }

        public static string DecodeFromBase64String(string original)
        {
            if (string.IsNullOrEmpty(original))
            {
                return original;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(original));
        }
    }

    public class UserAgentMessageProcessingHandler : MessageProcessingHandler
    {
        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.UserAgent.Add(AzurePowerShell.UserAgentValue);
            return request;
        }

        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            return response;
        }
    }

    public class ServiceManagementClientOutputMessageInspector : IClientMessageInspector, IEndpointBehavior
    {
        public const string UserAgentHeaderName = ApiConstants.UserAgentHeaderName;
        public const string UserAgentHeaderContent = ApiConstants.UserAgentHeaderValue;
        public const string VSDebuggerCausalityDataHeaderName = "VSDebuggerCausalityData";

        #region IClientMessageInspector Members

        public void AfterReceiveReply(ref Message reply, object correlationState) { }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
            {
                var property = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];

                // Remove VSDebuggerCausalityData header which is added by WCF.
                if (property.Headers[VSDebuggerCausalityDataHeaderName] != null)
                {
                    property.Headers.Remove(VSDebuggerCausalityDataHeaderName);
                }

                if (property.Headers[ApiConstants.VersionHeaderName] == null)
                {
                    property.Headers.Add(ApiConstants.VersionHeaderName, ApiConstants.VersionHeaderContentLatest);
                }

                if (property.Headers[UserAgentHeaderName] == null)
                {
                    property.Headers.Add(UserAgentHeaderName, UserAgentHeaderContent);
                }
            }

            return null;
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