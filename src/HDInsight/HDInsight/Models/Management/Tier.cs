using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Management.HDInsight.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for Tier.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Tier
    {
        [EnumMember(Value = "Standard")]
        Standard,
        [EnumMember(Value = "Premium")]
        Premium
    }
    internal static class TierEnumExtension
    {
#pragma warning disable CS0436 // Type conflicts with imported type
        internal static string ToSerializedValue(this Tier? value)
#pragma warning restore CS0436 // Type conflicts with imported type
        {
#pragma warning disable CS0436 // Type conflicts with imported type
            return value == null ? null : ((Tier)value).ToSerializedValue();
#pragma warning restore CS0436 // Type conflicts with imported type
        }

#pragma warning disable CS0436 // Type conflicts with imported type
        internal static string ToSerializedValue(this Tier value)
#pragma warning restore CS0436 // Type conflicts with imported type
        {
            switch (value)
            {
#pragma warning disable CS0436 // Type conflicts with imported type
                case Tier.Standard:
#pragma warning restore CS0436 // Type conflicts with imported type
                    return "Standard";
#pragma warning disable CS0436 // Type conflicts with imported type
                case Tier.Premium:
#pragma warning restore CS0436 // Type conflicts with imported type
                    return "Premium";
            }
            return null;
        }

#pragma warning disable CS0436 // Type conflicts with imported type
        internal static Tier? ParseTier(this string value)
#pragma warning restore CS0436 // Type conflicts with imported type
        {
            switch (value)
            {
                case "Standard":
#pragma warning disable CS0436 // Type conflicts with imported type
                    return Tier.Standard;
#pragma warning restore CS0436 // Type conflicts with imported type
                case "Premium":
#pragma warning disable CS0436 // Type conflicts with imported type
                    return Tier.Premium;
#pragma warning restore CS0436 // Type conflicts with imported type
            }
            return null;
        }
    }
}
