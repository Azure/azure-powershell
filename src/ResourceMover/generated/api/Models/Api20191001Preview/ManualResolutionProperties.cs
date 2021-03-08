namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the properties for manual resolution.</summary>
    public partial class ManualResolutionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IManualResolutionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IManualResolutionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="TargetId" /> property.</summary>
        private string _targetId;

        /// <summary>
        /// Gets or sets the target resource ARM ID of the dependent resource if the resource type is Manual.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string TargetId { get => this._targetId; set => this._targetId = value; }

        /// <summary>Creates an new <see cref="ManualResolutionProperties" /> instance.</summary>
        public ManualResolutionProperties()
        {

        }
    }
    /// Defines the properties for manual resolution.
    public partial interface IManualResolutionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets the target resource ARM ID of the dependent resource if the resource type is Manual.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the target resource ARM ID of the dependent resource if the resource type is Manual.",
        SerializedName = @"targetId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetId { get; set; }

    }
    /// Defines the properties for manual resolution.
    internal partial interface IManualResolutionPropertiesInternal

    {
        /// <summary>
        /// Gets or sets the target resource ARM ID of the dependent resource if the resource type is Manual.
        /// </summary>
        string TargetId { get; set; }

    }
}