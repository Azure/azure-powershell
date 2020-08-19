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
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificDetails()); set => this._customDetail = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)CustomDetail).InstanceType; }

        /// <summary>Backing field for <see cref="EncryptionDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails _encryptionDetail;

        /// <summary>Encryption details for the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails EncryptionDetail { get => (this._encryptionDetail = this._encryptionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EncryptionDetails()); set => this._encryptionDetail = value; }

        /// <summary>The key encryption key certificate expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? EncryptionDetailKekCertExpiryDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)EncryptionDetail).KekCertExpiryDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)EncryptionDetail).KekCertExpiryDate = value; }

        /// <summary>The key encryption key certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string EncryptionDetailKekCertThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)EncryptionDetail).KekCertThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)EncryptionDetail).KekCertThumbprint = value; }

        /// <summary>The key encryption key state for the Vmm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string EncryptionDetailKekState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)EncryptionDetail).KekState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)EncryptionDetail).KekState = value; }

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

        /// <summary>Internal Acessors for CustomDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal.CustomDetail { get => (this._customDetail = this._customDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificDetails()); set { {_customDetail = value;} } }

        /// <summary>Internal Acessors for CustomDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal.CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)CustomDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)CustomDetail).InstanceType = value; }

        /// <summary>Internal Acessors for EncryptionDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal.EncryptionDetail { get => (this._encryptionDetail = this._encryptionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EncryptionDetails()); set { {_encryptionDetail = value;} } }

        /// <summary>Internal Acessors for RolloverEncryptionDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal.RolloverEncryptionDetail { get => (this._rolloverEncryptionDetail = this._rolloverEncryptionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EncryptionDetails()); set { {_rolloverEncryptionDetail = value;} } }

        /// <summary>Backing field for <see cref="RolloverEncryptionDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails _rolloverEncryptionDetail;

        /// <summary>Rollover encryption details for the fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails RolloverEncryptionDetail { get => (this._rolloverEncryptionDetail = this._rolloverEncryptionDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EncryptionDetails()); set => this._rolloverEncryptionDetail = value; }

        /// <summary>The key encryption key certificate expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? RolloverEncryptionDetailKekCertExpiryDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)RolloverEncryptionDetail).KekCertExpiryDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)RolloverEncryptionDetail).KekCertExpiryDate = value; }

        /// <summary>The key encryption key certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RolloverEncryptionDetailKekCertThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)RolloverEncryptionDetail).KekCertThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)RolloverEncryptionDetail).KekCertThumbprint = value; }

        /// <summary>The key encryption key state for the Vmm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RolloverEncryptionDetailKekState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)RolloverEncryptionDetail).KekState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetailsInternal)RolloverEncryptionDetail).KekState = value; }

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
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the class type. Overridden in derived classes.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDetailInstanceType { get;  }
        /// <summary>The key encryption key certificate expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key encryption key certificate expiry date.",
        SerializedName = @"kekCertExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EncryptionDetailKekCertExpiryDate { get; set; }
        /// <summary>The key encryption key certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key encryption key certificate thumbprint.",
        SerializedName = @"kekCertThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string EncryptionDetailKekCertThumbprint { get; set; }
        /// <summary>The key encryption key state for the Vmm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key encryption key state for the Vmm.",
        SerializedName = @"kekState",
        PossibleTypes = new [] { typeof(string) })]
        string EncryptionDetailKekState { get; set; }
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
        /// <summary>The key encryption key certificate expiry date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key encryption key certificate expiry date.",
        SerializedName = @"kekCertExpiryDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RolloverEncryptionDetailKekCertExpiryDate { get; set; }
        /// <summary>The key encryption key certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key encryption key certificate thumbprint.",
        SerializedName = @"kekCertThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string RolloverEncryptionDetailKekCertThumbprint { get; set; }
        /// <summary>The key encryption key state for the Vmm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The key encryption key state for the Vmm.",
        SerializedName = @"kekState",
        PossibleTypes = new [] { typeof(string) })]
        string RolloverEncryptionDetailKekState { get; set; }

    }
    /// Fabric properties.
    internal partial interface IFabricPropertiesInternal

    {
        /// <summary>BCDR state of the fabric.</summary>
        string BcdrState { get; set; }
        /// <summary>Fabric specific settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails CustomDetail { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        string CustomDetailInstanceType { get; set; }
        /// <summary>Encryption details for the fabric.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails EncryptionDetail { get; set; }
        /// <summary>The key encryption key certificate expiry date.</summary>
        global::System.DateTime? EncryptionDetailKekCertExpiryDate { get; set; }
        /// <summary>The key encryption key certificate thumbprint.</summary>
        string EncryptionDetailKekCertThumbprint { get; set; }
        /// <summary>The key encryption key state for the Vmm.</summary>
        string EncryptionDetailKekState { get; set; }
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
        /// <summary>The key encryption key certificate expiry date.</summary>
        global::System.DateTime? RolloverEncryptionDetailKekCertExpiryDate { get; set; }
        /// <summary>The key encryption key certificate thumbprint.</summary>
        string RolloverEncryptionDetailKekCertThumbprint { get; set; }
        /// <summary>The key encryption key state for the Vmm.</summary>
        string RolloverEncryptionDetailKekState { get; set; }

    }
}