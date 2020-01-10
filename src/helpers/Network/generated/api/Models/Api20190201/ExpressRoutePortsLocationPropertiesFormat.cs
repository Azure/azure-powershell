namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties specific to ExpressRoutePorts peering location resources.</summary>
    public partial class ExpressRoutePortsLocationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="Address" /> property.</summary>
        private string _address;

        /// <summary>Address of peering location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Address { get => this._address; }

        /// <summary>Backing field for <see cref="AvailableBandwidth" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationBandwidths[] _availableBandwidth;

        /// <summary>The inventory of available ExpressRoutePort bandwidths.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationBandwidths[] AvailableBandwidth { get => this._availableBandwidth; set => this._availableBandwidth = value; }

        /// <summary>Backing field for <see cref="Contact" /> property.</summary>
        private string _contact;

        /// <summary>Contact details of peering locations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Contact { get => this._contact; }

        /// <summary>Internal Acessors for Address</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationPropertiesFormatInternal.Address { get => this._address; set { {_address = value;} } }

        /// <summary>Internal Acessors for Contact</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationPropertiesFormatInternal.Contact { get => this._contact; set { {_contact = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the ExpressRoutePortLocation resource. Possible values are: 'Succeeded', 'Updating', 'Deleting',
        /// and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>
        /// Creates an new <see cref="ExpressRoutePortsLocationPropertiesFormat" /> instance.
        /// </summary>
        public ExpressRoutePortsLocationPropertiesFormat()
        {

        }
    }
    /// Properties specific to ExpressRoutePorts peering location resources.
    public partial interface IExpressRoutePortsLocationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Address of peering location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Address of peering location.",
        SerializedName = @"address",
        PossibleTypes = new [] { typeof(string) })]
        string Address { get;  }
        /// <summary>The inventory of available ExpressRoutePort bandwidths.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The inventory of available ExpressRoutePort bandwidths.",
        SerializedName = @"availableBandwidths",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationBandwidths) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationBandwidths[] AvailableBandwidth { get; set; }
        /// <summary>Contact details of peering locations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Contact details of peering locations.",
        SerializedName = @"contact",
        PossibleTypes = new [] { typeof(string) })]
        string Contact { get;  }
        /// <summary>
        /// The provisioning state of the ExpressRoutePortLocation resource. Possible values are: 'Succeeded', 'Updating', 'Deleting',
        /// and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the ExpressRoutePortLocation resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Properties specific to ExpressRoutePorts peering location resources.
    internal partial interface IExpressRoutePortsLocationPropertiesFormatInternal

    {
        /// <summary>Address of peering location.</summary>
        string Address { get; set; }
        /// <summary>The inventory of available ExpressRoutePort bandwidths.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortsLocationBandwidths[] AvailableBandwidth { get; set; }
        /// <summary>Contact details of peering locations.</summary>
        string Contact { get; set; }
        /// <summary>
        /// The provisioning state of the ExpressRoutePortLocation resource. Possible values are: 'Succeeded', 'Updating', 'Deleting',
        /// and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}