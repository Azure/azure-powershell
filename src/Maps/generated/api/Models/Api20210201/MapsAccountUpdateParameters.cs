namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>Parameters used to update an existing Maps Account.</summary>
    public partial class MapsAccountUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal
    {

        /// <summary>
        /// Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared
        /// Keys authentication from any usage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public bool? DisableLocalAuth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).DisableLocalAuth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).DisableLocalAuth = value ?? default(bool); }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind? _kind;

        /// <summary>Get or Set Kind property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind? Kind { get => this._kind; set => this._kind = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SkuTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal.SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal)Sku).Tier = value; }

        /// <summary>Internal Acessors for UniqueId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersInternal.UniqueId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).UniqueId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).UniqueId = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties _property;

        /// <summary>The map account properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountProperties()); set => this._property = value; }

        /// <summary>the state of the provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku _sku;

        /// <summary>The SKU of this account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.Sku()); set => this._sku = value; }

        /// <summary>The name of the SKU, in standard format (such as S0).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal)Sku).Name = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name)""); }

        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal)Sku).Tier; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersTags _tag;

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
        /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
        /// than 128 characters and value no greater than 256 characters.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountUpdateParametersTags()); set => this._tag = value; }

        /// <summary>A unique identifier for the maps account</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string UniqueId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).UniqueId; }

        /// <summary>Creates an new <see cref="MapsAccountUpdateParameters" /> instance.</summary>
        public MapsAccountUpdateParameters()
        {

        }
    }
    /// Parameters used to update an existing Maps Account.
    public partial interface IMapsAccountUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared
        /// Keys authentication from any usage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared Keys authentication from any usage.",
        SerializedName = @"disableLocalAuth",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DisableLocalAuth { get; set; }
        /// <summary>Get or Set Kind property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Get or Set Kind property.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind? Kind { get; set; }
        /// <summary>the state of the provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"the state of the provisioning.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The name of the SKU, in standard format (such as S0).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the SKU, in standard format (such as S0).",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name? SkuName { get; set; }
        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the sku tier. This is based on the SKU name.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string SkuTier { get;  }
        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
        /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
        /// than 128 characters and value no greater than 256 characters.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater than 128 characters and value no greater than 256 characters.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersTags Tag { get; set; }
        /// <summary>A unique identifier for the maps account</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A unique identifier for the maps account",
        SerializedName = @"uniqueId",
        PossibleTypes = new [] { typeof(string) })]
        string UniqueId { get;  }

    }
    /// Parameters used to update an existing Maps Account.
    internal partial interface IMapsAccountUpdateParametersInternal

    {
        /// <summary>
        /// Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared
        /// Keys authentication from any usage.
        /// </summary>
        bool? DisableLocalAuth { get; set; }
        /// <summary>Get or Set Kind property.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind? Kind { get; set; }
        /// <summary>The map account properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties Property { get; set; }
        /// <summary>the state of the provisioning.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The SKU of this account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku Sku { get; set; }
        /// <summary>The name of the SKU, in standard format (such as S0).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name? SkuName { get; set; }
        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        string SkuTier { get; set; }
        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
        /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
        /// than 128 characters and value no greater than 256 characters.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountUpdateParametersTags Tag { get; set; }
        /// <summary>A unique identifier for the maps account</summary>
        string UniqueId { get; set; }

    }
}