namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>PrivateAccess resource specific properties</summary>
    public partial class PrivateAccessProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>Whether private access is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="VirtualNetwork" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessVirtualNetwork[] _virtualNetwork;

        /// <summary>The Virtual Networks (and subnets) allowed to access the site privately.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessVirtualNetwork[] VirtualNetwork { get => this._virtualNetwork; set => this._virtualNetwork = value; }

        /// <summary>Creates an new <see cref="PrivateAccessProperties" /> instance.</summary>
        public PrivateAccessProperties()
        {

        }
    }
    /// PrivateAccess resource specific properties
    public partial interface IPrivateAccessProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Whether private access is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether private access is enabled or not.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>The Virtual Networks (and subnets) allowed to access the site privately.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Virtual Networks (and subnets) allowed to access the site privately.",
        SerializedName = @"virtualNetworks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessVirtualNetwork) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessVirtualNetwork[] VirtualNetwork { get; set; }

    }
    /// PrivateAccess resource specific properties
    internal partial interface IPrivateAccessPropertiesInternal

    {
        /// <summary>Whether private access is enabled or not.</summary>
        bool? Enabled { get; set; }
        /// <summary>The Virtual Networks (and subnets) allowed to access the site privately.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateAccessVirtualNetwork[] VirtualNetwork { get; set; }

    }
}