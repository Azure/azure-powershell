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
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Runtime.InteropServices;
using Hyak.Common;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsOther.Use,
        Constants.CommandNames.AzureHDInsightCluster),
    OutputType(typeof(string))]
    public class UseAzureHDInsightClusterCommand : HDInsightCmdletBase
    {
        internal const string CurrentCluster = "CurrentHDInsightCluster";
        internal const string ClusterEndpoint = "CurrentHDInsightClusterEndpoint";
        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the resource group.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName
        {
            get { return _clusterName; }
            set { _clusterName = value; }
        }

        #endregion


        public override void ExecuteCmdlet()
        {
            var cluster = HDInsightManagementClient.GetCluster(ResourceGroupName, ClusterName);
            if (cluster.First() == null)
            {
                throw new NullReferenceException(string.Format("Could not find cluster {0} in resource group {1}", ClusterName, ResourceGroupName));
            }
            var azurecluster = new AzureHDInsightCluster(cluster.First());
            var state = azurecluster.ClusterState;
            if (!(state.Equals("Running", StringComparison.OrdinalIgnoreCase) || state.Equals("Operational", StringComparison.OrdinalIgnoreCase)))
            {
                throw new NotSupportedException(
                    string.Format("The cluster {0} is in the {1} state and canot be used at this time.", ClusterName,
                        state));
            }

            var httpEndpoint = azurecluster.HttpEndpoint;
            if (httpEndpoint == null)
            {
                throw new NotSupportedException(
                    string.Format(
                        "Cannot use cluster {0} because HTTP is not enabled on it. Please use the {1} cmdlet to HTTP and try again.",
                        azurecluster.Name, "Grant-" + Constants.CommandNames.AzureHDInsightHttpServicesAccess));
            }

            SessionState.PSVariable.Set(CurrentCluster, ClusterName);
            SessionState.PSVariable.Set(ClusterEndpoint, httpEndpoint);

            WriteObject(string.Format("Successfully connected to cluster {0} in resource group {1}", ClusterName, ResourceGroupName));
        }
    }

    public class AzureHDInsightClusterConnection
    {
        public AzureHDInsightCluster Cluster { get; set; }

        public PSCredential HttpCredentials { get; set; }
    }
}
