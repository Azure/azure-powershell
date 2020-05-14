namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Settings properties for Active Directory (AD).</summary>
    public partial class ActiveDirectoryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IActiveDirectoryPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AzureStorageSid" /> property.</summary>
        private string _azureStorageSid;

        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AzureStorageSid { get => this._azureStorageSid; set => this._azureStorageSid = value; }

        /// <summary>Backing field for <see cref="DomainGuid" /> property.</summary>
        private string _domainGuid;

        /// <summary>Specifies the domain GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DomainGuid { get => this._domainGuid; set => this._domainGuid = value; }

        /// <summary>Backing field for <see cref="DomainName" /> property.</summary>
        private string _domainName;

        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DomainName { get => this._domainName; set => this._domainName = value; }

        /// <summary>Backing field for <see cref="DomainSid" /> property.</summary>
        private string _domainSid;

        /// <summary>Specifies the security identifier (SID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DomainSid { get => this._domainSid; set => this._domainSid = value; }

        /// <summary>Backing field for <see cref="ForestName" /> property.</summary>
        private string _forestName;

        /// <summary>Specifies the Active Directory forest to get.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ForestName { get => this._forestName; set => this._forestName = value; }

        /// <summary>Backing field for <see cref="NetBiosDomainName" /> property.</summary>
        private string _netBiosDomainName;

        /// <summary>Specifies the NetBIOS domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NetBiosDomainName { get => this._netBiosDomainName; set => this._netBiosDomainName = value; }

        /// <summary>Creates an new <see cref="ActiveDirectoryProperties" /> instance.</summary>
        public ActiveDirectoryProperties()
        {

        }
    }
    /// Settings properties for Active Directory (AD).
    public partial interface IActiveDirectoryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the security identifier (SID) for Azure Storage.",
        SerializedName = @"azureStorageSid",
        PossibleTypes = new [] { typeof(string) })]
        string AzureStorageSid { get; set; }
        /// <summary>Specifies the domain GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the domain GUID.",
        SerializedName = @"domainGuid",
        PossibleTypes = new [] { typeof(string) })]
        string DomainGuid { get; set; }
        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the primary domain that the AD DNS server is authoritative for.",
        SerializedName = @"domainName",
        PossibleTypes = new [] { typeof(string) })]
        string DomainName { get; set; }
        /// <summary>Specifies the security identifier (SID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the security identifier (SID).",
        SerializedName = @"domainSid",
        PossibleTypes = new [] { typeof(string) })]
        string DomainSid { get; set; }
        /// <summary>Specifies the Active Directory forest to get.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the Active Directory forest to get.",
        SerializedName = @"forestName",
        PossibleTypes = new [] { typeof(string) })]
        string ForestName { get; set; }
        /// <summary>Specifies the NetBIOS domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the NetBIOS domain name.",
        SerializedName = @"netBiosDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string NetBiosDomainName { get; set; }

    }
    /// Settings properties for Active Directory (AD).
    internal partial interface IActiveDirectoryPropertiesInternal

    {
        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        string AzureStorageSid { get; set; }
        /// <summary>Specifies the domain GUID.</summary>
        string DomainGuid { get; set; }
        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        string DomainName { get; set; }
        /// <summary>Specifies the security identifier (SID).</summary>
        string DomainSid { get; set; }
        /// <summary>Specifies the Active Directory forest to get.</summary>
        string ForestName { get; set; }
        /// <summary>Specifies the NetBIOS domain name.</summary>
        string NetBiosDomainName { get; set; }

    }
}