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

using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
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
                    helper.GetRMModulePath("Az.Monitor.psd1"),
                    helper.GetRMModulePath("Az.Network.psd1"),
                    helper.GetRMModulePath("Az.Compute.psd1"),
                    helper.GetRMModulePath("Az.Storage.psd1"),
                    helper.GetRMModulePath("Az.Sql.psd1"),
                    helper.GetRMModulePath("Az.OperationalInsights.psd1"),
                    helper.GetRMModulePath("Az.KeyVault.psd1"),
                    helper.GetRMModulePath("Az.ManagedServiceIdentity.psd1"),
                    helper.GetRMModulePath("Az.PrivateDns.psd1"),
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
                    GetKeyVaultClient
                )
                .Build();
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
                    string aadTenant = connectionInfo.GetValue<string>(ConnectionStringKeys.TenantIdKey);

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
