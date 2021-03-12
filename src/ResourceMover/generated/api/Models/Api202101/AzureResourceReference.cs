namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines reference to an Azure resource.</summary>
    public partial class AzureResourceReference :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReference,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReferenceInternal
    {

        /// <summary>Backing field for <see cref="SourceArmResourceId" /> property.</summary>
        private string _sourceArmResourceId;

        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string SourceArmResourceId { get => this._sourceArmResourceId; set => this._sourceArmResourceId = value; }

        /// <summary>Creates an new <see cref="AzureResourceReference" /> instance.</summary>
        public AzureResourceReference()
        {

        }
    }
    /// Defines reference to an Azure resource.
    public partial interface IAzureResourceReference :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets the ARM resource ID of the tracked resource being referenced.",
        SerializedName = @"sourceArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceArmResourceId { get; set; }

    }
    /// Defines reference to an Azure resource.
    internal partial interface IAzureResourceReferenceInternal

    {
        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        string SourceArmResourceId { get; set; }

    }
}