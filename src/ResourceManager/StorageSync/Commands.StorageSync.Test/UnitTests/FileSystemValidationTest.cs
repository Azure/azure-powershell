using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class FileSystemValidationTest
    {
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
