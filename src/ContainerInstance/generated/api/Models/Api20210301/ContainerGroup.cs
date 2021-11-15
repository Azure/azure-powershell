namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>A container group.</summary>
    public partial class ContainerGroup :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroup,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Resource();

        /// <summary>The containers within the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[] Container { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).Container; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).Container = value ; }

        /// <summary>The DNS servers for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string[] DnsConfigNameServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).DnsConfigNameServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).DnsConfigNameServer = value ?? null /* arrayOf */; }

        /// <summary>The DNS options for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string DnsConfigOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).DnsConfigOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).DnsConfigOption = value ?? null; }

        /// <summary>The DNS search domains for hostname lookup in the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string DnsConfigSearchDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).DnsConfigSearchDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).DnsConfigSearchDomain = value ?? null; }

        /// <summary>The encryption key name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string EncryptionPropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).EncryptionPropertyKeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).EncryptionPropertyKeyName = value ?? null; }

        /// <summary>The encryption key version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string EncryptionPropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).EncryptionPropertyKeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).EncryptionPropertyKeyVersion = value ?? null; }

        /// <summary>The keyvault base url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string EncryptionPropertyVaultBaseUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).EncryptionPropertyVaultBaseUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).EncryptionPropertyVaultBaseUrl = value ?? null; }

        /// <summary>The Dns name label for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string IPAddressDnsNameLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressDnsNameLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressDnsNameLabel = value ?? null; }

        /// <summary>The FQDN for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string IPAddressFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressFqdn; }

        /// <summary>The IP exposed to the public internet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string IPAddressIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressIP = value ?? null; }

        /// <summary>The list of ports exposed on the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[] IPAddressPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressPort; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressPort = value ?? null /* arrayOf */; }

        /// <summary>Specifies if the IP is exposed to the public internet or private VNET.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType? IPAddressType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType)""); }

        /// <summary>The resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentity _identity;

        /// <summary>The identity of the container group, if configured.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupIdentity()); set => this._identity = value; }

        /// <summary>
        /// The principal id of the container group identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityInternal)Identity).PrincipalId; }

        /// <summary>
        /// The tenant id associated with the container group. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityInternal)Identity).TenantId; }

        /// <summary>
        /// The type of identity used for the container group. The type 'SystemAssigned, UserAssigned' includes both an implicitly
        /// created identity and a set of user assigned identities. The type 'None' will remove any identities from the container
        /// group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ResourceIdentityType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityInternal)Identity).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ResourceIdentityType)""); }

        /// <summary>
        /// The list of user identities associated with the container group. The user identity dictionary key references will be ARM
        /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityInternal)Identity).UserAssignedIdentity = value ?? null /* model class */; }

        /// <summary>The image registry credentials by which the container group is created from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[] ImageRegistryCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).ImageRegistryCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).ImageRegistryCredentials = value ?? null /* arrayOf */; }

        /// <summary>The init containers for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[] InitContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).InitContainer; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).InitContainer = value ?? null /* arrayOf */; }

        /// <summary>The events of this container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).InstanceViewEvent; }

        /// <summary>The state of the container group. Only valid in response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string InstanceViewState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).InstanceViewState; }

        /// <summary>The resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>The log type to be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType? LogAnalyticLogType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).LogAnalyticLogType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).LogAnalyticLogType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType)""); }

        /// <summary>Metadata for log analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata LogAnalyticMetadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).LogAnalyticMetadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).LogAnalyticMetadata = value ?? null /* model class */; }

        /// <summary>The workspace id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string LogAnalyticWorkspaceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).LogAnalyticWorkspaceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).LogAnalyticWorkspaceId = value ?? null; }

        /// <summary>The workspace key for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string LogAnalyticWorkspaceKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).LogAnalyticWorkspaceKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).LogAnalyticWorkspaceKey = value ?? null; }

        /// <summary>The workspace resource id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId LogAnalyticWorkspaceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).LogAnalyticWorkspaceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).LogAnalyticWorkspaceResourceId = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Diagnostic</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnostics Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.Diagnostic { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).Diagnostic; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).Diagnostic = value; }

        /// <summary>Internal Acessors for DiagnosticLogAnalytic</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalytics Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.DiagnosticLogAnalytic { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).DiagnosticLogAnalytic; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).DiagnosticLogAnalytic = value; }

        /// <summary>Internal Acessors for DnsConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfiguration Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.DnsConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).DnsConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).DnsConfig = value; }

        /// <summary>Internal Acessors for EncryptionProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionProperties Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.EncryptionProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).EncryptionProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).EncryptionProperty = value; }

        /// <summary>Internal Acessors for IPAddress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddress Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddress = value; }

        /// <summary>Internal Acessors for IPAddressFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.IPAddressFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).IPAddressFqdn = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentity Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for InstanceView</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.InstanceView { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).InstanceView; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).InstanceView = value; }

        /// <summary>Internal Acessors for InstanceViewEvent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.InstanceViewEvent { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).InstanceViewEvent; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).InstanceViewEvent = value; }

        /// <summary>Internal Acessors for InstanceViewState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.InstanceViewState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).InstanceViewState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).InstanceViewState = value; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupNetworkProfile Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.NetworkProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).NetworkProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).NetworkProfile = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Type = value; }

        /// <summary>The resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Name; }

        /// <summary>The identifier for a network profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string NetworkProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).NetworkProfileId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).NetworkProfileId = value ?? null; }

        /// <summary>The operating system type required by the containers in the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes OSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).OSType = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties _property;

        /// <summary>The container group properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupProperties()); set => this._property = value; }

        /// <summary>
        /// The provisioning state of the container group. This only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Restart policy for all containers within the container group.
        /// - `Always` Always restart
        /// - `OnFailure` Restart on failure
        /// - `Never` Never restart
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy? RestartPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).RestartPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).RestartPolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy)""); }

        /// <summary>The SKU for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku? Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).Sku = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku)""); }

        /// <summary>The resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Tag = value ?? null /* model class */; }

        /// <summary>The resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal)__resource).Type; }

        /// <summary>The list of volumes that can be mounted by containers in this container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[] Volume { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).Volume; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal)Property).Volume = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="ContainerGroup" /> instance.</summary>
        public ContainerGroup()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// A container group.
    public partial interface IContainerGroup :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResource
    {
        /// <summary>The containers within the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The containers within the container group.",
        SerializedName = @"containers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[] Container { get; set; }
        /// <summary>The DNS servers for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DNS servers for the container group.",
        SerializedName = @"nameServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsConfigNameServer { get; set; }
        /// <summary>The DNS options for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DNS options for the container group.",
        SerializedName = @"options",
        PossibleTypes = new [] { typeof(string) })]
        string DnsConfigOption { get; set; }
        /// <summary>The DNS search domains for hostname lookup in the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DNS search domains for hostname lookup in the container group.",
        SerializedName = @"searchDomains",
        PossibleTypes = new [] { typeof(string) })]
        string DnsConfigSearchDomain { get; set; }
        /// <summary>The encryption key name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The encryption key name.",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string EncryptionPropertyKeyName { get; set; }
        /// <summary>The encryption key version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The encryption key version.",
        SerializedName = @"keyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string EncryptionPropertyKeyVersion { get; set; }
        /// <summary>The keyvault base url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The keyvault base url.",
        SerializedName = @"vaultBaseUrl",
        PossibleTypes = new [] { typeof(string) })]
        string EncryptionPropertyVaultBaseUrl { get; set; }
        /// <summary>The Dns name label for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Dns name label for the IP.",
        SerializedName = @"dnsNameLabel",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressDnsNameLabel { get; set; }
        /// <summary>The FQDN for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The FQDN for the IP.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressFqdn { get;  }
        /// <summary>The IP exposed to the public internet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP exposed to the public internet.",
        SerializedName = @"ip",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressIP { get; set; }
        /// <summary>The list of ports exposed on the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of ports exposed on the container group.",
        SerializedName = @"ports",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[] IPAddressPort { get; set; }
        /// <summary>Specifies if the IP is exposed to the public internet or private VNET.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies if the IP is exposed to the public internet or private VNET.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType? IPAddressType { get; set; }
        /// <summary>
        /// The principal id of the container group identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal id of the container group identity. This property will only be provided for a system assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>
        /// The tenant id associated with the container group. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant id associated with the container group. This property will only be provided for a system assigned identity.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>
        /// The type of identity used for the container group. The type 'SystemAssigned, UserAssigned' includes both an implicitly
        /// created identity and a set of user assigned identities. The type 'None' will remove any identities from the container
        /// group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity used for the container group. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the container group.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ResourceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ResourceIdentityType? IdentityType { get; set; }
        /// <summary>
        /// The list of user identities associated with the container group. The user identity dictionary key references will be ARM
        /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of user identities associated with the container group. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>The image registry credentials by which the container group is created from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The image registry credentials by which the container group is created from.",
        SerializedName = @"imageRegistryCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[] ImageRegistryCredentials { get; set; }
        /// <summary>The init containers for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The init containers for a container group.",
        SerializedName = @"initContainers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[] InitContainer { get; set; }
        /// <summary>The events of this container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The events of this container group.",
        SerializedName = @"events",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get;  }
        /// <summary>The state of the container group. Only valid in response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the container group. Only valid in response.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceViewState { get;  }
        /// <summary>The log type to be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The log type to be used.",
        SerializedName = @"logType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType? LogAnalyticLogType { get; set; }
        /// <summary>Metadata for log analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Metadata for log analytics.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata LogAnalyticMetadata { get; set; }
        /// <summary>The workspace id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The workspace id for log analytics",
        SerializedName = @"workspaceId",
        PossibleTypes = new [] { typeof(string) })]
        string LogAnalyticWorkspaceId { get; set; }
        /// <summary>The workspace key for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The workspace key for log analytics",
        SerializedName = @"workspaceKey",
        PossibleTypes = new [] { typeof(string) })]
        string LogAnalyticWorkspaceKey { get; set; }
        /// <summary>The workspace resource id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The workspace resource id for log analytics",
        SerializedName = @"workspaceResourceId",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId LogAnalyticWorkspaceResourceId { get; set; }
        /// <summary>The identifier for a network profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identifier for a network profile.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileId { get; set; }
        /// <summary>The operating system type required by the containers in the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The operating system type required by the containers in the container group.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes OSType { get; set; }
        /// <summary>
        /// The provisioning state of the container group. This only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the container group. This only appears in the response.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// Restart policy for all containers within the container group.
        /// - `Always` Always restart
        /// - `OnFailure` Restart on failure
        /// - `Never` Never restart
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Restart policy for all containers within the container group.
        - `Always` Always restart
        - `OnFailure` Restart on failure
        - `Never` Never restart
        ",
        SerializedName = @"restartPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy? RestartPolicy { get; set; }
        /// <summary>The SKU for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The SKU for a container group.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku? Sku { get; set; }
        /// <summary>The list of volumes that can be mounted by containers in this container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of volumes that can be mounted by containers in this container group.",
        SerializedName = @"volumes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[] Volume { get; set; }

    }
    /// A container group.
    internal partial interface IContainerGroupInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal
    {
        /// <summary>The containers within the container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[] Container { get; set; }
        /// <summary>The diagnostic information for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnostics Diagnostic { get; set; }
        /// <summary>Container group log analytics information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalytics DiagnosticLogAnalytic { get; set; }
        /// <summary>The DNS config information for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfiguration DnsConfig { get; set; }
        /// <summary>The DNS servers for the container group.</summary>
        string[] DnsConfigNameServer { get; set; }
        /// <summary>The DNS options for the container group.</summary>
        string DnsConfigOption { get; set; }
        /// <summary>The DNS search domains for hostname lookup in the container group.</summary>
        string DnsConfigSearchDomain { get; set; }
        /// <summary>The encryption properties for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionProperties EncryptionProperty { get; set; }
        /// <summary>The encryption key name.</summary>
        string EncryptionPropertyKeyName { get; set; }
        /// <summary>The encryption key version.</summary>
        string EncryptionPropertyKeyVersion { get; set; }
        /// <summary>The keyvault base url.</summary>
        string EncryptionPropertyVaultBaseUrl { get; set; }
        /// <summary>The IP address type of the container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddress IPAddress { get; set; }
        /// <summary>The Dns name label for the IP.</summary>
        string IPAddressDnsNameLabel { get; set; }
        /// <summary>The FQDN for the IP.</summary>
        string IPAddressFqdn { get; set; }
        /// <summary>The IP exposed to the public internet.</summary>
        string IPAddressIP { get; set; }
        /// <summary>The list of ports exposed on the container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[] IPAddressPort { get; set; }
        /// <summary>Specifies if the IP is exposed to the public internet or private VNET.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType? IPAddressType { get; set; }
        /// <summary>The identity of the container group, if configured.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentity Identity { get; set; }
        /// <summary>
        /// The principal id of the container group identity. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>
        /// The tenant id associated with the container group. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityTenantId { get; set; }
        /// <summary>
        /// The type of identity used for the container group. The type 'SystemAssigned, UserAssigned' includes both an implicitly
        /// created identity and a set of user assigned identities. The type 'None' will remove any identities from the container
        /// group.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ResourceIdentityType? IdentityType { get; set; }
        /// <summary>
        /// The list of user identities associated with the container group. The user identity dictionary key references will be ARM
        /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>The image registry credentials by which the container group is created from.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[] ImageRegistryCredentials { get; set; }
        /// <summary>The init containers for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[] InitContainer { get; set; }
        /// <summary>The instance view of the container group. Only valid in response.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView InstanceView { get; set; }
        /// <summary>The events of this container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get; set; }
        /// <summary>The state of the container group. Only valid in response.</summary>
        string InstanceViewState { get; set; }
        /// <summary>The log type to be used.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType? LogAnalyticLogType { get; set; }
        /// <summary>Metadata for log analytics.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata LogAnalyticMetadata { get; set; }
        /// <summary>The workspace id for log analytics</summary>
        string LogAnalyticWorkspaceId { get; set; }
        /// <summary>The workspace key for log analytics</summary>
        string LogAnalyticWorkspaceKey { get; set; }
        /// <summary>The workspace resource id for log analytics</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId LogAnalyticWorkspaceResourceId { get; set; }
        /// <summary>The network profile information for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupNetworkProfile NetworkProfile { get; set; }
        /// <summary>The identifier for a network profile.</summary>
        string NetworkProfileId { get; set; }
        /// <summary>The operating system type required by the containers in the container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes OSType { get; set; }
        /// <summary>The container group properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties Property { get; set; }
        /// <summary>
        /// The provisioning state of the container group. This only appears in the response.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// Restart policy for all containers within the container group.
        /// - `Always` Always restart
        /// - `OnFailure` Restart on failure
        /// - `Never` Never restart
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy? RestartPolicy { get; set; }
        /// <summary>The SKU for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku? Sku { get; set; }
        /// <summary>The list of volumes that can be mounted by containers in this container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[] Volume { get; set; }

    }
}