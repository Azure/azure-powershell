namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Properties of the Domain Service.</summary>
    public partial class DomainServiceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal
    {

        /// <summary>Backing field for <see cref="DeploymentId" /> property.</summary>
        private string _deploymentId;

        /// <summary>Deployment Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string DeploymentId { get => this._deploymentId; }

        /// <summary>Backing field for <see cref="DomainConfigurationType" /> property.</summary>
        private string _domainConfigurationType;

        /// <summary>Domain Configuration Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string DomainConfigurationType { get => this._domainConfigurationType; set => this._domainConfigurationType = value; }

        /// <summary>Backing field for <see cref="DomainName" /> property.</summary>
        private string _domainName;

        /// <summary>
        /// The name of the Azure domain that the user would like to deploy Domain Services to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string DomainName { get => this._domainName; set => this._domainName = value; }

        /// <summary>Backing field for <see cref="DomainSecuritySetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings _domainSecuritySetting;

        /// <summary>DomainSecurity Settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings DomainSecuritySetting { get => (this._domainSecuritySetting = this._domainSecuritySetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings()); set => this._domainSecuritySetting = value; }

        /// <summary>A flag to determine whether or not NtlmV1 is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1? DomainSecuritySettingNtlmV1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)DomainSecuritySetting).NtlmV1; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)DomainSecuritySetting).NtlmV1 = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1)""); }

        /// <summary>
        /// A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords? DomainSecuritySettingSyncKerberosPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)DomainSecuritySetting).SyncKerberosPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)DomainSecuritySetting).SyncKerberosPassword = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords)""); }

        /// <summary>A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords? DomainSecuritySettingSyncNtlmPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)DomainSecuritySetting).SyncNtlmPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)DomainSecuritySetting).SyncNtlmPassword = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords)""); }

        /// <summary>A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords? DomainSecuritySettingSyncOnPremPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)DomainSecuritySetting).SyncOnPremPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)DomainSecuritySetting).SyncOnPremPassword = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords)""); }

        /// <summary>A flag to determine whether or not TlsV1 is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1? DomainSecuritySettingTlsV1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)DomainSecuritySetting).TlsV1; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)DomainSecuritySetting).TlsV1 = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1)""); }

        /// <summary>Backing field for <see cref="FilteredSync" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.FilteredSync? _filteredSync;

        /// <summary>Enabled or Disabled flag to turn on Group-based filtered sync</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.FilteredSync? FilteredSync { get => this._filteredSync; set => this._filteredSync = value; }

        /// <summary>NotAfter DateTime of configure ldaps certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public global::System.DateTime? LdapSettingCertificateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).CertificateNotAfter; }

        /// <summary>Thumbprint of configure ldaps certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public string LdapSettingCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).CertificateThumbprint; }

        /// <summary>
        /// A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess? LdapSettingExternalAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).ExternalAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).ExternalAccess = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess)""); }

        /// <summary>A flag to determine whether or not Secure LDAP is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps? LdapSettingLdap { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).Ldap; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).Ldap = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps)""); }

        /// <summary>
        /// The certificate required to configure Secure LDAP. The parameter passed here should be a base64encoded representation
        /// of the certificate pfx file.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public string LdapSettingPfxCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).PfxCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).PfxCertificate = value ?? null; }

        /// <summary>The password to decrypt the provided Secure LDAP certificate pfx file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public string LdapSettingPfxCertificatePassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).PfxCertificatePassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).PfxCertificatePassword = value ?? null; }

        /// <summary>Public certificate used to configure secure ldap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public string LdapSettingPublicCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).PublicCertificate; }

        /// <summary>Backing field for <see cref="LdapsSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings _ldapsSetting;

        /// <summary>Secure LDAP Settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings LdapsSetting { get => (this._ldapsSetting = this._ldapsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings()); set => this._ldapsSetting = value; }

        /// <summary>Internal Acessors for DeploymentId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.DeploymentId { get => this._deploymentId; set { {_deploymentId = value;} } }

        /// <summary>Internal Acessors for DomainSecuritySetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.DomainSecuritySetting { get => (this._domainSecuritySetting = this._domainSecuritySetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings()); set { {_domainSecuritySetting = value;} } }

        /// <summary>Internal Acessors for LdapSettingCertificateNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.LdapSettingCertificateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).CertificateNotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).CertificateNotAfter = value; }

        /// <summary>Internal Acessors for LdapSettingCertificateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.LdapSettingCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).CertificateThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).CertificateThumbprint = value; }

        /// <summary>Internal Acessors for LdapSettingPublicCertificate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.LdapSettingPublicCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).PublicCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal)LdapsSetting).PublicCertificate = value; }

        /// <summary>Internal Acessors for LdapsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.LdapsSetting { get => (this._ldapsSetting = this._ldapsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings()); set { {_ldapsSetting = value;} } }

        /// <summary>Internal Acessors for MigrationProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.MigrationProperty { get => (this._migrationProperty = this._migrationProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProperties()); set { {_migrationProperty = value;} } }

        /// <summary>Internal Acessors for MigrationPropertyMigrationProgress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgress Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.MigrationPropertyMigrationProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).MigrationProgress; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).MigrationProgress = value; }

        /// <summary>Internal Acessors for MigrationPropertyOldSubnetId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.MigrationPropertyOldSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).OldSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).OldSubnetId = value; }

        /// <summary>Internal Acessors for MigrationPropertyOldVnetSiteId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.MigrationPropertyOldVnetSiteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).OldVnetSiteId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).OldVnetSiteId = value; }

        /// <summary>Internal Acessors for NotificationSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettings Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.NotificationSetting { get => (this._notificationSetting = this._notificationSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.NotificationSettings()); set { {_notificationSetting = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ResourceForestSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettings Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.ResourceForestSetting { get => (this._resourceForestSetting = this._resourceForestSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ResourceForestSettings()); set { {_resourceForestSetting = value;} } }

        /// <summary>Internal Acessors for SyncOwner</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.SyncOwner { get => this._syncOwner; set { {_syncOwner = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.TenantId { get => this._tenantId; set { {_tenantId = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Completion Percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public double? MigrationProgressCompletionPercentage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).MigrationProgressCompletionPercentage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).MigrationProgressCompletionPercentage = value ?? default(double); }

        /// <summary>Progress Message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public string MigrationProgressMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).MigrationProgressMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).MigrationProgressMessage = value ?? null; }

        /// <summary>Backing field for <see cref="MigrationProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties _migrationProperty;

        /// <summary>Migration Properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties MigrationProperty { get => (this._migrationProperty = this._migrationProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProperties()); }

        /// <summary>Old Subnet Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public string MigrationPropertyOldSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).OldSubnetId; }

        /// <summary>Old Vnet Site Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public string MigrationPropertyOldVnetSiteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)MigrationProperty).OldVnetSiteId; }

        /// <summary>Backing field for <see cref="NotificationSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettings _notificationSetting;

        /// <summary>Notification Settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettings NotificationSetting { get => (this._notificationSetting = this._notificationSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.NotificationSettings()); set => this._notificationSetting = value; }

        /// <summary>The list of additional recipients</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public string[] NotificationSettingAdditionalRecipient { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettingsInternal)NotificationSetting).AdditionalRecipient; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettingsInternal)NotificationSetting).AdditionalRecipient = value ?? null /* arrayOf */; }

        /// <summary>Should domain controller admins be notified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyDcAdmins? NotificationSettingNotifyDcAdmin { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettingsInternal)NotificationSetting).NotifyDcAdmin; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettingsInternal)NotificationSetting).NotifyDcAdmin = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyDcAdmins)""); }

        /// <summary>Should global admins be notified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyGlobalAdmins? NotificationSettingNotifyGlobalAdmin { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettingsInternal)NotificationSetting).NotifyGlobalAdmin; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettingsInternal)NotificationSetting).NotifyGlobalAdmin = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyGlobalAdmins)""); }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// the current deployment or provisioning state, which only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ReplicaSet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet[] _replicaSet;

        /// <summary>List of ReplicaSets</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet[] ReplicaSet { get => this._replicaSet; set => this._replicaSet = value; }

        /// <summary>Backing field for <see cref="ResourceForestSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettings _resourceForestSetting;

        /// <summary>Resource Forest Settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettings ResourceForestSetting { get => (this._resourceForestSetting = this._resourceForestSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ResourceForestSettings()); set => this._resourceForestSetting = value; }

        /// <summary>Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public string ResourceForestSettingResourceForest { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettingsInternal)ResourceForestSetting).ResourceForest; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettingsInternal)ResourceForestSetting).ResourceForest = value ?? null; }

        /// <summary>List of settings for Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[] ResourceForestSettingsSettings { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettingsInternal)ResourceForestSetting).Setting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettingsInternal)ResourceForestSetting).Setting = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private string _sku;

        /// <summary>Sku Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string Sku { get => this._sku; set => this._sku = value; }

        /// <summary>Backing field for <see cref="SyncOwner" /> property.</summary>
        private string _syncOwner;

        /// <summary>SyncOwner ReplicaSet Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string SyncOwner { get => this._syncOwner; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>Azure Active Directory Tenant Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private int? _version;

        /// <summary>Data Model Version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public int? Version { get => this._version; }

        /// <summary>Creates an new <see cref="DomainServiceProperties" /> instance.</summary>
        public DomainServiceProperties()
        {

        }
    }
    /// Properties of the Domain Service.
    public partial interface IDomainServiceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable
    {
        /// <summary>Deployment Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Deployment Id",
        SerializedName = @"deploymentId",
        PossibleTypes = new [] { typeof(string) })]
        string DeploymentId { get;  }
        /// <summary>Domain Configuration Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Domain Configuration Type",
        SerializedName = @"domainConfigurationType",
        PossibleTypes = new [] { typeof(string) })]
        string DomainConfigurationType { get; set; }
        /// <summary>
        /// The name of the Azure domain that the user would like to deploy Domain Services to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure domain that the user would like to deploy Domain Services to.",
        SerializedName = @"domainName",
        PossibleTypes = new [] { typeof(string) })]
        string DomainName { get; set; }
        /// <summary>A flag to determine whether or not NtlmV1 is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not NtlmV1 is enabled or disabled.",
        SerializedName = @"ntlmV1",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1? DomainSecuritySettingNtlmV1 { get; set; }
        /// <summary>
        /// A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.",
        SerializedName = @"syncKerberosPasswords",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords? DomainSecuritySettingSyncKerberosPassword { get; set; }
        /// <summary>A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.",
        SerializedName = @"syncNtlmPasswords",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords? DomainSecuritySettingSyncNtlmPassword { get; set; }
        /// <summary>A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.",
        SerializedName = @"syncOnPremPasswords",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords? DomainSecuritySettingSyncOnPremPassword { get; set; }
        /// <summary>A flag to determine whether or not TlsV1 is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not TlsV1 is enabled or disabled.",
        SerializedName = @"tlsV1",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1? DomainSecuritySettingTlsV1 { get; set; }
        /// <summary>Enabled or Disabled flag to turn on Group-based filtered sync</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enabled or Disabled flag to turn on Group-based filtered sync",
        SerializedName = @"filteredSync",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.FilteredSync) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.FilteredSync? FilteredSync { get; set; }
        /// <summary>NotAfter DateTime of configure ldaps certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"NotAfter DateTime of configure ldaps certificate.",
        SerializedName = @"certificateNotAfter",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LdapSettingCertificateNotAfter { get;  }
        /// <summary>Thumbprint of configure ldaps certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Thumbprint of configure ldaps certificate.",
        SerializedName = @"certificateThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string LdapSettingCertificateThumbprint { get;  }
        /// <summary>
        /// A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.",
        SerializedName = @"externalAccess",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess? LdapSettingExternalAccess { get; set; }
        /// <summary>A flag to determine whether or not Secure LDAP is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not Secure LDAP is enabled or disabled.",
        SerializedName = @"ldaps",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps? LdapSettingLdap { get; set; }
        /// <summary>
        /// The certificate required to configure Secure LDAP. The parameter passed here should be a base64encoded representation
        /// of the certificate pfx file.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The certificate required to configure Secure LDAP. The parameter passed here should be a base64encoded representation of the certificate pfx file.",
        SerializedName = @"pfxCertificate",
        PossibleTypes = new [] { typeof(string) })]
        string LdapSettingPfxCertificate { get; set; }
        /// <summary>The password to decrypt the provided Secure LDAP certificate pfx file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password to decrypt the provided Secure LDAP certificate pfx file.",
        SerializedName = @"pfxCertificatePassword",
        PossibleTypes = new [] { typeof(string) })]
        string LdapSettingPfxCertificatePassword { get; set; }
        /// <summary>Public certificate used to configure secure ldap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Public certificate used to configure secure ldap.",
        SerializedName = @"publicCertificate",
        PossibleTypes = new [] { typeof(string) })]
        string LdapSettingPublicCertificate { get;  }
        /// <summary>Completion Percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Completion Percentage",
        SerializedName = @"completionPercentage",
        PossibleTypes = new [] { typeof(double) })]
        double? MigrationProgressCompletionPercentage { get; set; }
        /// <summary>Progress Message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Progress Message",
        SerializedName = @"progressMessage",
        PossibleTypes = new [] { typeof(string) })]
        string MigrationProgressMessage { get; set; }
        /// <summary>Old Subnet Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Old Subnet Id",
        SerializedName = @"oldSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string MigrationPropertyOldSubnetId { get;  }
        /// <summary>Old Vnet Site Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Old Vnet Site Id",
        SerializedName = @"oldVnetSiteId",
        PossibleTypes = new [] { typeof(string) })]
        string MigrationPropertyOldVnetSiteId { get;  }
        /// <summary>The list of additional recipients</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of additional recipients",
        SerializedName = @"additionalRecipients",
        PossibleTypes = new [] { typeof(string) })]
        string[] NotificationSettingAdditionalRecipient { get; set; }
        /// <summary>Should domain controller admins be notified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Should domain controller admins be notified",
        SerializedName = @"notifyDcAdmins",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyDcAdmins) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyDcAdmins? NotificationSettingNotifyDcAdmin { get; set; }
        /// <summary>Should global admins be notified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Should global admins be notified",
        SerializedName = @"notifyGlobalAdmins",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyGlobalAdmins) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyGlobalAdmins? NotificationSettingNotifyGlobalAdmin { get; set; }
        /// <summary>
        /// the current deployment or provisioning state, which only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"the current deployment or provisioning state, which only appears in the response.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>List of ReplicaSets</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of ReplicaSets",
        SerializedName = @"replicaSets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet[] ReplicaSet { get; set; }
        /// <summary>Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Forest",
        SerializedName = @"resourceForest",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceForestSettingResourceForest { get; set; }
        /// <summary>List of settings for Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of settings for Resource Forest",
        SerializedName = @"settings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[] ResourceForestSettingsSettings { get; set; }
        /// <summary>Sku Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sku Type",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(string) })]
        string Sku { get; set; }
        /// <summary>SyncOwner ReplicaSet Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SyncOwner ReplicaSet Id",
        SerializedName = @"syncOwner",
        PossibleTypes = new [] { typeof(string) })]
        string SyncOwner { get;  }
        /// <summary>Azure Active Directory Tenant Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Azure Active Directory Tenant Id",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }
        /// <summary>Data Model Version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Data Model Version",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? Version { get;  }

    }
    /// Properties of the Domain Service.
    internal partial interface IDomainServicePropertiesInternal

    {
        /// <summary>Deployment Id</summary>
        string DeploymentId { get; set; }
        /// <summary>Domain Configuration Type</summary>
        string DomainConfigurationType { get; set; }
        /// <summary>
        /// The name of the Azure domain that the user would like to deploy Domain Services to.
        /// </summary>
        string DomainName { get; set; }
        /// <summary>DomainSecurity Settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings DomainSecuritySetting { get; set; }
        /// <summary>A flag to determine whether or not NtlmV1 is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1? DomainSecuritySettingNtlmV1 { get; set; }
        /// <summary>
        /// A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords? DomainSecuritySettingSyncKerberosPassword { get; set; }
        /// <summary>A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords? DomainSecuritySettingSyncNtlmPassword { get; set; }
        /// <summary>A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords? DomainSecuritySettingSyncOnPremPassword { get; set; }
        /// <summary>A flag to determine whether or not TlsV1 is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1? DomainSecuritySettingTlsV1 { get; set; }
        /// <summary>Enabled or Disabled flag to turn on Group-based filtered sync</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.FilteredSync? FilteredSync { get; set; }
        /// <summary>NotAfter DateTime of configure ldaps certificate.</summary>
        global::System.DateTime? LdapSettingCertificateNotAfter { get; set; }
        /// <summary>Thumbprint of configure ldaps certificate.</summary>
        string LdapSettingCertificateThumbprint { get; set; }
        /// <summary>
        /// A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess? LdapSettingExternalAccess { get; set; }
        /// <summary>A flag to determine whether or not Secure LDAP is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps? LdapSettingLdap { get; set; }
        /// <summary>
        /// The certificate required to configure Secure LDAP. The parameter passed here should be a base64encoded representation
        /// of the certificate pfx file.
        /// </summary>
        string LdapSettingPfxCertificate { get; set; }
        /// <summary>The password to decrypt the provided Secure LDAP certificate pfx file.</summary>
        string LdapSettingPfxCertificatePassword { get; set; }
        /// <summary>Public certificate used to configure secure ldap.</summary>
        string LdapSettingPublicCertificate { get; set; }
        /// <summary>Secure LDAP Settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings LdapsSetting { get; set; }
        /// <summary>Completion Percentage</summary>
        double? MigrationProgressCompletionPercentage { get; set; }
        /// <summary>Progress Message</summary>
        string MigrationProgressMessage { get; set; }
        /// <summary>Migration Properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties MigrationProperty { get; set; }
        /// <summary>Migration Progress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgress MigrationPropertyMigrationProgress { get; set; }
        /// <summary>Old Subnet Id</summary>
        string MigrationPropertyOldSubnetId { get; set; }
        /// <summary>Old Vnet Site Id</summary>
        string MigrationPropertyOldVnetSiteId { get; set; }
        /// <summary>Notification Settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettings NotificationSetting { get; set; }
        /// <summary>The list of additional recipients</summary>
        string[] NotificationSettingAdditionalRecipient { get; set; }
        /// <summary>Should domain controller admins be notified</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyDcAdmins? NotificationSettingNotifyDcAdmin { get; set; }
        /// <summary>Should global admins be notified</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyGlobalAdmins? NotificationSettingNotifyGlobalAdmin { get; set; }
        /// <summary>
        /// the current deployment or provisioning state, which only appears in the response.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>List of ReplicaSets</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet[] ReplicaSet { get; set; }
        /// <summary>Resource Forest Settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettings ResourceForestSetting { get; set; }
        /// <summary>Resource Forest</summary>
        string ResourceForestSettingResourceForest { get; set; }
        /// <summary>List of settings for Resource Forest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[] ResourceForestSettingsSettings { get; set; }
        /// <summary>Sku Type</summary>
        string Sku { get; set; }
        /// <summary>SyncOwner ReplicaSet Id</summary>
        string SyncOwner { get; set; }
        /// <summary>Azure Active Directory Tenant Id</summary>
        string TenantId { get; set; }
        /// <summary>Data Model Version</summary>
        int? Version { get; set; }

    }
}