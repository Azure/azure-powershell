namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Describes the Power State of the cluster</summary>
    public partial class PowerState :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerStateInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? _code;

        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? Code { get => this._code; set => this._code = value; }

        /// <summary>Creates an new <see cref="PowerState" /> instance.</summary>
        public PowerState()
        {

        }
    }
    /// Describes the Power State of the cluster
    public partial interface IPowerState :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tells whether the cluster is Running or Stopped",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? Code { get; set; }

    }
    /// Describes the Power State of the cluster
    internal partial interface IPowerStateInternal

    {
        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? Code { get; set; }

    }
}