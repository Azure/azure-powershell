namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>A class representing follower database request.</summary>
    [System.ComponentModel.TypeConverter(typeof(FollowerDatabaseDefinitionTypeConverter))]
    public partial class FollowerDatabaseDefinition
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.FollowerDatabaseDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinition" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinition DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FollowerDatabaseDefinition(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.FollowerDatabaseDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinition" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinition DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FollowerDatabaseDefinition(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.FollowerDatabaseDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FollowerDatabaseDefinition(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).ClusterResourceId = (string) content.GetValueForProperty("ClusterResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).ClusterResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).AttachedDatabaseConfigurationName = (string) content.GetValueForProperty("AttachedDatabaseConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).AttachedDatabaseConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).DatabaseName = (string) content.GetValueForProperty("DatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).DatabaseName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.FollowerDatabaseDefinition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FollowerDatabaseDefinition(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).ClusterResourceId = (string) content.GetValueForProperty("ClusterResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).ClusterResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).AttachedDatabaseConfigurationName = (string) content.GetValueForProperty("AttachedDatabaseConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).AttachedDatabaseConfigurationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).DatabaseName = (string) content.GetValueForProperty("DatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinitionInternal)this).DatabaseName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FollowerDatabaseDefinition" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IFollowerDatabaseDefinition FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A class representing follower database request.
    [System.ComponentModel.TypeConverter(typeof(FollowerDatabaseDefinitionTypeConverter))]
    public partial interface IFollowerDatabaseDefinition

    {

    }
}