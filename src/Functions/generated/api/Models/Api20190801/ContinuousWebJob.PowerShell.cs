namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Continuous Web Job Information.</summary>
    [System.ComponentModel.TypeConverter(typeof(ContinuousWebJobTypeConverter))]
    public partial class ContinuousWebJob
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContinuousWebJob(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJobPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).DetailedStatus = (string) content.GetValueForProperty("DetailedStatus",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).DetailedStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Error = (string) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Error, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).ExtraInfoUrl = (string) content.GetValueForProperty("ExtraInfoUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).ExtraInfoUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).LogUrl = (string) content.GetValueForProperty("LogUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).LogUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).RunCommand = (string) content.GetValueForProperty("RunCommand",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).RunCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Setting = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesSettings) content.GetValueForProperty("Setting",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Setting, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJobPropertiesSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ContinuousWebJobStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ContinuousWebJobStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Url = (string) content.GetValueForProperty("Url",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Url, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).UsingSdk = (bool?) content.GetValueForProperty("UsingSdk",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).UsingSdk, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).WebJobType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType?) content.GetValueForProperty("WebJobType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).WebJobType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContinuousWebJob(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJobPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).DetailedStatus = (string) content.GetValueForProperty("DetailedStatus",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).DetailedStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Error = (string) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Error, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).ExtraInfoUrl = (string) content.GetValueForProperty("ExtraInfoUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).ExtraInfoUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).LogUrl = (string) content.GetValueForProperty("LogUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).LogUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).RunCommand = (string) content.GetValueForProperty("RunCommand",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).RunCommand, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Setting = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesSettings) content.GetValueForProperty("Setting",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Setting, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJobPropertiesSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ContinuousWebJobStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ContinuousWebJobStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Url = (string) content.GetValueForProperty("Url",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).Url, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).UsingSdk = (bool?) content.GetValueForProperty("UsingSdk",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).UsingSdk, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).WebJobType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType?) content.GetValueForProperty("WebJobType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobInternal)this).WebJobType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WebJobType.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJob" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJob DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContinuousWebJob(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContinuousWebJob"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJob" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJob DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContinuousWebJob(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContinuousWebJob" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJob FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Continuous Web Job Information.
    [System.ComponentModel.TypeConverter(typeof(ContinuousWebJobTypeConverter))]
    public partial interface IContinuousWebJob

    {

    }
}