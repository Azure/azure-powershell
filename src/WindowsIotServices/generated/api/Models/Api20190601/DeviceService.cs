namespace Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Extensions;

    /// <summary>The description of the Windows IoT Device Service.</summary>
    public partial class DeviceService :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceService,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.TrackedResource();

        /// <summary>Windows IoT Device Service OEM AAD domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inlined)]
        public string AdminDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).AdminDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).AdminDomainName = value; }

        /// <summary>Windows IoT Device Service ODM AAD domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inlined)]
        public string BillingDomainName { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).BillingDomainName; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).BillingDomainName = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>
        /// The Etag field is *not* required. If it is provided in the response body, it must also be provided as a header per the
        /// normal ETag convention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Fully qualified resource Id for the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__trackedResource).Id; }

        /// <summary>The Azure Region where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceProperties Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.DeviceServiceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for StartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceInternal.StartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).StartDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).StartDate = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__trackedResource).Name; }

        /// <summary>Windows IoT Device Service notes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inlined)]
        public string Note { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).Note; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).Note = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceProperties _property;

        /// <summary>The properties of a Windows IoT Device Service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.DeviceServiceProperties()); set => this._property = value; }

        /// <summary>Windows IoT Device Service device allocation,</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inlined)]
        public long? Quantity { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).Quantity; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).Quantity = value; }

        /// <summary>Windows IoT Device Service start date,</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inlined)]
        public global::System.DateTime? StartDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServicePropertiesInternal)Property).StartDate; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="DeviceService" /> instance.</summary>
        public DeviceService()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// The description of the Windows IoT Device Service.
    public partial interface IDeviceService :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResource
    {
        /// <summary>Windows IoT Device Service OEM AAD domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Windows IoT Device Service OEM AAD domain",
        SerializedName = @"adminDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string AdminDomainName { get; set; }
        /// <summary>Windows IoT Device Service ODM AAD domain</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Windows IoT Device Service ODM AAD domain",
        SerializedName = @"billingDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string BillingDomainName { get; set; }
        /// <summary>
        /// The Etag field is *not* required. If it is provided in the response body, it must also be provided as a header per the
        /// normal ETag convention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Etag field is *not* required. If it is provided in the response body, it must also be provided as a header per the normal ETag convention.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>Windows IoT Device Service notes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Windows IoT Device Service notes.",
        SerializedName = @"notes",
        PossibleTypes = new [] { typeof(string) })]
        string Note { get; set; }
        /// <summary>Windows IoT Device Service device allocation,</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Windows IoT Device Service device allocation,",
        SerializedName = @"quantity",
        PossibleTypes = new [] { typeof(long) })]
        long? Quantity { get; set; }
        /// <summary>Windows IoT Device Service start date,</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Windows IoT Device Service start date,",
        SerializedName = @"startDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartDate { get;  }

    }
    /// The description of the Windows IoT Device Service.
    internal partial interface IDeviceServiceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceInternal
    {
        /// <summary>Windows IoT Device Service OEM AAD domain</summary>
        string AdminDomainName { get; set; }
        /// <summary>Windows IoT Device Service ODM AAD domain</summary>
        string BillingDomainName { get; set; }
        /// <summary>
        /// The Etag field is *not* required. If it is provided in the response body, it must also be provided as a header per the
        /// normal ETag convention.
        /// </summary>
        string Etag { get; set; }
        /// <summary>Windows IoT Device Service notes.</summary>
        string Note { get; set; }
        /// <summary>The properties of a Windows IoT Device Service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceProperties Property { get; set; }
        /// <summary>Windows IoT Device Service device allocation,</summary>
        long? Quantity { get; set; }
        /// <summary>Windows IoT Device Service start date,</summary>
        global::System.DateTime? StartDate { get; set; }

    }
}