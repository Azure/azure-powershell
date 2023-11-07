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
    using Microsoft.Azure.Commands.StorageSync.Evaluation;
    using Xunit;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    /// <summary>
    /// Class FilenamesCharactersValidationTest.
    /// </summary>
    public class FilenamesCharactersValidationTest
    {
        /// <summary>
        /// The configuration
        /// </summary>
        IConfiguration _configuration = new Configuration();

        /// <summary>
        /// Defines the test method ItReturnsErrorOnDirectoryWithInvalidCodePoint.
        /// </summary>
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
            FilenamesCharactersValidation validation = new FilenamesCharactersValidation(configurationMockFactory.Object);

            var directoryInfoMockFactory = new Moq.Mock<IDirectoryInfo>();
            directoryInfoMockFactory.SetupGet(directoryInfo => directoryInfo.Name).Returns("AAAzAAA");

            IValidationResult validationResult = validation.Validate(directoryInfoMockFactory.Object);

            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        /// <summary>
        /// Defines the test method ItReturnsErrorOnFileWithInvalidCodePoint.
        /// </summary>
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
            FilenamesCharactersValidation validation = new FilenamesCharactersValidation(configurationMockFactory.Object);

            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.Name).Returns("AAAzAAA");

            IValidationResult validationResult = validation.Validate(fileInfoMockFactory.Object);

            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }


        /// <summary>
        /// Defines the test method TestWithRealConfigReturnsSuccessForValidSurrogateCodePoint.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWithRealConfigReturnsSuccessForValidSurrogateCodePoint()
        {
            FilenamesCharactersValidation validation = new FilenamesCharactersValidation(this._configuration);

            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();

            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.Name).Returns(new string(new char[] { 'a', (char)0xD834, (char)0xDD1E, 'z' }));
            IValidationResult validationResult = validation.Validate(fileInfoMockFactory.Object);

            Assert.StrictEqual<Result>(Result.Success, validationResult.Result);
        }


        /// <summary>
        /// Defines the test method TestWithRealConfigReturnsErrorForInvalidCodePoint.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWithRealConfigReturnsErrorForInvalidCodePoint()
        {
            FilenamesCharactersValidation validation = new FilenamesCharactersValidation(this._configuration);

            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.Name).Returns(new string(new char[] {
                'a',
                (char)0xD834, (char)0xDD1E, // valid surrogate pair
                (char)0xD834, 'a', // invalid surrogate pair,
                'a', (char)0xDD1E, // invalid surrogate pair,
                (char)0xD834, 'a', // invalid surrogate pair,
                'z',
                (char)0x007C // blacklisted codepoint
            }));
            IValidationResult validationResult = validation.Validate(fileInfoMockFactory.Object);

            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
            Assert.True(validationResult.Positions.Count == 4, $"Unexpected number of error positions");
            Assert.True(validationResult.Positions[0] == 4, $"Unexpected position of first error");
            Assert.True(validationResult.Positions[1] == 7, $"Unexpected position of second error");
            Assert.True(validationResult.Positions[2] == 8, $"Unexpected position of third error");
            Assert.True(validationResult.Positions[3] == 11, $"Unexpected position of fourth error");
        }

    }
}
