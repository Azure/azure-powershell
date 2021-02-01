namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>
    /// Extra Parameter in a Connection Setting Properties to indicate service provider specific properties
    /// </summary>
    public partial class ConnectionSettingParameter :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingParameter,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingParameterInternal
    {

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private string _key;

        /// <summary>Key for the Connection Setting Parameter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Key { get => this._key; set => this._key = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>Value associated with the Connection Setting Parameter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ConnectionSettingParameter" /> instance.</summary>
        public ConnectionSettingParameter()
        {

        }
    }
    /// Extra Parameter in a Connection Setting Properties to indicate service provider specific properties
    public partial interface IConnectionSettingParameter :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Key for the Connection Setting Parameter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key for the Connection Setting Parameter.",
        SerializedName = @"key",
        PossibleTypes = new [] { typeof(string) })]
        string Key { get; set; }
        /// <summary>Value associated with the Connection Setting Parameter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value associated with the Connection Setting Parameter.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Extra Parameter in a Connection Setting Properties to indicate service provider specific properties
    internal partial interface IConnectionSettingParameterInternal

    {
        /// <summary>Key for the Connection Setting Parameter.</summary>
        string Key { get; set; }
        /// <summary>Value associated with the Connection Setting Parameter.</summary>
        string Value { get; set; }

    }
}