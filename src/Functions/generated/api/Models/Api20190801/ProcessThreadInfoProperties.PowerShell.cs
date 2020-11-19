namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>ProcessThreadInfo resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(ProcessThreadInfoPropertiesTypeConverter))]
    public partial class ProcessThreadInfoProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ProcessThreadInfoProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ProcessThreadInfoProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ProcessThreadInfoProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ProcessThreadInfoProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Identifier = (int?) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Identifier, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Href = (string) content.GetValueForProperty("Href",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Href, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Process = (string) content.GetValueForProperty("Process",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Process, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).StartAddress = (string) content.GetValueForProperty("StartAddress",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).StartAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).CurrentPriority = (int?) content.GetValueForProperty("CurrentPriority",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).CurrentPriority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).PriorityLevel = (string) content.GetValueForProperty("PriorityLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).PriorityLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).BasePriority = (int?) content.GetValueForProperty("BasePriority",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).BasePriority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).TotalProcessorTime = (string) content.GetValueForProperty("TotalProcessorTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).TotalProcessorTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).UserProcessorTime = (string) content.GetValueForProperty("UserProcessorTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).UserProcessorTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).WaitReason = (string) content.GetValueForProperty("WaitReason",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).WaitReason, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ProcessThreadInfoProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Identifier = (int?) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Identifier, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Href = (string) content.GetValueForProperty("Href",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Href, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Process = (string) content.GetValueForProperty("Process",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).Process, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).StartAddress = (string) content.GetValueForProperty("StartAddress",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).StartAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).CurrentPriority = (int?) content.GetValueForProperty("CurrentPriority",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).CurrentPriority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).PriorityLevel = (string) content.GetValueForProperty("PriorityLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).PriorityLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).BasePriority = (int?) content.GetValueForProperty("BasePriority",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).BasePriority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).TotalProcessorTime = (string) content.GetValueForProperty("TotalProcessorTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).TotalProcessorTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).UserProcessorTime = (string) content.GetValueForProperty("UserProcessorTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).UserProcessorTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).WaitReason = (string) content.GetValueForProperty("WaitReason",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoPropertiesInternal)this).WaitReason, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// ProcessThreadInfo resource specific properties
    [System.ComponentModel.TypeConverter(typeof(ProcessThreadInfoPropertiesTypeConverter))]
    public partial interface IProcessThreadInfoProperties

    {

    }
}