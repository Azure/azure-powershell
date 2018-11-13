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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.ContainerInstance.Test.ScenarioTests
{
    public class TestController
    {
        private readonly EnvironmentSetupHelper _helper;

        public ContainerInstanceManagementClient ContainerInstanceClient { get; private set; }

        public ResourceManagementClient ResourceClient { get; private set; }

        public TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public static TestController NewInstance => new TestController();

        public void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

            var providers = new Dictionary<string, string>()
            {
                { "Microsoft.Resources", null },
                { "Microsoft.Features", null },
                { "Microsoft.Authorization", null },
                { "Microsoft.Compute", null }
            };

            var providersToIgnore = new Dictionary<string, string>()
            {
                { "Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01" }
            };

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                var callingClassName = callingClassType?.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "AzureRM.Resources.ps1",
                    "ScenarioTests\\Common.ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.ContainerInstance.psd1"));

                if (scripts != null)
                {
                    _helper.RunPowerShellTest(scripts);
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ResourceClient = GetResourceManagementClient(context);
            ContainerInstanceClient = GetContainerInstanceManagementClient(context);
            _helper.SetupManagementClients(ResourceClient, ContainerInstanceClient);
        }

        private static ContainerInstanceManagementClient GetContainerInstanceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ContainerInstanceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
