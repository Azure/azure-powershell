using System.Collections.Generic;
using Microsoft.Azure.Commands.StorageSync.Evaluation;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
using Xunit;
using Moq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class SystemValidationsProcessorTest
    {
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
            outputWriterMockFactory1.VerifyNoOtherCalls();
            outputWriterMockFactory2.Verify(outputWriter => outputWriter.Write(It.IsAny<IValidationResult>()), Times.AtMostOnce());
            outputWriterMockFactory2.VerifyNoOtherCalls();
        }
    }
}
