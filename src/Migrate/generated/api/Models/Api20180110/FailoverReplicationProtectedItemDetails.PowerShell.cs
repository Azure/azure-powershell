namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Failover details for a replication protected item.</summary>
    [System.ComponentModel.TypeConverter(typeof(FailoverReplicationProtectedItemDetailsTypeConverter))]
    public partial class FailoverReplicationProtectedItemDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FailoverReplicationProtectedItemDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FailoverReplicationProtectedItemDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FailoverReplicationProtectedItemDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FailoverReplicationProtectedItemDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FailoverReplicationProtectedItemDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FailoverReplicationProtectedItemDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).TestVMName = (string) content.GetValueForProperty("TestVMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).TestVMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).TestVMFriendlyName = (string) content.GetValueForProperty("TestVMFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).TestVMFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).NetworkConnectionStatus = (string) content.GetValueForProperty("NetworkConnectionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).NetworkConnectionStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).NetworkFriendlyName = (string) content.GetValueForProperty("NetworkFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).NetworkFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).Subnet = (string) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).Subnet, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).RecoveryPointId = (string) content.GetValueForProperty("RecoveryPointId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).RecoveryPointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).RecoveryPointTime = (global::System.DateTime?) content.GetValueForProperty("RecoveryPointTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).RecoveryPointTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FailoverReplicationProtectedItemDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FailoverReplicationProtectedItemDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).TestVMName = (string) content.GetValueForProperty("TestVMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).TestVMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).TestVMFriendlyName = (string) content.GetValueForProperty("TestVMFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).TestVMFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).NetworkConnectionStatus = (string) content.GetValueForProperty("NetworkConnectionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).NetworkConnectionStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).NetworkFriendlyName = (string) content.GetValueForProperty("NetworkFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).NetworkFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).Subnet = (string) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).Subnet, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).RecoveryPointId = (string) content.GetValueForProperty("RecoveryPointId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).RecoveryPointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).RecoveryPointTime = (global::System.DateTime?) content.GetValueForProperty("RecoveryPointTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetailsInternal)this).RecoveryPointTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FailoverReplicationProtectedItemDetails" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Failover details for a replication protected item.
    [System.ComponentModel.TypeConverter(typeof(FailoverReplicationProtectedItemDetailsTypeConverter))]
    public partial interface IFailoverReplicationProtectedItemDetails

    {

    }
}