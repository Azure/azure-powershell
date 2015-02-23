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

using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Batch.Protocol.Entities;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Reflection;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test.HttpRecorder;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    /// <summary>
    /// Helper methods for the Batch cmdlet scenario tests
    /// </summary>
    public static class ScenarioTestHelpers
    {
        /// <summary>
        /// Creates an account and resource group for use with the Scenario tests
        /// </summary>
        public static BatchAccountContext CreateTestAccountAndResourceGroup(BatchController controller, string resourceGroupName, string accountName, string location)
        {
            controller.ResourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup() { Location = location });
            BatchAccountCreateResponse createResponse = controller.BatchManagementClient.Accounts.Create(resourceGroupName, accountName, new BatchAccountCreateParameters() { Location = location });
            BatchAccountContext context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(createResponse.Resource);
            BatchAccountListKeyResponse response = controller.BatchManagementClient.Accounts.ListKeys(resourceGroupName, accountName);
            context.PrimaryAccountKey = response.PrimaryKey;
            context.SecondaryAccountKey = response.SecondaryKey;
            return context;
        }

        /// <summary>
        /// Cleans up an account and resource group used in a Scenario test.
        /// </summary>
        public static void CleanupTestAccount(BatchController controller, string resourceGroupName, string accountName)
        {
            controller.BatchManagementClient.Accounts.Delete(resourceGroupName, accountName);
            controller.ResourceManagementClient.ResourceGroups.Delete(resourceGroupName);
        }

        /// <summary>
        /// Creates a test Pool for use in Scenario tests.
        /// TODO: Replace with new Pool client method when it exists.
        /// </summary>
        public static void CreateTestPool(BatchAccountContext context, string poolName)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                using (IPoolManager poolManager = context.BatchOMClient.OpenPoolManager())
                {
                    ICloudPool pool = poolManager.CreatePool(poolName, "4", "small", 3);
                    pool.Commit();
                }
            }
        }

        /// <summary>
        /// Deletes a Pool used in a Scenario test.
        /// TODO: Replace with remove Pool client method when it exists.
        /// </summary>
        public static void DeletePool(BatchAccountContext context, string poolName)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                using (IPoolManager poolManager = context.BatchOMClient.OpenPoolManager())
                {
                    poolManager.DeletePool(poolName);
                }
            }
        }

        /// <summary>
        /// Creates a test WorkItem for use in Scenario tests.
        /// TODO: Replace with new WorkItem client method when it exists.
        /// </summary>
        public static void CreateTestWorkItem(BatchAccountContext context, string workItemName, TimeSpan? recurrenceInterval)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                using (IWorkItemManager wiManager = context.BatchOMClient.OpenWorkItemManager())
                {
                    ICloudWorkItem workItem = wiManager.CreateWorkItem(workItemName);
                    workItem.JobExecutionEnvironment = new Azure.Batch.JobExecutionEnvironment();
                    workItem.JobExecutionEnvironment.PoolName = "testPool";
                    if (recurrenceInterval != null)
                    {
                        workItem.Schedule = new Azure.Batch.WorkItemSchedule();
                        workItem.Schedule.RecurrenceInterval = recurrenceInterval;
                    }
                    workItem.Commit();
                }
            }
        }

        /// <summary>
        /// Creates a test WorkItem for use in Scenario tests.
        /// </summary>
        public static void CreateTestWorkItem(BatchAccountContext context, string workItemName)
        {
            CreateTestWorkItem(context, workItemName, null);
        }

        /// <summary>
        /// Waits for a Recent Job on a WorkItem and returns its name. If a previous job is specified, this method waits until a new Recent Job is created.
        /// </summary>
        public static string WaitForRecentJob(BatchController controller, BatchAccountContext context, string workItemName, string previousJob = null)
        {
            DateTime timeout = DateTime.Now.AddMinutes(2);

            YieldInjectionInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);
            PSCloudWorkItem workItem = client.ListWorkItems(context, workItemName, null, Constants.DefaultMaxCount, behaviors).First();

            while (workItem.ExecutionInformation.RecentJob == null || string.Equals(workItem.ExecutionInformation.RecentJob.Name, previousJob, StringComparison.OrdinalIgnoreCase))
            {
                if (DateTime.Now > timeout)
                {
                    throw new TimeoutException("Timed out waiting for recent job");
                }
                Sleep(5000);
                workItem = client.ListWorkItems(context, workItemName, null, Constants.DefaultMaxCount, behaviors).First();
            }
            return workItem.ExecutionInformation.RecentJob.Name;
        }

        /// <summary>
        /// Deletes a WorkItem used in a Scenario test.
        /// TODO: Replace with remove WorkItem client method when it exists.
        /// </summary>
        public static void DeleteWorkItem(BatchAccountContext context, string workItemName)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                using (IWorkItemManager wiManager = context.BatchOMClient.OpenWorkItemManager())
                {
                    wiManager.DeleteWorkItem(workItemName);
                }
            }
        }

        /// <summary>
        /// Terminates a Job
        /// TODO: Replace with terminate Job client method when it exists.
        /// </summary>
        public static void TerminateJob(BatchAccountContext context, string workItemName, string jobName)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                using (IWorkItemManager wiManager = context.BatchOMClient.OpenWorkItemManager())
                {
                    wiManager.TerminateJob(workItemName, jobName);
                }
            }
        }

        /// <summary>
        /// Creates an interceptor that can be used to support the HTTP recorder scenario tests.
        /// This behavior grabs the outgoing Protocol request, converts it to an HttpRequestMessage compatible with the 
        /// HTTP recorder, sends the request through the HTTP recorder, and converts the response to an HttpWebResponse
        /// for serialization by the Protocol Layer.
        /// NOTE: This is a temporary behavior that should no longer be needed when the Batch OM switches to Hyak.
        /// </summary>
        public static YieldInjectionInterceptor CreateHttpRecordingInterceptor()
        {
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, batchRequest) =>
            {
                Task<object> task = Task<object>.Factory.StartNew(() =>
                {
                    object batchResponse = null;

                    HttpRequestMessage request = GenerateHttpRequest((BatchRequest)batchRequest);

                    // Setup HTTP recorder and send the request
                    HttpMockServer mockServer = HttpMockServer.CreateInstance();
                    mockServer.InnerHandler = new HttpClientHandler();
                    HttpClient client = new HttpClient(mockServer);
                    Task<HttpResponseMessage> responseTask = client.SendAsync(request);
                    responseTask.Wait();
                    HttpResponseMessage response = responseTask.Result;

                    Task<Stream> getContentTask = response.Content.ReadAsStreamAsync();
                    getContentTask.Wait();
                    Stream body = getContentTask.Result;

                    HttpWebResponse webResponse = ConvertResponseMessageToWebResponse(response);

                    batchResponse = GenerateBatchResponse((BatchRequest)batchRequest, webResponse, body);

                    return batchResponse;
                });
                return task;
            });
            return interceptor;
        }

        /// <summary>
        /// Generates an HttpRequestMessage from the BatchRequest.
        /// </summary>
        private static HttpRequestMessage GenerateHttpRequest(BatchRequest batchRequest)
        {
            HttpRequestMessage requestMessage = null;
            Uri uri = null;
            // Since we aren't directly using the Protocol Layer to send the request, we have to extract the pieces to create the signed web request
            // that we can convert into a format compatible with the HTTP Recorder.
            MethodInfo getResourceMethod = batchRequest.GetType().GetMethod("GetResourceUri", BindingFlags.NonPublic | BindingFlags.Instance);
            if (getResourceMethod != null)
            {
                uri = getResourceMethod.Invoke(batchRequest, null) as Uri;
            }
            MethodInfo createWebRequestMethod = batchRequest.GetType().GetMethod("CreateWebRequest", BindingFlags.NonPublic | BindingFlags.Instance);
            if (createWebRequestMethod != null && uri != null)
            {
                HttpWebRequest webRequest = createWebRequestMethod.Invoke(batchRequest, new object[] { uri, null, null }) as HttpWebRequest;
                if (webRequest != null)
                {
                    batchRequest.AuthenticationHandler.SignRequest(webRequest, null);

                    // Convert the signed HttpWebRequest into an HttpRequestMessage for use with the HTTP Recorder
                    requestMessage = new HttpRequestMessage(new HttpMethod(webRequest.Method), webRequest.RequestUri);
                    foreach (var header in webRequest.Headers)
                    {
                        string key = header.ToString();
                        string value = webRequest.Headers[key];
                        requestMessage.Headers.Add(key, value);
                    }
                }
            }
            return requestMessage;
        }

        /// <summary>
        /// Converts the HttpResponseMessage into an HttpWebResponse that can be used by the Protocol layer
        /// </summary>
        private static HttpWebResponse ConvertResponseMessageToWebResponse(HttpResponseMessage responseMessage)
        {
            HttpWebResponse webResponse = null;

            // The HttpWebResponse class isn't meant to be built on the fly outside of the .NET framework internals, so we use Reflection.
            ConstructorInfo constructor = typeof(HttpWebResponse).GetConstructor(new Type[] { });
            if (constructor != null)
            {
                webResponse = constructor.Invoke(null) as HttpWebResponse;
                if (webResponse != null)
                {
                    BatchTestHelpers.SetField(webResponse, "m_HttpResponseHeaders", new WebHeaderCollection());
                    foreach (var header in responseMessage.Headers)
                    {
                        webResponse.Headers.Add(header.Key, header.Value.FirstOrDefault());
                    }
                    webResponse.Headers.Add("Content-Type", "application/json;odata=minimalmetadata");
                    BatchTestHelpers.SetField(webResponse, "m_StatusCode", responseMessage.StatusCode);
                }
            }
            return webResponse;
        }

        /// <summary>
        /// Serializes an HttpWebRespone and response body into a BatchResponse
        /// </summary>
        private static object GenerateBatchResponse(BatchRequest batchRequest, HttpWebResponse webResponse, Stream responseBody)
        {
            object batchResponse = null;
            Type requestBaseType = batchRequest.GetType().BaseType;
            if (requestBaseType != null)
            {
                Type batchResponseType = requestBaseType.GetGenericArguments()[0];
                MethodInfo processMethod = batchResponseType.GetMethod("ProcessResponse", BindingFlags.NonPublic | BindingFlags.Instance);
                ConstructorInfo constructor = batchResponseType.GetConstructor(new Type[] { });
                if (constructor != null)
                {
                    batchResponse = constructor.Invoke(null);
                    if (processMethod != null)
                    {
                        processMethod.Invoke(batchResponse, new object[] { webResponse, responseBody, null });
                    }
                }
            }
            return batchResponse;
        }

        /// <summary>
        /// Sleep method used for Scenario Tests. Only sleep when recording.
        /// </summary>
        private static void Sleep(int milliseconds)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                Thread.Sleep(milliseconds);
            }
        }
    }
}
