namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Describes a hybrid machine.</summary>
    public partial class Machine :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachine,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.TrackedResource();

        /// <summary>Specifies the AD fully qualified display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string AdFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).AdFqdn; }

        /// <summary>The hybrid machine agent full version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string AgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).AgentVersion; }

        /// <summary>
        /// Public Key that the client provides to be used during initial resource onboarding
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string ClientPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).ClientPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).ClientPublicKey = value; }

        /// <summary>Specifies the hybrid machine display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).DisplayName; }

        /// <summary>Specifies the DNS fully qualified display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string DnsFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).DnsFqdn; }

        /// <summary>Specifies the Windows domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string DomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).DomainName; }

        /// <summary>Details about the error state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[] ErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).ErrorDetail; }

        /// <summary>Machine Extensions information</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView[] Extension { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).Extension; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).Extension = value; }

        /// <summary>Specifies the hybrid machine FQDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).MachineFqdn; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineIdentity _identity;

        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineIdentity()); set => this._identity = value; }

        /// <summary>The identity's principal id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IIdentityInternal)Identity).PrincipalId; }

        /// <summary>The identity's tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IIdentityInternal)Identity).TenantId; }

        /// <summary>The identity type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IIdentityInternal)Identity).Type = value; }

        /// <summary>The time of the last status change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public global::System.DateTime? LastStatusChange { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LastStatusChange; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>The city or locality where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string LocationDataCity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LocationDataCity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LocationDataCity = value; }

        /// <summary>The country or region where the resource is located</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string LocationDataCountryOrRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LocationDataCountryOrRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LocationDataCountryOrRegion = value; }

        /// <summary>The district, state, or province where the resource is located.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string LocationDataDistrict { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LocationDataDistrict; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LocationDataDistrict = value; }

        /// <summary>A canonical name for the geographic or physical location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string LocationDataName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LocationDataName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LocationDataName = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>Internal Acessors for AdFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.AdFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).AdFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).AdFqdn = value; }

        /// <summary>Internal Acessors for AgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.AgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).AgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).AgentVersion = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).DisplayName = value; }

        /// <summary>Internal Acessors for DnsFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.DnsFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).DnsFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).DnsFqdn = value; }

        /// <summary>Internal Acessors for DomainName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.DomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).DomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).DomainName = value; }

        /// <summary>Internal Acessors for ErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[] Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.ErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).ErrorDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).ErrorDetail = value; }

        /// <summary>Internal Acessors for Fqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).MachineFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).MachineFqdn = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineIdentity Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for LastStatusChange</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.LastStatusChange { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LastStatusChange; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LastStatusChange = value; }

        /// <summary>Internal Acessors for LocationData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.LocationData { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LocationData; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).LocationData = value; }

        /// <summary>Internal Acessors for OSName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.OSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSName = value; }

        /// <summary>Internal Acessors for OSProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesOSProfile Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.OSProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSProfile = value; }

        /// <summary>Internal Acessors for OSProfileComputerName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.OSProfileComputerName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSProfileComputerName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSProfileComputerName = value; }

        /// <summary>Internal Acessors for OSSku</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.OSSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSSku; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSSku = value; }

        /// <summary>Internal Acessors for OSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.OSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSVersion = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineProperties1 Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineProperties1()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for VMUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineInternal.VMUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).VMUuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).VMUuid = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal)__trackedResource).Name; }

        /// <summary>The Operating System running on the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.FormatTable(Index = 2)]
        public string OSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSName; }

        /// <summary>Specifies the host OS name of the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string OSProfileComputerName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSProfileComputerName; }

        /// <summary>Specifies the Operating System product SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string OSSku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSSku; }

        /// <summary>The version of Operating System running on the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string OSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).OSVersion; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineProperties1 _property;

        /// <summary>Hybrid Compute Machine properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineProperties1 Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineProperties1()); set => this._property = value; }

        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.FormatTable(Index = 4)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).ProvisioningState; }

        /// <summary>The status of the hybrid machine agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.FormatTable(Index = 3)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).Status; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.IResourceInternal)__trackedResource).Type; }

        /// <summary>Specifies the hybrid machine unique ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string VMId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).VMId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).VMId = value; }

        /// <summary>Specifies the Arc Machine's unique SMBIOS ID</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.DoNotFormat]
        public string VMUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)Property).VMUuid; }

        /// <summary>Creates an new <see cref="Machine" /> instance.</summary>
        public Machine()
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
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Describes a hybrid machine.
    public partial interface IMachine :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ITrackedResource
    {
        /// <summary>Specifies the AD fully qualified display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the AD fully qualified display name.",
        SerializedName = @"adFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string AdFqdn { get;  }
        /// <summary>The hybrid machine agent full version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hybrid machine agent full version.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string AgentVersion { get;  }
        /// <summary>
        /// Public Key that the client provides to be used during initial resource onboarding
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public Key that the client provides to be used during initial resource onboarding",
        SerializedName = @"clientPublicKey",
        PossibleTypes = new [] { typeof(string) })]
        string ClientPublicKey { get; set; }
        /// <summary>Specifies the hybrid machine display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the hybrid machine display name.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Specifies the DNS fully qualified display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the DNS fully qualified display name.",
        SerializedName = @"dnsFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string DnsFqdn { get;  }
        /// <summary>Specifies the Windows domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the Windows domain name.",
        SerializedName = @"domainName",
        PossibleTypes = new [] { typeof(string) })]
        string DomainName { get;  }
        /// <summary>Details about the error state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Details about the error state.",
        SerializedName = @"errorDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[] ErrorDetail { get;  }
        /// <summary>Machine Extensions information</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Machine Extensions information",
        SerializedName = @"extensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView[] Extension { get; set; }
        /// <summary>Specifies the hybrid machine FQDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the hybrid machine FQDN.",
        SerializedName = @"machineFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get;  }
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
        /// <summary>The time of the last status change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time of the last status change.",
        SerializedName = @"lastStatusChange",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastStatusChange { get;  }
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
        /// <summary>The Operating System running on the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Operating System running on the hybrid machine.",
        SerializedName = @"osName",
        PossibleTypes = new [] { typeof(string) })]
        string OSName { get;  }
        /// <summary>Specifies the host OS name of the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the host OS name of the hybrid machine.",
        SerializedName = @"computerName",
        PossibleTypes = new [] { typeof(string) })]
        string OSProfileComputerName { get;  }
        /// <summary>Specifies the Operating System product SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the Operating System product SKU.",
        SerializedName = @"osSku",
        PossibleTypes = new [] { typeof(string) })]
        string OSSku { get;  }
        /// <summary>The version of Operating System running on the hybrid machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The version of Operating System running on the hybrid machine.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get;  }
        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state, which only appears in the response.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The status of the hybrid machine agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the hybrid machine agent.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? Status { get;  }
        /// <summary>Specifies the hybrid machine unique ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the hybrid machine unique ID.",
        SerializedName = @"vmId",
        PossibleTypes = new [] { typeof(string) })]
        string VMId { get; set; }
        /// <summary>Specifies the Arc Machine's unique SMBIOS ID</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the Arc Machine's unique SMBIOS ID",
        SerializedName = @"vmUuid",
        PossibleTypes = new [] { typeof(string) })]
        string VMUuid { get;  }

    }
    /// Describes a hybrid machine.
    internal partial interface IMachineInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ITrackedResourceInternal
    {
        /// <summary>Specifies the AD fully qualified display name.</summary>
        string AdFqdn { get; set; }
        /// <summary>The hybrid machine agent full version.</summary>
        string AgentVersion { get; set; }
        /// <summary>
        /// Public Key that the client provides to be used during initial resource onboarding
        /// </summary>
        string ClientPublicKey { get; set; }
        /// <summary>Specifies the hybrid machine display name.</summary>
        string DisplayName { get; set; }
        /// <summary>Specifies the DNS fully qualified display name.</summary>
        string DnsFqdn { get; set; }
        /// <summary>Specifies the Windows domain name.</summary>
        string DomainName { get; set; }
        /// <summary>Details about the error state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[] ErrorDetail { get; set; }
        /// <summary>Machine Extensions information</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView[] Extension { get; set; }
        /// <summary>Specifies the hybrid machine FQDN.</summary>
        string Fqdn { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineIdentity Identity { get; set; }
        /// <summary>The identity's principal id.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>The identity's tenant id.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>The identity type.</summary>
        string IdentityType { get; set; }
        /// <summary>The time of the last status change.</summary>
        global::System.DateTime? LastStatusChange { get; set; }
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
        /// <summary>The Operating System running on the hybrid machine.</summary>
        string OSName { get; set; }
        /// <summary>Specifies the operating system settings for the hybrid machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesOSProfile OSProfile { get; set; }
        /// <summary>Specifies the host OS name of the hybrid machine.</summary>
        string OSProfileComputerName { get; set; }
        /// <summary>Specifies the Operating System product SKU.</summary>
        string OSSku { get; set; }
        /// <summary>The version of Operating System running on the hybrid machine.</summary>
        string OSVersion { get; set; }
        /// <summary>Hybrid Compute Machine properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineProperties1 Property { get; set; }
        /// <summary>The provisioning state, which only appears in the response.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The status of the hybrid machine agent.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes? Status { get; set; }
        /// <summary>Specifies the hybrid machine unique ID.</summary>
        string VMId { get; set; }
        /// <summary>Specifies the Arc Machine's unique SMBIOS ID</summary>
        string VMUuid { get; set; }

    }
}