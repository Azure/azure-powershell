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
