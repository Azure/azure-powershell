namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Rules that can be defined for auto-heal.</summary>
    public partial class AutoHealRules :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActions _action;

        /// <summary>Actions to be executed when a rule is triggered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActions Action { get => (this._action = this._action ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealActions()); set => this._action = value; }

        /// <summary>
        /// Minimum time the process must execute
        /// before taking the action
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActionMinProcessExecutionTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal)Action).MinProcessExecutionTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal)Action).MinProcessExecutionTime = value; }

        /// <summary>Predefined action to be taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType? ActionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal)Action).ActionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal)Action).ActionType = value; }

        /// <summary>Executable to be run.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomActionExe { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal)Action).CustomActionExe; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal)Action).CustomActionExe = value; }

        /// <summary>Parameters for the executable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomActionParameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal)Action).CustomActionParameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal)Action).CustomActionParameter = value; }

        /// <summary>Internal Acessors for Action</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActions Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal.Action { get => (this._action = this._action ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealActions()); set { {_action = value;} } }

        /// <summary>Internal Acessors for ActionCustomAction</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal.ActionCustomAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal)Action).CustomAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActionsInternal)Action).CustomAction = value; }

        /// <summary>Internal Acessors for Trigger</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal.Trigger { get => (this._trigger = this._trigger ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealTriggers()); set { {_trigger = value;} } }

        /// <summary>Internal Acessors for TriggerRequest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTrigger Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal.TriggerRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).Request; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).Request = value; }

        /// <summary>Internal Acessors for TriggerSlowRequest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTrigger Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal.TriggerSlowRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).SlowRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).SlowRequest = value; }

        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? RequestCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).RequestCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).RequestCount = value; }

        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RequestTimeInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).RequestTimeInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).RequestTimeInterval = value; }

        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SlowRequestCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).SlowRequestCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).SlowRequestCount = value; }

        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SlowRequestTimeInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).SlowRequestTimeInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).SlowRequestTimeInterval = value; }

        /// <summary>Time taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SlowRequestTimeTaken { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).SlowRequestTimeTaken; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).SlowRequestTimeTaken = value; }

        /// <summary>Backing field for <see cref="Trigger" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers _trigger;

        /// <summary>Conditions that describe when to execute the auto-heal actions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers Trigger { get => (this._trigger = this._trigger ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealTriggers()); set => this._trigger = value; }

        /// <summary>A rule based on private bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? TriggerPrivateBytesInKb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).PrivateBytesInKb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).PrivateBytesInKb = value; }

        /// <summary>A rule based on status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[] TriggerStatusCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).StatusCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)Trigger).StatusCode = value; }

        /// <summary>Creates an new <see cref="AutoHealRules" /> instance.</summary>
        public AutoHealRules()
        {

        }
    }
    /// Rules that can be defined for auto-heal.
    public partial interface IAutoHealRules :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
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
        string ActionMinProcessExecutionTime { get; set; }
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
        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request Count.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? RequestCount { get; set; }
        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time interval.",
        SerializedName = @"timeInterval",
        PossibleTypes = new [] { typeof(string) })]
        string RequestTimeInterval { get; set; }
        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request Count.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? SlowRequestCount { get; set; }
        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time interval.",
        SerializedName = @"timeInterval",
        PossibleTypes = new [] { typeof(string) })]
        string SlowRequestTimeInterval { get; set; }
        /// <summary>Time taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time taken.",
        SerializedName = @"timeTaken",
        PossibleTypes = new [] { typeof(string) })]
        string SlowRequestTimeTaken { get; set; }
        /// <summary>A rule based on private bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A rule based on private bytes.",
        SerializedName = @"privateBytesInKB",
        PossibleTypes = new [] { typeof(int) })]
        int? TriggerPrivateBytesInKb { get; set; }
        /// <summary>A rule based on status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A rule based on status codes.",
        SerializedName = @"statusCodes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[] TriggerStatusCode { get; set; }

    }
    /// Rules that can be defined for auto-heal.
    internal partial interface IAutoHealRulesInternal

    {
        /// <summary>Actions to be executed when a rule is triggered.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActions Action { get; set; }
        /// <summary>Custom action to be taken.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction ActionCustomAction { get; set; }
        /// <summary>
        /// Minimum time the process must execute
        /// before taking the action
        /// </summary>
        string ActionMinProcessExecutionTime { get; set; }
        /// <summary>Predefined action to be taken.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType? ActionType { get; set; }
        /// <summary>Executable to be run.</summary>
        string CustomActionExe { get; set; }
        /// <summary>Parameters for the executable.</summary>
        string CustomActionParameter { get; set; }
        /// <summary>Request Count.</summary>
        int? RequestCount { get; set; }
        /// <summary>Time interval.</summary>
        string RequestTimeInterval { get; set; }
        /// <summary>Request Count.</summary>
        int? SlowRequestCount { get; set; }
        /// <summary>Time interval.</summary>
        string SlowRequestTimeInterval { get; set; }
        /// <summary>Time taken.</summary>
        string SlowRequestTimeTaken { get; set; }
        /// <summary>Conditions that describe when to execute the auto-heal actions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers Trigger { get; set; }
        /// <summary>A rule based on private bytes.</summary>
        int? TriggerPrivateBytesInKb { get; set; }
        /// <summary>A rule based on total requests.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTrigger TriggerRequest { get; set; }
        /// <summary>A rule based on request execution time.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTrigger TriggerSlowRequest { get; set; }
        /// <summary>A rule based on status codes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[] TriggerStatusCode { get; set; }

    }
}