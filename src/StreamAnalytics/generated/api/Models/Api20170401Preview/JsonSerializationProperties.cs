namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with the JSON serialization type.</summary>
    public partial class JsonSerializationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Encoding" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.Encoding? _encoding;

        /// <summary>
        /// Specifies the encoding of the incoming data in the case of input and the encoding of outgoing data in the case of output.
        /// Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.Encoding? Encoding { get => this._encoding; set => this._encoding = value; }

        /// <summary>Backing field for <see cref="Format" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JsonOutputSerializationFormat? _format;

        /// <summary>
        /// This property only applies to JSON serialization of outputs only. It is not applicable to inputs. This property specifies
        /// the format of the JSON the output will be written in. The currently supported values are 'lineSeparated' indicating the
        /// output will be formatted by having each JSON object separated by a new line and 'array' indicating the output will be
        /// formatted as an array of JSON objects. Default value is 'lineSeparated' if left null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JsonOutputSerializationFormat? Format { get => this._format; set => this._format = value; }

        /// <summary>Creates an new <see cref="JsonSerializationProperties" /> instance.</summary>
        public JsonSerializationProperties()
        {

        }
    }
    /// The properties that are associated with the JSON serialization type.
    public partial interface IJsonSerializationProperties :
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
        /// This property only applies to JSON serialization of outputs only. It is not applicable to inputs. This property specifies
        /// the format of the JSON the output will be written in. The currently supported values are 'lineSeparated' indicating the
        /// output will be formatted by having each JSON object separated by a new line and 'array' indicating the output will be
        /// formatted as an array of JSON objects. Default value is 'lineSeparated' if left null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This property only applies to JSON serialization of outputs only. It is not applicable to inputs. This property specifies the format of the JSON the output will be written in. The currently supported values are 'lineSeparated' indicating the output will be formatted by having each JSON object separated by a new line and 'array' indicating the output will be formatted as an array of JSON objects. Default value is 'lineSeparated' if left null.",
        SerializedName = @"format",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JsonOutputSerializationFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JsonOutputSerializationFormat? Format { get; set; }

    }
    /// The properties that are associated with the JSON serialization type.
    internal partial interface IJsonSerializationPropertiesInternal

    {
        /// <summary>
        /// Specifies the encoding of the incoming data in the case of input and the encoding of outgoing data in the case of output.
        /// Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.Encoding? Encoding { get; set; }
        /// <summary>
        /// This property only applies to JSON serialization of outputs only. It is not applicable to inputs. This property specifies
        /// the format of the JSON the output will be written in. The currently supported values are 'lineSeparated' indicating the
        /// output will be formatted by having each JSON object separated by a new line and 'array' indicating the output will be
        /// formatted as an array of JSON objects. Default value is 'lineSeparated' if left null.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JsonOutputSerializationFormat? Format { get; set; }

    }
}