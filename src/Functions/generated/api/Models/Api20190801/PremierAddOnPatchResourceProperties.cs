namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>PremierAddOnPatchResource resource specific properties</summary>
    public partial class PremierAddOnPatchResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnPatchResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnPatchResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="MarketplaceOffer" /> property.</summary>
        private string _marketplaceOffer;

        /// <summary>Premier add on Marketplace offer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MarketplaceOffer { get => this._marketplaceOffer; set => this._marketplaceOffer = value; }

        /// <summary>Backing field for <see cref="MarketplacePublisher" /> property.</summary>
        private string _marketplacePublisher;

        /// <summary>Premier add on Marketplace publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MarketplacePublisher { get => this._marketplacePublisher; set => this._marketplacePublisher = value; }

        /// <summary>Backing field for <see cref="Product" /> property.</summary>
        private string _product;

        /// <summary>Premier add on Product.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Product { get => this._product; set => this._product = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private string _sku;

        /// <summary>Premier add on SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Sku { get => this._sku; set => this._sku = value; }

        /// <summary>Backing field for <see cref="Vendor" /> property.</summary>
        private string _vendor;

        /// <summary>Premier add on Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Vendor { get => this._vendor; set => this._vendor = value; }

        /// <summary>Creates an new <see cref="PremierAddOnPatchResourceProperties" /> instance.</summary>
        public PremierAddOnPatchResourceProperties()
        {

        }
    }
    /// PremierAddOnPatchResource resource specific properties
    public partial interface IPremierAddOnPatchResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Premier add on Marketplace offer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Premier add on Marketplace offer.",
        SerializedName = @"marketplaceOffer",
        PossibleTypes = new [] { typeof(string) })]
        string MarketplaceOffer { get; set; }
        /// <summary>Premier add on Marketplace publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Premier add on Marketplace publisher.",
        SerializedName = @"marketplacePublisher",
        PossibleTypes = new [] { typeof(string) })]
        string MarketplacePublisher { get; set; }
        /// <summary>Premier add on Product.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Premier add on Product.",
        SerializedName = @"product",
        PossibleTypes = new [] { typeof(string) })]
        string Product { get; set; }
        /// <summary>Premier add on SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Premier add on SKU.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(string) })]
        string Sku { get; set; }
        /// <summary>Premier add on Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Premier add on Vendor.",
        SerializedName = @"vendor",
        PossibleTypes = new [] { typeof(string) })]
        string Vendor { get; set; }

    }
    /// PremierAddOnPatchResource resource specific properties
    internal partial interface IPremierAddOnPatchResourcePropertiesInternal

    {
        /// <summary>Premier add on Marketplace offer.</summary>
        string MarketplaceOffer { get; set; }
        /// <summary>Premier add on Marketplace publisher.</summary>
        string MarketplacePublisher { get; set; }
        /// <summary>Premier add on Product.</summary>
        string Product { get; set; }
        /// <summary>Premier add on SKU.</summary>
        string Sku { get; set; }
        /// <summary>Premier add on Vendor.</summary>
        string Vendor { get; set; }

    }
}