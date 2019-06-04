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
    /// Class MaximumPathLengthValidationTest.
    /// </summary>
    public class MaximumPathLengthValidationTest
    {
        /// <summary>
        /// Defines the test method WhenLocalPathIsTooLongValidationResultIsError.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenLocalDirectoryPathIsTooLongValidationResultIsError.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenLocalFilePathIsEqualToMaxPathLengthValidationResultIsSuccess.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenUNCPathIsTooLongValidationResultIsError.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenUNCPathRelativePartIsEqualToMaximumPathLengthValidationResultIsSuccess.
        /// </summary>
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
