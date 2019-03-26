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

using System.Management.Automation;
using Microsoft.Azure.Commands.Kusto.Models;
using Microsoft.Azure.Commands.Kusto.Properties;
using Microsoft.Azure.Commands.Kusto.Utilities;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Kusto.Commands
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KustoDatabase", DefaultParameterSetName = CmdletParametersSet, SupportsShouldProcess = true),
     OutputType(typeof(PSKustoDatabase))]
    public class NewAzureRmKustoDatabase : KustoCmdletBase
    {
        protected const string ObjectParameterSet = "ByInputObject";
        protected const string ResourceIdParameterSet = "ByResourceId";
        protected const string CmdletParametersSet = "ByNameAndResourceGroup";

        [Parameter(
            ParameterSetName = CmdletParametersSet,
           Position = 0,
           Mandatory = true,
           HelpMessage = "Name of resource group under which the cluster exists.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = CmdletParametersSet,
            Position = 1,
            Mandatory = true,
            HelpMessage = "Name of cluster under which you want to create the database.")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the database to be created.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The number of days data should be kept before it stops being accessible to queries.")]
        public int SoftDeletePeriodInDays { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The number of days of data that should be kept in cache for fast queries.")]
        public int HotCachePeriodInDays { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Kusto cluster ResourceID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "Kusto cluster object.")]
        [ValidateNotNullOrEmpty]
        public PSKustoCluster InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = ResourceGroupName;
            string clusterName = ClusterName;
            string databaseName = Name;
            string location = null;
            if (ShouldProcess(Name, Resources.CreateNewKustoCluster))
            {
                try
                {
                    if (!string.IsNullOrEmpty(ResourceId))
                    {
                        KustoUtils.GetResourceGroupNameAndClusterNameFromClusterId(ResourceId, out resourceGroupName, out clusterName);
                    }

                    if (InputObject != null)
                    {
                        KustoUtils.GetResourceGroupNameAndClusterNameFromClusterId(InputObject.Id, out resourceGroupName, out clusterName);
                    }

                    var cluser = KustoClient.GetCluster(resourceGroupName, clusterName);
                    if (cluser == null)
                    {
                        throw new CloudException(string.Format(Resources.KustoClusterNotExist, clusterName));
                    }

                    location = cluser.Location;

                    var database = KustoClient.GetDatabase(resourceGroupName, clusterName, databaseName);
                    if (database != null)
                    {
                        throw new CloudException(string.Format(Resources.KustoClusterExists, Name));
                    }
                }
                catch (CloudException ex)
                {
                    if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) && ex.Body.Code == "ResourceNotFound" ||
                        ex.Message.Contains("ResourceNotFound"))
                    {
                        // there are 2 options:
                        // -database does not exists so go ahead and create one
                        // -cluster does not exist, so continue and let the command fail
                    }
                    else if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) &&
                             ex.Body.Code == "ResourceGroupNotFound" || ex.Message.Contains("ResourceGroupNotFound"))
                    {
                        // resource group not found, let create throw error don't throw from here
                    }
                    else
                    {
                        // all other exceptions should be thrown
                        throw;
                    }
                }

                var createdDatabase = KustoClient.CreateOrUpdateDatabase(resourceGroupName, clusterName, databaseName, HotCachePeriodInDays, SoftDeletePeriodInDays, location);
                WriteObject(createdDatabase);
            }
        }
    }
}
