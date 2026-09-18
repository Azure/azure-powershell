using System.Collections.Generic;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    public class SftpTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected SftpTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Resources.ps1",
                    @"../AzureRM.Storage.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Sftp.psd1"),
                    helper.GetRMModulePath("Az.Storage.psd1"),
                    helper.GetRMModulePath("Az.Resources.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>(),
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Storage", null }
                    }
                )
                .Build();
        }
    }
}
