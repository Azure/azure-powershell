namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>Elements class for feature request</summary>
    [System.ComponentModel.TypeConverter(typeof(SupportedFeatureTypeConverter))]
    public partial class SupportedFeature
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.SupportedFeature"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeature"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeature DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SupportedFeature(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.SupportedFeature"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeature"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeature DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SupportedFeature(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SupportedFeature" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeature FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.SupportedFeature"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SupportedFeature(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).FeatureName = (string) content.GetValueForProperty("FeatureName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).FeatureName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).SupportStatus = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureSupportStatus?) content.GetValueForProperty("SupportStatus",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).SupportStatus, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureSupportStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).ExposureControlledFeature = (string[]) content.GetValueForProperty("ExposureControlledFeature",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).ExposureControlledFeature, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.SupportedFeature"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SupportedFeature(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).FeatureName = (string) content.GetValueForProperty("FeatureName",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).FeatureName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).SupportStatus = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureSupportStatus?) content.GetValueForProperty("SupportStatus",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).SupportStatus, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.FeatureSupportStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).ExposureControlledFeature = (string[]) content.GetValueForProperty("ExposureControlledFeature",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ISupportedFeatureInternal)this).ExposureControlledFeature, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Elements class for feature request
    [System.ComponentModel.TypeConverter(typeof(SupportedFeatureTypeConverter))]
    public partial interface ISupportedFeature

    {

    }
}