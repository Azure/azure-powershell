namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines load balancer frontend IP configuration properties.</summary>
    public partial class LbFrontendIpconfigurationResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILbFrontendIpconfigurationResourceSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILbFrontendIpconfigurationResourceSettingsInternal
    {

        /// <summary>Internal Acessors for Subnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetReference Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILbFrontendIpconfigurationResourceSettingsInternal.Subnet { get => (this._subnet = this._subnet ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.SubnetReference()); set { {_subnet = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Gets or sets the frontend IP configuration name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="PrivateIPAddress" /> property.</summary>
        private string _privateIPAddress;

        /// <summary>
        /// Gets or sets the IP address of the Load Balancer.This is only specified if a specific
        /// private IP address shall be allocated from the subnet specified in subnetRef.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string PrivateIPAddress { get => this._privateIPAddress; set => this._privateIPAddress = value; }

        /// <summary>Backing field for <see cref="PrivateIPAllocationMethod" /> property.</summary>
        private string _privateIPAllocationMethod;

        /// <summary>Gets or sets PrivateIP allocation method (Static/Dynamic).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string PrivateIPAllocationMethod { get => this._privateIPAllocationMethod; set => this._privateIPAllocationMethod = value; }

        /// <summary>Backing field for <see cref="Subnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetReference _subnet;

        /// <summary>Defines reference to subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetReference Subnet { get => (this._subnet = this._subnet ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.SubnetReference()); set => this._subnet = value; }

        /// <summary>Gets the name of the proxy resource on the target side.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string SubnetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IProxyResourceReferenceInternal)Subnet).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IProxyResourceReferenceInternal)Subnet).Name = value; }

        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string SubnetSourceArmResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAzureResourceReferenceInternal)Subnet).SourceArmResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAzureResourceReferenceInternal)Subnet).SourceArmResourceId = value; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string _zone;

        /// <summary>Gets or sets the csv list of zones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Zone { get => this._zone; set => this._zone = value; }

        /// <summary>
        /// Creates an new <see cref="LbFrontendIpconfigurationResourceSettings" /> instance.
        /// </summary>
        public LbFrontendIpconfigurationResourceSettings()
        {

        }
    }
    /// Defines load balancer frontend IP configuration properties.
    public partial interface ILbFrontendIpconfigurationResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the frontend IP configuration name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the frontend IP configuration name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the IP address of the Load Balancer.This is only specified if a specific
        /// private IP address shall be allocated from the subnet specified in subnetRef.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the IP address of the Load Balancer.This is only specified if a specific
        private IP address shall be allocated from the subnet specified in subnetRef.",
        SerializedName = @"privateIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get; set; }
        /// <summary>Gets or sets PrivateIP allocation method (Static/Dynamic).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets PrivateIP allocation method (Static/Dynamic).",
        SerializedName = @"privateIpAllocationMethod",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAllocationMethod { get; set; }
        /// <summary>Gets the name of the proxy resource on the target side.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the name of the proxy resource on the target side.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetName { get; set; }
        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets the ARM resource ID of the tracked resource being referenced.",
        SerializedName = @"sourceArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetSourceArmResourceId { get; set; }
        /// <summary>Gets or sets the csv list of zones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the csv list of zones.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string Zone { get; set; }

    }
    /// Defines load balancer frontend IP configuration properties.
    internal partial interface ILbFrontendIpconfigurationResourceSettingsInternal

    {
        /// <summary>Gets or sets the frontend IP configuration name.</summary>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the IP address of the Load Balancer.This is only specified if a specific
        /// private IP address shall be allocated from the subnet specified in subnetRef.
        /// </summary>
        string PrivateIPAddress { get; set; }
        /// <summary>Gets or sets PrivateIP allocation method (Static/Dynamic).</summary>
        string PrivateIPAllocationMethod { get; set; }
        /// <summary>Defines reference to subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetReference Subnet { get; set; }
        /// <summary>Gets the name of the proxy resource on the target side.</summary>
        string SubnetName { get; set; }
        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        string SubnetSourceArmResourceId { get; set; }
        /// <summary>Gets or sets the csv list of zones.</summary>
        string Zone { get; set; }

    }
}