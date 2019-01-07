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

using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.NotificationHubs;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.Collections.Generic;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.IO;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Commands.NotificationHubs.Test
{
    public abstract class TestBaseClass : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        protected TestBaseClass()
        {
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            var resourceManagementClient = GetResourceManagementClient(context);
            var nhManagementClient = GetNotificationHubsManagementClient(context);

            _helper.SetupManagementClients(nhManagementClient, resourceManagementClient);
        }

        protected void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                var callingClassName = callingClassType?.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();

                var modules = new List<string>
                {
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.NotificationHubs.psd1"),
                    "AzureRM.Resources.ps1"
                };

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                _helper.SetupModules(AzureModule.AzureResourceManager, modules.ToArray());

                if (scripts != null)
                {
                    _helper.RunPowerShellTest(scripts);
                }
            }
        }

        protected NotificationHubsManagementClient GetNotificationHubsManagementClient(MockContext context)
        {
            return context.GetServiceClient<NotificationHubsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
