namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Enterprise Channel resource definition</summary>
    public partial class EnterpriseChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Resource();

        /// <summary>Entity Tag</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Etag { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Etag = value ?? null; }

        /// <summary>Specifies the resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Id; }

        /// <summary>Required. Gets or sets the Kind of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Kind? Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Kind = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Kind)""); }

        /// <summary>Specifies the location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.EnterpriseChannelProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for SkuTier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier? Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal.SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).SkuTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).SkuTier = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Type = value; }

        /// <summary>Specifies the name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Name; }

        /// <summary>The nodes associated with the Enterprise Channel.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode[] Node { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)Property).Node; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)Property).Node = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelProperties _property;

        /// <summary>The set of properties specific to an Enterprise Channel resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.EnterpriseChannelProperties()); set => this._property = value; }

        /// <summary>Gets or sets the SKU of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISku Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Sku = value ?? null /* model class */; }

        /// <summary>The sku name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).SkuName = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName)""); }

        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier? SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).SkuTier; }

        /// <summary>The current state of the Enterprise Channel.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState? State { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)Property).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)Property).State = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState)""); }

        /// <summary>Contains resource tags defined as key/value pairs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Tag = value ?? null /* model class */; }

        /// <summary>Specifies the type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="EnterpriseChannel" /> instance.</summary>
        public EnterpriseChannel()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Enterprise Channel resource definition
    public partial interface IEnterpriseChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResource
    {
        /// <summary>The nodes associated with the Enterprise Channel.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The nodes associated with the Enterprise Channel.",
        SerializedName = @"nodes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode[] Node { get; set; }
        /// <summary>The current state of the Enterprise Channel.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The current state of the Enterprise Channel.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState? State { get; set; }

    }
    /// Enterprise Channel resource definition
    internal partial interface IEnterpriseChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal
    {
        /// <summary>The nodes associated with the Enterprise Channel.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode[] Node { get; set; }
        /// <summary>The set of properties specific to an Enterprise Channel resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelProperties Property { get; set; }
        /// <summary>The current state of the Enterprise Channel.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState? State { get; set; }

    }
}