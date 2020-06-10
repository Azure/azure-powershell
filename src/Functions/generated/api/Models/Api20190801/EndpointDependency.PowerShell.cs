namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>
    /// A domain name that a service is reached at, including details of the current connection status.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(EndpointDependencyTypeConverter))]
    public partial class EndpointDependency
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EndpointDependency"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependency" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependency DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EndpointDependency(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EndpointDependency"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependency" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependency DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EndpointDependency(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EndpointDependency"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EndpointDependency(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependencyInternal)this).DomainName = (string) content.GetValueForProperty("DomainName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependencyInternal)this).DomainName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependencyInternal)this).EndpointDetail = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDetail[]) content.GetValueForProperty("EndpointDetail",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependencyInternal)this).EndpointDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EndpointDetailTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EndpointDependency"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EndpointDependency(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependencyInternal)this).DomainName = (string) content.GetValueForProperty("DomainName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependencyInternal)this).DomainName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependencyInternal)this).EndpointDetail = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDetail[]) content.GetValueForProperty("EndpointDetail",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependencyInternal)this).EndpointDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.EndpointDetailTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EndpointDependency" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependency FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A domain name that a service is reached at, including details of the current connection status.
    [System.ComponentModel.TypeConverter(typeof(EndpointDependencyTypeConverter))]
    public partial interface IEndpointDependency

    {

    }
}