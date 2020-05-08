namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The list of language extension objects.</summary>
    public partial class LanguageExtensionsList :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtensionsList,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtensionsListInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtension[] _value;

        /// <summary>The list of language extensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtension[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="LanguageExtensionsList" /> instance.</summary>
        public LanguageExtensionsList()
        {

        }
    }
    /// The list of language extension objects.
    public partial interface ILanguageExtensionsList :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The list of language extensions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of language extensions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtension) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtension[] Value { get; set; }

    }
    /// The list of language extension objects.
    internal partial interface ILanguageExtensionsListInternal

    {
        /// <summary>The list of language extensions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ILanguageExtension[] Value { get; set; }

    }
}