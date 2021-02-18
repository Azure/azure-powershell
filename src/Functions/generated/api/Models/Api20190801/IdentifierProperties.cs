namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Identifier resource specific properties</summary>
    public partial class IdentifierProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIdentifierProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIdentifierPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>String representation of the identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="IdentifierProperties" /> instance.</summary>
        public IdentifierProperties()
        {

        }
    }
    /// Identifier resource specific properties
    public partial interface IIdentifierProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>String representation of the identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"String representation of the identity.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Identifier resource specific properties
    internal partial interface IIdentifierPropertiesInternal

    {
        /// <summary>String representation of the identity.</summary>
        string Value { get; set; }

    }
}