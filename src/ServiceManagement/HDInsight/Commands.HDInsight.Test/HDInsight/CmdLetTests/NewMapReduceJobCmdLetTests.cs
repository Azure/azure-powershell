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
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class NewMapReduceJobCmdLetTests : HDInsightTestCaseBase
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
        public void ICanCallThe_New_HDInsightMapReduceJobDefinitionCmdlet()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar",               
            };

            mapReduceJobDefinition.LibJars.Add("some.jarfile.jar");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, mapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.JarFile, mapReduceJobDefinition.JarFile)
                            .WithParameter(CmdletConstants.ClassName, mapReduceJobDefinition.ClassName)
                            .WithParameter(CmdletConstants.LibJars, mapReduceJobDefinition.LibJars)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightMapReduceJobDefinition mapReduceJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightMapReduceJobDefinition>().First();

                Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromPowershell.JobName);
                Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromPowershell.ClassName);
                Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromPowershell.JarFile);
                Assert.AreEqual(mapReduceJobDefinition.LibJars.Count, mapReduceJobFromPowershell.LibJars.Count);
                Assert.AreEqual(mapReduceJobDefinition.LibJars.First(), mapReduceJobFromPowershell.LibJars.First());
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void ICanCallThe_New_HDInsightMapReduceJobDefinitionCmdlet_WithArguments()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };
            mapReduceJobDefinition.Arguments.Add("16");
            mapReduceJobDefinition.Arguments.Add("10000");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, mapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.JarFile, mapReduceJobDefinition.JarFile)
                            .WithParameter(CmdletConstants.ClassName, mapReduceJobDefinition.ClassName)
                            .WithParameter(CmdletConstants.Arguments, mapReduceJobDefinition.Arguments)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightMapReduceJobDefinition mapReduceJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightMapReduceJobDefinition>().First();

                Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromPowershell.JobName);
                Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromPowershell.ClassName);
                Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromPowershell.JarFile);

                foreach (string argument in mapReduceJobDefinition.Arguments)
                {
                    Assert.IsTrue(
                        mapReduceJobFromPowershell.Arguments.Any(arg => string.Equals(argument, arg)),
                        "Unable to find argument '{0}' in value returned from powershell",
                        argument);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void ICanCallThe_New_HDInsightMapReduceJobDefinitionCmdlet_WithLibJars()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };
            mapReduceJobDefinition.LibJars.Add("pidata.jar");
            mapReduceJobDefinition.LibJars.Add("pidate2.jar");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, mapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.JarFile, mapReduceJobDefinition.JarFile)
                            .WithParameter(CmdletConstants.ClassName, mapReduceJobDefinition.ClassName)
                            .WithParameter(CmdletConstants.LibJars, mapReduceJobDefinition.LibJars)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightMapReduceJobDefinition mapReduceJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightMapReduceJobDefinition>().First();

                Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromPowershell.JobName);
                Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromPowershell.ClassName);
                Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromPowershell.JarFile);

                foreach (string libjar in mapReduceJobDefinition.LibJars)
                {
                    Assert.IsTrue(
                        mapReduceJobFromPowershell.LibJars.Any(arg => string.Equals(libjar, arg)),
                        "Unable to find LibJar '{0}' in value returned from powershell",
                        libjar);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void ICanCallThe_New_HDInsightMapReduceJobDefinitionCmdlet_WithOutputStorageLocation()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar",
                StatusFolder = "/pilogs"
            };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, mapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.JarFile, mapReduceJobDefinition.JarFile)
                            .WithParameter(CmdletConstants.ClassName, mapReduceJobDefinition.ClassName)
                            .WithParameter(CmdletConstants.StatusFolder, mapReduceJobDefinition.StatusFolder)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightMapReduceJobDefinition mapReduceJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightMapReduceJobDefinition>().First();

                Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromPowershell.JobName);
                Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromPowershell.ClassName);
                Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromPowershell.JarFile);
                Assert.AreEqual(mapReduceJobDefinition.StatusFolder, mapReduceJobFromPowershell.StatusFolder);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void ICanCallThe_New_HDInsightMapReduceJobDefinitionCmdlet_WithParameters()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };

            mapReduceJobDefinition.Defines.Add("map.input.tasks", "1000");
            mapReduceJobDefinition.Defines.Add("map.input.reducers", "1000");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, mapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.JarFile, mapReduceJobDefinition.JarFile)
                            .WithParameter(CmdletConstants.ClassName, mapReduceJobDefinition.ClassName)
                            .WithParameter(CmdletConstants.Parameters, mapReduceJobDefinition.Defines)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightMapReduceJobDefinition mapReduceJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightMapReduceJobDefinition>().First();

                Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromPowershell.JobName);
                Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromPowershell.ClassName);
                Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromPowershell.JarFile);

                foreach (var parameter in mapReduceJobDefinition.Defines)
                {
                    Assert.IsTrue(
                        mapReduceJobFromPowershell.Defines.Any(
                            arg => string.Equals(parameter.Key, arg.Key) && string.Equals(parameter.Value, arg.Value)),
                        "Unable to find parameter '{0}' in value returned from powershell",
                        parameter.Key);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void ICanCallThe_New_HDInsightMapReduceJobDefinitionCmdlet_WithResources()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                JobName = "pi estimation jobDetails",
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };
            mapReduceJobDefinition.Files.Add("pidata.txt");
            mapReduceJobDefinition.Files.Add("pidate2.txt");

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JobName, mapReduceJobDefinition.JobName)
                            .WithParameter(CmdletConstants.JarFile, mapReduceJobDefinition.JarFile)
                            .WithParameter(CmdletConstants.ClassName, mapReduceJobDefinition.ClassName)
                            .WithParameter(CmdletConstants.Files, mapReduceJobDefinition.Files)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightMapReduceJobDefinition mapReduceJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightMapReduceJobDefinition>().First();

                Assert.AreEqual(mapReduceJobDefinition.JobName, mapReduceJobFromPowershell.JobName);
                Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromPowershell.ClassName);
                Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromPowershell.JarFile);

                foreach (string file in mapReduceJobDefinition.Files)
                {
                    Assert.IsTrue(
                        mapReduceJobFromPowershell.Files.Any(arg => string.Equals(file, arg)),
                        "Unable to find File '{0}' in value returned from powershell",
                        file);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        
        [TestCategory("Jobs")]
        [TestCategory("New-AzureHDInsightMapReduceJobDefinition")]
        public void ICanCallThe_New_HDInsightMapReduceJobDefinitionCmdlet_WithoutJobName()
        {
            var mapReduceJobDefinition = new MapReduceJobCreateParameters
            {
                ClassName = "pi",
                JarFile = TestConstants.WabsProtocolSchemeName + "container@hostname/examples.jar"
            };

            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightMapReduceJobDefinition)
                            .WithParameter(CmdletConstants.JarFile, mapReduceJobDefinition.JarFile)
                            .WithParameter(CmdletConstants.ClassName, mapReduceJobDefinition.ClassName)
                            .Invoke();
                Assert.AreEqual(1, results.Results.Count);
                AzureHDInsightMapReduceJobDefinition mapReduceJobFromPowershell =
                    results.Results.ToEnumerable<AzureHDInsightMapReduceJobDefinition>().First();

                Assert.AreEqual(mapReduceJobDefinition.ClassName, mapReduceJobFromPowershell.ClassName);
                Assert.AreEqual(mapReduceJobDefinition.JarFile, mapReduceJobFromPowershell.JarFile);
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
