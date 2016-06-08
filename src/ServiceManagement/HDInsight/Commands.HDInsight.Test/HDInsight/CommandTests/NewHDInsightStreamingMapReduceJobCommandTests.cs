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

using System.Collections;
using System.Linq;
using Microsoft.Hadoop.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    [TestClass]
    public class NewHDInsightStreamingMapReduceJobCommandTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightStreamingMapReduceJobDefinition")]
        public void CanCreateNewStreamingMapReduceDefinition()
        {
            StreamingMapReduceJobCreateParameters streamingMapReduceJobDefinition = this.GetStreamingMapReduceJob();

            INewAzureHDInsightStreamingJobDefinitionCommand newStreamingMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewStreamingMapReduceDefinition();
            newStreamingMapReduceJobDefinitionCommand.JobName = streamingMapReduceJobDefinition.JobName;
            newStreamingMapReduceJobDefinitionCommand.JobName = streamingMapReduceJobDefinition.JobName;
            newStreamingMapReduceJobDefinitionCommand.InputPath = streamingMapReduceJobDefinition.Input;
            newStreamingMapReduceJobDefinitionCommand.OutputPath = streamingMapReduceJobDefinition.Output;
            newStreamingMapReduceJobDefinitionCommand.Mapper = streamingMapReduceJobDefinition.Mapper;
            newStreamingMapReduceJobDefinitionCommand.Reducer = streamingMapReduceJobDefinition.Reducer;
            newStreamingMapReduceJobDefinitionCommand.StatusFolder = streamingMapReduceJobDefinition.StatusFolder;
            newStreamingMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightStreamingMapReduceJobDefinition streamingMapReduceJobFromCommand =
                newStreamingMapReduceJobDefinitionCommand.Output.ElementAt(0);

            NewStreamingMapReduceJobCmdLetTests.AssertJobDefinitionsEqual(streamingMapReduceJobDefinition, streamingMapReduceJobFromCommand);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightStreamingMapReduceJobDefinition")]
        public void CanCreateNewStreamingMapReduceDefinition_WithArguments()
        {
            StreamingMapReduceJobCreateParameters streamingMapReduceJobDefinition = this.GetStreamingMapReduceJob();
            streamingMapReduceJobDefinition.Arguments.Add("16");
            streamingMapReduceJobDefinition.Arguments.Add("10000");

            INewAzureHDInsightStreamingJobDefinitionCommand newStreamingMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewStreamingMapReduceDefinition();
            newStreamingMapReduceJobDefinitionCommand.JobName = streamingMapReduceJobDefinition.JobName;
            newStreamingMapReduceJobDefinitionCommand.JobName = streamingMapReduceJobDefinition.JobName;
            newStreamingMapReduceJobDefinitionCommand.InputPath = streamingMapReduceJobDefinition.Input;
            newStreamingMapReduceJobDefinitionCommand.OutputPath = streamingMapReduceJobDefinition.Output;
            newStreamingMapReduceJobDefinitionCommand.Mapper = streamingMapReduceJobDefinition.Mapper;
            newStreamingMapReduceJobDefinitionCommand.Reducer = streamingMapReduceJobDefinition.Reducer;
            newStreamingMapReduceJobDefinitionCommand.StatusFolder = streamingMapReduceJobDefinition.StatusFolder;
            newStreamingMapReduceJobDefinitionCommand.Arguments = streamingMapReduceJobDefinition.Arguments.ToArray();
            newStreamingMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightStreamingMapReduceJobDefinition streamingMapReduceJobFromCommand =
                newStreamingMapReduceJobDefinitionCommand.Output.ElementAt(0);

            NewStreamingMapReduceJobCmdLetTests.AssertJobDefinitionsEqual(streamingMapReduceJobDefinition, streamingMapReduceJobFromCommand);

            foreach (string argument in streamingMapReduceJobDefinition.Arguments)
            {
                Assert.IsTrue(
                    streamingMapReduceJobFromCommand.Arguments.Any(arg => string.Equals(argument, arg)),
                    "Unable to find argument '{0}' in value returned from command",
                    argument);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightStreamingMapReduceJobDefinition")]
        public void CanCreateNewStreamingMapReduceDefinition_WithParameters()
        {
            StreamingMapReduceJobCreateParameters streamingMapReduceJobDefinition = this.GetStreamingMapReduceJob();

            streamingMapReduceJobDefinition.Defines.Add("map.input.tasks", "1000");
            streamingMapReduceJobDefinition.Defines.Add("map.input.reducers", "1000");

            INewAzureHDInsightStreamingJobDefinitionCommand newStreamingMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewStreamingMapReduceDefinition();
            newStreamingMapReduceJobDefinitionCommand.JobName = streamingMapReduceJobDefinition.JobName;
            newStreamingMapReduceJobDefinitionCommand.JobName = streamingMapReduceJobDefinition.JobName;
            newStreamingMapReduceJobDefinitionCommand.InputPath = streamingMapReduceJobDefinition.Input;
            newStreamingMapReduceJobDefinitionCommand.OutputPath = streamingMapReduceJobDefinition.Output;
            newStreamingMapReduceJobDefinitionCommand.Mapper = streamingMapReduceJobDefinition.Mapper;
            newStreamingMapReduceJobDefinitionCommand.Reducer = streamingMapReduceJobDefinition.Reducer;
            newStreamingMapReduceJobDefinitionCommand.StatusFolder = streamingMapReduceJobDefinition.StatusFolder;
            newStreamingMapReduceJobDefinitionCommand.Defines = new Hashtable();
            foreach (var define in streamingMapReduceJobDefinition.Defines)
            {
                newStreamingMapReduceJobDefinitionCommand.Defines.Add(define.Key, define.Value);
            }
            newStreamingMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightStreamingMapReduceJobDefinition streamingMapReduceJobFromCommand =
                newStreamingMapReduceJobDefinitionCommand.Output.ElementAt(0);

            NewStreamingMapReduceJobCmdLetTests.AssertJobDefinitionsEqual(streamingMapReduceJobDefinition, streamingMapReduceJobFromCommand);

            foreach (var parameter in streamingMapReduceJobDefinition.Defines)
            {
                Assert.IsTrue(
                    streamingMapReduceJobFromCommand.Defines.Any(
                        arg => string.Equals(parameter.Key, arg.Key) && string.Equals(parameter.Value, arg.Value)),
                    "Unable to find parameter '{0}' in value returned from command",
                    parameter.Key);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightStreamingMapReduceJobDefinition")]
        public void CanCreateNewStreamingMapReduceDefinition_WithResources()
        {
            StreamingMapReduceJobCreateParameters streamingMapReduceJobDefinition = this.GetStreamingMapReduceJob();
            streamingMapReduceJobDefinition.Files.Add("pidata.txt");
            streamingMapReduceJobDefinition.Files.Add("pidate2.txt");

            INewAzureHDInsightStreamingJobDefinitionCommand newStreamingMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewStreamingMapReduceDefinition();
            newStreamingMapReduceJobDefinitionCommand.JobName = streamingMapReduceJobDefinition.JobName;
            newStreamingMapReduceJobDefinitionCommand.JobName = streamingMapReduceJobDefinition.JobName;
            newStreamingMapReduceJobDefinitionCommand.InputPath = streamingMapReduceJobDefinition.Input;
            newStreamingMapReduceJobDefinitionCommand.OutputPath = streamingMapReduceJobDefinition.Output;
            newStreamingMapReduceJobDefinitionCommand.Mapper = streamingMapReduceJobDefinition.Mapper;
            newStreamingMapReduceJobDefinitionCommand.Reducer = streamingMapReduceJobDefinition.Reducer;
            newStreamingMapReduceJobDefinitionCommand.StatusFolder = streamingMapReduceJobDefinition.StatusFolder;
            newStreamingMapReduceJobDefinitionCommand.Files = streamingMapReduceJobDefinition.Files.ToArray();
            newStreamingMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightStreamingMapReduceJobDefinition streamingMapReduceJobFromCommand =
                newStreamingMapReduceJobDefinitionCommand.Output.ElementAt(0);

            NewStreamingMapReduceJobCmdLetTests.AssertJobDefinitionsEqual(streamingMapReduceJobDefinition, streamingMapReduceJobFromCommand);

            foreach (string resource in streamingMapReduceJobDefinition.Files)
            {
                Assert.IsTrue(
                    streamingMapReduceJobFromCommand.Files.Any(arg => string.Equals(resource, arg)),
                    "Unable to find File '{0}' in value returned from command",
                    resource);
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        private StreamingMapReduceJobCreateParameters GetStreamingMapReduceJob()
        {
            return new StreamingMapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                Input = TestConstants.WabsProtocolSchemeName + "input",
                Output = TestConstants.WabsProtocolSchemeName + "input",
                Mapper = TestConstants.WabsProtocolSchemeName + "combiner",
                Reducer = TestConstants.WabsProtocolSchemeName + "combiner",
                StatusFolder = TestConstants.WabsProtocolSchemeName + "someotherlocation"
            };
        }
    }
}
