using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class MaximumFileSizeValidationTest
    {
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenFileIsTooBigValidationResultIsError()
        {
            // Prepare
            int maxFileSize = 10;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumFileSizeOf(maxFileSize);
            MaximumFileSizeValidation validation = new MaximumFileSizeValidation(configuration);
            int tooBigSize = maxFileSize + 1;
            IFileInfo tooBigFile = MockFactory.FileWithSizeOf(tooBigSize);

            // Exercise
            IValidationResult validationResult = validation.Validate(tooBigFile);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "A file bigger than maximum file size does not trigger an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenFileIsSizeIsEqualToMaxSizeValidationResultIsSuccess()
        {
            // Prepare
            int maxFileSize = 10;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumFileSizeOf(maxFileSize);
            MaximumFileSizeValidation validation = new MaximumFileSizeValidation(configuration);
            IFileInfo file = MockFactory.FileWithSizeOf(maxFileSize);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "A file with size equal to maximum file size triggers an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenFileIsSizeIsLessThanMaxSizeValidationResultIsSuccess()
        {
            // Prepare
            int maxFileSize = 10;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumFileSizeOf(maxFileSize);
            MaximumFileSizeValidation validation = new MaximumFileSizeValidation(configuration);
            int lessThanMaxSize = maxFileSize - 1;
            IFileInfo file = MockFactory.FileWithSizeOf(lessThanMaxSize);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "A file with size less than maximum file size triggers an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void DirectoriesValidationResultIsSuccess()
        {
            // Prepare
            int maxFileSize = 10;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumFileSizeOf(maxFileSize);
            MaximumFileSizeValidation validation = new MaximumFileSizeValidation(configuration);
            IDirectoryInfo directory = MockFactory.DirectoryWithName("a_directory_name");

            // Exercise
            IValidationResult validationResult = validation.Validate(directory);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "A directory triggers a maximum file size validation error.");
        }

    }
}
