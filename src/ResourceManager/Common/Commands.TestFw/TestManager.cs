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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit.Abstractions;

namespace  Microsoft.Azure.Commands.TestFw
{
    public delegate IRecordMatcher BuildMatcherDelegate (bool ignoreResourcesClient, Dictionary<string, string> resourceProviders, Dictionary<string, string> userAgentsToIgnore);

    public class TestManager : IPreBuildable, IBuildable, ITestRunnable
    {
        private readonly string _callingClassName;
        private string _projectSubfolderForTestsName = null;
        private string _newPsScriptFilename = null;
        private Dictionary<string, string> _userAgentsToIgnore;
        protected EnvironmentSetupHelper Helper;
        protected readonly List<string> RmModules;
        protected readonly List<string> CommonPsScripts = new List<string>();

        protected BuildMatcherDelegate BuildMatcher { get; set; }

        protected XunitTracingInterceptor Logger { get; set; }

        /// <summary>
        /// Factory method
        /// </summary>
        /// <param name="callerFilePath"></param>
        /// <returns></returns>
        public static IPreBuildable CreateInstance([CallerFilePath] string callerFilePath = null)
        {
            var callingClassName = string.IsNullOrEmpty(callerFilePath) 
                ? null
                : Path.GetFileNameWithoutExtension(callerFilePath);
            return new TestManager(callingClassName);
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

            BuildMatcher = (ignoreResourcesClient, resourceProviders, userAgentsToIgnore) =>
                new PermissiveRecordMatcherWithApiExclusion(ignoreResourcesClient, resourceProviders, userAgentsToIgnore);
        }

        #region Builder impl

        /// <summary>
        /// Sets a name of the subfolder where a test project keeps tests 
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns>self</returns>
        public IBuildable WithProjectSubfolderForTests(string folderName)
        {
            _projectSubfolderForTestsName = folderName ?? "ScenarioTests";
            return this;
        }

        /// <summary>
        /// Add helper scripts
        /// </summary>
        /// <param name="psScriptList"></param>
        /// <returns>self</returns>
        public IBuildable WithCommonPsScripts(string[] psScriptList)
        {
            CommonPsScripts.AddRange(psScriptList);
            return this;
        }

        /// <summary>
        /// Overrided default script name, which by convension is the cs test class name with ps1 extension.
        /// </summary>
        /// <param name="psScriptName"></param>
        /// <returns>self</returns>
        public IBuildable WithNewPsScriptFilename(string psScriptName)
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
        public IBuildable WithExtraRmModules(Func<EnvironmentSetupHelper, string[]> buildModuleList)
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
        public IBuildable WithNewRmModules(Func<EnvironmentSetupHelper, string[]> buildModuleList)
        {
            RmModules.Clear();
            var moduleList = buildModuleList(Helper);
            RmModules.AddRange(moduleList);
            return this;
        }

        /// <summary>
        /// Sets a new HttpMockServer.Matcher implementation. By defauls it's PermissiveRecordMatcherWithApiExclusion
        /// </summary>
        /// <param name="buildMatcher">delegate</param>
        /// <returns>self</returns>
        public IBuildable WithNewMockServerMatcher(BuildMatcherDelegate buildMatcher)
        {
            BuildMatcher = buildMatcher;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAgentsToIgnore">
        /// Dictionary to store pairs: {user agent name, version-api to ignore}.
        /// Initial pair is {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
        /// </param>
        /// <returns>self</returns>
        public IBuildable WithExtraUserAgentsToIgnore(Dictionary<string, string> userAgentsToIgnore)
        {
            _userAgentsToIgnore = userAgentsToIgnore;
            return this;
        }

        public IBuildable WithXunitTracingInterceptor(ITestOutputHelper output)
        {
            Logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(Logger);
            Helper.TracingInterceptor = Logger;
            return this;
        }

        public ITestRunnable Build()
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
                AzureSession.Instance.ClientFactory = new TestClientFactory(mockContext);
                Helper.SetupEnvironment(AzureModule.AzureResourceManager);
                SetupAzureContext();
                Helper.RunPowerShellTest(scripts);
            }
        }

        #endregion

        #region Helpers

        protected string[] BuildModulesList()
        {
            if (string.IsNullOrEmpty(_callingClassName)
                && string.IsNullOrEmpty(_newPsScriptFilename))
                throw new ArgumentNullException($"Both {nameof(_callingClassName)} and {nameof(_newPsScriptFilename)} are null");

            var allScripts = CommonPsScripts;
            allScripts.Add(_newPsScriptFilename ?? $"{_callingClassName}.ps1");

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
            var zeroGuild = Guid.Empty.ToString();

            string tenantId =  null;
            string userDomain = null;
            string subscriptionId = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                tenantId = environment.Tenant;
                userDomain = string.IsNullOrEmpty(environment.UserName) 
                    ? string.Empty 
                    : environment.UserName.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries).Last();

                subscriptionId = environment.SubscriptionId;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                tenantId = HttpMockServer.Variables.ContainsKey(tenantIdKey)
                    ? HttpMockServer.Variables[tenantIdKey]
                    : zeroGuild;
                userDomain = HttpMockServer.Variables.ContainsKey(domainKey)
                    ? HttpMockServer.Variables[domainKey]
                    : "testdomain.onmicrosoft.com";
                subscriptionId = HttpMockServer.Variables.ContainsKey(subscriptionIdKey)
                    ? HttpMockServer.Variables[subscriptionIdKey]
                    : zeroGuild;
            }

            AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id = tenantId ?? undefined;
            AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Directory = userDomain ?? undefined;
            AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.Id = subscriptionId ?? undefined;
        }

        protected void SetupMockServerMatcher()
        {
            var resourceProviders = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Providers.Test", null},
            };

            var userAgentsToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
            };

            _userAgentsToIgnore?.Keys.ForEach(k=> userAgentsToIgnore.Add(k, _userAgentsToIgnore[k]));

            HttpMockServer.Matcher = BuildMatcher(true, resourceProviders, userAgentsToIgnore);
        }

        #endregion
    }

    #region Builder interfaces

    public interface IPreBuildable
    {
        IBuildable WithXunitTracingInterceptor(ITestOutputHelper output);   
    }

    public interface IBuildable
    {
        ITestRunnable Build();
        IBuildable WithProjectSubfolderForTests(string folderName);
        IBuildable WithCommonPsScripts(string[] psScriptList);
        IBuildable WithNewPsScriptFilename(string psScriptName);
        IBuildable WithExtraRmModules(Func<EnvironmentSetupHelper, string[]> buildModuleList);
        IBuildable WithNewRmModules(Func<EnvironmentSetupHelper, string[]> buildModuleList);
        IBuildable WithExtraUserAgentsToIgnore(Dictionary<string, string> userAgentsToIgnore);
        IBuildable WithNewMockServerMatcher(BuildMatcherDelegate buildMatcher);
    }

    public interface ITestRunnable
    {
        void RunTestScript(params string[] scripts);
    }

    #endregion
}
