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
    using Microsoft.Azure.Commands.StorageSync.Evaluation;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Xunit;
    using Moq;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    /// <summary>
    /// Class SystemValidationsProcessorTest.
    /// </summary>
    public class SystemValidationsProcessorTest
    {
        /// <summary>
        /// Defines the test method AllOutputWritersReceiveTheValidationResults.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]  
        public void AllOutputWritersReceiveTheValidationResults()
        {
            // Prepare
            var powershellCommandRunnerMockFactory = new Moq.Mock<IPowershellCommandRunner>();
            var systemValidationMockFactory = new Moq.Mock<ISystemValidation>();
            List<ISystemValidation> systemValidations = new List<ISystemValidation>
            {
                systemValidationMockFactory.Object
            };
            var outputWriterMockFactory1 = new Moq.Mock<IOutputWriter>();
            outputWriterMockFactory1.Setup(outputWriter => outputWriter.Write(It.IsAny<IValidationResult>())).Verifiable();
            var outputWriterMockFactory2 = new Moq.Mock<IOutputWriter>();
            outputWriterMockFactory2.Setup(outputWriter => outputWriter.Write(It.IsAny<IValidationResult>())).Verifiable();
            List<IOutputWriter> outputWriters = new List<IOutputWriter>
            {
                outputWriterMockFactory1.Object,
                outputWriterMockFactory2.Object
            };
            var progressReporterFactory = new Mock<IProgressReporter>();

            // Exercise
            SystemValidationsProcessor systemValidationsProcessor = new SystemValidationsProcessor(powershellCommandRunnerMockFactory.Object, systemValidations, outputWriters, progressReporterFactory.Object);
            systemValidationsProcessor.Run();

            // Verify
            outputWriterMockFactory1.Verify(outputWriter => outputWriter.Write(It.IsAny<IValidationResult>()), Times.AtMostOnce());
            // Only available in updated Moq library
            //outputWriterMockFactory1.VerifyNoOtherCalls();
            outputWriterMockFactory2.Verify(outputWriter => outputWriter.Write(It.IsAny<IValidationResult>()), Times.AtMostOnce());
            // Only available in updated Moq library
            //outputWriterMockFactory2.VerifyNoOtherCalls();
        }
    }
}
