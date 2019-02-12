using System.Collections.Generic;
using Microsoft.Azure.Commands.TestFx;
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
                    helper.GetRMModulePath("AzureRM.ContainerInstance.psd1"),
                    helper.GetRMModulePath("AzureRM.OperationalInsights.psd1"),
                    helper.GetRMModulePath("AzureRM.ManagedServiceIdentity.psd1"),
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
                        {"Microsoft.Storage", null},
                        {"Microsoft.ManagedServiceIdentity", null},
                    }
                )
                .Build();
        }
    }
}
