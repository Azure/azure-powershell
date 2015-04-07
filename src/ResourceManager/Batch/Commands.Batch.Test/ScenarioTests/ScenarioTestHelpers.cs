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

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Auth;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.Entities;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Reflection;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Moq;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    /// <summary>
    /// Helper methods for the Batch cmdlet scenario tests
    /// </summary>
    public static class ScenarioTestHelpers
    {
        // Content-Type header used by the Batch REST APIs
        private const string ContentTypeString = "application/json;odata=minimalmetadata";

        private const string DefaultPoolName = "testPool";

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
        /// Get Batch Context with keys
        /// </summary>
        public static BatchAccountContext GetBatchAccountContextWithKeys(BatchController controller, string accountName)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);
            BatchAccountContext context = client.ListKeys(null, accountName);

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
        /// </summary>
        public static void CreateTestPool(BatchController controller, BatchAccountContext context, string poolName)
        {
            YieldInjectionInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            NewPoolParameters parameters = new NewPoolParameters()
            {
                Context = context,
                PoolName = poolName,
                OSFamily = "4",
                TargetOSVersion = "*",
                TargetDedicated = 1,
                AdditionalBehaviors = behaviors
            };

            client.CreatePool(parameters);
        }

        /// <summary>
        /// Deletes a Pool used in a Scenario test.
        /// </summary>
        public static void DeletePool(BatchController controller, BatchAccountContext context, string poolName)
        {
            YieldInjectionInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            client.DeletePool(context, poolName, behaviors);
        }

        /// <summary>
        /// Creates a test WorkItem for use in Scenario tests.
        /// </summary>
        public static void CreateTestWorkItem(BatchController controller, BatchAccountContext context, string workItemName, TimeSpan? recurrenceInterval)
        {
            YieldInjectionInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            PSJobExecutionEnvironment jobExecutionEnvironment = new PSJobExecutionEnvironment();
            jobExecutionEnvironment.PoolName = DefaultPoolName;
            PSWorkItemSchedule schedule = null;
            if (recurrenceInterval != null)
            {
                schedule = new PSWorkItemSchedule();
                schedule.RecurrenceInterval = recurrenceInterval;
            }

            NewWorkItemParameters parameters = new NewWorkItemParameters()
            {
                Context = context,
                WorkItemName = workItemName,
                JobExecutionEnvironment = jobExecutionEnvironment,
                Schedule = schedule,
                AdditionalBehaviors = behaviors
            };

            client.CreateWorkItem(parameters);
        }

        /// <summary>
        /// Creates a test WorkItem for use in Scenario tests.
        /// </summary>
        public static void CreateTestWorkItem(BatchController controller, BatchAccountContext context, string workItemName)
        {
            CreateTestWorkItem(controller, context, workItemName, null);
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

            ListWorkItemOptions options = new ListWorkItemOptions()
            {
                Context = context,
                WorkItemName = workItemName,
                Filter = null,
                MaxCount = Constants.DefaultMaxCount,
                AdditionalBehaviors = behaviors
            };
            PSCloudWorkItem workItem = client.ListWorkItems(options).First();

            while (workItem.ExecutionInformation.RecentJob == null || string.Equals(workItem.ExecutionInformation.RecentJob.Name, previousJob, StringComparison.OrdinalIgnoreCase))
            {
                if (DateTime.Now > timeout)
                {
                    throw new TimeoutException("Timed out waiting for recent job");
                }
                Sleep(5000);
                workItem = client.ListWorkItems(options).First();
            }
            return workItem.ExecutionInformation.RecentJob.Name;
        }

        /// <summary>
        /// Creates a test Task for use in Scenario tests.
        /// </summary>
        public static void CreateTestTask(BatchController controller, BatchAccountContext context, string workItemName, string jobName, string taskName, string cmdLine = "cmd /c dir /s")
        {
            YieldInjectionInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            NewTaskParameters parameters = new NewTaskParameters()
            {
                Context = context,
                WorkItemName = workItemName,
                JobName = jobName,
                TaskName = taskName,
                CommandLine = cmdLine,
                RunElevated = true,
                AdditionalBehaviors = behaviors
            };
            
            client.CreateTask(parameters);
        }

        /// <summary>
        /// Waits for the specified task to complete
        /// </summary>
        public static void WaitForTaskCompletion(BatchController controller, BatchAccountContext context, string workItemName, string jobName, string taskName)
        {
            YieldInjectionInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListTaskOptions options = new ListTaskOptions()
            {
                Context = context,
                WorkItemName = workItemName,
                JobName = jobName,
                TaskName = taskName,
                AdditionalBehaviors = behaviors
            };
            IEnumerable<PSCloudTask> tasks = client.ListTasks(options);

            ITaskStateMonitor monitor = context.BatchOMClient.OpenToolbox().CreateTaskStateMonitor();
            monitor.WaitAll(tasks.Select(t => t.omObject), TaskState.Completed, TimeSpan.FromMinutes(2), null, behaviors);
        }

        /// <summary>
        /// Deletes a WorkItem used in a Scenario test.
        /// </summary>
        public static void DeleteWorkItem(BatchController controller, BatchAccountContext context, string workItemName)
        {
            YieldInjectionInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            client.DeleteWorkItem(context, workItemName, behaviors);
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
        /// Creates a test user for use in Scenario tests.
        /// </summary>
        public static void CreateTestUser(BatchController controller, BatchAccountContext context, string poolName, string vmName, string userName)
        {
            YieldInjectionInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            NewUserParameters parameters = new NewUserParameters()
            {
                Context = context,
                PoolName = poolName,
                VMName = vmName,
                UserName = userName,
                Password = "Password1234!",
                AdditionalBehaviors = behaviors
            };

            client.CreateUser(parameters);
        }

        /// <summary>
        /// Deletes a user used in a Scenario test.
        /// </summary>
        public static void DeleteUser(BatchController controller, BatchAccountContext context, string poolName, string vmName, string userName)
        {
            YieldInjectionInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            RemoveUserParameters parameters = new RemoveUserParameters()
            {
                Context = context,
                PoolName = poolName,
                VMName = vmName,
                UserName = userName,
                AdditionalBehaviors = behaviors
            };
            client.DeleteUser(parameters);
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

                    Delegate postProcessDelegate = null;
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
            
            // Get the generated HttpWebRequest from the BatchRequest
            MethodInfo createCommandMethod = batchRequest.GetType().GetMethod("CreateRestCommand", BindingFlags.NonPublic | BindingFlags.Instance);
            if (createCommandMethod != null)
            {
                object command = createCommandMethod.Invoke(batchRequest, null);
                FieldInfo buildRequestField = command.GetType().GetField("BuildRequestDelegate", BindingFlags.Public | BindingFlags.Instance);
                if (buildRequestField != null)
                {
                    PropertyInfo currentResultProperty = command.GetType().GetProperty("CurrentResult", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (currentResultProperty != null)
                    {
                        currentResultProperty.SetValue(command, new RequestResult());
                    }
                    Delegate buildRequest = buildRequestField.GetValue(command) as Delegate;
                    if (buildRequest != null)
                    {
                        HttpWebRequest webRequest = buildRequest.DynamicInvoke(uri, null, false, null, null) as HttpWebRequest;
                        if (webRequest != null)
                        {
                            // Delete requests set a Content-Length of 0 with the HttpRequestMessage class for some reason.
                            // Add in this header before signing the request.
                            if (webRequest.Method == "DELETE")
                            {
                                webRequest.ContentLength = 0;
                            }

                            // Sign the request to add the Authorization header
                            batchRequest.AuthenticationHandler.SignRequest(webRequest, null);

                            // Convert the signed HttpWebRequest into an HttpRequestMessage for use with the HTTP Recorder
                            requestMessage = new HttpRequestMessage(new HttpMethod(webRequest.Method), webRequest.RequestUri);
                            foreach (var header in webRequest.Headers)
                            {
                                string key = header.ToString();
                                string value = webRequest.Headers[key];
                                if (string.Equals(key, "Content-Type"))
                                {
                                    // Copy the Content to the HttpRequestMessage
                                    FieldInfo streamField = command.GetType().GetField("SendStream", BindingFlags.Public | BindingFlags.Instance);
                                    if (streamField != null)
                                    {
                                        Stream contentStream = streamField.GetValue(command) as Stream;
                                        if (contentStream != null)
                                        {
                                            MemoryStream memStream = new MemoryStream();

                                            contentStream.CopyTo(memStream);
                                            memStream.Seek(0, SeekOrigin.Begin);
                                            requestMessage.Content = new StreamContent(memStream);

                                            // Add Content-Type header to the HttpRequestMessage
                                            // Use a custom class to force the proper formatting of the Content-Type header.
                                            requestMessage.Content.Headers.ContentType = new JsonOdataMinimalHeader();
                                            requestMessage.Content.Headers.ContentLength = webRequest.ContentLength;
                                        }
                                    }
                                }
                                else
                                { 
                                    requestMessage.Headers.Add(key, value);
                                }
                            }
                        }
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
                    webResponse.Headers.Add("Content-Type", ContentTypeString);
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
            MethodInfo createCommandMethod = batchRequest.GetType().GetMethod("CreateRestCommand", BindingFlags.NonPublic | BindingFlags.Instance);
            if (createCommandMethod != null)
            {
                object command = createCommandMethod.Invoke(batchRequest, null);
                FieldInfo preProcessField = command.GetType().GetField("PreProcessResponse", BindingFlags.Public | BindingFlags.Instance);
                if (preProcessField != null)
                {
                    Delegate preProcessDelegate = preProcessField.GetValue(command) as Delegate;
                    if (preProcessDelegate != null)
                    {
                        preProcessDelegate.DynamicInvoke(command, webResponse, null, null);
                    }
                }

                FieldInfo postProcessField = command.GetType().GetField("PostProcessResponse", BindingFlags.Public | BindingFlags.Instance);
                if (postProcessField != null)
                {
                    Delegate postProcessDelegate = postProcessField.GetValue(command) as Delegate;
                    if (postProcessDelegate != null)
                    {
                        FieldInfo responseStreamField = command.GetType().GetField("ResponseStream", BindingFlags.Public | BindingFlags.Instance);
                        if (responseStreamField != null)
                        {
                            responseStreamField.SetValue(command, responseBody);
                        }
                        FieldInfo destinationStreamField = command.GetType().GetField("DestinationStream", BindingFlags.Public | BindingFlags.Instance);
                        if (destinationStreamField != null)
                        {
                            Stream destinationStream = destinationStreamField.GetValue(command) as Stream;
                            if (destinationStream != null)
                            {
                                responseBody.CopyTo(destinationStream);
                            }
                        }
                        batchResponse = postProcessDelegate.DynamicInvoke(command, webResponse, null, null);
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

        /// <summary>
        /// Custom override to the HttpRequestMessage Content header.
        /// By default, calling MediaTypeHeaderValue.Parse("application/json;odata=minimalmetadata") will
        /// add an extra space character to the Content-Type header that the Batch service will reject as 
        /// incorrectly formatted. This extension class overrides the ToString() method to return the 
        /// Content-Type header string without any extra spaces.
        /// </summary>
        private class JsonOdataMinimalHeader : MediaTypeHeaderValue
        {
            public JsonOdataMinimalHeader() : base("application/json")
            { }

            public override string ToString()
            {
                return ContentTypeString;
            }
        }
    }
}
