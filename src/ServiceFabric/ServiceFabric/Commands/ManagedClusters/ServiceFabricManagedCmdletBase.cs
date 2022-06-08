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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.ServiceFabricManagedClusters;
using Microsoft.Rest.Azure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    public class ServiceFabricManagedCmdletBase : ServiceFabricCommonCmdletBase
    {
        private Lazy<ServiceFabricManagedClustersManagementClient> sfrpMcClient;

        internal ServiceFabricManagedClustersManagementClient SfrpMcClient
        {
            get { return sfrpMcClient.Value; }
            set { sfrpMcClient = new Lazy<ServiceFabricManagedClustersManagementClient>(() => value); }
        }

        public ServiceFabricManagedCmdletBase()
        {
            InitializeManagementClients();
        }

        private void InitializeManagementClients()
        {
            this.sfrpMcClient = new Lazy<ServiceFabricManagedClustersManagementClient>(() =>
            {
                var armClient = AzureSession.Instance.ClientFactory.
                CreateArmClient<ServiceFabricManagedClustersManagementClient>(
                DefaultContext,
                AzureEnvironment.Endpoint.ResourceManager);
                return armClient;
            });
        }

        #region Helper

        protected void PollLongRunningOperation(Rest.Azure.AzureOperationResponse beginRequestResponse)
        {
            AzureOperationResponse<object> response2 = new Rest.Azure.AzureOperationResponse<object>
            {
                Request = beginRequestResponse.Request,
                Response = beginRequestResponse.Response,
                RequestId = beginRequestResponse.RequestId
            };

            this.PollLongRunningOperation(response2);
        }

        protected T PollLongRunningOperation<T>(AzureOperationResponse<T> beginRequestResponse) where T : class
        {
            var progress = new ProgressRecord(0, "Request in progress", "Getting Status...");
            WriteProgress(progress);
            WriteVerboseWithTimestamp(string.Format("Begin request ARM correlationId: '{0}' response: '{1}'",
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
                    result = this.SfrpMcClient.GetLongRunningOperationResultAsync(beginRequestResponse, null, CancellationToken.None).GetAwaiter().GetResult();
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
                            string content = responseJson.Content.ReadAsStringAsync().Result;
                            Operation op = this.ConvertToOperation(content);

                            if (op != null)
                            {
                                string progressMessage = $"Operation Status: {op.Status}. Progress: {op.PercentComplete} %";
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
                    "Long Running Operation Failed. Begin request with ARM correlationId: '{0}' response: '{1}' operationId '{0}'",
                    beginRequestResponse.RequestId,
                    beginRequestResponse.Response.StatusCode,
                    this.GetOperationIdFromAsyncHeader(beginRequestResponse.Response.Headers));

                WriteErrorWithTimestamp(errorMessage);
                throw requestTask.Exception;
            }

            return result?.Body;
        }

        private string GetOperationIdFromAsyncHeader(HttpResponseHeaders headers)
        {
            if (headers.Location != null)
            {
                return headers.Location.Segments.LastOrDefault();
            }

            if (headers.TryGetValues(Constants.AzureAsyncOperationHeader, out IEnumerable<string> headerValues))
            {
                var asyncOperationStatusEndpoint = new Uri(headerValues.First());
                return asyncOperationStatusEndpoint.Segments.LastOrDefault();
            }
            
            return "Unknown";
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

        #endregion
    }
}
