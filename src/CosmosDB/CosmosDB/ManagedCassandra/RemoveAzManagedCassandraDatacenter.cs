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

using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using System;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ManagedCassandraDatacenter", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(void), typeof(bool))]
    public class RemoveAzManagedCassandraDatacenter : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DataCenterName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.ManagedCassandraDatacenterObjectHelpMessage)]
        [ValidateNotNull]
        public PSDataCenterResource InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.ManagedCassandraClusterObjectHelpMessage)]
        [ValidateNotNull]
        public PSClusterResource ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {

            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                ClusterName = resourceIdentifier.ResourceName;
            }
            else if (!ParameterSetName.Equals(NameParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = null;
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                }
                else if (ParameterSetName.Equals(ObjectParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                }
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                String[] parentSegments = resourceIdentifier.ParentResource.Split(separator: '/');
                if (parentSegments.Length != 2)
                {
                    throw new ArgumentException("ResourceId is invalid.");
                }
                ClusterName = resourceIdentifier.ParentResource.Split(separator: '/')[1];
                DataCenterName = resourceIdentifier.ResourceName;
            }

            if (ShouldProcess(ClusterName, "Removing Managed Cassandra DataCenter."))
            {
                CosmosDBManagementClient.CassandraDataCenters.DeleteWithHttpMessagesAsync(ResourceGroupName, ClusterName, DataCenterName).GetAwaiter().GetResult();

                if (PassThru)
                {
                    WriteObject(true);
                }                    
            }

            return;
        }
    }
}
