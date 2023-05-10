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
using Microsoft.Azure.Management.Sql.LegacySdk.Models;

namespace Microsoft.Azure.Commands.Sql.DataSync.Model
{
    /// <summary>
    /// Represents a sync agent object 
    /// </summary>
    public class AzureSqlSyncAgentModel
    {
        /// <summary>
        /// Gets or sets the resource Id
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }
        
        /// <summary>
        /// Gets or sets the location
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the sync agent name
        /// </summary>
        public string SyncAgentName { get; set; }

        /// <summary>
        /// Gets or sets the sync database resource id
        /// </summary>
        public string SyncDatabaseId { get; set; }
        
        /// <summary>
        /// Gets or sets the last alive time of the sync agent
        /// </summary>
        public DateTime? LastAliveTime { get; set; }

        /// <summary>
        /// Gets or sets the version of the sync agent
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// Indicate whether this sync agent is up to date
        /// </summary>
        public bool? IsUpToDate { get; set; }
        
        /// <summary>
        /// Gets or sets the expires date of the sync agent
        /// </summary>
        public DateTime? ExpiryTime { get; set; }
        
        /// <summary>
        /// Gets or sets the state of the sync agent
        /// </summary>
        public string State { get; set; }

        public AzureSqlSyncAgentModel()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncAgentModel
        /// </summary>
        /// <param name="resourceGroup">resource group</param>
        /// <param name="serverName">server name</param>
        /// <param name="syncAgent">sync agent</param>
        public AzureSqlSyncAgentModel(string resourceGroup, string serverName, SyncAgent syncAgent)
        {
            ResourceGroupName = resourceGroup;
            ResourceId = syncAgent.Id;
            ServerName = serverName;
            SyncAgentName = syncAgent.Name;
            SyncDatabaseId = syncAgent.Properties.SyncDatabaseId;
            Version = syncAgent.Properties.Version;
            LastAliveTime = syncAgent.Properties.LastAliveTime;
            ExpiryTime = syncAgent.Properties.ExpiryTime;
            State = syncAgent.Properties.State == null ? null : syncAgent.Properties.State.ToString();
            IsUpToDate = syncAgent.Properties.IsUpToDate;
        }
    }
}
