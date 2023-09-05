namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Object containing updates for patch operations.</summary>
    public partial class ResourcePatch :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IResourcePatch,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IResourcePatchInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IResourcePatchTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IResourcePatchTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.ResourcePatchTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="ResourcePatch" /> instance.</summary>
        public ResourcePatch()
        {

        }
    }
    /// Object containing updates for patch operations.
    public partial interface IResourcePatch :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IResourcePatchTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IResourcePatchTags Tag { get; set; }

    }
    /// Object containing updates for patch operations.
    internal partial interface IResourcePatchInternal

    {
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IResourcePatchTags Tag { get; set; }

    }
}