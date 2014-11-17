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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Utilities.HttpRecorder;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Testing;
using System.Diagnostics;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    public class EnvironmentSetupHelper
    {
        private static string testEnvironmentName = "__test-environment";
        private static string testSubscriptionName = "__test-subscriptions";
        private AzureSubscription testSubscription;
        private AzureAccount testAccount;
        protected List<string> modules;
        private ProfileClient client;

        public EnvironmentSetupHelper()
        {
            ProfileClient.DataStore = new MockDataStore();
            client = new ProfileClient();

            // Ignore SSL errors
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;
            // Set RunningMocked
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Playback)
            {
                TestMockSupport.RunningMocked = true;
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

            client.Profile.Save();
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

            if (!client.Profile.Environments.ContainsKey(testEnvironmentName))
            {
                client.AddOrSetEnvironment(environment);
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

                client.Profile.Subscriptions[testSubscription.Id] = testSubscription;
                client.Profile.Accounts[testAccount.Id] = testAccount;
                client.SetSubscriptionAsCurrent(testSubscription.Name, testSubscription.Account);
            }
        }

        private void SetAuthenticationFactory(AzureModule mode, TestEnvironment rdfeEnvironment, TestEnvironment csmEnvironment)
        {
            string jwtToken = null;
            X509Certificate2 certificate = null;
            TestEnvironment currentEnvironment = (mode == AzureModule.AzureResourceManager ? csmEnvironment : rdfeEnvironment);

            if (mode == AzureModule.AzureServiceManagement)
            {
                if (rdfeEnvironment.Credentials is TokenCloudCredentials)
                {
                    jwtToken = ((TokenCloudCredentials)rdfeEnvironment.Credentials).Token;
                }
                if (rdfeEnvironment.Credentials is CertificateCloudCredentials)
                {
                    certificate = ((CertificateCloudCredentials)rdfeEnvironment.Credentials).ManagementCertificate;
                }
            }
            else
            {
                if (csmEnvironment.Credentials is TokenCloudCredentials)
                {
                    jwtToken = ((TokenCloudCredentials)csmEnvironment.Credentials).Token;
                }
                if (csmEnvironment.Credentials is CertificateCloudCredentials)
                {
                    certificate = ((CertificateCloudCredentials)csmEnvironment.Credentials).ManagementCertificate;
                }
            }


            if (jwtToken != null)
            {
                AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory(currentEnvironment.UserName,
                    jwtToken);
            }
            else if (certificate != null)
            {
                AzureSession.AuthenticationFactory = new MockCertificateAuthenticationFactory(currentEnvironment.UserName,
                    certificate);
            }
        }

        public void SetupModules(AzureModule mode, params string[] modules)
        {
            this.modules = new List<string>();
            if (mode == AzureModule.AzureProfile)
            {
                this.modules.Add(@"ServiceManagement\Azure\Azure.psd1");
                this.modules.Add(@"ResourceManager\AzureResourceManager\AzureResourceManager.psd1");
            }
            else if (mode == AzureModule.AzureServiceManagement)
            {
                this.modules.Add(@"ServiceManagement\Azure\Azure.psd1");
            }
            else if (mode == AzureModule.AzureResourceManager)
            {
                this.modules.Add(@"ResourceManager\AzureResourceManager\AzureResourceManager.psd1");
            }
            else
            {
                throw new ArgumentException("Unknown command type for testing");
            }
            this.modules.Add("Assert.ps1");
            this.modules.Add("Common.ps1");
            this.modules.AddRange(modules);
        }

        public virtual Collection<PSObject> RunPowerShellTest(params string[] scripts)
        {
            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                SetupPowerShellModules(powershell);

                Collection<PSObject> output = null;
                for (int i = 0; i < scripts.Length; ++i)
                {
                    Console.WriteLine(scripts[i]);
                    powershell.AddScript(scripts[i]);
                }
                try
                {
                    output = powershell.Invoke();

                    if (powershell.Streams.Error.Count > 0)
                    {
                        throw new RuntimeException(
                            "Test failed due to a non-empty error stream, check the error stream in the test log for more details.");
                    }

                    return output;
                }
                catch (Exception psException)
                {
                    powershell.LogPowerShellException(psException);
                    throw;
                }
                finally
                {
                    powershell.LogPowerShellResults(output);
                }
            }
        }

        private void SetupPowerShellModules(System.Management.Automation.PowerShell powershell)
        {
            powershell.AddScript(string.Format("cd \"{0}\"", Environment.CurrentDirectory));

            foreach (string moduleName in modules)
            {
                powershell.AddScript(string.Format("Import-Module \".\\{0}\"", moduleName));
            }

            powershell.AddScript("$VerbosePreference='Continue'");
            powershell.AddScript("$DebugPreference='Continue'");
            powershell.AddScript("$ErrorActionPreference='Stop'");
            powershell.AddScript("Write-Debug \"AZURE_TEST_MODE = $env:AZURE_TEST_MODE\"");
            powershell.AddScript("Write-Debug \"TEST_HTTPMOCK_OUTPUT = $env:TEST_HTTPMOCK_OUTPUT\"");
        }
    }
}
