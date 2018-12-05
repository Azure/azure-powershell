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

using System;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Kusto.Models;
using Microsoft.Azure.Commands.Kusto.Properties;
using Microsoft.Azure.Commands.Kusto.Utilities;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Kusto.Commands
{

    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KustoDatabase",
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
            HelpMessage = "Name of the database to update")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = CmdletParametersSet,
            Position = 1,
            Mandatory = true,
            HelpMessage = "Name of cluster under which the database exists")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            ParameterSetName = CmdletParametersSet,
            Mandatory = false,
            HelpMessage = "Name of resource group under which the cluster exists.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            Mandatory = true,
            HelpMessage = "the amount of days for the data .")] //TODO:Add here and in create a valid help message
        [LocationCompleter("Microsoft.Kusto/databases")]
        public int SoftDeletePeriodInDays { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Position = 5,
            Mandatory = true,
            HelpMessage = ".")] //TODO:Add here and in create a valid help message
        [LocationCompleter("Microsoft.Kusto/clusters")]
        public int HotCachePeriodInDays { get; set; }

        [Parameter(
            ParameterSetName = ResourceIdParameterSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Kusto database ResourceID.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = ObjectParameterSet,
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            HelpMessage = "Kusto database object.")]
        [ValidateNotNullOrEmpty]
        public PSKustoDatabase InputObject { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            string databaseName = Name;
            string clusterName = ClusterName;
            string resourceGroupName = ResourceGroupName;
            string location = null;

            if (!string.IsNullOrEmpty(ResourceId))
            {
                KustoUtils.GetResourceGroupNameClusterNameAndDatabaseNameFromDatabaseId(ResourceId, out resourceGroupName, out clusterName, out databaseName);
            }
            else if (InputObject != null)
            {
                KustoUtils.GetResourceGroupNameClusterNameAndDatabaseNameFromDatabaseId(InputObject.Id, out resourceGroupName, out clusterName, out databaseName);
            }

            if (string.IsNullOrEmpty(clusterName))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of cluster not specified"));
            }
            if (string.IsNullOrEmpty(databaseName))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of database not specified"));
            }

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
                        // resource group not found, let create throw error don't throw from here
                    }
                    else
                    {
                        // all other exceptions should be thrown
                        throw;
                    }
                }

                var updatedDatabase = KustoClient.CreateOrUpdateDatabase(resourceGroupName, clusterName, databaseName, HotCachePeriodInDays, SoftDeletePeriodInDays, location);
                WriteObject(updatedDatabase);
            }
        }

    }
}

