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
                    helper.GetRMModulePath("AzureRM.Compute.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                        {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"},
                        {"Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient", "2016-09-01"},
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Compute", null},
                    }
                )
                .Build();
        }
    }
}
