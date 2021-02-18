namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Worker pool of an App Service Environment ARM resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(WorkerPoolResourceTypeConverter))]
    public partial class WorkerPoolResource
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WorkerPoolResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResource DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new WorkerPoolResource(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WorkerPoolResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResource DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new WorkerPoolResource(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="WorkerPoolResource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResource FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WorkerPoolResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal WorkerPoolResource(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WorkerPoolTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescriptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerSize = (string) content.GetValueForProperty("WorkerSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerCount = (int?) content.GetValueForProperty("WorkerCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).InstanceName = (string[]) content.GetValueForProperty("InstanceName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).InstanceName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerSizeId = (int?) content.GetValueForProperty("WorkerSizeId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerSizeId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).ComputeMode = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions?) content.GetValueForProperty("ComputeMode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).ComputeMode, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuLocation = (string[]) content.GetValueForProperty("SkuLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[]) content.GetValueForProperty("SkuCapability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityScaleType = (string) content.GetValueForProperty("SkuCapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityMinimum = (int?) content.GetValueForProperty("SkuCapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityMaximum = (int?) content.GetValueForProperty("SkuCapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityDefault = (int?) content.GetValueForProperty("SkuCapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WorkerPoolResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal WorkerPoolResource(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WorkerPoolTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescriptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerSize = (string) content.GetValueForProperty("WorkerSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerCount = (int?) content.GetValueForProperty("WorkerCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).InstanceName = (string[]) content.GetValueForProperty("InstanceName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).InstanceName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerSizeId = (int?) content.GetValueForProperty("WorkerSizeId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).WorkerSizeId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).ComputeMode = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions?) content.GetValueForProperty("ComputeMode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).ComputeMode, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuLocation = (string[]) content.GetValueForProperty("SkuLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[]) content.GetValueForProperty("SkuCapability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityScaleType = (string) content.GetValueForProperty("SkuCapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityMinimum = (int?) content.GetValueForProperty("SkuCapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityMaximum = (int?) content.GetValueForProperty("SkuCapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityDefault = (int?) content.GetValueForProperty("SkuCapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolResourceInternal)this).SkuCapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }
    }
    /// Worker pool of an App Service Environment ARM resource.
    [System.ComponentModel.TypeConverter(typeof(WorkerPoolResourceTypeConverter))]
    public partial interface IWorkerPoolResource

    {

    }
}