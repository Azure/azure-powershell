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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    /// <summary>
    /// Retrieves a list of Microsoft Azure SQL Databases in the given server context.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseServiceObjective", ConfirmImpact = ConfirmImpact.None,
        DefaultParameterSetName = "ByConnectionContext")]
    public class GetAzureSqlDatabaseServiceObjective : AzureSMCmdlet
    {
        #region Parameter Sets

        /// <summary>
        /// The parameter set string for connecting with a connection context
        /// </summary>
        internal const string ByConnectionContext =
            "ByConnectionContext";

        /// <summary>
        /// The parameter set string for connecting using azure subscription
        /// </summary>
        internal const string ByServerName =
            "ByServerName";

        #endregion

        #region Parameters

        /// <summary>
        /// Gets or sets the server connection context.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true,
            ParameterSetName = ByConnectionContext,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection context to the specified server.")]
        [ValidateNotNull]
        public IServerDataServiceContext Context { get; set; }

        /// <summary>
        /// Gets or sets the server namee upon which to operate
        /// </summary>
        [Parameter(Mandatory = true, Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByServerName,
            HelpMessage = "The name of the server to operate on")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the service objective object to refresh.
        /// </summary>
        [Parameter(Mandatory = false, 
            ValueFromPipeline = true, HelpMessage = "The Service Objective object to refresh.")]
        [ValidateNotNull]
        public ServiceObjective ServiceObjective { get; set; }

        /// <summary>
        /// Gets or sets the name of the service objective to retrieve.
        /// </summary>
        [Parameter(Mandatory = false, 
            HelpMessage = "The name of the Service Objective to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string ServiceObjectiveName { get; set; }

        #endregion

        /// <summary>
        /// Execute the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IServerDataServiceContext context = null;
            switch (this.ParameterSetName)
            {
                case ByConnectionContext:
                    context = this.Context;
                    break;

                case ByServerName:
                    context = ServerDataServiceCertAuth.Create(this.ServerName, Profile, Profile.Context.Subscription);
                    break;

                default:
                    throw new InvalidPowerShellStateException("Unrecognized parameter set name used.");
            }
            ProcessWithContext(context);
        }

        private void ProcessWithContext(IServerDataServiceContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException("context", "The ServerDataServiceContext cannot be null.");
            }

            try
            {
                if (this.ServiceObjectiveName != null)
                {
                    // Retrieve the service objective with the specified name
                    this.WriteObject(context.GetServiceObjective(this.ServiceObjectiveName));
                }
                else if (this.ServiceObjective != null)
                {
                    // Retrieve the latest service objective with the specified service objective
                    this.WriteObject(context.GetServiceObjective(this.ServiceObjective));
                }
                else
                {
                    // No name specified, retrieve all service objectives in the server
                    this.WriteObject(context.GetServiceObjectives(), true);
                }
            }
            catch (Exception ex)
            {
                SqlDatabaseExceptionHandler.WriteErrorDetails(
                    this,
                    context.ClientRequestId,
                    ex);
            }
        }
    }
}
