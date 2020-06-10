namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>The encryption settings on the storage account.</summary>
    [System.ComponentModel.TypeConverter(typeof(EncryptionTypeConverter))]
    public partial class Encryption
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Encryption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Encryption(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Encryption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Encryption(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Encryption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Encryption(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).Keyvaultproperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties) content.GetValueForProperty("Keyvaultproperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).Keyvaultproperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.KeyVaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).Service = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices) content.GetValueForProperty("Service",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).Service, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServicesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeySource = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource) content.GetValueForProperty("KeySource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeySource, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyName = (string) content.GetValueForProperty("KeyvaultpropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyVersion = (string) content.GetValueForProperty("KeyvaultpropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceBlob = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("ServiceBlob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceBlob, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceFile = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("ServiceFile",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceFile, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceQueue = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("ServiceQueue",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceQueue, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceTable = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("ServiceTable",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceTable, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyVaultUri = (string) content.GetValueForProperty("KeyvaultpropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).TableLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("TableLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).TableLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).BlobLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("BlobLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).BlobLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).FileEnabled = (bool?) content.GetValueForProperty("FileEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).FileEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).FileLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("FileLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).FileLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).QueueEnabled = (bool?) content.GetValueForProperty("QueueEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).QueueEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).QueueLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("QueueLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).QueueLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).TableEnabled = (bool?) content.GetValueForProperty("TableEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).TableEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).BlobEnabled = (bool?) content.GetValueForProperty("BlobEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).BlobEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Encryption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Encryption(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).Keyvaultproperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IKeyVaultProperties) content.GetValueForProperty("Keyvaultproperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).Keyvaultproperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.KeyVaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).Service = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionServices) content.GetValueForProperty("Service",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).Service, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServicesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeySource = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource) content.GetValueForProperty("KeySource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeySource, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeySource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyName = (string) content.GetValueForProperty("KeyvaultpropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyVersion = (string) content.GetValueForProperty("KeyvaultpropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceBlob = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("ServiceBlob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceBlob, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceFile = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("ServiceFile",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceFile, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceQueue = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("ServiceQueue",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceQueue, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceTable = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionService) content.GetValueForProperty("ServiceTable",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).ServiceTable, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.EncryptionServiceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyVaultUri = (string) content.GetValueForProperty("KeyvaultpropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).KeyvaultpropertyKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).TableLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("TableLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).TableLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).BlobLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("BlobLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).BlobLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).FileEnabled = (bool?) content.GetValueForProperty("FileEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).FileEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).FileLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("FileLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).FileLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).QueueEnabled = (bool?) content.GetValueForProperty("QueueEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).QueueEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).QueueLastEnabledTime = (global::System.DateTime?) content.GetValueForProperty("QueueLastEnabledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).QueueLastEnabledTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).TableEnabled = (bool?) content.GetValueForProperty("TableEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).TableEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).BlobEnabled = (bool?) content.GetValueForProperty("BlobEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryptionInternal)this).BlobEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Encryption" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEncryption FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The encryption settings on the storage account.
    [System.ComponentModel.TypeConverter(typeof(EncryptionTypeConverter))]
    public partial interface IEncryption

    {

    }
}