using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
using Xunit;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class MaximumFilenameLengthValidationTest
    {
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenFilenameIsTooLongValidationResultIsError()
        {
            // Prepare
            int maxFilenameLength = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumFilenameLength(maxFilenameLength);
            MaximumFilenameLengthValidation validation = new MaximumFilenameLengthValidation(configuration);
            string tooLongFilename = "abcd";
            IFileInfo file = MockFactory.FileWithName(tooLongFilename);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "File with too long name does not trigger an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenFilenameLengthIsEqualToMaxLengthValidationResultIsSuccess()
        {
            // Prepare
            int maxFilenameLength = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumFilenameLength(maxFilenameLength);
            MaximumFilenameLengthValidation validation = new MaximumFilenameLengthValidation(configuration);
            string filename = "abc";
            IFileInfo file = MockFactory.FileWithName(filename);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "File with name of length equal to max length triggers an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenFilenameLengthIsLessThanMaxLengthValidationResultIsSuccess()
        {
            // Prepare
            int maxFilenameLength = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumFilenameLength(maxFilenameLength);
            MaximumFilenameLengthValidation validation = new MaximumFilenameLengthValidation(configuration);
            string filename = "ac";
            IFileInfo file = MockFactory.FileWithName(filename);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "File with name of length less than max length triggers an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenDirectoryNameIsTooLongValidationResultIsError()
        {
            // Prepare
            int maxFilenameLength = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumFilenameLength(maxFilenameLength);
            MaximumFilenameLengthValidation validation = new MaximumFilenameLengthValidation(configuration);
            string tooLongName = "abcd";
            IDirectoryInfo directory = MockFactory.DirectoryWithName(tooLongName);

            // Exercise
            IValidationResult validationResult = validation.Validate(directory);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "File with too long name does not trigger an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenDirectoryNameLengthIsEqualToMaxLengthValidationResultIsSuccess()
        {
            // Prepare
            int maxFilenameLength = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumFilenameLength(maxFilenameLength);
            MaximumFilenameLengthValidation validation = new MaximumFilenameLengthValidation(configuration);
            string dirName = "abc";
            IDirectoryInfo directory = MockFactory.DirectoryWithName(dirName);

            // Exercise
            IValidationResult validationResult = validation.Validate(directory);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "File with name of length equal to max length triggers an error.");
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenDirectoryNameLengthIsLessThanMaxLengthValidationResultIsSuccess()
        {
            // Prepare
            int maxFilenameLength = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumFilenameLength(maxFilenameLength);
            MaximumFilenameLengthValidation validation = new MaximumFilenameLengthValidation(configuration);
            string dirName = "ac";
            IDirectoryInfo directory = MockFactory.DirectoryWithName(dirName);

            // Exercise
            IValidationResult validationResult = validation.Validate(directory);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "File with name of length less than max length triggers an error.");
        }

    }
}
