namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMware site usage.</summary>
    public partial class VMwareSiteUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteUsage,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteUsageInternal
    {

        /// <summary>Backing field for <see cref="MachineCount" /> property.</summary>
        private int? _machineCount;

        /// <summary>Number of machines discovered in the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MachineCount { get => this._machineCount; set => this._machineCount = value; }

        /// <summary>Backing field for <see cref="RunAsAccountCount" /> property.</summary>
        private int? _runAsAccountCount;

        /// <summary>Number of run as accounts in the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? RunAsAccountCount { get => this._runAsAccountCount; set => this._runAsAccountCount = value; }

        /// <summary>Backing field for <see cref="VCenterCount" /> property.</summary>
        private int? _vCenterCount;

        /// <summary>Number of vCenters part of the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? VCenterCount { get => this._vCenterCount; set => this._vCenterCount = value; }

        /// <summary>Creates an new <see cref="VMwareSiteUsage" /> instance.</summary>
        public VMwareSiteUsage()
        {

        }
    }
    /// VMware site usage.
    public partial interface IVMwareSiteUsage :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Number of machines discovered in the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of machines discovered in the site.",
        SerializedName = @"machineCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MachineCount { get; set; }
        /// <summary>Number of run as accounts in the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of run as accounts in the site.",
        SerializedName = @"runAsAccountCount",
        PossibleTypes = new [] { typeof(int) })]
        int? RunAsAccountCount { get; set; }
        /// <summary>Number of vCenters part of the site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of vCenters part of the site.",
        SerializedName = @"vCenterCount",
        PossibleTypes = new [] { typeof(int) })]
        int? VCenterCount { get; set; }

    }
    /// VMware site usage.
    internal partial interface IVMwareSiteUsageInternal

    {
        /// <summary>Number of machines discovered in the site.</summary>
        int? MachineCount { get; set; }
        /// <summary>Number of run as accounts in the site.</summary>
        int? RunAsAccountCount { get; set; }
        /// <summary>Number of vCenters part of the site.</summary>
        int? VCenterCount { get; set; }

    }
}