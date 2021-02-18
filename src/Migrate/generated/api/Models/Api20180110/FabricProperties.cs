namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Fabric properties.</summary>
    public partial class FabricProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BcdrState" /> property.</summary>
        private string _bcdrState;

        /// <summary>BCDR state of the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string BcdrState { get => this._bcdrState; set => this._bcdrState = value; }

        /// <summary>Backing field for <see cref="CustomDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails _customDetail;

        /// <summary>Fabric specific settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificDetails()); set => this._customDetail = value; }

        /// <summary>Backing field for <see cref="EncryptionDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails _encryptionDetail;

        /// <summary>Encryption details for the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails EncryptionDetail { get => (this._encryptionDetail = this._encryptionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EncryptionDetails()); set => this._encryptionDetail = value; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Friendly name of the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="Health" /> property.</summary>
        private string _health;

        /// <summary>Health of fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Health { get => this._health; set => this._health = value; }

        /// <summary>Backing field for <see cref="HealthErrorDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] _healthErrorDetail;

        /// <summary>Fabric health error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthErrorDetail { get => this._healthErrorDetail; set => this._healthErrorDetail = value; }

        /// <summary>Backing field for <see cref="InternalIdentifier" /> property.</summary>
        private string _internalIdentifier;

        /// <summary>Dra Registration Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InternalIdentifier { get => this._internalIdentifier; set => this._internalIdentifier = value; }

        /// <summary>Backing field for <see cref="RolloverEncryptionDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails _rolloverEncryptionDetail;

        /// <summary>Rollover encryption details for the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails RolloverEncryptionDetail { get => (this._rolloverEncryptionDetail = this._rolloverEncryptionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EncryptionDetails()); set => this._rolloverEncryptionDetail = value; }

        /// <summary>Creates an new <see cref="FabricProperties" /> instance.</summary>
        public FabricProperties()
        {

        }
    }
    /// Fabric properties.
    public partial interface IFabricProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>BCDR state of the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"BCDR state of the fabric.",
        SerializedName = @"bcdrState",
        PossibleTypes = new [] { typeof(string) })]
        string BcdrState { get; set; }
        /// <summary>Fabric specific settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fabric specific settings.",
        SerializedName = @"customDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails CustomDetail { get; set; }
        /// <summary>Encryption details for the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Encryption details for the fabric.",
        SerializedName = @"encryptionDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails EncryptionDetail { get; set; }
        /// <summary>Friendly name of the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of the fabric.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>Health of fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Health of fabric.",
        SerializedName = @"health",
        PossibleTypes = new [] { typeof(string) })]
        string Health { get; set; }
        /// <summary>Fabric health error details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fabric health error details.",
        SerializedName = @"healthErrorDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthErrorDetail { get; set; }
        /// <summary>Dra Registration Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dra Registration Id.",
        SerializedName = @"internalIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string InternalIdentifier { get; set; }
        /// <summary>Rollover encryption details for the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Rollover encryption details for the fabric.",
        SerializedName = @"rolloverEncryptionDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails RolloverEncryptionDetail { get; set; }

    }
    /// Fabric properties.
    internal partial interface IFabricPropertiesInternal

    {
        /// <summary>BCDR state of the fabric.</summary>
        string BcdrState { get; set; }
        /// <summary>Fabric specific settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails CustomDetail { get; set; }
        /// <summary>Encryption details for the fabric.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails EncryptionDetail { get; set; }
        /// <summary>Friendly name of the fabric.</summary>
        string FriendlyName { get; set; }
        /// <summary>Health of fabric.</summary>
        string Health { get; set; }
        /// <summary>Fabric health error details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] HealthErrorDetail { get; set; }
        /// <summary>Dra Registration Id.</summary>
        string InternalIdentifier { get; set; }
        /// <summary>Rollover encryption details for the fabric.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails RolloverEncryptionDetail { get; set; }

    }
}