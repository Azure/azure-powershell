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
    public class NewHiveJobCmdLetTests : HDInsightTestCaseBase
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
        [TestCategory("New-AzureHDInsightHiveJobDefinition")]
        public void ICanCallThe_New_HDInsightHiveJobDefinitionCmdlet()
        {
            var HiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, HiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, HiveJobDefinition.Query)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightHiveJobDefinition HiveJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightHiveJobDefinition>().First();

                Assert.AreEqual(HiveJobDefinition.JobName, HiveJobFromPowershell.JobName);
                Assert.AreEqual(HiveJobDefinition.Query, HiveJobFromPowershell.Query);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightHiveJobDefinition")]
        public void ICanCallThe_New_HDInsightHiveJobDefinitionCmdlet_WithArguments()
        {
            var HiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables" };
            HiveJobDefinition.Arguments.Add("arg 1");
            HiveJobDefinition.Arguments.Add("arg 2");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, HiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, HiveJobDefinition.Query)
                            .WithParameter(CmdletConstants.HiveArgs, HiveJobDefinition.Arguments)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightHiveJobDefinition HiveJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightHiveJobDefinition>().First();

                Assert.AreEqual(HiveJobDefinition.JobName, HiveJobFromPowershell.JobName);
                Assert.AreEqual(HiveJobDefinition.Query, HiveJobFromPowershell.Query);

                foreach (string args in HiveJobDefinition.Arguments)
                {
                    Assert.IsTrue(
                        HiveJobFromPowershell.Arguments.Any(arg => string.Equals(args, arg)),
                        "Unable to find argument '{0}' in value returned from powershell",
                        args);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightHiveJobDefinition")]
        public void ICanCallThe_New_HDInsightHiveJobDefinitionCmdlet_WithFileParameter()
        {
            var HiveJobDefinition = new HiveJobCreateParameters
            {
                JobName = "show tables jobDetails",
                File = TestConstants.WabsProtocolSchemeName + "filepath.hql"
            };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, HiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.File, HiveJobDefinition.File)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightHiveJobDefinition HiveJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightHiveJobDefinition>().First();

                Assert.AreEqual(HiveJobDefinition.JobName, HiveJobFromPowershell.JobName);
                Assert.AreEqual(HiveJobDefinition.File, HiveJobFromPowershell.File);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightHiveJobDefinition")]
        [TestCategory("Defect")]
        public void ICanCallThe_New_HDInsightHiveJobDefinitionCmdlet_WithOutputStorageLocation()
        {
            var HiveJobDefinition = new HiveJobCreateParameters
            {
                JobName = "show tables jobDetails",
                Query = "show tables",
                StatusFolder = "/tablesList"
            };

            HiveJobDefinition.Defines.Add("map.input.tasks", "1000");
            HiveJobDefinition.Defines.Add("map.input.reducers", "1000");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, HiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, HiveJobDefinition.Query)
                            .WithParameter(CmdletConstants.Parameters, HiveJobDefinition.Defines)
                            .WithParameter(CmdletConstants.StatusFolder, HiveJobDefinition.StatusFolder)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightHiveJobDefinition HiveJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightHiveJobDefinition>().First();

                Assert.AreEqual(HiveJobDefinition.JobName, HiveJobFromPowershell.JobName);
                Assert.AreEqual(HiveJobDefinition.Query, HiveJobFromPowershell.Query);
                Assert.AreEqual(HiveJobDefinition.StatusFolder, HiveJobFromPowershell.StatusFolder);

                foreach (var parameter in HiveJobDefinition.Defines)
                {
                    Assert.IsTrue(
                        HiveJobFromPowershell.Defines.Any(arg => string.Equals(parameter.Key, arg.Key) && string.Equals(parameter.Value, arg.Value)),
                        "Unable to find parameter '{0}' in value returned from powershell",
                        parameter.Key);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightHiveJobDefinition")]
        public void ICanCallThe_New_HDInsightHiveJobDefinitionCmdlet_WithParameters()
        {
            var HiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables" };

            HiveJobDefinition.Defines.Add("map.input.tasks", "1000");
            HiveJobDefinition.Defines.Add("map.input.reducers", "1000");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, HiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, HiveJobDefinition.Query)
                            .WithParameter(CmdletConstants.Parameters, HiveJobDefinition.Defines)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightHiveJobDefinition HiveJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightHiveJobDefinition>().First();

                Assert.AreEqual(HiveJobDefinition.JobName, HiveJobFromPowershell.JobName);
                Assert.AreEqual(HiveJobDefinition.Query, HiveJobFromPowershell.Query);

                foreach (var parameter in HiveJobDefinition.Defines)
                {
                    Assert.IsTrue(
                        HiveJobFromPowershell.Defines.Any(arg => string.Equals(parameter.Key, arg.Key) && string.Equals(parameter.Value, arg.Value)),
                        "Unable to find parameter '{0}' in value returned from powershell",
                        parameter.Key);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightHiveJobDefinition")]
        public void ICanCallThe_New_HDInsightHiveJobDefinitionCmdlet_WithResources()
        {
            var HiveJobDefinition = new HiveJobCreateParameters { JobName = "show tables jobDetails", Query = "show tables" };
            HiveJobDefinition.Files.Add("pidata.txt");
            HiveJobDefinition.Files.Add("pidate2.txt");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, HiveJobDefinition.JobName)
                            .WithParameter(CmdletConstants.Query, HiveJobDefinition.Query)
                            .WithParameter(CmdletConstants.Files, HiveJobDefinition.Files)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightHiveJobDefinition HiveJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightHiveJobDefinition>().First();

                Assert.AreEqual(HiveJobDefinition.JobName, HiveJobFromPowershell.JobName);
                Assert.AreEqual(HiveJobDefinition.Query, HiveJobFromPowershell.Query);

                foreach (string file in HiveJobDefinition.Files)
                {
                    Assert.IsTrue(
                        HiveJobFromPowershell.Files.Any(arg => string.Equals(file, arg)),
                        "Unable to find File '{0}' in value returned from powershell",
                        file);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightHiveJobDefinition")]
        public void ICanCallThe_New_HDInsightHiveJobDefinitionCmdlet_WithoutJobName()
        {
            var HiveJobDefinition = new HiveJobCreateParameters { Query = "show tables" };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.Query, HiveJobDefinition.Query)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightHiveJobDefinition HiveJobFromPowershell = results.Results.ToEnumerable<AzureHDInsightHiveJobDefinition>().First();

                Assert.AreEqual(HiveJobDefinition.Query, HiveJobFromPowershell.Query);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightHiveJobDefinition")]
        public void ICannotCallThe_New_HDInsightHiveJobDefinitionCmdlet_WithoutFileOrQueryParameter()
        {
            var HiveJobDefinition = new HiveJobCreateParameters
            {
                JobName = "show tables jobDetails",
                File = TestConstants.WabsProtocolSchemeName + "filepath.hql"
            };

            try
            {
                using (IRunspace runspace = this.GetPowerShellRunspace())
                {
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightHiveJobDefinition)
                            .WithParameter(CmdletConstants.JobName, HiveJobDefinition.JobName)
                            .Invoke();
                    Assert.Fail("test failed.");
                }
            }
            catch (CmdletInvocationException invokeException)
            {
                var psArgumentException = invokeException.GetBaseException() as PSArgumentException;
                Assert.IsNotNull(psArgumentException);
                Assert.AreEqual("Either File or Query should be specified for Hive jobs.", psArgumentException.Message);
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
