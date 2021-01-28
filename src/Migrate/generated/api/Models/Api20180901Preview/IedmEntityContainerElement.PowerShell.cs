namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(IedmEntityContainerElementTypeConverter))]
    public partial class IedmEntityContainerElement
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmEntityContainerElement"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElement"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElement DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new IedmEntityContainerElement(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmEntityContainerElement"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElement"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElement DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new IedmEntityContainerElement(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="IedmEntityContainerElement" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElement FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmEntityContainerElement"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal IedmEntityContainerElement(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).Container = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainer) content.GetValueForProperty("Container",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).Container, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmEntityContainerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerElementKind = (string) content.GetValueForProperty("ContainerElementKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerElementKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerElement = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElement[]) content.GetValueForProperty("ContainerElement",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerElement, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElement>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmEntityContainerElementTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerSchemaElementKind = (string) content.GetValueForProperty("ContainerSchemaElementKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerSchemaElementKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerNamespace = (string) content.GetValueForProperty("ContainerNamespace",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerNamespace, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerName = (string) content.GetValueForProperty("ContainerName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmEntityContainerElement"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal IedmEntityContainerElement(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).Container = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainer) content.GetValueForProperty("Container",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).Container, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmEntityContainerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerElementKind = (string) content.GetValueForProperty("ContainerElementKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerElementKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerElement = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElement[]) content.GetValueForProperty("ContainerElement",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerElement, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElement>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmEntityContainerElementTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerSchemaElementKind = (string) content.GetValueForProperty("ContainerSchemaElementKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerSchemaElementKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerNamespace = (string) content.GetValueForProperty("ContainerNamespace",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerNamespace, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerName = (string) content.GetValueForProperty("ContainerName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmEntityContainerElementInternal)this).ContainerName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(IedmEntityContainerElementTypeConverter))]
    public partial interface IIedmEntityContainerElement

    {

    }
}