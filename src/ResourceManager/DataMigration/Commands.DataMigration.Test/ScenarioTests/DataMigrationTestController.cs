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
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.DataMigration.Test;

namespace Microsoft.Azure.Commands.ScenarioTest.DmsTest
{

    public class DataMigrationTestController : RMTestBase
    {
        private int defaultTimeOut = 60;
        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;

        public static DataMigrationTestController NewInstance
        {
            get
            {
                return new DataMigrationTestController();
            }
        }

        public DataMigrationTestController()
        {
            helper = new EnvironmentSetupHelper();
            DataMigrationAppSettings settings = DataMigrationAppSettings.Instance;
            if(settings == null)
            {
                throw new ArgumentException("DMS Config File Appsettings.json not loaded properly");
            }
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = Microsoft.Azure.Test.TestUtilities.GetCallingClass(2);
            var mockName = Microsoft.Azure.Test.TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            d.Add("Microsoft.Compute", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath(@"AzureRM.DataMigration.psd1"),
                    "AzureRM.Resources.ps1"
                    );

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
            helper.SetupManagementClients(
                GetResourceManagementClient(),
                GetDmsClient(context),
                GetAuthorizationManagementClient(context)
                );
        }

        private DataMigrationServiceClient GetDmsClient(MockContext context)
        {
            DataMigrationServiceClient client = context.GetServiceClient<DataMigrationServiceClient>(Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory.GetTestEnvironment());
           
            client.LongRunningOperationRetryTimeout = DefaultTimeOut;

            return client;
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return Microsoft.Azure.Test.TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>(Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        private int DefaultTimeOut
        {
            get
            {
                if (HttpMockServer.Mode == HttpRecorderMode.Playback)
                {
                    defaultTimeOut = 0;
                }

                return defaultTimeOut;
            }
        }
      
    }
}
