namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Describes a hybrid machine Update.</summary>
    public partial class MachineUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IUpdateResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IUpdateResource __updateResource = new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.UpdateResource();

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateIdentity _identity;

        /// <summary>Hybrid Compute Machine Managed Identity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.MachineUpdateIdentity()); set => this._identity = value; }

        /// <summary>The identity's principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IIdentityInternal)Identity).PrincipalId; }

        /// <summary>The identity's tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IIdentityInternal)Identity).TenantId; }

        /// <summary>The identity type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IIdentityInternal)Identity).Type = value; }

        /// <summary>The city or locality where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string LocationDataCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdatePropertiesInternal)Property).LocationDataCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdatePropertiesInternal)Property).LocationDataCity = value; }

        /// <summary>The country or region where the resource is located</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string LocationDataCountryOrRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdatePropertiesInternal)Property).LocationDataCountryOrRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdatePropertiesInternal)Property).LocationDataCountryOrRegion = value; }

        /// <summary>The district, state, or province where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string LocationDataDistrict { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdatePropertiesInternal)Property).LocationDataDistrict; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdatePropertiesInternal)Property).LocationDataDistrict = value; }

        /// <summary>A canonical name for the geographic or physical location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string LocationDataName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdatePropertiesInternal)Property).LocationDataName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdatePropertiesInternal)Property).LocationDataName = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateIdentity Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.MachineUpdateIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for LocationData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateInternal.LocationData { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdatePropertiesInternal)Property).LocationData; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdatePropertiesInternal)Property).LocationData = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateProperties1 Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.MachineUpdateProperties1()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateProperties1 _property;

        /// <summary>Hybrid Compute Machine properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateProperties1 Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.MachineUpdateProperties1()); set => this._property = value; }

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IUpdateResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IUpdateResourceInternal)__updateResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IUpdateResourceInternal)__updateResource).Tag = value; }

        /// <summary>Creates an new <see cref="MachineUpdate" /> instance.</summary>
        public MachineUpdate()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__updateResource), __updateResource);
            await eventListener.AssertObjectIsValid(nameof(__updateResource), __updateResource);
        }
    }
    /// Describes a hybrid machine Update.
    public partial interface IMachineUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IUpdateResource
    {
        /// <summary>The identity's principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The identity's principal id.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>The identity's tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The identity's tenant id.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>The identity type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityType { get; set; }
        /// <summary>The city or locality where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The city or locality where the resource is located.",
        SerializedName = @"city",
        PossibleTypes = new [] { typeof(string) })]
        string LocationDataCity { get; set; }
        /// <summary>The country or region where the resource is located</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The country or region where the resource is located",
        SerializedName = @"countryOrRegion",
        PossibleTypes = new [] { typeof(string) })]
        string LocationDataCountryOrRegion { get; set; }
        /// <summary>The district, state, or province where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The district, state, or province where the resource is located.",
        SerializedName = @"district",
        PossibleTypes = new [] { typeof(string) })]
        string LocationDataDistrict { get; set; }
        /// <summary>A canonical name for the geographic or physical location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"A canonical name for the geographic or physical location.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string LocationDataName { get; set; }

    }
    /// Describes a hybrid machine Update.
    internal partial interface IMachineUpdateInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IUpdateResourceInternal
    {
        /// <summary>Hybrid Compute Machine Managed Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateIdentity Identity { get; set; }
        /// <summary>The identity's principal id.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>The identity's tenant id.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>The identity type.</summary>
        string IdentityType { get; set; }
        /// <summary>Metadata pertaining to the geographic location of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData LocationData { get; set; }
        /// <summary>The city or locality where the resource is located.</summary>
        string LocationDataCity { get; set; }
        /// <summary>The country or region where the resource is located</summary>
        string LocationDataCountryOrRegion { get; set; }
        /// <summary>The district, state, or province where the resource is located.</summary>
        string LocationDataDistrict { get; set; }
        /// <summary>A canonical name for the geographic or physical location.</summary>
        string LocationDataName { get; set; }
        /// <summary>Hybrid Compute Machine properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IMachineUpdateProperties1 Property { get; set; }

    }
}