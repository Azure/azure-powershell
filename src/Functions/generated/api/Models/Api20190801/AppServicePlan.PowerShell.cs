namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>App Service plan.</summary>
    [System.ComponentModel.TypeConverter(typeof(AppServicePlanTypeConverter))]
    public partial class AppServicePlan
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServicePlan"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AppServicePlan(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServicePlanPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescriptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).TargetWorkerSizeId = (int?) content.GetValueForProperty("TargetWorkerSizeId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).TargetWorkerSizeId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HyperV = (bool?) content.GetValueForProperty("HyperV",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HyperV, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).IsSpot = (bool?) content.GetValueForProperty("IsSpot",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).IsSpot, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).IsXenon = (bool?) content.GetValueForProperty("IsXenon",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).IsXenon, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).MaximumElasticWorkerCount = (int?) content.GetValueForProperty("MaximumElasticWorkerCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).MaximumElasticWorkerCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).MaximumNumberOfWorker = (int?) content.GetValueForProperty("MaximumNumberOfWorker",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).MaximumNumberOfWorker, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).NumberOfSite = (int?) content.GetValueForProperty("NumberOfSite",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).NumberOfSite, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).PerSiteScaling = (bool?) content.GetValueForProperty("PerSiteScaling",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).PerSiteScaling, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfile = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile) content.GetValueForProperty("HostingEnvironmentProfile",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfile, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostingEnvironmentProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Reserved = (bool?) content.GetValueForProperty("Reserved",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Reserved, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).ResourceGroup = (string) content.GetValueForProperty("ResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).ResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SpotExpirationTime = (global::System.DateTime?) content.GetValueForProperty("SpotExpirationTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SpotExpirationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Subscription = (string) content.GetValueForProperty("Subscription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Subscription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).TargetWorkerCount = (int?) content.GetValueForProperty("TargetWorkerCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).TargetWorkerCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).FreeOfferExpirationTime = (global::System.DateTime?) content.GetValueForProperty("FreeOfferExpirationTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).FreeOfferExpirationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).WorkerTierName = (string) content.GetValueForProperty("WorkerTierName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).WorkerTierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileName = (string) content.GetValueForProperty("HostingEnvironmentProfileName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileType = (string) content.GetValueForProperty("HostingEnvironmentProfileType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileId = (string) content.GetValueForProperty("HostingEnvironmentProfileId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).GeoRegion = (string) content.GetValueForProperty("GeoRegion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).GeoRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[]) content.GetValueForProperty("SkuCapability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuLocation = (string[]) content.GetValueForProperty("SkuLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityScaleType = (string) content.GetValueForProperty("SkuCapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityDefault = (int?) content.GetValueForProperty("SkuCapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityMaximum = (int?) content.GetValueForProperty("SkuCapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityMinimum = (int?) content.GetValueForProperty("SkuCapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServicePlan"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AppServicePlan(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServicePlanPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuDescription) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuDescriptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISkuCapacity) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SkuCapacityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).TargetWorkerSizeId = (int?) content.GetValueForProperty("TargetWorkerSizeId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).TargetWorkerSizeId, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HyperV = (bool?) content.GetValueForProperty("HyperV",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HyperV, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).IsSpot = (bool?) content.GetValueForProperty("IsSpot",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).IsSpot, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).IsXenon = (bool?) content.GetValueForProperty("IsXenon",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).IsXenon, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).MaximumElasticWorkerCount = (int?) content.GetValueForProperty("MaximumElasticWorkerCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).MaximumElasticWorkerCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).MaximumNumberOfWorker = (int?) content.GetValueForProperty("MaximumNumberOfWorker",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).MaximumNumberOfWorker, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).NumberOfSite = (int?) content.GetValueForProperty("NumberOfSite",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).NumberOfSite, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).PerSiteScaling = (bool?) content.GetValueForProperty("PerSiteScaling",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).PerSiteScaling, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfile = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile) content.GetValueForProperty("HostingEnvironmentProfile",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfile, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostingEnvironmentProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Reserved = (bool?) content.GetValueForProperty("Reserved",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Reserved, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).ResourceGroup = (string) content.GetValueForProperty("ResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).ResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SpotExpirationTime = (global::System.DateTime?) content.GetValueForProperty("SpotExpirationTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SpotExpirationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.StatusOptions.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Subscription = (string) content.GetValueForProperty("Subscription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Subscription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).TargetWorkerCount = (int?) content.GetValueForProperty("TargetWorkerCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).TargetWorkerCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).FreeOfferExpirationTime = (global::System.DateTime?) content.GetValueForProperty("FreeOfferExpirationTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).FreeOfferExpirationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).WorkerTierName = (string) content.GetValueForProperty("WorkerTierName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).WorkerTierName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileName = (string) content.GetValueForProperty("HostingEnvironmentProfileName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileType = (string) content.GetValueForProperty("HostingEnvironmentProfileType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileId = (string) content.GetValueForProperty("HostingEnvironmentProfileId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).HostingEnvironmentProfileId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).GeoRegion = (string) content.GetValueForProperty("GeoRegion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).GeoRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapability = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability[]) content.GetValueForProperty("SkuCapability",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapability, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CapabilityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuFamily, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuLocation = (string[]) content.GetValueForProperty("SkuLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuLocation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuTier = (string) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuTier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityScaleType = (string) content.GetValueForProperty("SkuCapacityScaleType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityScaleType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityDefault = (int?) content.GetValueForProperty("SkuCapacityDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityDefault, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityMaximum = (int?) content.GetValueForProperty("SkuCapacityMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityMinimum = (int?) content.GetValueForProperty("SkuCapacityMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlanInternal)this).SkuCapacityMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServicePlan"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AppServicePlan(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServicePlan"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AppServicePlan(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AppServicePlan" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// App Service plan.
    [System.ComponentModel.TypeConverter(typeof(AppServicePlanTypeConverter))]
    public partial interface IAppServicePlan

    {

    }
}