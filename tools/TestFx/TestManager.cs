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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Azure.Commands.TestFx.Recorder;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.TestFx
{
    public delegate IRecordMatcher RecordMatcherDelegate (bool ignoreResourcesClient, Dictionary<string, string> resourceProviders, Dictionary<string, string> userAgentsToIgnore);
    
    public class TestManager : ITestRunnerFactory, ITestRunner
    {
        protected EnvironmentSetupHelper Helper;
        protected XunitTracingInterceptor Logger { get; set; }

        private readonly string _testProjectPath;
        private readonly string _callingClassName;
        private string _testBaseFolderName = String.Empty;
        private string _psTestScript;
        private readonly List<string> _psAzModules;
        private readonly List<string> _psCommonScripts = new List<string>();

        private RecordMatcherDelegate _recordMatcher;
        private bool _matcherIgnoreResourceClient = true;
        private Dictionary<string, string> _matcherUserAgentsToIgnore;
        private Dictionary<string, string> _matcherResourceProvidersToIgnore;
        
        private Action _initAction;
        private Action<MockContext> _mockContextAction;
        private Action _cleanupAction;

        private Func<MockContext, object>[] _initializedServiceClients;

        /// <summary>
        /// Factory method
        /// </summary>
        /// <param name="output"></param>
        /// <param name="callerFilePath"></param>
        /// <returns></returns>
        public static ITestRunnerFactory CreateInstance(ITestOutputHelper output, [CallerFilePath] string callerFilePath = null)
        {
            var callingClassName = string.IsNullOrEmpty(callerFilePath)
                ? null
                : Path.GetFileNameWithoutExtension(callerFilePath);

            return new TestManager(callingClassName, Assembly.GetCallingAssembly()).WithTestOutputHelper(output);
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="callingClassName"></param>
        protected TestManager(string callingClassName, Assembly callingAssembly)
        {
            Helper = new EnvironmentSetupHelper();
            _callingClassName = callingClassName;
            _testProjectPath = GetTestProjectPath(callingAssembly);

            _psAzModules = new List<string>
            {
                Helper.RMProfileModule,
                Helper.RMResourceModule,
            };
        }

        /// <summary>
        /// Sets a name of the subfolder where a test project keeps tests
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns>self</returns>
        public ITestRunnerFactory WithProjectSubfolderForTests(string folderName)
        {
            _testBaseFolderName = folderName ?? "ScenarioTests";
            return this;
        }

        /// <summary>
        /// Overrided default script name, which by convension is the cs test class name with ps1 extension.
        /// </summary>
        /// <param name="psScriptName"></param>
        /// <returns>self</returns>
        public ITestRunnerFactory WithNewPsScriptFilename(string psScriptName)
        {
            _psTestScript = psScriptName;
            return this;
        }

        /// <summary>
        /// Add helper scripts
        /// </summary>
        /// <param name="psScriptList"></param>
        /// <returns>self</returns>
        public ITestRunnerFactory WithCommonPsScripts(string[] psScriptList)
        {
            _psCommonScripts.AddRange(psScriptList);
            return this;
        }

        /// <summary>
        /// Clears default RM modules list and sets a brand new
        /// </summary>
        /// <param name="buildModuleList"></param>
        /// <returns></returns>
        public ITestRunnerFactory WithNewRmModules(Func<EnvironmentSetupHelper, string[]> buildModuleList)
        {
            _psAzModules.Clear();
            var moduleList = buildModuleList(Helper);
            _psAzModules.AddRange(moduleList);
            return this;
        }

        /// <summary>
        /// Adds extra RM modules in addition to the RMProfileModule and RMResourceModule,
        /// witch are added in the constructor.
        /// </summary>
        /// <param name="buildModuleList"></param>
        /// <returns></returns>
        public ITestRunnerFactory WithExtraRmModules(Func<EnvironmentSetupHelper, string[]> buildModuleList)
        {
            var moduleList = buildModuleList(Helper);
            _psAzModules.AddRange(moduleList);
            return this;
        }

        /// <summary>
        /// Set new argumets for the mock server record matcher
        /// </summary>
        /// <param name="userAgentsToIgnore">Dictionary [userAgent:apiVersion] to ignore</param>
        /// <param name="resourceProviders">Dictionary [resouceProvider:apiVersion] to match</param>
        /// <returns></returns>
        public ITestRunnerFactory WithNewRecordMatcherArguments(Dictionary<string, string> userAgentsToIgnore, Dictionary<string, string> resourceProviders, bool ignoreResourceClient = true)
        {
            _matcherIgnoreResourceClient = ignoreResourceClient;
            _matcherUserAgentsToIgnore = userAgentsToIgnore;
            _matcherResourceProvidersToIgnore = resourceProviders;
            return this;
        }

        public ITestRunnerFactory WithInitAction(Action initAction)
        {
            _initAction = initAction;
            return this;
        }

        public ITestRunnerFactory WithMockContextAction(Action<MockContext> mockContextAction)
        {
            _mockContextAction = mockContextAction;
            return this;
        }

        public ITestRunnerFactory WithCleanupAction(Action cleanupAction)
        {
            _cleanupAction = cleanupAction;
            return this;
        }

        /// <summary>
        /// Sets a new HttpMockServer.Matcher implementation. By defauls it's PermissiveRecordMatcherWithApiExclusion
        /// </summary>
        /// <param name="recordMatcher">delegate</param>
        /// <returns>self</returns>
        public ITestRunnerFactory WithRecordMatcher(RecordMatcherDelegate recordMatcher)
        {
            _recordMatcher = recordMatcher;
            return this;
        }

        public ITestRunnerFactory WithTestOutputHelper(ITestOutputHelper output)
        {
            Logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(Logger);
            Helper.TracingInterceptor = Logger;
            return this;
        }

        public ITestRunnerFactory WithManagementClients(params Func<MockContext, object>[] initializedManagementClients)
        {
            _initializedServiceClients = initializedManagementClients;
            return this;
        }

        public ITestRunner Build()
        {
            SetupSessionAndProfile();
            SetupMockServer();
            Helper.SetupModules(AzureModule.AzureResourceManager, BuildModulesList());
            return this;
        }

        public void RunTestScript(params string[] scripts)
        {
            RunTestScriptCore(null, null, null, scripts);
        }

        public void RunTestScript(Action<MockContext> contextAction, params string[] scripts)
        {
            RunTestScriptCore(null, contextAction, null, scripts);
        }

        public void RunTestScript(Action setUp, Action tearDown, params string[] scripts)
        {
            RunTestScriptCore(setUp, null, tearDown, scripts);
        }

        public void RunTestScript(Action setUp, Action<MockContext> contextAction, Action tearDown, params string[] scripts)
        {
            RunTestScriptCore(setUp, contextAction, tearDown, scripts);
        }

        private void RunTestScriptCore(Action setUp, Action<MockContext> contextAction, Action tearDown, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(2);
            var method = sf.GetMethod();
            var className = method.ReflectedType?.ToString();
            var methodName = method.Name;

            _initAction?.Invoke();
            setUp?.Invoke();

            using var context = MockContext.Start(className, methodName);
            _mockContextAction?.Invoke(context);
            Helper.SetupEnvironment(AzureModule.AzureResourceManager);
            SetupAzureContext();
            var serviceClients = SetupServiceClients(context);
            AzureSession.Instance.ClientFactory = new MockClientFactory(context, serviceClients);
            contextAction?.Invoke(context);
            Helper.RunPowerShellTest(scripts);

            tearDown?.Invoke();
            _cleanupAction?.Invoke();
        }

        private string GetTestProjectPath(Assembly testAssembly)
        {
            var testProjectPath = testAssembly.GetCustomAttributes<AssemblyMetadataAttribute>().Single(a => a.Key == "TestProjectPath")?.Value;

            if (string.IsNullOrEmpty(testProjectPath))
            {
                throw new InvalidOperationException($"Unable to determine the test directory for {testAssembly}");
            }

            return testProjectPath;
        }

        protected string[] BuildModulesList()
        {
            if (string.IsNullOrEmpty(_callingClassName)
                && string.IsNullOrEmpty(_psTestScript))
                throw new ArgumentNullException($"Both {nameof(_callingClassName)} and {nameof(_psTestScript)} are null");

            var allScripts = _psCommonScripts;
            if (_psTestScript != null)
            {
                allScripts.Add(_psTestScript);
            }

            var allScriptsWithPath = allScripts.Select(s => Path.Combine(_testBaseFolderName, s));

            var allModules = _psAzModules;
            allModules.AddRange(allScriptsWithPath);

            return allModules.ToArray();
        }

        protected void SetupSessionAndProfile()
        {
            AzureSessionInitializer.InitializeAzureSession();
            AzureSession.Instance.ARMContextSaveMode = ContextSaveMode.Process;
            ResourceManagerProfileProvider.InitializeResourceManagerProfile();
            if (!(AzureSession.Instance?.DataStore is MemoryDataStore))
            {
                AzureSession.Instance.DataStore = new MemoryDataStore();
            }
        }

        protected void SetupAzureContext()
        {
            const string tenantIdKey = "TenantId";
            const string subscriptionIdKey = "SubscriptionId";
            const string undefined = "Undefined";
            var zeroGuid = Guid.Empty.ToString();
            const string dummyGuid = "395544B0-BF41-429D-921F-E1CA2252FCF4";

            string tenantId =  null;
            string subscriptionId = null;
            switch (HttpMockServer.Mode)
            {
                case HttpRecorderMode.Record:
                    var environment = TestEnvironmentFactory.GetTestEnvironment();
                    tenantId = environment.TenantId;
                    subscriptionId = environment.SubscriptionId;
                    break;
                case HttpRecorderMode.Playback:
                    tenantId = HttpMockServer.Variables.ContainsKey(tenantIdKey)
                        ? HttpMockServer.Variables[tenantIdKey]
                        : dummyGuid;
                    subscriptionId = HttpMockServer.Variables.ContainsKey(subscriptionIdKey)
                        ? HttpMockServer.Variables[subscriptionIdKey]
                        : zeroGuid;
                    break;
                case HttpRecorderMode.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id = tenantId ?? undefined;
            AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.Id = subscriptionId ?? undefined;
        }

        protected void SetupMockServer()
        {
            var resourceProvidersToIgnore = _matcherResourceProvidersToIgnore?.Count > 0
                ? _matcherResourceProvidersToIgnore
                : new Dictionary<string, string>
                {
                    {"Microsoft.Resources", null},
                    {"Microsoft.Features", null},
                    {"Microsoft.Authorization", null},
                    {"Providers.Test", null},
                };

            var userAgentsToIgnore = _matcherUserAgentsToIgnore?.Count > 0
                ? _matcherUserAgentsToIgnore
                : new Dictionary<string, string>
                {
                    {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                };

            _recordMatcher ??= (ignoreResourcesClient, resourceProviders, userAgentsToIgnore) => new PermissiveRecordMatcherWithApiExclusion(ignoreResourcesClient, resourceProviders, userAgentsToIgnore);
            HttpMockServer.Matcher = _recordMatcher(_matcherIgnoreResourceClient, resourceProvidersToIgnore, userAgentsToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(_testProjectPath, "SessionRecords");
        }

        protected object[] SetupServiceClients(MockContext context)
        {
            if (_initializedServiceClients == null)
                return Array.Empty<object>();

            var clients = new List<object>();
            foreach (var client in _initializedServiceClients)
            {
                clients.Add(client(context));
            }
            return clients.ToArray();
        }
    }
}
