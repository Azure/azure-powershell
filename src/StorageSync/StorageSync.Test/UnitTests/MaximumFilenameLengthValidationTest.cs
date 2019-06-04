// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    /// <summary>
    /// Class MaximumFilenameLengthValidationTest.
    /// </summary>
    public class MaximumFilenameLengthValidationTest
    {
        /// <summary>
        /// Defines the test method WhenFilenameIsTooLongValidationResultIsError.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenFilenameLengthIsEqualToMaxLengthValidationResultIsSuccess.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenFilenameLengthIsLessThanMaxLengthValidationResultIsSuccess.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenDirectoryNameIsTooLongValidationResultIsError.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenDirectoryNameLengthIsEqualToMaxLengthValidationResultIsSuccess.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenDirectoryNameLengthIsLessThanMaxLengthValidationResultIsSuccess.
        /// </summary>
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
