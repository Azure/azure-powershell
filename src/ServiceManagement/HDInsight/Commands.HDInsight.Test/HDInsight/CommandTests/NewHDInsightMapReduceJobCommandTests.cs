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
    public class NewHDInsightMapReduceJobCommandTests : HDInsightTestCaseBase
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
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void CanCreateNewMapReduceDefinition()
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

            Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromCommand.JobName);
            Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromCommand.ClassName);
            Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromCommand.JarFile);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void CanCreateNewMapReduceDefinition_WithArguments()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };
            mapReduceJobDefinition.Arguments.Add("16");
            mapReduceJobDefinition.Arguments.Add("10000");

            INewAzureHDInsightMapReduceJobDefinitionCommand newMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewMapReduceDefinition();
            newMapReduceJobDefinitionCommand.JobName = mapReduceJobDefinition.JobName;
            newMapReduceJobDefinitionCommand.JarFile = mapReduceJobDefinition.JarFile;
            newMapReduceJobDefinitionCommand.ClassName = mapReduceJobDefinition.ClassName;
            newMapReduceJobDefinitionCommand.Arguments = mapReduceJobDefinition.Arguments.ToArray();
            newMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightMapReduceJobDefinition mapReduceJobFromCommand = newMapReduceJobDefinitionCommand.Output.ElementAt(0);

            Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromCommand.JobName);
            Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromCommand.ClassName);
            Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromCommand.JarFile);

            foreach (string argument in mapReduceJobDefinition.Arguments)
            {
                Assert.IsTrue(
                    mapReduceJobFromCommand.Arguments.Any(arg => string.Equals(argument, arg)),
                    "Unable to find argument '{0}' in value returned from command",
                    argument);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void CanCreateNewMapReduceDefinition_WithLibJars()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };
            mapReduceJobDefinition.LibJars.Add("pidata.jar");
            mapReduceJobDefinition.LibJars.Add("pidata2.jar");

            INewAzureHDInsightMapReduceJobDefinitionCommand newMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewMapReduceDefinition();
            newMapReduceJobDefinitionCommand.JobName = mapReduceJobDefinition.JobName;
            newMapReduceJobDefinitionCommand.JarFile = mapReduceJobDefinition.JarFile;
            newMapReduceJobDefinitionCommand.ClassName = mapReduceJobDefinition.ClassName;
            newMapReduceJobDefinitionCommand.LibJars = mapReduceJobDefinition.LibJars.ToArray();
            newMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightMapReduceJobDefinition mapReduceJobFromCommand = newMapReduceJobDefinitionCommand.Output.ElementAt(0);

            Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromCommand.JobName);
            Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromCommand.ClassName);
            Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromCommand.JarFile);

            foreach (string libjar in mapReduceJobDefinition.LibJars)
            {
                Assert.IsTrue(
                    mapReduceJobFromCommand.LibJars.Any(arg => string.Equals(libjar, arg)),
                    "Unable to find LibJar '{0}' in value returned from command",
                    libjar);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void CanCreateNewMapReduceDefinition_WithParameters()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };

            mapReduceJobDefinition.Defines.Add("map.input.tasks", "1000");
            mapReduceJobDefinition.Defines.Add("map.input.reducers", "1000");


            INewAzureHDInsightMapReduceJobDefinitionCommand newMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewMapReduceDefinition();
            newMapReduceJobDefinitionCommand.JobName = mapReduceJobDefinition.JobName;
            newMapReduceJobDefinitionCommand.JarFile = mapReduceJobDefinition.JarFile;
            newMapReduceJobDefinitionCommand.ClassName = mapReduceJobDefinition.ClassName;
            foreach (var define in mapReduceJobDefinition.Defines)
            {
                newMapReduceJobDefinitionCommand.Defines.Add(define.Key, define.Value);
            }

            newMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightMapReduceJobDefinition mapReduceJobFromCommand = newMapReduceJobDefinitionCommand.Output.ElementAt(0);

            Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromCommand.JobName);
            Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromCommand.ClassName);
            Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromCommand.JarFile);

            foreach (var parameter in mapReduceJobDefinition.Defines)
            {
                Assert.IsTrue(
                    mapReduceJobFromCommand.Defines.Any(arg => string.Equals(parameter.Key, arg.Key) && string.Equals(parameter.Value, arg.Value)),
                    "Unable to find parameter '{0}' in value returned from command",
                    parameter.Key);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void CanCreateNewMapReduceDefinition_WithResources()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };
            mapReduceJobDefinition.Files.Add("pidata.txt");
            mapReduceJobDefinition.Files.Add("pidate2.txt");

            INewAzureHDInsightMapReduceJobDefinitionCommand newMapReduceJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewMapReduceDefinition();
            newMapReduceJobDefinitionCommand.JobName = mapReduceJobDefinition.JobName;
            newMapReduceJobDefinitionCommand.JarFile = mapReduceJobDefinition.JarFile;
            newMapReduceJobDefinitionCommand.ClassName = mapReduceJobDefinition.ClassName;
            newMapReduceJobDefinitionCommand.Files = mapReduceJobDefinition.Files.ToArray();
            newMapReduceJobDefinitionCommand.EndProcessing();

            AzureHDInsightMapReduceJobDefinition mapReduceJobFromCommand = newMapReduceJobDefinitionCommand.Output.ElementAt(0);

            Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromCommand.JobName);
            Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromCommand.ClassName);
            Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromCommand.JarFile);

            foreach (string resource in mapReduceJobDefinition.Files)
            {
                Assert.IsTrue(
                    mapReduceJobFromCommand.Files.Any(arg => string.Equals(resource, arg)),
                    "Unable to find File '{0}' in value returned from command",
                    resource);
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
