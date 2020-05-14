namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Details of a hostname derived from a domain.</summary>
    public partial class HostName :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameInternal
    {

        /// <summary>Backing field for <see cref="AzureResourceName" /> property.</summary>
        private string _azureResourceName;

        /// <summary>
        /// Name of the Azure resource the hostname is assigned to. If it is assigned to a Traffic Manager then it will be the Traffic
        /// Manager name otherwise it will be the app name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AzureResourceName { get => this._azureResourceName; set => this._azureResourceName = value; }

        /// <summary>Backing field for <see cref="AzureResourceType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? _azureResourceType;

        /// <summary>Type of the Azure resource the hostname is assigned to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? AzureResourceType { get => this._azureResourceType; set => this._azureResourceType = value; }

        /// <summary>Backing field for <see cref="CustomHostNameDnsRecordType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? _customHostNameDnsRecordType;

        /// <summary>Type of the DNS record.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get => this._customHostNameDnsRecordType; set => this._customHostNameDnsRecordType = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="SiteName" /> property.</summary>
        private string[] _siteName;

        /// <summary>
        /// List of apps the hostname is assigned to. This list will have more than one app only if the hostname is pointing to a
        /// Traffic Manager.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] SiteName { get => this._siteName; set => this._siteName = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? _type;

        /// <summary>Type of the hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="HostName" /> instance.</summary>
        public HostName()
        {

        }
    }
    /// Details of a hostname derived from a domain.
    public partial interface IHostName :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Name of the Azure resource the hostname is assigned to. If it is assigned to a Traffic Manager then it will be the Traffic
        /// Manager name otherwise it will be the app name.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the Azure resource the hostname is assigned to. If it is assigned to a Traffic Manager then it will be the Traffic Manager name otherwise it will be the app name.",
        SerializedName = @"azureResourceName",
        PossibleTypes = new [] { typeof(string) })]
        string AzureResourceName { get; set; }
        /// <summary>Type of the Azure resource the hostname is assigned to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the Azure resource the hostname is assigned to.",
        SerializedName = @"azureResourceType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? AzureResourceType { get; set; }
        /// <summary>Type of the DNS record.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the DNS record.",
        SerializedName = @"customHostNameDnsRecordType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get; set; }
        /// <summary>Name of the hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the hostname.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// List of apps the hostname is assigned to. This list will have more than one app only if the hostname is pointing to a
        /// Traffic Manager.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of apps the hostname is assigned to. This list will have more than one app only if the hostname is pointing to a Traffic Manager.",
        SerializedName = @"siteNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] SiteName { get; set; }
        /// <summary>Type of the hostname.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the hostname.",
        SerializedName = @"hostNameType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? Type { get; set; }

    }
    /// Details of a hostname derived from a domain.
    internal partial interface IHostNameInternal

    {
        /// <summary>
        /// Name of the Azure resource the hostname is assigned to. If it is assigned to a Traffic Manager then it will be the Traffic
        /// Manager name otherwise it will be the app name.
        /// </summary>
        string AzureResourceName { get; set; }
        /// <summary>Type of the Azure resource the hostname is assigned to.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType? AzureResourceType { get; set; }
        /// <summary>Type of the DNS record.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType? CustomHostNameDnsRecordType { get; set; }
        /// <summary>Name of the hostname.</summary>
        string Name { get; set; }
        /// <summary>
        /// List of apps the hostname is assigned to. This list will have more than one app only if the hostname is pointing to a
        /// Traffic Manager.
        /// </summary>
        string[] SiteName { get; set; }
        /// <summary>Type of the hostname.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType? Type { get; set; }

    }
}