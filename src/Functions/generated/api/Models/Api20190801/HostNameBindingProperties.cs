namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>HostNameBinding resource specific properties</summary>
    public partial class HostNameBindingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AzureResourceName" /> property.</summary>
        private string _azureResourceName;

        /// <summary>Azure resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AzureResourceName { get => this._azureResourceName; set => this._azureResourceName = value; }

        /// <summary>Backing field for <see cref="AzureResourceType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? _azureResourceType;

        /// <summary>Azure resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? AzureResourceType { get => this._azureResourceType; set => this._azureResourceType = value; }

        /// <summary>Backing field for <see cref="CustomHostNameDnsRecordType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? _customHostNameDnsRecordType;

        /// <summary>Custom DNS record type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get => this._customHostNameDnsRecordType; set => this._customHostNameDnsRecordType = value; }

        /// <summary>Backing field for <see cref="DomainId" /> property.</summary>
        private string _domainId;

        /// <summary>Fully qualified ARM domain resource URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DomainId { get => this._domainId; set => this._domainId = value; }

        /// <summary>Backing field for <see cref="HostNameType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? _hostNameType;

        /// <summary>Hostname type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? HostNameType { get => this._hostNameType; set => this._hostNameType = value; }

        /// <summary>Internal Acessors for VirtualIP</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal.VirtualIP { get => this._virtualIP; set { {_virtualIP = value;} } }

        /// <summary>Backing field for <see cref="SiteName" /> property.</summary>
        private string _siteName;

        /// <summary>App Service app name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SiteName { get => this._siteName; set => this._siteName = value; }

        /// <summary>Backing field for <see cref="SslState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? _sslState;

        /// <summary>SSL type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? SslState { get => this._sslState; set => this._sslState = value; }

        /// <summary>Backing field for <see cref="Thumbprint" /> property.</summary>
        private string _thumbprint;

        /// <summary>SSL certificate thumbprint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Thumbprint { get => this._thumbprint; set => this._thumbprint = value; }

        /// <summary>Backing field for <see cref="VirtualIP" /> property.</summary>
        private string _virtualIP;

        /// <summary>Virtual IP address assigned to the hostname if IP based SSL is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VirtualIP { get => this._virtualIP; }

        /// <summary>Creates an new <see cref="HostNameBindingProperties" /> instance.</summary>
        public HostNameBindingProperties()
        {

        }
    }
    /// HostNameBinding resource specific properties
    public partial interface IHostNameBindingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Azure resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure resource name.",
        SerializedName = @"azureResourceName",
        PossibleTypes = new [] { typeof(string) })]
        string AzureResourceName { get; set; }
        /// <summary>Azure resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure resource type.",
        SerializedName = @"azureResourceType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? AzureResourceType { get; set; }
        /// <summary>Custom DNS record type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Custom DNS record type.",
        SerializedName = @"customHostNameDnsRecordType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get; set; }
        /// <summary>Fully qualified ARM domain resource URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified ARM domain resource URI.",
        SerializedName = @"domainId",
        PossibleTypes = new [] { typeof(string) })]
        string DomainId { get; set; }
        /// <summary>Hostname type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Hostname type.",
        SerializedName = @"hostNameType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? HostNameType { get; set; }
        /// <summary>App Service app name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"App Service app name.",
        SerializedName = @"siteName",
        PossibleTypes = new [] { typeof(string) })]
        string SiteName { get; set; }
        /// <summary>SSL type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SSL type",
        SerializedName = @"sslState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? SslState { get; set; }
        /// <summary>SSL certificate thumbprint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SSL certificate thumbprint",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string Thumbprint { get; set; }
        /// <summary>Virtual IP address assigned to the hostname if IP based SSL is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Virtual IP address assigned to the hostname if IP based SSL is enabled.",
        SerializedName = @"virtualIP",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualIP { get;  }

    }
    /// HostNameBinding resource specific properties
    internal partial interface IHostNameBindingPropertiesInternal

    {
        /// <summary>Azure resource name.</summary>
        string AzureResourceName { get; set; }
        /// <summary>Azure resource type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? AzureResourceType { get; set; }
        /// <summary>Custom DNS record type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get; set; }
        /// <summary>Fully qualified ARM domain resource URI.</summary>
        string DomainId { get; set; }
        /// <summary>Hostname type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? HostNameType { get; set; }
        /// <summary>App Service app name.</summary>
        string SiteName { get; set; }
        /// <summary>SSL type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState? SslState { get; set; }
        /// <summary>SSL certificate thumbprint</summary>
        string Thumbprint { get; set; }
        /// <summary>Virtual IP address assigned to the hostname if IP based SSL is enabled.</summary>
        string VirtualIP { get; set; }

    }
}