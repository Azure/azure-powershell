namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Trace properties payload</summary>
    public partial class TraceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITraceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AppInsightInstrumentationKey" /> property.</summary>
        private string _appInsightInstrumentationKey;

        /// <summary>Target application insight instrumentation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string AppInsightInstrumentationKey { get => this._appInsightInstrumentationKey; set => this._appInsightInstrumentationKey = value; }

        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IErrorInternal)Error).Code = value; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>Indicates whether enable the tracing functionality</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError _error;

        /// <summary>Error when apply trace proxy changes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.Error()); set => this._error = value; }

        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.Error()); set { {_error = value;} } }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? _state;

        /// <summary>State of the trace proxy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? State { get => this._state; }

        /// <summary>Creates an new <see cref="TraceProperties" /> instance.</summary>
        public TraceProperties()
        {

        }
    }
    /// Trace properties payload
    public partial interface ITraceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Target application insight instrumentation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target application insight instrumentation key",
        SerializedName = @"appInsightInstrumentationKey",
        PossibleTypes = new [] { typeof(string) })]
        string AppInsightInstrumentationKey { get; set; }
        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>Indicates whether enable the tracing functionality</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether enable the tracing functionality",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The message of error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>State of the trace proxy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the trace proxy.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? State { get;  }

    }
    /// Trace properties payload
    public partial interface ITracePropertiesInternal

    {
        /// <summary>Target application insight instrumentation key</summary>
        string AppInsightInstrumentationKey { get; set; }
        /// <summary>The code of error.</summary>
        string Code { get; set; }
        /// <summary>Indicates whether enable the tracing functionality</summary>
        bool? Enabled { get; set; }
        /// <summary>Error when apply trace proxy changes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError Error { get; set; }
        /// <summary>The message of error.</summary>
        string Message { get; set; }
        /// <summary>State of the trace proxy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? State { get; set; }

    }
}