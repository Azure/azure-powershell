namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>The list of available agent pool versions.</summary>
    public partial class AgentPoolAvailableVersionsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AgentPoolVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem[] _agentPoolVersion;

        /// <summary>List of versions available for agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem[] AgentPoolVersion { get => this._agentPoolVersion; set => this._agentPoolVersion = value; }

        /// <summary>Creates an new <see cref="AgentPoolAvailableVersionsProperties" /> instance.</summary>
        public AgentPoolAvailableVersionsProperties()
        {

        }
    }
    /// The list of available agent pool versions.
    public partial interface IAgentPoolAvailableVersionsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>List of versions available for agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of versions available for agent pool.",
        SerializedName = @"agentPoolVersions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem[] AgentPoolVersion { get; set; }

    }
    /// The list of available agent pool versions.
    internal partial interface IAgentPoolAvailableVersionsPropertiesInternal

    {
        /// <summary>List of versions available for agent pool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolAvailableVersionsPropertiesAgentPoolVersionsItem[] AgentPoolVersion { get; set; }

    }
}