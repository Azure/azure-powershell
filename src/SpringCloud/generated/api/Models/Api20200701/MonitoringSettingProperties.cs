namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Monitoring Setting properties payload</summary>
    public partial class MonitoringSettingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AppInsightsInstrumentationKey" /> property.</summary>
        private string _appInsightsInstrumentationKey;

        /// <summary>Target application insight instrumentation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string AppInsightsInstrumentationKey { get => this._appInsightsInstrumentationKey; set => this._appInsightsInstrumentationKey = value; }

        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IErrorInternal)Error).Code = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IError _error;

        /// <summary>Error when apply Monitoring Setting changes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.Error()); set => this._error = value; }

        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IError Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.Error()); set { {_error = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState? _provisioningState;

        /// <summary>State of the Monitoring Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="TraceEnabled" /> property.</summary>
        private bool? _traceEnabled;

        /// <summary>Indicates whether enable the trace functionality</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public bool? TraceEnabled { get => this._traceEnabled; set => this._traceEnabled = value; }

        /// <summary>Creates an new <see cref="MonitoringSettingProperties" /> instance.</summary>
        public MonitoringSettingProperties()
        {

        }
    }
    /// Monitoring Setting properties payload
    public partial interface IMonitoringSettingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Target application insight instrumentation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target application insight instrumentation key",
        SerializedName = @"appInsightsInstrumentationKey",
        PossibleTypes = new [] { typeof(string) })]
        string AppInsightsInstrumentationKey { get; set; }
        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The message of error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>State of the Monitoring Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the Monitoring Setting.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState? ProvisioningState { get;  }
        /// <summary>Indicates whether enable the trace functionality</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether enable the trace functionality",
        SerializedName = @"traceEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TraceEnabled { get; set; }

    }
    /// Monitoring Setting properties payload
    public partial interface IMonitoringSettingPropertiesInternal

    {
        /// <summary>Target application insight instrumentation key</summary>
        string AppInsightsInstrumentationKey { get; set; }
        /// <summary>The code of error.</summary>
        string Code { get; set; }
        /// <summary>Error when apply Monitoring Setting changes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IError Error { get; set; }
        /// <summary>The message of error.</summary>
        string Message { get; set; }
        /// <summary>State of the Monitoring Setting.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState? ProvisioningState { get; set; }
        /// <summary>Indicates whether enable the trace functionality</summary>
        bool? TraceEnabled { get; set; }

    }
}