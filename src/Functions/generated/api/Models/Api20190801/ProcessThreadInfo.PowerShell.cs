namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Process Thread Information.</summary>
    [System.ComponentModel.TypeConverter(typeof(ProcessThreadInfoTypeConverter))]
    public partial class ProcessThreadInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ProcessThreadInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ProcessThreadInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ProcessThreadInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ProcessThreadInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfoPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).StartAddress = (string) content.GetValueForProperty("StartAddress",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).StartAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).BasePriority = (int?) content.GetValueForProperty("BasePriority",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).BasePriority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Href = (string) content.GetValueForProperty("Href",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Href, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Identifier = (int?) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Identifier, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).PriorityLevel = (string) content.GetValueForProperty("PriorityLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).PriorityLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Process = (string) content.GetValueForProperty("Process",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Process, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).CurrentPriority = (int?) content.GetValueForProperty("CurrentPriority",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).CurrentPriority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).TotalProcessorTime = (string) content.GetValueForProperty("TotalProcessorTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).TotalProcessorTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).UserProcessorTime = (string) content.GetValueForProperty("UserProcessorTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).UserProcessorTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).WaitReason = (string) content.GetValueForProperty("WaitReason",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).WaitReason, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ProcessThreadInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessThreadInfoPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).StartAddress = (string) content.GetValueForProperty("StartAddress",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).StartAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).BasePriority = (int?) content.GetValueForProperty("BasePriority",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).BasePriority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Href = (string) content.GetValueForProperty("Href",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Href, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Identifier = (int?) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Identifier, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).PriorityLevel = (string) content.GetValueForProperty("PriorityLevel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).PriorityLevel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Process = (string) content.GetValueForProperty("Process",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).Process, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).CurrentPriority = (int?) content.GetValueForProperty("CurrentPriority",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).CurrentPriority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).TotalProcessorTime = (string) content.GetValueForProperty("TotalProcessorTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).TotalProcessorTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).UserProcessorTime = (string) content.GetValueForProperty("UserProcessorTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).UserProcessorTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).WaitReason = (string) content.GetValueForProperty("WaitReason",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessThreadInfoInternal)this).WaitReason, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Process Thread Information.
    [System.ComponentModel.TypeConverter(typeof(ProcessThreadInfoTypeConverter))]
    public partial interface IProcessThreadInfo

    {

    }
}