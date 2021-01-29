namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Migration properties that can be shared by various publishers.</summary>
    [System.ComponentModel.TypeConverter(typeof(MigrationDetailsTypeConverter))]
    public partial class MigrationDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MigrationDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MigrationDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MigrationDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MigrationDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MigrationPhase = (string) content.GetValueForProperty("MigrationPhase",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MigrationPhase, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MigrationTested = (bool?) content.GetValueForProperty("MigrationTested",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MigrationTested, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).ReplicationProgressPercentage = (int?) content.GetValueForProperty("ReplicationProgressPercentage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).ReplicationProgressPercentage, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).TargetVMArmId = (string) content.GetValueForProperty("TargetVMArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).TargetVMArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).EnqueueTime = (string) content.GetValueForProperty("EnqueueTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).EnqueueTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).SolutionName = (string) content.GetValueForProperty("SolutionName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).SolutionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineId = (string) content.GetValueForProperty("MachineId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineManagerId = (string) content.GetValueForProperty("MachineManagerId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineManagerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).FabricType = (string) content.GetValueForProperty("FabricType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).FabricType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).LastUpdatedTime = (global::System.DateTime?) content.GetValueForProperty("LastUpdatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).LastUpdatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineName = (string) content.GetValueForProperty("MachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).IPAddress = (string[]) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).IPAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).Fqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).BiosId = (string) content.GetValueForProperty("BiosId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).BiosId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MacAddress = (string[]) content.GetValueForProperty("MacAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MacAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).ExtendedInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsExtendedInfo) content.GetValueForProperty("ExtendedInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).ExtendedInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrationDetailsExtendedInfoTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MigrationDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MigrationPhase = (string) content.GetValueForProperty("MigrationPhase",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MigrationPhase, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MigrationTested = (bool?) content.GetValueForProperty("MigrationTested",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MigrationTested, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).ReplicationProgressPercentage = (int?) content.GetValueForProperty("ReplicationProgressPercentage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).ReplicationProgressPercentage, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).TargetVMArmId = (string) content.GetValueForProperty("TargetVMArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).TargetVMArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).EnqueueTime = (string) content.GetValueForProperty("EnqueueTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).EnqueueTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).SolutionName = (string) content.GetValueForProperty("SolutionName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).SolutionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineId = (string) content.GetValueForProperty("MachineId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineManagerId = (string) content.GetValueForProperty("MachineManagerId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineManagerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).FabricType = (string) content.GetValueForProperty("FabricType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).FabricType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).LastUpdatedTime = (global::System.DateTime?) content.GetValueForProperty("LastUpdatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).LastUpdatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineName = (string) content.GetValueForProperty("MachineName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MachineName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).IPAddress = (string[]) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).IPAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).Fqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).BiosId = (string) content.GetValueForProperty("BiosId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).BiosId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MacAddress = (string[]) content.GetValueForProperty("MacAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).MacAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).ExtendedInfo = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsExtendedInfo) content.GetValueForProperty("ExtendedInfo",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetailsInternal)this).ExtendedInfo, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrationDetailsExtendedInfoTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Migration properties that can be shared by various publishers.
    [System.ComponentModel.TypeConverter(typeof(MigrationDetailsTypeConverter))]
    public partial interface IMigrationDetails

    {

    }
}