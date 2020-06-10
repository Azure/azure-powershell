namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Copy deployment slot parameters.</summary>
    public partial class CsmCopySlotEntity :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmCopySlotEntity,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmCopySlotEntityInternal
    {

        /// <summary>Backing field for <see cref="SiteConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig _siteConfig;

        /// <summary>
        /// The site object which will be merged with the source slot site
        /// to produce new destination slot site object.
        /// <code>null</code> to just copy source slot content. Otherwise a <code>Site</code>
        /// object with properties to override source slot site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig SiteConfig { get => (this._siteConfig = this._siteConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteConfig()); set => this._siteConfig = value; }

        /// <summary>Backing field for <see cref="TargetSlot" /> property.</summary>
        private string _targetSlot;

        /// <summary>Destination deployment slot during copy operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TargetSlot { get => this._targetSlot; set => this._targetSlot = value; }

        /// <summary>Creates an new <see cref="CsmCopySlotEntity" /> instance.</summary>
        public CsmCopySlotEntity()
        {

        }
    }
    /// Copy deployment slot parameters.
    public partial interface ICsmCopySlotEntity :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The site object which will be merged with the source slot site
        /// to produce new destination slot site object.
        /// <code>null</code> to just copy source slot content. Otherwise a <code>Site</code>
        /// object with properties to override source slot site.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The site object which will be merged with the source slot site
        to produce new destination slot site object.
        <code>null</code> to just copy source slot content. Otherwise a <code>Site</code>
        object with properties to override source slot site.",
        SerializedName = @"siteConfig",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig SiteConfig { get; set; }
        /// <summary>Destination deployment slot during copy operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Destination deployment slot during copy operation.",
        SerializedName = @"targetSlot",
        PossibleTypes = new [] { typeof(string) })]
        string TargetSlot { get; set; }

    }
    /// Copy deployment slot parameters.
    internal partial interface ICsmCopySlotEntityInternal

    {
        /// <summary>
        /// The site object which will be merged with the source slot site
        /// to produce new destination slot site object.
        /// <code>null</code> to just copy source slot content. Otherwise a <code>Site</code>
        /// object with properties to override source slot site.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig SiteConfig { get; set; }
        /// <summary>Destination deployment slot during copy operation.</summary>
        string TargetSlot { get; set; }

    }
}