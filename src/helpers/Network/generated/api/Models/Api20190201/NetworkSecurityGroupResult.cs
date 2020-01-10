namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Network configuration diagnostic result corresponded provided traffic query.</summary>
    public partial class NetworkSecurityGroupResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResultInternal
    {

        /// <summary>Backing field for <see cref="EvaluatedNsg" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[] _evaluatedNsg;

        /// <summary>List of results network security groups diagnostic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[] EvaluatedNsg { get => this._evaluatedNsg; }

        /// <summary>Internal Acessors for EvaluatedNsg</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupResultInternal.EvaluatedNsg { get => this._evaluatedNsg; set { {_evaluatedNsg = value;} } }

        /// <summary>Backing field for <see cref="SecurityRuleAccessResult" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? _securityRuleAccessResult;

        /// <summary>The network traffic is allowed or denied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? SecurityRuleAccessResult { get => this._securityRuleAccessResult; set => this._securityRuleAccessResult = value; }

        /// <summary>Creates an new <see cref="NetworkSecurityGroupResult" /> instance.</summary>
        public NetworkSecurityGroupResult()
        {

        }
    }
    /// Network configuration diagnostic result corresponded provided traffic query.
    public partial interface INetworkSecurityGroupResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of results network security groups diagnostic.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of results network security groups diagnostic.",
        SerializedName = @"evaluatedNetworkSecurityGroups",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[] EvaluatedNsg { get;  }
        /// <summary>The network traffic is allowed or denied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The network traffic is allowed or denied.",
        SerializedName = @"securityRuleAccessResult",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? SecurityRuleAccessResult { get; set; }

    }
    /// Network configuration diagnostic result corresponded provided traffic query.
    internal partial interface INetworkSecurityGroupResultInternal

    {
        /// <summary>List of results network security groups diagnostic.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup[] EvaluatedNsg { get; set; }
        /// <summary>The network traffic is allowed or denied.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess? SecurityRuleAccessResult { get; set; }

    }
}