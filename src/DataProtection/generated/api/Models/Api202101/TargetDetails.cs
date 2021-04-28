namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>
    /// Class encapsulating target details, used where the destination is not a datasource
    /// </summary>
    public partial class TargetDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITargetDetails,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITargetDetailsInternal
    {

        /// <summary>Backing field for <see cref="FilePrefix" /> property.</summary>
        private string _filePrefix;

        /// <summary>
        /// Restore operation may create multiple files inside location pointed by Url
        /// Below will be the common prefix for all of them
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string FilePrefix { get => this._filePrefix; set => this._filePrefix = value; }

        /// <summary>Backing field for <see cref="RestoreTargetLocationType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetLocationType _restoreTargetLocationType;

        /// <summary>
        /// Denotes the target location where the data will be restored,
        /// string value for the enum {Microsoft.Internal.AzureBackup.DataProtection.Common.Interface.RestoreTargetLocationType}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetLocationType RestoreTargetLocationType { get => this._restoreTargetLocationType; set => this._restoreTargetLocationType = value; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>
        /// Url denoting the restore destination. It can point to container / file share etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Creates an new <see cref="TargetDetails" /> instance.</summary>
        public TargetDetails()
        {

        }
    }
    /// Class encapsulating target details, used where the destination is not a datasource
    public partial interface ITargetDetails :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Restore operation may create multiple files inside location pointed by Url
        /// Below will be the common prefix for all of them
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Restore operation may create multiple files inside location pointed by Url
        Below will be the common prefix for all of them",
        SerializedName = @"filePrefix",
        PossibleTypes = new [] { typeof(string) })]
        string FilePrefix { get; set; }
        /// <summary>
        /// Denotes the target location where the data will be restored,
        /// string value for the enum {Microsoft.Internal.AzureBackup.DataProtection.Common.Interface.RestoreTargetLocationType}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Denotes the target location where the data will be restored,
        string value for the enum {Microsoft.Internal.AzureBackup.DataProtection.Common.Interface.RestoreTargetLocationType}",
        SerializedName = @"restoreTargetLocationType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetLocationType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetLocationType RestoreTargetLocationType { get; set; }
        /// <summary>
        /// Url denoting the restore destination. It can point to container / file share etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Url denoting the restore destination. It can point to container / file share etc",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }

    }
    /// Class encapsulating target details, used where the destination is not a datasource
    internal partial interface ITargetDetailsInternal

    {
        /// <summary>
        /// Restore operation may create multiple files inside location pointed by Url
        /// Below will be the common prefix for all of them
        /// </summary>
        string FilePrefix { get; set; }
        /// <summary>
        /// Denotes the target location where the data will be restored,
        /// string value for the enum {Microsoft.Internal.AzureBackup.DataProtection.Common.Interface.RestoreTargetLocationType}
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.RestoreTargetLocationType RestoreTargetLocationType { get; set; }
        /// <summary>
        /// Url denoting the restore destination. It can point to container / file share etc
        /// </summary>
        string Url { get; set; }

    }
}