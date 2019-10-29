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
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.CosmosDB.Models;
using System.Reflection;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlDatabase", SupportsShouldProcess = true), OutputType(typeof(PSSqlDatabase))]
    public class SetAzCosmosDBSqlDatabase : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DatabaseNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SqlDatabaseThroughputHelpMessage)]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObject)]
        public PSDatabaseAccount InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.ResourceName;
            }

            SqlDatabaseCreateUpdateParametersInner sqlDatabaseCreateUpdate = new SqlDatabaseCreateUpdateParametersInner();
            SqlDatabaseResource databaseResource = new SqlDatabaseResource(id:Name);
            Dictionary<string, string> options = new Dictionary<string, string>();
            sqlDatabaseCreateUpdate.Resource = databaseResource;
            sqlDatabaseCreateUpdate.Options = options;

            var response = CosmosClient.DatabaseAccounts.BeginCreateUpdateSqlDatabaseWithHttpMessagesAsync(ResourceGroupName, AccountName, Name, sqlDatabaseCreateUpdate).Result;
            WriteObject(sqlDatabaseCreateUpdate);

            return;
        }
    }
}
