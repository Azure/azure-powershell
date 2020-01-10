namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for the CheckDnsNameAvailability API service call.</summary>
    public partial class DnsNameAvailabilityResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDnsNameAvailabilityResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IDnsNameAvailabilityResultInternal
    {

        /// <summary>Backing field for <see cref="Available" /> property.</summary>
        private bool? _available;

        /// <summary>Domain availability (True/False).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? Available { get => this._available; set => this._available = value; }

        /// <summary>Creates an new <see cref="DnsNameAvailabilityResult" /> instance.</summary>
        public DnsNameAvailabilityResult()
        {

        }
    }
    /// Response for the CheckDnsNameAvailability API service call.
    public partial interface IDnsNameAvailabilityResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Domain availability (True/False).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Domain availability (True/False).",
        SerializedName = @"available",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Available { get; set; }

    }
    /// Response for the CheckDnsNameAvailability API service call.
    internal partial interface IDnsNameAvailabilityResultInternal

    {
        /// <summary>Domain availability (True/False).</summary>
        bool? Available { get; set; }

    }
}