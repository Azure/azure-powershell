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
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites
{
    public class RemoteLogStreamManager : KuduRemoteClientBase
    {
        public Action<string> Logger { get; set; }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public RemoteLogStreamManager()
        {

        }

        public RemoteLogStreamManager(
            string serviceUrl,
            string path,
            string filter,
            ICredentials credentials,
            Action<string> logger = null)
            : base(GetServiceUrl(serviceUrl, path, filter), credentials)
        {
            Logger = logger;
        }

        private static string GetServiceUrl(string serviceUrl, string path, string filter)
        {
            return string.Format(
                "{0}/logstream/{1}{2}",
                serviceUrl,
                path,
                string.IsNullOrEmpty(filter) ? string.Empty : "?filter=" + filter);
        }

        public virtual Task<Stream> GetStream()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(ServiceUrl);
            request.UserAgent = ApiConstants.UserAgentHeaderValue;
            TaskCompletionSource<Stream> tcs = new TaskCompletionSource<Stream>();
            RequestState state = new RequestState { Manager = this, TaskCompletionSource = tcs, Request = request };

            if (Credentials != null)
            {
                NetworkCredential networkCred = Credentials.GetCredential(
                    Client.BaseAddress,
                    ApiConstants.BasicAuthorization);
                string credParameter = Convert.ToBase64String(Encoding.ASCII.GetBytes(networkCred.UserName + ":" + networkCred.Password));
                request.Headers[ApiConstants.AuthorizationHeaderName] = string.Format(
                    "{0} {1}",
                    ApiConstants.BasicAuthorization, credParameter);
            }

            LogRequest(request);
            IAsyncResult result = request.BeginGetResponse(RemoteLogStreamManager.OnGetResponse, state);
            
            if (result.CompletedSynchronously)
            {
                state.Response = (HttpWebResponse)request.EndGetResponse(result);
                OnGetResponse(state);
            }

            return tcs.Task;
        }

        private static void OnGetResponse(IAsyncResult result)
        {
            RequestState state = (RequestState)result.AsyncState;
            try
            {
                state.Response = (HttpWebResponse)state.Request.EndGetResponse(result);
                state.Manager.OnGetResponse(state);
            }
            catch (Exception ex)
            {
                state.TaskCompletionSource.TrySetException(ex);
            }
        }

        private void OnGetResponse(RequestState state)
        {
            state.TaskCompletionSource.TrySetResult(new DelegatingStream(state.Response.GetResponseStream(), state));
        }

        private void LogRequest(HttpWebRequest request)
        {
            if (Logger != null)
            {
                Logger(GeneralUtilities.GetHttpRequestLog(
                request.Method,
                request.RequestUri.ToString(),
                request.Headers,
                string.Empty));
            }
        }

        class RequestState
        {
            public RemoteLogStreamManager Manager { get; set; }
            public TaskCompletionSource<Stream> TaskCompletionSource { get; set; }
            public HttpWebRequest Request { get; set; }
            public HttpWebResponse Response { get; set; }
        }

        class DelegatingStream : Stream
        {
            Stream inner;
            RequestState state;

            public DelegatingStream(Stream inner, RequestState state)
            {
                this.inner = inner;
                this.state = state;
            }

            public override void Close()
            {
                // To avoid hanging!
                this.state.Request.Abort();

                this.inner.Close();
            }

            public override bool CanRead
            {
                get { return this.inner.CanRead; }
            }

            public override bool CanSeek
            {
                get { return this.inner.CanSeek; }
            }

            public override bool CanWrite
            {
                get { return this.inner.CanWrite; }
            }

            public override void Flush()
            {
                this.inner.Flush();
            }

            public override long Length
            {
                get { return this.inner.Length; }
            }

            public override long Position
            {
                get { return this.inner.Position; }
                set { this.inner.Position = value; }
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return this.inner.Read(buffer, offset, count);
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return this.inner.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                this.inner.SetLength(value);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                this.inner.Write(buffer, offset, count);
            }
        }
    }
}
