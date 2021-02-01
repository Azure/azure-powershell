namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.PowerShell;

    /// <summary>Replica Set Definition</summary>
    [System.ComponentModel.TypeConverter(typeof(ReplicaSetTypeConverter))]
    public partial class ReplicaSet
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ReplicaSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ReplicaSet(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ReplicaSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ReplicaSet(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ReplicaSet" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ReplicaSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ReplicaSet(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).VnetSiteId = (string) content.GetValueForProperty("VnetSiteId",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).VnetSiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).SubnetId = (string) content.GetValueForProperty("SubnetId",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).SubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).DomainControllerIPAddress = (string[]) content.GetValueForProperty("DomainControllerIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).DomainControllerIPAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).ExternalAccessIPAddress = (string) content.GetValueForProperty("ExternalAccessIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).ExternalAccessIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).ServiceStatus = (string) content.GetValueForProperty("ServiceStatus",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).ServiceStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthLastEvaluated = (global::System.DateTime?) content.GetValueForProperty("HealthLastEvaluated",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthLastEvaluated, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthMonitor = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor[]) content.GetValueForProperty("HealthMonitor",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthMonitor, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor>(__y, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.HealthMonitorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthAlert = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert[]) content.GetValueForProperty("HealthAlert",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthAlert, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert>(__y, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.HealthAlertTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ReplicaSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ReplicaSet(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).VnetSiteId = (string) content.GetValueForProperty("VnetSiteId",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).VnetSiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).SubnetId = (string) content.GetValueForProperty("SubnetId",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).SubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).DomainControllerIPAddress = (string[]) content.GetValueForProperty("DomainControllerIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).DomainControllerIPAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).ExternalAccessIPAddress = (string) content.GetValueForProperty("ExternalAccessIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).ExternalAccessIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).ServiceStatus = (string) content.GetValueForProperty("ServiceStatus",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).ServiceStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthLastEvaluated = (global::System.DateTime?) content.GetValueForProperty("HealthLastEvaluated",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthLastEvaluated, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthMonitor = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor[]) content.GetValueForProperty("HealthMonitor",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthMonitor, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor>(__y, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.HealthMonitorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthAlert = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert[]) content.GetValueForProperty("HealthAlert",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal)this).HealthAlert, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert>(__y, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.HealthAlertTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Replica Set Definition
    [System.ComponentModel.TypeConverter(typeof(ReplicaSetTypeConverter))]
    public partial interface IReplicaSet

    {

    }
}