namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>InMageAzureV2 protected disk details.</summary>
    [System.ComponentModel.TypeConverter(typeof(InMageAzureV2ProtectedDiskDetailsTypeConverter))]
    public partial class InMageAzureV2ProtectedDiskDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAzureV2ProtectedDiskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new InMageAzureV2ProtectedDiskDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAzureV2ProtectedDiskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new InMageAzureV2ProtectedDiskDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="InMageAzureV2ProtectedDiskDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAzureV2ProtectedDiskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal InMageAzureV2ProtectedDiskDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskId = (string) content.GetValueForProperty("DiskId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskName = (string) content.GetValueForProperty("DiskName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ProtectionStage = (string) content.GetValueForProperty("ProtectionStage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ProtectionStage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).HealthErrorCode = (string) content.GetValueForProperty("HealthErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).HealthErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).RpoInSecond = (long?) content.GetValueForProperty("RpoInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).RpoInSecond, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncRequired = (string) content.GetValueForProperty("ResyncRequired",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncRequired, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncProgressPercentage = (int?) content.GetValueForProperty("ResyncProgressPercentage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncProgressPercentage, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncDurationInSecond = (long?) content.GetValueForProperty("ResyncDurationInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncDurationInSecond, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskCapacityInByte = (long?) content.GetValueForProperty("DiskCapacityInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskCapacityInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).FileSystemCapacityInByte = (long?) content.GetValueForProperty("FileSystemCapacityInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).FileSystemCapacityInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).SourceDataInMegaByte = (double?) content.GetValueForProperty("SourceDataInMegaByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).SourceDataInMegaByte, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).PsDataInMegaByte = (double?) content.GetValueForProperty("PsDataInMegaByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).PsDataInMegaByte, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).TargetDataInMegaByte = (double?) content.GetValueForProperty("TargetDataInMegaByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).TargetDataInMegaByte, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskResized = (string) content.GetValueForProperty("DiskResized",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskResized, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).LastRpoCalculatedTime = (global::System.DateTime?) content.GetValueForProperty("LastRpoCalculatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).LastRpoCalculatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAzureV2ProtectedDiskDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal InMageAzureV2ProtectedDiskDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskId = (string) content.GetValueForProperty("DiskId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskName = (string) content.GetValueForProperty("DiskName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ProtectionStage = (string) content.GetValueForProperty("ProtectionStage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ProtectionStage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).HealthErrorCode = (string) content.GetValueForProperty("HealthErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).HealthErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).RpoInSecond = (long?) content.GetValueForProperty("RpoInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).RpoInSecond, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncRequired = (string) content.GetValueForProperty("ResyncRequired",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncRequired, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncProgressPercentage = (int?) content.GetValueForProperty("ResyncProgressPercentage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncProgressPercentage, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncDurationInSecond = (long?) content.GetValueForProperty("ResyncDurationInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).ResyncDurationInSecond, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskCapacityInByte = (long?) content.GetValueForProperty("DiskCapacityInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskCapacityInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).FileSystemCapacityInByte = (long?) content.GetValueForProperty("FileSystemCapacityInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).FileSystemCapacityInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).SourceDataInMegaByte = (double?) content.GetValueForProperty("SourceDataInMegaByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).SourceDataInMegaByte, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).PsDataInMegaByte = (double?) content.GetValueForProperty("PsDataInMegaByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).PsDataInMegaByte, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).TargetDataInMegaByte = (double?) content.GetValueForProperty("TargetDataInMegaByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).TargetDataInMegaByte, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskResized = (string) content.GetValueForProperty("DiskResized",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).DiskResized, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).LastRpoCalculatedTime = (global::System.DateTime?) content.GetValueForProperty("LastRpoCalculatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAzureV2ProtectedDiskDetailsInternal)this).LastRpoCalculatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// InMageAzureV2 protected disk details.
    [System.ComponentModel.TypeConverter(typeof(InMageAzureV2ProtectedDiskDetailsTypeConverter))]
    public partial interface IInMageAzureV2ProtectedDiskDetails

    {

    }
}