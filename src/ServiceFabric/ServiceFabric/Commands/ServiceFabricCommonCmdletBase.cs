// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricCommonCmdletBase : AzureRMCmdlet
    {
        private static int WriteVerboseIntervalInSec = 20;

        private Lazy<ServiceFabricManagementClient> sfrpClient;
        private Lazy<IResourceManagementClient> resourcesClient;

        internal ServiceFabricManagementClient SFRPClient
        {
            get { return sfrpClient.Value; }
            set { sfrpClient = new Lazy<ServiceFabricManagementClient>(() => value); }
        }

        internal IResourceManagementClient ResourcesClient
        {
            get { return resourcesClient.Value; }
            set { resourcesClient = new Lazy<IResourceManagementClient>(() => value); }
        }

        public ServiceFabricCommonCmdletBase()
        {
            InitializeManagementClients();
        }

        private void InitializeManagementClients()
        {
            this.sfrpClient = new Lazy<ServiceFabricManagementClient>(() =>
            {
                var armClient = AzureSession.Instance.ClientFactory.
                CreateArmClient<ServiceFabricManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager);
                return armClient;
            });

            this.resourcesClient = new Lazy<IResourceManagementClient>(() =>
            AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager));
        }

        #region Helper

        protected T PollLongRunningOperation<T>(AzureOperationResponse<T> beginRequestResponse) where T : class
        {
            var progress = new ProgressRecord(0, "Request in progress", "Getting Status...");
            WriteProgress(progress);
            WriteVerboseWithTimestamp(string.Format("Beging request ARM correlationId: '{0}' response: '{1}'",
                                        beginRequestResponse.RequestId,
                                        beginRequestResponse.Response.StatusCode));

            AzureOperationResponse<T> result = null;
            var tokenSource = new CancellationTokenSource();
            Uri asyncOperationStatusEndpoint = null;
            HttpRequestMessage asyncOpStatusRequest = null;
            if (beginRequestResponse.Response.Headers.TryGetValues(Constants.AzureAsyncOperationHeader, out IEnumerable<string> headerValues))
            {
                asyncOperationStatusEndpoint = new Uri(headerValues.First());
                asyncOpStatusRequest = beginRequestResponse.Request;
            }

            var requestTask = Task.Factory.StartNew(() =>
            {
                try
                {
                    result = this.SFRPClient.GetLongRunningOperationResultAsync(beginRequestResponse, null, default).GetAwaiter().GetResult();
                }
                finally
                {
                    tokenSource.Cancel();
                }
            });

            
            while (!tokenSource.IsCancellationRequested)
            {
                tokenSource.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));
                if (asyncOpStatusRequest != null && asyncOperationStatusEndpoint != null)
                {
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            asyncOpStatusRequest = this.CloneAndDisposeRequest(asyncOpStatusRequest, asyncOperationStatusEndpoint, HttpMethod.Get);
                            HttpResponseMessage responseJson = client.SendAsync(asyncOpStatusRequest).GetAwaiter().GetResult();
                            string content = responseJson.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result;
                            Operation op = this.ConvertToOperation(content);

                            if (op != null)
                            {
                                string progressMessage = $"Operation Status: {op.Status}";
                                WriteDebugWithTimestamp(progressMessage);
                                progress.StatusDescription = progressMessage;
                                progress.PercentComplete = Convert.ToInt32(op.PercentComplete);
                                WriteProgress(progress);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // don't throw if poll operation state fails
                        WriteDebugWithTimestamp("Error polling operation status {0}", ex);
                    }
                }
                else
                {
                    if (progress.StatusDescription != "In progress")
                    {
                        progress.StatusDescription = "In progress";
                        WriteProgress(progress);
                    }
                }
            }

            if (requestTask.IsFaulted)
            {
                var errorMessage = string.Format(
                    "Long Running Operation Failed. Begin request with ARM correlationId: '{0}' response: '{1}'",
                    beginRequestResponse.RequestId,
                    beginRequestResponse.Response.StatusCode);

                WriteErrorWithTimestamp(errorMessage);
                throw requestTask.Exception;
            }

            return result?.Body;
        }

        protected void PollLongRunningOperation(Rest.Azure.AzureOperationResponse beginRequestResponse)
        {
            AzureOperationResponse<object> response2 = new Rest.Azure.AzureOperationResponse<object>
            {
                Request = beginRequestResponse.Request,
                Response = beginRequestResponse.Response,
                RequestId = beginRequestResponse.RequestId
            };

            this.PollLongRunningOperation(response2);
            /*
            var progress = new ProgressRecord(0, "Request in progress", "Starting...");
            WriteProgress(progress);
            Rest.Azure.AzureOperationResponse beginRequestResponse = null;
            Rest.Azure.AzureOperationResponse result = null;
            var tokenSource = new CancellationTokenSource();
            Uri asyncOperationStatusEndpoint = null;
            HttpRequestMessage asyncOpStatusRequest = null;
            try
            {
                var requestTask = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        beginRequestResponse = beginRequestAction().GetAwaiter().GetResult();
                        if (beginRequestResponse.Response.Headers.TryGetValues(Constants.AzureAsyncOperationHeader, out IEnumerable<string> headerValues))
                        {
                            asyncOperationStatusEndpoint = new Uri(headerValues.First());
                            asyncOpStatusRequest = beginRequestResponse.Request;
                        }

                        WriteVerboseWithTimestamp(string.Format("Beging request ARM correlationId: '{0}' response: '{1}'",
                                        beginRequestResponse.RequestId,
                                        beginRequestResponse.Response.StatusCode));

                        result = this.SFRPClient.GetLongRunningOperationResultAsync(beginRequestResponse, null, default).GetAwaiter().GetResult();
                    }
                    finally
                    {
                        tokenSource.Cancel();
                    }
                });

                try
                {
                    while (!tokenSource.IsCancellationRequested)
                    {
                        tokenSource.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(WriteVerboseIntervalInSec));

                        if (asyncOpStatusRequest != null && asyncOperationStatusEndpoint != null)
                        {
                            using (HttpClient client = new HttpClient())
                            {
                                asyncOpStatusRequest = this.CloneAndDisposeRequest(asyncOpStatusRequest, asyncOperationStatusEndpoint, HttpMethod.Get);
                                HttpResponseMessage responseJson = client.SendAsync(asyncOpStatusRequest).GetAwaiter().GetResult();
                                string content = responseJson.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result;
                                Operation op = this.ConvertToOperation(content);

                                if (op != null)
                                {
                                    string progressMessage = $"Operation Status: {op.Status}";
                                    WriteDebugWithTimestamp(progressMessage);
                                    progress.StatusDescription = progressMessage;
                                    progress.PercentComplete = Convert.ToInt32(op.PercentComplete);
                                    WriteProgress(progress);
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    // don't throw if poll operation state fails
                    WriteDebugWithTimestamp("Error polling operation status {0}", ex);
                }

                if (requestTask.IsFaulted)
                {
                    string errorMessage = "Begin request operation failed";
                    if (beginRequestResponse != null)
                    {
                        errorMessage = string.Format(
                            "Operation Failed. Begin request with ARM correlationId: '{0}' response: '{1}'",
                            beginRequestResponse.RequestId,
                            beginRequestResponse.Response.StatusCode);

                    }

                    WriteErrorWithTimestamp(errorMessage);
                    throw requestTask.Exception;
                }
            }
            catch (Exception e)
            {
                PrintSdkExceptionDetail(e);
                throw;
            }

            //return result?.Body;
            */
        }

        private Operation ConvertToOperation(string content)
        {
            try
            {
                var operationJObject = JObject.Parse(content);
                var operation = new Operation();

                if (operationJObject.TryGetValue("Name", StringComparison.OrdinalIgnoreCase, out JToken value))
                {
                    operation.Name = (string)value;
                }

                if (operationJObject.TryGetValue("PercentComplete", StringComparison.OrdinalIgnoreCase, out value))
                {
                    operation.PercentComplete = (double)value;
                }

                if (operationJObject.TryGetValue("Status", StringComparison.OrdinalIgnoreCase, out value))
                {
                    operation.Status = (string)value;
                }

                if (operationJObject.TryGetValue("Error", StringComparison.OrdinalIgnoreCase, out value))
                {
                    operation.Error = new OperationError();
                    if (((JObject)value).TryGetValue("Code", StringComparison.OrdinalIgnoreCase, out JToken innerValue))
                    {
                        operation.Error.Code = (string)innerValue;
                    }

                    if (((JObject)value).TryGetValue("Message", StringComparison.OrdinalIgnoreCase, out innerValue))
                    {
                        operation.Error.Message = (string)innerValue;
                    }
                }

                return operation;
            }
            catch(Exception ex)
            {
                WriteDebugWithTimestamp("unable to parse operation content '{0}' exception {1}", content, ex);
                return null;
            }
        }

        private HttpRequestMessage CloneAndDisposeRequest(HttpRequestMessage original, Uri requestUri = null, HttpMethod method = null)
        {
            using (original)
            {
                var clone = new HttpRequestMessage
                {
                    Method = method ?? original.Method,
                    RequestUri = requestUri ?? original.RequestUri,
                    Version = original.Version,
                };

                foreach (KeyValuePair<string, object> prop in original.Properties)
                {
                    clone.Properties.Add(prop);
                }

                foreach (KeyValuePair<string, IEnumerable<string>> header in original.Headers)
                {
                    clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }

                return clone;
            }
        }

        protected void PrintSdkExceptionDetail(Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            while (!(exception is CloudException || exception is ErrorModelException) && exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            if (exception is CloudException)
            {
                var cloudException = (CloudException)exception;
                if (cloudException.Body != null)
                {
                    var cloudErrorMessage = GetCloudErrorMessage(cloudException.Body);
                    var ex = new Exception(cloudErrorMessage);
                    WriteError(
                        new ErrorRecord(ex, string.Empty, ErrorCategory.NotSpecified, null));
                }
            }
            else if (exception is ErrorModelException)
            {
                var errorModelException = (ErrorModelException)exception;
                if (errorModelException.Body != null)
                {
                    var cloudErrorMessage = GetErrorModelErrorMessage(errorModelException.Body);
                    var ex = new Exception(cloudErrorMessage);
                    WriteError(
                        new ErrorRecord(ex, string.Empty, ErrorCategory.NotSpecified, null));
                }
            }
            else
            {
                WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.NotSpecified, null));
            }
        }

        private string GetCloudErrorMessage(CloudError error)
        {
            if (error == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            if (error.Details != null)
            {
                foreach (var detail in error.Details)
                {
                    sb.Append(GetCloudErrorMessage(detail));
                }
            }

            var message = string.Format(
                "Code: {0}, Message: {1}{2}Details: {3}{2}",
                error.Code,
                error.Message,
                Environment.NewLine,
                sb);

            return message;
        }

        private string GetErrorModelErrorMessage(ErrorModel error)
        {
            if (error == null || error.Error == null)
            {
                return string.Empty;
            }

            var message = string.Format(
                "Code: {0}, Message: {1}{2}",
                error.Error.Code,
                error.Error.Message,
                Environment.NewLine);

            return message;
        }

        #endregion
    }
}