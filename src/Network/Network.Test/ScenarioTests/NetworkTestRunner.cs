using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.Internal.Common;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.PrivateDns;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Network.Test.ScenarioTests
{
    public class NetworkTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected NetworkTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance (output)
                .WithNewPsScriptFilename ($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests ("ScenarioTests")
                .WithCommonPsScripts (new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Resources.ps1",
                })
                .WithNewRmModules (helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("AzureRM.Monitor.psd1"),
                    helper.GetRMModulePath("AzureRM.Network.psd1"),
                    helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    helper.GetRMModulePath("AzureRM.Storage.psd1"),
                    helper.GetRMModulePath("AzureRM.Sql.psd1"),
                    helper.GetRMModulePath("AzureRM.ContainerInstance.psd1"),
                    helper.GetRMModulePath("AzureRM.OperationalInsights.psd1"),
                    helper.GetRMModulePath("AzureRM.KeyVault.psd1"),
                    helper.GetRMModulePath("AzureRM.ManagedServiceIdentity.psd1"),
                    helper.GetRMModulePath("AzureRM.PrivateDns.psd1"),
                })
                .WithNewRecordMatcherArguments (
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Compute", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Network", null},
                        {"Microsoft.Storage", null},
                        {"Microsoft.Sql", null},
                        {"Microsoft.KeyVault", null},
                        {"Microsoft.ManagedServiceIdentity", null},
                        {"Microsoft.PrivateDns", null},
                    }
                ).WithManagementClients(
                    GetResourceManagementClient,
                    GetManagedServiceIdentityClient,
                    GetKeyVaultManagementClient,
                    GetNetworkManagementClient,
                    GetComputeManagementClient,
                    GetStorageManagementClient,
                    GetKeyVaultClient,
                    GetAzureRestClient,
                    GetPrivateDnsManagementClient
                )
                .Build();
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ManagedServiceIdentityClient GetManagedServiceIdentityClient(MockContext context)
        {
            return context.GetServiceClient<ManagedServiceIdentityClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static KeyVaultManagementClient GetKeyVaultManagementClient(MockContext context)
        {
            return context.GetServiceClient<KeyVaultManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ComputeManagementClient GetComputeManagementClient(MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static AzureRestClient GetAzureRestClient(MockContext context)
        {
            return context.GetServiceClient<AzureRestClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static PrivateDnsManagementClient GetPrivateDnsManagementClient(MockContext context)
        {
            return context.GetServiceClient<PrivateDnsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static KeyVaultClient GetKeyVaultClient(MockContext context)
        {
            string environmentConnectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            string accessToken = "fakefakefake";

            // When recording, we should have a connection string passed into the code from the environment
            if (!string.IsNullOrEmpty(environmentConnectionString))
            {
                // Gather test client credential information from the environment
                var connectionInfo = new ConnectionString(Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION"));
                var mode = connectionInfo.GetValue<string>(ConnectionStringKeys.HttpRecorderModeKey);
                if (mode == HttpRecorderMode.Record.ToString())
                {
                    string servicePrincipal = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalKey);
                    string servicePrincipalSecret = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalSecretKey);
                    string aadTenant = connectionInfo.GetValue<string>(ConnectionStringKeys.AADTenantKey);

                    // Create credentials
                    var clientCredentials = new ClientCredential(servicePrincipal, servicePrincipalSecret);
                    var authContext = new AuthenticationContext($"https://login.windows.net/{aadTenant}", TokenCache.DefaultShared);
                    accessToken = authContext.AcquireTokenAsync("https://vault.azure.net", clientCredentials).Result.AccessToken;
                }
            }

            return new KeyVaultClient(new TokenCredentials(accessToken), HttpMockServer.CreateInstance());
        }
    }
}
