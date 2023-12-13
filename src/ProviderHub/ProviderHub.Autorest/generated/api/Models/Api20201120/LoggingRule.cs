namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class LoggingRule :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRuleInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private string _action;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="DetailLevel" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.LoggingDetails _detailLevel;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.LoggingDetails DetailLevel { get => this._detailLevel; set => this._detailLevel = value; }

        /// <summary>Backing field for <see cref="Direction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.LoggingDirections _direction;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.LoggingDirections Direction { get => this._direction; set => this._direction = value; }

        /// <summary>Backing field for <see cref="HiddenPropertyPath" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPath _hiddenPropertyPath;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPath HiddenPropertyPath { get => (this._hiddenPropertyPath = this._hiddenPropertyPath ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.LoggingHiddenPropertyPath()); set => this._hiddenPropertyPath = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] HiddenPropertyPathHiddenPathsOnRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPathInternal)HiddenPropertyPath).HiddenPathsOnRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPathInternal)HiddenPropertyPath).HiddenPathsOnRequest = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] HiddenPropertyPathHiddenPathsOnResponse { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPathInternal)HiddenPropertyPath).HiddenPathsOnResponse; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPathInternal)HiddenPropertyPath).HiddenPathsOnResponse = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for HiddenPropertyPath</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPath Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRuleInternal.HiddenPropertyPath { get => (this._hiddenPropertyPath = this._hiddenPropertyPath ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.LoggingHiddenPropertyPath()); set { {_hiddenPropertyPath = value;} } }

        /// <summary>Creates an new <see cref="LoggingRule" /> instance.</summary>
        public LoggingRule()
        {

        }
    }
    public partial interface ILoggingRule :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"action",
        PossibleTypes = new [] { typeof(string) })]
        string Action { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"detailLevel",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.LoggingDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.LoggingDetails DetailLevel { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"direction",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.LoggingDirections) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.LoggingDirections Direction { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"hiddenPathsOnRequest",
        PossibleTypes = new [] { typeof(string) })]
        string[] HiddenPropertyPathHiddenPathsOnRequest { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"hiddenPathsOnResponse",
        PossibleTypes = new [] { typeof(string) })]
        string[] HiddenPropertyPathHiddenPathsOnResponse { get; set; }

    }
    internal partial interface ILoggingRuleInternal

    {
        string Action { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.LoggingDetails DetailLevel { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.LoggingDirections Direction { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPath HiddenPropertyPath { get; set; }

        string[] HiddenPropertyPathHiddenPathsOnRequest { get; set; }

        string[] HiddenPropertyPathHiddenPathsOnResponse { get; set; }

    }
}