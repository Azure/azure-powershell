namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>
    /// The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(EndpointsTypeConverter))]
    public partial class Endpoints
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Endpoints"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Endpoints(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Endpoints"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Endpoints(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Endpoints"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Endpoints(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Blob = (string) content.GetValueForProperty("Blob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Blob, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Queue = (string) content.GetValueForProperty("Queue",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Queue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Table = (string) content.GetValueForProperty("Table",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Table, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).File = (string) content.GetValueForProperty("File",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).File, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Web = (string) content.GetValueForProperty("Web",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Web, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Df = (string) content.GetValueForProperty("Df",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Df, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Endpoints"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Endpoints(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Blob = (string) content.GetValueForProperty("Blob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Blob, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Queue = (string) content.GetValueForProperty("Queue",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Queue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Table = (string) content.GetValueForProperty("Table",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Table, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).File = (string) content.GetValueForProperty("File",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).File, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Web = (string) content.GetValueForProperty("Web",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Web, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Df = (string) content.GetValueForProperty("Df",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpointsInternal)this).Df, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Endpoints" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IEndpoints FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object.
    [System.ComponentModel.TypeConverter(typeof(EndpointsTypeConverter))]
    public partial interface IEndpoints

    {

    }
}