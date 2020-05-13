namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Function key info.</summary>
    public partial class KeyInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyInfoInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Key name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>Key value</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="KeyInfo" /> instance.</summary>
        public KeyInfo()
        {

        }
    }
    /// Function key info.
    public partial interface IKeyInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Key name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Key value</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key value",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Function key info.
    internal partial interface IKeyInfoInternal

    {
        /// <summary>Key name</summary>
        string Name { get; set; }
        /// <summary>Key value</summary>
        string Value { get; set; }

    }
}