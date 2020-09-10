namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Information needed for cloning operation.</summary>
    [System.ComponentModel.TypeConverter(typeof(CloningInfoTypeConverter))]
    public partial class CloningInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CloningInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CloningInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).AppSettingsOverride = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides) content.GetValueForProperty("AppSettingsOverride",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).AppSettingsOverride, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CloningInfoAppSettingsOverridesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CloneCustomHostName = (bool?) content.GetValueForProperty("CloneCustomHostName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CloneCustomHostName, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CloneSourceControl = (bool?) content.GetValueForProperty("CloneSourceControl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CloneSourceControl, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).ConfigureLoadBalancing = (bool?) content.GetValueForProperty("ConfigureLoadBalancing",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).ConfigureLoadBalancing, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CorrelationId = (string) content.GetValueForProperty("CorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).HostingEnvironment = (string) content.GetValueForProperty("HostingEnvironment",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).HostingEnvironment, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).Overwrite = (bool?) content.GetValueForProperty("Overwrite",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).Overwrite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).SourceWebAppId = (string) content.GetValueForProperty("SourceWebAppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).SourceWebAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).SourceWebAppLocation = (string) content.GetValueForProperty("SourceWebAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).SourceWebAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).TrafficManagerProfileId = (string) content.GetValueForProperty("TrafficManagerProfileId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).TrafficManagerProfileId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).TrafficManagerProfileName = (string) content.GetValueForProperty("TrafficManagerProfileName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).TrafficManagerProfileName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CloningInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CloningInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).AppSettingsOverride = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides) content.GetValueForProperty("AppSettingsOverride",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).AppSettingsOverride, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CloningInfoAppSettingsOverridesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CloneCustomHostName = (bool?) content.GetValueForProperty("CloneCustomHostName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CloneCustomHostName, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CloneSourceControl = (bool?) content.GetValueForProperty("CloneSourceControl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CloneSourceControl, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).ConfigureLoadBalancing = (bool?) content.GetValueForProperty("ConfigureLoadBalancing",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).ConfigureLoadBalancing, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CorrelationId = (string) content.GetValueForProperty("CorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).CorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).HostingEnvironment = (string) content.GetValueForProperty("HostingEnvironment",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).HostingEnvironment, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).Overwrite = (bool?) content.GetValueForProperty("Overwrite",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).Overwrite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).SourceWebAppId = (string) content.GetValueForProperty("SourceWebAppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).SourceWebAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).SourceWebAppLocation = (string) content.GetValueForProperty("SourceWebAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).SourceWebAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).TrafficManagerProfileId = (string) content.GetValueForProperty("TrafficManagerProfileId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).TrafficManagerProfileId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).TrafficManagerProfileName = (string) content.GetValueForProperty("TrafficManagerProfileName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)this).TrafficManagerProfileName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CloningInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CloningInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CloningInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CloningInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CloningInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Information needed for cloning operation.
    [System.ComponentModel.TypeConverter(typeof(CloningInfoTypeConverter))]
    public partial interface ICloningInfo

    {

    }
}