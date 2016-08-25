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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.MockServer
{
    /// <summary>
    /// A mock server implementation for capturing and replaying Http Web Requests.
    /// </summary>
    public class MockHttpServer : IDisposable
    {
        /// <summary>
        /// The HTTP server prefix for tests
        /// </summary>
        public static readonly Uri DefaultServerPrefixUri =
            new Uri("http://localhost:12345/");

        /// <summary>
        /// The HTTPS server prefix for tests which is been used in cert auth based unit tests
        /// </summary>
        public static readonly Uri DefaultHttpsServerPrefixUri =
            new Uri("https://localhost:65432/");

        /// <summary>
        /// The app id for the https binding
        /// </summary>
        private static readonly Guid HttpsAppId = new Guid("C1714DD7-CAB5-4031-8622-3D3D3D2795DB");

        private readonly Uri baseUri;
        private readonly AsyncExceptionManager exceptionManager;
        private readonly HttpListener listener;
        private readonly Uri stopListenerUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockHttpServer" /> class that record or
        /// playback responses for requests in a session.
        /// </summary>
        /// <param name="exceptionManager">
        /// The exception manager that captures all async exceptions.
        /// </param>
        /// <param name="baseUri">The server prefix to use.</param>
        /// <param name="session">The object that stores request/response information.</param>
        public MockHttpServer(
            AsyncExceptionManager exceptionManager,
            Uri baseUri,
            HttpSession session)
            : this(exceptionManager, baseUri)
        {
            this.stopListenerUri = new Uri(baseUri, Guid.NewGuid().ToString());
            this.listener = this.CreateListener(
                context => HandleMockRequest(
                    context,
                    this.baseUri,
                    session),
                int.MaxValue);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockHttpServer" /> class with a specified
        /// server prefix.
        /// </summary>
        /// <param name="exceptionManager">
        /// The exception manager that captures all async exceptions.
        /// </param>
        /// <param name="baseUri">The server prefix to use.</param>
        private MockHttpServer(AsyncExceptionManager exceptionManager, Uri baseUri)
        {
            this.exceptionManager = exceptionManager;
            this.baseUri = baseUri;
        }

        /// <summary>
        /// Create a <see cref="WebException"/> with the specified content.
        /// </summary>
        /// <param name="status">The status code to use in the exception.</param>
        /// <param name="content">The exception content.</param>
        /// <param name="contextHandler">An action that adds extra info to the response.</param>
        /// <returns>An <see cref="WebException"/> with the specified content.</returns>
        public static WebException CreateWebException(
            HttpStatusCode status,
            string content,
            Action<HttpListenerContext> contextHandler)
        {
            return CreateWebException(
                status,
                new MemoryStream(Encoding.UTF8.GetBytes(content)),
                contextHandler);
        }

        /// <summary>
        /// Create a <see cref="WebException"/> with the specified content.
        /// </summary>
        /// <param name="status">The status code to use in the exception.</param>
        /// <param name="content">A <see cref="MemoryStream"/> of the exception content.</param>
        /// <param name="contextHandler">An action that adds extra info to the response.</param>
        /// <returns>An <see cref="WebException"/> with the specified content.</returns>
        public static WebException CreateWebException(
            HttpStatusCode status,
            MemoryStream content,
            Action<HttpListenerContext> contextHandler)
        {
            HttpListener server = null;
            try
            {
                // Create a mock server that always returns the response code and exception stream
                // specified in the parameter.
                using (AsyncExceptionManager exceptionManager = new AsyncExceptionManager())
                {
                    MockHttpServer mockServer = new MockHttpServer(
                        exceptionManager,
                        MockHttpServer.DefaultServerPrefixUri);
                    server = mockServer.CreateListener(
                        (context) =>
                        {
                            contextHandler(context);
                            context.Response.StatusCode = (int)status;
                            content.Position = 0;
                            content.CopyTo(context.Response.OutputStream);
                            context.Response.Close();
                        },
                        1);
                }

                WebClient client = new WebClient();
                try
                {
                    client.OpenRead(new Uri(DefaultServerPrefixUri, "exception.htm"));
                }
                catch (WebException ex)
                {
                    return ex;
                }
            }
            finally
            {
                server.Stop();
            }

            return null;
        }

        /// <summary>
        /// Setup certificates required for the unit tests
        /// </summary>
        public static void SetupCertificates()
        {
            PSTestTracingInterceptor.AddToContext();
            var newGuid = Guid.NewGuid();
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = profile;
            AzureSession.DataStore = new MemoryDataStore();
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory();
            ProfileClient client = new ProfileClient(profile);
            client.AddOrSetAccount( new AzureAccount
            {
                Id = "test",
                Type = AzureAccount.AccountType.User,
                Properties = new Dictionary<AzureAccount.Property, string>
                        {
                            {AzureAccount.Property.Subscriptions, newGuid.ToString()}
                        }
            });
            client.AddOrSetAccount( new AzureAccount
            {
                Id = UnitTestHelper.GetUnitTestClientCertificate().Thumbprint,
                Type = AzureAccount.AccountType.Certificate,
                Properties = new Dictionary<AzureAccount.Property, string>
                        {
                            {AzureAccount.Property.Subscriptions, newGuid.ToString()}
                        }
            });
            client.AddOrSetAccount( new AzureAccount
            {
                Id = UnitTestHelper.GetUnitTestSSLCertificate().Thumbprint,
                Type = AzureAccount.AccountType.Certificate,
                Properties = new Dictionary<AzureAccount.Property, string>
                        {
                            {AzureAccount.Property.Subscriptions, newGuid.ToString()}
                        }
            });
            client.AddOrSetSubscription(new AzureSubscription
            {
                Id = newGuid,
                Name = "test",
                Environment = EnvironmentName.AzureCloud,
                Account = "test"
            });

            client.SetSubscriptionAsDefault(newGuid, "test");
            client.Profile.Save();


            // Check if the cert has been installed 
            Process proc = ExecuteProcess(
                "netsh",
                string.Format(
                    CultureInfo.InvariantCulture,
                    "http show sslcert ipport=0.0.0.0:{0}",
                    DefaultHttpsServerPrefixUri.Port));

            if (proc.ExitCode != 0)
            {
                // Install the SSL and client certificates to the LocalMachine store
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                store.Add(UnitTestHelper.GetUnitTestSSLCertificate());
                store.Add(UnitTestHelper.GetUnitTestClientCertificate());
                store.Close();
                store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                store.Add(UnitTestHelper.GetUnitTestSSLCertificate());
                store.Add(UnitTestHelper.GetUnitTestClientCertificate());
                store.Close();

                // Remove any existing certs on the default port 
                proc = ExecuteProcess(
                    "netsh",
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "http delete sslcert ipport=0.0.0.0:{0}",
                        DefaultHttpsServerPrefixUri.Port));

                // Install the ssl cert on the default port
                proc = ExecuteProcess(
                    "netsh",
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "http add sslcert ipport=0.0.0.0:{0} certhash={1} appid={2:B}",
                        DefaultHttpsServerPrefixUri.Port,
                        UnitTestHelper.GetUnitTestSSLCertificate().Thumbprint,
                        MockHttpServer.HttpsAppId));

                if (proc.ExitCode != 0)
                {
                    throw new InvalidOperationException(string.Format(
                        CultureInfo.InvariantCulture,
                        "Unable to add ssl certificate: {0}",
                        proc.StandardOutput.ReadToEnd()));
                }
            }
        }

        /// <summary>
        /// Stop and closes the listener.
        /// </summary>
        public void Dispose()
        {
            WebClient client = new WebClient();
            using (Stream stopStream = client.OpenRead(this.stopListenerUri))
            {
            }

            this.listener.Close();
        }

        /// <summary>
        /// Returns the <paramref name="originalUri"/> with its prefix changed from 
        /// <paramref name="originalUriPrefix"/> to <paramref name="newPrefix"/>, or if the 
        /// prefix is not in the <paramref name="originalUri"/>, return the Uri as is.
        /// </summary>
        /// <param name="originalUri">The original Uri.</param>
        /// <param name="originalUriPrefix">The prefix in the original Uri to change.</param>
        /// <param name="newPrefix">The new Uri prefix.</param>
        /// <returns>The original Uri with the new prefix.</returns>
        private static Uri ChangeUriBase(Uri originalUri, Uri originalUriPrefix, Uri newPrefix)
        {
            Uri relativeUri = originalUriPrefix.MakeRelativeUri(originalUri);

            if (relativeUri.IsAbsoluteUri)
            {
                return originalUri;
            }
            else
            {
                return new Uri(newPrefix, relativeUri);
            }
        }

        /// <summary>
        /// Helper method to execute and wait for process to complete.
        /// </summary>
        /// <param name="filename">An application with which to start the process.</param>
        /// <param name="arguments">Arguments passed to the application.</param>
        /// <returns>The <see cref="Process"/> info.</returns>
        private static Process ExecuteProcess(string filename, string arguments)
        {
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo(filename, arguments)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            proc.Start();
            proc.WaitForExit();

            return proc;
        }

        #region Helper methods for response record/playback

        /// <summary>
        /// Retrieves an <see cref="HttpMessage"/> object from a real service.
        /// </summary>
        /// <param name="request">The request to mimic on the real service.</param>
        /// <param name="baseUri">The request's base Uri.</param>
        /// <param name="serviceBaseUri">The real service's base Uri.</param>
        /// <param name="session">The object that stores request/response information.</param>
        /// <returns>An <see cref="HttpMessage"/> object containing the request/response.</returns>
        private static HttpMessage GetResponseInfoFromService(
            HttpListenerRequest request,
            Uri baseUri,
            Uri serviceBaseUri,
            HttpSession session)
        {
            // Construct the request to make
            HttpMessage message = new HttpMessage();
            message.RequestInfo = ConstructRequestInfo(request);

            // Clone the request and modify it for the real service
            HttpMessage.Request requestToSend = message.RequestInfo.Clone();
            requestToSend.RequestUri = ChangeUriBase(request.Url, baseUri, serviceBaseUri);
            if (session.RequestModifier != null)
            {
                session.RequestModifier(requestToSend);
            }

            HttpWebResponse response = MakeServiceRequest(requestToSend);
            message.ResponseInfo = ConstructResponseInfo(serviceBaseUri, response);
            return message;
        }

        /// <summary>
        /// Create an <see cref="HttpMessage.Request"/> object out of the given
        /// <paramref name="originalRequest"/>.
        /// </summary>
        /// <param name="originalRequest">The original request to mimic.</param>
        /// <returns>An <see cref="HttpMessage.Request"/> object containing the request.</returns>
        private static HttpMessage.Request ConstructRequestInfo(
            HttpListenerRequest originalRequest)
        {
            HttpMessage.Request requestInfo = new HttpMessage.Request();

            // Copy the request Uri and Method
            requestInfo.RequestUri = originalRequest.Url;
            requestInfo.Method = originalRequest.HttpMethod;

            // Copy all relevant headers to the request
            requestInfo.Headers = new HttpMessage.HeaderCollection();
            foreach (string headerKey in originalRequest.Headers.AllKeys)
            {
                if (headerKey.Equals("User-Agent", StringComparison.OrdinalIgnoreCase))
                {
                    requestInfo.UserAgent = originalRequest.Headers[headerKey];
                }
                else if (headerKey.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                {
                    requestInfo.ContentType = originalRequest.Headers[headerKey];
                }
                else if (headerKey.Equals("Accept", StringComparison.OrdinalIgnoreCase))
                {
                    requestInfo.Accept = originalRequest.Headers[headerKey];
                }
                else if (!headerKey.Equals("Connection", StringComparison.OrdinalIgnoreCase) &&
                         !headerKey.Equals("Host", StringComparison.OrdinalIgnoreCase) &&
                         !headerKey.Equals("Content-Length", StringComparison.OrdinalIgnoreCase) &&
                         !headerKey.Equals("Expect", StringComparison.OrdinalIgnoreCase))
                {
                    requestInfo.Headers.Add(new HttpMessage.Header
                    {
                        Name = headerKey,
                        Value = originalRequest.Headers[headerKey]
                    });
                }
            }

            // Copy response cookies
            requestInfo.Cookies = new HttpMessage.CookieCollection();
            foreach (Cookie cookie in originalRequest.Cookies)
            {
                requestInfo.Cookies.Add(new HttpMessage.Cookie
                {
                    Name = cookie.Name,
                    Value = cookie.Value,
                });
            }

            // Copy response stream
            if (originalRequest.Headers.AllKeys.Contains("Content-Length"))
            {
                using (StreamReader reader = new StreamReader(originalRequest.InputStream))
                {
                    requestInfo.RequestText = reader.ReadToEnd();
                }
            }

            // Retrieve the certificate on the request if any.
            requestInfo.Certificate = originalRequest.GetClientCertificate();

            return requestInfo;
        }

        /// <summary>
        /// Create an <see cref="HttpMessage.Response"/> object out of the response from a
        /// service.
        /// </summary>
        /// <param name="serviceBaseUri">The real service's base Uri.</param>
        /// <param name="response">The response from the service.</param>
        /// <returns>An <see cref="HttpMessage.Response"/> object containing the response.</returns>
        private static HttpMessage.Response ConstructResponseInfo(
            Uri serviceBaseUri,
            HttpWebResponse response)
        {
            HttpMessage.Response responseInfo = new HttpMessage.Response();

            // Copy the response status code
            responseInfo.StatusCode = response.StatusCode;

            // Copy all relevant headers to the response
            responseInfo.Headers = new HttpMessage.HeaderCollection();
            foreach (string headerKey in response.Headers.AllKeys)
            {
                if (!headerKey.Equals("Transfer-Encoding", StringComparison.OrdinalIgnoreCase) &&
                    !headerKey.Equals("Content-Length", StringComparison.OrdinalIgnoreCase))
                {
                    responseInfo.Headers.Add(new HttpMessage.Header()
                    {
                        Name = headerKey,
                        Value = response.Headers[headerKey]
                    });
                }
            }

            // Copy response cookies
            responseInfo.Cookies = new HttpMessage.CookieCollection();
            foreach (Cookie cookie in response.Cookies)
            {
                Uri cookieHostUri = new Uri(serviceBaseUri.Scheme + Uri.SchemeDelimiter + serviceBaseUri.Host);
                Uri cookieUri = new Uri(cookieHostUri, cookie.Path);
                Uri cookieRelativeUri = serviceBaseUri.MakeRelativeUri(cookieUri);
                responseInfo.Cookies.Add(new HttpMessage.Cookie
                {
                    Name = cookie.Name,
                    Value = cookie.Value,
                    RelativeUri = cookieRelativeUri
                });
            }

            // Copy response stream
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                responseInfo.ResponseText = reader.ReadToEnd();
            }

            return responseInfo;
        }

        /// <summary>
        /// Make an request to the real service and retrieve the response.
        /// </summary>
        /// <param name="originalRequest">The original request to mimic.</param>
        /// <param name="requestUri">The Uri to make the request to.</param>
        /// <returns>The response from the service.</returns>
        private static HttpWebResponse MakeServiceRequest(
            HttpMessage.Request originalRequest)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(
                originalRequest.RequestUri);

            request.Method = originalRequest.Method;

            // Copy all relevant headers to the request
            if (originalRequest.UserAgent != null)
            {
                request.UserAgent = originalRequest.UserAgent;
            }

            if (originalRequest.ContentType != null)
            {
                request.ContentType = originalRequest.ContentType;
            }

            if (originalRequest.Accept != null)
            {
                request.Accept = originalRequest.Accept;
            }

            foreach (HttpMessage.Header header in originalRequest.Headers)
            {
                request.Headers.Add(header.Name, header.Value);
            }

            if (originalRequest.Certificate != null)
            {
                request.ClientCertificates.Add(originalRequest.Certificate);
            }

            // Copy all request cookies
            request.CookieContainer = new CookieContainer();
            foreach (HttpMessage.Cookie cookie in originalRequest.Cookies)
            {
                Cookie requestCookie = new Cookie(cookie.Name, cookie.Value);
                requestCookie.Domain = request.RequestUri.Host;
                requestCookie.Path = request.RequestUri.LocalPath;
                request.CookieContainer.Add(requestCookie);
            }

            // Copy request streams
            if (originalRequest.RequestText != null)
            {
                using (StreamWriter requestStream = new StreamWriter(request.GetRequestStream()))
                {
                    requestStream.Write(originalRequest.RequestText);
                }
            }

            // Send the real request and obtain the response
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }

            return response;
        }

        /// <summary>
        /// Constructs the response from the specified <see cref="HttpMessage.Response"/>.
        /// </summary>
        /// <param name="responseInfo">The object that contains all info about the response.</param>
        /// <param name="baseUri">The base Uri for the response.</param>
        /// <param name="response">The response object to construct.</param>
        private static void ConstructListenerResponse(
            HttpMessage.Response responseInfo,
            Uri baseUri,
            HttpListenerResponse response)
        {
            // Set the status code
            response.StatusCode = (int)responseInfo.StatusCode;

            // Copy relevant response headers
            foreach (HttpMessage.Header header in responseInfo.Headers)
            {
                response.Headers[header.Name] = header.Value;
            }

            // Copy response cookies
            foreach (HttpMessage.Cookie responseCookie in responseInfo.Cookies)
            {
                Cookie cookie = new Cookie(responseCookie.Name, responseCookie.Value);
                Uri cookieUri = responseCookie.RelativeUri;
                if (!cookieUri.IsAbsoluteUri)
                {
                    cookieUri = new Uri(baseUri, cookieUri);
                }

                cookie.Domain = cookieUri.Host;
                cookie.Path = cookieUri.LocalPath;
                response.Cookies.Add(cookie);
            }

            // Copy response stream
            byte[] responseBytes = Encoding.UTF8.GetBytes(responseInfo.ResponseText);
            response.ContentLength64 = responseBytes.Length;
            using (BinaryWriter writer = new BinaryWriter(response.OutputStream))
            {
                writer.Write(responseBytes);
            }
        }

        #endregion

        #region Request Handlers

        /// <summary>
        /// The async delegate that handles an incoming request, passing it through to a real
        /// service and record the response if <paramref name="serviceBaseUri"/> was specified,
        /// or plays back responses from a pre-recorded <paramref name="session"/> if it was not.
        /// </summary>
        /// <param name="context">The context for the incoming request.</param>
        /// <param name="baseUri">The incoming request's base Uri.</param>
        /// <param name="session">The object that stores request/response information.</param>
        private static void HandleMockRequest(
            HttpListenerContext context,
            Uri baseUri,
            HttpSession session)
        {
            if (session.ServiceBaseUri != null)
            {
                // Issue the request to a real service and record the response
                HttpMessage message = GetResponseInfoFromService(
                    context.Request,
                    baseUri,
                    session.ServiceBaseUri,
                    session);
                session.Messages.RecordMessage(message);
            }

            // Construct the mock response from responses in the session.
            HttpMessage recordedMessage = session.Messages.GetMessage(context.Request.Url);
            if (session.RequestValidator != null)
            {
                HttpMessage.Request actualRequestInfo = ConstructRequestInfo(context.Request);
                session.RequestValidator(recordedMessage, actualRequestInfo);
            }

            if (session.ResponseModifier != null)
            {
                session.ResponseModifier(recordedMessage);
            }

            ConstructListenerResponse(recordedMessage.ResponseInfo, baseUri, context.Response);
            context.Response.Close();
        }

        /// <summary>
        /// The async delegate that handles an incoming request.
        /// </summary>
        /// <param name="ar">The <see cref="IAsyncResult"/> for this request.</param>
        /// <param name="contextHandler">An action that constructs the response.</param>
        /// <param name="requestsToHandle">The number of requests to handle before stopping.</param>
        private void HandleRequest(
            IAsyncResult ar,
            Action<HttpListenerContext> contextHandler,
            int requestsToHandle)
        {
            HttpListener listener = (HttpListener)ar.AsyncState;

            // Get the current context, request and response object and construct the response.
            HttpListenerContext context = null;
            context = listener.EndGetContext(ar);
            if (context.Request.Url != this.stopListenerUri)
            {
                // Handle the context, by creating the response.
                this.exceptionManager.CatchExceptions(
                   () => contextHandler(context),
                   () =>
                   {
                       context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                       context.Response.Close();
                   });

                if (requestsToHandle > 0)
                {
                    // Setup the next context
                    listener.BeginGetContext(
                        (arNext) => this.exceptionManager.CatchExceptions(
                            () => this.HandleRequest(
                                arNext,
                                contextHandler,
                                requestsToHandle - 1)),
                        listener);
                }
            }
            else
            {
                // We want to shutdown the server, return ok and exit.
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.Close();
            }
        }

        #endregion

        /// <summary>
        /// Create a <see cref="HttpListener"/> to handles requests.
        /// </summary>
        /// <param name="contextHandler">An action that constructs the response.</param>
        /// <param name="requestsToHandle">The number of requests to handle before stopping.</param>
        /// <returns>The listener object.</returns>
        private HttpListener CreateListener(
            Action<HttpListenerContext> contextHandler,
            int requestsToHandle)
        {
            // Create a mock http listener.
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(this.baseUri.AbsoluteUri);
            listener.Start();
            listener.BeginGetContext(
                (ar) => this.exceptionManager.CatchExceptions(
                    () => this.HandleRequest(ar, contextHandler, requestsToHandle - 1)),
                listener);
            return listener;
        }
    }
}
