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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.ServerUpgrade.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System;

namespace Microsoft.Azure.Commands.Sql.ServerUpgrade.Services
{
    /// <summary>
    /// Adapter for server upgrade operations
    /// </summary>
    public class AzureSqlServerUpgradeAdapter
    {
        /// <summary>
        /// Gets or sets the Communicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerUpgradeCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs a server adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlServerUpgradeAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerUpgradeCommunicator(Context);
        }

        /// <summary>
        /// Gets a server in a resource group
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>The server</returns>
        public AzureSqlServerUpgradeModel GetUpgrade(string resourceGroupName, string serverName)
        {
            var upgradeDetails = Communicator.GetUpgrade(resourceGroupName, serverName, Util.GenerateTracingId());
            ServerUpgradeStatus status;
            if (!Enum.TryParse(upgradeDetails.Status, out status))
            {
                status = ServerUpgradeStatus.Unknown;
            }

            return new AzureSqlServerUpgradeModel
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                Status = status,
                ScheduleUpgradeAfterUtcDateTime = upgradeDetails.ScheduleUpgradeAfterTime
            };
        }

        /// <summary>
        /// Start a server upgrade
        /// </summary>
        /// <param name="model">The server upgrade model to start the upgrade</param>
        public void Start(AzureSqlServerUpgradeStartModel model)
        {
            ServerUpgradeStartParameters parameters = new ServerUpgradeStartParameters()
            {
                Properties = new ServerUpgradeProperties()
                {
                    Version = model.ServerVersion,
                    ScheduleUpgradeAfterUtcDateTime = model.ScheduleUpgradeAfterUtcDateTime,
                    DatabaseCollection = model.DatabaseCollection,
                    ElasticPoolCollection = model.ElasticPoolCollection
                }
            };
            Communicator.Start(model.ResourceGroupName, model.ServerName, parameters, Util.GenerateTracingId());
        }

        /// <summary>
        /// Cancel a server upgrade
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server to cancel upgrade</param>
        public void Cancel(string resourceGroupName, string serverName)
        {
            Communicator.Cancel(resourceGroupName, serverName, Util.GenerateTracingId());
        }
    }
}
