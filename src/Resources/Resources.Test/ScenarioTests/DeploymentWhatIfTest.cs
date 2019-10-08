namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    using WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    public class DeploymentWhatIfTest : ResourceTestRunner
    {
        public DeploymentWhatIfTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelWhatIf_BlankTemplate_ReturnsNoChange()
        {
            TestRunner.RunTestScript("Test-NewWhatIfWithBlankTemplateAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelWhatIf_ResourceIdOnlyMode_ReturnsChangesWithResourceIdsOnly()
        {
            TestRunner.RunTestScript("Test-NewWhatIfWithResourceIdOnlyAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelWhatIf_CreateResources_ReturnsCreateChanges()
        {
            TestRunner.RunTestScript("Test-NewWhatIfCreateResourcesAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelWhatIf_ModifyResources_ReturnsModifyChanges()
        {
            TestRunner.RunTestScript("Test-NewWhatIfModifyResourcesAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceGroupLevelWhatIf_DeleteResources_ReturnsDeleteChanges()
        {
            TestRunner.RunTestScript("Test-NewWhatIfDeleteResourcesAtResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionLevelWhatIf_BlankTemplate_ReturnsNoChange()
        {
            TestRunner.RunTestScript("Test-NewWhatIfWithBlankTemplateAtSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionLevelWhatIf_ResourceIdOnlyMode_ReturnsChangesWithResourceIdOnly()
        {
            TestRunner.RunTestScript("Test-NewWhatIfWithResourceIdOnlyAtSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionLevelWhatIf_CreateResources_ReturnsCreateChanges()
        {
            TestRunner.RunTestScript("Test-NewWhatIfCreateResourcesAtSubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionLevelWhatIf_ModifyResources_ReturnsModifyChanges()
        {
            TestRunner.RunTestScript("Test-NewWhatIfModifyResourcesAtSubscriptionScope");
        }
    }
}
