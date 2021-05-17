namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell;

    /// <summary>The resource requirements.</summary>
    [System.ComponentModel.TypeConverter(typeof(ResourceRequirementsTypeConverter))]
    public partial class ResourceRequirements
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequirements"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirements"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirements DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ResourceRequirements(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequirements"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirements"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirements DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ResourceRequirements(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ResourceRequirements" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirements FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequirements"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ResourceRequirements(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).Request = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests) content.GetValueForProperty("Request",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).Request, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequestsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).Limit = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimits) content.GetValueForProperty("Limit",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).Limit, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceLimitsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestGpu = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource) content.GetValueForProperty("RequestGpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestGpu, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.GpuResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestMemoryInGb = (double) content.GetValueForProperty("RequestMemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestMemoryInGb, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestCpu = (double) content.GetValueForProperty("RequestCpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestCpu, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestsGpuSku = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) content.GetValueForProperty("RequestsGpuSku",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestsGpuSku, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitGpu = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource) content.GetValueForProperty("LimitGpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitGpu, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.GpuResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitMemoryInGb = (double?) content.GetValueForProperty("LimitMemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitMemoryInGb, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitCpu = (double?) content.GetValueForProperty("LimitCpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitCpu, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitsGpuSku = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) content.GetValueForProperty("LimitsGpuSku",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitsGpuSku, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestsGpuCount = (int) content.GetValueForProperty("RequestsGpuCount",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestsGpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitsGpuCount = (int) content.GetValueForProperty("LimitsGpuCount",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitsGpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequirements"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ResourceRequirements(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).Request = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequests) content.GetValueForProperty("Request",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).Request, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceRequestsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).Limit = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceLimits) content.GetValueForProperty("Limit",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).Limit, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceLimitsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestGpu = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource) content.GetValueForProperty("RequestGpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestGpu, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.GpuResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestMemoryInGb = (double) content.GetValueForProperty("RequestMemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestMemoryInGb, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestCpu = (double) content.GetValueForProperty("RequestCpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestCpu, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestsGpuSku = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) content.GetValueForProperty("RequestsGpuSku",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestsGpuSku, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitGpu = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IGpuResource) content.GetValueForProperty("LimitGpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitGpu, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.GpuResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitMemoryInGb = (double?) content.GetValueForProperty("LimitMemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitMemoryInGb, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitCpu = (double?) content.GetValueForProperty("LimitCpu",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitCpu, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitsGpuSku = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku) content.GetValueForProperty("LimitsGpuSku",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitsGpuSku, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestsGpuCount = (int) content.GetValueForProperty("RequestsGpuCount",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).RequestsGpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitsGpuCount = (int) content.GetValueForProperty("LimitsGpuCount",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceRequirementsInternal)this).LimitsGpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
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
    /// The resource requirements.
    [System.ComponentModel.TypeConverter(typeof(ResourceRequirementsTypeConverter))]
    public partial interface IResourceRequirements

    {

    }
}