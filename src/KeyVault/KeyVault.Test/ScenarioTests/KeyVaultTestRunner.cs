using Microsoft.Azure.Commands.TestFx;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class KeyVaultTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected KeyVaultTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules(helper => new[]
               {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("AzureRM.KeyVault.psd1"),
                    helper.GetRMModulePath("AzureRM.Network.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.KeyVault", null},
                        {"Microsoft.Network", null},
                    }
                )
                .Build();
        }
    }
}
