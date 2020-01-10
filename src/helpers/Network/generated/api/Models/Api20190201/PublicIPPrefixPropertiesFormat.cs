namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Public IP prefix properties.</summary>
    public partial class PublicIPPrefixPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="IPPrefix" /> property.</summary>
        private string _iPPrefix;

        /// <summary>The allocated Prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string IPPrefix { get => this._iPPrefix; set => this._iPPrefix = value; }

        /// <summary>Backing field for <see cref="IPTag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[] _iPTag;

        /// <summary>The list of tags associated with the public IP prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[] IPTag { get => this._iPTag; set => this._iPTag = value; }

        /// <summary>Backing field for <see cref="LoadBalancerFrontendIPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _loadBalancerFrontendIPConfiguration;

        /// <summary>
        /// The reference to load balancer frontend IP configuration associated with the public IP prefix.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource LoadBalancerFrontendIPConfiguration { get => (this._loadBalancerFrontendIPConfiguration = this._loadBalancerFrontendIPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string LoadBalancerFrontendIPConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)LoadBalancerFrontendIPConfiguration).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)LoadBalancerFrontendIPConfiguration).Id = value; }

        /// <summary>Internal Acessors for LoadBalancerFrontendIPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixPropertiesFormatInternal.LoadBalancerFrontendIPConfiguration { get => (this._loadBalancerFrontendIPConfiguration = this._loadBalancerFrontendIPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_loadBalancerFrontendIPConfiguration = value;} } }

        /// <summary>Backing field for <see cref="PrefixLength" /> property.</summary>
        private int? _prefixLength;

        /// <summary>The Length of the Public IP Prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? PrefixLength { get => this._prefixLength; set => this._prefixLength = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the Public IP prefix resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="PublicIPAddress" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress[] _publicIPAddress;

        /// <summary>The list of all referenced PublicIPAddresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress[] PublicIPAddress { get => this._publicIPAddress; set => this._publicIPAddress = value; }

        /// <summary>Backing field for <see cref="PublicIPAddressVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? _publicIPAddressVersion;

        /// <summary>The public IP address version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get => this._publicIPAddressVersion; set => this._publicIPAddressVersion = value; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>The resource GUID property of the public IP prefix resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; set => this._resourceGuid = value; }

        /// <summary>Creates an new <see cref="PublicIPPrefixPropertiesFormat" /> instance.</summary>
        public PublicIPPrefixPropertiesFormat()
        {

        }
    }
    /// Public IP prefix properties.
    public partial interface IPublicIPPrefixPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The allocated Prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The allocated Prefix.",
        SerializedName = @"ipPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string IPPrefix { get; set; }
        /// <summary>The list of tags associated with the public IP prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of tags associated with the public IP prefix.",
        SerializedName = @"ipTags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[] IPTag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string LoadBalancerFrontendIPConfigurationId { get; set; }
        /// <summary>The Length of the Public IP Prefix.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Length of the Public IP Prefix.",
        SerializedName = @"prefixLength",
        PossibleTypes = new [] { typeof(int) })]
        int? PrefixLength { get; set; }
        /// <summary>
        /// The provisioning state of the Public IP prefix resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the Public IP prefix resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>The list of all referenced PublicIPAddresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of all referenced PublicIPAddresses.",
        SerializedName = @"publicIPAddresses",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress[] PublicIPAddress { get; set; }
        /// <summary>The public IP address version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The public IP address version.",
        SerializedName = @"publicIPAddressVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get; set; }
        /// <summary>The resource GUID property of the public IP prefix resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the public IP prefix resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }

    }
    /// Public IP prefix properties.
    internal partial interface IPublicIPPrefixPropertiesFormatInternal

    {
        /// <summary>The allocated Prefix.</summary>
        string IPPrefix { get; set; }
        /// <summary>The list of tags associated with the public IP prefix.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIPTag[] IPTag { get; set; }
        /// <summary>
        /// The reference to load balancer frontend IP configuration associated with the public IP prefix.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource LoadBalancerFrontendIPConfiguration { get; set; }
        /// <summary>Resource ID.</summary>
        string LoadBalancerFrontendIPConfigurationId { get; set; }
        /// <summary>The Length of the Public IP Prefix.</summary>
        int? PrefixLength { get; set; }
        /// <summary>
        /// The provisioning state of the Public IP prefix resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The list of all referenced PublicIPAddresses.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IReferencedPublicIPAddress[] PublicIPAddress { get; set; }
        /// <summary>The public IP address version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion? PublicIPAddressVersion { get; set; }
        /// <summary>The resource GUID property of the public IP prefix resource.</summary>
        string ResourceGuid { get; set; }

    }
}