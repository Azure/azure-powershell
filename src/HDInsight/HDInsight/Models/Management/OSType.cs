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
    /// Defines values for OSType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OSType
    {
        [EnumMember(Value = "Windows")]
        Windows,
        [EnumMember(Value = "Linux")]
        Linux
    }
    internal static class OSTypeEnumExtension
    {
#pragma warning disable CS0436 // Type conflicts with imported type
        internal static string ToSerializedValue(this OSType? value)
#pragma warning restore CS0436 // Type conflicts with imported type
        {
#pragma warning disable CS0436 // Type conflicts with imported type
            return value == null ? null : ((OSType)value).ToSerializedValue();
#pragma warning restore CS0436 // Type conflicts with imported type
        }

#pragma warning disable CS0436 // Type conflicts with imported type
        internal static string ToSerializedValue(this OSType value)
#pragma warning restore CS0436 // Type conflicts with imported type
        {
            switch (value)
            {
#pragma warning disable CS0436 // Type conflicts with imported type
                case OSType.Windows:
#pragma warning restore CS0436 // Type conflicts with imported type
                    return "Windows";
#pragma warning disable CS0436 // Type conflicts with imported type
                case OSType.Linux:
#pragma warning restore CS0436 // Type conflicts with imported type
                    return "Linux";
            }
            return null;
        }

#pragma warning disable CS0436 // Type conflicts with imported type
        internal static OSType? ParseOSType(this string value)
#pragma warning restore CS0436 // Type conflicts with imported type
        {
            switch (value)
            {
                case "Windows":
#pragma warning disable CS0436 // Type conflicts with imported type
                    return OSType.Windows;
#pragma warning restore CS0436 // Type conflicts with imported type
                case "Linux":
#pragma warning disable CS0436 // Type conflicts with imported type
                    return OSType.Linux;
#pragma warning restore CS0436 // Type conflicts with imported type
            }
            return null;
        }
    }
}
