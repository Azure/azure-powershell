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
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
    using Xunit;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.NamespaceValidations;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    /// <summary>
    /// Class InvalidFilenameValidationTest.
    /// </summary>
    public class InvalidFilenameValidationTest
    {
        /// <summary>
        /// Defines the test method WhenFileFilenameIsInvalidValidationResultIsError.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenFileFilenameIsValidValidationResultIsSuccess.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenDirectoryNameIsInvalidValidationResultIsError.
        /// </summary>
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

        /// <summary>
        /// Defines the test method WhenDirectoryNameIsValidValidationResultIsSuccess.
        /// </summary>
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
