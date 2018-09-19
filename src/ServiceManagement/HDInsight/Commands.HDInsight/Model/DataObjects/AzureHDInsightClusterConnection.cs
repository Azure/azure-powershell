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
namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects
{
    /// <summary>
    ///     Represents an Azure HD Insight Cluster connection object for the PowerShell Cmdlets.
    /// </summary>
    public class AzureHDInsightClusterConnection
    {
        /// <summary>
        ///     Gets or sets the Azure HDInsight cluster we're connected to.
        /// </summary>
        public AzureHDInsightCluster Cluster { get; set; }

        /// <summary>
        ///     Gets or sets the subscription credentials for the connection.
        /// </summary>
        public IHDInsightSubscriptionCredentials Credential { get; set; }
    }
}
