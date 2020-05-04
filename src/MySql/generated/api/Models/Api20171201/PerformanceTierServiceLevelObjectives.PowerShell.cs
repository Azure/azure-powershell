namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.PowerShell;

    /// <summary>Service level objectives for performance tier.</summary>
    [System.ComponentModel.TypeConverter(typeof(PerformanceTierServiceLevelObjectivesTypeConverter))]
    public partial class PerformanceTierServiceLevelObjectives
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.PerformanceTierServiceLevelObjectives"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectives"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectives DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PerformanceTierServiceLevelObjectives(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.PerformanceTierServiceLevelObjectives"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectives"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectives DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PerformanceTierServiceLevelObjectives(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PerformanceTierServiceLevelObjectives" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectives FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.PerformanceTierServiceLevelObjectives"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PerformanceTierServiceLevelObjectives(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).Edition = (string) content.GetValueForProperty("Edition",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).Edition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).HardwareGeneration = (string) content.GetValueForProperty("HardwareGeneration",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).HardwareGeneration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MaxBackupRetentionDay = (int?) content.GetValueForProperty("MaxBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MaxBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MaxStorageMb = (int?) content.GetValueForProperty("MaxStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MaxStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MinBackupRetentionDay = (int?) content.GetValueForProperty("MinBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MinBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MinStorageMb = (int?) content.GetValueForProperty("MinStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MinStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).VCore = (int?) content.GetValueForProperty("VCore",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).VCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.PerformanceTierServiceLevelObjectives"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PerformanceTierServiceLevelObjectives(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).Edition = (string) content.GetValueForProperty("Edition",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).Edition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).HardwareGeneration = (string) content.GetValueForProperty("HardwareGeneration",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).HardwareGeneration, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MaxBackupRetentionDay = (int?) content.GetValueForProperty("MaxBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MaxBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MaxStorageMb = (int?) content.GetValueForProperty("MaxStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MaxStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MinBackupRetentionDay = (int?) content.GetValueForProperty("MinBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MinBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MinStorageMb = (int?) content.GetValueForProperty("MinStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).MinStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).VCore = (int?) content.GetValueForProperty("VCore",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectivesInternal)this).VCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Service level objectives for performance tier.
    [System.ComponentModel.TypeConverter(typeof(PerformanceTierServiceLevelObjectivesTypeConverter))]
    public partial interface IPerformanceTierServiceLevelObjectives

    {

    }
}