namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    /// <summary>Resource information with extended details.</summary>
    public partial class DedicatedHsm :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsm,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.Resource();

        /// <summary>The Azure Resource Manager resource ID for the dedicated HSM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Id; }

        /// <summary>The supported Azure location where the dedicated HSM should be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.FormatTable(Index = 3)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkProfile Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmInternal.NetworkProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).NetworkProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).NetworkProfile = value; }

        /// <summary>Internal Acessors for NetworkProfileSubnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IApiEntityReference Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmInternal.NetworkProfileSubnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).NetworkProfileSubnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).NetworkProfileSubnet = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmProperties Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.DedicatedHsmProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.JsonWebKeyType? Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for StatusMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmInternal.StatusMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).StatusMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).StatusMessage = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the dedicated HSM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Name; }

        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the dedicated HSM.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkInterface[] NetworkProfileNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).NetworkProfileNetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).NetworkProfileNetworkInterface = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmProperties _property;

        /// <summary>Properties of the dedicated HSM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.DedicatedHsmProperties()); set => this._property = value; }

        /// <summary>Provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.FormatTable(Index = 1, Label = @"Provisioning State")]
        public Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.JsonWebKeyType? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).ProvisioningState; }

        /// <summary>SKU details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ISku Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Sku = value; }

        /// <summary>SKU of the dedicated HSM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.FormatTable(Index = 2, Label = @"SKU")]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).SkuName = value; }

        /// <summary>This field will be used when RP does not support Availability zones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.DoNotFormat]
        public string StampId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).StampId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).StampId = value; }

        /// <summary>Resource Status Message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.DoNotFormat]
        public string StatusMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).StatusMessage; }

        /// <summary>
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.DoNotFormat]
        public string SubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).SubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmPropertiesInternal)Property).SubnetId = value; }

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Tag = value; }

        /// <summary>The resource type of the dedicated HSM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Type; }

        /// <summary>The Dedicated Hsm zones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.DoNotFormat]
        public string[] Zone { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Zone; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal)__resource).Zone = value; }

        /// <summary>Creates an new <see cref="DedicatedHsm" /> instance.</summary>
        public DedicatedHsm()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Resource information with extended details.
    public partial interface IDedicatedHsm :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResource
    {
        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the dedicated HSM.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the list of resource Ids for the network interfaces associated with the dedicated HSM.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkInterface[] NetworkProfileNetworkInterface { get; set; }
        /// <summary>Provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.JsonWebKeyType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.JsonWebKeyType? ProvisioningState { get;  }
        /// <summary>This field will be used when RP does not support Availability zones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This field will be used when RP does not support Availability zones.",
        SerializedName = @"stampId",
        PossibleTypes = new [] { typeof(string) })]
        string StampId { get; set; }
        /// <summary>Resource Status Message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Status Message.",
        SerializedName = @"statusMessage",
        PossibleTypes = new [] { typeof(string) })]
        string StatusMessage { get;  }
        /// <summary>
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }

    }
    /// Resource information with extended details.
    internal partial interface IDedicatedHsmInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal
    {
        /// <summary>Specifies the network interfaces of the dedicated hsm.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkProfile NetworkProfile { get; set; }
        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the dedicated HSM.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkInterface[] NetworkProfileNetworkInterface { get; set; }
        /// <summary>Specifies the identifier of the subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IApiEntityReference NetworkProfileSubnet { get; set; }
        /// <summary>Properties of the dedicated HSM</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmProperties Property { get; set; }
        /// <summary>Provisioning state.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.JsonWebKeyType? ProvisioningState { get; set; }
        /// <summary>This field will be used when RP does not support Availability zones.</summary>
        string StampId { get; set; }
        /// <summary>Resource Status Message.</summary>
        string StatusMessage { get; set; }
        /// <summary>
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/...
        /// </summary>
        string SubnetId { get; set; }

    }
}