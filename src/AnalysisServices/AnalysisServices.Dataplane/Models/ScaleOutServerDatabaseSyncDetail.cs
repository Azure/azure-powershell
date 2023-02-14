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
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    public sealed class ScaleOutServerDatabaseSyncDetails
    {
        internal static ScaleOutServerDatabaseSyncDetails FromResult(ScaleOutServerDatabaseSyncResult result, string correlationId)
        {
            var details = new ScaleOutServerDatabaseSyncDetails
            {
                CorrelationId = correlationId,
                OperationId = result.OperationId,
                Database = result.Database,
                UpdatedAt = result.UpdatedAt,
                StartedAt = result.StartedAt,
                Details = result.Details != null ? JsonConvert.SerializeObject(result.Details) : string.Empty,
                SyncState = result.SyncState
            };

            return details;
        }

        public string CorrelationId { get; set; }

        public string OperationId { get; set; }

        public string Database { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime StartedAt { get; set; }

        public DatabaseSyncState SyncState { get; set; }

        public string Details { get; set; }
    }
}
