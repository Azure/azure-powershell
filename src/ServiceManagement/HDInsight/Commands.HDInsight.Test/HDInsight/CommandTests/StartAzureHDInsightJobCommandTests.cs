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
    public class StartAzureHDInsightJobCommandTests : HDInsightTestCaseBase
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
        public void CanAutoGenerateStatusDirectoryForMapReduceJob()
        {
            var mapReduceJobDefinition = new AzureHDInsightMapReduceJobDefinition
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };

            AzureHDInsightJob startedJob = TestJobStart(mapReduceJobDefinition);
            Assert.IsFalse(string.IsNullOrEmpty(startedJob.StatusDirectory));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewHiveJob_StartJob()
        {
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables" };

            INewAzureHDInsightHiveJobDefinitionCommand newHiveJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewHiveDefinition();
            newHiveJobDefinitionCommand.JobName = hiveJobDefinition.JobName;
            newHiveJobDefinitionCommand.Query = hiveJobDefinition.Query;
            newHiveJobDefinitionCommand.EndProcessing();

            AzureHDInsightHiveJobDefinition hiveJobFromCommand = newHiveJobDefinitionCommand.Output.ElementAt(0);
            TestJobStart(hiveJobFromCommand);
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CannotCreateNewHiveJob_WithRestrictedCharacters_StartJob()
        {
            var hiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables %" };

            INewAzureHDInsightHiveJobDefinitionCommand newHiveJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewHiveDefinition();
            newHiveJobDefinitionCommand.JobName = hiveJobDefinition.JobName;
            newHiveJobDefinitionCommand.Query = hiveJobDefinition.Query;
            newHiveJobDefinitionCommand.EndProcessing();

            AzureHDInsightHiveJobDefinition hiveJobFromCommand = newHiveJobDefinitionCommand.Output.ElementAt(0);
            try
            {
                TestJobStart(hiveJobFromCommand);
                Assert.Fail();
            }
            catch (AggregateException aggregateException)
            {
                var invalidOperationException = aggregateException.GetBaseException() as InvalidOperationException;
                Assert.IsNotNull(invalidOperationException);
                Assert.IsTrue(invalidOperationException.Message.Contains("Query contains restricted character :'%'"), "Exception not thrown for special character");
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewHiveJob_WithoutJobName_WithFile()
        {
            var hiveJobDefinition = new AzureHDInsightHiveJobDefinition
            {
                File = TestConstants.WabsProtocolSchemeName + "container@hostname/Container1/myqueryfile.hql"
            };

            AzureHDInsightJob startedJob = TestJobStart(hiveJobDefinition);
            Assert.AreEqual(startedJob.Name, "Hive: myqueryfile.hql");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewHiveJob_WithoutJobName_WithQuery()
        {
            var hiveJobDefinition = new AzureHDInsightHiveJobDefinition { Query = "show tables" };

            AzureHDInsightJob startedJob = TestJobStart(hiveJobDefinition);
            Assert.AreEqual(startedJob.Name, "Hive: show tables");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewMapReduceJob_StartJob()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
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

            TestJobStart(mapReduceJobFromCommand);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewMapReduceJob_WithoutJobName()
        {
            var mapReduceJobDefinition = new AzureHDInsightMapReduceJobDefinition
            {
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar",
                StatusFolder = "/myoutputfolder"
            };

            AzureHDInsightJob startedJob = TestJobStart(mapReduceJobDefinition);
            Assert.AreEqual("pi", startedJob.Name);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewPigJob_StartJob()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load table from 'A'" };

            INewAzureHDInsightPigJobDefinitionCommand newMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewPigJobDefinition();
            newMapReduceJobDefinitionCommand.Query = pigJobDefinition.Query;
            newMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightPigJobDefinition pigJobFromCommand = newMapReduceJobDefinitionCommand.Output.ElementAt(0);

            TestJobStart(pigJobFromCommand);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CannotCreateNewPigJob_WithRestrictedCharacters_StartJob()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load table from 'A' %" };

            INewAzureHDInsightPigJobDefinitionCommand newMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewPigJobDefinition();
            newMapReduceJobDefinitionCommand.Query = pigJobDefinition.Query;
            newMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightPigJobDefinition pigJobFromCommand = newMapReduceJobDefinitionCommand.Output.ElementAt(0);
            try
            {
                TestJobStart(pigJobFromCommand);
                Assert.Fail();
            }
            catch (AggregateException aggregateException)
            {
                var invalidOperationException = aggregateException.GetBaseException() as InvalidOperationException;
                Assert.IsNotNull(invalidOperationException);
                Assert.IsTrue(invalidOperationException.Message.Contains("Query contains restricted character :'%'"), "Exception not thrown for special character");
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewPigJob_WithoutJobName_WithFile()
        {
            var pigJobDefinition = new AzureHDInsightPigJobDefinition
            {
                File = TestConstants.WabsProtocolSchemeName + "container@hostname/Container1/myqueryfile.hql"
            };

            AzureHDInsightJob startedJob = TestJobStart(pigJobDefinition);
            Assert.AreEqual(string.Empty, startedJob.Name);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewPigJob_WithoutJobName_WithQuery()
        {
            var pigJobDefinition = new AzureHDInsightPigJobDefinition { Query = "show tables" };

            AzureHDInsightJob startedJob = TestJobStart(pigJobDefinition);
            Assert.AreEqual(string.Empty, startedJob.Name);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewStreamingJob_StartJob()
        {
            var streamingMapReduceJobDefinition = new StreamingMapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                Input = TestConstants.WabsProtocolSchemeName + "container@hostname/input",
                Output = TestConstants.WabsProtocolSchemeName + "container@hostname/input",
                Mapper = TestConstants.WabsProtocolSchemeName + "container@hostname/combiner",
                Reducer = TestConstants.WabsProtocolSchemeName + "container@hostname/combiner",
                StatusFolder = TestConstants.WabsProtocolSchemeName + "container@hostname/someotherlocation"
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

            TestJobStart(streamingJobFromCommand);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanCreateNewStreamingMapReduceJob_WithoutJobName()
        {
            var streamingMapReduceJobDefinition = new AzureHDInsightStreamingMapReduceJobDefinition
            {
                Input = TestConstants.WabsProtocolSchemeName + "container@hostname/input",
                Output = TestConstants.WabsProtocolSchemeName + "container@hostname/input",
                Mapper = TestConstants.WabsProtocolSchemeName + "container@hostname/mapper",
                Reducer = TestConstants.WabsProtocolSchemeName + "container@hostname/combiner",
                StatusFolder = TestConstants.WabsProtocolSchemeName + "container@hostname/someotherlocation"
            };

            AzureHDInsightJob startedJob = TestJobStart(streamingMapReduceJobDefinition);
            Assert.AreEqual(startedJob.Name, "mapper");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Defect")]
        public void CanCreateNewStreamingMapReduceJob_WithoutJobName_FilesName()
        {
            var streamingMapReduceJobDefinition = new AzureHDInsightStreamingMapReduceJobDefinition
            {
                Input = "input",
                Output = "output",
                Mapper = "mapper.exe",
                Reducer = "combiner.exe",
                StatusFolder = "/someotherlocation"
            };

            AzureHDInsightJob startedJob = TestJobStart(streamingMapReduceJobDefinition);
            Assert.AreEqual(startedJob.Name, "mapper.exe");
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Defect")]
        public void CanCreateNewStreamingMapReduceJob_WithoutJobName_FilesRelative()
        {
            var streamingMapReduceJobDefinition = new AzureHDInsightStreamingMapReduceJobDefinition
            {
                Input = "input",
                Output = "output",
                Mapper = "/examples/mapper.exe",
                Reducer = "/examples/combiner.exe",
                StatusFolder = "/someotherlocation"
            };

            AzureHDInsightJob startedJob = TestJobStart(streamingMapReduceJobDefinition);
            Assert.AreEqual("mapper.exe", startedJob.Name);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanStartHiveJob()
        {
            var hiveJobDefinition = new AzureHDInsightHiveJobDefinition { JobName = "pi estimation jobDetails", Query = "show tables;" };

            TestJobStart(hiveJobDefinition);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanStartMapReduceJob()
        {
            var mapReduceJobDefinition = new AzureHDInsightMapReduceJobDefinition
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };
            TestJobStart(mapReduceJobDefinition);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CanStartSqoopJob()
        {
            var sqoopJobDefinition = new AzureHDInsightSqoopJobDefinition { Command = "show tables;" };

            TestJobStart(sqoopJobDefinition);
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CannotStartSqoopJob_WithRestrictedCharacters()
        {
            var sqoopJobDefinition = new AzureHDInsightSqoopJobDefinition { Command = "show tables; %" };
            try
            {
                TestJobStart(sqoopJobDefinition);
                Assert.Fail();
            }
            catch (AggregateException aggregateException)
            {
                var invalidOperationException = aggregateException.GetBaseException() as InvalidOperationException;
                Assert.IsNotNull(invalidOperationException);
                Assert.IsTrue(invalidOperationException.Message.Contains("Query contains restricted character :'%'"), "Exception not thrown for special character");
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void CannotStartCustomJobType()
        {
            try
            {
                var mapReduceJobDefinition = new HadoopCustomJobCreationDetails { CustomText = "pig text" };

                TestJobStart(mapReduceJobDefinition);
                Assert.Fail("An exception was expected");
            }
            catch (AggregateException aex)
            {
                Exception inner = aex.InnerExceptions.FirstOrDefault();
                Assert.IsNotNull(inner);
                Assert.IsInstanceOfType(inner, typeof(NotSupportedException));
                Assert.IsTrue(inner.Message.Contains("Cannot start jobDetails of type"));
                Assert.IsTrue(inner.Message.Contains("HadoopCustomJobCreationDetails"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void UserCanSupplyStatusDirectoryForMapReduceJob()
        {
            var mapReduceJobDefinition = new AzureHDInsightMapReduceJobDefinition
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar",
                StatusFolder = "/myoutputfolder"
            };

            AzureHDInsightJob startedJob = TestJobStart(mapReduceJobDefinition);
            Assert.AreEqual(startedJob.StatusDirectory, mapReduceJobDefinition.StatusFolder);
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        private static AzureHDInsightJob TestJobStart(AzureHDInsightJobDefinition mapReduceJobDefinition)
        {
            ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
            IStartAzureHDInsightJobCommand startJobCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateStartJob();
            startJobCommand.Cluster = testCluster.ConnectionUrl;
            startJobCommand.Credential = GetPSCredential(testCluster.HttpUserName, testCluster.HttpPassword);
            startJobCommand.JobDefinition = mapReduceJobDefinition;
            startJobCommand.EndProcessing().Wait();
            AzureHDInsightJob jobCreationResults = startJobCommand.Output.ElementAt(0);
            Assert.IsNotNull(jobCreationResults.JobId, "Should get a non-null jobDetails id");
            Assert.IsNotNull(jobCreationResults.StatusDirectory, "StatusDirectory should be set on jobDetails");
            return jobCreationResults;
        }
    }
}
