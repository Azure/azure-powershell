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

using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactories.Test.UnitTests
{
    public class GetActivityWindowTests : DataFactoryUnitTestBase
    {
        private const string pipelineName = "pipeline";
        private const string datasetName = "dataset";
        private const string activityName = "activity";

        private GetAzureDataFactoryActivityWindowsCommand cmdlet;

        private List<PSActivityWindow> expectedDf;
        private ActivityWindowListResponse response;

        // Arrange
        List<ActivityWindow> activityWindowsForResponseWindows = new List<ActivityWindow>()
            {
                new ActivityWindow()
                {
                    PipelineName = pipelineName,
                    DataFactoryName = DataFactoryName,
                    ResourceGroupName = ResourceGroupName,
                    LinkedServiceName = "ls",
                    RunStart = new DateTime(2016, 10, 02),
                    RunEnd = new DateTime(2016, 10, 03),
                    PercentComplete = 90
                },
                new ActivityWindow()
                {
                    PipelineName = pipelineName,
                    DataFactoryName = DataFactoryName,
                    ResourceGroupName = ResourceGroupName,
                    LinkedServiceName = "ls2",
                    RunStart = new DateTime(2016, 10, 02),
                    RunEnd = new DateTime(2016, 10, 03),
                    PercentComplete = 70
                }
            };

        public GetActivityWindowTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            this.expectedDf = new List<PSActivityWindow>();
            this.expectedDf.AddRange(activityWindowsForResponseWindows.Select(activityWindow => new PSActivityWindow(activityWindow)));

            this.response = new ActivityWindowListResponse()
            {
                ActivityWindowListResponseValue = new ActivityWindowListResponseValue()
                {
                    ActivityWindows = activityWindowsForResponseWindows,
                    LastUpdate = DateTime.UtcNow.ToString()
                },
                NextLink = null
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanListDataFactoryActivityWindows()
        {
            cmdlet = new GetAzureDataFactoryActivityWindowsCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName
            };

            dataFactoriesClientMock
                .Setup(
                    c =>
                        c.ListByDataFactoryActivityWindows(It.IsAny<string>(),
                            It.Is<ActivityWindowsByDataFactoryListParameters>(
                                options =>
                                    options.ResourceGroupName == ResourceGroupName &&
                                    options.DataFactoryName == DataFactoryName)))
                .Returns(this.response)
                .Verifiable();

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<List<PSActivityWindow>>(x => this.ValidateResult(x)), true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanListPipelineActivityWindows()
        {
            cmdlet = new GetAzureDataFactoryActivityWindowsCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                PipelineName = pipelineName
            };

            dataFactoriesClientMock
                .Setup(
                    c =>
                        c.ListByPipelineActivityWindows(It.IsAny<string>(),
                            It.Is<ActivityWindowsByPipelineListParameters>(
                                options =>
                                    options.ResourceGroupName == ResourceGroupName &&
                                    options.DataFactoryName == DataFactoryName &&
                                    options.PipelineName == pipelineName)))
                .Returns(this.response)
                .Verifiable();

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<List<PSActivityWindow>>(x => this.ValidateResult(x)), true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanListDatasetActivityWindows()
        {
            cmdlet = new GetAzureDataFactoryActivityWindowsCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                DatasetName = datasetName
            };

            dataFactoriesClientMock
                .Setup(
                    c =>
                        c.ListByDatasetActivityWindows(It.IsAny<string>(),
                            It.Is<ActivityWindowsByDatasetListParameters>(
                                options =>
                                    options.ResourceGroupName == ResourceGroupName &&
                                    options.DataFactoryName == DataFactoryName &&
                                    options.DatasetName == datasetName)))
                .Returns(this.response)
                .Verifiable();

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<List<PSActivityWindow>>(x => this.ValidateResult(x)), true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanListActivityActivityWindows()
        {
            cmdlet = new GetAzureDataFactoryActivityWindowsCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                PipelineName = pipelineName,
                ActivityName = activityName
            };

            dataFactoriesClientMock
                .Setup(
                    c =>
                        c.ListByActivityActivityWindows(It.IsAny<string>(),
                            It.Is<ActivityWindowsByActivityListParameters>(
                                options =>
                                    options.ResourceGroupName == ResourceGroupName &&
                                    options.DataFactoryName == DataFactoryName &&
                                    options.PipelineName == pipelineName &&
                                    options.ActivityName == activityName)))
                .Returns(this.response)
                .Verifiable();

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(f => f.WriteObject(It.Is<List<PSActivityWindow>>(x => this.ValidateResult(x)), true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanThrowWarningWhenBadArgumentPassed()
        {
            cmdlet = new GetAzureDataFactoryActivityWindowsCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                DataFactoryClient = dataFactoriesClientMock.Object,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                DatasetName = datasetName,
                PipelineName = pipelineName,
                ActivityName = activityName
            };

            // Action
            cmdlet.ExecuteCmdlet();

            // Assert
            dataFactoriesClientMock.VerifyAll();

            commandRuntimeMock.Verify(f => f.WriteWarning(It.Is<string>(x => x.Contains("An incorrect combination of arguments was passed"))), Times.Once());
        }

        private bool ValidateResult(List<PSActivityWindow> result)
        {
            if (result.Count != expectedDf.Count)
            {
                return false;
            }

            for (int i = 0; i < result.Count; i++)
            {
                if (!result[i].IsEqualTo(expectedDf[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}