namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>DeletedSite resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(DeletedSitePropertiesTypeConverter))]
    public partial class DeletedSiteProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DeletedSiteProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DeletedSiteProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedSiteId = (int?) content.GetValueForProperty("DeletedSiteId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedSiteId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedSiteName = (string) content.GetValueForProperty("DeletedSiteName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedSiteName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedTimestamp = (string) content.GetValueForProperty("DeletedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).GeoRegionName = (string) content.GetValueForProperty("GeoRegionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).GeoRegionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).ResourceGroup = (string) content.GetValueForProperty("ResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).ResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Slot = (string) content.GetValueForProperty("Slot",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Slot, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Subscription = (string) content.GetValueForProperty("Subscription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Subscription, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DeletedSiteProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DeletedSiteProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedSiteId = (int?) content.GetValueForProperty("DeletedSiteId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedSiteId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedSiteName = (string) content.GetValueForProperty("DeletedSiteName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedSiteName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedTimestamp = (string) content.GetValueForProperty("DeletedTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).DeletedTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).GeoRegionName = (string) content.GetValueForProperty("GeoRegionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).GeoRegionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).ResourceGroup = (string) content.GetValueForProperty("ResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).ResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Slot = (string) content.GetValueForProperty("Slot",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Slot, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Subscription = (string) content.GetValueForProperty("Subscription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSitePropertiesInternal)this).Subscription, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DeletedSiteProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DeletedSiteProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DeletedSiteProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DeletedSiteProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DeletedSiteProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeletedSiteProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// DeletedSite resource specific properties
    [System.ComponentModel.TypeConverter(typeof(DeletedSitePropertiesTypeConverter))]
    public partial interface IDeletedSiteProperties

    {

    }
}