namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>class to define the health summary of the Vault.</summary>
    public partial class VaultHealthProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal
    {

        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ContainerHealthCategorizedResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ContainersHealth).CategorizedResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ContainersHealth).CategorizedResourceCount = value ?? null /* model class */; }

        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ContainerHealthIssue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ContainersHealth).Issue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ContainersHealth).Issue = value ?? null /* arrayOf */; }

        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? ContainerHealthResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ContainersHealth).ResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ContainersHealth).ResourceCount = value ?? default(int); }

        /// <summary>Backing field for <see cref="ContainersHealth" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary _containersHealth;

        /// <summary>The list of the health detail of the containers in the vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary ContainersHealth { get => (this._containersHealth = this._containersHealth ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummary()); set => this._containersHealth = value; }

        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts FabricHealthCategorizedResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)FabricsHealth).CategorizedResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)FabricsHealth).CategorizedResourceCount = value ?? null /* model class */; }

        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] FabricHealthIssue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)FabricsHealth).Issue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)FabricsHealth).Issue = value ?? null /* arrayOf */; }

        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? FabricHealthResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)FabricsHealth).ResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)FabricsHealth).ResourceCount = value ?? default(int); }

        /// <summary>Backing field for <see cref="FabricsHealth" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary _fabricsHealth;

        /// <summary>The list of the health detail of the fabrics in the vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary FabricsHealth { get => (this._fabricsHealth = this._fabricsHealth ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummary()); set => this._fabricsHealth = value; }

        /// <summary>Internal Acessors for ContainersHealth</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal.ContainersHealth { get => (this._containersHealth = this._containersHealth ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummary()); set { {_containersHealth = value;} } }

        /// <summary>Internal Acessors for FabricsHealth</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal.FabricsHealth { get => (this._fabricsHealth = this._fabricsHealth ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummary()); set { {_fabricsHealth = value;} } }

        /// <summary>Internal Acessors for ProtectedItemsHealth</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVaultHealthPropertiesInternal.ProtectedItemsHealth { get => (this._protectedItemsHealth = this._protectedItemsHealth ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummary()); set { {_protectedItemsHealth = value;} } }

        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ProtectedItemHealthCategorizedResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ProtectedItemsHealth).CategorizedResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ProtectedItemsHealth).CategorizedResourceCount = value ?? null /* model class */; }

        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ProtectedItemHealthIssue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ProtectedItemsHealth).Issue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ProtectedItemsHealth).Issue = value ?? null /* arrayOf */; }

        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? ProtectedItemHealthResourceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ProtectedItemsHealth).ResourceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryInternal)ProtectedItemsHealth).ResourceCount = value ?? default(int); }

        /// <summary>Backing field for <see cref="ProtectedItemsHealth" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary _protectedItemsHealth;

        /// <summary>The list of the health detail of the protected items in the vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary ProtectedItemsHealth { get => (this._protectedItemsHealth = this._protectedItemsHealth ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ResourceHealthSummary()); set => this._protectedItemsHealth = value; }

        /// <summary>Backing field for <see cref="VaultError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] _vaultError;

        /// <summary>The list of errors on the vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] VaultError { get => this._vaultError; set => this._vaultError = value; }

        /// <summary>Creates an new <see cref="VaultHealthProperties" /> instance.</summary>
        public VaultHealthProperties()
        {

        }
    }
    /// class to define the health summary of the Vault.
    public partial interface IVaultHealthProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The categorized resource counts.",
        SerializedName = @"categorizedResourceCounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ContainerHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of summary of health errors across the resources under the container.",
        SerializedName = @"issues",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ContainerHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of total resources under the container.",
        SerializedName = @"resourceCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ContainerHealthResourceCount { get; set; }
        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The categorized resource counts.",
        SerializedName = @"categorizedResourceCounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts FabricHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of summary of health errors across the resources under the container.",
        SerializedName = @"issues",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] FabricHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of total resources under the container.",
        SerializedName = @"resourceCount",
        PossibleTypes = new [] { typeof(int) })]
        int? FabricHealthResourceCount { get; set; }
        /// <summary>The categorized resource counts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The categorized resource counts.",
        SerializedName = @"categorizedResourceCounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ProtectedItemHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of summary of health errors across the resources under the container.",
        SerializedName = @"issues",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ProtectedItemHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The count of total resources under the container.",
        SerializedName = @"resourceCount",
        PossibleTypes = new [] { typeof(int) })]
        int? ProtectedItemHealthResourceCount { get; set; }
        /// <summary>The list of errors on the vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of errors on the vault.",
        SerializedName = @"vaultErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] VaultError { get; set; }

    }
    /// class to define the health summary of the Vault.
    internal partial interface IVaultHealthPropertiesInternal

    {
        /// <summary>The categorized resource counts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ContainerHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ContainerHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        int? ContainerHealthResourceCount { get; set; }
        /// <summary>The list of the health detail of the containers in the vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary ContainersHealth { get; set; }
        /// <summary>The categorized resource counts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts FabricHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] FabricHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        int? FabricHealthResourceCount { get; set; }
        /// <summary>The list of the health detail of the fabrics in the vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary FabricsHealth { get; set; }
        /// <summary>The categorized resource counts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummaryCategorizedResourceCounts ProtectedItemHealthCategorizedResourceCount { get; set; }
        /// <summary>The list of summary of health errors across the resources under the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthErrorSummary[] ProtectedItemHealthIssue { get; set; }
        /// <summary>The count of total resources under the container.</summary>
        int? ProtectedItemHealthResourceCount { get; set; }
        /// <summary>The list of the health detail of the protected items in the vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceHealthSummary ProtectedItemsHealth { get; set; }
        /// <summary>The list of errors on the vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[] VaultError { get; set; }

    }
}