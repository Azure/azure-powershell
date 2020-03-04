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
using Microsoft.Azure.Attestation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Attestation;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Attestation.Test
{
    class AttestationController
    {
        private readonly EnvironmentSetupHelper _helper;

        public static AttestationController NewInstance => new AttestationController();

        public AttestationController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            logger.Information(string.Format("Test method entered: {0}.{1}", callingClassType, mockName));
            _helper.TracingInterceptor = logger;

            RunPowerShellTestWorkflow(
                () => scripts,
                // no custom cleanup
                null,
                callingClassType,
                mockName,
                true,
                false);
        }

        public void RunDataPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            logger.Information(string.Format("Test method entered: {0}.{1}", callingClassType, mockName));
            _helper.TracingInterceptor = logger;

            RunPowerShellTestWorkflow(
                () => scripts,
                // no custom cleanup
                null,
                callingClassType,
                mockName,
                false,
                true);
        }

        public void RunPowerShellTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName,
            bool setupManagementClients,
            bool setupDataClient)
        {
            var providers = new Dictionary<string, string>
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
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (var context = MockContext.Start(callingClassType, mockName))
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

                var callingClassName =
                    callingClassType.Split(new[] {"."}, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.GetRMModulePath("AzureRM.Attestation.psd1"),
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
            _helper.SetupManagementClients(
                GetResourceManagementClient(context), 
                GetAttestationManagementClient(context)
            );
        }

        private void SetupDataClient(MockContext context)
        {
            _helper.SetupManagementClients(
                GetResourceManagementClient(context), 
                GetAttestationManagementClient(context), 
                GetAttestationClient(context)
            );
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static AttestationManagementClient GetAttestationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AttestationManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static AttestationClient GetAttestationClient(MockContext context)
        {
            string environmentConnectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            string accessToken = "fakefakefake";

            // When recording, we should have a connection string passed into the code from the environment
            if (!string.IsNullOrEmpty(environmentConnectionString))
            {
                // Gather test client credential information from the environment
                var connectionInfo = new ConnectionString(Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION"));
                string servicePrincipal = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalKey);
                string servicePrincipalSecret = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalSecretKey);
                string aadTenant = connectionInfo.GetValue<string>(ConnectionStringKeys.AADTenantKey);

                // Create credentials
                var clientCredentials = new ClientCredential(servicePrincipal, servicePrincipalSecret);
                var authContext = new AuthenticationContext($"https://login.windows.net/{aadTenant}", TokenCache.DefaultShared);
                accessToken = authContext.AcquireTokenAsync("https://attest.azure.net", clientCredentials).Result.AccessToken;
            }

            return new AttestationClient(new AttestationCredentials(accessToken), HttpMockServer.CreateInstance());
        }
    }
}
