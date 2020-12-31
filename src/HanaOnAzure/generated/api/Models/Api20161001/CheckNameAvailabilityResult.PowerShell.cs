namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.PowerShell;

    /// <summary>The CheckNameAvailability operation response.</summary>
    [System.ComponentModel.TypeConverter(typeof(CheckNameAvailabilityResultTypeConverter))]
    public partial class CheckNameAvailabilityResult
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.CheckNameAvailabilityResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CheckNameAvailabilityResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).NameAvailable = (bool?) content.GetValueForProperty("NameAvailable",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).NameAvailable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).Reason = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.Reason?) content.GetValueForProperty("Reason",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).Reason, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.Reason.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).Message, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.CheckNameAvailabilityResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CheckNameAvailabilityResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).NameAvailable = (bool?) content.GetValueForProperty("NameAvailable",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).NameAvailable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).Reason = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.Reason?) content.GetValueForProperty("Reason",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).Reason, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.Reason.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResultInternal)this).Message, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.CheckNameAvailabilityResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CheckNameAvailabilityResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.CheckNameAvailabilityResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CheckNameAvailabilityResult(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CheckNameAvailabilityResult" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ICheckNameAvailabilityResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The CheckNameAvailability operation response.
    [System.ComponentModel.TypeConverter(typeof(CheckNameAvailabilityResultTypeConverter))]
    public partial interface ICheckNameAvailabilityResult

    {

    }
}