using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
using Xunit;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class MaximumPathLengthValidationTest
    {
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenLocalPathIsTooLongValidationResultIsError()
        {
            // Prepare
            int maxPathLength = 20;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumPathLengthOf(maxPathLength);
            MaximumPathLengthValidation validation = new MaximumPathLengthValidation(configuration);
            string tooLongPath = "C:/asdfasdf/asdfasdf/asdfasdf";
            IFileInfo file = MockFactory.FileWithPath(tooLongPath);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "File with too long path does not trigger an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenLocalDirectoryPathIsTooLongValidationResultIsError()
        {
            // Prepare
            int maxPathLength = 20;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumPathLengthOf(maxPathLength);
            MaximumPathLengthValidation validation = new MaximumPathLengthValidation(configuration);
            string tooLongPath = "C:/asdfasdf/asdfasdf/asdfasdf";
            IDirectoryInfo directory = MockFactory.DirectoryWithPath(tooLongPath);

            // Exercise
            IValidationResult validationResult = validation.Validate(directory);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "Directory with too long path does not trigger an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenLocalFilePathIsEqualToMaxPathLengthValidationResultIsSuccess()
        {
            // Prepare
            int maxPathLength = 20;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumPathLengthOf(maxPathLength);
            MaximumPathLengthValidation validation = new MaximumPathLengthValidation(configuration);
            string path = "C:/asdfasdf/asdfasdf";
            IFileInfo file = MockFactory.FileWithPath(path);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "File with path length equal to max path length triggers an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenUNCPathIsTooLongValidationResultIsError()
        {
            // Prepare
            int maxPathLength = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumPathLengthOf(maxPathLength);
            MaximumPathLengthValidation validation = new MaximumPathLengthValidation(configuration);
            string path = "\\\\servername\\share$\\asdfasdf\\asdfasdf";
            IFileInfo file = MockFactory.FileWithPath(path);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "File with path length longer than max path length does not trigger an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenUNCPathRelativePartIsEqualToMaximumPathLengthValidationResultIsSuccess()
        {
            // Prepare
            int maxPathLength = 5;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumPathLengthOf(maxPathLength);
            MaximumPathLengthValidation validation = new MaximumPathLengthValidation(configuration);
            string path = "\\\\servername\\share$\\asdf";
            IFileInfo file = MockFactory.FileWithPath(path);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "File with UNC path relative parth length equal to max path length triggers an error.");
        }

    }
}
