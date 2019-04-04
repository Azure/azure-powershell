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
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations;
    using Xunit;
    using Moq;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    /// <summary>
    /// Class OSVersionValidationTest.
    /// </summary>
    public class OSVersionValidationTest
    {
        /// <summary>
        /// Defines the test method WhenOsVersionIsSupportedValidationResultIsSuccessful.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenOsVersionIsSupportedValidationResultIsSuccessful()
        {
            
            // Prepare
            string aValidOSVersion = "1.0";
            uint aValidOSSku = 0;
            List<string> validOsVersions = new List<string>() { aValidOSVersion };
            List<uint> validOsSkus = new List<uint>() { aValidOSSku };
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidOsVersions()).Returns(validOsVersions);
            configurationMockFactory.Setup(configuration => configuration.ValidOsSKU()).Returns(validOsSkus);

            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.AddScript(It.IsAny<string>())).Verifiable();

            PSObject getCimInstanceResult = new PSObject();
            getCimInstanceResult.Members.Add(new PSNoteProperty("version", "1.0.123"));
            getCimInstanceResult.Members.Add(new PSNoteProperty("OperatingSystemSKU", aValidOSSku));
            Collection<PSObject> commandResults = new Collection<PSObject>
            {
                getCimInstanceResult
            };
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.Invoke()).Returns(commandResults);

            // Exercise
            OSVersionValidation osVersionValidation = new OSVersionValidation(configurationMockFactory.Object);
            IValidationResult validationResult = osVersionValidation.ValidateUsing(powershellCommandRunnerMockFactory.Object);

            // Verify
            Assert.StrictEqual<Result>(Result.Success, validationResult.Result);
        }

        /// <summary>
        /// Defines the test method WhenOsVersionIsNotSupportedValidationResultIsError.
        /// </summary>
        [Fact]
		[Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void WhenOsVersionIsNotSupportedValidationResultIsError()
        {
            // Prepare
            string aValidOSVersion = "1.0";
            uint aValidOSSku = 0;
            List<string> validOsVersions = new List<string>() { aValidOSVersion };
            List<uint> validOsSkus = new List<uint>() { aValidOSSku };
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidOsVersions()).Returns(validOsVersions);
            configurationMockFactory.Setup(configuration => configuration.ValidOsSKU()).Returns(validOsSkus);

            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.AddScript(It.IsAny<string>())).Verifiable();

            PSObject getCimInstanceResult = new PSObject();

            getCimInstanceResult.Members.Add(new PSNoteProperty("version", "2.0"));
            getCimInstanceResult.Members.Add(new PSNoteProperty("OperatingSystemSKU", aValidOSSku));

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

        /// <summary>
        /// Defines the test method WhenOsEditionIsNotSupportedValidationResultIsError.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenOsEditionIsNotSupportedValidationResultIsError()
        {
            // Prepare
            string aValidOSVersionPrefix = "1.0";
            uint aValidOSSku = 0;
            List<string> validOsVersions = new List<string>() { aValidOSVersionPrefix };
            List<uint> validOsSkus = new List<uint>() { aValidOSSku };
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidOsVersions()).Returns(validOsVersions);
            configurationMockFactory.Setup(configuration => configuration.ValidOsSKU()).Returns(validOsSkus);

            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            powershellCommandRunnerMockFactory.Setup(powershellCommandRunner => powershellCommandRunner.AddScript(It.IsAny<string>())).Verifiable();

            PSObject getCimInstanceResult = new PSObject();
            getCimInstanceResult.Members.Add(new PSNoteProperty("version", $"{aValidOSVersionPrefix}.123")); // valid version
            getCimInstanceResult.Members.Add(new PSNoteProperty("OperatingSystemSKU", aValidOSSku + 1)); // invalid edition

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

        /// <summary>
        /// Defines the test method WhenCommandFailsToRunValidationResultIsUnavailable.
        /// </summary>
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
            string anInvalidOSVersion = "invalid_os_version";
            PSMemberInfo versionMember = new PSNoteProperty("version", anInvalidOSVersion);
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
