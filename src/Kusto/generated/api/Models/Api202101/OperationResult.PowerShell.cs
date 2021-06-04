namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>Operation Result Entity.</summary>
    [System.ComponentModel.TypeConverter(typeof(OperationResultTypeConverter))]
    public partial class OperationResult
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResult" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OperationResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResult" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OperationResult(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OperationResult" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OperationResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorProperties) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResultErrorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Status?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Status.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).PercentComplete = (double?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).PercentComplete, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).OperationKind = (string) content.GetValueForProperty("OperationKind",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).OperationKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).OperationState = (string) content.GetValueForProperty("OperationState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).OperationState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Message, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OperationResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultErrorProperties) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.OperationResultErrorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Status?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Status.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).PercentComplete = (double?) content.GetValueForProperty("PercentComplete",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).PercentComplete, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).OperationKind = (string) content.GetValueForProperty("OperationKind",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).OperationKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).OperationState = (string) content.GetValueForProperty("OperationState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).OperationState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultInternal)this).Message, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Operation Result Entity.
    [System.ComponentModel.TypeConverter(typeof(OperationResultTypeConverter))]
    public partial interface IOperationResult

    {

    }
}