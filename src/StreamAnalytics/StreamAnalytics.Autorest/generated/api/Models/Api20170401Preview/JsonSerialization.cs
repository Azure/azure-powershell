namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// Describes how data from an input is serialized or how data is serialized when written to an output in JSON format.
    /// </summary>
    public partial class JsonSerialization :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerialization,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerialization"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerialization __serialization = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Serialization();

        /// <summary>
        /// Specifies the encoding of the incoming data in the case of input and the encoding of outgoing data in the case of output.
        /// Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.Encoding? Encoding { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationPropertiesInternal)Property).Encoding; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationPropertiesInternal)Property).Encoding = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.Encoding)""); }

        /// <summary>
        /// This property only applies to JSON serialization of outputs only. It is not applicable to inputs. This property specifies
        /// the format of the JSON the output will be written in. The currently supported values are 'lineSeparated' indicating the
        /// output will be formatted by having each JSON object separated by a new line and 'array' indicating the output will be
        /// formatted as an array of JSON objects. Default value is 'lineSeparated' if left null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JsonOutputSerializationFormat? Format { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationPropertiesInternal)Property).Format; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationPropertiesInternal)Property).Format = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JsonOutputSerializationFormat)""); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.JsonSerializationProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationProperties _property;

        /// <summary>
        /// The properties that are associated with the JSON serialization type. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.JsonSerializationProperties()); set => this._property = value; }

        /// <summary>
        /// Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventSerializationType Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerializationInternal)__serialization).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerializationInternal)__serialization).Type = value ; }

        /// <summary>Creates an new <see cref="JsonSerialization" /> instance.</summary>
        public JsonSerialization()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__serialization), __serialization);
            await eventListener.AssertObjectIsValid(nameof(__serialization), __serialization);
        }
    }
    /// Describes how data from an input is serialized or how data is serialized when written to an output in JSON format.
    public partial interface IJsonSerialization :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerialization
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
    /// Describes how data from an input is serialized or how data is serialized when written to an output in JSON format.
    internal partial interface IJsonSerializationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISerializationInternal
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
        /// <summary>
        /// The properties that are associated with the JSON serialization type. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJsonSerializationProperties Property { get; set; }

    }
}