namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory error message.</summary>
    public partial class ErrorMessage :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IErrorMessage,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IErrorMessageInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>Error message value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ErrorMessage" /> instance.</summary>
        public ErrorMessage()
        {

        }
    }
    /// Active Directory error message.
    public partial interface IErrorMessage :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>Error message value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error message value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Active Directory error message.
    internal partial interface IErrorMessageInternal

    {
        /// <summary>Error message value.</summary>
        string Value { get; set; }

    }
}