namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the public IP address resource settings.</summary>
    public partial class PublicIPAddressResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IPublicIPAddressResourceSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IPublicIPAddressResourceSettingsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettings __resourceSettings = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ResourceSettings();

        /// <summary>Backing field for <see cref="DomainNameLabel" /> property.</summary>
        private string _domainNameLabel;

        /// <summary>Gets or sets the domain name label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string DomainNameLabel { get => this._domainNameLabel; set => this._domainNameLabel = value; }

        /// <summary>Backing field for <see cref="FQdn" /> property.</summary>
        private string _fQdn;

        /// <summary>Gets or sets the fully qualified domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string FQdn { get => this._fQdn; set => this._fQdn = value; }

        /// <summary>Backing field for <see cref="PublicIPAllocationMethod" /> property.</summary>
        private string _publicIPAllocationMethod;

        /// <summary>Gets or sets public IP allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string PublicIPAllocationMethod { get => this._publicIPAllocationMethod; set => this._publicIPAllocationMethod = value; }

        /// <summary>
        /// The resource type. For example, the value can be Microsoft.Compute/virtualMachines.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string ResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettingsInternal)__resourceSettings).ResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettingsInternal)__resourceSettings).ResourceType = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private string _sku;

        /// <summary>Gets or sets public IP sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Sku { get => this._sku; set => this._sku = value; }

        /// <summary>Gets or sets the target Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string TargetResourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettingsInternal)__resourceSettings).TargetResourceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettingsInternal)__resourceSettings).TargetResourceName = value; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string _zone;

        /// <summary>Gets or sets public IP zones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Zone { get => this._zone; set => this._zone = value; }

        /// <summary>Creates an new <see cref="PublicIPAddressResourceSettings" /> instance.</summary>
        public PublicIPAddressResourceSettings()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resourceSettings), __resourceSettings);
            await eventListener.AssertObjectIsValid(nameof(__resourceSettings), __resourceSettings);
        }
    }
    /// Defines the public IP address resource settings.
    public partial interface IPublicIPAddressResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettings
    {
        /// <summary>Gets or sets the domain name label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the domain name label.",
        SerializedName = @"domainNameLabel",
        PossibleTypes = new [] { typeof(string) })]
        string DomainNameLabel { get; set; }
        /// <summary>Gets or sets the fully qualified domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the fully qualified domain name.",
        SerializedName = @"fQDN",
        PossibleTypes = new [] { typeof(string) })]
        string FQdn { get; set; }
        /// <summary>Gets or sets public IP allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets public IP allocation method.",
        SerializedName = @"publicIpAllocationMethod",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPAllocationMethod { get; set; }
        /// <summary>Gets or sets public IP sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets public IP sku.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(string) })]
        string Sku { get; set; }
        /// <summary>Gets or sets public IP zones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets public IP zones.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string Zone { get; set; }

    }
    /// Defines the public IP address resource settings.
    internal partial interface IPublicIPAddressResourceSettingsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IResourceSettingsInternal
    {
        /// <summary>Gets or sets the domain name label.</summary>
        string DomainNameLabel { get; set; }
        /// <summary>Gets or sets the fully qualified domain name.</summary>
        string FQdn { get; set; }
        /// <summary>Gets or sets public IP allocation method.</summary>
        string PublicIPAllocationMethod { get; set; }
        /// <summary>Gets or sets public IP sku.</summary>
        string Sku { get; set; }
        /// <summary>Gets or sets public IP zones.</summary>
        string Zone { get; set; }

    }
}