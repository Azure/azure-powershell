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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.Azure.Commands.ScenarioTest.DnsTests
{
    using System;
    using System.Linq;
    using ServiceManagemenet.Common;
    using Microsoft.Azure.Gallery;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.Azure.Management.Dns;
    using Microsoft.Azure.Subscriptions;
    using WindowsAzure.Commands.Test.Utilities.Common;

    public class DnsTestsBase : RMTestBase
    { 
        private CSMTestEnvironmentFactory csmTestFactory; 


        private readonly EnvironmentSetupHelper helper; 


        public ResourceManagementClient ResourceManagementClient { get; private set; } 


        public SubscriptionClient SubscriptionClient { get; private set; } 


        public GalleryClient GalleryClient { get; private set; } 


        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; } 


        public DnsManagementClient DnsClient { get; private set; } 


        public static DnsTestsBase NewInstance 
        { 
            get 
            { 
                return new DnsTestsBase(); 
            } 
        } 


        protected DnsTestsBase() 
        { 
            this.helper = new EnvironmentSetupHelper(); 
        } 


        protected void SetupManagementClients() 
        { 
            this.ResourceManagementClient = this.GetResourceManagementClient(); 
            this.SubscriptionClient = this.GetSubscriptionClient(); 
            this.GalleryClient = this.GetGalleryClient(); 
            this.AuthorizationManagementClient = this.GetAuthorizationManagementClient(); 
            this.DnsClient = this.GetFeatureClient(); 


            this.helper.SetupManagementClients( 
                this.ResourceManagementClient,  
                this.SubscriptionClient, 
                this.GalleryClient,  
                this.AuthorizationManagementClient, 
                this.DnsClient); 
        } 


        public void RunPowerShellTest(params string[] scripts) 
        { 
            string callingClassType = TestUtilities.GetCallingClass(2); 
            string mockName = TestUtilities.GetCurrentMethodName(2); 


            this.RunPsTestWorkflow( 
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
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            using (UndoContext context = UndoContext.Current) 
            { 
                context.Start(callingClassType, mockName); 


                this.csmTestFactory = new CSMTestEnvironmentFactory(); 


                if (initialize != null) 
                { 
                    initialize(this.csmTestFactory); 
                } 


                this.SetupManagementClients(); 


                this.helper.SetupEnvironment(AzureModule.AzureResourceManager); 


                string callingClassName = callingClassType 
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries) 
                                        .Last();


                this.helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\Common.ps1", "ScenarioTests\\" + callingClassName + ".ps1", 
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath("AzureRM.Dns.psd1")); 

                try 
                { 
                    if (scriptBuilder != null) 
                    { 
                        string[] psScripts = scriptBuilder(); 


                        if (psScripts != null) 
                        { 
                            this.helper.RunPowerShellTest(psScripts); 
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


        protected ResourceManagementClient GetResourceManagementClient() 
        { 
            return TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory); 
        } 


        private AuthorizationManagementClient GetAuthorizationManagementClient() 
        { 
            return TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory); 
        } 


        private SubscriptionClient GetSubscriptionClient() 
        { 
            return TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory); 
        } 


        private GalleryClient GetGalleryClient() 
        { 
            return TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory); 
        }


        private DnsManagementClient GetFeatureClient() 
        {
            return TestBase.GetServiceClient<DnsManagementClient>(this.csmTestFactory); 
        } 
    } 
} 
