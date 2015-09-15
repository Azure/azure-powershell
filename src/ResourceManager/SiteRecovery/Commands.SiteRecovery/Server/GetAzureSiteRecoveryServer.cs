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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Server.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryServer", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRServer>))]
    public class GetAzureSiteRecoveryServer : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets ID of the Server.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets name of the Server.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByName:
                        this.GetByName();
                        break;
                    case ASRParameterSets.ByFriendlyName:
                        this.GetByFriendlyName();
                        break;
                    case ASRParameterSets.Default:
                        this.GetAll();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            ServerListResponse serverListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryServer();

            bool found = false;
            foreach (Server server in serverListResponse.Servers)
            {
                if (0 == string.Compare(this.FriendlyName, server.Properties.FriendlyName, true))
                {
                    this.WriteServer(server);
                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ServerNotFound,
                    this.FriendlyName,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        /// Queries by name.
        /// </summary>
        private void GetByName()
        {
            ServerResponse serverResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryServer(this.Name);

            this.WriteServer(serverResponse.Server);
        }

        /// <summary>
        /// Queries all / by default.
        /// </summary>
        private void GetAll()
        {
            ServerListResponse serverListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryServer();

            this.WriteServers(serverListResponse.Servers);
        }

        /// <summary>
        /// Write Servers.
        /// </summary>
        /// <param name="servers">List of Servers</param>
        private void WriteServers(IList<Server> servers)
        {
            this.WriteObject(servers.Select(s => new ASRServer(s)), true);
        }

        /// <summary>
        /// Write Server.
        /// </summary>
        /// <param name="server">Server object</param>
        private void WriteServer(Server server)
        {
            this.WriteObject(new ASRServer(server));
        }
    }
}