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
using Microsoft.Azure.Commands.HDInsight.Models.Job;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System.IO;
using System.Management.Automation;

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
            HelpMessage = "The default container name.")]
        public string DefaultContainer { get; set; }

        [Parameter(Position = 3,
            HelpMessage = "The default storage account name.")]
        public string DefaultStorageAccountName { get; set; }

        [Parameter(Position = 4,
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

        [Parameter(HelpMessage = "The type of job output.")]
        public JobDisplayOutputType DisplayOutputType { get; set; }

        #endregion

        private IStorageAccess storageAccess = null;

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            storageAccess = GetDefaultStorageAccess(ResourceGroupName, _clusterName);

            _clusterName = GetClusterConnection(ResourceGroupName, ClusterName);

            string output;
            switch (DisplayOutputType)
            {
                case JobDisplayOutputType.StandardError:
                    output = GetJobError(this.storageAccess);
                    break;
                default:
                    output = GetJobOutput(this.storageAccess);
                    break;
            }
            WriteObject(output);
        }

        internal string GetJobOutput(IStorageAccess storageAccess)
        {
            var output = HDInsightJobClient.GetJobOutput(JobId, storageAccess);
            var outputStr = Convert(output);
            return outputStr;
        }

        internal string GetJobError(IStorageAccess storageAccess)
        {
            var output = HDInsightJobClient.GetJobError(JobId, storageAccess);
            var outputStr = Convert(output);
            return outputStr;
        }

        private static string Convert(Stream stream)
        {
            var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            return text;
        }

        internal IStorageAccess GetDefaultStorageAccess(string resourceGroupName, string clusterName)
        {
            if (DefaultContainer == null && DefaultStorageAccountName == null && DefaultStorageAccountKey == null)
            {
                var DefaultStorageAccount = GetDefaultStorageAccount(resourceGroupName, clusterName);

                DefaultContainer = DefaultStorageAccount.StorageContainerName;
                DefaultStorageAccountName = DefaultStorageAccount.StorageAccountName;
                DefaultStorageAccountKey = DefaultStorageAccount.StorageAccountKey;
            }

            return new AzureStorageAccess(DefaultStorageAccountName, DefaultStorageAccountKey, DefaultContainer);
        }
    }
}
