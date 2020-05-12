namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The LegalHold property of a blob container.</summary>
    public partial class LegalHoldProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldPropertiesInternal
    {

        /// <summary>Backing field for <see cref="HasLegalHold" /> property.</summary>
        private bool? _hasLegalHold;

        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HasLegalHold { get => this._hasLegalHold; }

        /// <summary>Internal Acessors for HasLegalHold</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldPropertiesInternal.HasLegalHold { get => this._hasLegalHold; set { {_hasLegalHold = value;} } }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[] _tag;

        /// <summary>The list of LegalHold tags of a blob container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[] Tag { get => this._tag; set => this._tag = value; }

        /// <summary>Creates an new <see cref="LegalHoldProperties" /> instance.</summary>
        public LegalHoldProperties()
        {

        }
    }
    /// The LegalHold property of a blob container.
    public partial interface ILegalHoldProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account.",
        SerializedName = @"hasLegalHold",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HasLegalHold { get;  }
        /// <summary>The list of LegalHold tags of a blob container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of LegalHold tags of a blob container.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[] Tag { get; set; }

    }
    /// The LegalHold property of a blob container.
    internal partial interface ILegalHoldPropertiesInternal

    {
        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        bool? HasLegalHold { get; set; }
        /// <summary>The list of LegalHold tags of a blob container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[] Tag { get; set; }

    }
}