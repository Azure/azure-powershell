// ----------------------------------------------------------------------------------
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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Properties;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    /// <summary>
    /// Retrieves a list of Microsoft Azure SQL Databases in the given server context.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseUsages", ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlDatabaseUsages : AzureSMCmdlet
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the server object upon which to operate
        /// </summary>
        [Parameter(Mandatory = true, Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the server")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to retrieve.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the database.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        #endregion

        /// <summary>
        /// Process the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            var context = ServerDataServiceCertAuth.Create(this.ServerName, Profile, Profile.Context.Subscription);
            ProcessWithContext(context);
        }

        /// <summary>
        /// Process the request using the provided connection context
        /// </summary>
        /// <param name="context">The connection context</param>
        private void ProcessWithContext(ServerDataServiceCertAuth context)
        {
            this.WriteObject(context.GetDatabaseUsages(this.DatabaseName), true);
        }
    }
}