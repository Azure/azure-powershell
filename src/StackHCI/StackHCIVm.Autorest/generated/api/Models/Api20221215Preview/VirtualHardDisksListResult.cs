namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    public partial class VirtualHardDisksListResult :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisksListResult,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisksListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisks[] _value;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisks[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="VirtualHardDisksListResult" /> instance.</summary>
        public VirtualHardDisksListResult()
        {

        }
    }
    public partial interface IVirtualHardDisksListResult :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisks) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisks[] Value { get; set; }

    }
    internal partial interface IVirtualHardDisksListResultInternal

    {
        string NextLink { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualHardDisks[] Value { get; set; }

    }
}