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
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Profile;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Test;
using System;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Test.Profile
{
    public sealed class ProfileTestController
    {
        private TestEnvironmentFactory testFactory;
        private EnvironmentSetupHelper helper;
        
        public static ProfileTestController NewRdfeInstance 
        { 
            get
            {
                return new ProfileTestController(AzureModule.AzureServiceManagement);
            }
        }

        public static ProfileTestController NewARMInstance
        {
            get
            {
                return new ProfileTestController(AzureModule.AzureResourceManager);
            }
        }

        public AzureModule Module
        {
            get; 
            private set; 
        }

        public ProfileTestController(AzureModule module)
        {
            Module = module;
            helper = new EnvironmentSetupHelper();
        }



        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => scripts, 
                // no custom initializer
                null, 
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPSTestWithToken(Func<AzureContext, string, string> testBuilder , params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);
            IAuthenticationFactory savedAuthFactory = AzureSession.AuthenticationFactory;
            try
            {
                RunPsTestWorkflow(
                    () =>
                    {
                        savedAuthFactory = AzureSession.AuthenticationFactory;
                        var command = new GetAzureSubscriptionCommand();
                        command.CommandRuntime = new MockCommandRuntime();
                        command.InvokeBeginProcessing();
                        var profile = command.Profile;
                        var context = profile.Context;
                        var account = context.Account;
                        var tenant = account.IsPropertySet(AzureAccount.Property.Tenants)
                            ? account.GetPropertyAsArray(AzureAccount.Property.Tenants).First()
                            : "Common";
                        var subscription = context.Subscription;
                        string token = null;
                        if (account.IsPropertySet(AzureAccount.Property.AccessToken))
                        {
                            token = account.GetProperty(AzureAccount.Property.AccessToken);
                        }
                        else
                        {
                            var accessToken = AzureSession.AuthenticationFactory.Authenticate(account,
                                context.Environment,
                                tenant, null, ShowDialog.Never);
                            Assert.IsNotNull(accessToken);
                            Assert.IsNotNull(accessToken.AccessToken);
                            token = accessToken.AccessToken;
                        }

                        AzureSession.AuthenticationFactory = new AuthenticationFactory();
                        var testString = testBuilder(context, token);
                        var returnedScripts = scripts.Concat(new String[] {testString});
                        return returnedScripts.ToArray();
                    },
                    // no custom initializer
                    null,
                    // no custom cleanup 
                    null,
                    callingClassType,
                    mockName);
            }
            finally
            {
               AzureSession.AuthenticationFactory = savedAuthFactory;
            }
        }

        public TestEnvironmentFactory GetFactory()
        {
            return (this.Module == AzureModule.AzureResourceManager) ? 
                new CSMTestEnvironmentFactory() as TestEnvironmentFactory : new RDFETestEnvironmentFactory() as TestEnvironmentFactory;
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder, 
            Action<TestEnvironmentFactory> initialize, 
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            HttpMockServer.Matcher = new PermissiveRecordMatcher();
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(callingClassType, mockName);

                this.testFactory = GetFactory();

                if(initialize != null)
                {
                    initialize(this.testFactory);
                }

                SetupManagementClients();

                helper.SetupEnvironment(this.Module);
                
                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(
                    this.Module, 
                    "Profile\\" + callingClassName + ".ps1");

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
                    if(cleanup !=null)
                    {
                        cleanup();
                    }
                }
            }
        }

        private void SetupManagementClients()
        {
            if (this.Module == AzureModule.AzureResourceManager)
            {
                helper.SetupSomeOfManagementClients();
            }
            else
            {
                helper.SetupSomeOfManagementClients();
            }
        }

    }
}
