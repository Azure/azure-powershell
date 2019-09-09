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

using System.IO;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
    using WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    /// <summary>
    /// Class MaximumTreeDepthValidationTest.
    /// </summary>
    public class MaximumTreeDepthValidationTest
    {
        /// <summary>
        /// Defines the test method WhenLocalFileIsDeeperThanMaxDepthValidationResultIsError.
        /// </summary>
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenLocalFileIsDeeperThanMaxDepthValidationResultIsError()
        {
            // Prepare
            int maxDepth = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDepthOf(maxDepth);
            MaximumTreeDepthValidation validation = new MaximumTreeDepthValidation(configuration);
            var tooDeepFile = Path.Combine(@"C:\", "first", "second", "third", "fourth");
            IFileInfo file = MockFactory.FileWithPath(tooDeepFile);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "Too deep local file does not trigger an error.");
        }

#if NETSTANDARD
        [Fact(Skip = "Fails on Linux, needs investigation")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        /// <summary>
        /// Defines the test method WhenUNCFileIsDeeperThanMaxDepthValidationResultIsError.
        /// </summary>
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenUNCFileIsDeeperThanMaxDepthValidationResultIsError()
        {
            // Prepare
            int maxDepth = 3;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDepthOf(maxDepth);
            MaximumTreeDepthValidation validation = new MaximumTreeDepthValidation(configuration);
            var tooDeepFile = Path.Combine(@"\\server", "share$", "first", "second", "third", "fourth");
            IFileInfo file = MockFactory.FileWithPath(tooDeepFile);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "Too deep local file does not trigger an error.");
        }

        /// <summary>
        /// Defines the test method WhenLocalFileDepthIsEqualToMaxDepthValidationResultIsSuccess.
        /// </summary>
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenLocalFileDepthIsEqualToMaxDepthValidationResultIsSuccess()
        {
            // Prepare
            int maxDepth = 4;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDepthOf(maxDepth);
            MaximumTreeDepthValidation validation = new MaximumTreeDepthValidation(configuration);
            var path = Path.Combine(@"C:\", "first", "second", "third", "fourth");
            IFileInfo file = MockFactory.FileWithPath(path);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "Local file with depth equal to max depth triggers an error.");
        }

#if NETSTANDARD
        [Fact(Skip = "Fails on Linux, needs investigation")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        /// <summary>
        /// Defines the test method WhenUNCFileDepthIsEqualToMaxDepthValidationResultIsSuccess.
        /// </summary>
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenUNCFileDepthIsEqualToMaxDepthValidationResultIsSuccess()
        {
            // Prepare
            int maxDepth = 4;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDepthOf(maxDepth);
            MaximumTreeDepthValidation validation = new MaximumTreeDepthValidation(configuration);
            var path = Path.Combine(@"\\server", "share$", "first", "second", "third", "fourth");
            IFileInfo file = MockFactory.FileWithPath(path);

            // Exercise
            IValidationResult validationResult = validation.Validate(file);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "UNC file with depth equal to max depth triggers an error.");
        }

        /// <summary>
        /// Defines the test method WhenLocalDirectoryTreeDepthIsEqualToMaxDepthValidationResultIsSuccess.
        /// </summary>
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenLocalDirectoryTreeDepthIsEqualToMaxDepthValidationResultIsSuccess()
        {
            // Prepare
            int maxDepth = 4;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDepthOf(maxDepth);
            MaximumTreeDepthValidation validation = new MaximumTreeDepthValidation(configuration);
            var path = Path.Combine(@"C:\", "first", "second", "third", "fourth");
            IDirectoryInfo directory = MockFactory.DirectoryWithPath(path);

            // Exercise
            IValidationResult validationResult = validation.Validate(directory);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "Local file with depth equal to max depth triggers an error.");
        }

    }
}
