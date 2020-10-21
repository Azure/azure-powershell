namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class AgentConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAgentConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAgentConfigurationInternal
    {

        /// <summary>Backing field for <see cref="AgentId" /> property.</summary>
        private string _agentId;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AgentId { get => this._agentId; set => this._agentId = value; }

        /// <summary>Backing field for <see cref="ClockGranularity" /> property.</summary>
        private int? _clockGranularity;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? ClockGranularity { get => this._clockGranularity; set => this._clockGranularity = value; }

        /// <summary>Backing field for <see cref="DependencyAgentId" /> property.</summary>
        private string _dependencyAgentId;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DependencyAgentId { get => this._dependencyAgentId; set => this._dependencyAgentId = value; }

        /// <summary>Backing field for <see cref="DependencyAgentRevision" /> property.</summary>
        private string _dependencyAgentRevision;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DependencyAgentRevision { get => this._dependencyAgentRevision; set => this._dependencyAgentRevision = value; }

        /// <summary>Backing field for <see cref="DependencyAgentVersion" /> property.</summary>
        private string _dependencyAgentVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DependencyAgentVersion { get => this._dependencyAgentVersion; set => this._dependencyAgentVersion = value; }

        /// <summary>Backing field for <see cref="RebootStatus" /> property.</summary>
        private string _rebootStatus;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RebootStatus { get => this._rebootStatus; set => this._rebootStatus = value; }

        /// <summary>Creates an new <see cref="AgentConfiguration" /> instance.</summary>
        public AgentConfiguration()
        {

        }
    }
    public partial interface IAgentConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"agentId",
        PossibleTypes = new [] { typeof(string) })]
        string AgentId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"clockGranularity",
        PossibleTypes = new [] { typeof(int) })]
        int? ClockGranularity { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"dependencyAgentId",
        PossibleTypes = new [] { typeof(string) })]
        string DependencyAgentId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"dependencyAgentRevision",
        PossibleTypes = new [] { typeof(string) })]
        string DependencyAgentRevision { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"dependencyAgentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string DependencyAgentVersion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"rebootStatus",
        PossibleTypes = new [] { typeof(string) })]
        string RebootStatus { get; set; }

    }
    internal partial interface IAgentConfigurationInternal

    {
        string AgentId { get; set; }

        int? ClockGranularity { get; set; }

        string DependencyAgentId { get; set; }

        string DependencyAgentRevision { get; set; }

        string DependencyAgentVersion { get; set; }

        string RebootStatus { get; set; }

    }
}