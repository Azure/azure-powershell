using Microsoft.Azure.Commands.StorageSync.Evaluation;
using Xunit;
using System.Collections.Generic;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class FilenamesCharactersValidationTest
    {
        [Fact]
				[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void ItReturnsErrorOnDirectoryWithInvalidCodePoint()
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            List<int> codePointBlacklist = new List<int>
            {
                0x7A
            };
            configurationMockFactory.Setup(configuration => configuration.BlacklistOfCodePoints()).Returns(codePointBlacklist);
            configurationMockFactory.Setup(configuration => configuration.BlacklistOfCodePointRanges()).Returns(new List<Configuration.CodePointRange>());
            FilenamesCharactersValidation validation = new FilenamesCharactersValidation(configurationMockFactory.Object);

            var directoryInfoMockFactory = new Moq.Mock<IDirectoryInfo>();
            directoryInfoMockFactory.SetupGet(directoryInfo => directoryInfo.Name).Returns("AAAzAAA");

            IValidationResult validationResult = validation.Validate(directoryInfoMockFactory.Object);

            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        [Fact]
				[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void ItReturnsErrorOnFileWithInvalidCodePoint()
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            List<int> codePointBlacklist = new List<int>
            {
                0x7A
            };
            configurationMockFactory.Setup(configuration => configuration.BlacklistOfCodePoints()).Returns(codePointBlacklist);
            configurationMockFactory.Setup(configuration => configuration.BlacklistOfCodePointRanges()).Returns(new List<Configuration.CodePointRange>());
            FilenamesCharactersValidation validation = new FilenamesCharactersValidation(configurationMockFactory.Object);

            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.Name).Returns("AAAzAAA");

            IValidationResult validationResult = validation.Validate(fileInfoMockFactory.Object);

            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        [Fact]
				[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void ItReturnsErrorWhenCodePointIsInBoundsOfRange()
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            List<Configuration.CodePointRange> blacklist = new List<Configuration.CodePointRange>
            {
                new Configuration.CodePointRange {
                    Start = 0x79, // y
                    End = 0x7A    // z
                }
            };
            configurationMockFactory.Setup(configuration => configuration.BlacklistOfCodePointRanges()).Returns(blacklist);
            configurationMockFactory.Setup(configuration => configuration.BlacklistOfCodePoints()).Returns(new List<int>());
            FilenamesCharactersValidation validation = new FilenamesCharactersValidation(configurationMockFactory.Object);

            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.Name).Returns("AAAzAAA");
            IValidationResult validationResult = validation.Validate(fileInfoMockFactory.Object);

            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        [Fact]
				[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void ItReturnsErrorWhenCodePointIsInMiddleOfRange()
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            List<Configuration.CodePointRange> blacklist = new List<Configuration.CodePointRange>
            {
                new Configuration.CodePointRange {
                    Start = 0x78, // y
                    End = 0x7A    // z
                }
            };
            configurationMockFactory.Setup(configuration => configuration.BlacklistOfCodePointRanges()).Returns(blacklist);
            configurationMockFactory.Setup(configuration => configuration.BlacklistOfCodePoints()).Returns(new List<int>());
            FilenamesCharactersValidation validation = new FilenamesCharactersValidation(configurationMockFactory.Object);

            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.Name).Returns("AAAyAAA");
            IValidationResult validationResult = validation.Validate(fileInfoMockFactory.Object);

            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }


    }
}
