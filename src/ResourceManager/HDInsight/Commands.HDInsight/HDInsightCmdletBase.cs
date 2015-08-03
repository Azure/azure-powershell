﻿// ----------------------------------------------------------------------------------
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
using Hyak.Common;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.HDInsight.Commands
{
    public class HDInsightCmdletBase : AzurePSCmdlet
    {
        private AzureHdInsightManagementClient _hdInsightManagementClient;
        private AzureHdInsightJobManagementClient _hdInsightJobClient;
        protected BasicAuthenticationCloudCredentials _credential;
        protected string _clusterName;

        public AzureHdInsightManagementClient HDInsightManagementClient
        {
            get {
                return _hdInsightManagementClient ??
                       (_hdInsightManagementClient = new AzureHdInsightManagementClient(Profile.Context));
            }
            set { _hdInsightManagementClient = value; }
        }

        public AzureHdInsightJobManagementClient HDInsightJobClient
        {
            get
            {
                if (_hdInsightJobClient == null || !_hdInsightJobClient.ClusterName.Equals(_clusterName))
                {
                    return new AzureHdInsightJobManagementClient(_clusterName, _credential);
                }
                return _hdInsightJobClient;
                //return _hdInsightJobClient ?? (_hdInsightJobClient = new AzureHdInsightJobManagementClient(_clusterName, _credential));
            }
            set { _hdInsightJobClient = value; }
        }

        protected string GetClusterConnection(string resourceGroupName, string clusterName)
        {
            if (clusterName.Contains("."))
            {
                return clusterName;
            }
            var cluster = HDInsightManagementClient.GetCluster(resourceGroupName, clusterName);
            if (cluster.First() == null)
            {
                throw new NullReferenceException(string.Format("Could not find cluster {0} in resource group {1}",
                    clusterName, resourceGroupName));
            }
            var azurecluster = new AzureHDInsightCluster(cluster.First());
            var state = azurecluster.ClusterState;
            if (
                !(state.Equals("Running", StringComparison.OrdinalIgnoreCase) ||
                  state.Equals("Operational", StringComparison.OrdinalIgnoreCase)))
            {
                throw new NotSupportedException(
                    string.Format("The cluster {0} is in the {1} state and canot be used at this time.", clusterName,
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
            return httpEndpoint;
        }
    }
}
