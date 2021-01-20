namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Update protected item input properties.</summary>
    public partial class UpdateReplicationProtectedItemInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="EnableRdpOnTargetOption" /> property.</summary>
        private string _enableRdpOnTargetOption;

        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EnableRdpOnTargetOption { get => this._enableRdpOnTargetOption; set => this._enableRdpOnTargetOption = value; }

        /// <summary>Backing field for <see cref="LicenseType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType? _licenseType;

        /// <summary>License type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType? LicenseType { get => this._licenseType; set => this._licenseType = value; }

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemInputPropertiesInternal.ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdateReplicationProtectedItemProviderInput()); set { {_providerSpecificDetail = value;} } }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInput _providerSpecificDetail;

        /// <summary>The provider specific input to update replication protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInput ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.UpdateReplicationProtectedItemProviderInput()); set => this._providerSpecificDetail = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInputInternal)ProviderSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInputInternal)ProviderSpecificDetail).InstanceType = value ?? null; }

        /// <summary>Backing field for <see cref="RecoveryAvailabilitySetId" /> property.</summary>
        private string _recoveryAvailabilitySetId;

        /// <summary>The target availability set id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAvailabilitySetId { get => this._recoveryAvailabilitySetId; set => this._recoveryAvailabilitySetId = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureVMName" /> property.</summary>
        private string _recoveryAzureVMName;

        /// <summary>Target azure VM name given by the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureVMName { get => this._recoveryAzureVMName; set => this._recoveryAzureVMName = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureVMSize" /> property.</summary>
        private string _recoveryAzureVMSize;

        /// <summary>Target Azure Vm size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureVMSize { get => this._recoveryAzureVMSize; set => this._recoveryAzureVMSize = value; }

        /// <summary>Backing field for <see cref="SelectedRecoveryAzureNetworkId" /> property.</summary>
        private string _selectedRecoveryAzureNetworkId;

        /// <summary>Target Azure Network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SelectedRecoveryAzureNetworkId { get => this._selectedRecoveryAzureNetworkId; set => this._selectedRecoveryAzureNetworkId = value; }

        /// <summary>Backing field for <see cref="SelectedSourceNicId" /> property.</summary>
        private string _selectedSourceNicId;

        /// <summary>
        /// The selected source nic Id which will be used as the primary nic during failover.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SelectedSourceNicId { get => this._selectedSourceNicId; set => this._selectedSourceNicId = value; }

        /// <summary>Backing field for <see cref="VMNic" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicInputDetails[] _vMNic;

        /// <summary>The list of vm nic details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicInputDetails[] VMNic { get => this._vMNic; set => this._vMNic = value; }

        /// <summary>
        /// Creates an new <see cref="UpdateReplicationProtectedItemInputProperties" /> instance.
        /// </summary>
        public UpdateReplicationProtectedItemInputProperties()
        {

        }
    }
    /// Update protected item input properties.
    public partial interface IUpdateReplicationProtectedItemInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption} enum.",
        SerializedName = @"enableRdpOnTargetOption",
        PossibleTypes = new [] { typeof(string) })]
        string EnableRdpOnTargetOption { get; set; }
        /// <summary>License type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"License type.",
        SerializedName = @"licenseType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType? LicenseType { get; set; }
        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>The target availability set id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target availability set id.",
        SerializedName = @"recoveryAvailabilitySetId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAvailabilitySetId { get; set; }
        /// <summary>Target azure VM name given by the user.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target azure VM name given by the user.",
        SerializedName = @"recoveryAzureVMName",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureVMName { get; set; }
        /// <summary>Target Azure Vm size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target Azure Vm size.",
        SerializedName = @"recoveryAzureVMSize",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureVMSize { get; set; }
        /// <summary>Target Azure Network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target Azure Network Id.",
        SerializedName = @"selectedRecoveryAzureNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string SelectedRecoveryAzureNetworkId { get; set; }
        /// <summary>
        /// The selected source nic Id which will be used as the primary nic during failover.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The selected source nic Id which will be used as the primary nic during failover.",
        SerializedName = @"selectedSourceNicId",
        PossibleTypes = new [] { typeof(string) })]
        string SelectedSourceNicId { get; set; }
        /// <summary>The list of vm nic details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of vm nic details.",
        SerializedName = @"vmNics",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicInputDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicInputDetails[] VMNic { get; set; }

    }
    /// Update protected item input properties.
    internal partial interface IUpdateReplicationProtectedItemInputPropertiesInternal

    {
        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        string EnableRdpOnTargetOption { get; set; }
        /// <summary>License type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.LicenseType? LicenseType { get; set; }
        /// <summary>The provider specific input to update replication protected item.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInput ProviderSpecificDetail { get; set; }
        /// <summary>The class type.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }
        /// <summary>The target availability set id.</summary>
        string RecoveryAvailabilitySetId { get; set; }
        /// <summary>Target azure VM name given by the user.</summary>
        string RecoveryAzureVMName { get; set; }
        /// <summary>Target Azure Vm size.</summary>
        string RecoveryAzureVMSize { get; set; }
        /// <summary>Target Azure Network Id.</summary>
        string SelectedRecoveryAzureNetworkId { get; set; }
        /// <summary>
        /// The selected source nic Id which will be used as the primary nic during failover.
        /// </summary>
        string SelectedSourceNicId { get; set; }
        /// <summary>The list of vm nic details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicInputDetails[] VMNic { get; set; }

    }
}