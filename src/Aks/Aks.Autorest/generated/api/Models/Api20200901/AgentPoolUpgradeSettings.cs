namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Settings for upgrading an agentpool</summary>
    public partial class AgentPoolUpgradeSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettingsInternal
    {

        /// <summary>Backing field for <see cref="MaxSurge" /> property.</summary>
        private string _maxSurge;

        /// <summary>
        /// Count or percentage of additional nodes to be added during upgrade. If empty uses AKS default
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string MaxSurge { get => this._maxSurge; set => this._maxSurge = value; }

        /// <summary>Creates an new <see cref="AgentPoolUpgradeSettings" /> instance.</summary>
        public AgentPoolUpgradeSettings()
        {

        }
    }
    /// Settings for upgrading an agentpool
    public partial interface IAgentPoolUpgradeSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Count or percentage of additional nodes to be added during upgrade. If empty uses AKS default
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Count or percentage of additional nodes to be added during upgrade. If empty uses AKS default",
        SerializedName = @"maxSurge",
        PossibleTypes = new [] { typeof(string) })]
        string MaxSurge { get; set; }

    }
    /// Settings for upgrading an agentpool
    internal partial interface IAgentPoolUpgradeSettingsInternal

    {
        /// <summary>
        /// Count or percentage of additional nodes to be added during upgrade. If empty uses AKS default
        /// </summary>
        string MaxSurge { get; set; }

    }
}