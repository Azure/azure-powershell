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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.Common;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Commands.TestFx
{
    public class EnvironmentSetupHelper
    {
        private const string TestEnvironmentName = "__test-environment";

        private const string TestSubscriptionName = "__test-subscriptions";

        private static string PackageDirectoryFromCommon { get; } = GetConfigDirectory();

        public static string PackageDirectory { get; }  = GetConfigDirectory();

        public static string StackDirectory { get; }  = GetConfigDirectory("Stack");

        public static string RmDirectory { get; }  = GetRMModuleDirectory();

        public static string StackRmDirectory { get; }  = GetRMModuleDirectory("Stack");

        public static string StorageDirectory { get; } = GetStorageDirectory();

        public static string StackStorageDirectory { get; } = GetStorageDirectory("Stack");

        protected List<string> modules;

        public XunitTracingInterceptor TracingInterceptor { get; set; }

        public EnvironmentSetupHelper()
        {
            var module = GetModuleManifest(RmDirectory, "Az.Accounts");
            if (string.IsNullOrWhiteSpace(module))
            {
                throw new InvalidOperationException("Could not find Accounts module");
            }

            LogIfNotNull($"Accounts Module path: {module}");
            RMProfileModule = module;
            module = GetModuleManifest(RmDirectory, "Az.Resources");
            LogIfNotNull($"Resources Module path: {module}");
            RMResourceModule = module;
            module = GetModuleManifest(RmDirectory, "Az.Insights");
            LogIfNotNull($"Insights Module path: {module}");
            RMInsightsModule = module;
            module = GetModuleManifest(RmDirectory, "Az.Storage");
            LogIfNotNull($"Storage Management Module path: {module}");
            RMStorageModule = module;
            module = GetModuleManifest(StorageDirectory, "Azure.Storage");
            LogIfNotNull($"Storage Data Plane Module path: {module}");
            RMStorageDataPlaneModule = module;
            module = GetModuleManifest(RmDirectory, "Az.OperationalInsights");
            LogIfNotNull($"Storage Data Plane Module path: {module}");
            RMOperationalInsightsModule = module;
            module = GetModuleManifest(RmDirectory, "Az.Network");
            LogIfNotNull($"Network Module path: {module}");
            RMNetworkModule = module;
            module = GetModuleManifest(RmDirectory, "Az.EventHub");
            LogIfNotNull($"EventHub Module path: {module}");
            RMEventHubModule = module;
            module = GetModuleManifest(RmDirectory, "Az.Monitor");
            LogIfNotNull($"Monitor Module path: {module}");
            RMMonitorModule = module;
            module = GetModuleManifest(StackRmDirectory, "Az.Accounts");
            LogIfNotNull($"Stack Accounts Module path: {module}");
            StackRMProfileModule = module;
            module = GetModuleManifest(StackRmDirectory, "Az.Resources");
            LogIfNotNull($"Stack Resources Module path: {module}");
            StackRMResourceModule = module;
            module = GetModuleManifest(StackRmDirectory, "Az.Storage");
            LogIfNotNull($"Stack Storage Management Plane Module path: {module}");
            StackRMStorageModule = module;
            module = GetModuleManifest(StackStorageDirectory, "Azure.Storage");
            LogIfNotNull($"Stack Storage Data Plane Module path: {module}");
            StackRMStorageDataPlaneModule = module;
            module = GetModuleManifest(RmDirectory, "Az.KeyVault");
            LogIfNotNull($"KeyVault Module path: {module}");
            RMKeyVaultModule = module;

            TestExecutionHelpers.SetUpSessionAndProfile();
            IDataStore datastore = new MemoryDataStore();
            if (AzureSession.Instance.DataStore != null && (AzureSession.Instance.DataStore is MemoryDataStore))
            {
                datastore = AzureSession.Instance.DataStore;
            }

            AzureSession.Instance.DataStore = datastore;
            var rmprofile = new AzureRmProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            rmprofile.EnvironmentTable.Add("foo", new AzureEnvironment(AzureEnvironment.PublicEnvironments.Values.FirstOrDefault()));
            rmprofile.DefaultContext = new AzureContext(new AzureSubscription(), new AzureAccount(), rmprofile.EnvironmentTable["foo"], new AzureTenant());
            rmprofile.DefaultContext.Subscription.SetEnvironment("foo");
            if (AzureRmProfileProvider.Instance.Profile == null)
            {
                AzureRmProfileProvider.Instance.Profile = rmprofile;
            }

            AzureSession.Instance.DataStore = datastore;

            // Ignore SSL errors
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;

            // Set RunningMocked
            TestMockSupport.RunningMocked = HttpMockServer.GetCurrentMode() == HttpRecorderMode.Playback;

            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), Resources.AzureDirectoryName, "testcredentials.json")))
            {
                SetEnvironmentVariableFromCredentialFile();
            }
        }

        public string RMProfileModule { get; private set; }

        public string RMResourceModule { get; private set; }

        public string RMInsightsModule { get; private set; }

        public string RMStorageModule { get; private set; }

        public string RMOperationalInsightsModule { get; private set; }

        public string RMEventHubModule { get; private set; }

        public string RMMonitorModule { get; private set; }

        public string RMStorageDataPlaneModule { get; private set; }

        public string RMNetworkModule { get; private set; }

        public string StackRMProfileModule { get; private set; }

        public string StackRMResourceModule { get; private set; }

        public string StackRMStorageModule { get; private set; }

        public string StackRMStorageDataPlaneModule { get; private set; }

        public string RMKeyVaultModule { get; private set; }

        private void LogIfNotNull(string message)
        {
            if (TracingInterceptor != null)
            {
                TracingInterceptor.Information($"[EnvironmentSetupHelper]: {message}");
            }
        }

        private static string ProbeForSrcDirectory()
        {
            string directoryPath = "..";
            while(Directory.Exists(directoryPath) && !Directory.Exists(Path.Combine(directoryPath, "src")))
            {
                directoryPath = Path.Combine(directoryPath, "..");
            }

            string result = Directory.Exists(directoryPath) ? Path.GetFullPath(Path.Combine(directoryPath, "src")) : null;
            return result;
        }

        private static string GetConfigDirectory(string targetDirectory = "artifacts")
        {
            string result = null;
            var directoryPath = Path.Combine(ProbeForSrcDirectory(), "..");
            if (Directory.Exists(directoryPath))
            {
                var baseDirectory = Path.Combine(directoryPath, targetDirectory);
                if (Directory.Exists(baseDirectory))
                {
                    result = Directory.EnumerateDirectories(baseDirectory).FirstOrDefault(
                        (dir) => ! string.IsNullOrWhiteSpace(dir)
                        && (dir.EndsWith("Debug", StringComparison.OrdinalIgnoreCase)
                        || dir.EndsWith("Release", StringComparison.OrdinalIgnoreCase)));
                    if (result != null)
                    {
                        result = Path.GetFullPath(result);
                    }
                }
            }

            return result;
        }

        private static string GetRMModuleDirectory(string targetDirectory = "artifacts")
        {
            string configDirectory = GetConfigDirectory(targetDirectory);
            return (string.IsNullOrEmpty(configDirectory)) ? null : configDirectory;
        }

        private static string GetStorageDirectory(string targetDirectory = "artifacts")
        {
            string configDirectory = GetConfigDirectory(targetDirectory);
            return (string.IsNullOrEmpty(configDirectory)) ? null : Path.Combine(configDirectory, "Storage");
        }

        private static string GetModuleManifest(string baseDirectory, string desktopModuleName)
        {
            if (string.IsNullOrWhiteSpace(baseDirectory) || string.IsNullOrWhiteSpace(desktopModuleName))
            {
                return null;
            }

            return Path.Combine(baseDirectory, desktopModuleName.Replace("AzureRM", "Az"), $"{desktopModuleName.Replace("AzureRM", "Az")}.psd1");
        }

        /// <summary>
        /// For backwards compatibility - return the path to an RM module manifest
        /// </summary>
        /// <param name="moduleName">The name of the module</param>
        /// <returns>The path to the module directory</returns>
        public string GetRMModulePath(string moduleName)
        {
            if (string.IsNullOrWhiteSpace(RmDirectory))
            {
                throw new InvalidOperationException("No ResourceManager Modules Directory found in build. Please build the modules before running tests.");
            }

            if (string.IsNullOrWhiteSpace(moduleName))
            {
                throw new ArgumentNullException(nameof(moduleName));
            }

            var moduleDirectory = moduleName.Replace(".psd1", "");
            return GetModuleManifest(RmDirectory, moduleDirectory);
        }

        /// <summary>
        /// For backwards compatibility - return the path to an RM module manifest for AzureStack
        /// </summary>
        /// <param name="moduleName">The name of the module</param>
        /// <returns>The path to the module directory</returns>
        public string GetStackRMModulePath(string moduleName)
        {
            if (string.IsNullOrWhiteSpace(StackRmDirectory))
            {
                throw new InvalidOperationException("No ResourceManager Modules Directory for Azure Stack found in build. Please build the modules before running tests.");
            }

            if (string.IsNullOrWhiteSpace(moduleName))
            {
                throw new ArgumentNullException(nameof(moduleName));
            }

            var moduleDirectory = moduleName.Replace(".psd1", "");
            return GetModuleManifest(StackRmDirectory, moduleDirectory);
        }

        public void SetupManagementClients(MockContext context, params object[] initializedManagementClients)
        {
            AzureSession.Instance.ClientFactory = new MockClientFactory(context, initializedManagementClients);
        }

        public void SetupSomeOfManagementClients(MockContext context, params object[] initializedManagementClients)
        {
            AzureSession.Instance.ClientFactory = new MockClientFactory(context, initializedManagementClients);
        }

        public void SetupEnvironment(AzureModule mode)
        {
            SetupAzureEnvironmentFromEnvironmentVariables(mode);
        }

        public void SetEnvironmentVariableFromCredentialFile()
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), Resources.AzureDirectoryName, "testcredentials.json");
            Dictionary<string, object> testSettings;
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                testSettings = JsonUtilities.DeserializeJson(json);
            }

            StringBuilder formattedConnectionString = new StringBuilder();
            formattedConnectionString.Append($"Environment={testSettings["Environment"]};SubscriptionId={testSettings["SubscriptionId"]};TenantId={testSettings["TenantId"]};HttpRecorderMode={testSettings["HttpRecorderMode"]};");

            if (testSettings.ContainsKey("UserId"))
            {
                formattedConnectionString.Append($"UserId={testSettings["UserId"]};");
            }

            if (testSettings.ContainsKey("ServicePrincipal"))
            {
                formattedConnectionString.Append($"ServicePrincipal={testSettings["ServicePrincipal"]};");
                formattedConnectionString.Append($"ServicePrincipalSecret={testSettings["ServicePrincipalSecret"]};");
            }

            if (testSettings.ContainsKey("ResourceManagementUri"))
            {
                formattedConnectionString.Append($"ResourceManagementUri={testSettings["ResourceManagementUri"]};");
            }

            if (testSettings.ContainsKey("ServiceManagementUri"))
            {
                formattedConnectionString.Append($"ServiceManagementUri={testSettings["ServiceManagementUri"]};");
            }

            if (testSettings.ContainsKey("AADAuthUri"))
            {
                formattedConnectionString.Append($"AADAuthUri={testSettings["AADAuthUri"]};");
            }

            if (testSettings.ContainsKey("GraphUri"))
            {
                formattedConnectionString.Append($"GraphUri={testSettings["GraphUri"]};");
            }

            if (testSettings.ContainsKey("AADTokenAudienceUri"))
            {
                formattedConnectionString.Append($"AADTokenAudienceUri={testSettings["AADTokenAudienceUri"]};");
            }

            if (testSettings.ContainsKey($"GraphTokenAudienceUri"))
            {
                formattedConnectionString.Append($"GraphTokenAudienceUri={testSettings["GraphTokenAudienceUri"]};");
            }

            if (testSettings.ContainsKey("IbizaPortalUri"))
            {
                formattedConnectionString.Append($"IbizaPortalUri={testSettings["IbizaPortalUri"]};");
            }

            if (testSettings.ContainsKey("RdfePortalUri"))
            {
                formattedConnectionString.Append($"RdfePortalUri={testSettings["RdfePortalUri"]};");
            }

            if (testSettings.ContainsKey("GalleryUri"))
            {
                formattedConnectionString.Append($"GalleryUri={testSettings["GalleryUri"]};");
            }

            if (testSettings.ContainsKey("DataLakeStoreServiceUri"))
            {
                formattedConnectionString.Append($"DataLakeStoreServiceUri={testSettings["DataLakeStoreServiceUri"]};");
            }

            if (testSettings.ContainsKey("DataLakeAnalyticsJobAndCatalogServiceUri"))
            {
                formattedConnectionString.Append($"DataLakeAnalyticsJobAndCatalogServiceUri={testSettings["DataLakeAnalyticsJobAndCatalogServiceUri"]};");
            }

            Environment.SetEnvironmentVariable(ConnectionStringKeys.TestCSMOrgIdConnectionStringKey, formattedConnectionString.ToString());
            Environment.SetEnvironmentVariable(ConnectionStringKeys.AZURE_TEST_MODE_ENVKEY, testSettings["HttpRecorderMode"].ToString());
        }

        public void SetupAzureEnvironmentFromEnvironmentVariables(AzureModule mode)
        {
            TestEnvironment currentEnvironment;
            if (mode == AzureModule.AzureResourceManager)
            {
                currentEnvironment = TestEnvironmentFactory.BuildTestFxEnvironment();
            }
            else
            {
                throw new NotSupportedException("RDFE environment is not supported in .Net Core");
            }

            if (currentEnvironment.UserName == null)
            {
                currentEnvironment.UserName = "fakeuser@microsoft.com";
            }

            SetAuthenticationFactory(currentEnvironment);
            AzureEnvironment environment = new AzureEnvironment { Name = TestEnvironmentName };
            Debug.Assert(currentEnvironment != null);
            environment.ActiveDirectoryAuthority = currentEnvironment.Endpoints.AADAuthUri.AbsoluteUri;
            environment.GalleryUrl = currentEnvironment.Endpoints.GalleryUri?.AbsoluteUri;
            environment.ServiceManagementUrl = currentEnvironment.BaseUri.AbsoluteUri;
            environment.ResourceManagerUrl = currentEnvironment.Endpoints.ResourceManagementUri.AbsoluteUri;
            environment.GraphUrl = currentEnvironment.Endpoints.GraphUri.AbsoluteUri;
            environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = currentEnvironment.Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://", ""); // because it is just a sufix
            environment.AzureDataLakeStoreFileSystemEndpointSuffix = currentEnvironment.Endpoints.DataLakeStoreServiceUri.OriginalString.Replace("https://", ""); // because it is just a sufix
            environment.StorageEndpointSuffix = AzureEnvironmentConstants.AzureStorageEndpointSuffix;
            environment.AzureKeyVaultDnsSuffix = AzureEnvironmentConstants.AzureKeyVaultDnsSuffix;
            environment.AzureKeyVaultServiceEndpointResourceId = AzureEnvironmentConstants.AzureKeyVaultServiceEndpointResourceId;
            environment.ExtendedProperties.SetProperty(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpoint, "https://api.loganalytics.io/v1");
            environment.ExtendedProperties.SetProperty(AzureEnvironment.ExtendedEndpoint.OperationalInsightsEndpointResourceId, "https://api.loganalytics.io");
            if (!AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>().EnvironmentTable.ContainsKey(TestEnvironmentName))
            {
                AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>().EnvironmentTable[TestEnvironmentName] = environment;
            }

            if (currentEnvironment.SubscriptionId != null)
            {
                var testSubscription = new AzureSubscription
                {
                    Id = currentEnvironment.SubscriptionId,
                    Name = TestSubscriptionName,
                };

                testSubscription.SetEnvironment(TestEnvironmentName);
                testSubscription.SetAccount(currentEnvironment.UserName);
                testSubscription.SetDefault();
                testSubscription.SetStorageAccount(Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT"));

                var testAccount = new AzureAccount()
                {
                    Id = currentEnvironment.UserName,
                    Type = AzureAccount.AccountType.User,
                };

                testAccount.SetSubscriptions(currentEnvironment.SubscriptionId);
                var testTenant = new AzureTenant() { Id = Guid.NewGuid().ToString() };
                if (!string.IsNullOrEmpty(currentEnvironment.TenantId))
                {
                    if (Guid.TryParse(currentEnvironment.TenantId, out _))
                    {
                        testTenant.Id = currentEnvironment.TenantId;
                    }
                }
                AzureRmProfileProvider.Instance.Profile.DefaultContext = new AzureContext(testSubscription, testAccount, environment, testTenant);
            }
        }

        private void SetAuthenticationFactory(TestEnvironment environment)
        {
            if (environment.TokenInfo.ContainsKey(TokenAudience.Management))
            {
                var httpMessage = new HttpRequestMessage();
                environment.TokenInfo[TokenAudience.Management]
                    .ProcessHttpRequestAsync(httpMessage, CancellationToken.None)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory(environment.UserName, httpMessage.Headers.Authorization.Parameter);
            }
        }

        public void SetupModules(AzureModule mode, params string[] modules)
        {
            this.modules = new List<string>();
            if (mode == AzureModule.AzureProfile)
            {
                this.modules.Add(Path.Combine(PackageDirectory, @"ServiceManagement\Azure\Azure.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"AzureRM.Accounts\AzureRM.Accounts.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"AzureRM.Resources\AzureRM.Resources.psd1"));
                this.modules.Add(Path.Combine(PackageDirectory, @"AzureRM.Resources\AzureRM.Tags.psd1"));
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
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"AzureRM.Accounts\AzureRM.Accounts.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"AzureRM.Resources\AzureRM.Resources.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"AzureRM.Resources\AzureRM.Tags.psd1"));
            }
            else if (mode == AzureModule.AzureServiceManagement)
            {
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"ServiceManagement\Azure\Azure.psd1"));
            }
            else if (mode == AzureModule.AzureResourceManager)
            {
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"AzureRM.Accounts\AzureRM.Accounts.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"AzureRM.Resources\AzureRM.Resources.psd1"));
                this.modules.Add(Path.Combine(PackageDirectoryFromCommon, @"AzureRM.Resources\AzureRM.Tags.psd1"));
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
            this.modules = new List<string> {"Assert.ps1", "Common.ps1"};
            this.modules.AddRange(modules);
        }

        public virtual Collection<PSObject> RunPowerShellTest(params string[] scripts)
        {
            using var powershell = System.Management.Automation.PowerShell.Create(RunspaceMode.NewRunspace);
            SetupPowerShellModules(powershell);

            Collection<PSObject> output = null;
            foreach (var script in scripts)
            {
                TracingInterceptor?.Information(script);
                powershell.AddScript(script);
            }
            try
            {
                output = powershell.Invoke();
                if (powershell.Streams.Error.Count > 0)
                {
                    throw new RuntimeException($"Test failed due to a non-empty error stream. First error: {PowerShellExtensions.FormatErrorRecord(powershell.Streams.Error[0])}{(powershell.Streams.Error.Count > 0 ? "Check the error stream in the test log for additional errors." : "")}");
                }

                return output;
            }
            catch (Exception psException)
            {
                powershell.LogPowerShellException(psException, TracingInterceptor);
                powershell.LogPowerShellResults(output, TracingInterceptor);
                TracingInterceptor?.Flush();
                throw;
            }
            finally
            {
                powershell.Streams.Error.Clear();
            }
        }

        private void SetupPowerShellModules(System.Management.Automation.PowerShell powershell)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                powershell.AddScript("Set-ExecutionPolicy Unrestricted -Scope Process -ErrorAction Ignore");
            }
            powershell.AddScript("$Error.clear()");
            powershell.AddScript($"Write-Debug \"current directory: {AppDomain.CurrentDomain.BaseDirectory}\"");
            powershell.AddScript($"Write-Debug \"current executing assembly: {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\"");
            powershell.AddScript($"cd \"{AppDomain.CurrentDomain.BaseDirectory}\"");

            foreach (var moduleName in modules)
            {
                powershell.AddScript($"Import-Module \"{moduleName.AsAbsoluteLocation()}\"");
                if (moduleName.EndsWith(".psd1"))
                {
                    var moduleShortName = moduleName.Split(new string[] { @"\" }, StringSplitOptions.None).Last().Split(new string[] { @"/" }, StringSplitOptions.None).Last();
                    powershell.AddScript("Enable-AzureRmAlias -Module " + moduleShortName[..^5]);
                    if (moduleShortName.Equals("Az.Storage.psd1") && modules.Any(s => s.EndsWith("AzureRM.Storage.ps1")))
                    {
                        powershell.AddScript("Get-Alias | Where-Object {$_.Name -like '*-AzureRmStorage*'} | ForEach-Object { Remove-Item \"alias:\\$_\" }");
                    }
                }
            }

            powershell.AddScript("Disable-AzDataCollection -ErrorAction Ignore");
            powershell.AddScript($"Set-Location \"{AppDomain.CurrentDomain.BaseDirectory}\"");
            powershell.AddScript($"$TestOutputRoot='{AppDomain.CurrentDomain.BaseDirectory}'");
            powershell.AddScript("$VerbosePreference='Continue'");
            powershell.AddScript("$DebugPreference='Continue'");
            powershell.AddScript("$ErrorActionPreference='Stop'");
            powershell.AddScript("Write-Debug \"AZURE_TEST_MODE = $env:AZURE_TEST_MODE\"");
        }
    }
}
