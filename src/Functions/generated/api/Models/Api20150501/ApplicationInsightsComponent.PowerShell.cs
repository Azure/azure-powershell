namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>An Application Insights component definition.</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationInsightsComponentTypeConverter))]
    public partial class ApplicationInsightsComponent
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationInsightsComponent(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponentPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ComponentsResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ApplicationType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ApplicationType) content.GetValueForProperty("ApplicationType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ApplicationType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ApplicationType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).FlowType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FlowType?) content.GetValueForProperty("FlowType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).FlowType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FlowType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).RequestSource = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RequestSource?) content.GetValueForProperty("RequestSource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).RequestSource, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RequestSource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).HockeyAppToken = (string) content.GetValueForProperty("HockeyAppToken",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).HockeyAppToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).AppId = (string) content.GetValueForProperty("AppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).AppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).HockeyAppId = (string) content.GetValueForProperty("HockeyAppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).HockeyAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ApplicationId = (string) content.GetValueForProperty("ApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).InstrumentationKey = (string) content.GetValueForProperty("InstrumentationKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).InstrumentationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).CreationDate = (global::System.DateTime?) content.GetValueForProperty("CreationDate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).CreationDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).SamplingPercentage = (double?) content.GetValueForProperty("SamplingPercentage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).SamplingPercentage, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ProvisioningState, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationInsightsComponent(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponentPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentsResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ComponentsResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ApplicationType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ApplicationType) content.GetValueForProperty("ApplicationType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ApplicationType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ApplicationType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).FlowType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FlowType?) content.GetValueForProperty("FlowType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).FlowType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FlowType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).RequestSource = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RequestSource?) content.GetValueForProperty("RequestSource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).RequestSource, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RequestSource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).HockeyAppToken = (string) content.GetValueForProperty("HockeyAppToken",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).HockeyAppToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).AppId = (string) content.GetValueForProperty("AppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).AppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).HockeyAppId = (string) content.GetValueForProperty("HockeyAppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).HockeyAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ApplicationId = (string) content.GetValueForProperty("ApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).InstrumentationKey = (string) content.GetValueForProperty("InstrumentationKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).InstrumentationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).CreationDate = (global::System.DateTime?) content.GetValueForProperty("CreationDate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).CreationDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).SamplingPercentage = (double?) content.GetValueForProperty("SamplingPercentage",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).SamplingPercentage, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponentInternal)this).ProvisioningState, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationInsightsComponent(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.ApplicationInsightsComponent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationInsightsComponent(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationInsightsComponent" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// An Application Insights component definition.
    [System.ComponentModel.TypeConverter(typeof(ApplicationInsightsComponentTypeConverter))]
    public partial interface IApplicationInsightsComponent

    {

    }
}