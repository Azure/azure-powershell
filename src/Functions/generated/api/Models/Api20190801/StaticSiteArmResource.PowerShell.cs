namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Static Site ARM resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(StaticSiteArmResourceTypeConverter))]
    public partial class StaticSiteArmResource
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteArmResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResource DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new StaticSiteArmResource(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteArmResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResource DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new StaticSiteArmResource(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="StaticSiteArmResource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResource FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteArmResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal StaticSiteArmResource(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSite) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescriptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).CustomDomain = (string[]) content.GetValueForProperty("CustomDomain",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).CustomDomain, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).DefaultHostname = (string) content.GetValueForProperty("DefaultHostname",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).DefaultHostname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).RepositoryToken = (string) content.GetValueForProperty("RepositoryToken",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).RepositoryToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityScaleType = (string) content.GetValueForProperty("SkuCapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteBuildProperties) content.GetValueForProperty("BuildProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteBuildPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Branch = (string) content.GetValueForProperty("Branch",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Branch, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[]) content.GetValueForProperty("SkuCapability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuLocation = (string[]) content.GetValueForProperty("SkuLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyAppLocation = (string) content.GetValueForProperty("BuildPropertyAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyAppArtifactLocation = (string) content.GetValueForProperty("BuildPropertyAppArtifactLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyAppArtifactLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyApiLocation = (string) content.GetValueForProperty("BuildPropertyApiLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyApiLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityDefault = (int?) content.GetValueForProperty("SkuCapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityMaximum = (int?) content.GetValueForProperty("SkuCapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityMinimum = (int?) content.GetValueForProperty("SkuCapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteArmResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal StaticSiteArmResource(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSite) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescriptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).CustomDomain = (string[]) content.GetValueForProperty("CustomDomain",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).CustomDomain, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).DefaultHostname = (string) content.GetValueForProperty("DefaultHostname",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).DefaultHostname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).RepositoryToken = (string) content.GetValueForProperty("RepositoryToken",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).RepositoryToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).RepositoryUrl = (string) content.GetValueForProperty("RepositoryUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).RepositoryUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityScaleType = (string) content.GetValueForProperty("SkuCapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteBuildProperties) content.GetValueForProperty("BuildProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StaticSiteBuildPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Branch = (string) content.GetValueForProperty("Branch",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Branch, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[]) content.GetValueForProperty("SkuCapability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuLocation = (string[]) content.GetValueForProperty("SkuLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyAppLocation = (string) content.GetValueForProperty("BuildPropertyAppLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyAppLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyAppArtifactLocation = (string) content.GetValueForProperty("BuildPropertyAppArtifactLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyAppArtifactLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyApiLocation = (string) content.GetValueForProperty("BuildPropertyApiLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).BuildPropertyApiLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityDefault = (int?) content.GetValueForProperty("SkuCapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityMaximum = (int?) content.GetValueForProperty("SkuCapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityMinimum = (int?) content.GetValueForProperty("SkuCapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStaticSiteArmResourceInternal)this).SkuCapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Static Site ARM resource.
    [System.ComponentModel.TypeConverter(typeof(StaticSiteArmResourceTypeConverter))]
    public partial interface IStaticSiteArmResource

    {

    }
}