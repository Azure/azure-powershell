using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
using Xunit;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class MaximumDatasetSizeValidationTest
    {
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
