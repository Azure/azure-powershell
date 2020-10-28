namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the properties for automatic resolution.</summary>
    public partial class AutomaticResolutionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAutomaticResolutionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAutomaticResolutionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="MoveResourceId" /> property.</summary>
        private string _moveResourceId;

        /// <summary>
        /// Gets the MoveResource ARM ID of
        /// the dependent resource if the resolution type is Automatic.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string MoveResourceId { get => this._moveResourceId; set => this._moveResourceId = value; }

        /// <summary>Creates an new <see cref="AutomaticResolutionProperties" /> instance.</summary>
        public AutomaticResolutionProperties()
        {

        }
    }
    /// Defines the properties for automatic resolution.
    public partial interface IAutomaticResolutionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets the MoveResource ARM ID of
        /// the dependent resource if the resolution type is Automatic.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the MoveResource ARM ID of
        the dependent resource if the resolution type is Automatic.",
        SerializedName = @"moveResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string MoveResourceId { get; set; }

    }
    /// Defines the properties for automatic resolution.
    internal partial interface IAutomaticResolutionPropertiesInternal

    {
        /// <summary>
        /// Gets the MoveResource ARM ID of
        /// the dependent resource if the resolution type is Automatic.
        /// </summary>
        string MoveResourceId { get; set; }

    }
}