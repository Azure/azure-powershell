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
    /// Represents a sync group log object
    /// </summary>
    public class AzureSqlSyncGroupLogModel
    {
        /// <summary>
        /// Gets or sets the time stamp of logs
        /// </summary>
        public DateTime? TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the log level of logs
        /// </summary>
        public string LogLevel { get; set; }

        /// <summary>
        /// Gets or sets the content of logs
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the log source
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Construct AzureSqlSyncGroupLogModel
        /// </summary>
        public AzureSqlSyncGroupLogModel()
        {

        }

        /// <summary>
        /// Construct AzureSqlSyncGroupLogModel from Management.Sql.Models.SyncGroupLog object
        /// </summary>
        /// <param name="syncGroupLog">sync group log object</param>
        public AzureSqlSyncGroupLogModel(SyncGroupLog syncGroupLog)
        {
            TimeStamp = syncGroupLog.TimeStamp;
            LogLevel = syncGroupLog.Type == null ? null : syncGroupLog.Type.ToString();
            Details = syncGroupLog.Details;
            Source = syncGroupLog.Source;
        }
    }
}
