namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for CheckIPAddressAvailability API service call</summary>
    public partial class IPAddressAvailabilityResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPAddressAvailabilityResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPAddressAvailabilityResultInternal
    {

        /// <summary>Backing field for <see cref="Available" /> property.</summary>
        private bool? _available;

        /// <summary>Private IP address availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? Available { get => this._available; set => this._available = value; }

        /// <summary>Backing field for <see cref="AvailableIPAddress" /> property.</summary>
        private string[] _availableIPAddress;

        /// <summary>
        /// Contains other available private IP addresses if the asked for address is taken.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] AvailableIPAddress { get => this._availableIPAddress; set => this._availableIPAddress = value; }

        /// <summary>Creates an new <see cref="IPAddressAvailabilityResult" /> instance.</summary>
        public IPAddressAvailabilityResult()
        {

        }
    }
    /// Response for CheckIPAddressAvailability API service call
    public partial interface IIPAddressAvailabilityResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Private IP address availability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private IP address availability.",
        SerializedName = @"available",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Available { get; set; }
        /// <summary>
        /// Contains other available private IP addresses if the asked for address is taken.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Contains other available private IP addresses if the asked for address is taken.",
        SerializedName = @"availableIPAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] AvailableIPAddress { get; set; }

    }
    /// Response for CheckIPAddressAvailability API service call
    internal partial interface IIPAddressAvailabilityResultInternal

    {
        /// <summary>Private IP address availability.</summary>
        bool? Available { get; set; }
        /// <summary>
        /// Contains other available private IP addresses if the asked for address is taken.
        /// </summary>
        string[] AvailableIPAddress { get; set; }

    }
}