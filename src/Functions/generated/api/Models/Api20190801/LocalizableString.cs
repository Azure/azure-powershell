namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Localizable string object containing the name and a localized value.</summary>
    public partial class LocalizableString :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILocalizableString,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILocalizableStringInternal
    {

        /// <summary>Backing field for <see cref="LocalizedValue" /> property.</summary>
        private string _localizedValue;

        /// <summary>Localized name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LocalizedValue { get => this._localizedValue; set => this._localizedValue = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>Non-localized name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="LocalizableString" /> instance.</summary>
        public LocalizableString()
        {

        }
    }
    /// Localizable string object containing the name and a localized value.
    public partial interface ILocalizableString :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Localized name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized name.",
        SerializedName = @"localizedValue",
        PossibleTypes = new [] { typeof(string) })]
        string LocalizedValue { get; set; }
        /// <summary>Non-localized name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Non-localized name.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Localizable string object containing the name and a localized value.
    internal partial interface ILocalizableStringInternal

    {
        /// <summary>Localized name.</summary>
        string LocalizedValue { get; set; }
        /// <summary>Non-localized name.</summary>
        string Value { get; set; }

    }
}