namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>The properties of a Solution that can be patched.</summary>
    public partial class SolutionPatch :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPatch,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPatchInternal
    {

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPatchTags _tag;

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPatchTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.SolutionPatchTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="SolutionPatch" /> instance.</summary>
        public SolutionPatch()
        {

        }
    }
    /// The properties of a Solution that can be patched.
    public partial interface ISolutionPatch :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.IJsonSerializable
    {
        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPatchTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPatchTags Tag { get; set; }

    }
    /// The properties of a Solution that can be patched.
    internal partial interface ISolutionPatchInternal

    {
        /// <summary>Resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPatchTags Tag { get; set; }

    }
}