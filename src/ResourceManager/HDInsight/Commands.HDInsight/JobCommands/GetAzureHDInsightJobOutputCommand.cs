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

using System.IO;
using System.Management.Automation;
using Hyak.Common;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models.Job;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsCommon.Get,
        Constants.CommandNames.AzureHDInsightJobOutput),
    OutputType(typeof(string))]
    public class GetAzureHDInsightJobOutputCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the cluster.")]
        public string ClusterName
        {
            get { return _clusterName; }
            set { _clusterName = value; }
        }

        [Parameter(Position = 1,
            Mandatory = true,
            HelpMessage = "The JobID of the jobDetails to stop.")]
        public string JobId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "The default container name.")]
        public string DefaultContainer { get; set; }

        [Parameter(Position = 3,
            Mandatory = true, 
            HelpMessage = "The default storage account name.")]
        public string DefaultStorageAccountName { get; set; }

        [Parameter(Position = 4,
            Mandatory = true, 
            HelpMessage = "The default storage account key.")]
        public string DefaultStorageAccountKey { get; set; }

        [Parameter(Mandatory = true,
            Position = 5,
            HelpMessage = "The credentials with which to connect to the cluster.")]
        [Alias("ClusterCredential")]
        public PSCredential HttpCredential
        {
            get
            {
                return _credential == null ? null : new PSCredential(_credential.Username, _credential.Password.ConvertToSecureString());
            }
            set
            {
                _credential = new BasicAuthenticationCloudCredentials
                {
                    Username = value.UserName,
                    Password = value.Password.ConvertToString()
                };
            }
        }

        [Parameter(HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        [Parameter(HelpMessage = "The type of job output.", ParameterSetName = "Display")]
        public JobDisplayOutputType DisplayOutputType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The type of output to download.", ParameterSetName = "Download")]
        public JobDownloadOutputType DownloadOutputType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The folder to save the output to.", ParameterSetName = "Download")]
        public string Folder { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }
            _clusterName = GetClusterConnection(ResourceGroupName, ClusterName);

            if (ParameterSetName == "Display")
            {
                string output;
                switch (DisplayOutputType)
                {
                    case JobDisplayOutputType.StandardError:
                        output = GetJobError();
                        break;
                    case JobDisplayOutputType.TaskSummary:
                        output = GetJobTaskLogSummary();
                        break;
                    default:
                        output = GetJobOutput();
                        break;
                }
                WriteObject(output);
            }
            else
            {
                DownloadJobTaskLogs();
            }
        }
        
        internal string GetJobOutput()
        {
            var output = HDInsightJobClient.GetJobOutput(JobId, DefaultStorageAccountName, DefaultStorageAccountKey, DefaultContainer);
            var outputStr = Convert(output);
            return outputStr;
        }

        private string GetJobError()
        {
            var output = HDInsightJobClient.GetJobError(JobId, DefaultStorageAccountName, DefaultStorageAccountKey,
                DefaultContainer);
            var outputStr = Convert(output);
            return outputStr;
        }

        private string GetJobTaskLogSummary()
        {
            var output = HDInsightJobClient.GetJobTaskLogSummary(JobId, DefaultStorageAccountName, DefaultStorageAccountKey,
                DefaultContainer);
            var outputStr = Convert(output);
            return outputStr;
        }

        private void DownloadJobTaskLogs()
        {
            HDInsightJobClient.GetJobTaskLogSummary(JobId, DefaultStorageAccountName, DefaultStorageAccountKey,
                DefaultContainer);
        }

        private static string Convert(Stream stream)
        {
            var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            return text;
        }
    }
}
