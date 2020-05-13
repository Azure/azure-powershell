namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The LegalHold property of a blob container.</summary>
    public partial class LegalHold :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHold,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldInternal
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
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldInternal.HasLegalHold { get => this._hasLegalHold; set { {_hasLegalHold = value;} } }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private string[] _tag;

        /// <summary>
        /// Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Tag { get => this._tag; set => this._tag = value; }

        /// <summary>Creates an new <see cref="LegalHold" /> instance.</summary>
        public LegalHold()
        {

        }
    }
    /// The LegalHold property of a blob container.
    public partial interface ILegalHold :
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
        /// <summary>
        /// Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(string) })]
        string[] Tag { get; set; }

    }
    /// The LegalHold property of a blob container.
    internal partial interface ILegalHoldInternal

    {
        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        bool? HasLegalHold { get; set; }
        /// <summary>
        /// Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP.
        /// </summary>
        string[] Tag { get; set; }

    }
}