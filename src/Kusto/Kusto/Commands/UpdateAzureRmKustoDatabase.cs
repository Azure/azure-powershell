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
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Kusto.Commands
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KustoDatabase", DefaultParameterSetName = CmdletParametersSet, 
         SupportsShouldProcess = true),
     OutputType(typeof(PSKustoDatabase))]
    public class UpdateAzureRmKustoDatabase : KustoCmdletBase
    {
        protected const string CmdletParametersSet = "ByNameAndResourceGroup";
        protected const string ObjectParameterSet = "ByInputObject";
        protected const string ResourceIdParameterSet = "ByResourceId";

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
            HelpMessage = "Name of cluster under which the database exists")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            ParameterSetName = CmdletParametersSet,  
            Position = 2,
            Mandatory = true,
            HelpMessage = "Name of the database to update")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The number of days that data should be kept before it stops being accessible to queries")]
        public int? SoftDeletePeriodInDays { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The number of days that data should be kept in cache for fast queries")]
        public int? HotCachePeriodInDays { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Kusto database ResourceID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "Kusto database object.")]
        [ValidateNotNullOrEmpty]
        public PSKustoDatabase InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            string databaseName = Name;
            string clusterName = ClusterName;
            string resourceGroupName = ResourceGroupName;
            string location = null;
            int hotCachePeriodInDays = 0;
            int softRetentionPeriodInDays = 0;

            if (!string.IsNullOrEmpty(ResourceId))
            {
                KustoUtils.GetResourceGroupNameClusterNameAndDatabaseNameFromDatabaseId(ResourceId, out resourceGroupName, out clusterName, out databaseName);
            }
            else if (InputObject != null)
            {
                KustoUtils.GetResourceGroupNameClusterNameAndDatabaseNameFromDatabaseId(InputObject.Id, out resourceGroupName, out clusterName, out databaseName);
            }

            EnsureDatabaseClusterResourceGroupSpecified(resourceGroupName, clusterName, databaseName);

            if (ShouldProcess(databaseName, Resources.UpdatingKustoDatabase))
            {
                try
                {
                    var database = KustoClient.GetDatabase(resourceGroupName, clusterName, databaseName);
                    if (database == null)
                    {
                        throw new CloudException(string.Format(Resources.KustoDatabaseNotExist, databaseName));
                    }

                    location = database.Location;
                    hotCachePeriodInDays = HotCachePeriodInDays ?? database.HotCachePeriodInDays.GetValueOrDefault();
                    softRetentionPeriodInDays = SoftDeletePeriodInDays ?? database.SoftDeletePeriodInDays;
                }
                catch (CloudException ex)
                {
                    if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) && ex.Body.Code == "ResourceNotFound" ||
                        ex.Message.Contains("ResourceNotFound"))
                    {
                        throw new CloudException(string.Format(Resources.KustoDatabaseNotExist, databaseName));
                    }
                    else if (ex.Body != null && !string.IsNullOrEmpty(ex.Body.Code) &&
                             ex.Body.Code == "ResourceGroupNotFound" || ex.Message.Contains("ResourceGroupNotFound"))
                    {
                        throw new CloudException(string.Format(Resources.ResourceGroupNotExist, resourceGroupName));
                    }
                    else
                    {
                        // all other exceptions should be thrown
                        throw;
                    }
                }
                
                var updatedDatabase = KustoClient.CreateOrUpdateDatabase(resourceGroupName, clusterName, databaseName, hotCachePeriodInDays, softRetentionPeriodInDays, location);
                WriteObject(updatedDatabase);
            }
        }

    }
}
