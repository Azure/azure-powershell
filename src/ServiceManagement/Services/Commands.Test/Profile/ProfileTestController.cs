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

using Microsoft.Azure.Common.Authentication;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Test;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Test.Profile
{
    public sealed class ProfileTestController
    {
        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;

        public static ProfileTestController NewInstance 
        { 
            get
            {
                return new ProfileTestController();
            }
        }

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
        public ProfileTestController()
        {
            Module = AzureModule.AzureResourceManager;
            helper = new EnvironmentSetupHelper();
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

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder, 
            Action<CSMTestEnvironmentFactory> initialize, 
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(callingClassType, mockName);

                this.csmTestFactory = new CSMTestEnvironmentFactory();

                if(initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                SetupManagementClients();

                helper.SetupEnvironment(this.Module);
                
                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(
                    AzureModule.AzureResourceManager, 
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
