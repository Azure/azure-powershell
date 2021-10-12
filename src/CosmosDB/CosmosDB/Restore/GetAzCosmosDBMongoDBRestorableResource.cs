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

using System;
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBRestorableResource", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSDatabaseToRestore))]
    public class GetAzCosmosDBMongoDBRestorableResource : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = Constants.LocationNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.AccountInstanceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseAccountInstanceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.RestoreTimestampHelpMessage)]
        public DateTimeOffset RestoreTimestampInUtc { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.RestoreLocationNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string RestoreLocation { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.RestorableDatabaseAccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSRestorableDatabaseAccountGetResult InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                Location = InputObject.Location;
                DatabaseAccountInstanceId = InputObject.DatabaseAccountInstanceId;
            }

            IEnumerable restorableMongoDBResources = CosmosDBManagementClient.RestorableMongodbResources.ListWithHttpMessagesAsync(Location, DatabaseAccountInstanceId, RestoreLocation, RestoreTimestampInUtc.ToString()).GetAwaiter().GetResult().Body;
            foreach (DatabaseRestoreResource restorableMongoDBResource in restorableMongoDBResources)
            {
                WriteObject(new PSDatabaseToRestore(restorableMongoDBResource));
            }
        }
    }
}
