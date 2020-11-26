namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Details of the Process Server.</summary>
    [System.ComponentModel.TypeConverter(typeof(ProcessServerTypeConverter))]
    public partial class ProcessServer
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProcessServer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ProcessServer(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProcessServer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ProcessServer(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ProcessServer" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProcessServer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ProcessServer(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails) content.GetValueForProperty("AgentVersionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).OSType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).LastHeartbeat = (global::System.DateTime?) content.GetValueForProperty("LastHeartbeat",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).LastHeartbeat, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).VersionStatus = (string) content.GetValueForProperty("VersionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).VersionStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MobilityServiceUpdate = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdate[]) content.GetValueForProperty("MobilityServiceUpdate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MobilityServiceUpdate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdate>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MobilityServiceUpdateTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).HostId = (string) content.GetValueForProperty("HostId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).HostId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MachineCount = (string) content.GetValueForProperty("MachineCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MachineCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).ReplicationPairCount = (string) content.GetValueForProperty("ReplicationPairCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).ReplicationPairCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SystemLoad = (string) content.GetValueForProperty("SystemLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SystemLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SystemLoadStatus = (string) content.GetValueForProperty("SystemLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SystemLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).CpuLoad = (string) content.GetValueForProperty("CpuLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).CpuLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).CpuLoadStatus = (string) content.GetValueForProperty("CpuLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).CpuLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).TotalMemoryInByte = (long?) content.GetValueForProperty("TotalMemoryInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).TotalMemoryInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AvailableMemoryInByte = (long?) content.GetValueForProperty("AvailableMemoryInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AvailableMemoryInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MemoryUsageStatus = (string) content.GetValueForProperty("MemoryUsageStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MemoryUsageStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).TotalSpaceInByte = (long?) content.GetValueForProperty("TotalSpaceInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).TotalSpaceInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AvailableSpaceInByte = (long?) content.GetValueForProperty("AvailableSpaceInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AvailableSpaceInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SpaceUsageStatus = (string) content.GetValueForProperty("SpaceUsageStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SpaceUsageStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).PsServiceStatus = (string) content.GetValueForProperty("PsServiceStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).PsServiceStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SslCertExpiryDate = (global::System.DateTime?) content.GetValueForProperty("SslCertExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SslCertExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SslCertExpiryRemainingDay = (int?) content.GetValueForProperty("SslCertExpiryRemainingDay",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SslCertExpiryRemainingDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).OSVersion = (string) content.GetValueForProperty("OSVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).OSVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailVersion = (string) content.GetValueForProperty("AgentVersionDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentVersionDetailExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailStatus = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus?) content.GetValueForProperty("AgentVersionDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailStatus, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProcessServer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ProcessServer(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails) content.GetValueForProperty("AgentVersionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).OSType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).LastHeartbeat = (global::System.DateTime?) content.GetValueForProperty("LastHeartbeat",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).LastHeartbeat, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).VersionStatus = (string) content.GetValueForProperty("VersionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).VersionStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MobilityServiceUpdate = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdate[]) content.GetValueForProperty("MobilityServiceUpdate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MobilityServiceUpdate, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdate>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MobilityServiceUpdateTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).HostId = (string) content.GetValueForProperty("HostId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).HostId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MachineCount = (string) content.GetValueForProperty("MachineCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MachineCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).ReplicationPairCount = (string) content.GetValueForProperty("ReplicationPairCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).ReplicationPairCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SystemLoad = (string) content.GetValueForProperty("SystemLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SystemLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SystemLoadStatus = (string) content.GetValueForProperty("SystemLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SystemLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).CpuLoad = (string) content.GetValueForProperty("CpuLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).CpuLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).CpuLoadStatus = (string) content.GetValueForProperty("CpuLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).CpuLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).TotalMemoryInByte = (long?) content.GetValueForProperty("TotalMemoryInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).TotalMemoryInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AvailableMemoryInByte = (long?) content.GetValueForProperty("AvailableMemoryInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AvailableMemoryInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MemoryUsageStatus = (string) content.GetValueForProperty("MemoryUsageStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).MemoryUsageStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).TotalSpaceInByte = (long?) content.GetValueForProperty("TotalSpaceInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).TotalSpaceInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AvailableSpaceInByte = (long?) content.GetValueForProperty("AvailableSpaceInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AvailableSpaceInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SpaceUsageStatus = (string) content.GetValueForProperty("SpaceUsageStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SpaceUsageStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).PsServiceStatus = (string) content.GetValueForProperty("PsServiceStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).PsServiceStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SslCertExpiryDate = (global::System.DateTime?) content.GetValueForProperty("SslCertExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SslCertExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SslCertExpiryRemainingDay = (int?) content.GetValueForProperty("SslCertExpiryRemainingDay",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).SslCertExpiryRemainingDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).OSVersion = (string) content.GetValueForProperty("OSVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).OSVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailVersion = (string) content.GetValueForProperty("AgentVersionDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentVersionDetailExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailStatus = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus?) content.GetValueForProperty("AgentVersionDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServerInternal)this).AgentVersionDetailStatus, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Details of the Process Server.
    [System.ComponentModel.TypeConverter(typeof(ProcessServerTypeConverter))]
    public partial interface IProcessServer

    {

    }
}