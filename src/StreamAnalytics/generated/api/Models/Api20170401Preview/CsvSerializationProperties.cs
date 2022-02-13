namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with the CSV serialization type.</summary>
    public partial class CsvSerializationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICsvSerializationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICsvSerializationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Encoding" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.Encoding? _encoding;

        /// <summary>
        /// Specifies the encoding of the incoming data in the case of input and the encoding of outgoing data in the case of output.
        /// Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.Encoding? Encoding { get => this._encoding; set => this._encoding = value; }

        /// <summary>Backing field for <see cref="FieldDelimiter" /> property.</summary>
        private string _fieldDelimiter;

        /// <summary>
        /// Specifies the delimiter that will be used to separate comma-separated value (CSV) records. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input
        /// or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a list of supported values. Required
        /// on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string FieldDelimiter { get => this._fieldDelimiter; set => this._fieldDelimiter = value; }

        /// <summary>Creates an new <see cref="CsvSerializationProperties" /> instance.</summary>
        public CsvSerializationProperties()
        {

        }
    }
    /// The properties that are associated with the CSV serialization type.
    public partial interface ICsvSerializationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Specifies the encoding of the incoming data in the case of input and the encoding of outgoing data in the case of output.
        /// Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the encoding of the incoming data in the case of input and the encoding of outgoing data in the case of output. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"encoding",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.Encoding) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.Encoding? Encoding { get; set; }
        /// <summary>
        /// Specifies the delimiter that will be used to separate comma-separated value (CSV) records. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input
        /// or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a list of supported values. Required
        /// on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the delimiter that will be used to separate comma-separated value (CSV) records. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a list of supported values. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"fieldDelimiter",
        PossibleTypes = new [] { typeof(string) })]
        string FieldDelimiter { get; set; }

    }
    /// The properties that are associated with the CSV serialization type.
    internal partial interface ICsvSerializationPropertiesInternal

    {
        /// <summary>
        /// Specifies the encoding of the incoming data in the case of input and the encoding of outgoing data in the case of output.
        /// Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.Encoding? Encoding { get; set; }
        /// <summary>
        /// Specifies the delimiter that will be used to separate comma-separated value (CSV) records. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input
        /// or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a list of supported values. Required
        /// on PUT (CreateOrReplace) requests.
        /// </summary>
        string FieldDelimiter { get; set; }

    }
}