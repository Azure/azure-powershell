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
    /// Class MaximumDatasetSizeValidationTest.
    /// </summary>
    public class MaximumDatasetSizeValidationTest
    {
        /// <summary>
        /// Defines the test method WhenDataSetSizeIsTooBigValidationResultIsError.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenDataSetSizeIsTooBigValidationResultIsError()
        {
            // Prepare
            long maxDatasetSizeInBytes = 255;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDatasetSizeOf(maxDatasetSizeInBytes);
            MaximumDatasetSizeValidation validation = new MaximumDatasetSizeValidation(configuration);
            INamespaceInfo namespaceInfo = MockFactory.NamespaceWithPathAndSize("c:\\sample_path", maxDatasetSizeInBytes + 1);

            // Exercise
            IValidationResult validationResult = validation.Validate(namespaceInfo);

            // Verify
            AssertExtension.ValidationResultIsError(validationResult, "Dataset validation does not trigger an error when dataset is too big.");
        }

        /// <summary>
        /// Defines the test method WhenDataSetSizeIsMaxResultIsSuccess.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenDataSetSizeIsMaxResultIsSuccess()
        {
            // Prepare
            long maxDatasetSizeInBytes = 255;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDatasetSizeOf(maxDatasetSizeInBytes);
            MaximumDatasetSizeValidation validation = new MaximumDatasetSizeValidation(configuration);
            INamespaceInfo namespaceInfo = MockFactory.NamespaceWithPathAndSize("c:\\sample_path", maxDatasetSizeInBytes);

            // Exercise
            IValidationResult validationResult = validation.Validate(namespaceInfo);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "Dataset validation triggered an error when dataset is same as max.");
        }

        /// <summary>
        /// Defines the test method WhenDataSetSizeLessThanMaxResultIsSuccess.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenDataSetSizeLessThanMaxResultIsSuccess()
        {
            // Prepare
            long maxDatasetSizeInBytes = 255;
            IConfiguration configuration = MockFactory.ConfigurationWithMaximumDatasetSizeOf(maxDatasetSizeInBytes);
            MaximumDatasetSizeValidation validation = new MaximumDatasetSizeValidation(configuration);
            INamespaceInfo namespaceInfo = MockFactory.NamespaceWithPathAndSize("c:\\sample_path", maxDatasetSizeInBytes - 1);

            // Exercise
            IValidationResult validationResult = validation.Validate(namespaceInfo);

            // Verify
            AssertExtension.ValidationResultIsSuccess(validationResult, "Dataset validation triggered an error when dataset is less than max.");
        }

    }
}
