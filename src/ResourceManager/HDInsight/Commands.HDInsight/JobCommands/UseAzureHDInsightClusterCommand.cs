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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsOther.Use,
        Constants.CommandNames.AzureHDInsightCluster),
    OutputType(typeof(string))]
    public class UseAzureHDInsightClusterCommand : HDInsightCmdletBase
    {
        internal const string CurrentCluster = "CurrentHDInsightCluster";
        internal const string ClusterEndpoint = "CurrentHDInsightClusterEndpoint";
        internal const string ClusterCred = "CurrentHDInsightClusterCredential";
        internal const string CurrentResourceGroup = "CurrentHDInsightResourceGroup";

        #region Input Parameter Definitions

        [Parameter(
             Position = 0,
             Mandatory = true,
             HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The credentials with which to connect to the cluster.")]
        [Alias("ClusterCredential")]
        public PSCredential HttpCredential
        {
            get
            {
                return _credential == null
                    ? null
                    : new PSCredential(_credential.Username, _credential.Password.ConvertToSecureString());
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

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            var httpEndpoint = GetClusterConnection(ResourceGroupName, ClusterName);

            SessionState.PSVariable.Set(ClusterEndpoint, httpEndpoint);
            SessionState.PSVariable.Set(ClusterCred, HttpCredential);
            SessionState.PSVariable.Set(CurrentResourceGroup, ResourceGroupName);

            WriteObject(string.Format("Successfully connected to cluster {0} in resource group {1}", ClusterName,
                ResourceGroupName));
        }
    }
}
