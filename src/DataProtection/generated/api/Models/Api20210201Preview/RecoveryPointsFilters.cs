namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    public partial class RecoveryPointsFilters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRecoveryPointsFilters,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRecoveryPointsFiltersInternal
    {

        /// <summary>Backing field for <see cref="EndDate" /> property.</summary>
        private string _endDate;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string EndDate { get => this._endDate; set => this._endDate = value; }

        /// <summary>Backing field for <see cref="ExtendedInfo" /> property.</summary>
        private bool? _extendedInfo;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool? ExtendedInfo { get => this._extendedInfo; set => this._extendedInfo = value; }

        /// <summary>Backing field for <see cref="IsVisible" /> property.</summary>
        private bool? _isVisible;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool? IsVisible { get => this._isVisible; set => this._isVisible = value; }

        /// <summary>Backing field for <see cref="RestorePointDataStoreId" /> property.</summary>
        private string _restorePointDataStoreId;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RestorePointDataStoreId { get => this._restorePointDataStoreId; set => this._restorePointDataStoreId = value; }

        /// <summary>Backing field for <see cref="RestorePointState" /> property.</summary>
        private string _restorePointState;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RestorePointState { get => this._restorePointState; set => this._restorePointState = value; }

        /// <summary>Backing field for <see cref="StartDate" /> property.</summary>
        private string _startDate;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string StartDate { get => this._startDate; set => this._startDate = value; }

        /// <summary>Creates an new <see cref="RecoveryPointsFilters" /> instance.</summary>
        public RecoveryPointsFilters()
        {

        }
    }
    public partial interface IRecoveryPointsFilters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"endDate",
        PossibleTypes = new [] { typeof(string) })]
        string EndDate { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"extendedInfo",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ExtendedInfo { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"isVisible",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsVisible { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"restorePointDataStoreId",
        PossibleTypes = new [] { typeof(string) })]
        string RestorePointDataStoreId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"restorePointState",
        PossibleTypes = new [] { typeof(string) })]
        string RestorePointState { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"startDate",
        PossibleTypes = new [] { typeof(string) })]
        string StartDate { get; set; }

    }
    internal partial interface IRecoveryPointsFiltersInternal

    {
        string EndDate { get; set; }

        bool? ExtendedInfo { get; set; }

        bool? IsVisible { get; set; }

        string RestorePointDataStoreId { get; set; }

        string RestorePointState { get; set; }

        string StartDate { get; set; }

    }
}