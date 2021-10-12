namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell;

    /// <summary>The resource requests.</summary>
    [System.ComponentModel.TypeConverter(typeof(ResourceRequestsTypeConverter))]
    public partial class ResourceRequests
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequests"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ResourceRequests(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequests"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ResourceRequests(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ResourceRequests" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequests"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ResourceRequests(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).Gpu = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource) content.GetValueForProperty("Gpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).Gpu, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.GpuResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).MemoryInGb = (double) content.GetValueForProperty("MemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).MemoryInGb, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).Cpu = (double) content.GetValueForProperty("Cpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).Cpu, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).GpuSku = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) content.GetValueForProperty("GpuSku",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).GpuSku, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).GpuCount = (int) content.GetValueForProperty("GpuCount",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).GpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequests"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ResourceRequests(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).Gpu = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource) content.GetValueForProperty("Gpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).Gpu, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.GpuResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).MemoryInGb = (double) content.GetValueForProperty("MemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).MemoryInGb, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).Cpu = (double) content.GetValueForProperty("Cpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).Cpu, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).GpuSku = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) content.GetValueForProperty("GpuSku",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).GpuSku, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).GpuCount = (int) content.GetValueForProperty("GpuCount",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequestsInternal)this).GpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// The resource requests.
    [System.ComponentModel.TypeConverter(typeof(ResourceRequestsTypeConverter))]
    public partial interface IResourceRequests

    {

    }
}