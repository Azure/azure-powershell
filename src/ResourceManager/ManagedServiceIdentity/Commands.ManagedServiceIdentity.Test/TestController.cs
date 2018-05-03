using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegacyTest = Microsoft.Azure.Test;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Resources;

namespace Microsoft.Azure.Commands.ManagedServiceIdentity.Test
{
    public class TestController
    {
        private LegacyTest.CSMTestEnvironmentFactory _csmTestFactory;
        private readonly EnvironmentSetupHelper _helper;

        public ManagedServiceIdentityClient ManagedServiceIdentityClient { get; private set; }

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient InternalResourceManagementClient { get; private set; }

        public TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = LegacyTest.TestUtilities.GetCallingClass(2);
            var mockName = LegacyTest.TestUtilities.GetCurrentMethodName(2);

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
            Action<LegacyTest.CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            d.Add("Microsoft.Storage", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {

                _csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();

                initialize?.Invoke(_csmTestFactory);

                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    _helper.RMResourceModule,
                    _helper.GetRMModulePath("AzureRm.ManagedServiceIdentity.psd1"),
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "AzureRM.Resources.ps1");

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            _helper.RunPowerShellTest(psScripts);
                        }
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
            ResourceManagementClient = GetResourceManagementClient();
            InternalResourceManagementClient = GetInternalResourceManagementClient(context);
            ManagedServiceIdentityClient = GetManagedServiceIdentityClient(context);
            _helper.SetupManagementClients(
                ResourceManagementClient,
                InternalResourceManagementClient,
                ManagedServiceIdentityClient);
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(this._csmTestFactory);
        }

        private ManagedServiceIdentityClient GetManagedServiceIdentityClient(MockContext context)
        {
            return context.GetServiceClient<ManagedServiceIdentityClient>();
        }

        private Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient GetInternalResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
