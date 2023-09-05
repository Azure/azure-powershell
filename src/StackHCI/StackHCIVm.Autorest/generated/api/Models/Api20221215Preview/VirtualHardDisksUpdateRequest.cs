namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>The virtual hard disk resource patch definition.</summary>
    public partial class VirtualHardDisksUpdateRequest :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisksUpdateRequest,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisksUpdateRequestInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisksUpdateRequestTags _tag;

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisksUpdateRequestTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualHardDisksUpdateRequestTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="VirtualHardDisksUpdateRequest" /> instance.</summary>
        public VirtualHardDisksUpdateRequest()
        {

        }
    }
    /// The virtual hard disk resource patch definition.
    public partial interface IVirtualHardDisksUpdateRequest :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisksUpdateRequestTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisksUpdateRequestTags Tag { get; set; }

    }
    /// The virtual hard disk resource patch definition.
    internal partial interface IVirtualHardDisksUpdateRequestInternal

    {
        /// <summary>Resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisksUpdateRequestTags Tag { get; set; }

    }
}