using System;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    public sealed class ScaleOutServerDatabaseSyncResult
    {
        [DataMember]
        public string OperationId { get; set; }

        [DataMember(Name = "database")]
        public string Database { get; set; }

        [DataMember(Name = "UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "StartedAt")]
        public DateTime StartedAt { get; set; }

        [DataMember(Name = "syncstate")]
        public DatabaseSyncState SyncState { get; set; }

        [DataMember(Name = "details")]
        public string Details { get; set; }
    }

    public enum DatabaseSyncState
    {
        Succeeded,
        Failed
    }
}
