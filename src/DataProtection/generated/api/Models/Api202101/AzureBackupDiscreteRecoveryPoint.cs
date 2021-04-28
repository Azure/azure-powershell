namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Azure backup discrete RecoveryPoint</summary>
    public partial class AzureBackupDiscreteRecoveryPoint :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupDiscreteRecoveryPoint,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupDiscreteRecoveryPointInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryPoint"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryPoint __azureBackupRecoveryPoint = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupRecoveryPoint();

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryPointInternal)__azureBackupRecoveryPoint).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryPointInternal)__azureBackupRecoveryPoint).ObjectType = value ; }

        /// <summary>Backing field for <see cref="PolicyName" /> property.</summary>
        private string _policyName;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string PolicyName { get => this._policyName; set => this._policyName = value; }

        /// <summary>Backing field for <see cref="PolicyVersion" /> property.</summary>
        private string _policyVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string PolicyVersion { get => this._policyVersion; set => this._policyVersion = value; }

        /// <summary>Backing field for <see cref="RecoveryPointDataStoresDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRecoveryPointDataStoreDetails[] _recoveryPointDataStoresDetail;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRecoveryPointDataStoreDetails[] RecoveryPointDataStoresDetail { get => this._recoveryPointDataStoresDetail; set => this._recoveryPointDataStoresDetail = value; }

        /// <summary>Backing field for <see cref="RecoveryPointId" /> property.</summary>
        private string _recoveryPointId;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RecoveryPointId { get => this._recoveryPointId; set => this._recoveryPointId = value; }

        /// <summary>Backing field for <see cref="RecoveryPointTime" /> property.</summary>
        private global::System.DateTime _recoveryPointTime;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public global::System.DateTime RecoveryPointTime { get => this._recoveryPointTime; set => this._recoveryPointTime = value; }

        /// <summary>Backing field for <see cref="RecoveryPointType" /> property.</summary>
        private string _recoveryPointType;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RecoveryPointType { get => this._recoveryPointType; set => this._recoveryPointType = value; }

        /// <summary>Backing field for <see cref="RetentionTagName" /> property.</summary>
        private string _retentionTagName;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RetentionTagName { get => this._retentionTagName; set => this._retentionTagName = value; }

        /// <summary>Backing field for <see cref="RetentionTagVersion" /> property.</summary>
        private string _retentionTagVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string RetentionTagVersion { get => this._retentionTagVersion; set => this._retentionTagVersion = value; }

        /// <summary>Creates an new <see cref="AzureBackupDiscreteRecoveryPoint" /> instance.</summary>
        public AzureBackupDiscreteRecoveryPoint()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__azureBackupRecoveryPoint), __azureBackupRecoveryPoint);
            await eventListener.AssertObjectIsValid(nameof(__azureBackupRecoveryPoint), __azureBackupRecoveryPoint);
        }
    }
    /// Azure backup discrete RecoveryPoint
    public partial interface IAzureBackupDiscreteRecoveryPoint :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryPoint
    {
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"policyName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"policyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyVersion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"recoveryPointDataStoresDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRecoveryPointDataStoreDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRecoveryPointDataStoreDetails[] RecoveryPointDataStoresDetail { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"recoveryPointId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryPointId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"recoveryPointTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime RecoveryPointTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"recoveryPointType",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryPointType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"retentionTagName",
        PossibleTypes = new [] { typeof(string) })]
        string RetentionTagName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"retentionTagVersion",
        PossibleTypes = new [] { typeof(string) })]
        string RetentionTagVersion { get; set; }

    }
    /// Azure backup discrete RecoveryPoint
    internal partial interface IAzureBackupDiscreteRecoveryPointInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupRecoveryPointInternal
    {
        string FriendlyName { get; set; }

        string PolicyName { get; set; }

        string PolicyVersion { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRecoveryPointDataStoreDetails[] RecoveryPointDataStoresDetail { get; set; }

        string RecoveryPointId { get; set; }

        global::System.DateTime RecoveryPointTime { get; set; }

        string RecoveryPointType { get; set; }

        string RetentionTagName { get; set; }

        string RetentionTagVersion { get; set; }

    }
}