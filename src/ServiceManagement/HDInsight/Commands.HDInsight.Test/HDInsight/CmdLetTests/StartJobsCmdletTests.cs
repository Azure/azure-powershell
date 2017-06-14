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

using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class StarttJobsCmdletTests : StartJobsCmdletTestCaseBase
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
        public override void ICanCallThe_NewHiveJob_Then_Start_HDInsightJobsCmdlet()
        {
            base.ICanCallThe_NewHiveJob_Then_Start_HDInsightJobsCmdlet();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public override void ICanCallThe_NewMapReduceJob_Then_Start_HDInsightJobsCmdlet()
        {
            base.ICanCallThe_NewMapReduceJob_Then_Start_HDInsightJobsCmdlet();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public override void ICanCallThe_NewPigJob_Then_Start_HDInsightJobsCmdlet()
        {
            base.ICanCallThe_NewPigJob_Then_Start_HDInsightJobsCmdlet();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public override void ICanCallThe_NewSqoopJob_Then_Start_HDInsightJobsCmdlet()
        {
            base.ICanCallThe_NewSqoopJob_Then_Start_HDInsightJobsCmdlet();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public override void ICanCallThe_NewStreamingJob_Then_Start_HDInsightJobsCmdlet()
        {
            base.ICanCallThe_NewStreamingJob_Then_Start_HDInsightJobsCmdlet();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public override void ICanCallThe_Start_HDInsightJobsCmdlet()
        {
            base.ICanCallThe_Start_HDInsightJobsCmdlet();
        }


        //[TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public void ICanCallThe_Start_HDInsightJobsCmdlet_WithDebug()
        {
            var mapReduceJobDefinition = new AzureHDInsightMapReduceJobDefinition
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                string expectedLogMessage = string.Format(CultureInfo.InvariantCulture, "Starting jobDetails '{0}'.", mapReduceJobDefinition.JobName);
                RunJobInPowershell(
                    runspace, mapReduceJobDefinition, CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster(), true, expectedLogMessage);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("Start-AzureHDInsightJob")]
        public override void ICanCallThe_Start_HDInsightJobsCmdlet_WithoutName()
        {
            base.ICanCallThe_Start_HDInsightJobsCmdlet_WithoutName();
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
