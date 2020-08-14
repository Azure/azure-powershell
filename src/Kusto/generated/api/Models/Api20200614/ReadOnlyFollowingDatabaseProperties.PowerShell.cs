namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>Class representing the Kusto database properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(ReadOnlyFollowingDatabasePropertiesTypeConverter))]
    public partial class ReadOnlyFollowingDatabaseProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ReadOnlyFollowingDatabaseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ReadOnlyFollowingDatabaseProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ReadOnlyFollowingDatabaseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ReadOnlyFollowingDatabaseProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ReadOnlyFollowingDatabaseProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ReadOnlyFollowingDatabaseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ReadOnlyFollowingDatabaseProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).Statistics = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics) content.GetValueForProperty("Statistics",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).Statistics, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.DatabaseStatisticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).AttachedDatabaseConfigurationName = (string) content.GetValueForProperty("AttachedDatabaseConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).AttachedDatabaseConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).HotCachePeriod = (global::System.TimeSpan?) content.GetValueForProperty("HotCachePeriod",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).HotCachePeriod, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).LeaderClusterResourceId = (string) content.GetValueForProperty("LeaderClusterResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).LeaderClusterResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).PrincipalsModificationKind = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind?) content.GetValueForProperty("PrincipalsModificationKind",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).PrincipalsModificationKind, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).SoftDeletePeriod = (global::System.TimeSpan?) content.GetValueForProperty("SoftDeletePeriod",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).SoftDeletePeriod, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).StatisticsSize = (float?) content.GetValueForProperty("StatisticsSize",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).StatisticsSize, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ReadOnlyFollowingDatabaseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ReadOnlyFollowingDatabaseProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).Statistics = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics) content.GetValueForProperty("Statistics",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).Statistics, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.DatabaseStatisticsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).AttachedDatabaseConfigurationName = (string) content.GetValueForProperty("AttachedDatabaseConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).AttachedDatabaseConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).HotCachePeriod = (global::System.TimeSpan?) content.GetValueForProperty("HotCachePeriod",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).HotCachePeriod, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).LeaderClusterResourceId = (string) content.GetValueForProperty("LeaderClusterResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).LeaderClusterResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).PrincipalsModificationKind = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind?) content.GetValueForProperty("PrincipalsModificationKind",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).PrincipalsModificationKind, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).SoftDeletePeriod = (global::System.TimeSpan?) content.GetValueForProperty("SoftDeletePeriod",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).SoftDeletePeriod, (v) => v is global::System.TimeSpan _v ? _v : global::System.Xml.XmlConvert.ToTimeSpan( v.ToString() ));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).StatisticsSize = (float?) content.GetValueForProperty("StatisticsSize",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)this).StatisticsSize, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class representing the Kusto database properties.
    [System.ComponentModel.TypeConverter(typeof(ReadOnlyFollowingDatabasePropertiesTypeConverter))]
    public partial interface IReadOnlyFollowingDatabaseProperties

    {

    }
}