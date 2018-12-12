﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources;
using SubscriptionClient = Microsoft.Azure.Internal.Subscriptions.SubscriptionClient;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public sealed class ProfileController
    {
        private readonly EnvironmentSetupHelper _helper;

        public SubscriptionClient SubscriptionClient { get; private set; }

        public ResourceManagementClient NewResourceManagementClient { get; private set; }

        public static ProfileController NewInstance => new ProfileController();

        public ProfileController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, string tenant, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            logger.Information(string.Format("Test method entered: {0}.{1}", callingClassType, mockName));
            _helper.TracingInterceptor = logger;
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
            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                var oldFactory = AzureSession.Instance.AuthenticationFactory as MockTokenAuthenticationFactory;
                AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory(oldFactory?.Token.UserId, oldFactory?.Token.AccessToken, tenant);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "Common.ps1",
                    callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    "AzureRM.Resources.ps1"
                    );

                try
                {
                    var psScripts = scriptBuilder?.Invoke();
                    if (psScripts != null)
                    {
                        _helper.RunPowerShellTest(psScripts);
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            SubscriptionClient = GetSubscriptionClient(context);
            NewResourceManagementClient = GetNewResourceManagementClient(context);

            _helper.SetupManagementClients(SubscriptionClient, NewResourceManagementClient);
        }

        private static SubscriptionClient GetSubscriptionClient(MockContext context)
        {
            return context.GetServiceClient<SubscriptionClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetNewResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}