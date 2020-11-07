namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>The parameters to list service SAS credentials of a specific resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServiceSasParametersTypeConverter))]
    public partial class ServiceSasParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ServiceSasParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServiceSasParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ServiceSasParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServiceSasParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServiceSasParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ServiceSasParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServiceSasParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).CanonicalizedResource = (string) content.GetValueForProperty("CanonicalizedResource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).CanonicalizedResource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).PartitionKeyEnd = (string) content.GetValueForProperty("PartitionKeyEnd",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).PartitionKeyEnd, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).RowKeyEnd = (string) content.GetValueForProperty("RowKeyEnd",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).RowKeyEnd, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).KeyToSign = (string) content.GetValueForProperty("KeyToSign",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).KeyToSign, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).CacheControl = (string) content.GetValueForProperty("CacheControl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).CacheControl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentDisposition = (string) content.GetValueForProperty("ContentDisposition",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentDisposition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentEncoding = (string) content.GetValueForProperty("ContentEncoding",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentEncoding, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentLanguage = (string) content.GetValueForProperty("ContentLanguage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentLanguage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentType = (string) content.GetValueForProperty("ContentType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).SharedAccessExpiryTime = (global::System.DateTime?) content.GetValueForProperty("SharedAccessExpiryTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).SharedAccessExpiryTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Identifier = (string) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Identifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).IPAddressOrRange = (string) content.GetValueForProperty("IPAddressOrRange",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).IPAddressOrRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Permission = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions?) content.GetValueForProperty("Permission",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Permission, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Resource = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResource?) content.GetValueForProperty("Resource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Resource, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).SharedAccessStartTime = (global::System.DateTime?) content.GetValueForProperty("SharedAccessStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).SharedAccessStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).PartitionKeyStart = (string) content.GetValueForProperty("PartitionKeyStart",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).PartitionKeyStart, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).RowKeyStart = (string) content.GetValueForProperty("RowKeyStart",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).RowKeyStart, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ServiceSasParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServiceSasParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).CanonicalizedResource = (string) content.GetValueForProperty("CanonicalizedResource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).CanonicalizedResource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).PartitionKeyEnd = (string) content.GetValueForProperty("PartitionKeyEnd",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).PartitionKeyEnd, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).RowKeyEnd = (string) content.GetValueForProperty("RowKeyEnd",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).RowKeyEnd, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).KeyToSign = (string) content.GetValueForProperty("KeyToSign",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).KeyToSign, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).CacheControl = (string) content.GetValueForProperty("CacheControl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).CacheControl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentDisposition = (string) content.GetValueForProperty("ContentDisposition",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentDisposition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentEncoding = (string) content.GetValueForProperty("ContentEncoding",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentEncoding, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentLanguage = (string) content.GetValueForProperty("ContentLanguage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentLanguage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentType = (string) content.GetValueForProperty("ContentType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).ContentType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).SharedAccessExpiryTime = (global::System.DateTime?) content.GetValueForProperty("SharedAccessExpiryTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).SharedAccessExpiryTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Identifier = (string) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Identifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).IPAddressOrRange = (string) content.GetValueForProperty("IPAddressOrRange",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).IPAddressOrRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Permission = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions?) content.GetValueForProperty("Permission",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Permission, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Permissions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HttpProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Resource = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResource?) content.GetValueForProperty("Resource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).Resource, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SignedResource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).SharedAccessStartTime = (global::System.DateTime?) content.GetValueForProperty("SharedAccessStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).SharedAccessStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).PartitionKeyStart = (string) content.GetValueForProperty("PartitionKeyStart",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).PartitionKeyStart, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).RowKeyStart = (string) content.GetValueForProperty("RowKeyStart",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IServiceSasParametersInternal)this).RowKeyStart, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The parameters to list service SAS credentials of a specific resource.
    [System.ComponentModel.TypeConverter(typeof(ServiceSasParametersTypeConverter))]
    public partial interface IServiceSasParameters

    {

    }
}