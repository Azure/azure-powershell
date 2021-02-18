namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Database connection string value to type pair.</summary>
    public partial class ConnStringValueTypePair :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringValueTypePair,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringValueTypePairInternal
    {

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConnectionStringType _type;

        /// <summary>Type of database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConnectionStringType Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>Value of pair.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ConnStringValueTypePair" /> instance.</summary>
        public ConnStringValueTypePair()
        {

        }
    }
    /// Database connection string value to type pair.
    public partial interface IConnStringValueTypePair :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Type of database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of database.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConnectionStringType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConnectionStringType Type { get; set; }
        /// <summary>Value of pair.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Value of pair.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Database connection string value to type pair.
    internal partial interface IConnStringValueTypePairInternal

    {
        /// <summary>Type of database.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConnectionStringType Type { get; set; }
        /// <summary>Value of pair.</summary>
        string Value { get; set; }

    }
}