namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The details of the InMage agent.</summary>
    public partial class InMageAgentDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal
    {

        /// <summary>Backing field for <see cref="AgentExpiryDate" /> property.</summary>
        private global::System.DateTime? _agentExpiryDate;

        /// <summary>Agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? AgentExpiryDate { get => this._agentExpiryDate; set => this._agentExpiryDate = value; }

        /// <summary>Backing field for <see cref="AgentUpdateStatus" /> property.</summary>
        private string _agentUpdateStatus;

        /// <summary>A value indicating whether installed agent needs to be updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AgentUpdateStatus { get => this._agentUpdateStatus; set => this._agentUpdateStatus = value; }

        /// <summary>Backing field for <see cref="AgentVersion" /> property.</summary>
        private string _agentVersion;

        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AgentVersion { get => this._agentVersion; set => this._agentVersion = value; }

        /// <summary>Backing field for <see cref="PostUpdateRebootStatus" /> property.</summary>
        private string _postUpdateRebootStatus;

        /// <summary>A value indicating whether reboot is required after update is applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PostUpdateRebootStatus { get => this._postUpdateRebootStatus; set => this._postUpdateRebootStatus = value; }

        /// <summary>Creates an new <see cref="InMageAgentDetails" /> instance.</summary>
        public InMageAgentDetails()
        {

        }
    }
    /// The details of the InMage agent.
    public partial interface IInMageAgentDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Agent expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Agent expiry date.",
        SerializedName = @"agentExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? AgentExpiryDate { get; set; }
        /// <summary>A value indicating whether installed agent needs to be updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether installed agent needs to be updated.",
        SerializedName = @"agentUpdateStatus",
        PossibleTypes = new [] { typeof(string) })]
        string AgentUpdateStatus { get; set; }
        /// <summary>The agent version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The agent version.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string AgentVersion { get; set; }
        /// <summary>A value indicating whether reboot is required after update is applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether reboot is required after update is applied.",
        SerializedName = @"postUpdateRebootStatus",
        PossibleTypes = new [] { typeof(string) })]
        string PostUpdateRebootStatus { get; set; }

    }
    /// The details of the InMage agent.
    internal partial interface IInMageAgentDetailsInternal

    {
        /// <summary>Agent expiry date.</summary>
        global::System.DateTime? AgentExpiryDate { get; set; }
        /// <summary>A value indicating whether installed agent needs to be updated.</summary>
        string AgentUpdateStatus { get; set; }
        /// <summary>The agent version.</summary>
        string AgentVersion { get; set; }
        /// <summary>A value indicating whether reboot is required after update is applied.</summary>
        string PostUpdateRebootStatus { get; set; }

    }
}