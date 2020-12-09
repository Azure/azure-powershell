namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The language extension object.</summary>
    public partial class LanguageExtension :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtensionInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.LanguageExtensionName? _name;

        /// <summary>The language extension name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.LanguageExtensionName? Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="LanguageExtension" /> instance.</summary>
        public LanguageExtension()
        {

        }
    }
    /// The language extension object.
    public partial interface ILanguageExtension :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The language extension name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The language extension name.",
        SerializedName = @"languageExtensionName",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.LanguageExtensionName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.LanguageExtensionName? Name { get; set; }

    }
    /// The language extension object.
    internal partial interface ILanguageExtensionInternal

    {
        /// <summary>The language extension name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.LanguageExtensionName? Name { get; set; }

    }
}