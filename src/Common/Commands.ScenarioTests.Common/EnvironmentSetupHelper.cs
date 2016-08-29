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

using Microsoft.Azure;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.ServiceManagemenet.Common;
using System.Text;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;
using System.Net.Http;
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
        public const string PackageDirectory = @"..\..\..\..\..\Package\Debug";

        protected List<string> modules;

        public XunitTracingInterceptor TracingInterceptor { get; set; }

        protected ProfileClient ProfileClient { get; set; }

        public EnvironmentSetupHelper()
        {
            var datastore = new MemoryDataStore();
            AzureSession.DataStore = datastore;
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = profile;
            AzureSession.DataStore = datastore;
            ProfileClient = new ProfileClient(profile);

            // Ignore SSL errors
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;

            // Set RunningMocked
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Playback)
            {
                TestMockSupport.RunningMocked = true;
            }
            else
            {
                TestMockSupport.RunningMocked = false;
            }
        }

        /// <summary>
        /// Loads DummyManagementClientHelper with clients and throws exception if any client is missing.
        /// </summary>
        /// <param name="initializedManagementClients"></param>
        public void SetupManagementClients(params object[] initializedManagementClients)
        {
            AzureSession.ClientFactory = new MockClientFactory(initializedManagementClients);
        }

        /// <summary>
        /// Loads DummyManagementClientHelper with clients and sets it up to create missing clients dynamically.
        /// </summary>
        /// <param name="initializedManagementClients"></param>
        public void SetupSomeOfManagementClients(params object[] initializedManagementClients)
        {
            AzureSession.ClientFactory = new MockClientFactory(initializedManagementClients, false);
        }

        public void SetupEnvironment(AzureModule mode)
        {
            SetupAzureEnvironmentFromEnvironmentVariables(mode);

            ProfileClient.Profile.Save();
        }

        private void SetupAzureEnvironmentFromEnvironmentVariables(AzureModule mode)
        {
            TestEnvironment rdfeEnvironment = new RDFETestEnvironmentFactory().GetTestEnvironment();
            TestEnvironment csmEnvironment = new CSMTestEnvironmentFactory().GetTestEnvironment();
            TestEnvironment currentEnvironment = (mode == AzureModule.AzureResourceManager ? csmEnvironment : rdfeEnvironment);

            if (currentEnvironment.UserName == null)
            {
                currentEnvironment.UserName = "fakeuser@microsoft.com";
            }

            SetAuthenticationFactory(mode, rdfeEnvironment, csmEnvironment);

            AzureEnvironment environment = new AzureEnvironment { Name = testEnvironmentName };

            Debug.Assert(currentEnvironment != null);
            environment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectory] = currentEnvironment.Endpoints.AADAuthUri.AbsoluteUri;
            environment.Endpoints[AzureEnvironment.Endpoint.Gallery] = currentEnvironment.Endpoints.GalleryUri.AbsoluteUri;

            if (csmEnvironment != null)
            {
                environment.Endpoints[AzureEnvironment.Endpoint.ResourceManager] = csmEnvironment.BaseUri.AbsoluteUri;
            }

            if (rdfeEnvironment != null)
            {
                environment.Endpoints[AzureEnvironment.Endpoint.ServiceManagement] = rdfeEnvironment.BaseUri.AbsoluteUri;
            }

            if (!ProfileClient.Profile.Environments.ContainsKey(testEnvironmentName))
            {
                ProfileClient.AddOrSetEnvironment(environment);
            }

            if (currentEnvironment.SubscriptionId != null)
            {
                testSubscription = new AzureSubscription()
                {
                    Id = new Guid(currentEnvironment.SubscriptionId),
                    Name = testSubscriptionName,
                    Environment = testEnvironmentName,
                    Account = currentEnvironment.UserName,
                    Properties = new Dictionary<AzureSubscription.Property, string>
                    {
                        {AzureSubscription.Property.Default, "True"},
                        {
                            AzureSubscription.Property.StorageAccount,
                            Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT")
                        },
                    }
                };

                testAccount = new AzureAccount()
                {
                    Id = currentEnvironment.UserName,
                    Type = AzureAccount.AccountType.User,
                    Properties = new Dictionary<AzureAccount.Property, string>
                    {
                        {AzureAccount.Property.Subscriptions, currentEnvironment.SubscriptionId},
                    }
                };

                ProfileClient.Profile.Subscriptions[testSubscription.Id] = testSubscription;
                ProfileClient.Profile.Accounts[testAccount.Id] = testAccount;
                ProfileClient.SetSubscriptionAsDefault(testSubscription.Name, testSubscription.Account);
            }
        }

        private void SetAuthenticationFactory(TestEnvironment environment)
        {
            if (environment.AuthorizationContext.Certificate != null)
            {
                AzureSession.AuthenticationFactory = new MockCertificateAuthenticationFactory(environment.UserName,
                    environment.AuthorizationContext.Certificate);
            }
            else if (environment.AuthorizationContext.TokenCredentials.ContainsKey(TokenAudience.Management))
            {
                var httpMessage = new HttpRequestMessage();
                environment.AuthorizationContext.TokenCredentials[TokenAudience.Management]
                    .ProcessHttpRequestAsync(httpMessage, CancellationToken.None)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory(
                    environment.UserName,
                    httpMessage.Headers.Authorization.Parameter);
            }
        }

        private void SetAuthenticationFactory(AzureModule mode, TestEnvironment rdfeEnvironment, TestEnvironment csmEnvironment)
        {
            if (mode == AzureModule.AzureServiceManagement)
            {
                SetAuthenticationFactory(rdfeEnvironment);
            }
            else
            {
                SetAuthenticationFactory(csmEnvironment);
            }
        }

        public void SetupModules(AzureModule mode, params string[] modules)
        {
            this.modules = new List<string>();
            if (mode == AzureModule.AzureProfile)
            {
                this.modules.Add(Path.Combine(PackageDirectory, @"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Tags.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"Storage\Azure.Storage\Azure.Storage.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"ServiceManagement\Azure\Azure.psd1"));
            }
            else if (mode == AzureModule.AzureServiceManagement)
            {
                this.modules.Add(Path.Combine(PackageDirectory, @"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"Storage\Azure.Storage\Azure.Storage.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"ServiceManagement\Azure\Azure.psd1"));
            }
            else if (mode == AzureModule.AzureResourceManager)
            {
                this.modules.Add(Path.Combine(PackageDirectory, @"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Tags.psd1"));
            }
            else
            {
                throw new ArgumentException("Unknown command type for testing");
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
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Tags.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"Storage\Azure.Storage\Azure.Storage.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ServiceManagement\Azure\Azure.psd1"));
            }
            else if (mode == AzureModule.AzureServiceManagement)
            {
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Tags.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"Storage\Azure.Storage\Azure.Storage.psd1"));
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
            using (var powershell = System.Management.Automation.PowerShell.Create(RunspaceMode.NewRunspace))
            {
                return ExecuteShellTest(powershell, null, scripts);
            }
        }
        public virtual Collection<PSObject> RunPowerShellTest(IEnumerable<string> setupScripts, IEnumerable<string> scripts)
        {
            using (var powershell = System.Management.Automation.PowerShell.Create(RunspaceMode.NewRunspace))
            {
                return ExecuteShellTest(powershell, setupScripts, scripts);
            }
        }

        private Collection<PSObject> ExecuteShellTest(
            System.Management.Automation.PowerShell powershell,
            IEnumerable<string> setupScripts,
            IEnumerable<string> scripts)
        {
            SetupPowerShellModules(powershell, setupScripts);

            Collection<PSObject> output = null;

            foreach (var script in scripts)
            {
                if (TracingInterceptor != null)
                {
                    TracingInterceptor.Information(script);
                }
                powershell.AddScript(script);
            }
            try
            {
                powershell.Runspace.Events.Subscribers.Clear();
                powershell.Streams.Error.Clear();
                output = powershell.Invoke();

                if (powershell.Streams.Error.Count > 0)
                {
                    var sb = new StringBuilder();

                    sb.AppendLine("Test failed due to a non-empty error stream, check the error stream in the test log for more details.");
                    sb.AppendLine(string.Format("{0} total Errors", powershell.Streams.Error.Count));
                    foreach (var error in powershell.Streams.Error)
                    {
                        sb.AppendLine(error.Exception.ToString());
                    }

                    throw new RuntimeException(sb.ToString());
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

        private void SetupPowerShellModules(System.Management.Automation.PowerShell powershell, IEnumerable<string> setupScripts)
        {
            powershell.AddScript("$error.clear()");
            powershell.AddScript(string.Format("cd \"{0}\"", AppDomain.CurrentDomain.BaseDirectory));
            if (setupScripts != null)
            {
                foreach(var script in setupScripts)
                {
                    powershell.AddScript(script);
                }
            }

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
