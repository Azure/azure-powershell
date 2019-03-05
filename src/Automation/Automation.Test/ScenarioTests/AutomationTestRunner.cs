using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Commands.Automation.Test
{
    public class AutomationTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected AutomationTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance (output)
                .WithNewPsScriptFilename ($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests ("ScenarioTests")
                .WithCommonPsScripts (new[]
                {
                    @"../AzureRM.Resources.ps1",
                })
                .WithNewRmModules (helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath(@"AzureRM.Automation.psd1")
                })
                .Build();
        }
    }
}
