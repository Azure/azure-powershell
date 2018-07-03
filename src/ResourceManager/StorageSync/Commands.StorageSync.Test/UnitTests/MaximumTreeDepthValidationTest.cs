namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
    using WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class MaximumTreeDepthValidationTest
    {
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenLocalFileIsDeeperThanMaxDepthValidationResultIsError()
        {
            // Prepare
            int maxDepth = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDepthOf(maxDepth);
            MaximumTreeDepthValidation validation = new MaximumTreeDepthValidation(configuration);
            string tooDeepFile = @"C:\first\second\third\fourth";
            IFileInfo file = MockFactory.FileWithPath(tooDeepFile);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "Too deep local file does not trigger an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenUNCFileIsDeeperThanMaxDepthValidationResultIsError()
        {
            // Prepare
            int maxDepth = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDepthOf(maxDepth);
            MaximumTreeDepthValidation validation = new MaximumTreeDepthValidation(configuration);
            string tooDeepFile = @"\\server\share$\first\second\third\fourth";
            IFileInfo file = MockFactory.FileWithPath(tooDeepFile);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "Too deep local file does not trigger an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenLocalFileDepthIsEqualToMaxDepthValidationResultIsSuccess()
        {
            // Prepare
            int maxDepth = 4;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDepthOf(maxDepth);
            MaximumTreeDepthValidation validation = new MaximumTreeDepthValidation(configuration);
            string path = @"C:\first\second\third\fourth";
            IFileInfo file = MockFactory.FileWithPath(path);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "Local file with depth equal to max depth triggers an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenUNCFileDepthIsEqualToMaxDepthValidationResultIsSuccess()
        {
            // Prepare
            int maxDepth = 4;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDepthOf(maxDepth);
            MaximumTreeDepthValidation validation = new MaximumTreeDepthValidation(configuration);
            string path = @"\\server\share$\first\second\third\fourth";
            IFileInfo file = MockFactory.FileWithPath(path);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "UNC file with depth equal to max depth triggers an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenLocalDirectoryTreeDepthIsEqualToMaxDepthValidationResultIsSuccess()
        {
            // Prepare
            int maxDepth = 4;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDepthOf(maxDepth);
            MaximumTreeDepthValidation validation = new MaximumTreeDepthValidation(configuration);
            string path = @"C:\first\second\third\fourth";
            IDirectoryInfo directory = MockFactory.DirectoryWithPath(path);

            // Exercise
            IValidationResult validationResult = validation.Validate(directory);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "Local file with depth equal to max depth triggers an error.");
        }

    }
}
