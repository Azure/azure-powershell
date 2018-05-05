using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using Microsoft.Azure.Commands.StorageSync.Evaluation;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
using Xunit;
using Moq;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class OSVersionValidationTest
    {
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenOsVersionIsSupportedValidationResultIsSuccessful()
        {
            // Prepare
            string aValidOSVersion = "valid_os_version";
            List<string> validOsVersions = new List<string>() {aValidOSVersion};
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidOsVersions()).Returns(validOsVersions);

            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.AddScript(It.IsAny<string>())).Verifiable();
            
            PSObject operatingSystemResult = new PSObject();
            PSMemberInfo versionMember = new PSNoteProperty("version", aValidOSVersion);
            operatingSystemResult.Members.Add(versionMember);
            Collection<PSObject> commandResults = new Collection<PSObject>
            {
                operatingSystemResult
            };
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.Invoke()).Returns(commandResults);

            // Exercise
            OSVersionValidation osVersionValidation = new OSVersionValidation(configurationMockFactory.Object);
            IValidationResult validationResult = osVersionValidation.ValidateUsing(powershellCommandRunnerMockFactory.Object);

            // Verify
            Assert.StrictEqual<Result>(Result.Success, validationResult.Result);
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenOsVersionIsNotSupportedValidationResultIsError()
        {
            // Prepare
            string aValidOSVersion = "valid_os_version";
            List<string> validOsVersions = new List<string>() { aValidOSVersion };
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidOsVersions()).Returns(validOsVersions);

            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.AddScript(It.IsAny<string>())).Verifiable();

            PSObject getCimInstanceResult = new PSObject();
            string anInalidOSVersion = "invalid_os_version";
            PSMemberInfo versionMember = new PSNoteProperty("version", anInalidOSVersion);
            getCimInstanceResult.Members.Add(versionMember);
            Collection<PSObject> commandResults = new Collection<PSObject>
            {
                getCimInstanceResult
            };
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.Invoke()).Returns(commandResults);

            // Exercise
            OSVersionValidation osVersionValidation = new OSVersionValidation(configurationMockFactory.Object);
            IValidationResult validationResult = osVersionValidation.ValidateUsing(powershellCommandRunnerMockFactory.Object);

            // Verify
            Assert.StrictEqual<Result>(Result.Fail, validationResult.Result);
        }

        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenCommandFailsToRunValidationResultIsUnavailable()
        {
            // Prepare
            string aValidOSVersion = "valid_os_version";
            List<string> validOsVersions = new List<string>() { aValidOSVersion };
            IConfiguration configuration = MockFactory.ConfigurationWithValidOSVersions(validOsVersions);

            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.AddScript(It.IsAny<string>())).Verifiable();

            PSObject getCimInstanceResult = new PSObject();
            string anInalidOSVersion = "invalid_os_version";
            PSMemberInfo versionMember = new PSNoteProperty("version", anInalidOSVersion);
            getCimInstanceResult.Members.Add(versionMember);
            Collection<PSObject> commandResults = new Collection<PSObject>
            {
                getCimInstanceResult
            };
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.Invoke()).Throws(new Exception());

            // Exercise
            OSVersionValidation osVersionValidation = new OSVersionValidation(configuration);
            IValidationResult validationResult = osVersionValidation.ValidateUsing(powershellCommandRunnerMockFactory.Object);

            // Verify
            Assert.StrictEqual<Result>(Result.Unavailable, validationResult.Result);
        }
    }
}
