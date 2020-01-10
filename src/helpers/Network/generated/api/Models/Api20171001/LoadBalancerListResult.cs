namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListLoadBalancers API service call.</summary>
    public partial class LoadBalancerListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancerListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancer[] _value;

        /// <summary>A list of load balancers in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancer[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="LoadBalancerListResult" /> instance.</summary>
        public LoadBalancerListResult()
        {

        }
    }
    /// Response for ListLoadBalancers API service call.
    public partial interface ILoadBalancerListResult :
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
        /// <summary>A list of load balancers in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of load balancers in a resource group.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancer[] Value { get; set; }

    }
    /// Response for ListLoadBalancers API service call.
    internal partial interface ILoadBalancerListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of load balancers in a resource group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ILoadBalancer[] Value { get; set; }

    }
}