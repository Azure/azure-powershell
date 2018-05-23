using System.Collections.Generic;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
using Xunit;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class InvalidFilenameValidationTest
    {
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenFileFilenameIsInvalidValidationResultIsError()
        {
            // Prepare
            string invalidFilename = "invalid_filename";
            List<string> invalidFilenames = new List<string>
            {
                invalidFilename
            };
            IConfiguration configuration = MockFactory.ConfigurationWithInvalidFilenames(invalidFilenames);
            InvalidFilenameValidation validation = new InvalidFilenameValidation(configuration);
            IFileInfo file = MockFactory.FileWithName(invalidFilename);
            
            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenFileFilenameIsValidValidationResultIsSuccess()
        {
            // Prepare
            string invalidFilename = "invalid_filename";
            List<string> invalidFilenames = new List<string>
            {
                invalidFilename
            };
            IConfiguration configuration = MockFactory.ConfigurationWithInvalidFilenames(invalidFilenames);
            InvalidFilenameValidation validation = new InvalidFilenameValidation(configuration);
            IFileInfo file = MockFactory.FileWithName("valid_filename");

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            Assert.StrictEqual<Result>(Result.Success, validationResult.Result);
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenDirectoryNameIsInvalidValidationResultIsError()
        {
            // Prepare
            string invalidName = "invalid_name";
            List<string> invalidFilenames = new List<string>
            {
                invalidName
            };
            IConfiguration configuration = MockFactory.ConfigurationWithInvalidFilenames(invalidFilenames);
            InvalidFilenameValidation validation = new InvalidFilenameValidation(configuration);
            IDirectoryInfo file = MockFactory.DirectoryWithName(invalidName);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenDirectoryNameIsValidValidationResultIsSuccess()
        {
            // Prepare
            string invalidFilename = "invalid_filename";
            List<string> invalidFilenames = new List<string>
            {
                invalidFilename
            };
            IConfiguration configuration = MockFactory.ConfigurationWithInvalidFilenames(invalidFilenames);
            InvalidFilenameValidation validation = new InvalidFilenameValidation(configuration);
            IDirectoryInfo file = MockFactory.DirectoryWithName("valid_name");

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            Assert.StrictEqual<Result>(Result.Success, validationResult.Result);
        }

    }
}
