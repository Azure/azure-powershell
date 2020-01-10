namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListInboundNatRule API service call.</summary>
    public partial class InboundNatRuleListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRuleListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRuleListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRuleListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] _value;

        /// <summary>A list of inbound nat rules in a load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="InboundNatRuleListResult" /> instance.</summary>
        public InboundNatRuleListResult()
        {

        }
    }
    /// Response for ListInboundNatRule API service call.
    public partial interface IInboundNatRuleListResult :
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
        /// <summary>A list of inbound nat rules in a load balancer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of inbound nat rules in a load balancer.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] Value { get; set; }

    }
    /// Response for ListInboundNatRule API service call.
    internal partial interface IInboundNatRuleListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of inbound nat rules in a load balancer.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[] Value { get; set; }

    }
}