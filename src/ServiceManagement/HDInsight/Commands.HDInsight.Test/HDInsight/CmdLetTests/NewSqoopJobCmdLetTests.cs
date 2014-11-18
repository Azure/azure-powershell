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
using System.Management.Automation;
using Microsoft.Hadoop.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class NewSqoopJobCmdLetTests : HDInsightTestCaseBase
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
        [TestCategory("New-AzureHDInsightSqoopJobDefinition")]
        public void ICanCallThe_New_HDInsightSqoopJobDefinitionCmdlet()
        {
            var sqoopJobDefinition = new SqoopJobCreateParameters { Command = "show tables" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightSqoopJobDefinition)
                            .WithParameter(CmdletConstants.Command, sqoopJobDefinition.Command)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightSqoopJobDefinition SqoopJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightSqoopJobDefinition>().First();

                Assert.AreEqual(sqoopJobDefinition.Command, SqoopJobFromPowershell.Command);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightSqoopJobDefinition")]
        public void ICanCallThe_New_HDInsightSqoopJobDefinitionCmdlet_WithFileParameter()
        {
            var sqoopJobDefinition = new SqoopJobCreateParameters { File = TestConstants.WabsProtocolSchemeName + "filepath.hql" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightSqoopJobDefinition)
                            .WithParameter(CmdletConstants.File, sqoopJobDefinition.File)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightSqoopJobDefinition SqoopJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightSqoopJobDefinition>().First();

                Assert.AreEqual(sqoopJobDefinition.File, SqoopJobFromPowershell.File);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightSqoopJobDefinition")]
        [TestCategory("Defect")]
        public void ICanCallThe_New_HDInsightSqoopJobDefinitionCmdlet_WithOutputStorageLocation()
        {
            var sqoopJobDefinition = new SqoopJobCreateParameters { Command = "show tables", StatusFolder = "/tablesList" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightSqoopJobDefinition)
                            .WithParameter(CmdletConstants.Command, sqoopJobDefinition.Command)
                            .WithParameter(CmdletConstants.StatusFolder, sqoopJobDefinition.StatusFolder)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightSqoopJobDefinition SqoopJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightSqoopJobDefinition>().First();

                Assert.AreEqual(sqoopJobDefinition.Command, SqoopJobFromPowershell.Command);
                Assert.AreEqual(sqoopJobDefinition.StatusFolder, SqoopJobFromPowershell.StatusFolder);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightSqoopJobDefinition")]
        public void ICanCallThe_New_HDInsightSqoopJobDefinitionCmdlet_WithResources()
        {
            var sqoopJobDefinition = new SqoopJobCreateParameters { Command = "show tables" };
            sqoopJobDefinition.Files.Add("pidata.txt");
            sqoopJobDefinition.Files.Add("pidate2.txt");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightSqoopJobDefinition)
                            .WithParameter(CmdletConstants.Command, sqoopJobDefinition.Command)
                            .WithParameter(CmdletConstants.Files, sqoopJobDefinition.Files)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightSqoopJobDefinition SqoopJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightSqoopJobDefinition>().First();

                Assert.AreEqual(sqoopJobDefinition.Command, SqoopJobFromPowershell.Command);

                foreach (string file in sqoopJobDefinition.Files)
                {
                    Assert.IsTrue(
                        SqoopJobFromPowershell.Files.Any(arg => string.Equals(file, arg)),
                        "Unable to find File '{0}' in value returned from powershell",
                        file);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightSqoopJobDefinition")]
        public void ICanCallThe_New_HDInsightSqoopJobDefinitionCmdlet_WithoutJobName()
        {
            var sqoopJobDefinition = new SqoopJobCreateParameters { Command = "show tables" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightSqoopJobDefinition)
                            .WithParameter(CmdletConstants.Command, sqoopJobDefinition.Command)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightSqoopJobDefinition SqoopJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightSqoopJobDefinition>().First();

                Assert.AreEqual(sqoopJobDefinition.Command, SqoopJobFromPowershell.Command);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightSqoopJobDefinition")]
        public void ICannotCallThe_New_HDInsightSqoopJobDefinitionCmdlet_WithoutFileOrCommandParameter()
        {
            var sqoopJobDefinition = new SqoopJobCreateParameters { File = TestConstants.WabsProtocolSchemeName + "filepath.hql" };

            try
            {
                using (IRunspace runspace = this.GetPowerShellRunspace())
                {
                    runspace.NewPipeline().AddCommand(CmdletConstants.NewAzureHDInsightSqoopJobDefinition).Invoke();
                    Assert.Fail("test failed.");
                }
            }
            catch (CmdletInvocationException invokeException)
            {
                var psArgumentException = invokeException.GetBaseException() as PSArgumentException;
                Assert.IsNotNull(psArgumentException);
                Assert.AreEqual("Either File or Command should be specified for Sqoop jobs.", psArgumentException.Message);
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
