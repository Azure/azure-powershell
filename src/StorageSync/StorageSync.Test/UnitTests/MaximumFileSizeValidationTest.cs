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
    /// Class MaximumFileSizeValidationTest.
    /// </summary>
    public class MaximumFileSizeValidationTest
    {
        /// <summary>
        /// Defines the test method WhenFileIsTooBigValidationResultIsError.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenFileIsSizeIsEqualToMaxSizeValidationResultIsSuccess.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenFileIsSizeIsLessThanMaxSizeValidationResultIsSuccess.
        /// </summary>
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

        /// <summary>
        /// Defines the test method DirectoriesValidationResultIsSuccess.
        /// </summary>
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
