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
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlDatabaseMerge", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSPhysicalPartitionStorageInfo))]
    public class InvokeAzCosmosDBSqlDatabaseMerge : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName;

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccountGetResults ParentObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.SqlDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlDatabaseGetResults InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        public void PopulateFromParentObject()
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            AccountName = resourceIdentifier.ResourceName;
        }

        public void PopulateFromInputObject()
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            Name = resourceIdentifier.ResourceName;
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

            PhysicalPartitionStorageInfoCollection physicalPartitionStorageInfoCollection = null;
            MergeParameters mergeParameters = new MergeParameters(isDryRun: false);

            if (ShouldProcess(Name, "Merging partitions.", String.Empty, out ShouldProcessReason shouldProcessReason))
            {
                if (this.Force.IsPresent || ShouldContinue($"This command will merge the partitions of collection {Name} , do you want to continue?", "This operation might take a long time (potentially hours) depending on the data movement involved."))
                {
                    physicalPartitionStorageInfoCollection =
                    CosmosDBManagementClient.SqlResources.SqlDatabasePartitionMerge(ResourceGroupName, AccountName, Name, new MergeParameters(isDryRun: false));
                }
            }
            else if (shouldProcessReason == ShouldProcessReason.WhatIf)
            {
                mergeParameters.IsDryRun = true;
                physicalPartitionStorageInfoCollection =
                    CosmosDBManagementClient.SqlResources.SqlDatabasePartitionMerge(ResourceGroupName, AccountName, Name, new MergeParameters(isDryRun: true));
            }

            if (physicalPartitionStorageInfoCollection != null)
            {
                IList<PSPhysicalPartitionStorageInfo> physicalPartitionStorageInfos = new List<PSPhysicalPartitionStorageInfo>();

                foreach (PhysicalPartitionStorageInfo item in physicalPartitionStorageInfoCollection.PhysicalPartitionStorageInfoCollectionProperty)
                {
                    physicalPartitionStorageInfos.Add(new PSPhysicalPartitionStorageInfo(item.Id, item.StorageInKb));
                }

                WriteObject(physicalPartitionStorageInfos);
            }
        }
    }
}
