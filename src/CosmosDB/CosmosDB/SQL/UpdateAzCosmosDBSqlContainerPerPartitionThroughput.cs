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
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlContainerPerPartitionThroughput", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSPhysicalPartitionThroughputInfo))]
    public class UpdateAzCosmosDBSqlContainerPerPartitionThroughput : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName;

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ContainerNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlDatabaseGetResults ParentObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.SqlContainerObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlContainerGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SourcePhysicalPartitionThroughputHelpMessage)]        
        public PSPhysicalPartitionThroughputInfo[] SourcePhysicalPartitionThroughputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TargetPhysicalPartitionThroughputHelpMessage)]        
        public PSPhysicalPartitionThroughputInfo[] TargetPhysicalPartitionThroughputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ResetPartitionThroughputLayoutHelpMessage)]
        public SwitchParameter EqualDistributionPolicy { get; set; }

        public void PopulateFromParentObject()
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            DatabaseName = resourceIdentifier.ResourceName;
            AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
        }

        public void PopulateFromInputObject()
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            Name = resourceIdentifier.ResourceName;
            DatabaseName = ResourceIdentifierExtensions.GetSqlDatabaseName(resourceIdentifier);
            AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
        }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                PopulateFromParentObject();
            }
            else if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                PopulateFromInputObject();
            }

            if (ShouldProcess(Name, "Updating throughput"))
            {
                string throughputPolicy = "Custom";

                List<PhysicalPartitionThroughputInfoResource> sourcePartitionInfos = 
                    new List<PhysicalPartitionThroughputInfoResource>();
                
                List<PhysicalPartitionThroughputInfoResource> targetPartitionInfos =
                    new List<PhysicalPartitionThroughputInfoResource>();

                if (this.EqualDistributionPolicy.IsPresent)
                {
                    throughputPolicy = "Equal";
                }
                else
                {
                    if(this.SourcePhysicalPartitionThroughputObject == null || this.TargetPhysicalPartitionThroughputObject == null)
                    {
                        throw new ArgumentException("SourcePhysicalPartitionThroughputObject and TargetPhysicalPartitionThroughputObject cannot be null if 'EqualDistributionPolicy' is absent.");
                    }

                    foreach (var item in this.SourcePhysicalPartitionThroughputObject)
                    {
                        //NullorEmpty
                        PhysicalPartitionThroughputInfoResource source = new PhysicalPartitionThroughputInfoResource(item.Id, item.Throughput);
                        sourcePartitionInfos.Add(source);
                    }

                    foreach (var item in this.TargetPhysicalPartitionThroughputObject)
                    {
                        PhysicalPartitionThroughputInfoResource target = new PhysicalPartitionThroughputInfoResource(item.Id, item.Throughput);
                        targetPartitionInfos.Add(target);
                    }
                }                
                
                RedistributeThroughputParameters redistributeThroughputParameters = new RedistributeThroughputParameters();
                redistributeThroughputParameters.Resource
                    = new RedistributeThroughputPropertiesResource(throughputPolicy, targetPartitionInfos, sourcePartitionInfos);

                PhysicalPartitionThroughputInfoResult physicalPartitionThroughputInfoResult =
                    CosmosDBManagementClient.SqlResources.SqlContainerRedistributeThroughput(this.ResourceGroupName, this.AccountName, this.DatabaseName, this.Name,
                    redistributeThroughputParameters);
                
                List<PSPhysicalPartitionThroughputInfo> resultantPartitionInfos = new List<PSPhysicalPartitionThroughputInfo>();
                foreach (var item in physicalPartitionThroughputInfoResult.Resource.PhysicalPartitionThroughputInfo)
                {
                    resultantPartitionInfos.Add(new PSPhysicalPartitionThroughputInfo(item.Id, item.Throughput.Value));
                }

                WriteObject(resultantPartitionInfos);
            }
        }
    }
}
