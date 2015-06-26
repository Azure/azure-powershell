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
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsCommon.Get,
        Constants.CommandNames.AzureHDInsightJobOutput),
    OutputType(typeof(string))]
    public class GetAzureHDInsightJobOutputCommand : HDInsightCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the cluster.")]
        public string ClusterName
        {
            get { return _clusterName; }
            set { _clusterName = value; }
        }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "The JobID of the jobDetails to stop.")]
        public string JobId { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            HelpMessage = "The default container name.")]
        public string DefaultContainer { get; set; }

        [Parameter(Position = 4,
            Mandatory = true, 
            HelpMessage = "The default storage account name.")]
        public string DefaultStorageAccountName { get; set; }

        [Parameter(Position = 5,
            Mandatory = true, 
            HelpMessage = "The default storage account key.")]
        public string DefaultStorageAccountKey { get; set; }

        [Parameter(Mandatory = true,
            Position = 6,
            HelpMessage = "The credentials with which to connect to the cluster.")]
        public PSCredential ClusterCredential
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

        public override void ExecuteCmdlet()
        {
            _clusterName = GetClusterConnection(ResourceGroupName, ClusterName);
            var output = GetJobOutput();
            WriteObject(output);
        }

        public string GetJobOutput()
        {
            var output = HDInsightJobClient.GetJobOutput(JobId, DefaultStorageAccountName, DefaultStorageAccountKey, DefaultContainer);
            var outputStr = Convert(output);
            return outputStr;
        }

        private static string Convert(Stream stream)
        {
            var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            return text;
        }
    }
}
