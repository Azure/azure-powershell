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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    public class NewOrUpdateAzManagedCassandraDatacenter : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ManagedCassandraClusterNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ManagedCassandraDatacenterNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatacenterName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraNodeCountHelpMessage)]
        public int? NodeCount { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraBase64EncodedCassandraYamlFragment)]
        [ValidateNotNullOrEmpty]
        public string Base64EncodedCassandraYamlFragment { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ManagedCassandraBackupStorageCustomerKeyUri)]
        [ValidateNotNullOrEmpty]
        public string BackupStorageCustomerKeyUri { get; set; }
    }
}
