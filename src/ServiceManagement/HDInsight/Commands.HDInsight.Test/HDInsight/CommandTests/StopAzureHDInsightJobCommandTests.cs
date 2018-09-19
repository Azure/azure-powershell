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

using System;
using System.Linq;
using Microsoft.Hadoop.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    [TestClass]
    public class StopAzureHDInsightJobCommandTests : HDInsightTestCaseBase
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
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewHiveJob_StartJob_StopJob()
        {
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables" };

            INewAzureHDInsightHiveJobDefinitionCommand newMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewHiveDefinition();
            newMapReduceJobDefinitionCommand.JobName = hiveJobDefinition.JobName;
            newMapReduceJobDefinitionCommand.Query = hiveJobDefinition.Query;
            newMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightHiveJobDefinition hiveJobFromCommand = newMapReduceJobDefinitionCommand.Output.ElementAt(0);
            TestJobLifecycle(hiveJobFromCommand);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewMapReduceJob_StartJob_StopJob()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation job",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };

            INewAzureHDInsightMapReduceJobDefinitionCommand newMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewMapReduceDefinition();
            newMapReduceJobDefinitionCommand.JobName = mapReduceJobDefinition.JobName;
            newMapReduceJobDefinitionCommand.JarFile = mapReduceJobDefinition.JarFile;
            newMapReduceJobDefinitionCommand.ClassName = mapReduceJobDefinition.ClassName;
            newMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightMapReduceJobDefinition mapReduceJobFromCommand = newMapReduceJobDefinitionCommand.Output.ElementAt(0);

            TestJobLifecycle(mapReduceJobFromCommand);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewPigJob_StartJob_StopJob()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load table from 'A'" };

            INewAzureHDInsightPigJobDefinitionCommand newMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewPigJobDefinition();
            newMapReduceJobDefinitionCommand.Query = pigJobDefinition.Query;
            newMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightPigJobDefinition pigJobFromCommand = newMapReduceJobDefinitionCommand.Output.ElementAt(0);

            TestJobLifecycle(pigJobFromCommand);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewStreamingJob_StartJob_StopJob()
        {
            var streamingMapReduceJobDefinition = new StreamingMapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                Input = TestConstants.WabsProtocolSchemeName + "input",
                Output = TestConstants.WabsProtocolSchemeName + "input",
                Mapper = TestConstants.WabsProtocolSchemeName + "combiner",
                Reducer = TestConstants.WabsProtocolSchemeName + "combiner",
                StatusFolder = TestConstants.WabsProtocolSchemeName + "someotherlocation"
            };

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

            AzureHDInsightStreamingMapReduceJobDefinition streamingJobFromCommand = newStreamingMapReduceJobDefinitionCommand.Output.ElementAt(0);

            TestJobLifecycle(streamingJobFromCommand);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanStopHiveJob()
        {
            var hiveJobDefinition = new AzureHDInsightHiveJobDefinition { JobName = "pi estimation jobDetails", Query = "show tables;" };

            TestJobLifecycle(hiveJobDefinition);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanStopMapReduceJob()
        {
            var mapReduceJobDefinition = new AzureHDInsightMapReduceJobDefinition
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };

            TestJobLifecycle(mapReduceJobDefinition);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CannotStopNonExistingJob()
        {
            ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            TestJobStop(testCluster, Guid.NewGuid().ToString());
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        private static AzureHDInsightJob TestJobStart(AzureHDInsightJobDefinition mapReduceJobDefinition)
        {
            ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            return TestJobStart(mapReduceJobDefinition, testCluster);
        }

        private static void TestJobLifecycle(AzureHDInsightJobDefinition mapReduceJobDefinition)
        {
            ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            AzureHDInsightJob startedJob = TestJobStart(mapReduceJobDefinition, testCluster);
            TestJobStop(testCluster, startedJob.JobId);
        }

        private static AzureHDInsightJob TestJobStart(AzureHDInsightJobDefinition mapReduceJobDefinition, ClusterDetails testCluster)
        {
            IStartAzureHDInsightJobCommand startJobCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateStartJob();
            startJobCommand.Cluster = testCluster.ConnectionUrl;
            startJobCommand.Credential = GetPSCredential(testCluster.HttpUserName, testCluster.HttpPassword);
            startJobCommand.JobDefinition = mapReduceJobDefinition;
            startJobCommand.EndProcessing();
            AzureHDInsightJob jobCreationResults = startJobCommand.Output.ElementAt(0);
            Assert.IsNotNull(jobCreationResults.JobId, "Should get a non-null jobDetails id");
            Assert.IsNotNull(jobCreationResults.StatusDirectory, "StatusDirectory should be set on jobDetails");
            return jobCreationResults;
        }

        private static AzureHDInsightJob TestJobStop(ClusterDetails testCluster, string jobId)
        {
            IStopAzureHDInsightJobCommand stopJobCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateStopJob();
            stopJobCommand.Cluster = testCluster.ConnectionUrl;
            stopJobCommand.Credential = GetPSCredential(testCluster.HttpUserName, testCluster.HttpPassword);
            stopJobCommand.JobId = jobId;
            stopJobCommand.EndProcessing();

            if (stopJobCommand.Output.Count != 0)
            {
                AzureHDInsightJob jobCancellationResults = stopJobCommand.Output.ElementAt(0);
                Assert.IsNotNull(jobCancellationResults.JobId, "Should get a non-null jobDetails id");
                Assert.IsNotNull(jobCancellationResults.StatusDirectory, "StatusDirectory should be set on jobDetails");
                return jobCancellationResults;
            }
            return null;
        }
    }
}
