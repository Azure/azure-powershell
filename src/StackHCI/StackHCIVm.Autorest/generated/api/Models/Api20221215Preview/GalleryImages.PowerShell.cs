namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.PowerShell;

    /// <summary>The gallery images resource definition.</summary>
    [System.ComponentModel.TypeConverter(typeof(GalleryImagesTypeConverter))]
    public partial class GalleryImages
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImages"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImages" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImages DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new GalleryImages(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImages"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImages" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImages DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new GalleryImages(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="GalleryImages" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImages FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImages"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal GalleryImages(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImagePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocation = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocation) content.GetValueForProperty("ExtendedLocation",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocation, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.ExtendedLocationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocationName = (string) content.GetValueForProperty("ExtendedLocationName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Identifier = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifier) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Identifier, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageIdentifierTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersion) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatus) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ContainerName = (string) content.GetValueForProperty("ContainerName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ContainerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ImagePath = (string) content.GetValueForProperty("ImagePath",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ImagePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).OSType = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes?) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).OSType, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).CloudInitDataSource = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource?) content.GetValueForProperty("CloudInitDataSource",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).CloudInitDataSource, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).HyperVGeneration = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration?) content.GetValueForProperty("HyperVGeneration",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).HyperVGeneration, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocationType = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes?) content.GetValueForProperty("ExtendedLocationType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocationType, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierPublisher = (string) content.GetValueForProperty("IdentifierPublisher",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierPublisher, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierOffer = (string) content.GetValueForProperty("IdentifierOffer",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierOffer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierSku = (string) content.GetValueForProperty("IdentifierSku",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierSku, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).VersionProperty = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionProperties) content.GetValueForProperty("VersionProperty",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).VersionProperty, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).VersionName = (string) content.GetValueForProperty("VersionName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).VersionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusProvisioningStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatus) content.GetValueForProperty("StatusProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusProvisioningStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatusProvisioningStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusDownloadStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatus) content.GetValueForProperty("StatusDownloadStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusDownloadStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatusDownloadStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusErrorCode = (string) content.GetValueForProperty("StatusErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusErrorMessage = (string) content.GetValueForProperty("StatusErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusProgressPercentage = (long?) content.GetValueForProperty("StatusProgressPercentage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusProgressPercentage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status?) content.GetValueForProperty("ProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersionStorageProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningStatusOperationId = (string) content.GetValueForProperty("ProvisioningStatusOperationId",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningStatusOperationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).DownloadStatusDownloadSizeInMb = (long?) content.GetValueForProperty("DownloadStatusDownloadSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).DownloadStatusDownloadSizeInMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StorageProfileOSDiskImage = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage) content.GetValueForProperty("StorageProfileOSDiskImage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StorageProfileOSDiskImage, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryDiskImageTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).OSDiskImageSizeInMb = (long?) content.GetValueForProperty("OSDiskImageSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).OSDiskImageSizeInMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImages"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal GalleryImages(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImagePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocation = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocation) content.GetValueForProperty("ExtendedLocation",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocation, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.ExtendedLocationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocationName = (string) content.GetValueForProperty("ExtendedLocationName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocationName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Identifier = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageIdentifier) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Identifier, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageIdentifierTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersion) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatus) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ContainerName = (string) content.GetValueForProperty("ContainerName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ContainerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ImagePath = (string) content.GetValueForProperty("ImagePath",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ImagePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).OSType = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes?) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).OSType, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OperatingSystemTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).CloudInitDataSource = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource?) content.GetValueForProperty("CloudInitDataSource",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).CloudInitDataSource, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CloudInitDataSource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).HyperVGeneration = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration?) content.GetValueForProperty("HyperVGeneration",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).HyperVGeneration, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.HyperVGeneration.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocationType = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes?) content.GetValueForProperty("ExtendedLocationType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ExtendedLocationType, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierPublisher = (string) content.GetValueForProperty("IdentifierPublisher",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierPublisher, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierOffer = (string) content.GetValueForProperty("IdentifierOffer",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierOffer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierSku = (string) content.GetValueForProperty("IdentifierSku",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).IdentifierSku, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).VersionProperty = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionProperties) content.GetValueForProperty("VersionProperty",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).VersionProperty, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersionPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).VersionName = (string) content.GetValueForProperty("VersionName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).VersionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusProvisioningStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusProvisioningStatus) content.GetValueForProperty("StatusProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusProvisioningStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatusProvisioningStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusDownloadStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageStatusDownloadStatus) content.GetValueForProperty("StatusDownloadStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusDownloadStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageStatusDownloadStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusErrorCode = (string) content.GetValueForProperty("StatusErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusErrorMessage = (string) content.GetValueForProperty("StatusErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusProgressPercentage = (long?) content.GetValueForProperty("StatusProgressPercentage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StatusProgressPercentage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status?) content.GetValueForProperty("ProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImageVersionStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryImageVersionStorageProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningStatusOperationId = (string) content.GetValueForProperty("ProvisioningStatusOperationId",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).ProvisioningStatusOperationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).DownloadStatusDownloadSizeInMb = (long?) content.GetValueForProperty("DownloadStatusDownloadSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).DownloadStatusDownloadSizeInMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StorageProfileOSDiskImage = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryDiskImage) content.GetValueForProperty("StorageProfileOSDiskImage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).StorageProfileOSDiskImage, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GalleryDiskImageTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).OSDiskImageSizeInMb = (long?) content.GetValueForProperty("OSDiskImageSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImagesInternal)this).OSDiskImageSizeInMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The gallery images resource definition.
    [System.ComponentModel.TypeConverter(typeof(GalleryImagesTypeConverter))]
    public partial interface IGalleryImages

    {

    }
}