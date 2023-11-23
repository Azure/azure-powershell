namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with an output.</summary>
    public partial class OutputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Datasource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource _datasource;

        /// <summary>
        /// Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource Datasource { get => (this._datasource = this._datasource ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.OutputDataSource()); set => this._datasource = value; }

        /// <summary>Backing field for <see cref="Diagnostic" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnostics _diagnostic;

        /// <summary>
        /// Describes conditions applicable to the Input, Output, or the job overall, that warrant customer attention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnostics Diagnostic { get => (this._diagnostic = this._diagnostic ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Diagnostics()); }

        /// <summary>
        /// A collection of zero or more conditions applicable to the resource, or to the job overall, that warrant customer attention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition[] DiagnosticCondition { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticsInternal)Diagnostic).Condition; }

        /// <summary>Internal Acessors for Diagnostic</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnostics Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputPropertiesInternal.Diagnostic { get => (this._diagnostic = this._diagnostic ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Diagnostics()); set { {_diagnostic = value;} } }

        /// <summary>Internal Acessors for DiagnosticCondition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition[] Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputPropertiesInternal.DiagnosticCondition { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticsInternal)Diagnostic).Condition; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticsInternal)Diagnostic).Condition = value; }

        /// <summary>Internal Acessors for Serialization</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerialization Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputPropertiesInternal.Serialization { get => (this._serialization = this._serialization ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Serialization()); set { {_serialization = value;} } }

        /// <summary>Backing field for <see cref="Serialization" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerialization _serialization;

        /// <summary>
        /// Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace)
        /// requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerialization Serialization { get => (this._serialization = this._serialization ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Serialization()); set => this._serialization = value; }

        /// <summary>
        /// Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType? SerializationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerializationInternal)Serialization).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerializationInternal)Serialization).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType)""); }

        /// <summary>Backing field for <see cref="SizeWindow" /> property.</summary>
        private float? _sizeWindow;

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public float? SizeWindow { get => this._sizeWindow; set => this._sizeWindow = value; }

        /// <summary>Backing field for <see cref="TimeWindow" /> property.</summary>
        private string _timeWindow;

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string TimeWindow { get => this._timeWindow; set => this._timeWindow = value; }

        /// <summary>Creates an new <see cref="OutputProperties" /> instance.</summary>
        public OutputProperties()
        {

        }
    }
    /// The properties that are associated with an output.
    public partial interface IOutputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"datasource",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource Datasource { get; set; }
        /// <summary>
        /// A collection of zero or more conditions applicable to the resource, or to the job overall, that warrant customer attention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of zero or more conditions applicable to the resource, or to the job overall, that warrant customer attention.",
        SerializedName = @"conditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition[] DiagnosticCondition { get;  }
        /// <summary>
        /// Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType? SerializationType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"sizeWindow",
        PossibleTypes = new [] { typeof(float) })]
        float? SizeWindow { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"timeWindow",
        PossibleTypes = new [] { typeof(string) })]
        string TimeWindow { get; set; }

    }
    /// The properties that are associated with an output.
    internal partial interface IOutputPropertiesInternal

    {
        /// <summary>
        /// Describes the data source that output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource Datasource { get; set; }
        /// <summary>
        /// Describes conditions applicable to the Input, Output, or the job overall, that warrant customer attention.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnostics Diagnostic { get; set; }
        /// <summary>
        /// A collection of zero or more conditions applicable to the resource, or to the job overall, that warrant customer attention.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDiagnosticCondition[] DiagnosticCondition { get; set; }
        /// <summary>
        /// Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace)
        /// requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerialization Serialization { get; set; }
        /// <summary>
        /// Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType? SerializationType { get; set; }

        float? SizeWindow { get; set; }

        string TimeWindow { get; set; }

    }
}