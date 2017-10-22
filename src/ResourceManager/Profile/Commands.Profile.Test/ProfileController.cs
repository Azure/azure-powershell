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
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using LegacyTest = Microsoft.Azure.Test;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public sealed class ProfileController
    {
        private EnvironmentSetupHelper helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";
        private const string SubscriptionIdKey = "SubscriptionId";


        public Internal.Subscriptions.SubscriptionClient SubscriptionClient { get; private set; }

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public Management.Internal.Resources.ResourceManagementClient NewResourceManagementClient { get; private set; }

        public string UserDomain { get; private set; }

        public static ProfileController NewInstance
        {
            get { return new ProfileController(); }
        }

        public ProfileController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, string tenant, params string[] scripts)
        {
#if !NETSTANDARD
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);
#else
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            var callingClassType = sf.GetMethod().ReflectedType.ToString();
            var mockName = sf.GetMethod().Name;
#endif
            logger.Information(string.Format("Test method entered: {0}.{1}", callingClassType, mockName));
            helper.TracingInterceptor = logger;
            RunPsTestWorkflow(
                () => scripts,
                // no custom cleanup 
                null,
                callingClassType,
                mockName, tenant);
            logger.Information(string.Format("Test method finished: {0}.{1}", callingClassType, mockName));
        }

        private void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName, 
            string tenant)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                var oldFactory = AzureSession.Instance.AuthenticationFactory as MockTokenAuthenticationFactory;
                AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory(oldFactory.Token.UserId, oldFactory.Token.AccessToken, tenant);

                var callingClassName = callingClassType
                    .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                    .Last();
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "Common.ps1",
                    callingClassName + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.RMInsightsModule);

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    if (cleanup != null)
                    {
                        cleanup();
                    }
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            SubscriptionClient = GetSubscriptionClient(context);
            ResourceManagementClient = GetResourceManagementClient(context);
            NewResourceManagementClient = GetNewResourceManagementClient(context);

            helper.SetupManagementClients(SubscriptionClient, ResourceManagementClient, NewResourceManagementClient);
        }

        private Internal.Subscriptions.SubscriptionClient GetSubscriptionClient(MockContext context)
        {
            return context.GetServiceClient<Internal.Subscriptions.SubscriptionClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private Management.Internal.Resources.ResourceManagementClient GetNewResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Management.Internal.Resources.ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}