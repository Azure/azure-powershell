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

using Hyak.Common;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsLifecycle.Invoke,
        Constants.CommandNames.AzureHDInsightHiveJob),
    OutputType(typeof(string))]
    public class InvokeHiveCommand : HDInsightCmdletBase
    {
        private readonly NewAzureHDInsightHiveJobDefinitionCommand hiveJobDefinitionCommand;

        #region Input Parameter Definitions

        [Parameter(HelpMessage = "The hive arguments for the jobDetails.")]
        public string[] Arguments
        {
            get { return hiveJobDefinitionCommand.Arguments; }
            set { hiveJobDefinitionCommand.Arguments = value; }
        }

        [Parameter(HelpMessage = "The files for the jobDetails.")]
        public string[] Files
        {
            get { return hiveJobDefinitionCommand.Files; }
            set { hiveJobDefinitionCommand.Files = value; }
        }

        [Parameter(HelpMessage = "The output location to use for the job.")]
        public string StatusFolder
        {
            get { return hiveJobDefinitionCommand.StatusFolder; }
            set { hiveJobDefinitionCommand.StatusFolder = value; }
        }

        [Parameter(HelpMessage = "The parameters for the jobDetails.")]
        public Hashtable Defines
        {
            get { return hiveJobDefinitionCommand.Defines; }
            set { hiveJobDefinitionCommand.Defines = value; }
        }

        [Parameter(HelpMessage = "The query file to run in the jobDetails.")]
        public string File
        {
            get { return hiveJobDefinitionCommand.File; }
            set { hiveJobDefinitionCommand.File = value; }
        }

        [Parameter(HelpMessage = "The name of the jobDetails.")]
        public string JobName
        {
            get { return hiveJobDefinitionCommand.JobName; }
            set { hiveJobDefinitionCommand.JobName = value; }
        }

        [Parameter(HelpMessage = "The query to run in the jobDetails.")]
        public string Query
        {
            get { return hiveJobDefinitionCommand.Query; }
            set { hiveJobDefinitionCommand.Query = value; }
        }

        [Parameter(HelpMessage = "Run the query as a file.")]
        public SwitchParameter RunAsFileJob
        {
            get { return hiveJobDefinitionCommand.RunAsFileJob; }
            set { hiveJobDefinitionCommand.RunAsFileJob = value; }
        }

        [Parameter(HelpMessage = "The default container name.")]
        public string DefaultContainer { get; set; }

        [Parameter(HelpMessage = "The default storage account name.")]
        public string DefaultStorageAccountName { get; set; }

        [Parameter(HelpMessage = "The default storage account key.")]
        public string DefaultStorageAccountKey { get; set; }

        #endregion

        public InvokeHiveCommand()
        {
            this.hiveJobDefinitionCommand = new NewAzureHDInsightHiveJobDefinitionCommand();
        }

        public override void ExecuteCmdlet()
        {
            //get variables from session
            var clusterConnection = SessionState.PSVariable.Get(UseAzureHDInsightClusterCommand.ClusterEndpoint).Value.ToString();
            var clusterCred =
                (PSCredential)SessionState.PSVariable.Get(UseAzureHDInsightClusterCommand.ClusterCred).Value;
            var resourceGroup =
                SessionState.PSVariable.Get(UseAzureHDInsightClusterCommand.CurrentResourceGroup).Value.ToString();

            _credential = new BasicAuthenticationCloudCredentials
            {
                Username = clusterCred.UserName,
                Password = clusterCred.Password.ConvertToString()
            };

            if (clusterConnection == null || clusterCred == null)
            {
                throw new NullReferenceException(
                    string.Format(
                        "The cluster or resource group specified is null. Please use the Use-AzureRmHDInsightCluster command to connect to a cluster."));
            }

            //get hive job
            var hivejob = hiveJobDefinitionCommand.GetHiveJob();

            //start hive job
            WriteObject("Submitting hive query...");
            var startJobCommand = new StartAzureHDInsightJobCommand
            {
                ClusterName = clusterConnection,
                ResourceGroupName = resourceGroup,
                JobDefinition = hivejob,
                HttpCredential = clusterCred
            };

            var jobCreationResult = startJobCommand.SubmitJob();
            var jobid = jobCreationResult.JobSubmissionJsonResponse.Id;
            WriteObject(string.Format("Submitted Hive query with jobDetails Id : {0}", jobid));

            //wait for job to complete
            WriteProgress(new ProgressRecord(0, "Waiting for job to complete", "In Progress"));
            var waitJobCommand = new WaitAzureHDInsightJobCommand
            {
                HttpCredential = clusterCred,
                ResourceGroupName = resourceGroup,
                ClusterName = clusterConnection,
                JobId = jobid
            };

            var job = waitJobCommand.WaitJob();

            _clusterName = clusterConnection.Substring(0, clusterConnection.IndexOf('.'));

            var getOutputCommand = new GetAzureHDInsightJobOutputCommand
            {
                HttpCredential = clusterCred,
                ResourceGroupName = resourceGroup,
                ClusterName = clusterConnection,
                DefaultContainer = DefaultContainer,
                DefaultStorageAccountName = DefaultStorageAccountName,
                DefaultStorageAccountKey = DefaultStorageAccountKey,
                JobId = jobid
            };

            var storageAccess = getOutputCommand.GetDefaultStorageAccess(resourceGroup, _clusterName);

            string output;
            if (job.ExitValue == 0)
            {
                //get job output
                output = getOutputCommand.GetJobOutput(storageAccess);
            }
            else
            {
                //get job error
                output = getOutputCommand.GetJobError(storageAccess);
            }

            WriteObject(output);
        }
    }
}
