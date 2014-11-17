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
    public class NewPigJobCmdLetTests : HDInsightTestCaseBase
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
        public void ICanCallThe_New_HDInsightPigJobDefinitionCmdlet()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load 'passwd' using PigStorage(':'); B = foreach A generate $0 as id;" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightPigJobDefinition)
                            .WithParameter(CmdletConstants.Query, pigJobDefinition.Query)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightPigJobDefinition pigJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightPigJobDefinition>().First();

                Assert.AreEqual(pigJobDefinition.Query, pigJobFromPowershell.Query);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightPigJobDefinition")]
        public void ICanCallThe_New_HDInsightPigJobDefinitionCmdlet_WithArguments()
        {
            var pigJobDefinition = new PigJobCreateParameters { File = TestConstants.WabsProtocolSchemeName + "container@accountname/pigquery.q" };

            pigJobDefinition.Arguments.Add("map.input.tasks=1000");
            pigJobDefinition.Arguments.Add("map.input.reducers=1000");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightPigJobDefinition)
                            .WithParameter(CmdletConstants.File, pigJobDefinition.File)
                            .WithParameter(CmdletConstants.Arguments, pigJobDefinition.Arguments)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightPigJobDefinition pigJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightPigJobDefinition>().First();

                Assert.AreEqual(pigJobDefinition.File, pigJobFromPowershell.File);

                foreach (string argument in pigJobDefinition.Arguments)
                {
                    Assert.IsTrue(
                        pigJobFromPowershell.Arguments.Any(arg => string.Equals(argument, arg)),
                        string.Format("Unable to find parameter '{0}' in value returned from powershell", argument));
                }
            }
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightPigJobDefinition")]
        public void ICanCallThe_New_HDInsightPigJobDefinitionCmdlet_WithOutputStorageLocation()
        {
            var pigJobDefinition = new PigJobCreateParameters
            {
                Query = "load 'passwd' using PigStorage(':'); B = foreach A generate $0 as id;",
                StatusFolder = "/passwordlogs"
            };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightPigJobDefinition)
                            .WithParameter(CmdletConstants.Query, pigJobDefinition.Query)
                            .WithParameter(CmdletConstants.StatusFolder, pigJobDefinition.StatusFolder)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightPigJobDefinition pigJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightPigJobDefinition>().First();

                Assert.AreEqual(pigJobDefinition.Query, pigJobFromPowershell.Query);
                Assert.AreEqual(pigJobDefinition.StatusFolder, pigJobFromPowershell.StatusFolder);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightPigJobDefinition")]
        public void ICanCallThe_New_HDInsightPigJobDefinitionCmdlet_WithQueryFile()
        {
            var pigJobDefinition = new PigJobCreateParameters { File = TestConstants.WabsProtocolSchemeName + "container@accountname/pigquery.q" };

            pigJobDefinition.Arguments.Add("map.input.tasks=1000");
            pigJobDefinition.Arguments.Add("map.input.reducers=1000");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightPigJobDefinition)
                            .WithParameter(CmdletConstants.File, pigJobDefinition.File)
                            .WithParameter(CmdletConstants.Arguments, pigJobDefinition.Arguments)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightPigJobDefinition pigJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightPigJobDefinition>().First();

                Assert.AreEqual(pigJobDefinition.File, pigJobFromPowershell.File);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightPigJobDefinition")]
        public void ICanCallThe_New_HDInsightPigJobDefinitionCmdlet_WithResources()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load 'passwd' using PigStorage(':'); B = foreach A generate $0 as id;" };
            pigJobDefinition.Files.Add("pidata.txt");
            pigJobDefinition.Files.Add("pidate2.txt");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightPigJobDefinition)
                            .WithParameter(CmdletConstants.Query, pigJobDefinition.Query)
                            .WithParameter(CmdletConstants.Files, pigJobDefinition.Files)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightPigJobDefinition pigJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightPigJobDefinition>().First();

                Assert.AreEqual(pigJobDefinition.Query, pigJobFromPowershell.Query);

                foreach (string file in pigJobDefinition.Files)
                {
                    Assert.IsTrue(
                        pigJobFromPowershell.Files.Any(arg => string.Equals(file, arg)),
                        "Unable to find File '{0}' in value returned from powershell",
                        file);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightPigJobDefinition")]
        public void ICanCallThe_New_HDInsightPigJobDefinitionCmdlet_WithoutJobName()
        {
            var pigJobDefinition = new PigJobCreateParameters { Query = "load 'passwd' using PigStorage(':'); B = foreach A generate $0 as id;" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightPigJobDefinition)
                            .WithParameter(CmdletConstants.Query, pigJobDefinition.Query)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightPigJobDefinition pigJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightPigJobDefinition>().First();

                Assert.AreEqual(pigJobDefinition.Query, pigJobFromPowershell.Query);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightHiveJobDefinition")]
        public void ICannotCallThe_New_HDInsightPigJobDefinitionCmdlet_WithoutFileOrQueryParameter()
        {
            try
            {
                using (IRunspace runspace = this.GetPowerShellRunspace())
                {
                    runspace.NewPipeline().AddCommand(CmdletConstants.NewAzureHDInsightPigJobDefinition).Invoke();
                    Assert.Fail("test failed.");
                }
            }
            catch (CmdletInvocationException invokeException)
            {
                var psArgumentException = invokeException.GetBaseException() as PSArgumentException;
                Assert.IsNotNull(psArgumentException);
                Assert.AreEqual("Either File or Query should be specified for Pig jobs.", psArgumentException.Message);
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
