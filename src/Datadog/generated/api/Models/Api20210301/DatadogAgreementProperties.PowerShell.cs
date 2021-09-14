namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.PowerShell;

    /// <summary>Terms properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(DatadogAgreementPropertiesTypeConverter))]
    public partial class DatadogAgreementProperties
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
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogAgreementProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DatadogAgreementProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Publisher = (string) content.GetValueForProperty("Publisher",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Publisher, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Product = (string) content.GetValueForProperty("Product",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Product, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Plan = (string) content.GetValueForProperty("Plan",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Plan, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).LicenseTextLink = (string) content.GetValueForProperty("LicenseTextLink",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).LicenseTextLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).PrivacyPolicyLink = (string) content.GetValueForProperty("PrivacyPolicyLink",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).PrivacyPolicyLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).RetrieveDatetime = (global::System.DateTime?) content.GetValueForProperty("RetrieveDatetime",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).RetrieveDatetime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Signature = (string) content.GetValueForProperty("Signature",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Signature, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Accepted = (bool?) content.GetValueForProperty("Accepted",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Accepted, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogAgreementProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DatadogAgreementProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Publisher = (string) content.GetValueForProperty("Publisher",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Publisher, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Product = (string) content.GetValueForProperty("Product",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Product, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Plan = (string) content.GetValueForProperty("Plan",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Plan, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).LicenseTextLink = (string) content.GetValueForProperty("LicenseTextLink",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).LicenseTextLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).PrivacyPolicyLink = (string) content.GetValueForProperty("PrivacyPolicyLink",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).PrivacyPolicyLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).RetrieveDatetime = (global::System.DateTime?) content.GetValueForProperty("RetrieveDatetime",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).RetrieveDatetime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Signature = (string) content.GetValueForProperty("Signature",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Signature, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Accepted = (bool?) content.GetValueForProperty("Accepted",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementPropertiesInternal)this).Accepted, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogAgreementProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DatadogAgreementProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogAgreementProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DatadogAgreementProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DatadogAgreementProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogAgreementProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// Terms properties.
    [System.ComponentModel.TypeConverter(typeof(DatadogAgreementPropertiesTypeConverter))]
    public partial interface IDatadogAgreementProperties

    {

    }
}