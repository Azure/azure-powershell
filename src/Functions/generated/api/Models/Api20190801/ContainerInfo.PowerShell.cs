namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(ContainerInfoTypeConverter))]
    public partial class ContainerInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStat = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics) content.GetValueForProperty("CurrentCpuStat",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStat, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatisticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0 = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics) content.GetValueForProperty("Eth0",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerNetworkInterfaceStatisticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStat = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatistics) content.GetValueForProperty("MemoryStat",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStat, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerMemoryStatisticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStat = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics) content.GetValueForProperty("PreviousCpuStat",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStat, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatisticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentTimeStamp = (global::System.DateTime?) content.GetValueForProperty("CurrentTimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentTimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousTimeStamp = (global::System.DateTime?) content.GetValueForProperty("PreviousTimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousTimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxDropped = (long?) content.GetValueForProperty("Eth0TxDropped",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxDropped, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatCpuUsage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage) content.GetValueForProperty("CurrentCpuStatCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatCpuUsage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuUsageTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatOnlineCpuCount = (int?) content.GetValueForProperty("CurrentCpuStatOnlineCpuCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatOnlineCpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatSystemCpuUsage = (long?) content.GetValueForProperty("CurrentCpuStatSystemCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatSystemCpuUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatSystemCpuUsage = (long?) content.GetValueForProperty("PreviouCpuStatSystemCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatSystemCpuUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatOnlineCpuCount = (int?) content.GetValueForProperty("PreviouCpuStatOnlineCpuCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatOnlineCpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatThrottlingData = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData) content.GetValueForProperty("PreviouCpuStatThrottlingData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatThrottlingData, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerThrottlingDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatCpuUsage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage) content.GetValueForProperty("PreviouCpuStatCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatCpuUsage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuUsageTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatUsage = (long?) content.GetValueForProperty("MemoryStatUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatMaxUsage = (long?) content.GetValueForProperty("MemoryStatMaxUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatMaxUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatLimit = (long?) content.GetValueForProperty("MemoryStatLimit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatLimit, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxByte = (long?) content.GetValueForProperty("Eth0RxByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxDropped = (long?) content.GetValueForProperty("Eth0RxDropped",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxDropped, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxError = (long?) content.GetValueForProperty("Eth0RxError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxError, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxPacket = (long?) content.GetValueForProperty("Eth0RxPacket",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxPacket, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxByte = (long?) content.GetValueForProperty("Eth0TxByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatThrottlingData = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData) content.GetValueForProperty("CurrentCpuStatThrottlingData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatThrottlingData, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerThrottlingDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxError = (long?) content.GetValueForProperty("Eth0TxError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxError, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxPacket = (long?) content.GetValueForProperty("Eth0TxPacket",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxPacket, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageKernelModeUsage = (long?) content.GetValueForProperty("PreviousCpuStatsCpuUsageKernelModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageKernelModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataThrottledTime = (int?) content.GetValueForProperty("CurrentCpuStatsThrottlingDataThrottledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataThrottledTime, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataPeriod = (int?) content.GetValueForProperty("CurrentCpuStatsThrottlingDataPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageUserModeUsage = (long?) content.GetValueForProperty("CurrentCpuStatsCpuUsageUserModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageUserModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageTotalUsage = (long?) content.GetValueForProperty("CurrentCpuStatsCpuUsageTotalUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageTotalUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsagePerCpuUsage = (long[]) content.GetValueForProperty("CurrentCpuStatsCpuUsagePerCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsagePerCpuUsage, __y => TypeConverterExtensions.SelectToArray<long>(__y, (__w)=> (long) global::System.Convert.ChangeType(__w, typeof(long))));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageKernelModeUsage = (long?) content.GetValueForProperty("CurrentCpuStatsCpuUsageKernelModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageKernelModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataThrottledPeriod = (int?) content.GetValueForProperty("CurrentCpuStatsThrottlingDataThrottledPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataThrottledPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsagePerCpuUsage = (long[]) content.GetValueForProperty("PreviousCpuStatsCpuUsagePerCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsagePerCpuUsage, __y => TypeConverterExtensions.SelectToArray<long>(__y, (__w)=> (long) global::System.Convert.ChangeType(__w, typeof(long))));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageTotalUsage = (long?) content.GetValueForProperty("PreviousCpuStatsCpuUsageTotalUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageTotalUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageUserModeUsage = (long?) content.GetValueForProperty("PreviousCpuStatsCpuUsageUserModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageUserModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataPeriod = (int?) content.GetValueForProperty("PreviousCpuStatsThrottlingDataPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataThrottledPeriod = (int?) content.GetValueForProperty("PreviousCpuStatsThrottlingDataThrottledPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataThrottledPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataThrottledTime = (int?) content.GetValueForProperty("PreviousCpuStatsThrottlingDataThrottledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataThrottledTime, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStat = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics) content.GetValueForProperty("CurrentCpuStat",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStat, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatisticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0 = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics) content.GetValueForProperty("Eth0",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerNetworkInterfaceStatisticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStat = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerMemoryStatistics) content.GetValueForProperty("MemoryStat",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStat, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerMemoryStatisticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStat = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuStatistics) content.GetValueForProperty("PreviousCpuStat",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStat, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuStatisticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentTimeStamp = (global::System.DateTime?) content.GetValueForProperty("CurrentTimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentTimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousTimeStamp = (global::System.DateTime?) content.GetValueForProperty("PreviousTimeStamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousTimeStamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxDropped = (long?) content.GetValueForProperty("Eth0TxDropped",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxDropped, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatCpuUsage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage) content.GetValueForProperty("CurrentCpuStatCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatCpuUsage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuUsageTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatOnlineCpuCount = (int?) content.GetValueForProperty("CurrentCpuStatOnlineCpuCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatOnlineCpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatSystemCpuUsage = (long?) content.GetValueForProperty("CurrentCpuStatSystemCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatSystemCpuUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatSystemCpuUsage = (long?) content.GetValueForProperty("PreviouCpuStatSystemCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatSystemCpuUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatOnlineCpuCount = (int?) content.GetValueForProperty("PreviouCpuStatOnlineCpuCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatOnlineCpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatThrottlingData = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData) content.GetValueForProperty("PreviouCpuStatThrottlingData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatThrottlingData, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerThrottlingDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatCpuUsage = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerCpuUsage) content.GetValueForProperty("PreviouCpuStatCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviouCpuStatCpuUsage, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerCpuUsageTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatUsage = (long?) content.GetValueForProperty("MemoryStatUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatMaxUsage = (long?) content.GetValueForProperty("MemoryStatMaxUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatMaxUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatLimit = (long?) content.GetValueForProperty("MemoryStatLimit",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).MemoryStatLimit, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxByte = (long?) content.GetValueForProperty("Eth0RxByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxDropped = (long?) content.GetValueForProperty("Eth0RxDropped",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxDropped, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxError = (long?) content.GetValueForProperty("Eth0RxError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxError, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxPacket = (long?) content.GetValueForProperty("Eth0RxPacket",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0RxPacket, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxByte = (long?) content.GetValueForProperty("Eth0TxByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatThrottlingData = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerThrottlingData) content.GetValueForProperty("CurrentCpuStatThrottlingData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatThrottlingData, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerThrottlingDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxError = (long?) content.GetValueForProperty("Eth0TxError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxError, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxPacket = (long?) content.GetValueForProperty("Eth0TxPacket",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).Eth0TxPacket, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageKernelModeUsage = (long?) content.GetValueForProperty("PreviousCpuStatsCpuUsageKernelModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageKernelModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataThrottledTime = (int?) content.GetValueForProperty("CurrentCpuStatsThrottlingDataThrottledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataThrottledTime, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataPeriod = (int?) content.GetValueForProperty("CurrentCpuStatsThrottlingDataPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageUserModeUsage = (long?) content.GetValueForProperty("CurrentCpuStatsCpuUsageUserModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageUserModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageTotalUsage = (long?) content.GetValueForProperty("CurrentCpuStatsCpuUsageTotalUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageTotalUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsagePerCpuUsage = (long[]) content.GetValueForProperty("CurrentCpuStatsCpuUsagePerCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsagePerCpuUsage, __y => TypeConverterExtensions.SelectToArray<long>(__y, (__w)=> (long) global::System.Convert.ChangeType(__w, typeof(long))));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageKernelModeUsage = (long?) content.GetValueForProperty("CurrentCpuStatsCpuUsageKernelModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsCpuUsageKernelModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataThrottledPeriod = (int?) content.GetValueForProperty("CurrentCpuStatsThrottlingDataThrottledPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).CurrentCpuStatsThrottlingDataThrottledPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsagePerCpuUsage = (long[]) content.GetValueForProperty("PreviousCpuStatsCpuUsagePerCpuUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsagePerCpuUsage, __y => TypeConverterExtensions.SelectToArray<long>(__y, (__w)=> (long) global::System.Convert.ChangeType(__w, typeof(long))));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageTotalUsage = (long?) content.GetValueForProperty("PreviousCpuStatsCpuUsageTotalUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageTotalUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageUserModeUsage = (long?) content.GetValueForProperty("PreviousCpuStatsCpuUsageUserModeUsage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsCpuUsageUserModeUsage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataPeriod = (int?) content.GetValueForProperty("PreviousCpuStatsThrottlingDataPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataThrottledPeriod = (int?) content.GetValueForProperty("PreviousCpuStatsThrottlingDataThrottledPeriod",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataThrottledPeriod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataThrottledTime = (int?) content.GetValueForProperty("PreviousCpuStatsThrottlingDataThrottledTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfoInternal)this).PreviousCpuStatsThrottlingDataThrottledTime, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(ContainerInfoTypeConverter))]
    public partial interface IContainerInfo

    {

    }
}