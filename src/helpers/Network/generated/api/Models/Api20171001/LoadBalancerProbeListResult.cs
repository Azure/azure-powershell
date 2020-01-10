namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListProbe API service call.</summary>
    public partial class LoadBalancerProbeListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerProbeListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerProbeListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerProbeListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe[] _value;

        /// <summary>A list of probes in a load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="LoadBalancerProbeListResult" /> instance.</summary>
        public LoadBalancerProbeListResult()
        {

        }
    }
    /// Response for ListProbe API service call.
    public partial interface ILoadBalancerProbeListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>A list of probes in a load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of probes in a load balancer.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe[] Value { get; set; }

    }
    /// Response for ListProbe API service call.
    internal partial interface ILoadBalancerProbeListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of probes in a load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IProbe[] Value { get; set; }

    }
}