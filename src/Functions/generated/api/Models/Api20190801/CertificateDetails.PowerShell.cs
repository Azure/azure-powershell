namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>SSL certificate details.</summary>
    [System.ComponentModel.TypeConverter(typeof(CertificateDetailsTypeConverter))]
    public partial class CertificateDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CertificateDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Issuer = (string) content.GetValueForProperty("Issuer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Issuer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).NotAfter = (global::System.DateTime?) content.GetValueForProperty("NotAfter",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).NotAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).NotBefore = (global::System.DateTime?) content.GetValueForProperty("NotBefore",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).NotBefore, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).RawData = (string) content.GetValueForProperty("RawData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).RawData, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).SerialNumber = (string) content.GetValueForProperty("SerialNumber",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).SerialNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).SignatureAlgorithm = (string) content.GetValueForProperty("SignatureAlgorithm",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).SignatureAlgorithm, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Subject = (string) content.GetValueForProperty("Subject",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Subject, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Thumbprint = (string) content.GetValueForProperty("Thumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Thumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Version = (int?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Version, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CertificateDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Issuer = (string) content.GetValueForProperty("Issuer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Issuer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).NotAfter = (global::System.DateTime?) content.GetValueForProperty("NotAfter",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).NotAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).NotBefore = (global::System.DateTime?) content.GetValueForProperty("NotBefore",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).NotBefore, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).RawData = (string) content.GetValueForProperty("RawData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).RawData, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).SerialNumber = (string) content.GetValueForProperty("SerialNumber",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).SerialNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).SignatureAlgorithm = (string) content.GetValueForProperty("SignatureAlgorithm",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).SignatureAlgorithm, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Subject = (string) content.GetValueForProperty("Subject",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Subject, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Thumbprint = (string) content.GetValueForProperty("Thumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Thumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Version = (int?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)this).Version, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CertificateDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CertificateDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CertificateDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// SSL certificate details.
    [System.ComponentModel.TypeConverter(typeof(CertificateDetailsTypeConverter))]
    public partial interface ICertificateDetails

    {

    }
}