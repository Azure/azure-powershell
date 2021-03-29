namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>Compliance Status details</summary>
    public partial class ComplianceStatus :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatus,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal
    {

        /// <summary>Backing field for <see cref="ComplianceState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? _complianceState;

        /// <summary>The compliance state of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? ComplianceState { get => this._complianceState; }

        /// <summary>Backing field for <see cref="LastConfigApplied" /> property.</summary>
        private global::System.DateTime? _lastConfigApplied;

        /// <summary>Datetime the configuration was last applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public global::System.DateTime? LastConfigApplied { get => this._lastConfigApplied; set => this._lastConfigApplied = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Message from when the configuration was applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="MessageLevel" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType? _messageLevel;

        /// <summary>Level of the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType? MessageLevel { get => this._messageLevel; set => this._messageLevel = value; }

        /// <summary>Internal Acessors for ComplianceState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IComplianceStatusInternal.ComplianceState { get => this._complianceState; set { {_complianceState = value;} } }

        /// <summary>Creates an new <see cref="ComplianceStatus" /> instance.</summary>
        public ComplianceStatus()
        {

        }
    }
    /// Compliance Status details
    public partial interface IComplianceStatus :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The compliance state of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The compliance state of the configuration.",
        SerializedName = @"complianceState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? ComplianceState { get;  }
        /// <summary>Datetime the configuration was last applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Datetime the configuration was last applied.",
        SerializedName = @"lastConfigApplied",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastConfigApplied { get; set; }
        /// <summary>Message from when the configuration was applied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Message from when the configuration was applied.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Level of the message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Level of the message.",
        SerializedName = @"messageLevel",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType? MessageLevel { get; set; }

    }
    /// Compliance Status details
    internal partial interface IComplianceStatusInternal

    {
        /// <summary>The compliance state of the configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.ComplianceStateType? ComplianceState { get; set; }
        /// <summary>Datetime the configuration was last applied.</summary>
        global::System.DateTime? LastConfigApplied { get; set; }
        /// <summary>Message from when the configuration was applied.</summary>
        string Message { get; set; }
        /// <summary>Level of the message.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.MessageLevelType? MessageLevel { get; set; }

    }
}