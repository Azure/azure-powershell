namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Connection draining allows open connections to a backend server to be active for a specified time after the backend server
    /// got removed from the configuration.
    /// </summary>
    public partial class ApplicationGatewayConnectionDraining :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDraining,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayConnectionDrainingInternal
    {

        /// <summary>Backing field for <see cref="DrainTimeoutInSec" /> property.</summary>
        private int _drainTimeoutInSec;

        /// <summary>
        /// The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int DrainTimeoutInSec { get => this._drainTimeoutInSec; set => this._drainTimeoutInSec = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool _enabled;

        /// <summary>Whether connection draining is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Creates an new <see cref="ApplicationGatewayConnectionDraining" /> instance.</summary>
        public ApplicationGatewayConnectionDraining()
        {

        }
    }
    /// Connection draining allows open connections to a backend server to be active for a specified time after the backend server
    /// got removed from the configuration.
    public partial interface IApplicationGatewayConnectionDraining :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.",
        SerializedName = @"drainTimeoutInSec",
        PossibleTypes = new [] { typeof(int) })]
        int DrainTimeoutInSec { get; set; }
        /// <summary>Whether connection draining is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Whether connection draining is enabled or not.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool Enabled { get; set; }

    }
    /// Connection draining allows open connections to a backend server to be active for a specified time after the backend server
    /// got removed from the configuration.
    internal partial interface IApplicationGatewayConnectionDrainingInternal

    {
        /// <summary>
        /// The number of seconds connection draining is active. Acceptable values are from 1 second to 3600 seconds.
        /// </summary>
        int DrainTimeoutInSec { get; set; }
        /// <summary>Whether connection draining is enabled or not.</summary>
        bool Enabled { get; set; }

    }
}