namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The usage names that can be used; currently limited to StorageAccount.</summary>
    public partial class UsageName :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageName,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageNameInternal
    {

        /// <summary>Backing field for <see cref="LocalizedValue" /> property.</summary>
        private string _localizedValue;

        /// <summary>Gets a localized string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LocalizedValue { get => this._localizedValue; }

        /// <summary>Internal Acessors for LocalizedValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageNameInternal.LocalizedValue { get => this._localizedValue; set { {_localizedValue = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUsageNameInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>Gets a string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Value { get => this._value; }

        /// <summary>Creates an new <see cref="UsageName" /> instance.</summary>
        public UsageName()
        {

        }
    }
    /// The usage names that can be used; currently limited to StorageAccount.
    public partial interface IUsageName :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Gets a localized string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a localized string describing the resource name.",
        SerializedName = @"localizedValue",
        PossibleTypes = new [] { typeof(string) })]
        string LocalizedValue { get;  }
        /// <summary>Gets a string describing the resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a string describing the resource name.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get;  }

    }
    /// The usage names that can be used; currently limited to StorageAccount.
    internal partial interface IUsageNameInternal

    {
        /// <summary>Gets a localized string describing the resource name.</summary>
        string LocalizedValue { get; set; }
        /// <summary>Gets a string describing the resource name.</summary>
        string Value { get; set; }

    }
}