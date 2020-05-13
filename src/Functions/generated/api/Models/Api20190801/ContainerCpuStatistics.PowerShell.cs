namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(ContainerCpuStatisticsTypeConverter))]
    public partial class ContainerCpuStatistics
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatistics"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerCpuStatistics(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage) content.GetValueForProperty("CpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuUsageTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingData = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData) content.GetValueForProperty("ThrottlingData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingData, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerThrottlingDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).OnlineCpuCount = (int?) content.GetValueForProperty("OnlineCpuCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).OnlineCpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).SystemCpuUsage = (long?) content.GetValueForProperty("SystemCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).SystemCpuUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageKernelModeUsage = (long?) content.GetValueForProperty("CpuUsageKernelModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageKernelModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsagePerCpuUsage = (long[]) content.GetValueForProperty("CpuUsagePerCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsagePerCpuUsage, __y => TypeConverterExtensions.SelectToArray<long>(__y, (__w)=> (long) global::System.Convert.ChangeType(__w, typeof(long))));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageTotalUsage = (long?) content.GetValueForProperty("CpuUsageTotalUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageTotalUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageUserModeUsage = (long?) content.GetValueForProperty("CpuUsageUserModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageUserModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataPeriod = (int?) content.GetValueForProperty("ThrottlingDataPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataThrottledPeriod = (int?) content.GetValueForProperty("ThrottlingDataThrottledPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataThrottledPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataThrottledTime = (int?) content.GetValueForProperty("ThrottlingDataThrottledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataThrottledTime, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatistics"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerCpuStatistics(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage) content.GetValueForProperty("CpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuUsageTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingData = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData) content.GetValueForProperty("ThrottlingData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingData, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerThrottlingDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).OnlineCpuCount = (int?) content.GetValueForProperty("OnlineCpuCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).OnlineCpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).SystemCpuUsage = (long?) content.GetValueForProperty("SystemCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).SystemCpuUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageKernelModeUsage = (long?) content.GetValueForProperty("CpuUsageKernelModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageKernelModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsagePerCpuUsage = (long[]) content.GetValueForProperty("CpuUsagePerCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsagePerCpuUsage, __y => TypeConverterExtensions.SelectToArray<long>(__y, (__w)=> (long) global::System.Convert.ChangeType(__w, typeof(long))));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageTotalUsage = (long?) content.GetValueForProperty("CpuUsageTotalUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageTotalUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageUserModeUsage = (long?) content.GetValueForProperty("CpuUsageUserModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).CpuUsageUserModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataPeriod = (int?) content.GetValueForProperty("ThrottlingDataPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataThrottledPeriod = (int?) content.GetValueForProperty("ThrottlingDataThrottledPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataThrottledPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataThrottledTime = (int?) content.GetValueForProperty("ThrottlingDataThrottledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatisticsInternal)this).ThrottlingDataThrottledTime, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatistics"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerCpuStatistics(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatistics"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerCpuStatistics(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerCpuStatistics" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(ContainerCpuStatisticsTypeConverter))]
    public partial interface IContainerCpuStatistics

    {

    }
}