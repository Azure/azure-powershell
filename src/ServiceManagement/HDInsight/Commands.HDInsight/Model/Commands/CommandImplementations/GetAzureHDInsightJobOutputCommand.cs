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

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    internal class GetAzureHDInsightJobOutputCommand : AzureHDInsightJobCommand<Stream>, IGetAzureHDInsightJobOutputCommand
    {
        private const string TaskLogDownloadCompleteTemplate = "Task logs for jobDetails {0} were Successfully downloaded to {1}";

        public GetAzureHDInsightJobOutputCommand()
        {
            this.OutputType = JobOutputType.StandardOutput;
        }

        /// <inheritdoc />
        public JobOutputType OutputType { get; set; }

        /// <inheritdoc />
        public string TaskLogsDirectory { get; set; }

        /// <inheritdoc />
        public override Task EndProcessing()
        {
            return this.GetJobOutput(this.JobId);
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
            Justification = "The only stream we're not disposing is created when the task logs are downloaded.")]
        private async Task GetJobOutput(string jobId)
        {
            this.JobId.ArgumentNotNullOrEmpty("jobId");
            Stream outputStream = null;

            IJobSubmissionClient hadoopClient = this.GetClient(this.Cluster);
            switch (this.OutputType)
            {
                case JobOutputType.StandardError:
                    outputStream = await hadoopClient.GetJobErrorLogsAsync(jobId);
                    break;
                case JobOutputType.StandardOutput:
                    outputStream = await hadoopClient.GetJobOutputAsync(jobId);
                    break;
                case JobOutputType.TaskSummary:
                    outputStream = await hadoopClient.GetJobTaskLogSummaryAsync(jobId);
                    break;
                case JobOutputType.TaskLogs:
                    this.TaskLogsDirectory.ArgumentNotNullOrEmpty("TaskLogsDirectory");
                    await hadoopClient.DownloadJobTaskLogsAsync(jobId, this.TaskLogsDirectory);
                    var messageStream = new MemoryStream();
                    string downloadCompleteMessage = string.Format(
                        CultureInfo.InvariantCulture, TaskLogDownloadCompleteTemplate, this.JobId, this.TaskLogsDirectory);
                    byte[] messageBytes = Encoding.UTF8.GetBytes(downloadCompleteMessage);
                    messageStream.Write(messageBytes, 0, messageBytes.Length);
                    messageStream.Seek(0, SeekOrigin.Begin);
                    outputStream = messageStream;
                    break;
            }

            this.Output.Add(outputStream);
        }
    }
}
