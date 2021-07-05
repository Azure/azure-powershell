namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>The response from the List Agent Pools operation.</summary>
    public partial class AgentPoolListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of agent pool results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool[] _value;

        /// <summary>The list of agent pools.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="AgentPoolListResult" /> instance.</summary>
        public AgentPoolListResult()
        {

        }
    }
    /// The response from the List Agent Pools operation.
    public partial interface IAgentPoolListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of agent pool results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URL to get the next set of agent pool results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>The list of agent pools.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of agent pools.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool[] Value { get; set; }

    }
    /// The response from the List Agent Pools operation.
    internal partial interface IAgentPoolListResultInternal

    {
        /// <summary>The URL to get the next set of agent pool results.</summary>
        string NextLink { get; set; }
        /// <summary>The list of agent pools.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool[] Value { get; set; }

    }
}