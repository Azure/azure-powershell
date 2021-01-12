namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Domain service.</summary>
    public partial class DomainService :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainService,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.Resource();

        /// <summary>Deployment Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string DeploymentId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DeploymentId; }

        /// <summary>Domain Configuration Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string DomainConfigurationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainConfigurationType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainConfigurationType = value ?? null; }

        /// <summary>
        /// The name of the Azure domain that the user would like to deploy Domain Services to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.FormatTable(Index = 1, Label = @"Domain Name")]
        public string DomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainName = value ?? null; }

        /// <summary>A flag to determine whether or not NtlmV1 is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1? DomainSecuritySettingNtlmV1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySettingNtlmV1; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySettingNtlmV1 = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1)""); }

        /// <summary>
        /// A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords? DomainSecuritySettingSyncKerberosPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySettingSyncKerberosPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySettingSyncKerberosPassword = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords)""); }

        /// <summary>A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords? DomainSecuritySettingSyncNtlmPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySettingSyncNtlmPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySettingSyncNtlmPassword = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords)""); }

        /// <summary>A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords? DomainSecuritySettingSyncOnPremPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySettingSyncOnPremPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySettingSyncOnPremPassword = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords)""); }

        /// <summary>A flag to determine whether or not TlsV1 is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1? DomainSecuritySettingTlsV1 { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySettingTlsV1; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySettingTlsV1 = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1)""); }

        /// <summary>Resource etag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string Etag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Etag = value; }

        /// <summary>Enabled or Disabled flag to turn on Group-based filtered sync</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.FilteredSync? FilteredSync { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).FilteredSync; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).FilteredSync = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.FilteredSync)""); }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Id; }

        /// <summary>NotAfter DateTime of configure ldaps certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public global::System.DateTime? LdapSettingCertificateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingCertificateNotAfter; }

        /// <summary>Thumbprint of configure ldaps certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string LdapSettingCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingCertificateThumbprint; }

        /// <summary>
        /// A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess? LdapSettingExternalAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingExternalAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingExternalAccess = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess)""); }

        /// <summary>A flag to determine whether or not Secure LDAP is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps? LdapSettingLdap { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingLdap; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingLdap = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps)""); }

        /// <summary>
        /// The certificate required to configure Secure LDAP. The parameter passed here should be a base64encoded representation
        /// of the certificate pfx file.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string LdapSettingPfxCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingPfxCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingPfxCertificate = value ?? null; }

        /// <summary>The password to decrypt the provided Secure LDAP certificate pfx file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string LdapSettingPfxCertificatePassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingPfxCertificatePassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingPfxCertificatePassword = value ?? null; }

        /// <summary>Public certificate used to configure secure ldap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string LdapSettingPublicCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingPublicCertificate; }

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.FormatTable(Index = 2)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for DeploymentId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.DeploymentId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DeploymentId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DeploymentId = value; }

        /// <summary>Internal Acessors for DomainSecuritySetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.DomainSecuritySetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).DomainSecuritySetting = value; }

        /// <summary>Internal Acessors for LdapSettingCertificateNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.LdapSettingCertificateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingCertificateNotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingCertificateNotAfter = value; }

        /// <summary>Internal Acessors for LdapSettingCertificateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.LdapSettingCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingCertificateThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingCertificateThumbprint = value; }

        /// <summary>Internal Acessors for LdapSettingPublicCertificate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.LdapSettingPublicCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingPublicCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapSettingPublicCertificate = value; }

        /// <summary>Internal Acessors for LdapsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.LdapsSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapsSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).LdapsSetting = value; }

        /// <summary>Internal Acessors for MigrationProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.MigrationProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationProperty = value; }

        /// <summary>Internal Acessors for MigrationPropertyMigrationProgress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgress Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.MigrationPropertyMigrationProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationPropertyMigrationProgress; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationPropertyMigrationProgress = value; }

        /// <summary>Internal Acessors for MigrationPropertyOldSubnetId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.MigrationPropertyOldSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationPropertyOldSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationPropertyOldSubnetId = value; }

        /// <summary>Internal Acessors for MigrationPropertyOldVnetSiteId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.MigrationPropertyOldVnetSiteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationPropertyOldVnetSiteId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationPropertyOldVnetSiteId = value; }

        /// <summary>Internal Acessors for NotificationSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.INotificationSettings Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.NotificationSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).NotificationSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).NotificationSetting = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceProperties Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainServiceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for ResourceForestSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettings Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.ResourceForestSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ResourceForestSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ResourceForestSetting = value; }

        /// <summary>Internal Acessors for SyncOwner</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.SyncOwner { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).SyncOwner; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).SyncOwner = value; }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).TenantId = value; }

        /// <summary>Internal Acessors for Version</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceInternal.Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).Version = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Type = value; }

        /// <summary>Completion Percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public double? MigrationProgressCompletionPercentage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationProgressCompletionPercentage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationProgressCompletionPercentage = value ?? default(double); }

        /// <summary>Progress Message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string MigrationProgressMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationProgressMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationProgressMessage = value ?? null; }

        /// <summary>Old Subnet Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string MigrationPropertyOldSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationPropertyOldSubnetId; }

        /// <summary>Old Vnet Site Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string MigrationPropertyOldVnetSiteId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).MigrationPropertyOldVnetSiteId; }

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Name; }

        /// <summary>The list of additional recipients</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string[] NotificationSettingAdditionalRecipient { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).NotificationSettingAdditionalRecipient; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).NotificationSettingAdditionalRecipient = value ?? null /* arrayOf */; }

        /// <summary>Should domain controller admins be notified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyDcAdmins? NotificationSettingNotifyDcAdmin { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).NotificationSettingNotifyDcAdmin; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).NotificationSettingNotifyDcAdmin = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyDcAdmins)""); }

        /// <summary>Should global admins be notified</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyGlobalAdmins? NotificationSettingNotifyGlobalAdmin { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).NotificationSettingNotifyGlobalAdmin; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).NotificationSettingNotifyGlobalAdmin = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyGlobalAdmins)""); }

        /// <summary>List of settings for Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[] PropertiesResourceForestSettingsSettings { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ResourceForestSettingsSettings; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ResourceForestSettingsSettings = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceProperties _property;

        /// <summary>Domain service properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainServiceProperties()); set => this._property = value; }

        /// <summary>
        /// the current deployment or provisioning state, which only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ProvisioningState; }

        /// <summary>List of ReplicaSets</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet[] ReplicaSet { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ReplicaSet; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ReplicaSet = value ?? null /* arrayOf */; }

        /// <summary>Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string ResourceForestSettingResourceForest { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ResourceForestSettingResourceForest; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).ResourceForestSettingResourceForest = value ?? null; }

        /// <summary>Sku Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.FormatTable(Index = 3)]
        public string Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).Sku = value ?? null; }

        /// <summary>SyncOwner ReplicaSet Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string SyncOwner { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).SyncOwner; }

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Tag = value; }

        /// <summary>Azure Active Directory Tenant Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).TenantId; }

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal)__resource).Type; }

        /// <summary>Data Model Version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.DoNotFormat]
        public int? Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServicePropertiesInternal)Property).Version; }

        /// <summary>Creates an new <see cref="DomainService" /> instance.</summary>
        public DomainService()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Domain service.
    public partial interface IDomainService :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResource
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
        /// <summary>List of settings for Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of settings for Resource Forest",
        SerializedName = @"settings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[] PropertiesResourceForestSettingsSettings { get; set; }
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
    /// Domain service.
    internal partial interface IDomainServiceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceInternal
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
        /// <summary>List of settings for Resource Forest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[] PropertiesResourceForestSettingsSettings { get; set; }
        /// <summary>Domain service properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainServiceProperties Property { get; set; }
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