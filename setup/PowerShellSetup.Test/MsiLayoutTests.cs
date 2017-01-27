namespace PowerShellSetup.Tests
{
    using Microsoft.Azure.Test;
    //using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Microsoft.Azure.Management.Resources;
    //using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    /// <summary>
    /// Launch Package Manager Console and execute: Update-Pacakge -reinstall
    /// This will add all the required references to the test project
    /// 
    /// Project References to be added
    ///     1) src\Common\Commands.Common.Authentication\Commands.Common.Authentication.csproj
    ///     2) src\Common\Commands.ResourceManager.Common\Commands.ResourceManager.Common.csproj
    ///     3) src\Common\Commands.ScenarioTests.ResourceManager.Common\Commands.ScenarioTests.ResourceManager.Common.csproj
    ///     
    /// 
    /// </summary>
    public class MsiLayoutTests
    {
        public MsiLayoutTests()
        {

        }

        [Fact]
        public void VerifyMsiExecExists()
        {

        }

        [Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifyFilesAreSigned(Xunit.Abstractions.ITestOutputHelper output)
        {
            
        }

        [Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateVM_Test1()
        {
            //CSMTestEnvironmentFactory csmTestFactory = new CSMTestEnvironmentFactory();
            //ResourceManagementClient ResourceMgmtClient = TestBase.GetServiceClient<ResourceManagementClient>(csmTestFactory);

            //Test-PSScript is the name of a function in your Powershell script that you would like to execute
            //ServiceTestController.NewInstance.RunPsTest("Test-PSScript"); 
            Assert.Equal<bool>(true, true);
        }
    }
}
