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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System.Reflection;
using System.IO;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ContainerService;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Commands.Aks.Test.ScenarioTests
{
    public class AksTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected AksTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance (output)
                .WithNewPsScriptFilename ($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests ("ScenarioTests")
                .WithCommonPsScripts (new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules (helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Aks.psd1")
                })
                .WithNewRecordMatcherArguments (
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2017-05-10"},
                        {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null}
                    }
                ).WithMockContextAction(() =>
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Playback)
                    {
                        AzureSession.Instance.DataStore = new MemoryDataStore();
                        var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        var dir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
                        var subscription = HttpMockServer.Variables["SubscriptionId"];
                        AzureSession.Instance.DataStore.WriteFile(Path.Combine(home, ".ssh", "id_rsa.pub"), File.ReadAllText(dir + "/Fixtures/id_rsa.pub"));
                        var jsonOutput = @"{""" + subscription + @""":{ ""service_principal"":""foo"",""client_secret"":""bar""}}";
                        AzureSession.Instance.DataStore.WriteFile(Path.Combine(home, ".azure", "acsServicePrincipal.json"), jsonOutput);
                    }
                    else if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        AzureSession.Instance.DataStore = new MemoryDataStore();
                        var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        var dir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
                        
                        var currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                        var subscription = currentEnvironment.ConnectionString.KeyValuePairs["SubscriptionId"];
                        string spn = null;
                        string spnSecret = null;
                        if (currentEnvironment.ConnectionString.KeyValuePairs.ContainsKey("ServicePrincipal"))
                        {
                            spn = currentEnvironment.ConnectionString.KeyValuePairs["ServicePrincipal"];
                        }
                        if (currentEnvironment.ConnectionString.KeyValuePairs.ContainsKey("ServicePrincipalSecret"))
                        {
                            spnSecret = currentEnvironment.ConnectionString.KeyValuePairs["ServicePrincipalSecret"];
                        }
                        AzureSession.Instance.DataStore.WriteFile(Path.Combine(home, ".ssh", "id_rsa.pub"), File.ReadAllText(dir + "/Fixtures/id_rsa.pub"));
                        var jsonOutput = @"{""" + subscription + @""":{ ""service_principal"":""" + spn + @""",""client_secret"":"""+ spnSecret + @"""}}";
                        AzureSession.Instance.DataStore.WriteFile(Path.Combine(home, ".azure", "acsServicePrincipal.json"), jsonOutput);
                    }
                }
                )
                .Build();
        }
    }
}
