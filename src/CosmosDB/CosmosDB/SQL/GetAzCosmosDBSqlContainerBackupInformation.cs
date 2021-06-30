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

using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Models.Restore.Sql;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlContainerBackupInformation", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSSqlBackupInformation))]
    public class GetAzCosmosDBSqlContainerBackupInformation : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.ContainerNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.LocationNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                CosmosDBManagementClient.SqlResources.GetSqlDatabase(ResourceGroupName, AccountName, DatabaseName);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFound, DatabaseName), innerException: e);
                }
                else
                {
                    throw e;
                }
            }

            try
            {
                CosmosDBManagementClient.SqlResources.GetSqlContainer(ResourceGroupName, AccountName, DatabaseName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFound, Name), innerException: e);
                }
                else
                {
                    throw e;
                }
            }

            ContinuousBackupRestoreLocation continuousBackupRestoreLocation = new ContinuousBackupRestoreLocation
            {
                Location = Location
            };

            BackupInformation backupInformation = CosmosDBManagementClient.SqlResources.RetrieveContinuousBackupInformation(ResourceGroupName, AccountName, DatabaseName, Name, continuousBackupRestoreLocation);
            WriteObject(new PSSqlBackupInformation(backupInformation));

            return;
        }
    }
}
