namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.PowerShell;

    /// <summary>
    /// Properties of RedisEnterprise databases, as opposed to general resource properties like location, tags
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(DatabasePropertiesTypeConverter))]
    public partial class DatabaseProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.DatabaseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DatabaseProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Persistence = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IPersistence) content.GetValueForProperty("Persistence",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Persistence, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.PersistenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ClientProtocol = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol?) content.GetValueForProperty("ClientProtocol",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ClientProtocol, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Port = (int?) content.GetValueForProperty("Port",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Port, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ResourceState = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState?) content.GetValueForProperty("ResourceState",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ResourceState, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ClusteringPolicy = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy?) content.GetValueForProperty("ClusteringPolicy",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ClusteringPolicy, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).EvictionPolicy = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy?) content.GetValueForProperty("EvictionPolicy",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).EvictionPolicy, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Module = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModule[]) content.GetValueForProperty("Module",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Module, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModule>(__y, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.ModuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceAofFrequency = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency?) content.GetValueForProperty("PersistenceAofFrequency",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceAofFrequency, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceRdbFrequency = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency?) content.GetValueForProperty("PersistenceRdbFrequency",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceRdbFrequency, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceAofEnabled = (bool?) content.GetValueForProperty("PersistenceAofEnabled",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceAofEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceRdbEnabled = (bool?) content.GetValueForProperty("PersistenceRdbEnabled",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceRdbEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.DatabaseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DatabaseProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Persistence = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IPersistence) content.GetValueForProperty("Persistence",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Persistence, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.PersistenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ClientProtocol = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol?) content.GetValueForProperty("ClientProtocol",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ClientProtocol, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Port = (int?) content.GetValueForProperty("Port",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Port, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ResourceState = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState?) content.GetValueForProperty("ResourceState",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ResourceState, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ClusteringPolicy = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy?) content.GetValueForProperty("ClusteringPolicy",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).ClusteringPolicy, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).EvictionPolicy = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy?) content.GetValueForProperty("EvictionPolicy",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).EvictionPolicy, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Module = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModule[]) content.GetValueForProperty("Module",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).Module, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModule>(__y, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.ModuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceAofFrequency = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency?) content.GetValueForProperty("PersistenceAofFrequency",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceAofFrequency, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceRdbFrequency = (Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency?) content.GetValueForProperty("PersistenceRdbFrequency",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceRdbFrequency, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceAofEnabled = (bool?) content.GetValueForProperty("PersistenceAofEnabled",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceAofEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceRdbEnabled = (bool?) content.GetValueForProperty("PersistenceRdbEnabled",((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)this).PersistenceRdbEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.DatabaseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DatabaseProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.DatabaseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DatabaseProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DatabaseProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of RedisEnterprise databases, as opposed to general resource properties like location, tags
    [System.ComponentModel.TypeConverter(typeof(DatabasePropertiesTypeConverter))]
    public partial interface IDatabaseProperties

    {

    }
}