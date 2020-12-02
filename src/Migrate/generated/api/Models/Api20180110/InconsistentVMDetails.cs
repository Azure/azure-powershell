namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// This class stores the monitoring details for consistency check of inconsistent Protected Entity.
    /// </summary>
    public partial class InconsistentVMDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInconsistentVMDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInconsistentVMDetailsInternal
    {

        /// <summary>Backing field for <see cref="CloudName" /> property.</summary>
        private string _cloudName;

        /// <summary>The Cloud name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CloudName { get => this._cloudName; set => this._cloudName = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private string[] _detail;

        /// <summary>The list of details regarding state of the Protected Entity in SRS and On prem.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="ErrorId" /> property.</summary>
        private string[] _errorId;

        /// <summary>The list of error ids.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] ErrorId { get => this._errorId; set => this._errorId = value; }

        /// <summary>Backing field for <see cref="VMName" /> property.</summary>
        private string _vMName;

        /// <summary>The Vm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VMName { get => this._vMName; set => this._vMName = value; }

        /// <summary>Creates an new <see cref="InconsistentVMDetails" /> instance.</summary>
        public InconsistentVMDetails()
        {

        }
    }
    /// This class stores the monitoring details for consistency check of inconsistent Protected Entity.
    public partial interface IInconsistentVMDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The Cloud name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Cloud name.",
        SerializedName = @"cloudName",
        PossibleTypes = new [] { typeof(string) })]
        string CloudName { get; set; }
        /// <summary>The list of details regarding state of the Protected Entity in SRS and On prem.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of details regarding state of the Protected Entity in SRS and On prem.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(string) })]
        string[] Detail { get; set; }
        /// <summary>The list of error ids.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of error ids.",
        SerializedName = @"errorIds",
        PossibleTypes = new [] { typeof(string) })]
        string[] ErrorId { get; set; }
        /// <summary>The Vm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Vm name.",
        SerializedName = @"vmName",
        PossibleTypes = new [] { typeof(string) })]
        string VMName { get; set; }

    }
    /// This class stores the monitoring details for consistency check of inconsistent Protected Entity.
    internal partial interface IInconsistentVMDetailsInternal

    {
        /// <summary>The Cloud name.</summary>
        string CloudName { get; set; }
        /// <summary>The list of details regarding state of the Protected Entity in SRS and On prem.</summary>
        string[] Detail { get; set; }
        /// <summary>The list of error ids.</summary>
        string[] ErrorId { get; set; }
        /// <summary>The Vm name.</summary>
        string VMName { get; set; }

    }
}