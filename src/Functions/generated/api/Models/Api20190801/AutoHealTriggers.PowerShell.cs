namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Triggers for auto-heal.</summary>
    [System.ComponentModel.TypeConverter(typeof(AutoHealTriggersTypeConverter))]
    public partial class AutoHealTriggers
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealTriggers"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AutoHealTriggers(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).Request = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTrigger) content.GetValueForProperty("Request",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).Request, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RequestsBasedTriggerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequest = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTrigger) content.GetValueForProperty("SlowRequest",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequest, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SlowRequestsBasedTriggerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).PrivateBytesInKb = (int?) content.GetValueForProperty("PrivateBytesInKb",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).PrivateBytesInKb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).StatusCode = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[]) content.GetValueForProperty("StatusCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).StatusCode, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StatusCodesBasedTriggerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).RequestCount = (int?) content.GetValueForProperty("RequestCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).RequestCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).RequestTimeInterval = (string) content.GetValueForProperty("RequestTimeInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).RequestTimeInterval, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestCount = (int?) content.GetValueForProperty("SlowRequestCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestTimeInterval = (string) content.GetValueForProperty("SlowRequestTimeInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestTimeInterval, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestTimeTaken = (string) content.GetValueForProperty("SlowRequestTimeTaken",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestTimeTaken, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealTriggers"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AutoHealTriggers(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).Request = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTrigger) content.GetValueForProperty("Request",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).Request, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RequestsBasedTriggerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequest = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTrigger) content.GetValueForProperty("SlowRequest",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequest, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SlowRequestsBasedTriggerTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).PrivateBytesInKb = (int?) content.GetValueForProperty("PrivateBytesInKb",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).PrivateBytesInKb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).StatusCode = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[]) content.GetValueForProperty("StatusCode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).StatusCode, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StatusCodesBasedTriggerTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).RequestCount = (int?) content.GetValueForProperty("RequestCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).RequestCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).RequestTimeInterval = (string) content.GetValueForProperty("RequestTimeInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).RequestTimeInterval, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestCount = (int?) content.GetValueForProperty("SlowRequestCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestTimeInterval = (string) content.GetValueForProperty("SlowRequestTimeInterval",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestTimeInterval, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestTimeTaken = (string) content.GetValueForProperty("SlowRequestTimeTaken",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggersInternal)this).SlowRequestTimeTaken, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealTriggers"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AutoHealTriggers(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealTriggers"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AutoHealTriggers(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AutoHealTriggers" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Triggers for auto-heal.
    [System.ComponentModel.TypeConverter(typeof(AutoHealTriggersTypeConverter))]
    public partial interface IAutoHealTriggers

    {

    }
}