namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Details of a Master Target Server.</summary>
    [System.ComponentModel.TypeConverter(typeof(MasterTargetServerTypeConverter))]
    public partial class MasterTargetServer
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MasterTargetServer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MasterTargetServer(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MasterTargetServer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MasterTargetServer(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MasterTargetServer" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MasterTargetServer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MasterTargetServer(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails) content.GetValueForProperty("AgentVersionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentVersionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails) content.GetValueForProperty("MarsAgentVersionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentVersionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).OSType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).LastHeartbeat = (global::System.DateTime?) content.GetValueForProperty("LastHeartbeat",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).LastHeartbeat, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).VersionStatus = (string) content.GetValueForProperty("VersionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).VersionStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).RetentionVolume = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolume[]) content.GetValueForProperty("RetentionVolume",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).RetentionVolume, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolume>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RetentionVolumeTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).DataStore = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStore[]) content.GetValueForProperty("DataStore",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).DataStore, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStore>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DataStoreTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).ValidationError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("ValidationError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).ValidationError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).DiskCount = (int?) content.GetValueForProperty("DiskCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).DiskCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).OSVersion = (string) content.GetValueForProperty("OSVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).OSVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentVersion = (string) content.GetValueForProperty("MarsAgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentExpiryDate = (global::System.DateTime?) content.GetValueForProperty("MarsAgentExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailVersion = (string) content.GetValueForProperty("AgentVersionDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentVersionDetailExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailStatus = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus?) content.GetValueForProperty("AgentVersionDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailStatus, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailVersion = (string) content.GetValueForProperty("MarAgentVersionDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailExpiryDate = (global::System.DateTime?) content.GetValueForProperty("MarAgentVersionDetailExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailStatus = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus?) content.GetValueForProperty("MarAgentVersionDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailStatus, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MasterTargetServer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MasterTargetServer(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails) content.GetValueForProperty("AgentVersionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentVersionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails) content.GetValueForProperty("MarsAgentVersionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentVersionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).OSType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).LastHeartbeat = (global::System.DateTime?) content.GetValueForProperty("LastHeartbeat",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).LastHeartbeat, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).VersionStatus = (string) content.GetValueForProperty("VersionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).VersionStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).RetentionVolume = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolume[]) content.GetValueForProperty("RetentionVolume",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).RetentionVolume, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRetentionVolume>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RetentionVolumeTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).DataStore = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStore[]) content.GetValueForProperty("DataStore",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).DataStore, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStore>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DataStoreTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).ValidationError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("ValidationError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).ValidationError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).DiskCount = (int?) content.GetValueForProperty("DiskCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).DiskCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).OSVersion = (string) content.GetValueForProperty("OSVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).OSVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentVersion = (string) content.GetValueForProperty("MarsAgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentExpiryDate = (global::System.DateTime?) content.GetValueForProperty("MarsAgentExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarsAgentExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailVersion = (string) content.GetValueForProperty("AgentVersionDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentVersionDetailExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailStatus = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus?) content.GetValueForProperty("AgentVersionDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).AgentVersionDetailStatus, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailVersion = (string) content.GetValueForProperty("MarAgentVersionDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailExpiryDate = (global::System.DateTime?) content.GetValueForProperty("MarAgentVersionDetailExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailStatus = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus?) content.GetValueForProperty("MarAgentVersionDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServerInternal)this).MarAgentVersionDetailStatus, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Details of a Master Target Server.
    [System.ComponentModel.TypeConverter(typeof(MasterTargetServerTypeConverter))]
    public partial interface IMasterTargetServer

    {

    }
}