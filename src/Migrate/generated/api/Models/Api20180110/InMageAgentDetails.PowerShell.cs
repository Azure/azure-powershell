namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>The details of the InMage agent.</summary>
    [System.ComponentModel.TypeConverter(typeof(InMageAgentDetailsTypeConverter))]
    public partial class InMageAgentDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAgentDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new InMageAgentDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAgentDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new InMageAgentDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="InMageAgentDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAgentDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal InMageAgentDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentUpdateStatus = (string) content.GetValueForProperty("AgentUpdateStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentUpdateStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).PostUpdateRebootStatus = (string) content.GetValueForProperty("PostUpdateRebootStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).PostUpdateRebootStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageAgentDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal InMageAgentDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentUpdateStatus = (string) content.GetValueForProperty("AgentUpdateStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentUpdateStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).PostUpdateRebootStatus = (string) content.GetValueForProperty("PostUpdateRebootStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).PostUpdateRebootStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentExpiryDate = (global::System.DateTime?) content.GetValueForProperty("AgentExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageAgentDetailsInternal)this).AgentExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The details of the InMage agent.
    [System.ComponentModel.TypeConverter(typeof(InMageAgentDetailsTypeConverter))]
    public partial interface IInMageAgentDetails

    {

    }
}