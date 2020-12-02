namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Stamp capacity information.</summary>
    [System.ComponentModel.TypeConverter(typeof(StampCapacityTypeConverter))]
    public partial class StampCapacity
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StampCapacity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new StampCapacity(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StampCapacity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new StampCapacity(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="StampCapacity" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StampCapacity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal StampCapacity(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).AvailableCapacity = (long?) content.GetValueForProperty("AvailableCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).AvailableCapacity, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).TotalCapacity = (long?) content.GetValueForProperty("TotalCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).TotalCapacity, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).Unit = (string) content.GetValueForProperty("Unit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).Unit, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).ComputeMode = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions?) content.GetValueForProperty("ComputeMode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).ComputeMode, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).WorkerSize = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerSizeOptions?) content.GetValueForProperty("WorkerSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).WorkerSize, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerSizeOptions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).WorkerSizeId = (int?) content.GetValueForProperty("WorkerSizeId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).WorkerSizeId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).ExcludeFromCapacityAllocation = (bool?) content.GetValueForProperty("ExcludeFromCapacityAllocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).ExcludeFromCapacityAllocation, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).IsApplicableForAllComputeMode = (bool?) content.GetValueForProperty("IsApplicableForAllComputeMode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).IsApplicableForAllComputeMode, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).SiteMode = (string) content.GetValueForProperty("SiteMode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).SiteMode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).IsLinux = (bool?) content.GetValueForProperty("IsLinux",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).IsLinux, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StampCapacity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal StampCapacity(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).AvailableCapacity = (long?) content.GetValueForProperty("AvailableCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).AvailableCapacity, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).TotalCapacity = (long?) content.GetValueForProperty("TotalCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).TotalCapacity, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).Unit = (string) content.GetValueForProperty("Unit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).Unit, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).ComputeMode = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions?) content.GetValueForProperty("ComputeMode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).ComputeMode, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).WorkerSize = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerSizeOptions?) content.GetValueForProperty("WorkerSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).WorkerSize, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerSizeOptions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).WorkerSizeId = (int?) content.GetValueForProperty("WorkerSizeId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).WorkerSizeId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).ExcludeFromCapacityAllocation = (bool?) content.GetValueForProperty("ExcludeFromCapacityAllocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).ExcludeFromCapacityAllocation, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).IsApplicableForAllComputeMode = (bool?) content.GetValueForProperty("IsApplicableForAllComputeMode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).IsApplicableForAllComputeMode, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).SiteMode = (string) content.GetValueForProperty("SiteMode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).SiteMode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).IsLinux = (bool?) content.GetValueForProperty("IsLinux",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityInternal)this).IsLinux, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Stamp capacity information.
    [System.ComponentModel.TypeConverter(typeof(StampCapacityTypeConverter))]
    public partial interface IStampCapacity

    {

    }
}