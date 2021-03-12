namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the NSG resource settings.</summary>
    public partial class NetworkSecurityGroupResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INetworkSecurityGroupResourceSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INetworkSecurityGroupResourceSettingsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings __resourceSettings = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettings();

        /// <summary>
        /// The resource type. For example, the value can be Microsoft.Compute/virtualMachines.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string ResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)__resourceSettings).ResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)__resourceSettings).ResourceType = value ; }

        /// <summary>Backing field for <see cref="SecurityRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule[] _securityRule;

        /// <summary>Gets or sets Security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule[] SecurityRule { get => this._securityRule; set => this._securityRule = value; }

        /// <summary>Gets or sets the target Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string TargetResourceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)__resourceSettings).TargetResourceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)__resourceSettings).TargetResourceName = value ; }

        /// <summary>Creates an new <see cref="NetworkSecurityGroupResourceSettings" /> instance.</summary>
        public NetworkSecurityGroupResourceSettings()
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
    /// Defines the NSG resource settings.
    public partial interface INetworkSecurityGroupResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings
    {
        /// <summary>Gets or sets Security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets Security rules of network security group.",
        SerializedName = @"securityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule[] SecurityRule { get; set; }

    }
    /// Defines the NSG resource settings.
    internal partial interface INetworkSecurityGroupResourceSettingsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal
    {
        /// <summary>Gets or sets Security rules of network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule[] SecurityRule { get; set; }

    }
}