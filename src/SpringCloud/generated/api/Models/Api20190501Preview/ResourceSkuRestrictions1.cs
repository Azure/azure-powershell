namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    public partial class ResourceSkuRestrictions1 :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictions1,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictions1Internal
    {

        /// <summary>Internal Acessors for RestrictionInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictionInfo Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictions1Internal.RestrictionInfo { get => (this._restrictionInfo = this._restrictionInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ResourceSkuRestrictionInfo()); set { {_restrictionInfo = value;} } }

        /// <summary>Backing field for <see cref="ReasonCode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsReasonCode? _reasonCode;

        /// <summary>
        /// Gets the reason for restriction. Possible values include: 'QuotaId', 'NotAvailableForSubscription'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsReasonCode? ReasonCode { get => this._reasonCode; set => this._reasonCode = value; }

        /// <summary>Backing field for <see cref="RestrictionInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictionInfo _restrictionInfo;

        /// <summary>Gets the information about the restriction where the SKU cannot be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictionInfo RestrictionInfo { get => (this._restrictionInfo = this._restrictionInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ResourceSkuRestrictionInfo()); set => this._restrictionInfo = value; }

        /// <summary>Gets locations where the SKU is restricted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string[] RestrictionInfoLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictionInfoInternal)RestrictionInfo).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictionInfoInternal)RestrictionInfo).Location = value; }

        /// <summary>Gets list of availability zones where the SKU is restricted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string[] RestrictionInfoZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictionInfoInternal)RestrictionInfo).Zone; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictionInfoInternal)RestrictionInfo).Zone = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsType? _type;

        /// <summary>Gets the type of restrictions. Possible values include: 'Location', 'Zone'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsType? Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string[] _value;

        /// <summary>
        /// Gets the value of restrictions. If the restriction type is set to
        /// location. This would be different locations where the SKU is restricted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ResourceSkuRestrictions1" /> instance.</summary>
        public ResourceSkuRestrictions1()
        {

        }
    }
    public partial interface IResourceSkuRestrictions1 :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets the reason for restriction. Possible values include: 'QuotaId', 'NotAvailableForSubscription'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the reason for restriction. Possible values include: 'QuotaId', 'NotAvailableForSubscription'",
        SerializedName = @"reasonCode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsReasonCode) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsReasonCode? ReasonCode { get; set; }
        /// <summary>Gets locations where the SKU is restricted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets locations where the SKU is restricted",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        string[] RestrictionInfoLocation { get; set; }
        /// <summary>Gets list of availability zones where the SKU is restricted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets list of availability zones where the SKU is restricted.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string[] RestrictionInfoZone { get; set; }
        /// <summary>Gets the type of restrictions. Possible values include: 'Location', 'Zone'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the type of restrictions. Possible values include: 'Location', 'Zone'",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsType) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsType? Type { get; set; }
        /// <summary>
        /// Gets the value of restrictions. If the restriction type is set to
        /// location. This would be different locations where the SKU is restricted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the value of restrictions. If the restriction type is set to
        location. This would be different locations where the SKU is restricted.",
        SerializedName = @"values",
        PossibleTypes = new [] { typeof(string) })]
        string[] Value { get; set; }

    }
    public partial interface IResourceSkuRestrictions1Internal

    {
        /// <summary>
        /// Gets the reason for restriction. Possible values include: 'QuotaId', 'NotAvailableForSubscription'
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsReasonCode? ReasonCode { get; set; }
        /// <summary>Gets the information about the restriction where the SKU cannot be used.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceSkuRestrictionInfo RestrictionInfo { get; set; }
        /// <summary>Gets locations where the SKU is restricted</summary>
        string[] RestrictionInfoLocation { get; set; }
        /// <summary>Gets list of availability zones where the SKU is restricted.</summary>
        string[] RestrictionInfoZone { get; set; }
        /// <summary>Gets the type of restrictions. Possible values include: 'Location', 'Zone'</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ResourceSkuRestrictionsType? Type { get; set; }
        /// <summary>
        /// Gets the value of restrictions. If the restriction type is set to
        /// location. This would be different locations where the SKU is restricted.
        /// </summary>
        string[] Value { get; set; }

    }
}