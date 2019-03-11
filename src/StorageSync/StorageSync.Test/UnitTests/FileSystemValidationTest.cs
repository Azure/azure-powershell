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
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations;
    using Moq;
    using Xunit;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    /// <summary>
    /// Class FileSystemValidationTest.
    /// </summary>
    public class FileSystemValidationTest
    {
        /// <summary>
        /// Defines the test method WhenFileSystemIsSupportedValidationResultIsSuccessful.
        /// </summary>
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenFileSystemIsSupportedValidationResultIsSuccessful()
        {
            // Prepare
            string aValidFilesystem = "valid_filesystem";
            List<string> validFilesystems = new List<string> { aValidFilesystem };
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidFilesystems()).Returns(validFilesystems);

            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.AddScript(It.IsAny<string>())).Verifiable();

            PSObject getVolumeResult = new PSObject();
            PSMemberInfo versionMember = new PSNoteProperty("FileSystem", aValidFilesystem);
            getVolumeResult.Members.Add(versionMember);
            Collection<PSObject> commandResults = new Collection<PSObject>
            {
                getVolumeResult
            };
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.Invoke()).Returns(commandResults);

            // Exercise
            string path = "C:\\";
            FileSystemValidation fileSystemValidation = new FileSystemValidation(configurationMockFactory.Object, path);
            IValidationResult validationResult = fileSystemValidation.ValidateUsing(powershellCommandRunnerMockFactory.Object);

            // Verify
            Assert.StrictEqual<Result>(Result.Success, validationResult.Result);
        }

        /// <summary>
        /// Defines the test method WhenFileSystemIsNotSupportedValidationResultIsError.
        /// </summary>
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenFileSystemIsNotSupportedValidationResultIsError()
        {
            // Prepare
            string aValidFilesystem = "valid_filesystem";
            List<string> validFilesystems = new List<string> { aValidFilesystem };
            var configurationMockFactory = new Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidFilesystems()).Returns(validFilesystems);

            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.AddScript(It.IsAny<string>())).Verifiable();

            PSObject getVolumeResult = new PSObject();
            string anInvalidFilesystem = "an_invalid_filesystem";
            PSMemberInfo versionMember = new PSNoteProperty("FileSystem", anInvalidFilesystem);
            getVolumeResult.Members.Add(versionMember);
            Collection<PSObject> commandResults = new Collection<PSObject>
            {
                getVolumeResult
            };
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.Invoke()).Returns(commandResults);

            // Exercise
            string path = "C:\\";
            FileSystemValidation fileSystemValidation = new FileSystemValidation(configurationMockFactory.Object, path);
            IValidationResult validationResult = fileSystemValidation.ValidateUsing(powershellCommandRunnerMockFactory.Object);

            // Verify
            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        /// <summary>
        /// Defines the test method WhenPathDoesNotSpecifiesDriveValidationResultIsUnableToRun.
        /// </summary>
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenPathDoesNotSpecifiesDriveValidationResultIsUnableToRun()
        {
            // Prepare
            string aValidFilesystem = "valid_filesystem";
            List<string> validFilesystems = new List<string> { aValidFilesystem };
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidFilesystems()).Returns(validFilesystems);

            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.AddScript(It.IsAny<string>())).Verifiable();

            PSObject getVolumeResult = new PSObject();
            string anInvalidFilesystem = "an_invalid_filesystem";
            PSMemberInfo versionMember = new PSNoteProperty("FileSystem", anInvalidFilesystem);
            getVolumeResult.Members.Add(versionMember);
            Collection<PSObject> commandResults = new Collection<PSObject>
            {
                getVolumeResult
            };
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.Invoke()).Returns(commandResults);

            // Exercise
            string path = @"\\someserver\someshare";
            FileSystemValidation fileSystemValidation = new FileSystemValidation(configurationMockFactory.Object, path);
            IValidationResult validationResult = fileSystemValidation.ValidateUsing(powershellCommandRunnerMockFactory.Object);

            // Verify
            Assert.StrictEqual<Result>(Result.Unavailable, validationResult.Result);
        }

        /// <summary>
        /// Defines the test method WhenCommandFailsValidationResultIsUnableToRun.
        /// </summary>
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenCommandFailsValidationResultIsUnableToRun()
        {
            // Prepare
            string aValidFilesystem = "valid_filesystem";
            List<string> validFilesystems = new List<string> { aValidFilesystem };
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidFilesystems()).Returns(validFilesystems);

            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.AddScript(It.IsAny<string>())).Verifiable();

            PSObject getVolumeResult = new PSObject();
            string anInvalidFilesystem = "an_invalid_filesystem";
            PSMemberInfo versionMember = new PSNoteProperty("FileSystem", anInvalidFilesystem);
            getVolumeResult.Members.Add(versionMember);
            Collection<PSObject> commandResults = new Collection<PSObject>
            {
                getVolumeResult
            };
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.Invoke()).Throws(new Exception());

            // Exercise
            string path = @"C:\dir";
            FileSystemValidation fileSystemValidation = new FileSystemValidation(configurationMockFactory.Object, path);
            IValidationResult validationResult = fileSystemValidation.ValidateUsing(powershellCommandRunnerMockFactory.Object);

            // Verify
            Assert.StrictEqual<Result>(Result.Unavailable, validationResult.Result);
        }

    }
}
