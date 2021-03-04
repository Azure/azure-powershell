namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Cluster REST Resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(HyperVClusterTypeConverter))]
    public partial class HyperVCluster
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVCluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HyperVCluster(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVCluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HyperVCluster(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HyperVCluster" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVCluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HyperVCluster(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVClusterPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).CreatedTimestamp = (string) content.GetValueForProperty("CreatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).CreatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).UpdatedTimestamp = (string) content.GetValueForProperty("UpdatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).UpdatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Fqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).FunctionalLevel = (int?) content.GetValueForProperty("FunctionalLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).FunctionalLevel, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Status = (string) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Status, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).RunAsAccountId = (string) content.GetValueForProperty("RunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).RunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).HostFqdnList = (string[]) content.GetValueForProperty("HostFqdnList",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).HostFqdnList, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[]) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Error, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HealthErrorDetailsTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVCluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HyperVCluster(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVClusterPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).CreatedTimestamp = (string) content.GetValueForProperty("CreatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).CreatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).UpdatedTimestamp = (string) content.GetValueForProperty("UpdatedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).UpdatedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Fqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).FunctionalLevel = (int?) content.GetValueForProperty("FunctionalLevel",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).FunctionalLevel, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Status = (string) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Status, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).RunAsAccountId = (string) content.GetValueForProperty("RunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).RunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).HostFqdnList = (string[]) content.GetValueForProperty("HostFqdnList",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).HostFqdnList, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[]) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterInternal)this).Error, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HealthErrorDetailsTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Cluster REST Resource.
    [System.ComponentModel.TypeConverter(typeof(HyperVClusterTypeConverter))]
    public partial interface IHyperVCluster

    {

    }
}