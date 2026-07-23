using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class BicepExportTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFileUtilityBicepExtension()
        {
            // Test that the FileUtility.SaveTemplateFile method correctly uses the .bicep extension
            var outputPath = FileUtility.SaveTemplateFile(
                templateName: "test-template",
                contents: "// Test bicep content\nresource test 'Microsoft.Storage/storageAccounts@2021-04-01' = {\n  name: 'test'\n}",
                outputPath: System.IO.Path.GetTempPath(),
                overwrite: true,
                shouldContinue: null,
                extension: ".bicep"
            );
            
            Assert.EndsWith(".bicep", outputPath);
        }
    }
}
