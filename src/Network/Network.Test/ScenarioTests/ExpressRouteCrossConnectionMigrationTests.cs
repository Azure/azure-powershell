using Microsoft.Azure.Commands.TestFx;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class ExpressRouteCrossConnectionMigrationTests
    {
        private readonly ITestRunner TestRunner;

        public ExpressRouteCrossConnectionMigrationTests(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename("ExpressRouteCrossConnectionMigrationTests.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Network.psd1")
                })
                .Build();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.exrdev)]
        public void TestExpressRouteCrossConnectionMigrationParameters()
        {
            TestRunner.RunTestScript("Test-ExpressRouteCrossConnectionMigrationParameterBinding");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.exrdev)]
        public void TestExpressRouteCrossConnectionMigrationWhatIf()
        {
            TestRunner.RunTestScript("Test-ExpressRouteCrossConnectionMigrationWhatIf");
        }
    }
}