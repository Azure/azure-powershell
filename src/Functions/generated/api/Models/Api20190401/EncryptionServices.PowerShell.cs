namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>A list of services that support encryption.</summary>
    [System.ComponentModel.TypeConverter(typeof(EncryptionServicesTypeConverter))]
    public partial class EncryptionServices
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServices"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EncryptionServices(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServices"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EncryptionServices(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServices"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EncryptionServices(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Blob = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("Blob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Blob, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).File = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("File",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).File, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Queue = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("Queue",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Queue, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Table = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("Table",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Table, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).BlobEnabled = (bool?) content.GetValueForProperty("BlobEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).BlobEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).BlobLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("BlobLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).BlobLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).FileEnabled = (bool?) content.GetValueForProperty("FileEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).FileEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).FileLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("FileLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).FileLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).QueueEnabled = (bool?) content.GetValueForProperty("QueueEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).QueueEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).QueueLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("QueueLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).QueueLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).TableEnabled = (bool?) content.GetValueForProperty("TableEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).TableEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).TableLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("TableLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).TableLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServices"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EncryptionServices(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Blob = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("Blob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Blob, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).File = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("File",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).File, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Queue = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("Queue",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Queue, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Table = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("Table",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).Table, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).BlobEnabled = (bool?) content.GetValueForProperty("BlobEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).BlobEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).BlobLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("BlobLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).BlobLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).FileEnabled = (bool?) content.GetValueForProperty("FileEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).FileEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).FileLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("FileLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).FileLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).QueueEnabled = (bool?) content.GetValueForProperty("QueueEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).QueueEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).QueueLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("QueueLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).QueueLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).TableEnabled = (bool?) content.GetValueForProperty("TableEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).TableEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).TableLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("TableLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServicesInternal)this).TableLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EncryptionServices" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A list of services that support encryption.
    [System.ComponentModel.TypeConverter(typeof(EncryptionServicesTypeConverter))]
    public partial interface IEncryptionServices

    {

    }
}