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

using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.Commands.TestFx.DelegatingHandlers;
using Microsoft.Azure.Commands.TestFx.Recorder;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public sealed class MockContext : IDisposable
    {
        //prevent multiple dispose events
        private bool _disposed = false;
        private readonly List<ResourceCleanerDelegatingHandler> _undoHandlers = new List<ResourceCleanerDelegatingHandler>();
        private TestEnvironment _testFxEnvironment;

        private MockContext()
        {
        }

        internal TestEnvironment TestFxEnvironment
        {
            get
            {
                if (_testFxEnvironment == null)
                {
                    string envStr = Environment.GetEnvironmentVariable(ConnectionStringKeys.TestCSMOrgIdConnectionStringKey);
                    _testFxEnvironment = new TestEnvironment(envStr);
                    OptimizeTestRecordingFile = _testFxEnvironment.OptimizeRecordedFile;
                }

                return _testFxEnvironment;
            }
        }

        internal bool OptimizeTestRecordingFile { get; set; } = false;

        /// <summary>
        /// Return a new MockContext
        /// </summary>
        /// <returns></returns>
        public static MockContext Start(
            string className,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "testframework_failed")
        {
            var context = new MockContext();
            if (HttpMockServer.FileSystemUtilsObject == null)
            {
                HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
            }
            HttpMockServer.Initialize(className, methodName);

            return context;
        }

        /// <summary>
        /// Return a new MockContext
        /// </summary>
        /// <returns></returns>
        public static MockContext Start(
            Type type,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "testframework_failed")
        {
            return Start(type.Name, methodName);
        }

        /// <summary>
        /// Get a test environment using default options
        /// </summary>
        /// <typeparam name="T">The type of the service client to return</typeparam>
        /// <returns>A Service client using credentials and base uri from the current environment</returns>
        public T GetServiceClient<T>(bool internalBaseUri = false, params DelegatingHandler[] handlers) where T : class
        {
            return GetServiceClient<T>(TestFxEnvironment, internalBaseUri, handlers);
        }

        /// <summary>
        /// Get a test environment, allowing the test to customize the creation options
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handlers">Delegating existingHandlers</param>
        /// <returns></returns>
        public T GetServiceClient<T>(TestEnvironment currentEnvironment, bool internalBaseUri = false, params DelegatingHandler[] handlers) where T : class
        {
            return GetServiceClientWithCredentials<T>(currentEnvironment,
                currentEnvironment.TokenInfo[TokenAudience.Management], internalBaseUri, handlers);
        }

        /// <summary>
        /// Creates Graph client object 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handlers">Delegating existingHandlers</param>
        /// <returns></returns>
        public T GetGraphServiceClient<T>(
            bool internalBaseUri = false,
            params DelegatingHandler[] handlers) where T : class
        {
            //TestFxEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            return GetGraphServiceClient<T>(TestFxEnvironment, internalBaseUri, handlers);
        }

        /// <summary>
        /// Creates Graph client object 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handlers">Delegating existingHandlers</param>
        /// <returns></returns>
        public T GetGraphServiceClient<T>(
            TestEnvironment currentEnvironment,
            bool internalBaseUri = false,
            params DelegatingHandler[] handlers) where T : class
        {
            if (!currentEnvironment.TokenInfo.ContainsKey(TokenAudience.Graph))
            {
                throw new ArgumentNullException(
                    "currentEnvironment.TokenInfo[TokenAudience.Graph]",
                    "Unable to create Graph Management client because Graph authentication token was not acquired during Login.");
            }

            return GetServiceClientWithCredentials<T>(
                currentEnvironment,
                currentEnvironment.TokenInfo[TokenAudience.Graph],
                currentEnvironment.Endpoints.GraphUri,
                internalBaseUri,
                handlers);
        }

        /// <summary>
        /// Get a test environment using default options
        /// </summary>
        /// <typeparam name="T">The type of the service client to return</typeparam>
        /// <param name="credentials">Credentials</param>
        /// <param name="handlers">Delegating existingHandlers</param>
        /// <returns>A Service client using credentials and base uri from the current environment</returns>
        public T GetServiceClientWithCredentials<T>(object credentials, params DelegatingHandler[] handlers) where T : class
        {
            return GetServiceClientWithCredentials<T>(TestFxEnvironment, credentials, handlers: handlers);
        }

        /// <summary>
        /// Get a test environment, allowing the test to customize the creation options
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="credentials">Credentials</param>
        /// <param name="handlers">Delegating existingHandlers</param>
        /// <returns></returns>
        public T GetServiceClientWithCredentials<T>(
            TestEnvironment currentEnvironment,
            object credentials,
            bool internalBaseUri = false,
            params DelegatingHandler[] handlers) where T : class
        {
            return GetServiceClientWithCredentials<T>(currentEnvironment, credentials, currentEnvironment.BaseUri, internalBaseUri, handlers);
        }

        /// <summary>
        /// Get a test environment, allowing the test to customize the creation options
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="credentials">Credentials</param>
        /// <param name="baseUri">Base Uri</param>
        /// <param name="handlers">Delegating existingHandlers</param>
        /// <returns></returns>
        public T GetServiceClientWithCredentials<T>(
            TestEnvironment currentEnvironment,
            object credentials,
            Uri baseUri,
            bool internalBaseUri = false,
            params DelegatingHandler[] handlers) where T : class
        {
            T client;
            handlers = AddHandlers(currentEnvironment, handlers);
            var constructors = typeof(T).GetConstructors(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

            ConstructorInfo constructor = null;
            //We no longer use UseCustomUri function, rather check if BaseUri is notNull
            //UseCustomeUri use to return true when BaseUri was set to some value
            if ((currentEnvironment.BaseUri != null) && !internalBaseUri)
            {
                foreach (var c in constructors)
                {
                    var parameters = c.GetParameters();
                    if (parameters.Length == 3 &&
                        parameters[0].ParameterType.Name == "Uri" &&
                        parameters[1].ParameterType.Name == "ServiceClientCredentials" &&
                        parameters[2].ParameterType.Name == "DelegatingHandler[]")
                    {
                        constructor = c;
                        break;
                    }
                }
                if (constructor == null)
                {
                    throw new InvalidOperationException(
                        "can't find constructor (uri, ServiceClientCredentials, DelegatingHandler[]) to create client");
                }
                client = constructor.Invoke(new object[]
                {
                    baseUri,
                    credentials,
                    handlers
                }) as T;
            }
            else
            {
                foreach (var c in constructors)
                {
                    var parameters = c.GetParameters();
                    if (parameters.Length == 2 &&
                        parameters[0].ParameterType.Name == "ServiceClientCredentials" &&
                        parameters[1].ParameterType.Name == "DelegatingHandler[]")
                    {
                        constructor = c;
                        break;
                    }
                }
                if (constructor == null)
                {
                    throw new InvalidOperationException(
                        "can't find constructor (ServiceClientCredentials, DelegatingHandler[]) to create client");
                }
                client = constructor.Invoke(new object[]
                {
                    credentials,
                    handlers
                }) as T;
            }

            var subscriptionId = typeof(T).GetProperty("SubscriptionId");
            if (subscriptionId != null && currentEnvironment.SubscriptionId != null)
            {
                subscriptionId.SetValue(client, currentEnvironment.SubscriptionId);
            }

            var tenantId = typeof(T).GetProperty("TenantId");
            if (tenantId != null && currentEnvironment.TenantId != null)
            {
                tenantId.SetValue(client, currentEnvironment.TenantId);
            }
            SetLongRunningOperationTimeouts(client);
            return client;
        }

        private void SetLongRunningOperationTimeouts<T>(T client) where T : class
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                PropertyInfo retryTimeout = typeof(T).GetProperty("LongRunningOperationRetryTimeout");
                if (retryTimeout != null)
                {
                    retryTimeout.SetValue(client, 0);
                }
            }
        }

        public DelegatingHandler[] AddHandlers(TestEnvironment currentEnvironment,
            params DelegatingHandler[] existingHandlers)
        {
            HttpMockServer server;

            try
            {
                server = HttpMockServer.CreateInstance();
            }
            catch (InvalidOperationException)
            {
                // mock server has never been initialized, we will need to initialize it.
                HttpMockServer.Initialize("TestEnvironment", "InitialCreation");
                server = HttpMockServer.CreateInstance();
            }

            var handlers = new List<DelegatingHandler>(existingHandlers);
            if (!MockServerInHandlers(handlers))
            {
                handlers.Add(server);
            }

            ResourceCleanerDelegatingHandler cleaner = new ResourceCleanerDelegatingHandler(currentEnvironment.TokenInfo[TokenAudience.Management]);
            handlers.Add(cleaner);
            _undoHandlers.Add(cleaner);

            return handlers.ToArray();
        }

        /// <summary>
        /// Stop recording and Discard all undo information
        /// </summary>
        public void Stop()
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                foreach (var undoHandler in _undoHandlers)
                {
                    undoHandler.DeleteResourceGroups().ConfigureAwait(false).GetAwaiter().GetResult();
                }
            }

            string recordedFilePath = HttpMockServer.Flush();

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                // this check should be removed once we make the optimizatoin default
                if (OptimizeTestRecordingFile)
                {
                    RecordedFiles procRecFile = new RecordedFiles(recordedFilePath);
                    procRecFile.CompactLroPolling();
                    procRecFile.SerializeCompactData();
                }
            }
        }

        private static bool MockServerInHandlers(List<DelegatingHandler> handlers)
        {
            var result = false;
            foreach (var handler in handlers)
            {
                if (HandlerContains<HttpMockServer>(handler))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private static bool HandlerContains<T1>(DelegatingHandler handler)
        {
            return (handler is T1 || (handler.InnerHandler != null
                && handler.InnerHandler is DelegatingHandler
                && HandlerContains<T1>(handler.InnerHandler as DelegatingHandler)));
        }

        /// <summary>
        /// Dispose only if we have not previously been disposed
        /// </summary>
        /// <param name="disposing">true if we should dispose, otherwise false</param>
        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                Stop();
                _disposed = true;
            }
        }

        /// <summary>
        /// Dispose the object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
