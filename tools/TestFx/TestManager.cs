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
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.TestFx
{
    public delegate IRecordMatcher RecordMatcherDelegate (bool ignoreResourcesClient, Dictionary<string, string> resourceProviders, Dictionary<string, string> userAgentsToIgnore);

    public class TestManager : ITestRunnerFactory, ITestRunner
    {
        private readonly string _callingClassName;
        private string _projectSubfolderForTestsName = null;
        private string _newPsScriptFilename = null;
        private Dictionary<string, string> _matcherExtraUserAgentsToIgnore;
        private Dictionary<string, string> _matcherNewUserAgentsToIgnore;
        private Dictionary<string, string> _matcherResourceProviders;
        private Action _mockContextAction;
        private Func<MockContext, object>[] _initializedManagementClients;
        protected EnvironmentSetupHelper Helper;
        protected readonly List<string> RmModules;
        protected readonly List<string> CommonPsScripts = new List<string>();

        protected RecordMatcherDelegate RecordMatcher { get; set; }

        protected XunitTracingInterceptor Logger { get; set; }

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
            return new TestManager(callingClassName).WithTestOutputHelper(output);
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="callingClassName"></param>
        protected TestManager(string callingClassName)
        {
            Helper = new EnvironmentSetupHelper();
            _callingClassName = callingClassName;

            RmModules = new List<string>
            {
                Helper.RMProfileModule,
                Helper.RMResourceModule,
            };

            RecordMatcher = (ignoreResourcesClient, resourceProviders, userAgentsToIgnore) =>
                new PermissiveRecordMatcherWithApiExclusion(ignoreResourcesClient, resourceProviders, userAgentsToIgnore);
        }

        #region Builder impl

        /// <summary>
        /// Sets a name of the subfolder where a test project keeps tests
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns>self</returns>
        public ITestRunnerFactory WithProjectSubfolderForTests(string folderName)
        {
            _projectSubfolderForTestsName = folderName ?? "ScenarioTests";
            return this;
        }

        /// <summary>
        /// Add helper scripts
        /// </summary>
        /// <param name="psScriptList"></param>
        /// <returns>self</returns>
        public ITestRunnerFactory WithCommonPsScripts(string[] psScriptList)
        {
            CommonPsScripts.AddRange(psScriptList);
            return this;
        }

        /// <summary>
        /// Overrided default script name, which by convension is the cs test class name with ps1 extension.
        /// </summary>
        /// <param name="psScriptName"></param>
        /// <returns>self</returns>
        public ITestRunnerFactory WithNewPsScriptFilename(string psScriptName)
        {
            _newPsScriptFilename = psScriptName;
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
            RmModules.AddRange(moduleList);
            return this;
        }

        /// <summary>
        /// Clears default RM modules list and sets a brand new
        /// </summary>
        /// <param name="buildModuleList"></param>
        /// <returns></returns>
        public ITestRunnerFactory WithNewRmModules(Func<EnvironmentSetupHelper, string[]> buildModuleList)
        {
            RmModules.Clear();
            var moduleList = buildModuleList(Helper);
            RmModules.AddRange(moduleList);
            return this;
        }

        /// <summary>
        /// Set new argumets for the mock server record matcher
        /// </summary>
        /// <param name="userAgentsToIgnore">Dictionary [userAgent:apiVersion] to ignore</param>
        /// <param name="resourceProviders">Dictionary [resouceProvider:apiVersion] to match</param>
        /// <returns></returns>
        public ITestRunnerFactory WithNewRecordMatcherArguments(Dictionary<string, string> userAgentsToIgnore, Dictionary<string, string> resourceProviders)
        {
            _matcherNewUserAgentsToIgnore = userAgentsToIgnore;
            _matcherResourceProviders = resourceProviders;
            return this;
        }

        public ITestRunnerFactory WithMockContextAction(Action mockContextAction)
        {
            _mockContextAction = mockContextAction;
            return this;
        }

        /// <summary>
        /// Sets a new HttpMockServer.Matcher implementation. By defauls it's PermissiveRecordMatcherWithApiExclusion
        /// </summary>
        /// <param name="recordMatcher">delegate</param>
        /// <returns>self</returns>
        public ITestRunnerFactory WithRecordMatcher(RecordMatcherDelegate recordMatcher)
        {
            RecordMatcher = recordMatcher;
            return this;
        }

        /// <summary>
        /// WithExtraUserAgentsToIgnore
        /// </summary>
        /// <param name="userAgentsToIgnore">
        /// Dictionary to store pairs: {user agent name, version-api to ignore}.
        /// Initial pair is {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
        /// </param>
        /// <returns>self</returns>
        public ITestRunnerFactory WithExtraUserAgentsToIgnore(Dictionary<string, string> userAgentsToIgnore)
        {
            _matcherExtraUserAgentsToIgnore = userAgentsToIgnore;
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
            _initializedManagementClients = initializedManagementClients;
            return this;
        }

        public ITestRunner Build()
        {
            SetupSessionAndProfile();
            SetupMockServerMatcher();
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            Helper.SetupModules(AzureModule.AzureResourceManager, BuildModulesList());
            return this;
        }

        public void RunTestScript(params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var className = sf.GetMethod().ReflectedType?.ToString();
            var methodName = sf.GetMethod().Name;

            using (var mockContext = MockContext.Start(className, methodName))
            {
                _mockContextAction?.Invoke();
                AzureSession.Instance.ClientFactory = new TestClientFactory(mockContext);
                SetupManagementClients(mockContext);
                Helper.SetupEnvironment(AzureModule.AzureResourceManager);
                SetupAzureContext();
                Helper.RunPowerShellTest(scripts);
            }
        }

        public void RunTestScript(Action setUp, Action tearDown, params string[] scripts)
        {
            setUp?.Invoke();
            RunTestScript(scripts);
            tearDown?.Invoke();
        }

        #endregion

        #region Helpers

        protected string[] BuildModulesList()
        {
            if (string.IsNullOrEmpty(_callingClassName)
                && string.IsNullOrEmpty(_newPsScriptFilename))
                throw new ArgumentNullException($"Both {nameof(_callingClassName)} and {nameof(_newPsScriptFilename)} are null");

            var allScripts = CommonPsScripts;

            if(_newPsScriptFilename != null)
            {
                allScripts.Add(_newPsScriptFilename);
            }
            

            var allScriptsWithPath = _projectSubfolderForTestsName == null
                ? allScripts
                : allScripts.Select(s => Path.Combine(_projectSubfolderForTestsName, s));

            var allModules = RmModules;
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
            const string domainKey = "Domain";
            const string subscriptionIdKey = "SubscriptionId";
            const string undefined = "Undefined";
            var zeroGuid = Guid.Empty.ToString();
            const string dummyGuid = "395544B0-BF41-429D-921F-E1CA2252FCF4";

            string tenantId =  null;
            string userDomain = null;
            string subscriptionId = null;
            switch (HttpMockServer.Mode)
            {
                case HttpRecorderMode.Record:
                    var environment = TestEnvironmentFactory.GetTestEnvironment();
                    tenantId = environment.Tenant;
                    userDomain = string.IsNullOrEmpty(environment.UserName)
                        ? string.Empty
                        : environment.UserName.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries).Last();

                    subscriptionId = environment.SubscriptionId;
                    break;
                case HttpRecorderMode.Playback:
                    tenantId = HttpMockServer.Variables.ContainsKey(tenantIdKey)
                        ? HttpMockServer.Variables[tenantIdKey]
                        : dummyGuid;
                    userDomain = HttpMockServer.Variables.ContainsKey(domainKey)
                        ? HttpMockServer.Variables[domainKey]
                        : "testdomain.onmicrosoft.com";
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

        protected void SetupMockServerMatcher()
        {
            var resourceProviders = _matcherResourceProviders?.Count > 0
                ? _matcherResourceProviders
                : new Dictionary<string, string> // default
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Providers.Test", null},
                    };

            var extraUserAgentsToIgnore = new Dictionary<string, string> // default
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
            };

            _matcherExtraUserAgentsToIgnore?.Keys.ForEach(k => extraUserAgentsToIgnore.Add(k, _matcherExtraUserAgentsToIgnore[k])); //extra

            var userAgentsToIgnore = _matcherNewUserAgentsToIgnore?.Count > 0
                ? _matcherNewUserAgentsToIgnore
                : extraUserAgentsToIgnore;

            HttpMockServer.Matcher = RecordMatcher(true, resourceProviders, userAgentsToIgnore);
        }

        protected void SetupManagementClients(MockContext context)
        {
            if (this._initializedManagementClients != null) {
                var clients = new List<object>();
                foreach (var client in this._initializedManagementClients)
                {
                    clients.Add(client(context));
                }
                Helper.SetupManagementClients(clients.ToArray());
            }
        }
        #endregion
    }
}
