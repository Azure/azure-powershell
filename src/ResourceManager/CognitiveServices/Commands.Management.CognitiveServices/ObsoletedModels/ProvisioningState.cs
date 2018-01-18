using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Management.CognitiveServices.Models
{
    [Obsolete("'ProvisioningState' enum is obsolete. It will be modeled as string in later version.")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProvisioningState
    {
        [EnumMember(Value = "Creating")] Creating,
        [EnumMember(Value = "Moving")] Moving,
        [EnumMember(Value = "Deleting")] Deleting,
        [EnumMember(Value = "ResolvingDNS")] ResolvingDNS,
        [EnumMember(Value = "Succeeded")] Succeeded,
        [EnumMember(Value = "Failed")] Failed
    }
}
