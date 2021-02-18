namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Binding resource properties payload</summary>
    [System.ComponentModel.TypeConverter(typeof(BindingResourcePropertiesTypeConverter))]
    public partial class BindingResourceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.BindingResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BindingResourceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceName = (string) content.GetValueForProperty("ResourceName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceType = (string) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).Key = (string) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).Key, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).BindingParameter = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesBindingParameters) content.GetValueForProperty("BindingParameter",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).BindingParameter, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.BindingResourcePropertiesBindingParametersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).GeneratedProperty = (string) content.GetValueForProperty("GeneratedProperty",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).GeneratedProperty, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).CreatedAt = (string) content.GetValueForProperty("CreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).CreatedAt, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).UpdatedAt = (string) content.GetValueForProperty("UpdatedAt",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).UpdatedAt, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.BindingResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BindingResourceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceName = (string) content.GetValueForProperty("ResourceName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceType = (string) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).ResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).Key = (string) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).Key, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).BindingParameter = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesBindingParameters) content.GetValueForProperty("BindingParameter",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).BindingParameter, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.BindingResourcePropertiesBindingParametersTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).GeneratedProperty = (string) content.GetValueForProperty("GeneratedProperty",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).GeneratedProperty, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).CreatedAt = (string) content.GetValueForProperty("CreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).CreatedAt, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).UpdatedAt = (string) content.GetValueForProperty("UpdatedAt",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourcePropertiesInternal)this).UpdatedAt, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.BindingResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BindingResourceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.BindingResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BindingResourceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BindingResourceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IBindingResourceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Binding resource properties payload
    [System.ComponentModel.TypeConverter(typeof(BindingResourcePropertiesTypeConverter))]
    public partial interface IBindingResourceProperties

    {

    }
}