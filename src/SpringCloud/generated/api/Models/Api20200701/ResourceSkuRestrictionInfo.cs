namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Information about the restriction where the SKU cannot be used</summary>
    public partial class ResourceSkuRestrictionInfo :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionInfo,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceSkuRestrictionInfoInternal
    {

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string[] _location;

        /// <summary>Gets locations where the SKU is restricted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string[] Location { get => this._location; set => this._location = value; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string[] _zone;

        /// <summary>Gets list of availability zones where the SKU is restricted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string[] Zone { get => this._zone; set => this._zone = value; }

        /// <summary>Creates an new <see cref="ResourceSkuRestrictionInfo" /> instance.</summary>
        public ResourceSkuRestrictionInfo()
        {

        }
    }
    /// Information about the restriction where the SKU cannot be used
    public partial interface IResourceSkuRestrictionInfo :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Gets locations where the SKU is restricted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets locations where the SKU is restricted",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        string[] Location { get; set; }
        /// <summary>Gets list of availability zones where the SKU is restricted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets list of availability zones where the SKU is restricted.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string[] Zone { get; set; }

    }
    /// Information about the restriction where the SKU cannot be used
    public partial interface IResourceSkuRestrictionInfoInternal

    {
        /// <summary>Gets locations where the SKU is restricted</summary>
        string[] Location { get; set; }
        /// <summary>Gets list of availability zones where the SKU is restricted.</summary>
        string[] Zone { get; set; }

    }
}