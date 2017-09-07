using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    [DataContract]
    public enum DatabaseSyncState
    {
        [EnumMember]
        Invalid = -1,

        [EnumMember]
        Replicating = 0,

        [EnumMember]
        Rehydrating = 1,

        [EnumMember]
        Completed = 2,

        [EnumMember]
        Failed = 3,
    }
}
