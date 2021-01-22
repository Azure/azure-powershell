namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Class representing the servers project summary.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServersProjectSummaryTypeConverter))]
    public partial class ServersProjectSummary
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ServersProjectSummary"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummary"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummary DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServersProjectSummary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ServersProjectSummary"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummary"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummary DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServersProjectSummary(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServersProjectSummary" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummary FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ServersProjectSummary"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServersProjectSummary(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).DiscoveredCount = (int?) content.GetValueForProperty("DiscoveredCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).DiscoveredCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).AssessedCount = (int?) content.GetValueForProperty("AssessedCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).AssessedCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).ReplicatingCount = (int?) content.GetValueForProperty("ReplicatingCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).ReplicatingCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).TestMigratedCount = (int?) content.GetValueForProperty("TestMigratedCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).TestMigratedCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).MigratedCount = (int?) content.GetValueForProperty("MigratedCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).MigratedCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).RefreshSummaryState = (string) content.GetValueForProperty("RefreshSummaryState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).RefreshSummaryState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).LastSummaryRefreshedTime = (global::System.DateTime?) content.GetValueForProperty("LastSummaryRefreshedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).LastSummaryRefreshedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).ExtendedSummary = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummary) content.GetValueForProperty("ExtendedSummary",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).ExtendedSummary, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ProjectSummaryExtendedSummaryTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ServersProjectSummary"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServersProjectSummary(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).DiscoveredCount = (int?) content.GetValueForProperty("DiscoveredCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).DiscoveredCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).AssessedCount = (int?) content.GetValueForProperty("AssessedCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).AssessedCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).ReplicatingCount = (int?) content.GetValueForProperty("ReplicatingCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).ReplicatingCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).TestMigratedCount = (int?) content.GetValueForProperty("TestMigratedCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).TestMigratedCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).MigratedCount = (int?) content.GetValueForProperty("MigratedCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IServersProjectSummaryInternal)this).MigratedCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).RefreshSummaryState = (string) content.GetValueForProperty("RefreshSummaryState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).RefreshSummaryState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).LastSummaryRefreshedTime = (global::System.DateTime?) content.GetValueForProperty("LastSummaryRefreshedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).LastSummaryRefreshedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).ExtendedSummary = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryExtendedSummary) content.GetValueForProperty("ExtendedSummary",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IProjectSummaryInternal)this).ExtendedSummary, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ProjectSummaryExtendedSummaryTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class representing the servers project summary.
    [System.ComponentModel.TypeConverter(typeof(ServersProjectSummaryTypeConverter))]
    public partial interface IServersProjectSummary

    {

    }
}