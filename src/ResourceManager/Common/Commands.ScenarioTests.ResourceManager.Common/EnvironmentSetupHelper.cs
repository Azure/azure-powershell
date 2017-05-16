﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Reflection;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    public class EnvironmentSetupHelper
    {
        private static string testEnvironmentName = "__test-environment";

        private static string testSubscriptionName = "__test-subscriptions";

        private AzureSubscription testSubscription;

        private AzureAccount testAccount;

        private const string PackageDirectoryFromCommon = @"..\..\..\..\Package\Debug";
        public string PackageDirectory = @"..\..\..\..\..\Package\Debug";

        protected List<string> modules;

        public XunitTracingInterceptor TracingInterceptor { get; set; }

        protected ProfileClient ProfileClient { get; set; }

        public EnvironmentSetupHelper()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            ServiceManagementProfileProvider.InitializeServiceManagementProfile();
            var datastore = new MemoryDataStore();
            AzureSession.Instance.DataStore = datastore;
            var profile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            var rmprofile = new AzureRmProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            rmprofile.EnvironmentTable.Add("foo", new AzureEnvironment(AzureEnvironment.PublicEnvironments.Values.FirstOrDefault()));
            rmprofile.DefaultContext = new AzureContext(new AzureSubscription(), new AzureAccount(), rmprofile.EnvironmentTable["foo"], new AzureTenant());
            rmprofile.DefaultContext.Subscription.SetEnvironment("foo");
            if (AzureRmProfileProvider.Instance.Profile == null)
            {
                AzureRmProfileProvider.Instance.Profile = rmprofile;
            }

            AzureSession.Instance.DataStore = datastore;
            ProfileClient = new ProfileClient(profile);

            // Ignore SSL errors
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;

            AdalTokenCache.ClearCookies();

            // Set RunningMocked
            TestMockSupport.RunningMocked = HttpMockServer.GetCurrentMode() == HttpRecorderMode.Playback;
        }

        public string RMProfileModule
        {
            get
            {
                return Path.Combine(this.PackageDirectory,
                                    @"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1");
            }
        }

        public string RMResourceModule
        {
            get
            {
                return Path.Combine(this.PackageDirectory,
                                    @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1");
            }
        }

        // This ResourceManagerStartup.ps1 contains Get-AzureRmAuthorizationChangeLog script
        public string RMResourceManagerStartup
        {
            get
            {
                return Path.Combine(this.PackageDirectory,
                                    @"ResourceManager\AzureResourceManager\AzureRM.Resources\ResourceManagerStartup.ps1");
            }
        }

        public string RMInsightsModule
        {
            get
            {
                return Path.Combine(this.PackageDirectory,
                                    @"ResourceManager\AzureResourceManager\AzureRM.Insights\AzureRM.Insights.psd1");
            }
        }

        public string RMStorageModule
        {
            get
            {
                return Path.Combine(this.PackageDirectory,
                                    @"ResourceManager\AzureResourceManager\AzureRM.Storage\AzureRM.Storage.psd1");
            }
        }

        //TODO: clarify (data plane should not be under ARM folder)
        public string RMStorageDataPlaneModule
        {
            get
            {
                return Path.Combine(this.PackageDirectory,
                                     @"Storage\Azure.Storage\Azure.Storage.psd1");
            }
        }

        public string GetRMModulePath(string psd1FileName)
        {
            string basename = Path.GetFileNameWithoutExtension(psd1FileName);
            return Path.Combine(this.PackageDirectory,
                                 @"ResourceManager\AzureResourceManager\" + basename + @"\" + psd1FileName);
        }
        /// <summary>
        /// Loads DummyManagementClientHelper with clients and throws exception if any client is missing.
        /// </summary>
        /// <param name="initializedManagementClients"></param>
        public void SetupManagementClients(params object[] initializedManagementClients)
        {
            AzureSession.Instance.ClientFactory = new MockClientFactory(initializedManagementClients);
        }

        /// <summary>
        /// Loads DummyManagementClientHelper with clients and sets it up to create missing clients dynamically.
        /// </summary>
        /// <param name="initializedManagementClients"></param>
        public void SetupSomeOfManagementClients(params object[] initializedManagementClients)
        {
            AzureSession.Instance.ClientFactory = new MockClientFactory(initializedManagementClients, false);
        }

        public void SetupEnvironment(AzureModule mode)
        {
            SetupAzureEnvironmentFromEnvironmentVariables(mode);

            ProfileClient.Profile.Save();
        }

        private void SetupAzureEnvironmentFromEnvironmentVariables(AzureModule mode)
        {
            TestEnvironment currentEnvironment = null;
            if (mode == AzureModule.AzureResourceManager)
            {
                currentEnvironment = new CSMTestEnvironmentFactory().GetTestEnvironment();
            }
            else
            {
                currentEnvironment = new RDFETestEnvironmentFactory().GetTestEnvironment();
            }

            if (currentEnvironment.UserName == null)
            {
                currentEnvironment.UserName = "fakeuser@microsoft.com";
            }

            SetAuthenticationFactory(mode, currentEnvironment);

            AzureEnvironment environment = new AzureEnvironment { Name = testEnvironmentName };

            Debug.Assert(currentEnvironment != null);
            environment.ActiveDirectoryAuthority = currentEnvironment.Endpoints.AADAuthUri.AbsoluteUri;
            environment.GalleryUrl = currentEnvironment.Endpoints.GalleryUri.AbsoluteUri;
            environment.ServiceManagementUrl = currentEnvironment.BaseUri.AbsoluteUri;
            environment.ResourceManagerUrl = currentEnvironment.Endpoints.ResourceManagementUri.AbsoluteUri;
            environment.GraphUrl = currentEnvironment.Endpoints.GraphUri.AbsoluteUri;
            environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = currentEnvironment.Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://", ""); // because it is just a sufix
            environment.AzureDataLakeStoreFileSystemEndpointSuffix = currentEnvironment.Endpoints.DataLakeStoreServiceUri.OriginalString.Replace("https://", ""); // because it is just a sufix

            if (!ProfileClient.Profile.EnvironmentTable.ContainsKey(testEnvironmentName))
            {
                ProfileClient.AddOrSetEnvironment(environment);
            }

            if (!AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>().EnvironmentTable.ContainsKey(testEnvironmentName))
            {
                AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>().EnvironmentTable[testEnvironmentName] = environment;
            }

            if (currentEnvironment.SubscriptionId != null)
            {
                testSubscription = new AzureSubscription()
                {
                    Id = currentEnvironment.SubscriptionId,
                    Name = testSubscriptionName,
                };

                testSubscription.SetEnvironment(testEnvironmentName);
                testSubscription.SetAccount(currentEnvironment.UserName);
                testSubscription.SetDefault();
                testSubscription.SetStorageAccount(Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT"));

                testAccount = new AzureAccount()
                {
                    Id = currentEnvironment.UserName,
                    Type = AzureAccount.AccountType.User,
                };

                testAccount.SetSubscriptions(currentEnvironment.SubscriptionId);

                ProfileClient.Profile.SubscriptionTable[testSubscription.GetId()] = testSubscription;
                ProfileClient.Profile.AccountTable[testAccount.Id] = testAccount;
                ProfileClient.SetSubscriptionAsDefault(testSubscription.Name, testSubscription.GetAccount());

                var testTenant = new AzureTenant() { Id = Guid.NewGuid().ToString() };
                if (!string.IsNullOrEmpty(currentEnvironment.Tenant))
                {
                    Guid tenant;
                    if (Guid.TryParse(currentEnvironment.Tenant, out tenant))
                    {
                        testTenant.Id = currentEnvironment.Tenant;
                    }
                }
                AzureRmProfileProvider.Instance.Profile.DefaultContext = new AzureContext(testSubscription, testAccount, environment, testTenant);
            }
        }

        private void SetAuthenticationFactory(AzureModule mode, TestEnvironment environment)
        {
            if(environment.AuthorizationContext.Certificate != null)
            {
                AzureSession.Instance.AuthenticationFactory = new MockCertificateAuthenticationFactory(environment.UserName,
                    environment.AuthorizationContext.Certificate);
            }
            else if(environment.AuthorizationContext.TokenCredentials.ContainsKey(TokenAudience.Management))
            {
                var httpMessage = new HttpRequestMessage();
                environment.AuthorizationContext.TokenCredentials[TokenAudience.Management]
                    .ProcessHttpRequestAsync(httpMessage, CancellationToken.None)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory(
                    environment.UserName,
                    httpMessage.Headers.Authorization.Parameter);
            }
        }

        public void SetupModules(AzureModule mode, params string[] modules)
        {
            this.modules = new List<string>();
            if (mode == AzureModule.AzureProfile)
            {
                this.modules.Add(Path.Combine(PackageDirectory, @"ServiceManagement\Azure\Azure.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Tags.psd1"));
            }
            else if (mode == AzureModule.AzureServiceManagement)
            {
                this.modules.Add(Path.Combine(PackageDirectory, @"ServiceManagement\Azure\Azure.psd1"));
            }

            this.modules.Add("Assert.ps1");
            this.modules.Add("Common.ps1");
            this.modules.AddRange(modules);
        }

        public void SetupModulesFromCommon(AzureModule mode, params string[] modules)
        {
            this.modules = new List<string>();
            if (mode == AzureModule.AzureProfile)
            {
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ServiceManagement\Azure\Azure.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Tags.psd1"));
            }
            else if (mode == AzureModule.AzureServiceManagement)
            {
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ServiceManagement\Azure\Azure.psd1"));
            }
            else if (mode == AzureModule.AzureResourceManager)
            {
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Tags.psd1"));
            }
            else
            {
                throw new ArgumentException("Unknown command type for testing");
            }
            this.modules.Add("Assert.ps1");
            this.modules.Add("Common.ps1");
            this.modules.AddRange(modules);
        }

        public void SetupModules(params string[] modules)
        {
            this.modules = new List<string>();
            this.modules.Add("Assert.ps1");
            this.modules.Add("Common.ps1");
            this.modules.AddRange(modules);
        }

        public virtual Collection<PSObject> RunPowerShellTest(params string[] scripts)
        {
            // If a test customizes the reecord matcher, use the cutomized version otherwise use the default
            // permissive record matcher.
            if (HttpMockServer.Matcher == null || HttpMockServer.Matcher.GetType() == typeof(SimpleRecordMatcher))
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("Microsoft.Resources", null);
                d.Add("Microsoft.Features", null);
                d.Add("Microsoft.Authorization", null);
                d.Add("Microsoft.Compute", null);
                var providersToIgnore = new Dictionary<string, string>();
                providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
                HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            }

            using (var powershell = System.Management.Automation.PowerShell.Create(RunspaceMode.NewRunspace))
            {
                SetupPowerShellModules(powershell);

                Collection<PSObject> output = null;
                for (int i = 0; i < scripts.Length; ++i)
                {
                    if (TracingInterceptor != null)
                    {
                        TracingInterceptor.Information(scripts[i]);
                    }
                    powershell.AddScript(scripts[i]);
                }
                try
                {
                    powershell.Runspace.Events.Subscribers.Clear();
                    output = powershell.Invoke();
                    if (powershell.Streams.Error.Count > 0)
                    {
                        throw new RuntimeException(
                            string.Format(
                                "Test failed due to a non-empty error stream. First error: {0}{1}",
                                PowerShellExtensions.FormatErrorRecord(powershell.Streams.Error[0]),
                                powershell.Streams.Error.Count > 0
                                    ? "Check the error stream in the test log for additional errors."
                                    : ""));
                    }

                    return output;
                }
                catch (Exception psException)
                {
                    powershell.LogPowerShellException(psException, TracingInterceptor);
                    throw;
                }
                finally
                {
                    powershell.LogPowerShellResults(output, TracingInterceptor);
                    powershell.Streams.Error.Clear();
                }
            }
        }

        private void SetupPowerShellModules(System.Management.Automation.PowerShell powershell)
        {
            powershell.AddScript("$error.clear()");
            powershell.AddScript(string.Format("Write-Debug \"current directory: {0}\"", AppDomain.CurrentDomain.BaseDirectory));
            powershell.AddScript(string.Format("Write-Debug \"current executing assembly: {0}\"", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
            powershell.AddScript(string.Format("cd \"{0}\"", AppDomain.CurrentDomain.BaseDirectory));

            foreach (string moduleName in modules)
            {
                powershell.AddScript(string.Format("Import-Module \"{0}\"", moduleName.AsAbsoluteLocation()));
            }

            powershell.AddScript(
                string.Format("set-location \"{0}\"", AppDomain.CurrentDomain.BaseDirectory));
            powershell.AddScript(string.Format(@"$TestOutputRoot='{0}'", AppDomain.CurrentDomain.BaseDirectory));
            powershell.AddScript("$VerbosePreference='Continue'");
            powershell.AddScript("$DebugPreference='Continue'");
            powershell.AddScript("$ErrorActionPreference='Stop'");
            powershell.AddScript("Write-Debug \"AZURE_TEST_MODE = $($env:AZURE_TEST_MODE)\"");
            powershell.AddScript("Write-Debug \"TEST_HTTPMOCK_OUTPUT =  $($env:TEST_HTTPMOCK_OUTPUT)\"");
        }

    }
}
