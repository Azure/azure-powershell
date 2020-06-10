namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Response containing status for a specific purge operation.</summary>
    public partial class ComponentPurgeStatusResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeStatusResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeStatusResponseInternal
    {

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PurgeState _status;

        /// <summary>Status of the operation represented by the requested Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PurgeState Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="ComponentPurgeStatusResponse" /> instance.</summary>
        public ComponentPurgeStatusResponse()
        {

        }
    }
    /// Response containing status for a specific purge operation.
    public partial interface IComponentPurgeStatusResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Status of the operation represented by the requested Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Status of the operation represented by the requested Id.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PurgeState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PurgeState Status { get; set; }

    }
    /// Response containing status for a specific purge operation.
    internal partial interface IComponentPurgeStatusResponseInternal

    {
        /// <summary>Status of the operation represented by the requested Id.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PurgeState Status { get; set; }

    }
}