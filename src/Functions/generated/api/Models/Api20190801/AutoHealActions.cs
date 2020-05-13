namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Actions which to take by the auto-heal module when a rule is triggered.</summary>
    public partial class AutoHealActions :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActions,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal
    {

        /// <summary>Backing field for <see cref="ActionType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType? _actionType;

        /// <summary>Predefined action to be taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType? ActionType { get => this._actionType; set => this._actionType = value; }

        /// <summary>Backing field for <see cref="CustomAction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction _customAction;

        /// <summary>Custom action to be taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction CustomAction { get => (this._customAction = this._customAction ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealCustomAction()); set => this._customAction = value; }

        /// <summary>Executable to be run.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomActionExe { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomActionInternal)CustomAction).Exe; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomActionInternal)CustomAction).Exe = value; }

        /// <summary>Parameters for the executable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomActionParameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomActionInternal)CustomAction).Parameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomActionInternal)CustomAction).Parameter = value; }

        /// <summary>Internal Acessors for CustomAction</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal.CustomAction { get => (this._customAction = this._customAction ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealCustomAction()); set { {_customAction = value;} } }

        /// <summary>Backing field for <see cref="MinProcessExecutionTime" /> property.</summary>
        private string _minProcessExecutionTime;

        /// <summary>
        /// Minimum time the process must execute
        /// before taking the action
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MinProcessExecutionTime { get => this._minProcessExecutionTime; set => this._minProcessExecutionTime = value; }

        /// <summary>Creates an new <see cref="AutoHealActions" /> instance.</summary>
        public AutoHealActions()
        {

        }
    }
    /// Actions which to take by the auto-heal module when a rule is triggered.
    public partial interface IAutoHealActions :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Predefined action to be taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Predefined action to be taken.",
        SerializedName = @"actionType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType? ActionType { get; set; }
        /// <summary>Executable to be run.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Executable to be run.",
        SerializedName = @"exe",
        PossibleTypes = new [] { typeof(string) })]
        string CustomActionExe { get; set; }
        /// <summary>Parameters for the executable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Parameters for the executable.",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(string) })]
        string CustomActionParameter { get; set; }
        /// <summary>
        /// Minimum time the process must execute
        /// before taking the action
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum time the process must execute
        before taking the action",
        SerializedName = @"minProcessExecutionTime",
        PossibleTypes = new [] { typeof(string) })]
        string MinProcessExecutionTime { get; set; }

    }
    /// Actions which to take by the auto-heal module when a rule is triggered.
    internal partial interface IAutoHealActionsInternal

    {
        /// <summary>Predefined action to be taken.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType? ActionType { get; set; }
        /// <summary>Custom action to be taken.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction CustomAction { get; set; }
        /// <summary>Executable to be run.</summary>
        string CustomActionExe { get; set; }
        /// <summary>Parameters for the executable.</summary>
        string CustomActionParameter { get; set; }
        /// <summary>
        /// Minimum time the process must execute
        /// before taking the action
        /// </summary>
        string MinProcessExecutionTime { get; set; }

    }
}