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
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.OperationalInsights;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Test
{
    public abstract class OperationalInsightsScenarioTestBase : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;

        protected OperationalInsightsScenarioTestBase()
        {
            _helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var operationalInsightsManagementClient = GetOperationalInsightsManagementClient(context);
            var resourceManagementClient = GetResourceManagementClient(context);

            _helper.SetupManagementClients(
                operationalInsightsManagementClient,
                resourceManagementClient);
        }

        protected void SetupDataClient(RestTestFramework.MockContext context)
        {
            var credentials = new ApiKeyClientCredentials("DEMO_KEY");
            var operationalInsightsDataClient = new OperationalInsightsDataClient(credentials, HttpMockServer.CreateInstance());

            _helper.SetupManagementClients(operationalInsightsDataClient);
        }

        protected void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            RunPowerShellTest(logger, true, false, scripts);
        }

        protected void RunDataPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            RunPowerShellTest(logger, false, true, scripts);
        }

        protected void RunPowerShellTest(XunitTracingInterceptor logger, bool setupManagementClients, bool setupDataClient, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(2);
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

            using (var context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                if (setupManagementClients)
                {
                    SetupManagementClients(context);
                    _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                }
                if (setupDataClient)
                {
                    SetupDataClient(context);
                }

                var callingClassName = callingClassType?.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.OperationalInsights.psd1"),
                    "AzureRM.Resources.ps1");

                _helper.RunPowerShellTest(scripts);
            }
        }

        protected OperationalInsightsManagementClient GetOperationalInsightsManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<OperationalInsightsManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        protected ResourceManagementClient GetResourceManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
