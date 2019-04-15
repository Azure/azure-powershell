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
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Linq;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Management.DeploymentManager;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Commands.DeploymentManager.Test.ScenarioTests
{
    public class DeploymentManagerController
    {
        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public AzureDeploymentManagerClient DeploymentManagerClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public ManagedServiceIdentityClient ManagedServiceIdentityClient { get; private set; }

        public GraphRbacManagementClient GraphManagementClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public DeploymentManagerController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public static DeploymentManagerController NewInstance => new DeploymentManagerController();

        private void SetupManagementClients(MockContext context)
        {
            DeploymentManagerClient = GetDeploymentManagementClient(context);
            ResourceManagementClient = GetResourceManagementClient(context);
            StorageClient = GetStorageManagementClient(context);
            ManagedServiceIdentityClient = GetManagedServiceIdentityClient(context);
            GraphManagementClient = GetGraphManagementClient(context);
            AuthorizationManagementClient = GetAuthorizationManagementClient(context);

            _helper.SetupManagementClients(
                DeploymentManagerClient,
                StorageClient,
                ResourceManagementClient,
                ManagedServiceIdentityClient,
                GraphManagementClient,
                AuthorizationManagementClient);
        }

        public void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
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
            var providersToIgnore = new Dictionary<string, string>();
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                var callingClassName = callingClassType?.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\DeploymentManagerTestsCommon.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    "AzureRM.Storage.ps1",
                    _helper.GetRMModulePath(@"Az.ManagedServiceIdentity.psd1"),
                    _helper.GetRMModulePath(@"Az.Storage.psd1"),
                    _helper.GetRMModulePath(@"Az.Resources.psd1"),
                    _helper.GetRMModulePath(@"Az.DeploymentManager.psd1"));

                if (scripts != null)
                {
                    _helper.RunPowerShellTest(scripts);
                }
            }
        }
        
        private static AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static GraphRbacManagementClient GetGraphManagementClient(MockContext context)
        {
            return context.GetServiceClient<GraphRbacManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ManagedServiceIdentityClient GetManagedServiceIdentityClient(MockContext context)
        {
            return context.GetServiceClient<ManagedServiceIdentityClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static AzureDeploymentManagerClient GetDeploymentManagementClient(MockContext context)
        {
            return context.GetServiceClient<AzureDeploymentManagerClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
