using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.Management.CognitiveServices.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IdentityType
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "SystemAssigned")]
        SystemAssigned,
        [EnumMember(Value = "UserAssigned")]
        UserAssigned,
        [EnumMember(Value = "SystemAssigned, UserAssigned")]
        SystemAssignedUserAssigned
    }
}
