namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Store the fabric details specific to the VMware fabric.</summary>
    [System.ComponentModel.TypeConverter(typeof(VMwareDetailsTypeConverter))]
    public partial class VMwareDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VMwareDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VMwareDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VMwareDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VMwareDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails) content.GetValueForProperty("AgentVersionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProcessServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer[]) content.GetValueForProperty("ProcessServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProcessServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProcessServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).MasterTargetServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer[]) content.GetValueForProperty("MasterTargetServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).MasterTargetServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MasterTargetServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).RunAsAccount = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount[]) content.GetValueForProperty("RunAsAccount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).RunAsAccount, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RunAsAccountTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ReplicationPairCount = (string) content.GetValueForProperty("ReplicationPairCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ReplicationPairCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProcessServerCount = (string) content.GetValueForProperty("ProcessServerCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProcessServerCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentCount = (string) content.GetValueForProperty("AgentCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProtectedServer = (string) content.GetValueForProperty("ProtectedServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProtectedServer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SystemLoad = (string) content.GetValueForProperty("SystemLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SystemLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SystemLoadStatus = (string) content.GetValueForProperty("SystemLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SystemLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CpuLoad = (string) content.GetValueForProperty("CpuLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CpuLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CpuLoadStatus = (string) content.GetValueForProperty("CpuLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CpuLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).TotalMemoryInByte = (long?) content.GetValueForProperty("TotalMemoryInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).TotalMemoryInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AvailableMemoryInByte = (long?) content.GetValueForProperty("AvailableMemoryInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AvailableMemoryInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).MemoryUsageStatus = (string) content.GetValueForProperty("MemoryUsageStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).MemoryUsageStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).TotalSpaceInByte = (long?) content.GetValueForProperty("TotalSpaceInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).TotalSpaceInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AvailableSpaceInByte = (long?) content.GetValueForProperty("AvailableSpaceInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AvailableSpaceInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SpaceUsageStatus = (string) content.GetValueForProperty("SpaceUsageStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SpaceUsageStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).WebLoad = (string) content.GetValueForProperty("WebLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).WebLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).WebLoadStatus = (string) content.GetValueForProperty("WebLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).WebLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).DatabaseServerLoad = (string) content.GetValueForProperty("DatabaseServerLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).DatabaseServerLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).DatabaseServerLoadStatus = (string) content.GetValueForProperty("DatabaseServerLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).DatabaseServerLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CsServiceStatus = (string) content.GetValueForProperty("CsServiceStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CsServiceStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).HostName = (string) content.GetValueForProperty("HostName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).HostName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).LastHeartbeat = (global::System.DateTime?) content.GetValueForProperty("LastHeartbeat",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).LastHeartbeat, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).VersionStatus = (string) content.GetValueForProperty("VersionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).VersionStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SslCertExpiryDate = (global::System.DateTime?) content.GetValueForProperty("SslCertExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SslCertExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SslCertExpiryRemainingDay = (int?) content.GetValueForProperty("SslCertExpiryRemainingDay",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SslCertExpiryRemainingDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).PsTemplateVersion = (string) content.GetValueForProperty("PsTemplateVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).PsTemplateVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailVersion = (string) content.GetValueForProperty("AgentVersionDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentVersionDetailExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailStatus = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus?) content.GetValueForProperty("AgentVersionDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailStatus, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VMwareDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails) content.GetValueForProperty("AgentVersionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProcessServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer[]) content.GetValueForProperty("ProcessServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProcessServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProcessServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).MasterTargetServer = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer[]) content.GetValueForProperty("MasterTargetServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).MasterTargetServer, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MasterTargetServerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).RunAsAccount = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount[]) content.GetValueForProperty("RunAsAccount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).RunAsAccount, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RunAsAccountTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ReplicationPairCount = (string) content.GetValueForProperty("ReplicationPairCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ReplicationPairCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProcessServerCount = (string) content.GetValueForProperty("ProcessServerCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProcessServerCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentCount = (string) content.GetValueForProperty("AgentCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProtectedServer = (string) content.GetValueForProperty("ProtectedServer",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).ProtectedServer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SystemLoad = (string) content.GetValueForProperty("SystemLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SystemLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SystemLoadStatus = (string) content.GetValueForProperty("SystemLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SystemLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CpuLoad = (string) content.GetValueForProperty("CpuLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CpuLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CpuLoadStatus = (string) content.GetValueForProperty("CpuLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CpuLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).TotalMemoryInByte = (long?) content.GetValueForProperty("TotalMemoryInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).TotalMemoryInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AvailableMemoryInByte = (long?) content.GetValueForProperty("AvailableMemoryInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AvailableMemoryInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).MemoryUsageStatus = (string) content.GetValueForProperty("MemoryUsageStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).MemoryUsageStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).TotalSpaceInByte = (long?) content.GetValueForProperty("TotalSpaceInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).TotalSpaceInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AvailableSpaceInByte = (long?) content.GetValueForProperty("AvailableSpaceInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AvailableSpaceInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SpaceUsageStatus = (string) content.GetValueForProperty("SpaceUsageStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SpaceUsageStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).WebLoad = (string) content.GetValueForProperty("WebLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).WebLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).WebLoadStatus = (string) content.GetValueForProperty("WebLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).WebLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).DatabaseServerLoad = (string) content.GetValueForProperty("DatabaseServerLoad",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).DatabaseServerLoad, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).DatabaseServerLoadStatus = (string) content.GetValueForProperty("DatabaseServerLoadStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).DatabaseServerLoadStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CsServiceStatus = (string) content.GetValueForProperty("CsServiceStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).CsServiceStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).HostName = (string) content.GetValueForProperty("HostName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).HostName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).LastHeartbeat = (global::System.DateTime?) content.GetValueForProperty("LastHeartbeat",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).LastHeartbeat, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).VersionStatus = (string) content.GetValueForProperty("VersionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).VersionStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SslCertExpiryDate = (global::System.DateTime?) content.GetValueForProperty("SslCertExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SslCertExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SslCertExpiryRemainingDay = (int?) content.GetValueForProperty("SslCertExpiryRemainingDay",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).SslCertExpiryRemainingDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).PsTemplateVersion = (string) content.GetValueForProperty("PsTemplateVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).PsTemplateVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailVersion = (string) content.GetValueForProperty("AgentVersionDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentVersionDetailExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailStatus = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus?) content.GetValueForProperty("AgentVersionDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetailsInternal)this).AgentVersionDetailStatus, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus.CreateFrom);
            AfterDeserializePSObject(content);
        }
    }
    /// Store the fabric details specific to the VMware fabric.
    [System.ComponentModel.TypeConverter(typeof(VMwareDetailsTypeConverter))]
    public partial interface IVMwareDetails

    {

    }
}