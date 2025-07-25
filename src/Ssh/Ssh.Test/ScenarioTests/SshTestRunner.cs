using System.Collections.Generic;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Ssh.Test.ScenarioTests
{
    public class SshTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected SshTestRunner(ITestOutputHelper output)
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
                    helper.GetRMModulePath("Az.Ssh.psd1"),
                    helper.GetRMModulePath("Az.Compute.psd1"),
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>(),
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Compute", null }
                    }
                )
                .Build();
        }
    }
}
