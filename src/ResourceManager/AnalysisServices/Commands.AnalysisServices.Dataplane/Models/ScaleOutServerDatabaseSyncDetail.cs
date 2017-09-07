using System;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    public sealed class ScaleOutServerDatabaseSyncDetails
    {
        internal static ScaleOutServerDatabaseSyncDetails FromResult(ScaleOutServerDatabaseSyncResult result)
        {
            var details = new ScaleOutServerDatabaseSyncDetails
            {
                OperationId = result.OperationId,
                Database = result.Database,
                UpdatedAt = result.UpdatedAt,
                StartedAt = result.StartedAt,
                Details = result.Details,
                SyncState = DatabaseSyncState.Failed
            };

            if (result.SyncState == DatabaseSyncState.Completed)
            {
                details.SyncState = DatabaseSyncState.Completed;
            }

            return details;
        }

        public string OperationId { get; set; }

        public string Database { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime StartedAt { get; set; }

        public DatabaseSyncState SyncState { get; set; }

        public string Details { get; set; }
    }
}
