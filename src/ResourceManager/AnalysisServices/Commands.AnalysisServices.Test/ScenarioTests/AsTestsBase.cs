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
using Microsoft.Azure.Management.Analysis;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using NewResourceManagementClient = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System.IO;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.AnalysisServices.Test.ScenarioTests
{
    public class AsTestsBase : RMTestBase
    {
        private readonly EnvironmentSetupHelper _helper;
        //private const string AuthorizationApiVersion = "2014-07-01-preview";

        public NewResourceManagementClient NewResourceManagementClient { get; private set; }

        public AnalysisServicesManagementClient AnalysisServicesManagementClient { get; private set; }

        public static AsTestsBase NewInstance => new AsTestsBase();


        public AsTestsBase()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

            RunPsTestWorkflow(
                () => scripts,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }


        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
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

                // register the namespace.
                //TryRegisterSubscriptionForResource();
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager, 
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath(@"AzureRM.AnalysisServices.psd1"),
#if !NETSTANDARD
                    _helper.GetRMModulePath(@"Azure.AnalysisServices.psd1"),
#endif
                    "AzureRM.Resources.ps1");

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
            AnalysisServicesManagementClient = GetAnalysisServicesManagementClient(context);
            NewResourceManagementClient = GetNewResourceManagementClient(context);
            _helper.SetupManagementClients(NewResourceManagementClient,
                AnalysisServicesManagementClient);
        }

        private static NewResourceManagementClient GetNewResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<NewResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static AnalysisServicesManagementClient GetAnalysisServicesManagementClient(MockContext context)
        {
            return context.GetServiceClient<AnalysisServicesManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        //private void TryRegisterSubscriptionForResource(string providerName = "Microsoft.DataLakeStore")
        //{
        //    var reg = ResourceManagementClient.Providers.Register(providerName);
        //    ThrowIfTrue(reg == null, "resourceManagementClient.Providers.Register returned null.");
        //    ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK, string.Format("resourceManagementClient.Providers.Register returned with status code {0}", reg.StatusCode));

        //    var resultAfterRegister = ResourceManagementClient.Providers.Get(providerName);
        //    ThrowIfTrue(resultAfterRegister == null, "resourceManagementClient.Providers.Get returned null.");
        //    ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
        //    ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace), string.Format("Provider name is not equal to {0}.", providerName));
        //    ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
        //        ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
        //        string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.Provider.RegistrationState));
        //    ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes == null || resultAfterRegister.Provider.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
        //}

        //private void TryCreateResourceGroup(string resourceGroupName, string location)
        //{
        //    ResourceGroupCreateOrUpdateResult result = ResourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
        //    var newlyCreatedGroup = ResourceManagementClient.ResourceGroups.Get(resourceGroupName);
        //    ThrowIfTrue(newlyCreatedGroup == null, "resourceManagementClient.ResourceGroups.Get returned null.");
        //    ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.ResourceGroup.Name), string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        //}

        private static void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
    }
}
