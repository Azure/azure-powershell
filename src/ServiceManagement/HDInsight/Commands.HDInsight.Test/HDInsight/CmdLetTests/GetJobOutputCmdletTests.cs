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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class GetJobOutputCmdletTests : HDInsightTestCaseBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Get-AzureHDInsightJobOutput")]
        public void ICanCallThe_Get_HDInsightJobOutputCmdlet()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(testCluster.HttpUserName, testCluster.HttpPassword))
                            .Invoke();
                IEnumerable<AzureHDInsightJob> jobHistory = results.Results.ToEnumerable<AzureHDInsightJob>();

                IPipelineResult outputContent =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.Id, jobHistory.First().JobId)
                            .Invoke();
                string result = outputContent.Results.ToEnumerable<string>().First();
                Assert.IsTrue(result.Length > 0);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Get-AzureHDInsightJobOutput")]
        public void ICanCallThe_Get_HDInsightJobOutputCmdlet_WithStdErrSwitch()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(testCluster.HttpUserName, testCluster.HttpPassword))
                            .Invoke();
                IEnumerable<AzureHDInsightJob> jobHistory = results.Results.ToEnumerable<AzureHDInsightJob>();

                IPipelineResult outputContent =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.Id, jobHistory.First().JobId)
                            .WithParameter(CmdletConstants.StdErr, null)
                            .Invoke();
                string result = outputContent.Results.ToEnumerable<string>().First();
                Assert.IsTrue(result.Length > 0);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Get-AzureHDInsightJobOutput")]
        public void ICanCallThe_Get_HDInsightJobOutputCmdlet_WithTaskLogsSwitch()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(testCluster.HttpUserName, testCluster.HttpPassword))
                            .Invoke();
                IEnumerable<AzureHDInsightJob> jobHistory = results.Results.ToEnumerable<AzureHDInsightJob>();
                DirectoryInfo taskLogsDirectory = Directory.CreateDirectory(Guid.NewGuid().ToString());
                IPipelineResult outputContent =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.JobId, jobHistory.First().JobId)
                            .WithParameter(CmdletConstants.DownloadTaskLogs, null)
                            .WithParameter(CmdletConstants.TaskLogsDirectory, taskLogsDirectory.Name)
                            .Invoke();
                IEnumerable<FileInfo> result = taskLogsDirectory.EnumerateFiles();
                Assert.IsTrue(result.Any());
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Get-AzureHDInsightJobOutput")]
        public void ICanCallThe_Get_HDInsightJobOutputCmdlet_WithTaskSummarySwitch()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(testCluster.HttpUserName, testCluster.HttpPassword))
                            .Invoke();
                IEnumerable<AzureHDInsightJob> jobHistory = results.Results.ToEnumerable<AzureHDInsightJob>();

                IPipelineResult outputContent =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.Id, jobHistory.First().JobId)
                            .WithParameter(CmdletConstants.TaskSummary, null)
                            .Invoke();
                string result = outputContent.Results.ToEnumerable<string>().First();
                Assert.IsTrue(result.Length > 0);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Get-AzureHDInsightJobOutput")]
        public void ICanCallThe_Get_HDInsightJobsCmdlet_WithNonExistantJobId()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
                string jobId = Guid.NewGuid().ToString();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.Id, jobId)
                            .WithParameter(CmdletConstants.StdErr, null)
                            .Invoke();

                Assert.IsTrue(results.Results.ToEnumerable<string>().All(string.IsNullOrEmpty));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]

        [TestCategory("Jobs")]
        [TestCategory("Get-AzureHDInsightJobOutput")]
        public void ICannotCallThe_Get_HDInsightJobOutputCmdlet_WithTaskLogsSwitch_NoDirectory()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                ClusterDetails testCluster = CmdletScenariosTestCaseBase.GetHttpAccessEnabledCluster();
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJob)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(testCluster.HttpUserName, testCluster.HttpPassword))
                            .Invoke();
                IEnumerable<AzureHDInsightJob> jobHistory = results.Results.ToEnumerable<AzureHDInsightJob>();
                try
                {
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.GetAzureHDInsightJobOutput)
                            .WithParameter(CmdletConstants.Cluster, testCluster.Name)
                            .WithParameter(CmdletConstants.Id, jobHistory.First().JobId)
                            .WithParameter(CmdletConstants.DownloadTaskLogs, null)
                            .Invoke();
                    Assert.Fail("test failed");
                }
                catch (CmdletInvocationException invokeException)
                {
                    var argException = invokeException.GetBaseException() as PSArgumentException;
                    Assert.IsNotNull(argException);
                    Assert.AreEqual(argException.ParamName, "taskLogsDirectory");
                    Assert.AreEqual(argException.Message, "Please specify the directory to download logs to.");
                }
            }
        }
    }
}
