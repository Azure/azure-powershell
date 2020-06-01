namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Settings for Azure Files identity based authentication.</summary>
    public partial class AzureFilesIdentityBasedAuthentication :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthentication,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal
    {

        /// <summary>Backing field for <see cref="ActiveDirectoryProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties _activeDirectoryProperty;

        /// <summary>Required if choose AD.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties ActiveDirectoryProperty { get => (this._activeDirectoryProperty = this._activeDirectoryProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ActiveDirectoryProperties()); set => this._activeDirectoryProperty = value; }

        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyAzureStorageSid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).AzureStorageSid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).AzureStorageSid = value; }

        /// <summary>Specifies the domain GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).DomainGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).DomainGuid = value; }

        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).DomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).DomainName = value; }

        /// <summary>Specifies the security identifier (SID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyDomainSid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).DomainSid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).DomainSid = value; }

        /// <summary>Specifies the Active Directory forest to get.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyForestName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).ForestName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).ForestName = value; }

        /// <summary>Specifies the NetBIOS domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActiveDirectoryPropertyNetBiosDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).NetBiosDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal)ActiveDirectoryProperty).NetBiosDomainName = value; }

        /// <summary>Backing field for <see cref="DirectoryServiceOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions _directoryServiceOption;

        /// <summary>Indicates the directory service used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions DirectoryServiceOption { get => this._directoryServiceOption; set => this._directoryServiceOption = value; }

        /// <summary>Internal Acessors for ActiveDirectoryProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IAzureFilesIdentityBasedAuthenticationInternal.ActiveDirectoryProperty { get => (this._activeDirectoryProperty = this._activeDirectoryProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ActiveDirectoryProperties()); set { {_activeDirectoryProperty = value;} } }

        /// <summary>Creates an new <see cref="AzureFilesIdentityBasedAuthentication" /> instance.</summary>
        public AzureFilesIdentityBasedAuthentication()
        {

        }
    }
    /// Settings for Azure Files identity based authentication.
    public partial interface IAzureFilesIdentityBasedAuthentication :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the security identifier (SID) for Azure Storage.",
        SerializedName = @"azureStorageSid",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyAzureStorageSid { get; set; }
        /// <summary>Specifies the domain GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the domain GUID.",
        SerializedName = @"domainGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyDomainGuid { get; set; }
        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the primary domain that the AD DNS server is authoritative for.",
        SerializedName = @"domainName",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyDomainName { get; set; }
        /// <summary>Specifies the security identifier (SID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the security identifier (SID).",
        SerializedName = @"domainSid",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyDomainSid { get; set; }
        /// <summary>Specifies the Active Directory forest to get.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the Active Directory forest to get.",
        SerializedName = @"forestName",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyForestName { get; set; }
        /// <summary>Specifies the NetBIOS domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the NetBIOS domain name.",
        SerializedName = @"netBiosDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string ActiveDirectoryPropertyNetBiosDomainName { get; set; }
        /// <summary>Indicates the directory service used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Indicates the directory service used.",
        SerializedName = @"directoryServiceOptions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions DirectoryServiceOption { get; set; }

    }
    /// Settings for Azure Files identity based authentication.
    internal partial interface IAzureFilesIdentityBasedAuthenticationInternal

    {
        /// <summary>Required if choose AD.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties ActiveDirectoryProperty { get; set; }
        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        string ActiveDirectoryPropertyAzureStorageSid { get; set; }
        /// <summary>Specifies the domain GUID.</summary>
        string ActiveDirectoryPropertyDomainGuid { get; set; }
        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        string ActiveDirectoryPropertyDomainName { get; set; }
        /// <summary>Specifies the security identifier (SID).</summary>
        string ActiveDirectoryPropertyDomainSid { get; set; }
        /// <summary>Specifies the Active Directory forest to get.</summary>
        string ActiveDirectoryPropertyForestName { get; set; }
        /// <summary>Specifies the NetBIOS domain name.</summary>
        string ActiveDirectoryPropertyNetBiosDomainName { get; set; }
        /// <summary>Indicates the directory service used.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DirectoryServiceOptions DirectoryServiceOption { get; set; }

    }
}