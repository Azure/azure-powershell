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
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    [TestClass]
    public class NewHDInsightPigJobCommandTests : HDInsightTestCaseBase
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
        [TestCategory("New-AzureHDInsightPigJobDefinition")]
        public void CanCreateNewPigDefinition()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load 'passwd' using PigStorage(':'); B = foreach A generate $0 as id;" };

            INewAzureHDInsightPigJobDefinitionCommand newPigJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewPigJobDefinition();
            newPigJobDefinitionCommand.Query = pigJobDefinition.Query;
            newPigJobDefinitionCommand.EndProcessing();

            AzureHDInsightPigJobDefinition pigJobFromCommand = newPigJobDefinitionCommand.Output.ElementAt(0);

            Assert.AreEqual(pigJobDefinition.Query, pigJobFromCommand.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightPigJobDefinition")]
        public void CanCreateNewPigDefinition_WithArguments()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load 'passwd' using PigStorage(':'); B = foreach A generate $0 as id;" };

            pigJobDefinition.Arguments.Add("map.input.tasks=1000");
            pigJobDefinition.Arguments.Add("map.input.reducers=1000");


            INewAzureHDInsightPigJobDefinitionCommand newPigJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewPigJobDefinition();
            newPigJobDefinitionCommand.Query = pigJobDefinition.Query;
            newPigJobDefinitionCommand.Arguments = pigJobDefinition.Arguments.ToArray();
            newPigJobDefinitionCommand.EndProcessing();

            AzureHDInsightPigJobDefinition pigJobFromCommand = newPigJobDefinitionCommand.Output.ElementAt(0);

            Assert.AreEqual(pigJobDefinition.Query, pigJobFromCommand.Query);

            foreach (string parameter in pigJobDefinition.Arguments)
            {
                Assert.IsTrue(
                    pigJobFromCommand.Arguments.Any(arg => string.Equals(parameter, arg)),
                    "Unable to find parameter '{0}' in value returned from command",
                    parameter);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightPigJobDefinition")]
        public void CanCreateNewPigDefinition_WithResources()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load 'passwd' using PigStorage(':'); B = foreach A generate $0 as id;" };
            pigJobDefinition.Files.Add("pidata.txt");
            pigJobDefinition.Files.Add("pidate2.txt");

            INewAzureHDInsightPigJobDefinitionCommand newPigJobDefinitionCommand =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewPigJobDefinition();
            newPigJobDefinitionCommand.Query = pigJobDefinition.Query;
            newPigJobDefinitionCommand.Files = pigJobDefinition.Files.ToArray();
            newPigJobDefinitionCommand.EndProcessing();

            AzureHDInsightPigJobDefinition pigJobFromCommand = newPigJobDefinitionCommand.Output.ElementAt(0);

            Assert.AreEqual(pigJobDefinition.Query, pigJobFromCommand.Query);

            foreach (string resource in pigJobDefinition.Files)
            {
                Assert.IsTrue(
                    pigJobFromCommand.Files.Any(arg => string.Equals(resource, arg)),
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
