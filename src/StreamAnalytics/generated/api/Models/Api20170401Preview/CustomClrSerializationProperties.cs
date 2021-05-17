namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with the CustomClr serialization type.</summary>
    public partial class CustomClrSerializationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICustomClrSerializationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICustomClrSerializationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="SerializationClassName" /> property.</summary>
        private string _serializationClassName;

        /// <summary>The serialization class name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string SerializationClassName { get => this._serializationClassName; set => this._serializationClassName = value; }

        /// <summary>Backing field for <see cref="SerializationDllPath" /> property.</summary>
        private string _serializationDllPath;

        /// <summary>The serialization library path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string SerializationDllPath { get => this._serializationDllPath; set => this._serializationDllPath = value; }

        /// <summary>Creates an new <see cref="CustomClrSerializationProperties" /> instance.</summary>
        public CustomClrSerializationProperties()
        {

        }
    }
    /// The properties that are associated with the CustomClr serialization type.
    public partial interface ICustomClrSerializationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The serialization class name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The serialization class name.",
        SerializedName = @"serializationClassName",
        PossibleTypes = new [] { typeof(string) })]
        string SerializationClassName { get; set; }
        /// <summary>The serialization library path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The serialization library path.",
        SerializedName = @"serializationDllPath",
        PossibleTypes = new [] { typeof(string) })]
        string SerializationDllPath { get; set; }

    }
    /// The properties that are associated with the CustomClr serialization type.
    internal partial interface ICustomClrSerializationPropertiesInternal

    {
        /// <summary>The serialization class name.</summary>
        string SerializationClassName { get; set; }
        /// <summary>The serialization library path.</summary>
        string SerializationDllPath { get; set; }

    }
}