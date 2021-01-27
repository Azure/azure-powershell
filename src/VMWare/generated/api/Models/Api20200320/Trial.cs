namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>Subscription trial availability</summary>
    public partial class Trial :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ITrial,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ITrialInternal
    {

        /// <summary>Backing field for <see cref="AvailableHost" /> property.</summary>
        private int? _availableHost;

        /// <summary>Number of trial hosts available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public int? AvailableHost { get => this._availableHost; }

        /// <summary>Internal Acessors for AvailableHost</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ITrialInternal.AvailableHost { get => this._availableHost; set { {_availableHost = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.TrialStatus? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ITrialInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.TrialStatus? _status;

        /// <summary>Trial status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.TrialStatus? Status { get => this._status; }

        /// <summary>Creates an new <see cref="Trial" /> instance.</summary>
        public Trial()
        {

        }
    }
    /// Subscription trial availability
    public partial interface ITrial :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>Number of trial hosts available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of trial hosts available",
        SerializedName = @"availableHosts",
        PossibleTypes = new [] { typeof(int) })]
        int? AvailableHost { get;  }
        /// <summary>Trial status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Trial status",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.TrialStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.TrialStatus? Status { get;  }

    }
    /// Subscription trial availability
    internal partial interface ITrialInternal

    {
        /// <summary>Number of trial hosts available</summary>
        int? AvailableHost { get; set; }
        /// <summary>Trial status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.TrialStatus? Status { get; set; }

    }
}