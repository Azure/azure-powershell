namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>List Restore Ranges Response</summary>
    public partial class AzureBackupFindRestorableTimeRangesResponse :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupFindRestorableTimeRangesResponse,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IAzureBackupFindRestorableTimeRangesResponseInternal
    {

        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Backing field for <see cref="RestorableTimeRange" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestorableTimeRange[] _restorableTimeRange;

        /// <summary>Returns the Restore Ranges available on the Backup Instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestorableTimeRange[] RestorableTimeRange { get => this._restorableTimeRange; set => this._restorableTimeRange = value; }

        /// <summary>
        /// Creates an new <see cref="AzureBackupFindRestorableTimeRangesResponse" /> instance.
        /// </summary>
        public AzureBackupFindRestorableTimeRangesResponse()
        {

        }
    }
    /// List Restore Ranges Response
    public partial interface IAzureBackupFindRestorableTimeRangesResponse :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }
        /// <summary>Returns the Restore Ranges available on the Backup Instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Returns the Restore Ranges available on the Backup Instance.",
        SerializedName = @"restorableTimeRanges",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestorableTimeRange) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestorableTimeRange[] RestorableTimeRange { get; set; }

    }
    /// List Restore Ranges Response
    internal partial interface IAzureBackupFindRestorableTimeRangesResponseInternal

    {
        string ObjectType { get; set; }
        /// <summary>Returns the Restore Ranges available on the Backup Instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IRestorableTimeRange[] RestorableTimeRange { get; set; }

    }
}